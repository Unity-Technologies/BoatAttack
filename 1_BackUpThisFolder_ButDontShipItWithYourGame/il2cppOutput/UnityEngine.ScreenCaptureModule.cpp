#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



struct String_t;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

struct U3CModuleU3E_tE8CCFA91781BB9C429F0997CDE2C44CCD8FBF84E 
{
};
struct Il2CppArrayBounds;

struct ScreenCapture_t513DA8E74951FF61C8421D7046F6FC69A4153092  : public RuntimeObject
{
};

struct String_t  : public RuntimeObject
{
	int32_t ____stringLength_4;
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	String_t* ___Empty_6;
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

struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value_0;
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



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenCapture_CaptureScreenshot_mD9416E855CC184119DB9BE11CFA0787F49C7F608 (String_t* ___filename0, int32_t ___superSize1, int32_t ___CaptureMode2, const RuntimeMethod* method) ;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenCapture_CaptureScreenshot_m6E774804276C74577E82CD2200A4FC9972CA0505 (String_t* ___filename0, int32_t ___superSize1, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___filename0;
		int32_t L_1 = ___superSize1;
		ScreenCapture_CaptureScreenshot_mD9416E855CC184119DB9BE11CFA0787F49C7F608(L_0, L_1, 1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScreenCapture_CaptureScreenshot_mD9416E855CC184119DB9BE11CFA0787F49C7F608 (String_t* ___filename0, int32_t ___superSize1, int32_t ___CaptureMode2, const RuntimeMethod* method) 
{
	typedef void (*ScreenCapture_CaptureScreenshot_mD9416E855CC184119DB9BE11CFA0787F49C7F608_ftn) (String_t*, int32_t, int32_t);
	static ScreenCapture_CaptureScreenshot_mD9416E855CC184119DB9BE11CFA0787F49C7F608_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (ScreenCapture_CaptureScreenshot_mD9416E855CC184119DB9BE11CFA0787F49C7F608_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.ScreenCapture::CaptureScreenshot(System.String,System.Int32,UnityEngine.ScreenCapture/StereoScreenCaptureMode)");
	_il2cpp_icall_func(___filename0, ___superSize1, ___CaptureMode2);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
