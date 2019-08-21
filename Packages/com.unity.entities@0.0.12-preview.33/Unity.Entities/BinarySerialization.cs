using System;
using System.IO;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities.Serialization
{
    public interface BinaryWriter : IDisposable
    {
        unsafe void WriteBytes(void* data, int bytes);
    }

    static unsafe class BinaryWriterExtensions
    {
        public static void Write(this BinaryWriter writer, byte value)
        {
            writer.WriteBytes(&value, 1);
        }

        public static void Write(this BinaryWriter writer, int value)
        {
            writer.WriteBytes(&value, sizeof(int));
        }

        public static void Write(this BinaryWriter writer, ulong value)
        {
            writer.WriteBytes(&value, sizeof(ulong));
        }

        public static void Write(this BinaryWriter writer, byte[] bytes)
        {
            fixed(byte* p = bytes)
            {
                writer.WriteBytes(p, bytes.Length);
            }
        }

        public static void WriteArray<T>(this BinaryWriter writer, NativeArray<T> data) where T: struct
        {
            writer.WriteBytes(data.GetUnsafeReadOnlyPtr(), data.Length * UnsafeUtility.SizeOf<T>());
        }

        public static void WriteList<T>(this BinaryWriter writer, NativeList<T> data) where T: struct
        {
            writer.WriteBytes(data.GetUnsafePtr(), data.Length * UnsafeUtility.SizeOf<T>());
        }
    }

    public interface BinaryReader : IDisposable
    {
        unsafe void ReadBytes(void* data, int bytes);
    }

    static unsafe class BinaryReaderExtensions
    {
        public static byte ReadByte(this BinaryReader reader)
        {
            byte value;
            reader.ReadBytes(&value, 1);
            return value;
        }

        public static int ReadInt(this BinaryReader reader)
        {
            int value;
            reader.ReadBytes(&value, sizeof(int));
            return value;
        }

        public static ulong ReadULong(this BinaryReader reader)
        {
            ulong value;
            reader.ReadBytes(&value, sizeof(ulong));
            return value;
        }

        public static void ReadBytes(this BinaryReader writer, NativeArray<byte> elements, int count, int offset = 0)
        {
            byte* destination = (byte*)elements.GetUnsafePtr() + offset;
            writer.ReadBytes(destination, count);
        }

        public static void ReadArray<T>(this BinaryReader reader, NativeArray<T> elements, int count) where T: struct
        {
            reader.ReadBytes((byte*)elements.GetUnsafePtr(), count * UnsafeUtility.SizeOf<T>());
        }
    }

#if !NET_DOTS
    public unsafe class StreamBinaryReader : BinaryReader
    {
        private Stream stream;
        private byte[] buffer;

        public StreamBinaryReader(string fileName, int bufferSize = 65536)
        {
            stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            buffer = new byte[bufferSize];
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public void ReadBytes(void* data, int bytes)
        {
            int remaining = bytes;
            int bufferSize = buffer.Length;

            fixed (byte* fixedBuffer = buffer)
            {
                while (remaining != 0)
                {
                    int read = stream.Read(buffer, 0, Math.Min(remaining, bufferSize));
                    remaining -= read;
                    UnsafeUtility.MemCpy(data, fixedBuffer, read);
                    data = (byte*) data + read;
                }
            }
        }
    }

    public unsafe class StreamBinaryWriter : BinaryWriter
    {
        private Stream stream;
        private byte[] buffer;

        public StreamBinaryWriter(string fileName, int bufferSize = 65536)
        {
            stream = File.Open(fileName, FileMode.Create, FileAccess.Write);
            buffer = new byte[bufferSize];
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public void WriteBytes(void* data, int bytes)
        {
            int remaining = bytes;
            int bufferSize = buffer.Length;

            fixed (byte* fixedBuffer = buffer)
            {
                while (remaining != 0)
                {
                    int bytesToWrite = Math.Min(remaining, bufferSize);
                    UnsafeUtility.MemCpy(fixedBuffer, data, bytesToWrite);
                    stream.Write(buffer, 0, bytesToWrite);
                    data = (byte*) data + bytesToWrite;
                    remaining -= bytesToWrite;
                }
            }
        }

        public long Length => stream.Length;
    }
#endif

    public unsafe class MemoryBinaryWriter : Entities.Serialization.BinaryWriter
    {
        NativeList<byte> content = new NativeList<byte>(Allocator.Temp);
        public byte* Data => (byte*)content.GetUnsafePtr();
        public int Length => content.Length;

        public void Dispose()
        {
            content.Dispose();
        }

        public void WriteBytes(void* data, int bytes)
        {
            int length = content.Length;
            content.ResizeUninitialized(length + bytes);
            UnsafeUtility.MemCpy((byte*)content.GetUnsafePtr() + length, data, bytes);
        }

    }

    public unsafe class MemoryBinaryReader : BinaryReader
    {
        byte* content;

        public MemoryBinaryReader(byte* content)
        {
            this.content = content;
        }

        public void Dispose()
        {
        }

        public void ReadBytes(void* data, int bytes)
        {
            UnsafeUtility.MemCpy(data, content, bytes);
            content += bytes;
        }
    }
}

