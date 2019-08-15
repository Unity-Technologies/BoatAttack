using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Entities.Tests.Types
{
#if !NET_DOTS
    [TestFixture]
    public class LayoutUtilityManagedTests : ECSTestsFixture
    {
        public enum AnEnum
        {
            A, B, C
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEmpty
        {
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SA
        {
            public byte AByte;
            public int AnInt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SAllSizes
        {
            public byte AByte;
            public ushort AnUshort;
            public int AnInt;
            public ulong AnUlong;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SNested
        {
            public SA A;
            public SA B;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SGeneric<T>
        {
            public T A;
            public T B;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SWithEnum
        {
            public AnEnum A;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SWithBool
        {
            public bool A;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SWithClassMember
        {
            public string A;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SWithPointer
        {
            public int* A;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SWithFixedArray
        {
            public fixed int A[4];
        }

        [Test]
        public void LayoutSA()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SA), Allocator.Temp))
            {
                Assert.AreEqual(2, layout.Length);
                Assert.AreEqual(0, layout[0].Offset);
                Assert.AreEqual(1, layout[0].Size);
                Assert.AreEqual(4, layout[1].Offset);
                Assert.AreEqual(4, layout[1].Size);
            }
        }

        [Test]
        public void LayoutEmpty()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SEmpty), Allocator.Temp))
            {
                Assert.AreEqual(0, layout.Length);
            }
        }

        [Test]
        public void LayoutAllSizes()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SAllSizes), Allocator.Temp))
            {
                Assert.AreEqual(4, layout.Length);
                Assert.AreEqual(0, layout[0].Offset);
                Assert.AreEqual(1, layout[0].Size);
                Assert.AreEqual(2, layout[1].Offset);
                Assert.AreEqual(2, layout[1].Size);
                Assert.AreEqual(4, layout[2].Offset);
                Assert.AreEqual(4, layout[2].Size);
                Assert.AreEqual(8, layout[3].Offset);
                Assert.AreEqual(8, layout[3].Size);
            }
        }

        [Test]
        public void LayoutNested()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SNested), Allocator.Temp))
            {
                Assert.AreEqual(4, layout.Length);
                Assert.AreEqual(0, layout[0].Offset);
                Assert.AreEqual(1, layout[0].Size);
                Assert.AreEqual(4, layout[1].Offset);
                Assert.AreEqual(4, layout[1].Size);
                Assert.AreEqual(8, layout[2].Offset);
                Assert.AreEqual(1, layout[2].Size);
                Assert.AreEqual(12, layout[3].Offset);
                Assert.AreEqual(4, layout[3].Size);
            }
        }

        [Test]
        public void LayoutClassThrows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(string), Allocator.Temp))
                {
                }
            });
        }

        [Test]
        public void LayoutGenericThrows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SGeneric<>), Allocator.Temp))
                {
                }
            });
        }

        [Test]
        public void LayoutClassMemberThrows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SWithClassMember), Allocator.Temp))
                {
                }
            });
        }

        [Test]
        public void LayoutGenericInstanceWorks()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SGeneric<int>), Allocator.Temp))
            {
                Assert.AreEqual(2, layout.Length);
                Assert.AreEqual(0, layout[0].Offset);
                Assert.AreEqual(4, layout[0].Size);
                Assert.AreEqual(4, layout[1].Offset);
                Assert.AreEqual(4, layout[1].Size);
            }
        }

        [Test]
        public void LayoutPrimitiveWorks()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(int), Allocator.Temp))
            {
                Assert.AreEqual(1, layout.Length);
                Assert.AreEqual(0, layout[0].Offset);
                Assert.AreEqual(4, layout[0].Size);
            }
        }

        [Test]
        public void LayoutEnum()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SWithEnum), Allocator.Temp))
            {
                Assert.AreEqual(1, layout.Length);
                Assert.AreEqual(0, layout[0].Offset);
                Assert.AreEqual(4, layout[0].Size);
            }
        }

        [Test]
        public void LayoutBool()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SWithBool), Allocator.Temp))
            {
                Assert.AreEqual(1, layout.Length);
                Assert.AreEqual(0, layout[0].Offset);
                Assert.AreEqual(1, layout[0].Size);
            }
        }

        [Test]
        public void LayoutPointer()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SWithPointer), Allocator.Temp))
            {
                unsafe
                {
                    Assert.AreEqual(1, layout.Length);
                    Assert.AreEqual(0, layout[0].Offset);
                    Assert.AreEqual(sizeof(IntPtr), layout[0].Size);
                }
            }
        }

        [Test]
        public void LayoutFixedArray()
        {
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(SWithFixedArray), Allocator.Temp))
            {
                unsafe
                {
                    Assert.AreEqual(4, layout.Length);
                    for (int i = 0; i < 4; ++i)
                    {
                        Assert.AreEqual(i * 4, layout[i].Offset);
                        Assert.AreEqual(4, layout[i].Size);
                    }
                }
            }
        }
    }

    [TestFixture]
    public class LayoutUtilityTests : ECSTestsFixture
    {
        struct TestData
        {
            public byte A;
            public short B;
            public int C;
            public float D;
            public ulong E;
        }

        private static int SumMemberSizes(NativeArray<SOAFieldInfo> fields)
        {
            int sum = 0;

            for (int i = 0; i < fields.Length; ++i)
            {
                sum += fields[i].Size;
            }

            return sum;
        }

        private static NativeArray<byte> CreateSOABuffer(NativeArray<SOAFieldInfo> fields, int capacity, Allocator allocator)
        {
            int byteSize = SumMemberSizes(fields) * capacity;
            return new NativeArray<byte>(byteSize, allocator);
        }

        [Test]
        public unsafe void FullSOAScatter([Values(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 15)] int slot)
        {
            const int arraySize = 16;
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(TestData), Allocator.Temp))
            using (var bufferOrig = CreateSOABuffer(layout, arraySize, Allocator.Temp))
            {
                var buffer = bufferOrig;

                var item = new TestData()
                {
                    A = 0x01,
                    B = 0x0203,
                    C = 0x04050607,
                    D = math.asfloat(0x41424344), // about 12.079, has distinct byte patterns from other data
                    E = 0x08090a0b0c0d0e0f,
                };

                for (int i = 0; i < buffer.Length; ++i)
                {
                    buffer[i] = 0xcc;
                }

                LayoutUtility.ScatterFullSOA(layout, (byte*) buffer.GetUnsafePtr(), &item, slot, arraySize);

                int rowOffset = 0;
                Assert.AreEqual(0x01, buffer[rowOffset + slot]);

                rowOffset = arraySize * 1;

                Assert.AreEqual(0x03, buffer[rowOffset + 2 * slot + 0]);
                Assert.AreEqual(0x02, buffer[rowOffset + 2 * slot + 1]);

                rowOffset += arraySize * 2;

                Assert.AreEqual(0x07, buffer[rowOffset + 4 * slot + 0]);
                Assert.AreEqual(0x06, buffer[rowOffset + 4 * slot + 1]);
                Assert.AreEqual(0x05, buffer[rowOffset + 4 * slot + 2]);
                Assert.AreEqual(0x04, buffer[rowOffset + 4 * slot + 3]);

                rowOffset += arraySize * 4;

                Assert.AreEqual(0x44, buffer[rowOffset + 4 * slot + 0]);
                Assert.AreEqual(0x43, buffer[rowOffset + 4 * slot + 1]);
                Assert.AreEqual(0x42, buffer[rowOffset + 4 * slot + 2]);
                Assert.AreEqual(0x41, buffer[rowOffset + 4 * slot + 3]);

                rowOffset += arraySize * 4;

                Assert.AreEqual(0x0f, buffer[rowOffset + 8 * slot + 0]);
                Assert.AreEqual(0x0e, buffer[rowOffset + 8 * slot + 1]);
                Assert.AreEqual(0x0d, buffer[rowOffset + 8 * slot + 2]);
                Assert.AreEqual(0x0c, buffer[rowOffset + 8 * slot + 3]);
                Assert.AreEqual(0x0b, buffer[rowOffset + 8 * slot + 4]);
                Assert.AreEqual(0x0a, buffer[rowOffset + 8 * slot + 5]);
                Assert.AreEqual(0x09, buffer[rowOffset + 8 * slot + 6]);
                Assert.AreEqual(0x08, buffer[rowOffset + 8 * slot + 7]);

                var item2 = default(TestData);
                LayoutUtility.GatherFullSOA(layout, (byte*) buffer.GetUnsafePtr(), &item2, slot, arraySize);

                Assert.AreEqual(item, item2);
            }
        }

        [Test]
        public unsafe void ChunkedSOAScatter([Values(0, 1, 2, 3, 4, 5, 6, 7, 8, 12, 15)] int slot)
        {
            const int arraySize = 16;
            using (var layout = LayoutUtilityManaged.CreateDescriptor(typeof(TestData), Allocator.Temp))
            using (var bufferOrig = CreateSOABuffer(layout, arraySize, Allocator.Temp))
            {
                var buffer = bufferOrig;
                int memberSizeSum = SumMemberSizes(layout);

                var item = new TestData()
                {
                    A = 0x01,
                    B = 0x0203,
                    C = 0x04050607,
                    D = math.asfloat(0x41424344), // about 12.079, has distinct byte patterns from other data
                    E = 0x08090a0b0c0d0e0f,
                };

                for (int i = 0; i < buffer.Length; ++i)
                {
                    buffer[i] = 0xcc;
                }

                LayoutUtility.ScatterChunkedSOA8(layout, memberSizeSum, (byte*) buffer.GetUnsafePtr(), &item, slot);

                int packetIndex = slot >> 3;
                int packetOffset = slot & 7;

                int rowOffset = packetIndex * 8 * memberSizeSum;

                Assert.AreEqual(0x01, buffer[rowOffset + packetOffset]);

                rowOffset += 8 * 1;

                Assert.AreEqual(0x03, buffer[rowOffset + 2 * packetOffset + 0]);
                Assert.AreEqual(0x02, buffer[rowOffset + 2 * packetOffset + 1]);

                rowOffset += 8 * 2;

                Assert.AreEqual(0x07, buffer[rowOffset + 4 * packetOffset + 0]);
                Assert.AreEqual(0x06, buffer[rowOffset + 4 * packetOffset + 1]);
                Assert.AreEqual(0x05, buffer[rowOffset + 4 * packetOffset + 2]);
                Assert.AreEqual(0x04, buffer[rowOffset + 4 * packetOffset + 3]);

                rowOffset += 8 * 4;

                Assert.AreEqual(0x44, buffer[rowOffset + 4 * packetOffset + 0]);
                Assert.AreEqual(0x43, buffer[rowOffset + 4 * packetOffset + 1]);
                Assert.AreEqual(0x42, buffer[rowOffset + 4 * packetOffset + 2]);
                Assert.AreEqual(0x41, buffer[rowOffset + 4 * packetOffset + 3]);

                rowOffset += 8 * 4;

                Assert.AreEqual(0x0f, buffer[rowOffset + 8 * packetOffset + 0]);
                Assert.AreEqual(0x0e, buffer[rowOffset + 8 * packetOffset + 1]);
                Assert.AreEqual(0x0d, buffer[rowOffset + 8 * packetOffset + 2]);
                Assert.AreEqual(0x0c, buffer[rowOffset + 8 * packetOffset + 3]);
                Assert.AreEqual(0x0b, buffer[rowOffset + 8 * packetOffset + 4]);
                Assert.AreEqual(0x0a, buffer[rowOffset + 8 * packetOffset + 5]);
                Assert.AreEqual(0x09, buffer[rowOffset + 8 * packetOffset + 6]);
                Assert.AreEqual(0x08, buffer[rowOffset + 8 * packetOffset + 7]);

                var item2 = default(TestData);
                LayoutUtility.GatherChunkedSOA8(layout, memberSizeSum, (byte*) buffer.GetUnsafePtr(), &item2, slot);

                Assert.AreEqual(item, item2);
            }
        }
    }
#endif
}
