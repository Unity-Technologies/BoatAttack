using System;
// TEMPORARY HACK
//using JetBrains.Annotations;
using NUnit.Framework;

namespace Unity.Entities.Tests
{
    class EntityQueryBuilderTestFixture : ECSTestsFixture
    {
        protected class TestComponentSystem : ComponentSystem
            { protected override void OnUpdate() { } }

        protected static TestComponentSystem TestSystem => World.Active.GetOrCreateSystem<TestComponentSystem>();
    }

    class EntityQueryBuilderTests : EntityQueryBuilderTestFixture
    {
        class TestComponentSystem2 : ComponentSystem
            { protected override void OnUpdate() { } }

        static TestComponentSystem2 TestSystem2 => World.Active.GetOrCreateSystem<TestComponentSystem2>();

        [Test]
        public void WithGroup_WithNullGroup_Throws() =>
            Assert.Throws<ArgumentNullException>(() => TestSystem.Entities.With(null));

        [Test]
        public void WithGroup_WithExistingGroup_Throws()
        {
            var group0 = TestSystem.GetEntityQuery(ComponentType.ReadWrite<EcsTestData>());
            var group1 = TestSystem.GetEntityQuery(ComponentType.ReadOnly<EcsTestData>());

            var query = TestSystem.Entities.With(group0);

            Assert.Throws<InvalidOperationException>(() => query.With(group1));
        }

