using System;
using Unity.Entities;
using Unity.Entities.Tests;

[assembly: RegisterGenericComponentType(typeof(EcsTestGeneric<int>))]
[assembly: RegisterGenericComponentType(typeof(EcsTestGeneric<float>))]
[assembly: RegisterGenericComponentType(typeof(EcsTestGenericTag<int>))]
[assembly: RegisterGenericComponentType(typeof(EcsTestGenericTag<float>))]

namespace Unity.Entities.Tests
{
    public struct EcsTestData : IComponentData
    {
        public int value;

        public EcsTestData(int inValue)
        {
            value = inValue;
        }
    }

    public struct EcsTestData2 : IComponentData
    {
        public int value0;
        public int value1;

        public EcsTestData2(int inValue)
        {
            value1 = value0 = inValue;
        }
    }

    public struct EcsTestData3 : IComponentData
    {
        public int value0;
        public int value1;
        public int value2;

        public EcsTestData3(int inValue)
        {
            value2 = value1 = value0 = inValue;
        }
    }

    public struct EcsTestData4 : IComponentData
    {
        public int value0;
        public int value1;
        public int value2;
        public int value3;

        public EcsTestData4(int inValue)
        {
            value3 = value2 = value1 = value0 = inValue;
        }
    }

    public struct EcsTestData5 : IComponentData
    {
        public int value0;
        public int value1;
        public int value2;
        public int value3;
        public int value4;

        public EcsTestData5(int inValue)
        {
            value4 = value3 = value2 = value1 = value0 = inValue;
        }
    }
    public struct EcsTestSharedComp : ISharedComponentData
    {
        public int value;

        public EcsTestSharedComp(int inValue)
        {
            value = inValue;
        }
    }

    public struct EcsTestSharedComp2 : ISharedComponentData
    {
        public int value0;
        public int value1;

        public EcsTestSharedComp2(int inValue)
        {
            value0 = value1 = inValue;
        }
    }

    public struct EcsTestDataEntity : IComponentData
    {
        public int value0;
        public Entity value1;

        public EcsTestDataEntity(int inValue0, Entity inValue1)
        {
            value0 = inValue0;
            value1 = inValue1;
        }
    }

    public struct EcsTestDataBlobAssetRef : IComponentData
    {
        public BlobAssetReference<int> value;
    }

    public struct EcsTestDataBlobAssetArray : IComponentData
    {
        public BlobAssetReference<BlobArray<float>> array;
    }

    public struct EcsTestSharedCompEntity : ISharedComponentData
    {
        public Entity value;

        public EcsTestSharedCompEntity(Entity inValue)
        {
            value = inValue;
        }

    }

    struct EcsState1 : ISystemStateComponentData
    {
        public int Value;

        public EcsState1(int value)
        {
            Value = value;
        }
    }

    struct EcsStateTag1 : ISystemStateComponentData
    {
    }

    [InternalBufferCapacity(8)]
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

    [InternalBufferCapacity(8)]
    public struct EcsIntElement2 : IBufferElementData
    {
        public int Value0;
        public int Value1;
    }

    [InternalBufferCapacity(8)]
    public struct EcsIntElement3 : IBufferElementData
    {
        public int Value0;
        public int Value1;
        public int Value2;
    }

    [InternalBufferCapacity(8)]
    public struct EcsIntElement4 : IBufferElementData
    {
        public int Value0;
        public int Value1;
        public int Value2;
        public int Value3;
    }

    [InternalBufferCapacity(8)]
    public struct EcsIntStateElement : ISystemStateBufferElementData
    {
        public static implicit operator int(EcsIntStateElement e)
        {
            return e.Value;
        }

        public static implicit operator EcsIntStateElement(int e)
        {
            return new EcsIntStateElement {Value = e};
        }

        public int Value;
    }

    [InternalBufferCapacity(4)]
    public struct EcsComplexEntityRefElement : IBufferElementData
    {
        public int Dummy;
        public Entity Entity;
    }

    public struct EcsTestTag : IComponentData
    {
    }

    public struct EcsTestComponentWithBool : IComponentData, IEquatable<EcsTestComponentWithBool>
    {
        public bool value;

        public override int GetHashCode()
        {
            return value ? 0x11001100 : 0x22112211;
        }

        public bool Equals(EcsTestComponentWithBool other)
        {
            return other.value == value;
        }
    }

    public struct EcsStringSharedComponent : ISharedComponentData, IEquatable<EcsStringSharedComponent>
    {
        public string Value;

        public bool Equals(EcsStringSharedComponent other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

    public struct EcsTestGeneric<T> : IComponentData
        where T : struct
    {
        public T value;
    }

    public struct EcsTestGenericTag<T> : IComponentData
        where T : struct
    {
    }
}
