using System;
using Unity.Mathematics;

namespace Unity.Entities
{
    [Serializable]
    public struct Hash128 : IEquatable<Hash128>
    {
        public uint4 Value;

        static readonly char[] HexToLiteral = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};

        public unsafe override string ToString()
        {
#if !NET_DOTS
            var str = new string('0', 32);
            fixed (char* buf = str)
            {
                HashToString(Value, buf);
            }
            
            return str;            
#else
            throw new System.NotImplementedException();
#endif
        }
        
        unsafe static void HashToString(uint4 data, char* name)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 7; j >= 0;j--)
                {
                    uint cur = data[i];
                    cur >>= (j* 4);
                    cur &= 0xF;
                    name[ i * 8 + j] = HexToLiteral[ cur];
                }
            }
        }
        
        public static bool operator== (Hash128 obj1, Hash128 obj2)
        {
            return obj1.Value.Equals(obj2.Value);
        }

        public static bool operator!= (Hash128 obj1, Hash128 obj2)
        {
            return !obj1.Value.Equals(obj2.Value);
        }

        public bool Equals(Hash128 obj)
        {
            return Value.Equals(obj.Value);

        }
        override public bool Equals(object obj)
        {
            throw new NotImplementedException();
            
        }

        public override int GetHashCode()
        {
            uint4 primes = new uint4(863, 5471887, 13143149, 15485291);
            return (int)math.csum(Value * primes);
        }
        
        #if UNITY_EDITOR
        unsafe public static implicit operator Hash128(UnityEditor.GUID guid)
        {
            var hash = new Hash128();
            hash = *(Hash128*) &guid;
            return hash;
        }
        #endif
    }
}
