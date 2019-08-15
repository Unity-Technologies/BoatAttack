using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Entities
{
    // We have defined three fixed-size NativeStrings, all of which are value types with zero allocation.
    // You can copy them freely without ever generating garbage or needing to Dispose, but they are limited in size.
    //
    // NativeString64 - consumes 64 bytes (one line) of memory. suitable for short names and descriptions.
    // NativeString512 - consumes 512 bytes (eight lines) of memory. can hold a few lines of text, a filename, a URL.
    // NativeString4096 - consumes 4096 bytes (one page) of memory. can hold a printed page of text.
    // 
    // These names are not very friendly, we might want to change them to, for example:
    //
    // NativeStringName
    // NativeStringLine
    // NativeStringPage
    //
    // There is also maybe a need for NativeString? which has a thread safety handle and calls malloc and requires
    // Dispose()? But, you have to wonder for what purpose. Text larger than 4096 bytes is probably a JSON file or
    // something like that - something you process offline or outside of gameplay. C# String and managed code might
    // be OK for that. Or, you could just use a NativeArray<char> for the file, and NativeString512 for the little
    // parseable pieces inside the file, since you wouldn't expect any of them to exceed 512 bytes. It seems fair
    // to limit token sizes to 512 bytes, no reasonable person would need tokens longer than that.
    //
    // The horrible waste of NativeString512 isn't so bad, if you consider:
    //
    // 1. These are almost certainly going to be on the stack most of the time
    // 2. The stack is hot in the page cache
    // 3. Since memory access is by 64 byte cache line, short strings only access first 64 byte cache line of 512

    public enum FormatError 
    {
        None,
        Overflow,
    }

    public enum ParseError 
    {
        None,
        Syntax,
        Overflow,
        Underflow,
    }

    public enum CopyError
    {
        None,
        Truncation
    }

    public enum ConversionError
    {
        None,
        Overflow,
        Encoding,
        CodePoint,
    }
    
    internal unsafe struct NativeString
    {
        public static bool IsValidCodePoint(int ucs)
        {
            if (ucs > 0x10FFFF) // maximum valid code point
                return false;
            if (ucs >= 0xD800 && ucs <= 0xDFFF) // surrogate pair
                return false;
            if (ucs < 0) // negative?
                return false;
            return true;
        }

        public static bool NotTrailer(byte b)
        {
            return (b & 0xC0) != 0x80;
        }

        private const int ReplacementCharacter = 0xFFFD;
        public static ConversionError Utf8ToUcs(out int ucs, byte* buffer, ref int offset, int capacity)
        {
            int code = 0;
            ucs = ReplacementCharacter;
            if (offset + 1 > capacity)
                return ConversionError.Overflow;
            if ((buffer[offset] & 0b10000000) == 0b00000000) // if high bit is 0, 1 byte
            {
                ucs = buffer[offset+0];
                offset += 1;
                return ConversionError.None;
            }
            if ((buffer[offset] & 0b11100000) == 0b11000000) // if high 3 bits are 110, 2 bytes
            {
                if (offset + 2 > capacity)
                {
                    offset += 1;
                    return ConversionError.Overflow;
                }
                code =              (buffer[offset+0] & 0b00011111);
                code = (code<<6) |  (buffer[offset+1] & 0b00111111);
                if (code < (1<<7) || NotTrailer(buffer[offset+1]))
                {
                    offset += 1;
                    return ConversionError.Encoding;
                }
                ucs = code;
                offset += 2;
                return ConversionError.None;
            }
            if ((buffer[offset] & 0b11110000) == 0b11100000) // if high 4 bits are 1110, 3 bytes
            {
                if (offset + 3 > capacity)
                {
                    offset += 1;
                    return ConversionError.Overflow;
                }
                code =              (buffer[offset+0] & 0b00001111);
                code = (code<<6) |  (buffer[offset+1] & 0b00111111); 
                code = (code<<6) |  (buffer[offset+2] & 0b00111111);
                if (code < (1<<11) || !IsValidCodePoint(code) || NotTrailer(buffer[offset+1]) || NotTrailer(buffer[offset+2]))
                {
                    offset += 1;
                    return ConversionError.Encoding;
                }
                ucs = code;
                offset += 3;
                return ConversionError.None;
            }
            if ((buffer[offset] & 0b11111000) == 0b11110000) // if high 5 bits are 11110, 4 bytes
            {
                if (offset + 4 > capacity)
                {
                    offset += 1;
                    return ConversionError.Overflow;
                }
                code =              (buffer[offset+0] & 0b00000111);
                code = (code<<6) |  (buffer[offset+1] & 0b00111111); 
                code = (code<<6) |  (buffer[offset+2] & 0b00111111); 
                code = (code<<6) |  (buffer[offset+3] & 0b00111111);
                if (code < (1 << 16) || !IsValidCodePoint(code) || NotTrailer(buffer[offset+1]) || NotTrailer(buffer[offset+2]) || NotTrailer(buffer[offset+3]))
                {
                    offset += 1;
                    return ConversionError.Encoding;
                }
                ucs = code;
                offset += 4;
                return ConversionError.None;
            }
            offset += 1;
            return ConversionError.Encoding;
        }
        public static ConversionError Utf16ToUcs(out int ucs, char* buffer, ref int offset, int capacity)
        {
            int code = 0;
            ucs = ReplacementCharacter;
            if (offset + 1 > capacity)
                return ConversionError.Overflow;
            if (buffer[offset] >= 0xD800 && buffer[offset] <= 0xDBFF)
            {
                if (offset + 2 > capacity)
                {
                    offset += 1;
                    return ConversionError.Overflow;
                }
                code =               (buffer[offset+0] & 0x03FF);
                char next = buffer[offset + 1];
                if (next < 0xDC00 || next > 0xDFFF)
                {
                    offset += 1;
                    return ConversionError.Encoding;
                }
                code = (code << 10) | (buffer[offset+1] & 0x03FF);
                code += 0x10000;
                ucs = code;
                offset += 2;
                return ConversionError.None;
            }
            ucs = buffer[offset+0];
            offset += 1;
            return ConversionError.None;
        }
        public static ConversionError UcsToUtf8(byte* buffer, ref int offset, int capacity, int ucs)
        {
            if(!IsValidCodePoint(ucs))
                return ConversionError.CodePoint;
            if (offset + 1 > capacity)
                return ConversionError.Overflow;
            if (ucs <= 0x7F)
            {
                buffer[offset++] = (byte) ucs;
                return ConversionError.None;
            }
            if (ucs <= 0x7FF)
            {
                if (offset + 2 > capacity)
                    return ConversionError.Overflow;
                buffer[offset++] = (byte)(0xC0 | (ucs >> 6));
                buffer[offset++] = (byte)(0x80 | ((ucs >> 0) & 0x3F));
                return ConversionError.None;
            }
            if (ucs <= 0xFFFF)
            {
                if (offset + 3 > capacity)
                    return ConversionError.Overflow;
                buffer[offset++] = (byte)(0xE0 | (ucs >> 12));
                buffer[offset++] = (byte)(0x80 | ((ucs >> 6) & 0x3F));
                buffer[offset++] = (byte)(0x80 | ((ucs >> 0) & 0x3F));
                return ConversionError.None;
            }
            if (ucs <= 0x1FFFFF)
            {
                if (offset + 4 > capacity)
                    return ConversionError.Overflow;
                buffer[offset++] = (byte)(0xF0 | (ucs >> 18));
                buffer[offset++] = (byte)(0x80 | ((ucs >> 12) & 0x3F));
                buffer[offset++] = (byte)(0x80 | ((ucs >> 6) & 0x3F));
                buffer[offset++] = (byte)(0x80 | ((ucs >> 0) & 0x3F));
                return ConversionError.None;
            }
            return ConversionError.Encoding;
        }
        public static ConversionError UcsToUtf16(char* buffer, ref int offset, int capacity, int ucs)
        {
            if(!IsValidCodePoint(ucs))
                return ConversionError.CodePoint;
            if (offset + 1 > capacity)
                return ConversionError.Overflow;
            if (ucs >= 0x10000)
            {
                if (offset + 2 > capacity)
                    return ConversionError.Overflow;
                int code = ucs - 0x10000;
                if (code >= (1 << 20))
                    return ConversionError.Encoding;
                buffer[offset++] = (char)(0xD800 | (code >> 10));
                buffer[offset++] = (char)(0xDC00 | (code & 0x3FF));
                return ConversionError.None;
            }
            buffer[offset++] = (char)ucs;
            return ConversionError.None;
        }
        public static ConversionError Utf16ToUtf8(char* utf16_buffer, int utf16_length, byte* utf8_buffer, out int utf8_length, int utf8_capacity)
        {
            utf8_length = 0;
            for(var utf16_offset = 0; utf16_offset < utf16_length;)
            {
                Utf16ToUcs(out var ucs, utf16_buffer, ref utf16_offset, utf16_length);
                if (UcsToUtf8(utf8_buffer, ref utf8_length, utf8_capacity, ucs) == ConversionError.Overflow)
                    return ConversionError.Overflow;
            }
            return ConversionError.None;            
        }

        public static ConversionError Utf8ToUtf16(byte* utf8_buffer, int utf8_length, char* utf16_buffer, out int utf16_length, int utf16_capacity)
        {
            utf16_length = 0;
            for(var utf8_offset = 0; utf8_offset < utf8_length;)
            {
                Utf8ToUcs(out var ucs, utf8_buffer, ref utf8_offset, utf8_length);
                if (UcsToUtf16(utf16_buffer, ref utf16_length, utf16_capacity, ucs) == ConversionError.Overflow)
                    return ConversionError.Overflow;
            }
            return ConversionError.None;
        }
        
        public static unsafe int CompareTo(char *a, int aa, char* b, int bb)
        {
            int chars = aa < bb ? aa : bb;
            for (var i = 0; i < chars; ++i)
            {
                if (a[i] < b[i])
                    return -1;
                if (a[i] > b[i])
                    return 1;
            }
            if (aa < bb)
                return -1;
            if (aa > bb)
                return 1;
            return 0;            
        }        
        public static unsafe bool Equals(char *a, int aa, char* b, int bb)
        {
            if (aa != bb)
                return false;
            return UnsafeUtility.MemCmp(a, b, aa * sizeof(char)) == 0;
        }

        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        public int Length;
        public int Capacity;
        public char* buffer;
        
        public ParseError Parse(ref int offset, ref int output)
        {
            long value = 0;
            int sign = 1;
            int digits = 0;
            if (offset < Length)
            {
                if (buffer[offset] == '+')
                    ++offset;
                else if (buffer[offset] == '-')
                {
                    sign = -1;
                    ++offset;
                }
            }
            while (offset < Length && IsDigit(buffer[offset]))
            {
                value *= 10;
                value += buffer[offset] - '0';
                if(value >> 32 != 0)
                    return ParseError.Overflow;
                ++offset;
                ++digits;
            }
            if (digits == 0)
                return ParseError.Syntax;
            value = sign * value;
            if(value > Int32.MaxValue)
                return ParseError.Overflow;
            if (value < Int32.MinValue)
                return ParseError.Overflow;            
            output = (int)value;
            return ParseError.None;
        }
        
        [StructLayout(LayoutKind.Explicit)]
        internal struct UintFloatUnion
        {
            [FieldOffset(0)]
            public uint uintValue;
            [FieldOffset(0)]
            public float floatValue;
        }
        
        static ParseError Base10ToBase2(ref float output, ulong mantissa10, int exponent10)
        {
            if (mantissa10 == 0)
            {
                output = 0.0f;
                return ParseError.None;
            }
            if (exponent10 == 0)
            {
                output = mantissa10;
                return ParseError.None;
            }
            var exponent2 = exponent10;
            var mantissa2 = mantissa10;
            while (exponent10 > 0)
            {
                while ((mantissa2 & 0xe000000000000000U) != 0)
                {
                    mantissa2 >>= 1;
                    ++exponent2;
                }
                mantissa2 *= 5;
                --exponent10;
            }
            while(exponent10 < 0)
            {
                while ((mantissa2 & 0x8000000000000000U) == 0) 
                {
                    mantissa2 <<= 1;
                    --exponent2;
                }
                mantissa2 /= 5;
                ++exponent10;
            }
            // TODO: implement math.ldexpf (which presumably handles denormals (i don't))
            UintFloatUnion ufu = new UintFloatUnion();
            ufu.floatValue = mantissa2;
            var e = (int)((ufu.uintValue >> 23) & 0xFFU) - 127;
            e += exponent2;
            if (e > 128)
                return ParseError.Overflow;
            if (e < -127)
                return ParseError.Underflow;
            ufu.uintValue = (ufu.uintValue & ~(0xFFU<<23)) | ((uint)(e + 127) << 23);
            output = ufu.floatValue;
            return ParseError.None;
        }

        static int tzcnt(uint v)
        {
            uint c = 32; // c will be the number of zero bits on the right
            v &= (uint)-(int)v;
            if (0 != v) c--;
            if (0 != (v & 0x0000FFFF)) c -= 16;
            if (0 != (v & 0x00FF00FF)) c -= 8;
            if (0 != (v & 0x0F0F0F0F)) c -= 4;
            if (0 != (v & 0x33333333)) c -= 2;
            if (0 != (v & 0x55555555)) c -= 1;
            return (int)c;
        }        
        
        public static void Base2ToBase10(ref ulong mantissa10, ref int exponent10, float input)
        {          
            UintFloatUnion ufu = new UintFloatUnion();
            ufu.floatValue = input;
            if(ufu.uintValue == 0)
            {
                mantissa10 = 0;
                exponent10 = 0;
                return;
            }
            var mantissa2 = (ufu.uintValue & ((1<<23)-1)) | (1 << 23);
            var exponent2 = (int) (ufu.uintValue >> 23) - 127 - 23;
//            var tz = tzcnt((uint)mantissa2);
//            mantissa2 >>= tz;
//            exponent2 += tz;
            mantissa10 = mantissa2;
            exponent10 = exponent2;
            if (exponent2 > 0)
            {
                while (exponent2 > 0)
                {
                    // denormalize mantissa10 as much as you can, to minimize loss when doing /5 below.
                    while (mantissa10 <= UInt64.MaxValue/10)
                    {
                        mantissa10 *= 10;
                        --exponent10;
                    }
                    mantissa10 /= 5;
                    --exponent2;
                }
            }
            if (exponent2 < 0)
            {
                while (exponent2 < 0)
                {
                    // normalize mantissa10 just as much as you need, in order to make the *5 below not overflow.
                    while (mantissa10 > UInt64.MaxValue/5)
                    {
                        mantissa10 /= 10;
                        ++exponent10;
                    }
                    mantissa10 *= 5;
                    ++exponent2;
                }
            }
            // normalize mantissa10                
            while (mantissa10 > 9999999U || mantissa10 % 10 == 0) 
            {
                mantissa10 = (mantissa10 + 5) / 10;
                ++exponent10;
            }
        }
        
        public FormatError Format(char a)
        {
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = a;
            return FormatError.None;
        }
        
        public FormatError Format(char a, char b)
        {
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = a;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = b;
            return FormatError.None;
        }
        
        public FormatError Format(char a, char b, char c)
        {            
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = a;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = b;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = c;
            return FormatError.None;
        }

        public FormatError Format(char a, char b, char c, char d, char e, char f, char g, char h)
        {            
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = a;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = b;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = c;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = d;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = e;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = f;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = g;
            if (Length >= Capacity)
                return FormatError.Overflow;
            buffer[Length++] = h;
            return FormatError.None;
        }

        public FormatError FormatScientific(char *source, int sourceLength, int decimalExponent, char decimalSeparator)
        {
            FormatError error;
            if ((error = Format(source[0])) != FormatError.None)
                return error;
            if (sourceLength > 1)
            {
                if ((error = Format(decimalSeparator)) != FormatError.None)
                    return error;
                for (var i = 1; i < sourceLength; ++i)
                {
                    if ((error = Format(source[i])) != FormatError.None)
                        return error;
                }
            }
            if ((error = Format('E')) != FormatError.None)
                return error;
            if (decimalExponent < 0)
            {
                if ((error = Format('-')) != FormatError.None)
                    return error;
                decimalExponent *= -1;
            }
            else
                if ((error = Format('+')) != FormatError.None)
                    return error;
            var ascii = stackalloc char[2];
            decimalExponent -= sourceLength - 1;
            const int decimalDigits = 2;
            for(var i = 0; i < decimalDigits; ++i)
            {
                var decimalDigit = decimalExponent % 10;
                ascii[1 - i] = (char)('0'+decimalDigit);
                decimalExponent /= 10;                        
            }
            for(var i = 0; i < decimalDigits; ++i)
                if ((error = Format(ascii[i])) != FormatError.None)
                    return error;            
            return FormatError.None;                       
        }
        
        public FormatError Format(float input, char decimalSeparator)
        {
            UintFloatUnion ufu = new UintFloatUnion();
            ufu.floatValue = input;
            if (ufu.uintValue == 4290772992U)
                return Format('N', 'a', 'N');
            var sign = ufu.uintValue >> 31;
            ufu.uintValue &= ~(1 << 31);
            FormatError error;
            if (sign != 0 && ufu.uintValue != 0) // C# prints -0 as 0
                if ((error = Format('-')) != FormatError.None)
                    return error;
            if(ufu.uintValue == 2139095040U)
                return Format( 'I', 'n', 'f', 'i', 'n', 'i', 't', 'y');
            ulong decimalMantissa = 0;
            int decimalExponent = 0;
            Base2ToBase10(ref decimalMantissa, ref decimalExponent, ufu.floatValue);
            var backwards = stackalloc char[9];
            int decimalDigits = 0;
            do
            {
                if (decimalDigits >= 9)
                    return FormatError.Overflow;
                var decimalDigit = decimalMantissa % 10;
                backwards[8-decimalDigits++] = (char) ('0' + decimalDigit);
                decimalMantissa /= 10;
            } while (decimalMantissa > 0);
            char *ascii = backwards + 9 - decimalDigits;
            var leadingZeroes = -decimalExponent - decimalDigits + 1;
            if (leadingZeroes > 0)
            {
                if (leadingZeroes > 4)
                    return FormatScientific(ascii, decimalDigits, decimalExponent, decimalSeparator);
                if ((error = Format('0', decimalSeparator)) != FormatError.None)
                    return error;
                --leadingZeroes;
                while (leadingZeroes > 0)
                {
                    if ((error = Format( '0')) != FormatError.None)
                        return error;
                    --leadingZeroes;
                }
                for (var i = 0; i < decimalDigits; ++i)
                {
                    if ((error = Format( ascii[i])) != FormatError.None)
                        return error;
                }
                return FormatError.None;
            }
            var trailingZeroes = decimalExponent;
            if (trailingZeroes > 0)
            {
                if (trailingZeroes > 4)
                    return FormatScientific(  ascii, decimalDigits, decimalExponent, decimalSeparator);                
                for (var i = 0; i < decimalDigits; ++i)
                {
                    if ((error = Format( ascii[i])) != FormatError.None)
                        return error;
                }
                while (trailingZeroes > 0)
                {
                    if ((error = Format( '0')) != FormatError.None)
                        return error;
                    --trailingZeroes;                    
                }                
                return FormatError.None;
            }
            var indexOfSeparator = decimalDigits + decimalExponent;
            for (var i = 0; i < decimalDigits; ++i)
            {
                if (i == indexOfSeparator)
                    if ((error = Format(decimalSeparator)) != FormatError.None)
                        return error;
                if ((error = Format( ascii[i])) != FormatError.None)
                    return error;
            }
            return FormatError.None;
        }

        public bool Found(ref int offset, char a, char b, char c)
        {
            if(offset + 3 > Length)
                return false;
            if((buffer[offset+0]|32) != a) return false;
            if((buffer[offset+1]|32) != b) return false;
            if((buffer[offset+2]|32) != c) return false;
            offset += 3;
            return true;            
        }

        public bool Found(ref int offset, char a, char b, char c, char d, char e, char f, char g, char h)
        {
            if(offset + 8 > Length)
                return false;
            if((buffer[offset+0]|32) != a) return false;
            if((buffer[offset+1]|32) != b) return false;
            if((buffer[offset+2]|32) != c) return false;
            if((buffer[offset+3]|32) != d) return false;
            if((buffer[offset+4]|32) != e) return false;
            if((buffer[offset+5]|32) != f) return false;
            if((buffer[offset+6]|32) != g) return false;
            if((buffer[offset+7]|32) != h) return false;
            offset += 8;
            return true;            
        }
        
        public ParseError Parse(ref int offset, ref float output, char decimalSeparator)
        {
            if(Found(ref offset, 'n', 'a', 'n'))
            {
                UintFloatUnion ufu = new UintFloatUnion();
                ufu.uintValue = 4290772992U;
                output = ufu.floatValue;
                return ParseError.None;
            }            
            int sign = 1;
            if (offset < Length)
            {
                if (buffer[offset] == '+')
                    ++offset;
                else if (buffer[offset] == '-')
                {
                    sign = -1;
                    ++offset;
                }
            }
            ulong decimalMantissa = 0;
            int significantDigits = 0;
            int digitsAfterDot = 0;
            int mantissaDigits = 0;
            if(Found(ref offset, 'i', 'n', 'f', 'i', 'n', 'i', 't', 'y'))
            {
                output = (sign == 1) ? Single.PositiveInfinity : Single.NegativeInfinity;
                return ParseError.None;
            }
            while (offset < Length && IsDigit(buffer[offset]))
            {
                ++mantissaDigits;
                if (significantDigits < 9)
                {
                    var temp = decimalMantissa * 10 + (ulong)(buffer[offset] - '0');
                    if (temp > decimalMantissa)
                        ++significantDigits;
                    decimalMantissa = temp;
                }
                else
                    --digitsAfterDot;
                ++offset;
            }
            if (offset < Length && buffer[offset] == decimalSeparator)
            {
                ++offset;
                while (offset < Length && IsDigit(buffer[offset]))
                {
                    ++mantissaDigits;
                    if (significantDigits < 9)
                    {
                        var temp = decimalMantissa * 10 + (ulong) (buffer[offset] - '0');
                        if (temp > decimalMantissa)
                            ++significantDigits;
                        decimalMantissa = temp;
                        ++digitsAfterDot;
                    }
                    ++offset;
                }
            }
            if (mantissaDigits == 0)
                return ParseError.Syntax;
            int decimalExponent = 0;
            int decimalExponentSign = 1;
            if (offset < Length && ((buffer[offset]|32) == 'e'))
            {
                ++offset;
                if (offset < Length)
                {
                    if (buffer[offset] == '+')
                        ++offset;
                    else if (buffer[offset] == '-')
                    {
                        decimalExponentSign = -1;
                        ++offset;
                    }
                }
                int exponentDigits = 0;
                while (offset < Length && IsDigit(buffer[offset]))
                {
                    ++exponentDigits;
                    decimalExponent = decimalExponent * 10 + (buffer[offset] - '0');
                    if (decimalExponent > 38)
                        if(decimalExponentSign == 1)
                            return ParseError.Overflow;
                        else
                            return ParseError.Underflow;
                    ++offset;
                }
                if (exponentDigits == 0)
                    return ParseError.Syntax;
            }
            decimalExponent = decimalExponent * decimalExponentSign - digitsAfterDot;            
            var error = Base10ToBase2(ref output, decimalMantissa, decimalExponent);
            if (error != ParseError.None)
                return error;
            output *= sign;
            return ParseError.None;
        }
        
        public static CopyError Copy(char *dest, out int destLength, int destMaxLength, char *src, int srcLength)
        {
            CopyError error = CopyError.None;
            destLength = srcLength;
            if (destLength > destMaxLength)
            {
                destLength = destMaxLength;
                error = CopyError.Truncation;
            }
            UnsafeUtility.MemCpy(dest, src, destLength * sizeof(char));
            return error;
        }
        
    }

    public struct NativeString64 : IComparable<NativeString64>, IEquatable<NativeString64>
    {
        public const int MaxLength = (64 - sizeof(int)) / sizeof(char);
        public int Length;
        private unsafe fixed uint buffer[MaxLength/2];

        public ParseError Parse(ref int offset, ref int output)
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    NativeString temp = new NativeString{buffer = c, Length = Length, Capacity = MaxLength};
                    return temp.Parse(ref offset, ref output);                    
                }
            }
        }
        public ParseError Parse(ref int offset, ref float output, char decimalSeparator = '.')
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    NativeString temp = new NativeString {buffer = c, Length = Length, Capacity = MaxLength};
                    return temp.Parse(ref offset, ref output, decimalSeparator);
                }
            }
        }

        public FormatError Format(float input, char decimalSeparator = '.')
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    NativeString temp = new NativeString {buffer = c, Length = Length, Capacity = MaxLength};
                    var error = temp.Format(input, decimalSeparator);
                    Length = temp.Length;
                    return error;
                }
            }
        }

        public unsafe CopyError CopyFrom(NativeString64 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(NativeString512 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(NativeString4096 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(char* s, int length)
        {
            fixed (uint* b = buffer)
                return NativeString.Copy((char*)b, out Length, MaxLength, s, length);
        }
        public unsafe CopyError CopyFrom(String source)
        {
            fixed(char *c = source)
                return CopyFrom(c, source.Length);
        }        
        public unsafe CopyError CopyTo(char* d, out int length, int maxLength)
        {
            fixed (uint* b = buffer)
                return NativeString.Copy(d, out length, maxLength, (char*) b, Length);
        }


        public NativeString64(String source)
        {
            Length = 0;
            CopyFrom(source);
        }
        
        public NativeString64(ref NativeString512 source)
        {
            Length = 0;
            CopyFrom(source);
        }

        public NativeString64(ref NativeString4096 source)
        {
            Length = 0;
            CopyFrom(source);
        }
        
        public char this[int index]
        {
            get
            {
                Assert.IsTrue(index >= 0 && index < Length);
                unsafe
                {
                    fixed (uint* b = buffer)
                    {
                        var c = (char*) b;
                        return c[index];
                    }
                }
            }
            set
            {
                Assert.IsTrue(index >= 0 && index < Length);
                unsafe
                {
                    fixed (uint* b = buffer)
                    {
                        var c = (char*) b;
                        c[index] = value;
                    }
                }
            }
        }
        public override String ToString()
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
#if !UNITY_DOTSPLAYER
                    return new String(c, 0, Length);
#else
                    var s = new char[Length];
                    for(var i = 0; i < Length; ++i)
                        s[i] = c[i];
                    return new String(s, 0, Length);
#endif
                }
            }
        }
        public override int GetHashCode()
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return (int) math.hash(c, Length * sizeof(char));
                }
            }
        }

        
        public int CompareTo(NativeString64 other)
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return NativeString.CompareTo(c, Length, (char*)other.buffer, other.Length);
                }
            }
        }

        public bool Equals(NativeString64 other)
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return NativeString.Equals(c, Length, (char*)other.buffer, other.Length);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is NativeString64 other && Equals(other);
        }
    }

    public struct NativeString512 : IComparable<NativeString512>, IEquatable<NativeString512>
    {
        public const int MaxLength = (512 - sizeof(int)) / 2;
        public int Length;
        private unsafe fixed uint buffer[MaxLength/2];
        
        public unsafe CopyError CopyFrom(NativeString64 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(NativeString512 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(NativeString4096 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(char* s, int length)
        {
            fixed (uint* b = buffer)
                return NativeString.Copy((char*)b, out Length, MaxLength, s, length);
        }
        public unsafe CopyError CopyFrom(String source)
        {
            fixed(char *c = source)
                return CopyFrom(c, source.Length);
        }        
        public unsafe CopyError CopyTo(char* d, out int length, int maxLength)
        {
            fixed (uint* b = buffer)
                return NativeString.Copy(d, out length, maxLength, (char*) b, Length);
        }
        
        public NativeString512(String source)
        {
            Length = 0;
            CopyFrom(source);
        }
        
        public NativeString512(ref NativeString64 source)
        {
            Length = 0;
            CopyFrom(source);
        }

        public NativeString512(ref NativeString4096 source)
        {
            Length = 0;
            CopyFrom(source);
        }
        
        public char this[int index]
        {
            get
            {
                Assert.IsTrue(index >= 0 && index < Length);
                unsafe
                {
                    fixed (uint* b = buffer)
                    {
                        var c = (char*) b;
                        return c[index];
                    }
                }
            }
            set
            {
                Assert.IsTrue(index >= 0 && index < Length);
                unsafe
                {
                    fixed (uint* b = buffer)
                    {
                        var c = (char*) b;
                        c[index] = value;
                    }
                }
            }
        }
        public override String ToString()
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
#if !UNITY_DOTSPLAYER
                    return new String(c, 0, Length);
#else
                    var s = new char[Length];
                    for(var i = 0; i < Length; ++i)
                        s[i] = c[i];
                    return new String(s, 0, Length);
#endif
                }
            }
        }
        public override int GetHashCode()
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return (int) math.hash(c, Length * sizeof(char));
                }
            }
        }
       
        public int CompareTo(NativeString512 other)
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return NativeString.CompareTo(c, Length, (char*)other.buffer, other.Length);
                }
            }
        }

        public bool Equals(NativeString512 other)
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return NativeString.Equals(c, Length, (char*)other.buffer, other.Length);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is NativeString512 other && Equals(other);
        }
    }

    public struct NativeString4096 : IComparable<NativeString4096>, IEquatable<NativeString4096>
    {
        public const int MaxLength = (4096 - sizeof(int)) / 2;
        public int Length;
        private unsafe fixed uint buffer[MaxLength/2];
        
        public unsafe CopyError CopyFrom(NativeString64 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(NativeString512 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(NativeString4096 source)
        {
            fixed (uint* b = buffer)
                return source.CopyTo((char*) b, out Length, MaxLength);
        }
        public unsafe CopyError CopyFrom(char* s, int length)
        {
            fixed (uint* b = buffer)
                return NativeString.Copy((char*)b, out Length, MaxLength, s, length);
        }
        public unsafe CopyError CopyFrom(String source)
        {
            fixed(char *c = source)
                return CopyFrom(c, source.Length);
        }        
        public unsafe CopyError CopyTo(char* d, out int length, int maxLength)
        {
            fixed (uint* b = buffer)
                return NativeString.Copy(d, out length, maxLength, (char*) b, Length);
        }
        
        public NativeString4096(String source)
        {            
            Length = 0;
            CopyFrom(source);
        }
        
        public NativeString4096(ref NativeString64 source)
        {
            Length = 0;
            CopyFrom(source);
        }

        public NativeString4096(ref NativeString512 source)
        {
            Length = 0;
            CopyFrom(source);
        }
        
        public char this[int index]
        {
            get
            {
                Assert.IsTrue(index >= 0 && index < Length);
                unsafe
                {
                    fixed (uint* b = buffer)
                    {
                        var c = (char*) b;
                        return c[index];
                    }
                }
            }
            set
            {
                Assert.IsTrue(index >= 0 && index < Length);
                unsafe
                {
                    fixed (uint* b = buffer)
                    {
                        var c = (char*) b;
                        c[index] = value;
                    }
                }
            }
        }
        public override String ToString()
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
#if !UNITY_DOTSPLAYER
                    return new String(c, 0, Length);
#else
                    var s = new char[Length];
                    for(var i = 0; i < Length; ++i)
                        s[i] = c[i];
                    return new String(s, 0, Length);
#endif
                }
            }
        }
        public override int GetHashCode()
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return (int) math.hash(c, Length * sizeof(char));
                }
            }
        }
        
        public int CompareTo(NativeString4096 other)
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return NativeString.CompareTo(c, Length, (char*)other.buffer, other.Length);
                }
            }
        }

        public bool Equals(NativeString4096 other)
        {
            unsafe
            {
                fixed (uint* b = buffer)
                {
                    var c = (char*) b;
                    return NativeString.Equals(c, Length, (char*)other.buffer, other.Length);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is NativeString4096 other && Equals(other);
        }
    }
    
    // A "NativeStringView" does not manage its own memory - it expects some other object to manage its memory
    // on its behalf.        
    
    public struct NativeStringView
    {
        unsafe char* pointer;
        int length;
        public unsafe NativeStringView(char* p, int l)
        {
            pointer = p;
            length = l;
        }

        public unsafe char this[int index]
        {
            get => UnsafeUtility.ReadArrayElement<char>(pointer, index);
            set => UnsafeUtility.WriteArrayElement<char>(pointer, index, value);
        }        
        public int Length => length;
        public override String ToString()
        {
            unsafe
            {
#if !UNITY_DOTSPLAYER
                return new String(pointer, 0, length);
#else
                var c = new char[Length];
                for(var i = 0; i < Length; ++i)
                    c[i] = pointer[i];
                return new String(c, 0, Length);
#endif
            }
        }

        public override int GetHashCode()
        {
            unsafe
            {
                return (int)math.hash(pointer, Length * sizeof(char));                
            }            
        }
    }
           
    sealed class WordStorageDebugView
    {
        WordStorage m_wordStorage;

        public WordStorageDebugView(WordStorage wordStorage)
        {
            m_wordStorage = wordStorage;
        }
        
        public NativeStringView[] Table
        {
            get
            {
                var table = new NativeStringView[m_wordStorage.Entries];
                for (var i = 0; i < m_wordStorage.Entries; ++i)
                    table[i] = m_wordStorage.GetNativeStringView(i);
                return table;
            }
        }
    }
    
    [DebuggerTypeProxy(typeof(WordStorageDebugView))]
    public class WordStorage : IDisposable
    {        
        private NativeArray<ushort> buffer; // all the UTF-16 encoded bytes in one place
        private NativeArray<int> offset; // one offset for each text in "buffer"
        private NativeArray<ushort> length; // one length for each text in "buffer"
        private NativeMultiHashMap<int,int> hash; // from string hash to table entry
        private int chars; // bytes in buffer allocated so far
        private int entries; // number of strings allocated so far
        static WordStorage _Instance;

        public static WordStorage Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WordStorage();
                return _Instance;
            }
            set { _Instance = value; }
        }

        const int kMaxEntries = 10000;
        const int kMaxChars = kMaxEntries * 100;

        public const int kMaxCharsPerEntry = 4096;
        
        public int Entries => entries;
        
        void Initialize()
        {
            buffer = new NativeArray<ushort>(kMaxChars, Allocator.Persistent);
            offset = new NativeArray<int>(kMaxEntries, Allocator.Persistent);
            length = new NativeArray<ushort>(kMaxEntries, Allocator.Persistent);
            hash = new NativeMultiHashMap<int,int>(kMaxEntries, Allocator.Persistent);
            chars = 0;
            entries = 0;
            GetOrCreateIndex(new NativeStringView()); // make sure that Index=0 means empty string
        }
        WordStorage()
        {
            Initialize();
        }
        public static void Setup()
        {
            if(Instance.buffer.Length > 0)
                Instance.Dispose();
            Instance.Initialize();
        }
        
        public unsafe NativeStringView GetNativeStringView(int index)
        {
            Assert.IsTrue(index < entries);
            var o = offset[index];
            var l = length[index];
            Assert.IsTrue(l <= kMaxCharsPerEntry);
            return new NativeStringView((char*)buffer.GetUnsafePtr() + o, l);
        }
        
        public int GetIndex(int h, NativeStringView temp)
        {
            Assert.IsTrue(temp.Length <= kMaxCharsPerEntry); // about one printed page of text
            int itemIndex;
            NativeMultiHashMapIterator<int> iter;
            if (hash.TryGetFirstValue(h, out itemIndex, out iter))
            {
                var l = length[itemIndex];
                Assert.IsTrue(l <= kMaxCharsPerEntry);
                if (l == temp.Length)
                {
                    var o = offset[itemIndex];
                    int matches;
                    for(matches = 0; matches < l; ++matches)
                        if (temp[matches] != buffer[o + matches])
                            break;
                    if (matches == temp.Length)
                        return itemIndex;

                }
            } while (hash.TryGetNextValue(out itemIndex, ref iter));
            return -1;            
        }

        public bool Contains(NativeStringView value)
        {            
            int h = value.GetHashCode();
            return GetIndex(h, value) != -1;
        }

        public unsafe bool Contains(String value)
        {
            fixed(char *c = value)
                return Contains(new NativeStringView(c, value.Length));
        }

        public int GetOrCreateIndex(NativeStringView value)
        {
            int h = value.GetHashCode();
            var itemIndex = GetIndex(h, value);
            if (itemIndex != -1)
                return itemIndex;
            Assert.IsTrue(entries < kMaxEntries);
            Assert.IsTrue(chars + value.Length <= kMaxChars);
            var o = chars;
            var l = (ushort)value.Length;
            for (var i = 0; i < l; ++i)
                buffer[chars++] = value[i];
            offset[entries] = o;
            length[entries] = l;
            hash.Add(h, entries);
            return entries++;
        }
        
        public void Dispose()
        {
            buffer.Dispose();
            offset.Dispose();
            length.Dispose();
            hash.Dispose();
        }
    }

    // A "Words" is an integer that refers to 4,096 or fewer chars of UTF-16 text in a global storage blob.
    // Each should refer to *at most* about one printed page of text.
    // If you need more text, consider using one Words struct for each printed page's worth.
    // If you need to store the text of "War and Peace" in a single object, you've come to the wrong place.
    
    public struct Words
    {
        private int Index;     
        public NativeStringView ToNativeStringView()
        {
            return WordStorage.Instance.GetNativeStringView(Index);
        }
        public override String ToString()
        {
            return WordStorage.Instance.GetNativeStringView(Index).ToString();
        }
        public unsafe void SetString(String value)
        {
            fixed(char *c = value)
                Index = WordStorage.Instance.GetOrCreateIndex(new NativeStringView(c, value.Length));            
        }
    }

    // A "NumberedWords" is a "Words", plus possibly a string of leading zeroes, followed by
    // possibly a positive integer.
    // The zeroes and integer aren't stored centrally as a string, they're stored as an int.
    // Therefore, 1,000,000 items with names from FooBarBazBifBoo000000 to FooBarBazBifBoo999999
    // Will cost 8MB + a single copy of "FooBarBazBifBoo", instead of ~48MB. 
    // They say that this is a thing, too.
    
    public struct NumberedWords
    {
        private int Index;
        private int Suffix;
        
        private const int kPositiveNumericSuffixShift = 0;
        private const int kPositiveNumericSuffixBits = 29;
        private const int kMaxPositiveNumericSuffix = (1 << kPositiveNumericSuffixBits) - 1;
        private const int kPositiveNumericSuffixMask = (1 << kPositiveNumericSuffixBits) - 1;

        private const int kLeadingZeroesShift = 29;
        private const int kLeadingZeroesBits = 3;
        private const int kMaxLeadingZeroes = (1 << kLeadingZeroesBits) - 1;
        private const int kLeadingZeroesMask = (1 << kLeadingZeroesBits) - 1;
        
        private int LeadingZeroes
        {
            get => (Suffix >> kLeadingZeroesShift) & kLeadingZeroesMask;
            set
            {
                Suffix &= ~(kLeadingZeroesMask << kLeadingZeroesShift);
                Suffix |= (value & kLeadingZeroesMask) << kLeadingZeroesShift;
            }
        }

        private int PositiveNumericSuffix
        {
            get => (Suffix >> kPositiveNumericSuffixShift) & kPositiveNumericSuffixMask;
            set
            {
                Suffix &= ~(kPositiveNumericSuffixMask << kPositiveNumericSuffixShift);
                Suffix |= (value & kPositiveNumericSuffixMask) << kPositiveNumericSuffixShift;
            }
        }

        bool HasPositiveNumericSuffix => PositiveNumericSuffix != 0;

        string NewString(char c, int count)
        {
            char[] temp = new char[count];
            for (var i = 0; i < count; ++i)
                temp[i] = c;
            return new string(temp, 0, count);
        }
        
        public override String ToString()
        {
            String temp = WordStorage.Instance.GetNativeStringView(Index).ToString();
            var leadingZeroes = LeadingZeroes;
            if (leadingZeroes > 0)
                temp += NewString('0', leadingZeroes);
            if (HasPositiveNumericSuffix)
                temp += PositiveNumericSuffix;
            return temp;
        }

        bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        string Substring(string s, int offset, int count)
        {
            char[] c = new char[count];
            for (var i = 0; i < count; ++i)
                c[i] = s[offset + i];
            return new string(c, 0, count);
        }
        
        public unsafe void SetString(String value)
        {
            int beginningOfDigits = value.Length;

            // as long as there are digits at the end,
            // look back for more digits.

            while (beginningOfDigits > 0 && IsDigit(value[beginningOfDigits - 1]))
                --beginningOfDigits;

            // as long as the first digit is a zero, it's not the beginning of the positive integer - it's a leading zero.
            
            var beginningOfPositiveNumericSuffix = beginningOfDigits;
            while (beginningOfPositiveNumericSuffix < value.Length && value[beginningOfPositiveNumericSuffix] == '0')
                ++beginningOfPositiveNumericSuffix;

            // now we know where the leading zeroes begin, and then where the positive integer begins after them.
            // but if there are too many leading zeroes to encode, the excess ones become part of the string.
            
            var leadingZeroes = beginningOfPositiveNumericSuffix - beginningOfDigits;
            if (leadingZeroes > kMaxLeadingZeroes)
            {
                var excessLeadingZeroes = leadingZeroes - kMaxLeadingZeroes;
                beginningOfDigits += excessLeadingZeroes;
                leadingZeroes -= excessLeadingZeroes;
            }
                        
            // if there is a positive integer after the zeroes, here's where we compute it and store it for later.

            PositiveNumericSuffix = 0;
            {
                int number = 0;
                for (var i = beginningOfPositiveNumericSuffix; i < value.Length; ++i)
                {
                    number *= 10;
                    number += value[i] - '0';
                }
                
                // an intrepid user may attempt to encode a positive integer with 20 digits or something.
                // they are rewarded with a string that is encoded wholesale without any optimizations.
                
                if(number <= kMaxPositiveNumericSuffix)
                    PositiveNumericSuffix = number; 
                else
                {
                    beginningOfDigits = value.Length; 
                    leadingZeroes = 0; // and your dog Toto, too.
                }
            }

            // set the leading zero count in the Suffix member.
            
            LeadingZeroes = leadingZeroes;

            // truncate the string, if there were digits at the end that we encoded.
            
            if(beginningOfDigits != value.Length)
                value = Substring(value, 0, beginningOfDigits);

            // finally, set the string to its index in the global string blob thing.

            fixed(char *c = value)
                Index = WordStorage.Instance.GetOrCreateIndex(new NativeStringView(c, value.Length));      
        }
    }
}
