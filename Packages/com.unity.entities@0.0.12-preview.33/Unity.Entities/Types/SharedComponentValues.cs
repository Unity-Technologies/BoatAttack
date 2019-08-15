namespace Unity.Entities
{
    internal unsafe struct SharedComponentValues
    {
        public int* firstIndex;
        public int stride;
        public ref int this[int i] => ref *(int*)(((byte*)firstIndex) + i*stride);

        public static implicit operator SharedComponentValues(int* p)
        {
            return new SharedComponentValues {firstIndex = p, stride=sizeof(int)};
        }

        public bool EqualTo(SharedComponentValues otherValues, int sharedComponentCount)
        {
            for(int i=0; i<sharedComponentCount; ++i)
                if (otherValues[i] != this[i])
                    return false;
            return true;
        }

        public void CopyTo(int* dest, int startIndex, int count)
        {
            for (int i = 0; i < count; ++i)
                dest[i] = this[startIndex + i];
        }
    }
}
