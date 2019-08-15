using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.Entities.Tests
{
    unsafe class EntityQueryCacheTests
    {
        [SetUp]
        public void Setup()
        {
            TypeManager.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
            TypeManager.Shutdown();
        }

        [Test]
        public void Ctor_WithCacheSize0_Throws()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.Throws<ArgumentOutOfRangeException>(() => new EntityQueryCache(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new EntityQueryCache(-1));
            // ReSharper restore ObjectCreationAsStatement
        }

        static void SimpleWrapCreateCachedQuery(EntityQueryCache cache, uint hash, EntityQuery group)
        {
            #if ENABLE_UNITY_COLLECTIONS_CHECKS
            var builder = new EntityQueryBuilder();
            cache.CreateCachedQuery(hash, group, ref builder, null, 0);
            #else
            cache.CreateCachedQuery(hash, group);
            #endif
        }

        [Test]
        public void CalcUsedCacheCount_WithEmptyCache_ReturnsZero()
        {
            var cache = new EntityQueryCache(1);

            Assert.AreEqual(0, cache.CalcUsedCacheCount());
        }

        [Test]
        public void CalcUsedCacheCount_WithSomeInCache_ReturnsCorrectNumber()
        {
            var cache = new EntityQueryCache(2);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);

            Assert.AreEqual(1, cache.CalcUsedCacheCount());
        }

        [Test]
        public void CalcUsedCacheCount_WithFullCache_ReturnsCorrectNumber()
        {
            var cache = new EntityQueryCache(1);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);

            Assert.AreEqual(1, cache.CalcUsedCacheCount());
        }

        [Test]
        public void FindQueryInCache_WithEmptyCache_ReturnsErrorIndex()
        {
            var cache = new EntityQueryCache(1);

            var found = cache.FindQueryInCache(0);

            Assert.Less(found, 0);
        }

        [Test]
        public void FindQueryInCache_WithHashNotFound_ReturnsErrorIndex()
        {
            var cache = new EntityQueryCache(1);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);

            var found = cache.FindQueryInCache(1);

            Assert.Less(found, 0);
        }

        [Test]
        public void FindQueryInCache_WithHashFound_ReturnsFoundIndex()
        {
            var cache = new EntityQueryCache(2);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);
            SimpleWrapCreateCachedQuery(cache, 1, k_DummyGroup);

            var found = cache.FindQueryInCache(1);

            Assert.AreEqual(1, found);
        }

        readonly Regex k_ResizeError = new Regex(".*is too small to hold the current number of queries.*");
        readonly EntityQuery k_DummyGroup = new EntityQuery(null, null, null, null);

        [Test]
        public void CreateCachedQuery_WithNullGroup_Throws()
        {
            var cache = new EntityQueryCache(1);

            Assert.Throws<ArgumentNullException>(() => SimpleWrapCreateCachedQuery(cache, 2, null));
        }

// TEMPORARY HACK
#if !UNITY_DOTSPLAYER
        [Test]
        public void CreateCachedQuery_OverflowWithCacheSize1_ResizesAndWarns()
        {
            var cache = new EntityQueryCache(1);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);

            LogAssert.Expect(LogType.Error, k_ResizeError);
            SimpleWrapCreateCachedQuery(cache, 1, k_DummyGroup);
        }

        [Test]
        public void CreateCachedQuery_OverflowWithCacheSize4_ResizesByAtLeastHalf()
        {
            var cache = new EntityQueryCache(4);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);
            SimpleWrapCreateCachedQuery(cache, 1, k_DummyGroup);
            SimpleWrapCreateCachedQuery(cache, 2, k_DummyGroup);
            SimpleWrapCreateCachedQuery(cache, 3, k_DummyGroup);

            LogAssert.Expect(LogType.Error, k_ResizeError);
            SimpleWrapCreateCachedQuery(cache, 4, k_DummyGroup);

            // this should not error
            SimpleWrapCreateCachedQuery(cache, 5, k_DummyGroup);
        }
#endif // !UNITY_DOTSPLAYER

        [Test]
        public void CreateCachedQuery_WithExistingHash_Throws()
        {
            var cache = new EntityQueryCache(1);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);

            Assert.Throws<InvalidOperationException>(() => SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup));
        }

        [Test]
        public void GetCachedQuery_WithValidIndex_ReturnsGroup()
        {
            var cache = new EntityQueryCache(1);
            SimpleWrapCreateCachedQuery(cache, 0, k_DummyGroup);

            var group = cache.GetCachedQuery(0);

            Assert.AreEqual(k_DummyGroup, group);
        }

        [Test]
        public void GetCachedQuery_WithInvalidIndex_Throws()
        {
            var cache = new EntityQueryCache(1);

            Assert.Throws<IndexOutOfRangeException>(() => cache.GetCachedQuery(1));
        }
#if ENABLE_UNITY_COLLECTIONS_CHECKS

        [Test]
        public void ValidateMatchesCache_WithValidMatch_DoesNotThrow()
        {
            var cache = new EntityQueryCache(1);
            int index;
            fixed (int* delegateTypes = new[] { 1 })
            {
                var builder = new EntityQueryBuilder().WithAll<EcsTestTag>();
                index = cache.CreateCachedQuery(0, k_DummyGroup, ref builder, delegateTypes, 1);
            }

            Assert.AreEqual(0, index);

            var testBuilder = new EntityQueryBuilder().WithAll<EcsTestTag>();

            fixed (int* testDelegateTypes = new[] { 1 })
                cache.ValidateMatchesCache(index, ref testBuilder, testDelegateTypes, 1);
        }

        [Test]
        public void ValidateMatchesCache_WithMismatchedBuilder_Throws()
        {
            var cache = new EntityQueryCache(1);
            var builder = new EntityQueryBuilder().WithAll<EcsTestTag>();
            var index = cache.CreateCachedQuery(0, k_DummyGroup, ref builder, null, 0);

            var anotherBuilder = new EntityQueryBuilder();
            Assert.IsFalse(builder.ShallowEquals(ref anotherBuilder));

            Assert.Throws<InvalidOperationException>(() => cache.ValidateMatchesCache(index, ref anotherBuilder, null, 0));
        }

        [Test]
        public void ValidateMatchesCache_WithMismatchedDelegateTypeIndices_Throws()
        {
            var cache = new EntityQueryCache(1);
            var builder = new EntityQueryBuilder().WithAll<EcsTestTag>();
            int index;
            fixed (int* delegateTypes = new[] { 1 })
                index = cache.CreateCachedQuery(0, k_DummyGroup, ref builder, delegateTypes, 1);

            Assert.Throws<InvalidOperationException>(() => cache.ValidateMatchesCache(index, ref builder, null, 0));

            // note: can't use a `fixed` var inside a closure, so below we implement a manual Assert.Throws

            InvalidOperationException testException0 = null;
            try
            {
                fixed (int* anotherDelegateTypes0 = new[] { 2 })
                    cache.ValidateMatchesCache(index, ref builder, anotherDelegateTypes0, 1);
            }
            catch (InvalidOperationException x) { testException0 = x; }
            Assert.NotNull(testException0);

            InvalidOperationException testException1 = null;
            try
            {
                fixed (int* anotherDelegateTypes1 = new[] { 1, 2 })
                    cache.ValidateMatchesCache(index, ref builder, anotherDelegateTypes1, 2);
            }
            catch (InvalidOperationException x) { testException1 = x; }
            Assert.NotNull(testException1);
        }
#endif
    }
}
