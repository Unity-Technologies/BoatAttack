#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA;
struct IsReadOnlyAttribute_t0F24CF54B4D1245C4463E7C989E457CB05E113F8;
struct NonVersionableAttribute_t1DB218A79D38828C49D22FA63D91E463687ABDF5;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

struct U3CModuleU3E_tF47F9AD17E4C851F27F94EF9A1FB29A52BA6B8A8 
{
};
struct Il2CppArrayBounds;

struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};

struct Unsafe_t7A5BFA4CCC4DE54D6A25FB6312C3DB95A35D2B9E  : public RuntimeObject
{
};

struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value_0;
};

struct IsReadOnlyAttribute_t0F24CF54B4D1245C4463E7C989E457CB05E113F8  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};

struct NonVersionableAttribute_t1DB218A79D38828C49D22FA63D91E463687ABDF5  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};

struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value_0;
};

struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2 (Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_CopyBlock_m275884E0E5269EE20C4FDB816A13EB0A33A5DD28 (void* ___destination0, void* ___source1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___destination0;
		void* L_1 = ___source1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memcpy(L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_CopyBlock_mA8175DDFFADA01EFD26E7DC6C1056471691EEDC7 (uint8_t* ___destination0, uint8_t* ___source1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		uint8_t* L_0 = ___destination0;
		uint8_t* L_1 = ___source1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memcpy(L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_CopyBlockUnaligned_mDC74221DAD22498BB43DABB5102F88D594774FEB (void* ___destination0, void* ___source1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___destination0;
		void* L_1 = ___source1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memcpy(L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_CopyBlockUnaligned_mD13DB0668E061153051CCE10829A29C5D8EB9509 (uint8_t* ___destination0, uint8_t* ___source1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		uint8_t* L_0 = ___destination0;
		uint8_t* L_1 = ___source1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memcpy(L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_InitBlock_m965E8E4DCB55DB85E260C50DF5BCB4C1AC9E72D9 (void* ___startAddress0, uint8_t ___value1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___startAddress0;
		uint8_t L_1 = ___value1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memset(L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_InitBlock_m22D44609198E040EFDD4B5FCC89DEF7C09EB420A (uint8_t* ___startAddress0, uint8_t ___value1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		uint8_t* L_0 = ___startAddress0;
		uint8_t L_1 = ___value1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memset(L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_InitBlockUnaligned_m59F5F56D7AF1385634EA2C8E6DA4ACFCDBA4783E (void* ___startAddress0, uint8_t ___value1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___startAddress0;
		uint8_t L_1 = ___value1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memset(L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Unsafe_InitBlockUnaligned_m8FA427864FE9EB5A31AA9672F5C3572782B6D1EF (uint8_t* ___startAddress0, uint8_t ___value1, uint32_t ___byteCount2, const RuntimeMethod* method) 
{
	{
		uint8_t* L_0 = ___startAddress0;
		uint8_t L_1 = ___value1;
		uint32_t L_2 = ___byteCount2;
		il2cpp_codegen_memset(L_0, L_1, L_2);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NonVersionableAttribute__ctor_mBC3056ECFEE16B17F3779A50EBDCCD519078E862 (NonVersionableAttribute_t1DB218A79D38828C49D22FA63D91E463687ABDF5* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IsReadOnlyAttribute__ctor_m5CCFBC2EDEEA918A10A9C5A57A355234A495046D (IsReadOnlyAttribute_t0F24CF54B4D1245C4463E7C989E457CB05E113F8* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
