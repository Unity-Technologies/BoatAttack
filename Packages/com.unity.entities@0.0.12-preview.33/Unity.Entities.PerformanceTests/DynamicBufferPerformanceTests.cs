using NUnit.Framework;
using Unity.Collections;
using Unity.PerformanceTesting;
using UnityEditor.UIElements;

namespace Unity.Entities.PerformanceTests
{
    [TestFixture]
    [Category("Performance")]
    public sealed class DynamicBufferPerformanceTests
    {
        World m_PreviousWorld;
        World m_World;
        EntityManager m_Manager;
        EntityQuery group;

        private const int kLargeAllocation = 32 * 1024 * 1024 / sizeof(int);
        private const int kSmallAllocation = 1 * 1024 / sizeof(int);
        private const int kTinyAllocation = 4;

        /// <summary>
        /// To get a reasonable reading from the tiny and small tests we need to run the code a lot more.
        /// </summary>
        private const int kTimesToCopyInManyTest = 10000;

        private NativeArray<EcsIntElement> nativeArrayLarge;
        private NativeArray<EcsIntElement> nativeArraySmall;
        private NativeArray<EcsIntElement> nativeArrayTiny;

        private EcsIntElement[] arrayLarge;
        private EcsIntElement[] arraySmall;
        private EcsIntElement[] arrayTiny;

