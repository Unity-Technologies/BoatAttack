using System;
using NUnit.Framework;

namespace Unity.Entities.Tests
{
    class EntityArchetypeQueryTests : ECSTestsFixture
    {
        [Test]
        public void EntityQueryFilter_IdenticalIds_InDifferentFilters_Throws()
        {
            var query = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(EcsTestData)},
                None = new ComponentType[] {typeof(EcsTestData)}
            };

            Assert.Throws<EntityQueryDescValidationException>(() =>
            {
                query.Validate();
            });
        }

        [Test]
        public void EntityQueryFilter_IdenticalIds_InSameFilter_Throws()
        {
            var query = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(EcsTestData), typeof(EcsTestData)}
            };

            Assert.Throws<EntityQueryDescValidationException>(() =>
            {
                query.Validate();
            });
        }

        [Test]
        public void EntityQueryFilter_MultipleIdenticalIds_Throws()
        {
            var query = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(EcsTestData), typeof(EcsTestData2)},
                None = new ComponentType[] {typeof(EcsTestData3), typeof(EcsTestData)},
                Any = new ComponentType[] {typeof(EcsTestData), typeof(EcsTestData4)},
            };

            Assert.Throws<EntityQueryDescValidationException>(() =>
            {
                query.Validate();
            });
        }

        [Test]
        public void EntityQueryFilter_SeparatedIds()
        {
            var query = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(EcsTestData), typeof(EcsTestData2)},
                None = new ComponentType[] {typeof(EcsTestData3), typeof(EcsTestData4)},
                Any = new ComponentType[] {typeof(EcsTestData5)},
            };

            Assert.DoesNotThrow(() =>
            {
                query.Validate();
            });
        }

        [Test]
        public void EntityQueryFilter_CannotContainExcludeComponentType_All_Throws()
        {
            var query = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(EcsTestData), ComponentType.Exclude<EcsTestData2>() },
            };

            Assert.Throws<ArgumentException>(() =>
            {
                query.Validate();
            });
        }

        [Test]
        public void EntityQueryFilterCannotContainExcludeComponentType_Any_Throws()
        {
            var query = new EntityQueryDesc
            {
                Any = new ComponentType[] {typeof(EcsTestData), ComponentType.Exclude<EcsTestData2>() },
            };

            Assert.Throws<ArgumentException>(() =>
            {
                query.Validate();
            });
        }

        [Test]
        public void EntityQueryFilterCannotContainExcludeComponentType_None_Throws()
        {
            var query = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(EcsTestData) },
                None = new ComponentType[] {typeof(EcsTestData3), ComponentType.Exclude<EcsTestData4>() },
            };

            Assert.Throws<ArgumentException>(() =>
            {
                query.Validate();
            });
        }
    }
}
