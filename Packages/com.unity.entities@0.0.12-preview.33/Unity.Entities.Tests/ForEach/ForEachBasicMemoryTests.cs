#if !UNITY_DOTSPLAYER
using System;
using NUnit.Framework;

// ReSharper disable MemberCanBeMadeStatic.Local

namespace Unity.Entities.Tests.ForEach
{
    // these tests are intended to confirm that compiled code allocs exactly how we expect

    class ForEachBasicMemoryTests : ForEachMemoryTestFixtureBase
    {
        // SANITY

        [Test]
        public void StackAllocValueType_ShouldRecordNoGCAllocs()
        {
            AllocRecorder.enabled = true;

            // ReSharper disable once NotAccessedVariable
            var i = 0;
            ++i;

            AllocRecorder.enabled = false;
            Assert.Zero(AllocRecorder.sampleBlockCount);
        }

        [Test]
        public void NewArray_ShouldRecordOneGCAlloc()
        {
            AllocRecorder.enabled = true;

            var t = new int[1];
            t[0] = 1;

            AllocRecorder.enabled = false;
            Assert.AreEqual(1, AllocRecorder.sampleBlockCount);
        }
    }
}
#endif // !UNITY_DOTSPLAYER
