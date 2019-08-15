using System;
using NUnit.Framework;
using Unity.Collections;

namespace Unity.Entities.Tests
{
    class ECBChainPriorityQueueTests
    {
        unsafe public void PQHeapSort(int[] unsorted, int[] sorted)
        {
            var chainStates = new NativeArray<ECBChainPlaybackState>(unsorted.Length, Allocator.Temp);
            for (int i = 0; i < unsorted.Length; ++i)
            {
                chainStates[i] = new ECBChainPlaybackState
                {
                    Chunk = null,
                    Offset = 0,
                    NextSortIndex = unsorted[i],
                };
            }
            ECBChainPriorityQueue pq = new ECBChainPriorityQueue(chainStates, Allocator.Temp);
            chainStates.Dispose();

            for(Int64 i=0; i<unsorted.Length; ++i)
            {
                Assert.False(pq.Empty, "queue shouldn't be empty with i=" + i);
                Int64 peeked = pq.Peek().SortIndex;
                Assert.AreEqual(peeked, sorted[i], "Peek() with i=" + i + " returned " + peeked);
                Int64 popped = pq.Pop().SortIndex;
                Assert.AreEqual(popped, sorted[i], "Pop() with i=" + i + " returned " + popped);
            }
            Assert.True(pq.Empty, "queue should be empty at end of loop");
            pq.Dispose();
        }

        [Test]
        unsafe public void PQHeapSortEvenCount()
        {
            int[] unsorted = new int[10] { 0,7,8,3,6,2,1,4,9,5 };
            int[] sorted   = new int[10] { 0,1,2,3,4,5,6,7,8,9 };
            PQHeapSort(unsorted, sorted);
        }

        [Test]
        unsafe public void PQHeapSortOddCount()
        {
            int[] unsorted = new int[9] { 0,7,8,3,6,2,1,4,5 };
            int[] sorted   = new int[9] { 0,1,2,3,4,5,6,7,8 };
            PQHeapSort(unsorted, sorted);
        }

        [Test]
        unsafe public void PQDuplicateKeys()
        {
            int[] unsorted = new int[5] { 3,1,3,2,3 };
            int[] sorted   = new int[5] { 1,2,3,3,3 };
            PQHeapSort(unsorted, sorted);
        }
    }
}
