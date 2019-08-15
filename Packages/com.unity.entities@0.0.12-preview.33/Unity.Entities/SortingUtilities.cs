using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;

namespace Unity.Entities
{
    internal struct SortingUtilities
    {
        public static unsafe void InsertSorted(int* data, int length, int newValue)
        {
            while (length > 0 && newValue < data[length - 1])
            {
                data[length] = data[length - 1];
                --length;
            }

            data[length] = newValue;
        }
        
        public static unsafe void InsertSorted(byte* data, int length, byte newValue)
        {
            while (length > 0 && newValue < data[length - 1])
            {
                data[length] = data[length - 1];
                --length;
            }

            data[length] = newValue;
        }
        
        public static unsafe void InsertSorted(ComponentType* data, int length, ComponentType newValue)
        {
            while (length > 0 && newValue < data[length - 1])
            {
                data[length] = data[length - 1];
                --length;
            }

            data[length] = newValue;
        }

        public static unsafe void InsertSorted(ComponentTypeInArchetype* data, int length, ComponentType newValue)
        {
            var newVal = new ComponentTypeInArchetype(newValue);
            while (length > 0 && newVal < data[length - 1])
            {
                data[length] = data[length - 1];
                --length;
            }

            data[length] = newVal;
        }
    }

    /// <summary>
    ///     Merge sort index list referencing NativeArray values.
    ///     Provide list of shared values, indices to shared values, and lists of source i
    ///     value indices with identical shared value.
    ///     As an example:
    ///     Given Source NativeArray: [A,A,A,B,B,C,C,A,B]
    ///     Provides:
    ///     Shared value indices: [0,0,0,1,1,2,2,0,1]
    ///     Shared value counts: [4,3,2] (number of occurrences of a shared value)
    ///     Shared values: [A,B,C] (not stored in this structure)
    ///     Sorted indices: [0,1,2,7,3,4,8,5,6] (using these indices to look up values in the source array would give you [A,A,A,A,B,B,B,C,C])
    ///     Shared value start offsets (into sorted indices): [0,4,7]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct NativeArraySharedValues<T> : IDisposable
        where T : struct, IComparable<T>
    {
        //m_WorkingBuffer contains 5 sections (in the following order):
        //2 buffers for a double-buffered sort:
        //  sortBuffer0
        //  sortBuffer1
        //1 buffer for SharedValueIndexCounts,
        //1 buffer for SharedValueStartIndices,
        //and an int: SharedValueCount
        private NativeArray<int> m_WorkingBuffer;
        [ReadOnly] private readonly NativeArray<T> m_SourceBuffer;
        public NativeArray<T> SourceBuffer => m_SourceBuffer;
        private int m_SortBufferIndex; //0 or 1 (i.e. sortBuffer0 or sortBuffer1)

        public NativeArraySharedValues(NativeArray<T> sourceBuffer, Allocator allocator)
        {
            m_WorkingBuffer = new NativeArray<int>(sourceBuffer.Length * 4 + 1, allocator);
            m_SourceBuffer = sourceBuffer;
            m_SortBufferIndex = 0;
        }

        [BurstCompile]
        private struct InitializeIndices : IJobParallelFor
        {
            public NativeArray<int> workingBuffer;

            public void Execute(int index)
            {
                workingBuffer[index] = index;
            }
        }

        [BurstCompile]
        private struct MergeSortedPairs : IJobParallelFor
        {
            [NativeDisableParallelForRestriction] public NativeArray<int> workingBuffer;
            [ReadOnly] public NativeArray<T> sourceBuffer;
            public int sortedCount;
            public int sortBufferIndex;

            public void Execute(int index)
            {
                var mergedCount = sortedCount * 2;
                var offset = index * mergedCount;
                var inputOffset = (sortBufferIndex ^ 1) * sourceBuffer.Length;
                var outputOffset = sortBufferIndex * sourceBuffer.Length;
                var leftCount = sortedCount;
                var rightCount = sortedCount;
                var leftNext = 0;
                var rightNext = 0;

                for (var i = 0; i < mergedCount; i++)
                    if (leftNext < leftCount && rightNext < rightCount)
                    {
                        var leftIndex = workingBuffer[inputOffset + offset + leftNext];
                        var rightIndex = workingBuffer[inputOffset + offset + leftCount + rightNext];
                        var leftValue = sourceBuffer[leftIndex];
                        var rightValue = sourceBuffer[rightIndex];

                        if (rightValue.CompareTo(leftValue) < 0)
                        {
                            workingBuffer[outputOffset + offset + i] = rightIndex;
                            rightNext++;
                        }
                        else
                        {
                            workingBuffer[outputOffset + offset + i] = leftIndex;
                            leftNext++;
                        }
                    }
                    else if (leftNext < leftCount)
                    {
                        var leftIndex = workingBuffer[inputOffset + offset + leftNext];
                        workingBuffer[outputOffset + offset + i] = leftIndex;
                        leftNext++;
                    }
                    else
                    {
                        var rightIndex = workingBuffer[inputOffset + offset + leftCount + rightNext];
                        workingBuffer[outputOffset + offset + i] = rightIndex;
                        rightNext++;
                    }
            }
        }

        [BurstCompile]
        private struct MergeLeft : IJobParallelFor
        {
            [NativeDisableParallelForRestriction] public NativeArray<int> workingBuffer;
            [ReadOnly] public NativeArray<T> sourceBuffer;
            public int leftCount;
            public int rightCount;
            public int startIndex;
            public int sortBufferIndex;

            // On left, equal is equivalent to less-than
            private int FindInsertNext(int startOffset, int minNext, int maxNext, T testValue)
            {
                if (minNext == maxNext)
                {
                    var index = workingBuffer[startOffset + minNext];
                    var value = sourceBuffer[index];
                    var compare = testValue.CompareTo(value);
                    if (compare <= 0) return minNext;
                    return minNext + 1;
                }

                var midNext = minNext + (maxNext - minNext) / 2;
                {
                    var index = workingBuffer[startOffset + midNext];
                    var value = sourceBuffer[index];
                    var compare = testValue.CompareTo(value);
                    if (compare <= 0)
                        return FindInsertNext(startOffset, minNext, math.max(midNext - 1, minNext), testValue);
                }
                return FindInsertNext(startOffset, math.min(midNext + 1, maxNext), maxNext, testValue);
            }

            public void Execute(int leftNext)
            {
                var inputOffset = (sortBufferIndex ^ 1) * sourceBuffer.Length;
                var outputOffset = sortBufferIndex * sourceBuffer.Length;
                var leftIndex = workingBuffer[inputOffset + startIndex + leftNext];
                var leftValue = sourceBuffer[leftIndex];
                var rightNext = FindInsertNext(inputOffset + startIndex + leftCount, 0, rightCount - 1, leftValue);
                var mergeNext = leftNext + rightNext;

                workingBuffer[outputOffset + startIndex + mergeNext] = leftIndex;
            }
        }

        [BurstCompile]
        private struct MergeRight : IJobParallelFor
        {
            [NativeDisableParallelForRestriction] public NativeArray<int> workingBuffer;
            [ReadOnly] public NativeArray<T> sourceBuffer;
            public int leftCount;
            public int rightCount;
            public int startIndex;
            public int sortBufferIndex;

            // On right, equal is equivalent to greater-than
            private int FindInsertNext(int startOffset, int minNext, int maxNext, T testValue)
            {
                if (minNext == maxNext)
                {
                    var index = workingBuffer[startOffset + minNext];
                    var value = sourceBuffer[index];
                    var compare = testValue.CompareTo(value);
                    if (compare < 0) return minNext;
                    return minNext + 1;
                }

                var midNext = minNext + (maxNext - minNext) / 2;
                {
                    var index = workingBuffer[startOffset + midNext];
                    var value = sourceBuffer[index];
                    var compare = testValue.CompareTo(value);
                    if (compare < 0)
                        return FindInsertNext(startOffset, minNext, math.max(midNext - 1, minNext), testValue);
                }
                return FindInsertNext(startOffset, math.min(midNext + 1, maxNext), maxNext, testValue);
            }

            public void Execute(int rightNext)
            {
                var inputOffset = (sortBufferIndex ^ 1) * sourceBuffer.Length;
                var outputOffset = sortBufferIndex * sourceBuffer.Length;
                var rightIndex = workingBuffer[inputOffset + startIndex + leftCount + rightNext];
                var rightValue = sourceBuffer[rightIndex];
                var leftNext = FindInsertNext(inputOffset + startIndex, 0, leftCount - 1, rightValue);
                var mergeNext = rightNext + leftNext;

                workingBuffer[outputOffset + startIndex + mergeNext] = rightIndex;
            }
        }

        [BurstCompile]
        private struct CopyRemainder : IJobParallelFor
        {
            [NativeDisableParallelForRestriction] public NativeArray<int> workingBuffer;
            [ReadOnly] public NativeArray<T> sourceBuffer;
            public int startIndex;
            public int sortBufferIndex;

            public void Execute(int index)
            {
                var inputOffset = (sortBufferIndex ^ 1) * sourceBuffer.Length;
                var outputOffset = sortBufferIndex * sourceBuffer.Length;
                var outputIndex = outputOffset + startIndex + index;
                var inputIndex = inputOffset + startIndex + index;
                var valueIndex = workingBuffer[inputIndex];
                workingBuffer[outputIndex] = valueIndex;
            }
        }

        private JobHandle MergeSortedLists(JobHandle inputDeps, int sortedCount, int sortBufferIndex)
        {
            var pairCount = m_SourceBuffer.Length / (sortedCount * 2);

            var mergeSortedPairsJobHandle = inputDeps;

            if (pairCount <= 4)
            {
                for (var i = 0; i < pairCount; i++)
                {
                    var mergeRemainderLeftJob = new MergeLeft
                    {
                        startIndex = i * sortedCount * 2,
                        workingBuffer = m_WorkingBuffer,
                        sourceBuffer = m_SourceBuffer,
                        leftCount = sortedCount,
                        rightCount = sortedCount,
                        sortBufferIndex = sortBufferIndex
                    };
                    // There's no overlap, but write to the same array, so extra dependency:
                    mergeSortedPairsJobHandle =
                        mergeRemainderLeftJob.Schedule(sortedCount, 64, mergeSortedPairsJobHandle);

                    var mergeRemainderRightJob = new MergeRight
                    {
                        startIndex = i * sortedCount * 2,
                        workingBuffer = m_WorkingBuffer,
                        sourceBuffer = m_SourceBuffer,
                        leftCount = sortedCount,
                        rightCount = sortedCount,
                        sortBufferIndex = sortBufferIndex
                    };
                    // There's no overlap, but write to the same array, so extra dependency:
                    mergeSortedPairsJobHandle =
                        mergeRemainderRightJob.Schedule(sortedCount, 64, mergeSortedPairsJobHandle);
                }
            }
            else
            {
                var mergeSortedPairsJob = new MergeSortedPairs
                {
                    workingBuffer = m_WorkingBuffer,
                    sourceBuffer = m_SourceBuffer,
                    sortedCount = sortedCount,
                    sortBufferIndex = sortBufferIndex
                };
                mergeSortedPairsJobHandle = mergeSortedPairsJob.Schedule(pairCount, (pairCount + 1) / 8, inputDeps);
            }

            var remainder = m_SourceBuffer.Length - pairCount * sortedCount * 2;
            if (remainder > sortedCount)
            {
                var mergeRemainderLeftJob = new MergeLeft
                {
                    startIndex = pairCount * sortedCount * 2,
                    workingBuffer = m_WorkingBuffer,
                    sourceBuffer = m_SourceBuffer,
                    leftCount = sortedCount,
                    rightCount = remainder - sortedCount,
                    sortBufferIndex = sortBufferIndex
                };
                // There's no overlap, but write to the same array, so extra dependency:
                var mergeLeftJobHandle = mergeRemainderLeftJob.Schedule(sortedCount, 64, mergeSortedPairsJobHandle);

                var mergeRemainderRightJob = new MergeRight
                {
                    startIndex = pairCount * sortedCount * 2,
                    workingBuffer = m_WorkingBuffer,
                    sourceBuffer = m_SourceBuffer,
                    leftCount = sortedCount,
                    rightCount = remainder - sortedCount,
                    sortBufferIndex = sortBufferIndex
                };
                // There's no overlap, but write to the same array, so extra dependency:
                var mergeRightJobHandle =
                    mergeRemainderRightJob.Schedule(remainder - sortedCount, 64, mergeLeftJobHandle);
                return mergeRightJobHandle;
            }

            if (remainder > 0)
            {
                var copyRemainderPairJob = new CopyRemainder
                {
                    startIndex = pairCount * sortedCount * 2,
                    workingBuffer = m_WorkingBuffer,
                    sourceBuffer = m_SourceBuffer,
                    sortBufferIndex = sortBufferIndex
                };

                // There's no overlap, but write to the same array, so extra dependency:
                var copyRemainderPairJobHandle =
                    copyRemainderPairJob.Schedule(remainder, (pairCount + 1) / 8, mergeSortedPairsJobHandle);
                return copyRemainderPairJobHandle;
            }

            return mergeSortedPairsJobHandle;
        }

        [BurstCompile]
        private struct AssignSharedValues : IJob
        {
            public NativeArray<int> workingBuffer;
            [ReadOnly] public NativeArray<T> sourceBuffer;
            public int sortBufferIndex;

            public void Execute()
            {
                var sortedIndicesOffset = sortBufferIndex * sourceBuffer.Length;
                var sharedValueIndicesOffset = (sortBufferIndex ^ 1) * sourceBuffer.Length;//beginning of "off" sortBuffer (e.g. if the current sortBufferIndex is 1, use sortBuffer0)
                var sharedValueIndexCountsOffset = 2 * sourceBuffer.Length; //beginning of SharedValueIndexCounts region of m_WorkingBuffer
                var sharedValueStartIndicesOffset = 3 * sourceBuffer.Length;//beginning of SharedValueStartIndices region of m_WorkingBuffer
                var sharedValueCountOffset = 4 * sourceBuffer.Length;

                var index = 0;
                var valueIndex = workingBuffer[sortedIndicesOffset + index];
                var sharedValue = sourceBuffer[valueIndex];
                var sharedValueCount = 1;
                workingBuffer[sharedValueIndicesOffset + valueIndex] = 0;
                workingBuffer[sharedValueStartIndicesOffset + (sharedValueCount - 1)] = index;
                workingBuffer[sharedValueIndexCountsOffset + (sharedValueCount - 1)] = 1;
                index++;

                while (index < sourceBuffer.Length)
                {
                    valueIndex = workingBuffer[sortedIndicesOffset + index];
                    var value = sourceBuffer[valueIndex];
                    if (value.CompareTo(sharedValue) != 0)
                    {
                        sharedValueCount++;
                        sharedValue = value;
                        workingBuffer[sharedValueStartIndicesOffset + (sharedValueCount - 1)] = index;
                        workingBuffer[sharedValueIndexCountsOffset + (sharedValueCount - 1)] = 1;
                        workingBuffer[sharedValueIndicesOffset + valueIndex] = sharedValueCount - 1;
                    }
                    else
                    {
                        workingBuffer[sharedValueIndexCountsOffset + (sharedValueCount - 1)]++;
                        workingBuffer[sharedValueIndicesOffset + valueIndex] = sharedValueCount - 1;
                    }

                    index++;
                }

                workingBuffer[sharedValueCountOffset] = sharedValueCount;
            }
        }

        /// <summary>
        ///     Double-buffered merge sort within the front half of m_WorkingBuffer.
        /// </summary>
        /// <param name="inputDeps">Dependent JobHandle</param>
        /// <returns>JobHandle</returns>
        private JobHandle Sort(JobHandle inputDeps)
        {
            var sortedCount = 1;
            var sortBufferIndex = 1;
            do
            {
                inputDeps = MergeSortedLists(inputDeps, sortedCount, sortBufferIndex);
                sortedCount *= 2;
                sortBufferIndex ^= 1;
            } while (sortedCount < m_SourceBuffer.Length);

            m_SortBufferIndex = sortBufferIndex ^ 1;

            return inputDeps;
        }

        private JobHandle ResolveSharedGroups(JobHandle inputDeps)
        {
            var assignSharedValuesJob = new AssignSharedValues
            {
                workingBuffer = m_WorkingBuffer,
                sourceBuffer = m_SourceBuffer,
                sortBufferIndex = m_SortBufferIndex
            };
            var assignSharedValuesJobHandle = assignSharedValuesJob.Schedule(inputDeps);
            return assignSharedValuesJobHandle;
        }

        /// <summary>
        ///     Schedule jobs to collect and sort shared values.
        /// </summary>
        /// <param name="inputDeps">Dependent JobHandle</param>
        /// <returns>JobHandle</returns>
        public JobHandle Schedule(JobHandle inputDeps)
        {
            if (m_SourceBuffer.Length == 0)
            {
                m_WorkingBuffer[0] = 0;
                return inputDeps;
            }
            
            var initializeIndicesJob = new InitializeIndices
            {
                workingBuffer = m_WorkingBuffer
            };
            var initializeIndicesJobHandle =
                initializeIndicesJob.Schedule(m_SourceBuffer.Length, (m_SourceBuffer.Length + 1) / 8, inputDeps);
            var sortJobHandle = Sort(initializeIndicesJobHandle);
            var resolveSharedGroupsJobHandle = ResolveSharedGroups(sortJobHandle);
            return resolveSharedGroupsJobHandle;
        }

        /// <summary>
        ///     Indices into source NativeArray sorted by value
        /// </summary>
        /// <returns>Index NativeArray where each element refers to an element in the source NativeArray</returns>
        public unsafe NativeArray<int> GetSortedIndices()
        {
            var rawIndices = (int*) m_WorkingBuffer.GetUnsafeReadOnlyPtr() + m_SortBufferIndex * m_SourceBuffer.Length;
            var arr = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(rawIndices, m_SourceBuffer.Length,
                Allocator.Invalid);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            SortedIndicesSetSafetyHandle(ref arr);
#endif
            return arr;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        // Uncomment when NativeArrayUnsafeUtility includes these conditional checks
        // [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void SortedIndicesSetSafetyHandle(ref NativeArray<int> arr)
        {
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref arr,
                NativeArrayUnsafeUtility.GetAtomicSafetyHandle(m_WorkingBuffer));
        }
#endif

        /// <summary>
        ///     Number of shared (unique) values in source NativeArray
        /// </summary>
        public int SharedValueCount => m_WorkingBuffer[m_SourceBuffer.Length * 4];

        /// <summary>
        ///     Index of shared value associated with an element in the source buffer.
        ///     For example, given source array: [A,A,A,B,B,C,C,A,B]
        ///     shared values are: [A,B,C]
        ///     Given the index 2 into the source array (A), the return value would be 0 (A in shared values).
        /// </summary>
        /// <param name="indexIntoSourceBuffer">Index of source value</param>
        /// <returns>Index into the list of shared values</returns>
        public int GetSharedIndexBySourceIndex(int indexIntoSourceBuffer)
        {
            var sharedValueIndicesOffset = (m_SortBufferIndex ^ 1) * m_SourceBuffer.Length; //beginning of "off" sortBuffer (e.g. if the current sortBufferIndex is 1, use sortBuffer0)
            var sharedValueIndex = m_WorkingBuffer[sharedValueIndicesOffset + indexIntoSourceBuffer];
            return sharedValueIndex;
        }

        /// <summary>
        ///     Indices into shared values.
        ///     For example, given source array: [A,A,A,B,B,C,C,A,B]
        ///     shared values are: [A,B,C]
        ///     shared index array would contain: [0,0,0,1,1,2,2,0,1]
        /// </summary>
        /// <returns>Index NativeArray where each element refers to the index of a shared value in a list of shared (unique) values.</returns>
        public unsafe NativeArray<int> GetSharedIndexArray()
        {
            // Capacity cannot be changed, so offset is valid.
            var rawIndices = (int*) NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(m_WorkingBuffer) +
                             (m_SortBufferIndex ^ 1) * m_SourceBuffer.Length;
            // Get array that maps to the currently unused sort buffer (e.g. if the current sortBufferIndex is 1, return sortBuffer0)
            var arr = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(rawIndices, m_SourceBuffer.Length,
                Allocator.Invalid);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            SharedIndexArraySetSafetyHandle(ref arr);
#endif
            return arr;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        // Uncomment when NativeArrayUnsafeUtility includes these conditional checks
        // [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void SharedIndexArraySetSafetyHandle(ref NativeArray<int> arr)
        {
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref arr,
                NativeArrayUnsafeUtility.GetAtomicSafetyHandle(m_WorkingBuffer));
        }
#endif

        /// <summary>
        ///     Array of indices into shared value indices NativeArray which share the same source value
        ///     For example, given Source NativeArray: [A,A,A,B,B,C,C,A,B]
        ///     shared values are: [A,B,C]
        ///     Shared value indices: [0,0,0,1,1,2,2,0,1]
        ///     Given the index 2 into the source array (A),
        ///     the returned array would contain: [0,1,2,7] (indices in SharedValueIndices that have a value of 0, i.e. where A is in the shared values)
        /// </summary>
        /// <param name="indexIntoSourceBuffer">Index of source value</param>
        /// <returns>Index NativeArray where each element refers to an index into the shared value indices array.</returns>
        public NativeArray<int> GetSharedValueIndicesBySourceIndex(int indexIntoSourceBuffer)
        {
            var sharedValueIndicesOffset = (m_SortBufferIndex ^ 1) * m_SourceBuffer.Length;//beginning of "off" sortBuffer (e.g. if the current sortBufferIndex is 1, return sortBuffer0)
            var sharedValueIndex = m_WorkingBuffer[sharedValueIndicesOffset + indexIntoSourceBuffer];
            return GetSharedValueIndicesBySharedIndex(sharedValueIndex);
        }

        /// <summary>
        ///     Number of occurrences of a shared (unique) value shared by a given a source index.
        ///     For example, given source array: [A,A,A,B,B,C,C,A,B]
        ///     shared values are: [A,B,C]
        ///     Shared value counts: [4,3,2] (number of occurrences of a shared value)
        ///     Given the index 2 into the source array (A), the return value would be 4 (for 4 occurrences of A in the source buffer).
        /// </summary>
        /// <param name="indexIntoSourceBuffer">Index of source value.</param>
        /// <returns>Count of total occurrences of the shared value at a source buffer index in the source buffer.</returns>
        public int GetSharedValueIndexCountBySourceIndex(int indexIntoSourceBuffer)
        {
            var sharedValueIndex = GetSharedIndexBySourceIndex(indexIntoSourceBuffer);
            var sharedValueIndexCountsOffset = 2 * m_SourceBuffer.Length; //beginning of SharedValueIndexCounts region of m_WorkingBuffer
            var sharedValueIndexCount = m_WorkingBuffer[sharedValueIndexCountsOffset + sharedValueIndex];
            return sharedValueIndexCount;
        }

        /// <summary>
        ///     Array of number of occurrences of all shared values.
        ///     For example, given source array: [A,A,A,B,B,C,C,A,B]
        ///     shared values are: [A,B,C]
        ///     Shared value counts: [4,3,2] (number of occurrences of a shared value)
        /// </summary>
        /// <returns>Count NativeArray where each element refers to the number of occurrences of each shared value.</returns>
        public unsafe NativeArray<int> GetSharedValueIndexCountArray()
        {
            // Capacity cannot be changed, so offset is valid.
            var rawIndices = (int*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(m_WorkingBuffer) + 2 * m_SourceBuffer.Length;
            var arr = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(rawIndices, SharedValueCount, Allocator.Invalid);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            SharedValueIndexCountArraySetSafetyHandle(ref arr);
#endif
            return arr;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        // Uncomment when NativeArrayUnsafeUtility includes these conditional checks
        // [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void SharedValueIndexCountArraySetSafetyHandle(ref NativeArray<int> arr)
        {
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref arr,
                NativeArrayUnsafeUtility.GetAtomicSafetyHandle(m_WorkingBuffer));
        }
#endif

        /// <summary>
        ///     Array of indices into source NativeArray which share the same shared value
        ///     For example, given source array: [A,A,A,B,B,C,C,A,B]
        ///     shared values are: [A,B,C]
        ///     Shared value counts: [4,3,2] (number of occurrences of a shared value)
        ///     Shared value start offsets (into sorted indices): [0,4,7]
        ///     Given the index 0 into the shared value array (A), the returned array would contain [0,1,2,7] (indices into the source array which point to the shared value A).
        /// </summary>
        /// <param name="sharedValueIndex">Index of shared value</param>
        /// <returns>Index NativeArray where each element refers to an index into the source array.</returns>
        public unsafe NativeArray<int> GetSharedValueIndicesBySharedIndex(int sharedValueIndex)
        {
            var sharedValueIndexCountsOffset = 2 * m_SourceBuffer.Length;  //beginning of SharedValueIndexCounts region of m_WorkingBuffer
            var sharedValueIndexCount = m_WorkingBuffer[sharedValueIndexCountsOffset + sharedValueIndex];
            var sharedValueStartIndicesOffset = 3 * m_SourceBuffer.Length; //beginning of SharedValueStartIndices region of m_WorkingBuffer
            var sharedValueStartIndex = m_WorkingBuffer[sharedValueStartIndicesOffset + sharedValueIndex];
            var sortedValueOffset = m_SortBufferIndex * m_SourceBuffer.Length; //get current sortBuffer

            // Capacity cannot be changed, so offset is valid.
            var rawIndices = (int*) NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(m_WorkingBuffer) +
                             (sortedValueOffset + sharedValueStartIndex);
            var arr = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(rawIndices, sharedValueIndexCount,
                Allocator.Invalid);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            SharedValueIndicesSetSafetyHandle(ref arr);
#endif
            return arr;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        // Uncomment when NativeArrayUnsafeUtility includes these conditional checks
        // [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private void SharedValueIndicesSetSafetyHandle(ref NativeArray<int> arr)
        {
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref arr,
                NativeArrayUnsafeUtility.GetAtomicSafetyHandle(m_WorkingBuffer));
        }
#endif

        /// <summary>
        ///     Get internal buffer for disposal by a job marked with [DeallocateOnJobCompletion] (as opposed to forcing a job to finish so you can use Dispose()).
        /// </summary>
        /// <returns></returns>
        public NativeArray<int> GetBuffer()
        {
            return m_WorkingBuffer;
        }

        /// <summary>
        ///     Dispose internal buffer
        /// </summary>
        public void Dispose()
        {
            m_WorkingBuffer.Dispose();
        }
    }
}
