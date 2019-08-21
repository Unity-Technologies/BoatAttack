using System;

namespace Unity.Entities
{
    class EntityQueryCache
    {
        uint[]                 m_CacheHashes; // combined hash of QueryComponentBuilder and delegate types
        EntityQuery[]          m_CachedEntityQueries;
        #if ENABLE_UNITY_COLLECTIONS_CHECKS
        EntityQueryBuilder[]   m_CacheCheckQueryBuilders;
        int[][]                m_CacheCheckDelegateTypeIndices;
        #endif

        public EntityQueryCache(int cacheSize = 10)
        {
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (cacheSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(cacheSize), "Cache size must be > 0");
            #endif

            m_CacheHashes = new uint[cacheSize];
            m_CachedEntityQueries = new EntityQuery[cacheSize];

            // we use these for an additional equality check to avoid accidental hash collisions
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_CacheCheckQueryBuilders = new EntityQueryBuilder[cacheSize];
            m_CacheCheckDelegateTypeIndices = new int[cacheSize][];
            #endif
        }

        public int CalcUsedCacheCount()
        {
            var used = 0;
            while (used < m_CacheHashes.Length && m_CachedEntityQueries[used] != null)
                ++used;

            return used;
        }

        public int FindQueryInCache(uint hash)
        {
            for (var i = 0; i < m_CacheHashes.Length && m_CachedEntityQueries[i] != null; ++i)
            {
                if (m_CacheHashes[i] == hash)
                    return i;
            }

            return -1;
        }

        public unsafe int CreateCachedQuery(uint hash, EntityQuery query
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            , ref EntityQueryBuilder builder, int* delegateTypeIndices, int delegateTypeCount
            #endif
            )
        {
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            #endif

            var index = 0;

            // find open slot or create one

            for (;;)
            {
                if (index == m_CacheHashes.Length)
                {
                    var newSize = m_CacheHashes.Length + Math.Max(m_CacheHashes.Length / 2, 1);

                    UnityEngine.Debug.LogError(
                        $"{nameof(EntityQueryCache)} is too small to hold the current number of queries this {nameof(ComponentSystem)} is running. The cache automatically expanded to {newSize}, " +
                        $"but this may cause a GC. Set cache size at init time via {nameof(ComponentSystem.InitEntityQueryCache)}() to a large enough number to ensure no allocations are required at run time.");

                    Array.Resize(ref m_CacheHashes, newSize);
                    Array.Resize(ref m_CachedEntityQueries, newSize);

                    #if ENABLE_UNITY_COLLECTIONS_CHECKS
                    Array.Resize(ref m_CacheCheckQueryBuilders, newSize);
                    Array.Resize(ref m_CacheCheckDelegateTypeIndices, newSize);
                    #endif
                    break;
                }

                if (m_CachedEntityQueries[index] == null)
                    break;

                #if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (m_CacheHashes[index] == hash)
                    throw new InvalidOperationException($"Unexpected {nameof(CreateCachedQuery)} with hash {hash} that already exists in cache at slot {index}");
                #endif

                ++index;
            }

            // store in cache

            m_CacheHashes[index] = hash;
            m_CachedEntityQueries[index] = query;

            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_CacheCheckQueryBuilders[index] = builder;
            var checkDelegateTypeIndices = new int[delegateTypeCount];
            for (var i = 0; i < delegateTypeCount; ++i)
                checkDelegateTypeIndices[i] = delegateTypeIndices[i];
            m_CacheCheckDelegateTypeIndices[index] = checkDelegateTypeIndices;
            #endif

            return index;
        }

        public EntityQuery GetCachedQuery(int cacheIndex)
            => m_CachedEntityQueries[cacheIndex];

        #if ENABLE_UNITY_COLLECTIONS_CHECKS
        public unsafe void ValidateMatchesCache(int foundCacheIndex, ref EntityQueryBuilder builder, int* delegateTypeIndices, int delegateTypeCount)
        {
            if (!builder.ShallowEquals(ref m_CacheCheckQueryBuilders[foundCacheIndex]))
                goto bad;

            var cached = m_CacheCheckDelegateTypeIndices[foundCacheIndex];
            if (cached.Length != delegateTypeCount)
                goto bad;

            for (var i = 0; i < delegateTypeCount; ++i)
            {
                if (cached[i] != delegateTypeIndices[i])
                    goto bad;
            }

            return;

        bad:
            throw new InvalidOperationException("Type signature does not match cached");
        }
        #endif
    }
}
