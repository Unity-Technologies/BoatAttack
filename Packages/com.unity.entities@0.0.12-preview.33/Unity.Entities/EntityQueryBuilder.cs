using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Mathematics;

namespace Unity.Entities
{
    public partial struct EntityQueryBuilder
    {
        ComponentSystem m_System;
        uint m_AnyWritableBitField, m_AllWritableBitField;
        ResizableArray64Byte<int> m_Any, m_None, m_All;
        EntityQueryOptions m_Options;
        EntityQuery m_Query;

        internal EntityQueryBuilder(ComponentSystem system)
        {
            m_System = system;
            m_Any     = new ResizableArray64Byte<int>();
            m_None    = new ResizableArray64Byte<int>();
            m_All     = new ResizableArray64Byte<int>();
            m_AnyWritableBitField = m_AllWritableBitField = 0;
            m_Options = EntityQueryOptions.Default;
            m_Query  = null;
        }

        // this is a specialized function intended only for validation that builders are hashing and getting cached
        // correctly without unexpected collisions. "Equals" is hard to truly validate because the type may not
        // fully be constructed yet due to ForEach not getting called yet.
        internal bool ShallowEquals(ref EntityQueryBuilder other)
        {
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!ReferenceEquals(m_System, other.m_System))
                throw new InvalidOperationException($"Suspicious comparison of {nameof(EntityQueryBuilder)}s with different {nameof(ComponentSystem)}s");
            #endif

            return
                m_Any .Equals(ref other.m_Any)  &&
                m_None                  .Equals(ref other.m_None)           	&&
                m_All 					.Equals(ref other.m_All)  				&&
                m_AnyWritableBitField   .Equals(other.m_AnyWritableBitField) 	&&
                m_AllWritableBitField   .Equals(other.m_AllWritableBitField) 	&&
                m_Options   			.Equals(other.m_Options)  				&&
                ReferenceEquals(m_Query, other.m_Query);
        }

        public override int GetHashCode() =>
            throw new InvalidOperationException("Hashing implies storage, but this type should only live on the stack in user code");
        public override bool Equals(object obj) =>
            throw new InvalidOperationException("Calling this function is a sign of inadvertent boxing");

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void ValidateHasNoQuery() => ThrowIfInvalidMixing(m_Query != null);

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void ValidateHasNoSpec() => ThrowIfInvalidMixing(
            m_Any           .Length    != 0 || 
            m_None          .Length    != 0 || 
            m_All           .Length    != 0);

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void ThrowIfInvalidMixing(bool throwIfTrue)
        {
            if (throwIfTrue)
                throw new InvalidOperationException($"Cannot mix {nameof(WithAny)}/{nameof(WithAnyReadOnly)}/{nameof(WithNone)}/{nameof(WithAll)}/{nameof(WithAllReadOnly)} and {nameof(With)}({nameof(EntityQuery)})");
        }

        public EntityQueryBuilder With(EntityQuery entityQuery)
        {
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (entityQuery == null)
                throw new ArgumentNullException(nameof(entityQuery));
            if (m_Query != null)
                throw new InvalidOperationException($"{nameof(EntityQuery)} has already been set");
            ValidateHasNoSpec();
            #endif

            m_Query = entityQuery;
            return this;
        }

        public EntityQueryBuilder With(EntityQueryOptions options)
        {
            ValidateHasNoQuery();
            m_Options = options;

            return this;
        }

        EntityQueryDesc ToEntityQueryDesc(int delegateTypeCount)
        {
            ComponentType[] ToComponentTypes(ref ResizableArray64Byte<int> typeIndices, uint writableBitField, int extraCapacity)
            {
                var length = typeIndices.Length + extraCapacity;
                if (length == 0)
                    return Array.Empty<ComponentType>();

                var types = new ComponentType[length];

                for (var i = 0; i < typeIndices.Length; ++i)
                    types[i] = new ComponentType { TypeIndex = typeIndices[i], 
                        AccessModeType = (writableBitField & (1 << i)) != 0 ? ComponentType.AccessMode.ReadWrite : ComponentType.AccessMode.ReadOnly };

                return types;
            }

            return new EntityQueryDesc
            {
                Any         = ToComponentTypes(ref m_Any, m_AnyWritableBitField, 0),
                None        = ToComponentTypes(ref m_None, 0, 0),
                All         = ToComponentTypes(ref m_All, m_AllWritableBitField,  delegateTypeCount),
                Options = m_Options
            };
        }