        [Test]
        public void WithGroup_WithExistingSpec_Throws()
        {
            var group = TestSystem.GetEntityQuery(ComponentType.ReadWrite<EcsTestData>());

            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.WithAny<EcsTestData>().With(group));
            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.WithNone<EcsTestData>().With(group));
            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.WithAll<EcsTestData>().With(group));
        }

        [Test]
        public void WithSpec_WithExistingGroup_Throws()
        {
            var group = TestSystem.GetEntityQuery(ComponentType.ReadWrite<EcsTestData>());

            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.With(group).WithAny<EcsTestData>());
            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.With(group).WithNone<EcsTestData>());
            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.With(group).WithAll<EcsTestData>());
        }

        [Test]
        public void Equals_WithMatchedButDifferentlyConstructedBuilders_ReturnsTrue()
        {
            var builder0 = TestSystem.Entities
                .WithAll<EcsTestTag>()
                .WithAny<EcsTestData, EcsTestData2>()
                .WithNone<EcsTestData3, EcsTestData4, EcsTestData5>();
            var builder1 = new EntityQueryBuilder(TestSystem)
                .WithNone<EcsTestData3>()
                .WithAll<EcsTestTag>()
                .WithAny<EcsTestData>()
                .WithNone<EcsTestData4, EcsTestData5>()
                .WithAny<EcsTestData2>();

            Assert.IsTrue(builder0.ShallowEquals(ref builder1));
        }

        [Test]
        public void Equals_WithSlightlyDifferentlyConstructedBuilders_ReturnsFalse()
        {
            var builder0 = TestSystem.Entities
                .WithAll<EcsTestTag>()
                .WithAny<EcsTestData, EcsTestData2>()
                .WithNone<EcsTestData3, EcsTestData4, EcsTestData5>();
            var builder1 = new EntityQueryBuilder(TestSystem)
                .WithAll<EcsTestTag>()
                .WithAny<EcsTestData>();

            Assert.IsFalse(builder0.ShallowEquals(ref builder1));
        }

        [Test]
        public void Equals_WithDifferentGroups_ReturnsFalse()
        {
            var group0 = TestSystem.GetEntityQuery(ComponentType.ReadWrite<EcsTestData>());
            var group1 = TestSystem.GetEntityQuery(ComponentType.ReadOnly<EcsTestData>());

            var builder0 = TestSystem.Entities.With(group0);
            var builder1 = TestSystem.Entities.With(group1);

            Assert.IsFalse(builder0.ShallowEquals(ref builder1));
        }

        [Test]
        public void Equals_WithDifferentWritePermissionBuilders_ReturnsFalse()
        {
            var builder0 = TestSystem.Entities
                .WithAll<EcsTestTag>();
            var builder1 = new EntityQueryBuilder(TestSystem)
                .WithAllReadOnly<EcsTestTag>();

            Assert.IsFalse(builder0.ShallowEquals(ref builder1));
        }

        [Test]
        public void ObjectGetHashCode_Throws()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.GetHashCode());
        }

        [Test]
        public void ObjectEquals_Throws()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Assert.Throws<InvalidOperationException>(() => TestSystem.Entities.Equals(null));
        }

        [Test]
        public void Equals_WithMismatchedSystems_Throws()
        {
            var builder0 = TestSystem.Entities;
            var builder1 = TestSystem2.Entities;

            Assert.Throws<InvalidOperationException>(() => builder0.ShallowEquals(ref builder1));
        }

        [Test]
        public void Equals_WithMismatchedBuilders_ReturnsFalse()
        {
            {
                var builder0 = TestSystem.Entities.WithAll<EcsTestData>();
                var builder1 = TestSystem.Entities.WithAll<EcsTestData2>();
                Assert.IsFalse(builder0.ShallowEquals(ref builder1));
            }

            {
                var builder0 = TestSystem.Entities.WithAny<EcsTestData3>();
                var builder1 = TestSystem.Entities.WithAny<EcsTestData3, EcsTestData4>();
                Assert.IsFalse(builder0.ShallowEquals(ref builder1));
            }

            {
                var builder0 = TestSystem.Entities.WithNone<EcsTestData3>();
                var builder1 = TestSystem.Entities.WithAll<EcsTestData3>();
                Assert.IsFalse(builder0.ShallowEquals(ref builder1));
            }

            {
                var group = TestSystem.GetEntityQuery(ComponentType.ReadWrite<EcsTestData>());
                var builder0 = TestSystem.Entities.With(group);
                var builder1 = TestSystem.Entities;
                Assert.IsFalse(builder0.ShallowEquals(ref builder1));
            }
        }

        [Test]
        public void ToEntityArchetypeQuery_WithFluentSpec_ReturnsQueryAsSpecified()
        {
            var eaq = TestSystem.Entities
                .WithAll<EcsTestTag>()
                .WithAny<EcsTestData, EcsTestData2>()
                .WithNone<EcsTestData3, EcsTestData4, EcsTestData5>()
                .With(EntityQueryOptions.Default)
                .ToEntityQueryDesc();

            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadWrite<EcsTestTag>() },
                eaq.All);
            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadWrite<EcsTestData>(), ComponentType.ReadWrite<EcsTestData2>() },
                eaq.Any);
            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadWrite<EcsTestData3>(), ComponentType.ReadWrite<EcsTestData4>(), ComponentType.ReadWrite<EcsTestData5>() },
                eaq.None);
        }

        [Test]
        public void ToEntityArchetypeQuery_WithFluentSpec_ReturnsReadOnlyQueryAsSpecified()
        {
            var eaq = TestSystem.Entities
                .WithAllReadOnly<EcsTestTag>()
                .WithAnyReadOnly<EcsTestData2>()
                .With(EntityQueryOptions.Default)
                .ToEntityQueryDesc();

            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadOnly<EcsTestTag>() },
                eaq.All);
            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadOnly<EcsTestData2>() },
                eaq.Any);
        }

        [Test]
        public void ToComponentGroup_OnceCached_StaysCached()
        {
            // this will cause the group to get cached in the query
            var query = TestSystem.Entities.WithAll<EcsTestTag>();
            query.ToEntityQuery();

            // this will throw because we're trying to modify the spec, yet we already have a group cached
            Assert.Throws<InvalidOperationException>(() => query.WithNone<EcsTestData>());
        }

        [Test]
        public void ForEach_WithReusedQueryButDifferentDelegateParams_Throws()
        {
            var entity = m_Manager.CreateEntity();
            m_Manager.AddComponentData(entity, new EcsTestData(0));
            m_Manager.AddComponentData(entity, new EcsTestData2(1));
            m_Manager.AddComponentData(entity, new EcsTestData3(2));

            var query = TestSystem.Entities.WithAllReadOnly<EcsTestData, EcsTestData2>();
            var oldQuery = query;

            // validate that each runs with a different componentgroup (if the second shared the first, we'd get a null ref)

            query.ForEach((ref EcsTestData3 three) => { Assert.NotNull(three); });
            query.ForEach((ref EcsTestData4 four) => { Assert.NotNull(four); });

            // also validate that the query has not been altered by either ForEach

            Assert.IsTrue(oldQuery.ShallowEquals(ref query));

            var eaq = query.ToEntityQueryDesc();
            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadWrite<EcsTestData>(), ComponentType.ReadWrite<EcsTestData2>() },
                eaq.All);
        }

        [Test]
        public void ForEach_WithIncludeDisabledOptions_ReturnsEntityWithDisabled()
        {
            var entity = m_Manager.CreateEntity();
            m_Manager.AddComponentData(entity, new EcsTestData(0));
            m_Manager.AddComponentData(entity, new Disabled());

            var query = TestSystem.Entities.WithAny<EcsTestData>().With(EntityQueryOptions.IncludeDisabled);

            bool entityFound = false;
            query.ForEach((Entity id) => { entityFound = true; });
            Assert.IsTrue(entityFound);
        }

        [Test]
        public void ForEach_WithoutIncludeDisabledOptions_ReturnsNoEntityWithDisabled()
        {
            var entity = m_Manager.CreateEntity();
            m_Manager.AddComponentData(entity, new EcsTestData(0));
            m_Manager.AddComponentData(entity, new Disabled());

            var query = TestSystem.Entities.WithAny<EcsTestData>().With(EntityQueryOptions.Default);

            bool entityFound = false;
            query.ForEach((Entity id) => { entityFound = true; });
            Assert.IsFalse(entityFound);
        }

        [Test]
        public void ForEach_WithAllReadOnlyAndWrite_Throws() =>
            Assert.Throws<EntityQueryDescValidationException>(() => 
            {
                var query = TestSystem.Entities.WithAll<EcsTestData>().WithAllReadOnly<EcsTestData>();
                query.ForEach((Entity id) => {});
            });

        [Test]
        public void ForEach_WithAllTypeInForEach_DoesNotThrow() =>
            Assert.DoesNotThrow(() => 
            {
                var query = TestSystem.Entities.WithAll<EcsTestData>();
                query.ForEach((Entity id, ref EcsTestData data) => {});
            });
        
        [Test]
        public void ForEach_WithAllReadOnlyTypeInForEach_DoesNotThrow() =>
            Assert.DoesNotThrow(() => 
            {
                var query = TestSystem.Entities.WithAllReadOnly<EcsTestData>();
                query.ForEach((Entity id, ref EcsTestData data) => {});
            });
        
        [Test]
        public void ForEach_WithAllReadOnlyTypeInForEach_OnlyHasReadOnlyType()
        {
            var query = TestSystem.Entities.WithAllReadOnly<EcsTestData>();
            query.ForEach((Entity id, ref EcsTestData data) => {});

            // validate that We only have EcsTestData as a ReadOnly type (WithAllReadOnly changes type to RO)
            var eaq = query.ToEntityQueryDesc();
            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadOnly<EcsTestData>() },
                eaq.All);
        }

        [Test]
        public void ForEach_WithAllTypeNotInForEachDelegate_OnlyHasReadOnlyType()
        {
            var query = TestSystem.Entities.WithAll<EcsTestData>();
            query.ForEach((Entity id) => {});

            // validate that We only have EcsTestData as a ReadOnly type (changed to ReadOnly as not in delegate)
            var eaq = query.ToEntityQueryDesc();
            CollectionAssert.AreEqual(
                new[] { ComponentType.ReadOnly<EcsTestData>() },
                eaq.All);
        }

		[Test]
        public void ForEach_WithIncludeDisabledOptionsAsSecondQuery_ReturnsEntityWithDisabled()
        {
            var entity = m_Manager.CreateEntity();
            m_Manager.AddComponentData(entity, new EcsTestData(0));
            m_Manager.AddComponentData(entity, new Disabled());

            var queryWithNoOptions = TestSystem.Entities.WithAny<EcsTestData>();
            queryWithNoOptions.ForEach((Entity id) => { });

            var queryWithIncludeDisabled = TestSystem.Entities.WithAny<EcsTestData>().With(EntityQueryOptions.IncludeDisabled);
            bool entityFound = false;
            queryWithIncludeDisabled.ForEach((Entity id) => { entityFound = true; });
            Assert.IsTrue(entityFound);
        }

        [Test]
        public void ForEach_WithAllTypes_HasCorrectAccessType([Values(1, 2, 3)] int readOnlyIndex)
        {
            ComponentType[] allComponentTypes = new ComponentType[3];
            var query = TestSystem.Entities;
            if (readOnlyIndex == 1)
            {
                query.WithAllReadOnly<EcsTestData>();
                allComponentTypes[0] = ComponentType.ReadOnly<EcsTestData>();
            }
            else
            {
                query.WithAll<EcsTestData>();
                allComponentTypes[0] = ComponentType.ReadWrite<EcsTestData>();
            }
            if (readOnlyIndex == 2)
            {
                query.WithAllReadOnly<EcsTestData2>();
                allComponentTypes[1] = ComponentType.ReadOnly<EcsTestData2>();
            }
            else
            {
                query.WithAll<EcsTestData2>();
                allComponentTypes[1] = ComponentType.ReadWrite<EcsTestData2>();
            }
            if (readOnlyIndex == 3)
            {
                query.WithAllReadOnly<EcsTestData3>();
                allComponentTypes[2] = ComponentType.ReadOnly<EcsTestData3>();
            }
            else
            {
                query.WithAll<EcsTestData3>();
                allComponentTypes[2] = ComponentType.ReadWrite<EcsTestData3>();
            }
            query.ForEach((Entity id, ref EcsTestData d1, ref EcsTestData2 d2, ref EcsTestData3 d3) => {});

            var eaq = query.ToEntityQueryDesc();

            CollectionAssert.AreEqual(allComponentTypes, eaq.All);
        }

        [Test]
        public void ForEach_WithAnyTypes_HasCorrectAccessType([Values(1, 2, 3)] int readOnlyIndex)
        {
            ComponentType[] anyComponentTypes = new ComponentType[3];
            var query = TestSystem.Entities;
            if (readOnlyIndex == 1)
            {
                query.WithAnyReadOnly<EcsTestData>();
                anyComponentTypes[0] = ComponentType.ReadOnly<EcsTestData>();
            }
            else
            {
                query.WithAny<EcsTestData>();
                anyComponentTypes[0] = ComponentType.ReadWrite<EcsTestData>();
            }
            if (readOnlyIndex == 2)
            {
                query.WithAnyReadOnly<EcsTestData2>();
                anyComponentTypes[1] = ComponentType.ReadOnly<EcsTestData2>();
            }
            else
            {
                query.WithAny<EcsTestData2>();
                anyComponentTypes[1] = ComponentType.ReadWrite<EcsTestData2>();
            }
            if (readOnlyIndex == 3)
            {
                query.WithAnyReadOnly<EcsTestData3>();
                anyComponentTypes[2] = ComponentType.ReadOnly<EcsTestData3>();
            }
            else
            {
                query.WithAny<EcsTestData3>();
                anyComponentTypes[2] = ComponentType.ReadWrite<EcsTestData3>();
            }
            query.ForEach((Entity id) => {});

            var eaq = query.ToEntityQueryDesc();

            CollectionAssert.AreEqual(anyComponentTypes, eaq.Any);
        }
    }
}