        [SetUp]
        public void Setup()
        {
            m_PreviousWorld = World.Active;
            m_World = World.Active = new World("Test World");
            m_Manager = m_World.EntityManager;
            nativeArrayLarge = new NativeArray<EcsIntElement>(kLargeAllocation, Allocator.Persistent);
            nativeArraySmall = new NativeArray<EcsIntElement>(kSmallAllocation, Allocator.Persistent);
            nativeArrayTiny = new NativeArray<EcsIntElement>(kTinyAllocation, Allocator.Persistent);
            arrayLarge = new EcsIntElement[kLargeAllocation];
            arraySmall = new EcsIntElement[kSmallAllocation];
            arrayTiny = new EcsIntElement[kTinyAllocation];

            for (var i = 0; i < kLargeAllocation; ++i)
            {
                if (i < kTinyAllocation)
                {
                    nativeArrayTiny[i] = i;
                    arrayTiny[i] = i;
                }

                if (i < kSmallAllocation)
                {
                    nativeArraySmall[i] = i;
                    arraySmall[i] = i;
                }

                nativeArrayLarge[i] = i;
                arrayLarge[i] = i;
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (m_Manager != null)
            {
                m_World.Dispose();
                m_World = null;

                World.Active = m_PreviousWorld;
                m_PreviousWorld = null;
                m_Manager = null;
            }
            nativeArrayLarge.Dispose();
            nativeArraySmall.Dispose();
            nativeArrayTiny.Dispose();
        }

        public struct EcsIntElement : IBufferElementData
        {
            public static implicit operator int(EcsIntElement e)
            {
                return e.Value;
            }

            public static implicit operator EcsIntElement(int e)
            {
                return new EcsIntElement {Value = e};
            }

            public int Value;
        }

#if UNITY_2019_2_OR_NEWER
        [Test, Performance]
#else
        [PerformanceTest]
#endif
        public void CopyFromDynamicBuffer()
        {
            var e = m_Manager.CreateEntity();
            var f = m_Manager.CreateEntity();

            m_Manager.AddBuffer<EcsIntElement>(e);
            m_Manager.AddBuffer<EcsIntElement>(f);

            var src = m_Manager.GetBuffer<EcsIntElement>(e);
            var dst = m_Manager.GetBuffer<EcsIntElement>(f);

            src.Reserve(kTinyAllocation);
            dst.Reserve(kTinyAllocation);

            for (var i = 0; i < kTinyAllocation; ++i)
            {
                src.Add(1);
                dst.Add(2);
            }

            Measure.Method(
                    () =>
                    {
                        for(var i = 0; i < kTimesToCopyInManyTest; ++i)
                            dst.CopyFrom(src);
                    })
                .Definition("Tiny")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            src.Reserve(kSmallAllocation);
            dst.Reserve(kSmallAllocation);

            for (var i = kTinyAllocation; i < kSmallAllocation; ++i)
            {
                src.Add(1);
                dst.Add(2);
            }

            Measure.Method(
                    () =>
                    {
                        for(var i = 0; i < kTimesToCopyInManyTest; ++i)
                            dst.CopyFrom(src);
                    })
                .Definition("Small")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            src.Reserve(kLargeAllocation);
            dst.Reserve(kLargeAllocation);

            for (var i = kSmallAllocation; i < kLargeAllocation; ++i)
            {
                src.Add(1);
                dst.Add(2);
            }

            Measure.Method(
                    () =>
                    {
                        dst.CopyFrom(src);
                    })
                .Definition("Large")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            m_Manager.DestroyEntity(e);
            m_Manager.DestroyEntity(f);

        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
#else
        [PerformanceTest]
#endif
        public void CopyFromNativeArray()
        {
            var e = m_Manager.CreateEntity();

            m_Manager.AddBuffer<EcsIntElement>(e);

            var dst = m_Manager.GetBuffer<EcsIntElement>(e);

            dst.Reserve(kTinyAllocation);

            for (var i = 0; i < kTinyAllocation; ++i)
            {
                dst.Add(0);
            }

            Measure.Method(
                    () =>
                    {
                        for(var i = 0; i < kTimesToCopyInManyTest; ++i)
                            dst.CopyFrom(nativeArrayTiny);
                    })
                .Definition("Tiny")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            dst.Reserve(kSmallAllocation);

            for (var i = kTinyAllocation; i < kSmallAllocation; ++i)
            {
                dst.Add(1);
            }

            Measure.Method(
                    () =>
                    {
                        for(var i = 0; i < kTimesToCopyInManyTest; ++i)
                            dst.CopyFrom(nativeArraySmall);
                    })
                .Definition("Small")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            dst.Reserve(kLargeAllocation);

            for (var i = kSmallAllocation; i < kLargeAllocation; ++i)
            {
                dst.Add(2);
            }

            Measure.Method(
                    () =>
                    {
                        dst.CopyFrom(nativeArrayLarge);
                    })
                .Definition("Large")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            m_Manager.DestroyEntity(e);
        }

#if UNITY_2019_2_OR_NEWER
        [Test, Performance]
#else
        [PerformanceTest]
#endif
        public void CopyFromArray()
        {
            var e = m_Manager.CreateEntity();

            m_Manager.AddBuffer<EcsIntElement>(e);

            var dst = m_Manager.GetBuffer<EcsIntElement>(e);

            dst.Reserve(kTinyAllocation);

            for (var i = 0; i < kTinyAllocation; ++i)
            {
                dst.Add(0);
            }

            Measure.Method(
                    () =>
                    {
                        for(var i = 0; i < kTimesToCopyInManyTest; ++i)
                            dst.CopyFrom(arrayTiny);
                    })
                .Definition("Tiny")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            dst.Reserve(kSmallAllocation);

            for (var i = kTinyAllocation; i < kSmallAllocation; ++i)
            {
                dst.Add(1);
            }

            Measure.Method(
                    () =>
                    {
                        for(var i = 0; i < kTimesToCopyInManyTest; ++i)
                            dst.CopyFrom(arraySmall);
                    })
                .Definition("Small")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            dst.Reserve(kLargeAllocation);

            for (var i = kSmallAllocation; i < kLargeAllocation; ++i)
            {
                dst.Add(2);
            }

            Measure.Method(
                    () =>
                    {
                        dst.CopyFrom(arrayLarge);
                    })
                .Definition("Large")
                .WarmupCount(100)
                .MeasurementCount(500)
                .Run();

            m_Manager.DestroyEntity(e);
        }

    }
}
