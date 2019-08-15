using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;

namespace Unity.Entities.Tests
{
    public class NativeArraySharedValuesTests
    {
        NativeArray<int> Source;
        NativeArraySharedValues<int> SharedValues;

        [TearDown]
        public void Cleanup()
        {
            if (Source.IsCreated)
            {
                SharedValues.Dispose();
                Source.Dispose();
            }
        }

        void PrepareReverseHalf(int count)
        {
            Source = new NativeArray<int>(count, Allocator.TempJob);
            for (int i = 0; i < count; i++)
            {
                Source[i] = count - (i / 2);
            }
            SharedValues = new NativeArraySharedValues<int>(Source, Allocator.TempJob);
            var sharedValuesJobHandle = SharedValues.Schedule(default(JobHandle));
            sharedValuesJobHandle.Complete();
        }

        void PrepareAllSame(int count)
        {
            Source = new NativeArray<int>(count, Allocator.TempJob);
            for (int i = 0; i < count; i++)
            {
                Source[i] = 71;
            }
            SharedValues = new NativeArraySharedValues<int>(Source, Allocator.TempJob);
            var sharedValuesJobHandle = SharedValues.Schedule(default(JobHandle));
            sharedValuesJobHandle.Complete();
        }
        

        [Test]
        public void NativeArraySharedValuesResultInOrderNoRemainder([Values(1, 3, 1204, 1024 + 1023)] int count)
        {
            PrepareReverseHalf(count);
            var sortedIndices = SharedValues.GetSortedIndices();

            var lastValue = Source[sortedIndices[0]];

            for (int i = 1; i < Source.Length; i++)
            {
                var index = sortedIndices[i];
                var value = Source[index];

                Assert.GreaterOrEqual(value,lastValue);

                lastValue = value;
            }
        }

        [Test]
        public void NativeArraySharedValuesFoundAllValues([Values(1, 3, 1024, 1024 + 1023)] int count)
        {
            PrepareReverseHalf(count);

            var sortedIndices = SharedValues.GetSortedIndices();
            for (int i = 0; i < Source.Length; i++)
            {
                var foundValue = false;
                for (int j = 0; j < sortedIndices.Length; j++)
                {
                    if (sortedIndices[j] == i)
                    {
                        foundValue = true;
                        break;
                    }
                }
                Assert.AreEqual(true, foundValue);
            }
        }

        [Test]
        public void NativeArraySharedValuesSameValues([Values(1, 3, 1024, 1024 + 1023)] int count)
        {
            PrepareReverseHalf(count);

            for (int i = 0; i < Source.Length; i++)
            {
                var sharedValueIndices = SharedValues.GetSharedValueIndicesBySourceIndex(i);
                var sourceValue = Source[i];
                Assert.GreaterOrEqual(sharedValueIndices.Length,1);
                for (int j = 0; j < sharedValueIndices.Length; j++)
                {
                    var otherIndex = sharedValueIndices[j];
                    var otherValue = Source[otherIndex];
                    Assert.AreEqual(sourceValue,otherValue);
                }
            }
        }
        
        [Test]
        public void NativeArraySharedValuesIndexCount([Values(1, 3, 1024, 1024 + 1023)] int count)
        {
            PrepareReverseHalf(count);

            //@TODO: @macton. It seems like this should be true? But maybe there is a reason why it shouldn't? 
            //Assert.AreEqual(SharedValues.SharedValueCount, sharedCounts.Length);
            
            var sharedCounts = SharedValues.GetSharedValueIndexCountArray();
            for (int i = 0; i < SharedValues.SharedValueCount; i++)
            {
                if (sharedCounts[i] != 1 && sharedCounts[i] != 2)
                    throw new AssertionException("Must be 1 or 2 but was: " + sharedCounts[i]);                
            }
        }
        
        [Test]
        public void NativeArraySharedValuesAllSameValues([Values(1, 3, 1024, 1024 + 1023)] int count)
        {
            PrepareAllSame(count);

            Assert.AreEqual(1, SharedValues.SharedValueCount);
            var indexCountArray = SharedValues.GetSharedValueIndexCountArray();
            Assert.AreEqual(1, indexCountArray.Length);
            Assert.AreEqual(count, indexCountArray[0]);
            
            var sharedValueIndices = SharedValues.GetSharedValueIndicesBySourceIndex(0);
            
            for (int i = 0; i < count; i++)
                Assert.AreEqual(i, sharedValueIndices[i]);
        }
        
        [Test]
        public void NativeArraySharedValuesAllEmptyArray()
        {
            PrepareAllSame(0);

            Assert.AreEqual(0, SharedValues.SharedValueCount);
            Assert.AreEqual(0, SharedValues.GetSortedIndices().Length);
        }
        
        [Test]
        public void NASV_FoundAllSharedValues()
        {
            int count = 1024 + 1023;
            var source = new NativeArray<int>(count, Allocator.TempJob);
            for (int i = 0; i < count; i++)
            {
                source[i] = i % 4;
            }
            var sharedValues = new NativeArraySharedValues<int>(source, Allocator.TempJob);
            var sharedValuesJobHandle = sharedValues.Schedule(default(JobHandle));
            sharedValuesJobHandle.Complete();

            var sharedValueCount = sharedValues.SharedValueCount;
            Assert.AreEqual(4,sharedValueCount);

            var sharedIndexArray = sharedValues.GetSharedIndexArray();

            Assert.AreEqual(0, source[sharedIndexArray[0]]);
            Assert.AreEqual(1, source[sharedIndexArray[1]]);
            Assert.AreEqual(2, source[sharedIndexArray[2]]);
            Assert.AreEqual(3, source[sharedIndexArray[3]]);
            
            sharedValues.Dispose();
            source.Dispose();
        }
    }
}