        public EntityQueryDesc ToEntityQueryDesc() =>
            ToEntityQueryDesc(0);

        public EntityQuery ToEntityQuery() =>
            m_Query ?? (m_Query = m_System.GetEntityQuery(ToEntityQueryDesc()));

        // see EntityQueryBuilder.tt for the template that is converted into EntityQueryBuilder.gen.cs,
        // which contains ForEach and other generated methods.

        #if ENABLE_UNITY_COLLECTIONS_CHECKS
        EntityManager.InsideForEach InsideForEach() =>
            new EntityManager.InsideForEach(m_System.EntityManager);
        #endif

        // this changes the existing query in the following ways:
        // a) change anything that is currently ReadWrite in m_All but not in delegate types to ReadOnly 
        //  (there is no way to access as ReadWrite if not in delegate)
        // b) remove anything in delegate types that is also in m_All (m_All access type takes precedent)
        unsafe void SanitizeTypes(int* delegateTypeIndices, ref int delegateTypeCount)
        {
            // quadratic time but these arrays should be small, access is linear and this avoids further allocation
            var filteredDelegateTypeCount = 0;
            uint allTypesThatMatchWriteDelegate = 0;
            for (var iDelegateType = 0; iDelegateType < delegateTypeCount; ++iDelegateType)
            {
                for (var iAll = 0; iAll < m_All.Length; ++iAll)
                {
                    if (delegateTypeIndices[iDelegateType] == m_All[iAll])
                    {
                        if ((1 << iAll & m_AllWritableBitField) == 1)
                            allTypesThatMatchWriteDelegate |= (1U << iAll);
                        delegateTypeIndices[iDelegateType] = -1;
                    }
                }
                
                if (delegateTypeIndices[iDelegateType] != -1)
                    filteredDelegateTypeCount++;
            }

            // Toggle all writable types to read only if they are not in delegate (they can't be written to anyways)
            m_AllWritableBitField &= allTypesThatMatchWriteDelegate; 
            
            // sort all non -1 types forward in the case we marked some as invalid
            // (they are already in m_All as ReadOnly)
            if (filteredDelegateTypeCount != delegateTypeCount)
            {
                for (var iDelegateType = 0; iDelegateType < filteredDelegateTypeCount; ++iDelegateType)
                {
                    while (delegateTypeIndices[iDelegateType] == -1 && iDelegateType < filteredDelegateTypeCount)
                        delegateTypeIndices[iDelegateType] = delegateTypeIndices[iDelegateType + 1];
                }

                delegateTypeCount = filteredDelegateTypeCount;
            }
        }

        unsafe EntityQuery ResolveEntityQuery(int* delegateTypeIndices, int delegateTypeCount)
        {
            SanitizeTypes(delegateTypeIndices, ref delegateTypeCount);
            
            var hash
                = (uint)m_Any    .GetHashCode() * 0xEA928FF9
                ^ (uint)m_None   .GetHashCode() * 0x4B772F25
                ^ (uint)m_All    .GetHashCode() * 0xBAEE8991
                ^ (uint)m_AnyWritableBitField   .GetHashCode() * 0x8F8BF1C7
                ^ (uint)m_AllWritableBitField   .GetHashCode() * 0xB6D633F7
                ^ (uint)m_Options               .GetHashCode() * 0xE0B7379B
                ^ math.hash(delegateTypeIndices, sizeof(int) * delegateTypeCount);

            var cache = m_System.GetOrCreateEntityQueryCache();
            var found = cache.FindQueryInCache(hash);

            if (found < 0)
            {
                // base query from builder spec, but reserve some extra room for the types detected from the delegate
                var eaq = ToEntityQueryDesc(delegateTypeCount);

                // now fill out the extra types
                for (var i = 0 ; i < delegateTypeCount; ++i)
                    eaq.All[i + m_All.Length] = ComponentType.FromTypeIndex(delegateTypeIndices[i]);

                var query = m_System.GetEntityQuery(eaq);

                #if ENABLE_UNITY_COLLECTIONS_CHECKS
                found = cache.CreateCachedQuery(hash, query, ref this, delegateTypeIndices, delegateTypeCount);
                #else
                found = cache.CreateCachedQuery(hash, query);
                #endif
            }
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            else
            {
                cache.ValidateMatchesCache(found, ref this, delegateTypeIndices, delegateTypeCount);

                // TODO: also validate that m_Query spec matches m_Any/All/None and delegateTypeIndices
            }
            #endif

            return cache.GetCachedQuery(found);
        }
    }
}
