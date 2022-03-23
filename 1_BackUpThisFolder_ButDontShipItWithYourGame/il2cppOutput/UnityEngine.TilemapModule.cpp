#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename T1, typename T2>
struct VirtualActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct VirtualActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3>
struct VirtualFuncInvoker3
{
	typedef R (*Func)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};

struct Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87;
struct Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D;
struct Action_2_t0302727DEEDCFCC692E80AEEC31B8066AE8C5550;
struct Action_2_t156C43F079E7E68155FCDCD12DC77DD11AEF7E3C;
struct Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2;
struct Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct SpriteU5BU5D_tCEE379E10CAD9DBFA770B331480592548ED0EA1B;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct Exception_t;
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164;
struct MethodInfo_t;
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A;
struct Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99;
struct SpriteAtlas_t7B9620FBFBE1CCB781F2ED24A3B2DD37734F66A8;
struct String_t;
struct Tile_t33119F106CFC3DC767E7D9306A958AAE12133490;
struct TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9;
struct Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751;
struct TilemapRenderer_t1A45FD335E86172CFBB77D657E1D6705A477A6CB;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C const RuntimeMethod* NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_m76FF49366AD64B309E424BF955B7C57C1850EAFA_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NativeArray_1_Copy_mC012394A9B0A5C70C934A7CB5120B70132781BEE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NativeArray_1_get_IsCreated_mE992FB4B97CD24CAF70D23773821AE2687DC4A30_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct SpriteU5BU5D_tCEE379E10CAD9DBFA770B331480592548ED0EA1B;
struct SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

struct U3CModuleU3E_t5E8190EE43F4DF5D80E8A6651A0469A8FD445F94 
{
};
struct Il2CppArrayBounds;

struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

struct NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C 
{
	void* ___m_Buffer_0;
	int32_t ___m_Length_1;
	int32_t ___m_AllocatorLabel_2;
};

struct NativeArray_1_t1520D9CD4959D9455C36ED19E490DBDC32B6EF5C 
{
	void* ___m_Buffer_0;
	int32_t ___m_Length_1;
	int32_t ___m_AllocatorLabel_2;
};

struct NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF 
{
	void* ___m_Buffer_0;
	int32_t ___m_Length_1;
	int32_t ___m_AllocatorLabel_2;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString_5;
	String_t* ___FalseString_6;
};

struct Color_tD001788D726C3A7F1379BEED0260B9591F440C1F 
{
	float ___r_0;
	float ___g_1;
	float ___b_2;
	float ___a_3;
};

struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value_0;
};

struct IntPtr_t 
{
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	intptr_t ___Zero_1;
};

struct Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 
{
	float ___m00_0;
	float ___m10_1;
	float ___m20_2;
	float ___m30_3;
	float ___m01_4;
	float ___m11_5;
	float ___m21_6;
	float ___m31_7;
	float ___m02_8;
	float ___m12_9;
	float ___m22_10;
	float ___m32_11;
	float ___m03_12;
	float ___m13_13;
	float ___m23_14;
	float ___m33_15;
};

struct Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6_StaticFields
{
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___zeroMatrix_16;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___identityMatrix_17;
};

struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value_0;
};

struct TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149 
{
	SpriteU5BU5D_tCEE379E10CAD9DBFA770B331480592548ED0EA1B* ___m_AnimatedSprites_0;
	float ___m_AnimationSpeed_1;
	float ___m_AnimationStartTime_2;
};
struct TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_pinvoke
{
	SpriteU5BU5D_tCEE379E10CAD9DBFA770B331480592548ED0EA1B* ___m_AnimatedSprites_0;
	float ___m_AnimationSpeed_1;
	float ___m_AnimationStartTime_2;
};
struct TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_com
{
	SpriteU5BU5D_tCEE379E10CAD9DBFA770B331480592548ED0EA1B* ___m_AnimatedSprites_0;
	float ___m_AnimationSpeed_1;
	float ___m_AnimationStartTime_2;
};

struct Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 
{
	int32_t ___m_X_0;
	int32_t ___m_Y_1;
	int32_t ___m_Z_2;
};

struct Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_StaticFields
{
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Zero_3;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_One_4;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Up_5;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Down_6;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Left_7;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Right_8;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Forward_9;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Back_10;
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

struct SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA 
{
	bool ___hasSyncTileCallback_0;
	bool ___hasPositionsChangedCallback_1;
	bool ___isBufferSyncTile_2;
};
struct SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_pinvoke
{
	int32_t ___hasSyncTileCallback_0;
	int32_t ___hasPositionsChangedCallback_1;
	int32_t ___isBufferSyncTile_2;
};
struct SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_com
{
	int32_t ___hasSyncTileCallback_0;
	int32_t ___hasPositionsChangedCallback_1;
	int32_t ___isBufferSyncTile_2;
};

struct Delegate_t  : public RuntimeObject
{
	Il2CppMethodPointer ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	RuntimeObject* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	bool ___method_is_virtual_12;
};
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

struct Exception_t  : public RuntimeObject
{
	String_t* ____className_1;
	String_t* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t* ____innerException_4;
	String_t* ____helpURL_5;
	RuntimeObject* ____stackTrace_6;
	String_t* ____stackTraceString_7;
	String_t* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	RuntimeObject* ____dynamicMethods_10;
	int32_t ____HResult_11;
	String_t* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};

struct Exception_t_StaticFields
{
	RuntimeObject* ___s_EDILock_0;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};

struct ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164  : public RuntimeObject
{
	Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* ___m_Tilemap_1;
	bool ___m_AddToList_2;
	int32_t ___m_RefreshCount_3;
	NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___m_RefreshPos_4;
};

struct ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_StaticFields
{
	ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___s_Instance_0;
};

struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	intptr_t ___m_CachedPtr_0;
};

struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

struct TileChangeData_t6035410A63723928DB7B86A0880351354ADB635E 
{
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___m_Position_0;
	Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___m_TileAsset_1;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_Color_2;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___m_Transform_3;
};

struct TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F 
{
	int32_t ___m_Sprite_0;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_Color_1;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___m_Transform_2;
	int32_t ___m_GameObject_3;
	int32_t ___m_Flags_4;
	int32_t ___m_ColliderType_5;
};

struct TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_StaticFields
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F ___Default_6;
};

struct TileDataNative_tAD277F2C587DC35577654A4C111ECE2C4114C528 
{
	int32_t ___m_Sprite_0;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_Color_1;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___m_Transform_2;
	int32_t ___m_GameObject_3;
	int32_t ___m_Flags_4;
	int32_t ___m_ColliderType_5;
};

struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

struct MulticastDelegate_t  : public Delegate_t
{
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

struct ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
struct ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A_marshaled_pinvoke : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
};
struct ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A_marshaled_com : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
};

struct Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

struct SpriteAtlas_t7B9620FBFBE1CCB781F2ED24A3B2DD37734F66A8  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

struct SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C 
{
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___m_Position_0;
	TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* ___m_Tile_1;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F ___m_TileData_2;
};
struct SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_pinvoke
{
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___m_Position_0;
	TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* ___m_Tile_1;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F ___m_TileData_2;
};
struct SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_com
{
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___m_Position_0;
	TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* ___m_Tile_1;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F ___m_TileData_2;
};

struct Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D  : public MulticastDelegate_t
{
};

struct Action_2_t0302727DEEDCFCC692E80AEEC31B8066AE8C5550  : public MulticastDelegate_t
{
};

struct Action_2_t156C43F079E7E68155FCDCD12DC77DD11AEF7E3C  : public MulticastDelegate_t
{
};

struct Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2  : public MulticastDelegate_t
{
};

struct Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1  : public MulticastDelegate_t
{
};

struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

struct Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

struct TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9  : public ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A
{
};

struct GridLayout_tAD661B1E1E57C16BE21C8C13432EA04FE1F0418B  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

struct Tile_t33119F106CFC3DC767E7D9306A958AAE12133490  : public TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9
{
	Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___m_Sprite_4;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_Color_5;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___m_Transform_6;
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___m_InstancedGameObject_7;
	int32_t ___m_Flags_8;
	int32_t ___m_ColliderType_9;
};

struct TilemapRenderer_t1A45FD335E86172CFBB77D657E1D6705A477A6CB  : public Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF
{
};

struct Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751  : public GridLayout_tAD661B1E1E57C16BE21C8C13432EA04FE1F0418B
{
	bool ___m_BufferSyncTile_6;
};

struct Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_StaticFields
{
	Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1* ___tilemapTileChanged_4;
	Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2* ___tilemapPositionsChanged_5;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF  : public RuntimeArray
{
	ALIGN_FIELD (8) SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C m_Items[1];

	inline SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->___m_Tile_1), (void*)NULL);
	}
	inline SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->___m_Tile_1), (void*)NULL);
	}
};
struct SpriteU5BU5D_tCEE379E10CAD9DBFA770B331480592548ED0EA1B  : public RuntimeArray
{
	ALIGN_FIELD (8) Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* m_Items[1];

	inline Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2_gshared (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* __this, int32_t ___length0, int32_t ___allocator1, int32_t ___options2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NativeArray_1_Copy_mC012394A9B0A5C70C934A7CB5120B70132781BEE_gshared (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___src0, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___dst1, int32_t ___length2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055_gshared (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NativeArray_1_get_IsCreated_mE992FB4B97CD24CAF70D23773821AE2687DC4A30_gshared (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_gshared (void* ___dataPointer0, int32_t ___length1, int32_t ___allocator2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_gshared (void* ___dataPointer0, int32_t ___length1, int32_t ___allocator2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_t1520D9CD4959D9455C36ED19E490DBDC32B6EF5C NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_m76FF49366AD64B309E424BF955B7C57C1850EAFA_gshared (void* ___dataPointer0, int32_t ___length1, int32_t ___allocator2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_2_Invoke_m7BFCE0BBCF67689D263059B56A8D79161B698587_gshared_inline (Action_2_t156C43F079E7E68155FCDCD12DC77DD11AEF7E3C* __this, RuntimeObject* ___arg10, RuntimeObject* ___arg21, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_2_Invoke_m7B85C2674B1EB0681F20E9C5AF3D19563459CBC0_gshared_inline (Action_2_t0302727DEEDCFCC692E80AEEC31B8066AE8C5550* __this, RuntimeObject* ___arg10, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___arg21, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_1__ctor_m2E1DFA67718FC1A0B6E5DFEB78831FFE9C059EB4_gshared (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Math_Max_m830F00B616D7A2130E46E974DFB27E9DA7FE30E5 (int32_t ___val10, int32_t ___val21, const RuntimeMethod* method) ;
inline void NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2 (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* __this, int32_t ___length0, int32_t ___allocator1, int32_t ___options2, const RuntimeMethod* method)
{
	((  void (*) (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF*, int32_t, int32_t, int32_t, const RuntimeMethod*))NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2_gshared)(__this, ___length0, ___allocator1, ___options2, method);
}
inline void NativeArray_1_Copy_mC012394A9B0A5C70C934A7CB5120B70132781BEE (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___src0, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___dst1, int32_t ___length2, const RuntimeMethod* method)
{
	((  void (*) (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF, int32_t, const RuntimeMethod*))NativeArray_1_Copy_mC012394A9B0A5C70C934A7CB5120B70132781BEE_gshared)(___src0, ___dst1, ___length2, method);
}
inline void NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055 (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* __this, const RuntimeMethod* method)
{
	((  void (*) (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF*, const RuntimeMethod*))NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_RefreshTile_mEF4F94212FD9B311431DFFAFE092A4A6EBA580DF (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ITilemap__ctor_m3281F6903F18F9B867E6B81E18BCCD0828084258 (ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* __this, const RuntimeMethod* method) ;
inline bool NativeArray_1_get_IsCreated_mE992FB4B97CD24CAF70D23773821AE2687DC4A30 (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF*, const RuntimeMethod*))NativeArray_1_get_IsCreated_mE992FB4B97CD24CAF70D23773821AE2687DC4A30_gshared)(__this, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void* IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline (intptr_t* __this, const RuntimeMethod* method) ;
inline NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724 (void* ___dataPointer0, int32_t ___length1, int32_t ___allocator2, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_gshared)(___dataPointer0, ___length1, ___allocator2, method);
}
inline NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45 (void* ___dataPointer0, int32_t ___length1, int32_t ___allocator2, const RuntimeMethod* method)
{
	return ((  NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_gshared)(___dataPointer0, ___length1, ___allocator2, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* Object_ForceLoadFromInstanceID_m061274984A3BC5C4C539D8E7DEE11FE0AD19B40B (int32_t ___instanceID0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_RefreshTilesNative_mD73E77DFD7C808A3665CA8389F728CBC08A52232 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, void* ___positions0, int32_t ___count1, const RuntimeMethod* method) ;
inline NativeArray_1_t1520D9CD4959D9455C36ED19E490DBDC32B6EF5C NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_m76FF49366AD64B309E424BF955B7C57C1850EAFA (void* ___dataPointer0, int32_t ___length1, int32_t ___allocator2, const RuntimeMethod* method)
{
	return ((  NativeArray_1_t1520D9CD4959D9455C36ED19E490DBDC32B6EF5C (*) (void*, int32_t, int32_t, const RuntimeMethod*))NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_m76FF49366AD64B309E424BF955B7C57C1850EAFA_gshared)(___dataPointer0, ___length1, ___allocator2, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_sprite_m3566544847F9C9C27EDB154324B6FBDB446EFE94 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_color_m5E759823878243A226EF46419FAD7C0CC3D5F40A (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_transform_m71074A780C066292F940002A7165658E9CC01F9F (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_gameObject_m1CE5B2AAAB5BF5AEF36EBAF2BCE23E4D2E5A9E09 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_flags_mEB46B1364D6DB7F77C2E1E43AFD31381B291BD30 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, int32_t ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_colliderType_mE12359ADEF5F42CC0B635DCBAEC3035F0526FA96 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, int32_t ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Color_get_white_m28BB6E19F27D4EE6858D3021A44F62BC74E20C43_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_get_identity_m94A09872C449C26863FF10D0FDF87842D91BECD6_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileBase__ctor_mBFD0A0ACF9DB1F08783B9F3F35D4E61C9205D4A2 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ITilemap_RefreshTile_m4C4B0A062A13E986BD20AA87F056982D67FAF69D (ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ScriptableObject__ctor_mD037FDB0B487295EA47F79A4DB1BF1846C9087FF (ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_SendTilemapTileChangedCallback_m66E5D12B134C48E57EF4C1B29658CD61B75366EF (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* ___syncTiles0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_SendTilemapPositionsChangedCallback_m8F1D0E0F18A797349A83465F5E68DF01972D75D4 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___positions0, const RuntimeMethod* method) ;
inline void Action_2_Invoke_m66A9645921ABEA3CFC0BB0DB828D756440BDF41D_inline (Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1* __this, Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* ___arg10, SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* ___arg21, const RuntimeMethod* method)
{
	((  void (*) (Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1*, Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751*, SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF*, const RuntimeMethod*))Action_2_Invoke_m7BFCE0BBCF67689D263059B56A8D79161B698587_gshared_inline)(__this, ___arg10, ___arg21, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogException_m6A7A404239B24E1C7CA358508923F47ABDF40D05 (Exception_t* ___exception0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___context1, const RuntimeMethod* method) ;
inline void Action_2_Invoke_m63AB8CDF184F8712FFDF64CD49CFAFF2FC9DF03D_inline (Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2* __this, Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* ___arg10, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___arg21, const RuntimeMethod* method)
{
	((  void (*) (Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2*, Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751*, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF, const RuntimeMethod*))Action_2_Invoke_m7B85C2674B1EB0681F20E9C5AF3D19563459CBC0_gshared_inline)(__this, ___arg10, ___arg21, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_RefreshTile_Injected_m99F1EC3F340590E282B01EC7C96F1F8D1BA03A69 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___position0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Tilemap_HasSyncTileCallback_mFA857D01EE281E4B09A3FB075B2E202020009FED (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Tilemap_HasPositionsChangedCallback_m0DC2724F4ACD2E248C2F226B3C8C5422C600A5E9 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Tilemap_get_bufferSyncTile_m5506F240CC262FD454CFF9B547F16530F9506B1D (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_HandleSyncTileCallback_mF1D8059E6F8ED90041313259D5DCFC3DBEB8750A (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* ___syncTiles0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_HandlePositionsChangedCallback_mCEC3B01A5328F6C83163C25CE9EDCD87E5895CD0 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, int32_t ___count0, intptr_t ___positionsIntPtr1, const RuntimeMethod* method) ;
inline void Action_1__ctor_mDAEB7161DF624FDF6A3DA3C6BE40319FFC05A2E3 (Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D*, RuntimeObject*, intptr_t, const RuntimeMethod*))Action_1__ctor_m2E1DFA67718FC1A0B6E5DFEB78831FFE9C059EB4_gshared)(__this, ___object0, ___method1, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SpriteAtlasManager_add_atlasRegistered_mF83F3AEB343B2111048330DCBBC25688B5F5F7AD (Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D* ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SpriteAtlasManager_remove_atlasRegistered_m606C351B26C01824C922ACF29708D85F35072E9F (Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D* ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Object_GetInstanceID_m554FF4073C9465F3835574CC084E68AAEEC6CC6A (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F TileData_CreateDefault_m4E44C661D13D791B4CBB2024970E4BE662ACCB57 (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___r0, float ___g1, float ___b2, float ___a3, const RuntimeMethod* method) ;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ITilemap__ctor_m3281F6903F18F9B867E6B81E18BCCD0828084258 (ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ITilemap_RefreshTile_m4C4B0A062A13E986BD20AA87F056982D67FAF69D (ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArray_1_Copy_mC012394A9B0A5C70C934A7CB5120B70132781BEE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF V_2;
	memset((&V_2), 0, sizeof(V_2));
	int32_t V_3 = 0;
	{
		bool L_0 = __this->___m_AddToList_2;
		V_0 = L_0;
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_008e;
		}
	}
	{
		int32_t L_2 = __this->___m_RefreshCount_3;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_3 = (&__this->___m_RefreshPos_4);
		int32_t L_4;
		L_4 = IL2CPP_NATIVEARRAY_GET_LENGTH((L_3)->___m_Length_1);
		V_1 = (bool)((((int32_t)((((int32_t)L_2) < ((int32_t)L_4))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_006d;
		}
	}
	{
		int32_t L_6 = __this->___m_RefreshCount_3;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		int32_t L_7;
		L_7 = Math_Max_m830F00B616D7A2130E46E974DFB27E9DA7FE30E5(1, ((int32_t)il2cpp_codegen_multiply(L_6, 2)), NULL);
		NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2((&V_2), L_7, 2, 1, NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2_RuntimeMethod_var);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_8 = __this->___m_RefreshPos_4;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_9 = V_2;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_10 = (&__this->___m_RefreshPos_4);
		int32_t L_11;
		L_11 = IL2CPP_NATIVEARRAY_GET_LENGTH((L_10)->___m_Length_1);
		NativeArray_1_Copy_mC012394A9B0A5C70C934A7CB5120B70132781BEE(L_8, L_9, L_11, NativeArray_1_Copy_mC012394A9B0A5C70C934A7CB5120B70132781BEE_RuntimeMethod_var);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_12 = (&__this->___m_RefreshPos_4);
		NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055(L_12, NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055_RuntimeMethod_var);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_13 = V_2;
		__this->___m_RefreshPos_4 = L_13;
	}

IL_006d:
	{
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_14 = (&__this->___m_RefreshPos_4);
		int32_t L_15 = __this->___m_RefreshCount_3;
		V_3 = L_15;
		int32_t L_16 = V_3;
		__this->___m_RefreshCount_3 = ((int32_t)il2cpp_codegen_add(L_16, 1));
		int32_t L_17 = V_3;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_18 = ___position0;
		IL2CPP_NATIVEARRAY_SET_ITEM(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, (L_14)->___m_Buffer_0, L_17, (L_18));
		goto IL_009b;
	}

IL_008e:
	{
		Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* L_19 = __this->___m_Tilemap_1;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_20 = ___position0;
		NullCheck(L_19);
		Tilemap_RefreshTile_mEF4F94212FD9B311431DFFAFE092A4A6EBA580DF(L_19, L_20, NULL);
	}

IL_009b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ITilemap_CreateInstance_mDAA1BDC39A1CFB4D7BB0571F1435438D1153C5E8 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* V_0 = NULL;
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_0 = (ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164*)il2cpp_codegen_object_new(ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		ITilemap__ctor_m3281F6903F18F9B867E6B81E18BCCD0828084258(L_0, NULL);
		((ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_StaticFields*)il2cpp_codegen_static_fields_for(ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_il2cpp_TypeInfo_var))->___s_Instance_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_StaticFields*)il2cpp_codegen_static_fields_for(ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_il2cpp_TypeInfo_var))->___s_Instance_0), (void*)L_0);
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_1 = ((ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_StaticFields*)il2cpp_codegen_static_fields_for(ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164_il2cpp_TypeInfo_var))->___s_Instance_0;
		V_0 = L_1;
		goto IL_0013;
	}

IL_0013:
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ITilemap_FindAllRefreshPositions_mBEB4F6C23D62051C27C3AC3BFE9F6DD4A721D1B0 (ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap0, int32_t ___count1, intptr_t ___oldTilesIntPtr2, intptr_t ___newTilesIntPtr3, intptr_t ___positionsIntPtr4, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArray_1_get_IsCreated_mE992FB4B97CD24CAF70D23773821AE2687DC4A30_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void* V_0 = NULL;
	void* V_1 = NULL;
	void* V_2 = NULL;
	NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C V_3;
	memset((&V_3), 0, sizeof(V_3));
	NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C V_4;
	memset((&V_4), 0, sizeof(V_4));
	NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF V_5;
	memset((&V_5), 0, sizeof(V_5));
	bool V_6 = false;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 V_10;
	memset((&V_10), 0, sizeof(V_10));
	bool V_11 = false;
	TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* V_12 = NULL;
	bool V_13 = false;
	TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* V_14 = NULL;
	bool V_15 = false;
	int32_t G_B3_0 = 0;
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_0 = ___tilemap0;
		NullCheck(L_0);
		L_0->___m_AddToList_2 = (bool)1;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_1 = ___tilemap0;
		NullCheck(L_1);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_2 = L_1->___m_RefreshPos_4;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_3 = ___tilemap0;
		NullCheck(L_3);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_4 = (&L_3->___m_RefreshPos_4);
		bool L_5;
		L_5 = NativeArray_1_get_IsCreated_mE992FB4B97CD24CAF70D23773821AE2687DC4A30(L_4, NativeArray_1_get_IsCreated_mE992FB4B97CD24CAF70D23773821AE2687DC4A30_RuntimeMethod_var);
		if (!L_5)
		{
			goto IL_002c;
		}
	}
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_6 = ___tilemap0;
		NullCheck(L_6);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_7 = (&L_6->___m_RefreshPos_4);
		int32_t L_8;
		L_8 = IL2CPP_NATIVEARRAY_GET_LENGTH((L_7)->___m_Length_1);
		int32_t L_9 = ___count1;
		G_B3_0 = ((((int32_t)L_8) < ((int32_t)L_9))? 1 : 0);
		goto IL_002d;
	}

IL_002c:
	{
		G_B3_0 = 1;
	}

IL_002d:
	{
		V_6 = (bool)G_B3_0;
		bool L_10 = V_6;
		if (!L_10)
		{
			goto IL_0048;
		}
	}
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_11 = ___tilemap0;
		int32_t L_12 = ___count1;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		int32_t L_13;
		L_13 = Math_Max_m830F00B616D7A2130E46E974DFB27E9DA7FE30E5(((int32_t)16), L_12, NULL);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_14;
		memset((&L_14), 0, sizeof(L_14));
		NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2((&L_14), L_13, 2, 1, NativeArray_1__ctor_m29DAD3F6139353D219E363E2C63BC183CBC778E2_RuntimeMethod_var);
		NullCheck(L_11);
		L_11->___m_RefreshPos_4 = L_14;
	}

IL_0048:
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_15 = ___tilemap0;
		NullCheck(L_15);
		L_15->___m_RefreshCount_3 = 0;
		void* L_16;
		L_16 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline((&___oldTilesIntPtr2), NULL);
		V_0 = L_16;
		void* L_17;
		L_17 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline((&___newTilesIntPtr3), NULL);
		V_1 = L_17;
		void* L_18;
		L_18 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline((&___positionsIntPtr4), NULL);
		V_2 = L_18;
		void* L_19 = V_0;
		int32_t L_20 = ___count1;
		NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C L_21;
		L_21 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724(L_19, L_20, 0, NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_RuntimeMethod_var);
		V_3 = L_21;
		void* L_22 = V_1;
		int32_t L_23 = ___count1;
		NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C L_24;
		L_24 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724(L_22, L_23, 0, NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_RuntimeMethod_var);
		V_4 = L_24;
		void* L_25 = V_2;
		int32_t L_26 = ___count1;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_27;
		L_27 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45(L_25, L_26, 0, NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_RuntimeMethod_var);
		V_5 = L_27;
		V_7 = 0;
		goto IL_00fe;
	}

IL_0089:
	{
		int32_t L_28 = V_7;
		int32_t L_29;
		L_29 = IL2CPP_NATIVEARRAY_GET_ITEM(int32_t, ((&V_3))->___m_Buffer_0, L_28);
		V_8 = L_29;
		int32_t L_30 = V_7;
		int32_t L_31;
		L_31 = IL2CPP_NATIVEARRAY_GET_ITEM(int32_t, ((&V_4))->___m_Buffer_0, L_30);
		V_9 = L_31;
		int32_t L_32 = V_7;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_33;
		L_33 = IL2CPP_NATIVEARRAY_GET_ITEM(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ((&V_5))->___m_Buffer_0, L_32);
		V_10 = L_33;
		int32_t L_34 = V_8;
		V_11 = (bool)((!(((uint32_t)L_34) <= ((uint32_t)0)))? 1 : 0);
		bool L_35 = V_11;
		if (!L_35)
		{
			goto IL_00d1;
		}
	}
	{
		int32_t L_36 = V_8;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_37;
		L_37 = Object_ForceLoadFromInstanceID_m061274984A3BC5C4C539D8E7DEE11FE0AD19B40B(L_36, NULL);
		V_12 = ((TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9*)CastclassClass((RuntimeObject*)L_37, TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9_il2cpp_TypeInfo_var));
		TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* L_38 = V_12;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_39 = V_10;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_40 = ___tilemap0;
		NullCheck(L_38);
		VirtualActionInvoker2< Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* >::Invoke(4, L_38, L_39, L_40);
	}

IL_00d1:
	{
		int32_t L_41 = V_9;
		V_13 = (bool)((!(((uint32_t)L_41) <= ((uint32_t)0)))? 1 : 0);
		bool L_42 = V_13;
		if (!L_42)
		{
			goto IL_00f7;
		}
	}
	{
		int32_t L_43 = V_9;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_44;
		L_44 = Object_ForceLoadFromInstanceID_m061274984A3BC5C4C539D8E7DEE11FE0AD19B40B(L_43, NULL);
		V_14 = ((TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9*)CastclassClass((RuntimeObject*)L_44, TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9_il2cpp_TypeInfo_var));
		TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* L_45 = V_14;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_46 = V_10;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_47 = ___tilemap0;
		NullCheck(L_45);
		VirtualActionInvoker2< Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* >::Invoke(4, L_45, L_46, L_47);
	}

IL_00f7:
	{
		int32_t L_48 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_48, 1));
	}

IL_00fe:
	{
		int32_t L_49 = V_7;
		int32_t L_50 = ___count1;
		V_15 = (bool)((((int32_t)L_49) < ((int32_t)L_50))? 1 : 0);
		bool L_51 = V_15;
		if (L_51)
		{
			goto IL_0089;
		}
	}
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_52 = ___tilemap0;
		NullCheck(L_52);
		Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* L_53 = L_52->___m_Tilemap_1;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_54 = ___tilemap0;
		NullCheck(L_54);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_55 = (&L_54->___m_RefreshPos_4);
		void* L_56 = L_55->___m_Buffer_0;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_57 = ___tilemap0;
		NullCheck(L_57);
		int32_t L_58 = L_57->___m_RefreshCount_3;
		NullCheck(L_53);
		Tilemap_RefreshTilesNative_mD73E77DFD7C808A3665CA8389F728CBC08A52232(L_53, L_56, L_58, NULL);
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_59 = ___tilemap0;
		NullCheck(L_59);
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF* L_60 = (&L_59->___m_RefreshPos_4);
		NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055(L_60, NativeArray_1_Dispose_mAB8B3AE6332BF29F21711643D4FFE57E30E1E055_RuntimeMethod_var);
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_61 = ___tilemap0;
		NullCheck(L_61);
		L_61->___m_AddToList_2 = (bool)0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ITilemap_GetAllTileData_mE382469F5C175A89CF0FD451914188814A876B86 (ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap0, int32_t ___count1, intptr_t ___tilesIntPtr2, intptr_t ___positionsIntPtr3, intptr_t ___outTileDataIntPtr4, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_m76FF49366AD64B309E424BF955B7C57C1850EAFA_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void* V_0 = NULL;
	void* V_1 = NULL;
	void* V_2 = NULL;
	NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C V_3;
	memset((&V_3), 0, sizeof(V_3));
	NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF V_4;
	memset((&V_4), 0, sizeof(V_4));
	NativeArray_1_t1520D9CD4959D9455C36ED19E490DBDC32B6EF5C V_5;
	memset((&V_5), 0, sizeof(V_5));
	int32_t V_6 = 0;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F V_7;
	memset((&V_7), 0, sizeof(V_7));
	int32_t V_8 = 0;
	bool V_9 = false;
	TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* V_10 = NULL;
	bool V_11 = false;
	{
		void* L_0;
		L_0 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline((&___tilesIntPtr2), NULL);
		V_0 = L_0;
		void* L_1;
		L_1 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline((&___positionsIntPtr3), NULL);
		V_1 = L_1;
		void* L_2;
		L_2 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline((&___outTileDataIntPtr4), NULL);
		V_2 = L_2;
		void* L_3 = V_0;
		int32_t L_4 = ___count1;
		NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C L_5;
		L_5 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724(L_3, L_4, 0, NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m3ACF6A1E47D345E814CEF2BDAD94A21A8AE66724_RuntimeMethod_var);
		V_3 = L_5;
		void* L_6 = V_1;
		int32_t L_7 = ___count1;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_8;
		L_8 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45(L_6, L_7, 0, NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_RuntimeMethod_var);
		V_4 = L_8;
		void* L_9 = V_2;
		int32_t L_10 = ___count1;
		NativeArray_1_t1520D9CD4959D9455C36ED19E490DBDC32B6EF5C L_11;
		L_11 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_m76FF49366AD64B309E424BF955B7C57C1850EAFA(L_9, L_10, 0, NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisTileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_m76FF49366AD64B309E424BF955B7C57C1850EAFA_RuntimeMethod_var);
		V_5 = L_11;
		V_6 = 0;
		goto IL_0090;
	}

IL_003b:
	{
		il2cpp_codegen_runtime_class_init_inline(TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_il2cpp_TypeInfo_var);
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F L_12 = ((TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_StaticFields*)il2cpp_codegen_static_fields_for(TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_il2cpp_TypeInfo_var))->___Default_6;
		V_7 = L_12;
		int32_t L_13 = V_6;
		int32_t L_14;
		L_14 = IL2CPP_NATIVEARRAY_GET_ITEM(int32_t, ((&V_3))->___m_Buffer_0, L_13);
		V_8 = L_14;
		int32_t L_15 = V_8;
		V_9 = (bool)((!(((uint32_t)L_15) <= ((uint32_t)0)))? 1 : 0);
		bool L_16 = V_9;
		if (!L_16)
		{
			goto IL_007d;
		}
	}
	{
		int32_t L_17 = V_8;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_18;
		L_18 = Object_ForceLoadFromInstanceID_m061274984A3BC5C4C539D8E7DEE11FE0AD19B40B(L_17, NULL);
		V_10 = ((TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9*)CastclassClass((RuntimeObject*)L_18, TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9_il2cpp_TypeInfo_var));
		TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* L_19 = V_10;
		int32_t L_20 = V_6;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_21;
		L_21 = IL2CPP_NATIVEARRAY_GET_ITEM(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ((&V_4))->___m_Buffer_0, L_20);
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_22 = ___tilemap0;
		NullCheck(L_19);
		VirtualActionInvoker3< Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164*, TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* >::Invoke(5, L_19, L_21, L_22, (&V_7));
	}

IL_007d:
	{
		int32_t L_23 = V_6;
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F L_24 = V_7;
		IL2CPP_NATIVEARRAY_SET_ITEM(TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F, ((&V_5))->___m_Buffer_0, L_23, (L_24));
		int32_t L_25 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add(L_25, 1));
	}

IL_0090:
	{
		int32_t L_26 = V_6;
		int32_t L_27 = ___count1;
		V_11 = (bool)((((int32_t)L_26) < ((int32_t)L_27))? 1 : 0);
		bool L_28 = V_11;
		if (L_28)
		{
			goto IL_003b;
		}
	}
	{
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* Tile_get_sprite_m3324CBA00505C3C95DA57FC3A6F8B0D5FA2EF553 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, const RuntimeMethod* method) 
{
	Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* V_0 = NULL;
	{
		Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* L_0 = __this->___m_Sprite_4;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile_set_sprite_mD9F351775FDFDFFA0FCC40121B4C54D566052D18 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___value0, const RuntimeMethod* method) 
{
	{
		Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* L_0 = ___value0;
		__this->___m_Sprite_4 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_Sprite_4), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Tile_get_color_mD50E790F486A1E64757E9471D48BA42FC9ECCE4C (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = __this->___m_Color_5;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile_set_color_m9D76C21865CA89F39FF56C112CB13AFD45CD8B69 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___value0, const RuntimeMethod* method) 
{
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = ___value0;
		__this->___m_Color_5 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Tile_get_transform_mFA119A0C353E4E75C92C8BE829C6BDFA40F17643 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, const RuntimeMethod* method) 
{
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = __this->___m_Transform_6;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile_set_transform_m2E46927D29823DBDC3B7B36E013845006075EB02 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = ___value0;
		__this->___m_Transform_6 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* Tile_get_gameObject_m8B1B09FD1B6B5A0402D63D3AFF139C6078754077 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, const RuntimeMethod* method) 
{
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* V_0 = NULL;
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0 = __this->___m_InstancedGameObject_7;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile_set_gameObject_mD4C82AFCA4B96D44BE5549CFF9E0F36218A4ECE9 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___value0, const RuntimeMethod* method) 
{
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0 = ___value0;
		__this->___m_InstancedGameObject_7 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_InstancedGameObject_7), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Tile_get_flags_m4AC2E9F8CF43DB83E9F8389EFDF7E6111E5A9806 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->___m_Flags_8;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile_set_flags_mE221D85F2B767EC5C3D473266CB7AABD66674DEA (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___value0;
		__this->___m_Flags_8 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Tile_get_colliderType_mDB7A2E3BEF055617F6AC198841938B79C289E967 (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->___m_ColliderType_9;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile_set_colliderType_m21E434F55E4CC8AEB867E7FCF88821EFFC9CEB3F (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___value0;
		__this->___m_ColliderType_9 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile_GetTileData_m187B4A0A655AAB70CC8EC203F78E4777ABB96D4E (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* ___tileData2, const RuntimeMethod* method) 
{
	{
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* L_0 = ___tileData2;
		Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* L_1 = __this->___m_Sprite_4;
		TileData_set_sprite_m3566544847F9C9C27EDB154324B6FBDB446EFE94(L_0, L_1, NULL);
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* L_2 = ___tileData2;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_3 = __this->___m_Color_5;
		TileData_set_color_m5E759823878243A226EF46419FAD7C0CC3D5F40A(L_2, L_3, NULL);
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* L_4 = ___tileData2;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_5 = __this->___m_Transform_6;
		TileData_set_transform_m71074A780C066292F940002A7165658E9CC01F9F(L_4, L_5, NULL);
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* L_6 = ___tileData2;
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_7 = __this->___m_InstancedGameObject_7;
		TileData_set_gameObject_m1CE5B2AAAB5BF5AEF36EBAF2BCE23E4D2E5A9E09(L_6, L_7, NULL);
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* L_8 = ___tileData2;
		int32_t L_9 = __this->___m_Flags_8;
		TileData_set_flags_mEB46B1364D6DB7F77C2E1E43AFD31381B291BD30(L_8, L_9, NULL);
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* L_10 = ___tileData2;
		int32_t L_11 = __this->___m_ColliderType_9;
		TileData_set_colliderType_mE12359ADEF5F42CC0B635DCBAEC3035F0526FA96(L_10, L_11, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tile__ctor_m1680C25E80E5ACCB156133C14199BD5BFE00EA5E (Tile_t33119F106CFC3DC767E7D9306A958AAE12133490* __this, const RuntimeMethod* method) 
{
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0;
		L_0 = Color_get_white_m28BB6E19F27D4EE6858D3021A44F62BC74E20C43_inline(NULL);
		__this->___m_Color_5 = L_0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_1;
		L_1 = Matrix4x4_get_identity_m94A09872C449C26863FF10D0FDF87842D91BECD6_inline(NULL);
		__this->___m_Transform_6 = L_1;
		__this->___m_Flags_8 = 1;
		__this->___m_ColliderType_9 = 1;
		TileBase__ctor_mBFD0A0ACF9DB1F08783B9F3F35D4E61C9205D4A2(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileBase_RefreshTile_m7302220B588658247D635871B92DBFF7708E2224 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, const RuntimeMethod* method) 
{
	{
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_0 = ___tilemap1;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_1 = ___position0;
		NullCheck(L_0);
		ITilemap_RefreshTile_m4C4B0A062A13E986BD20AA87F056982D67FAF69D(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileBase_GetTileData_m04B3B474F4DBF88997FF29ABA115A2FFB91BAF81 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* ___tileData2, const RuntimeMethod* method) 
{
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F TileBase_GetTileDataNoRef_m657510B6853906E397D8FC7E6F1A8B2DC4B34397 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, const RuntimeMethod* method) 
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F V_0;
	memset((&V_0), 0, sizeof(V_0));
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F));
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_0 = ___position0;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_1 = ___tilemap1;
		VirtualActionInvoker3< Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164*, TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* >::Invoke(5, __this, L_0, L_1, (&V_0));
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F L_2 = V_0;
		V_1 = L_2;
		goto IL_0018;
	}

IL_0018:
	{
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F L_3 = V_1;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TileBase_GetTileAnimationData_m8E1C84B8BC0B38E978ECEE6C7AD50D7D8BF810FE (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149* ___tileAnimationData2, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		V_0 = (bool)0;
		goto IL_0005;
	}

IL_0005:
	{
		bool L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149 TileBase_GetTileAnimationDataNoRef_m061D2FB92E28E5C2379385827F78C22719287D97 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, const RuntimeMethod* method) 
{
	TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149 V_0;
	memset((&V_0), 0, sizeof(V_0));
	TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149 V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149));
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_0 = ___position0;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_1 = ___tilemap1;
		bool L_2;
		L_2 = VirtualFuncInvoker3< bool, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164*, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149* >::Invoke(6, __this, L_0, L_1, (&V_0));
		TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149 L_3 = V_0;
		V_1 = L_3;
		goto IL_0018;
	}

IL_0018:
	{
		TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149 L_4 = V_1;
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileBase_GetTileAnimationDataRef_m10D856F55369986224F166E8EEF5633EB8EBA5C3 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149* ___tileAnimationData2, bool* ___hasAnimation3, const RuntimeMethod* method) 
{
	{
		bool* L_0 = ___hasAnimation3;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_1 = ___position0;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_2 = ___tilemap1;
		TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149* L_3 = ___tileAnimationData2;
		bool L_4;
		L_4 = VirtualFuncInvoker3< bool, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164*, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149* >::Invoke(6, __this, L_1, L_2, L_3);
		*((int8_t*)L_0) = (int8_t)L_4;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TileBase_StartUp_mBAF37DBB4DCC7BDB384352D93AB609CEB0E2E78B (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___go2, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		V_0 = (bool)0;
		goto IL_0005;
	}

IL_0005:
	{
		bool L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileBase_StartUpRef_mB00DB38868F87645811DE4784F57278388FAEEF9 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* ___tilemap1, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___go2, bool* ___startUpInvokedByUser3, const RuntimeMethod* method) 
{
	{
		bool* L_0 = ___startUpInvokedByUser3;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_1 = ___position0;
		ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164* L_2 = ___tilemap1;
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_3 = ___go2;
		bool L_4;
		L_4 = VirtualFuncInvoker3< bool, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376, ITilemap_tCD8B9C2D6A80DB1DFE9C934D91EACE6B8A018164*, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* >::Invoke(7, __this, L_1, L_2, L_3);
		*((int8_t*)L_0) = (int8_t)L_4;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileBase__ctor_mBFD0A0ACF9DB1F08783B9F3F35D4E61C9205D4A2 (TileBase_t07019BD771D35E8EA68118157D6EEE4C770CF0F9* __this, const RuntimeMethod* method) 
{
	{
		ScriptableObject__ctor_mD037FDB0B487295EA47F79A4DB1BF1846C9087FF(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Tilemap_get_bufferSyncTile_m5506F240CC262FD454CFF9B547F16530F9506B1D (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		bool L_0 = __this->___m_BufferSyncTile_6;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Tilemap_HasSyncTileCallback_mFA857D01EE281E4B09A3FB075B2E202020009FED (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1* L_0 = ((Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_StaticFields*)il2cpp_codegen_static_fields_for(Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var))->___tilemapTileChanged_4;
		V_0 = (bool)((!(((RuntimeObject*)(Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		goto IL_000c;
	}

IL_000c:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Tilemap_HasPositionsChangedCallback_m0DC2724F4ACD2E248C2F226B3C8C5422C600A5E9 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2* L_0 = ((Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_StaticFields*)il2cpp_codegen_static_fields_for(Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var))->___tilemapPositionsChanged_5;
		V_0 = (bool)((!(((RuntimeObject*)(Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		goto IL_000c;
	}

IL_000c:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_HandleSyncTileCallback_mF1D8059E6F8ED90041313259D5DCFC3DBEB8750A (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* ___syncTiles0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1* L_0 = ((Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_StaticFields*)il2cpp_codegen_static_fields_for(Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var))->___tilemapTileChanged_4;
		V_0 = (bool)((((RuntimeObject*)(Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_000f;
		}
	}
	{
		goto IL_0017;
	}

IL_000f:
	{
		SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* L_2 = ___syncTiles0;
		Tilemap_SendTilemapTileChangedCallback_m66E5D12B134C48E57EF4C1B29658CD61B75366EF(__this, L_2, NULL);
	}

IL_0017:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_HandlePositionsChangedCallback_mCEC3B01A5328F6C83163C25CE9EDCD87E5895CD0 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, int32_t ___count0, intptr_t ___positionsIntPtr1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void* V_0 = NULL;
	NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	{
		Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2* L_0 = ((Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_StaticFields*)il2cpp_codegen_static_fields_for(Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var))->___tilemapPositionsChanged_5;
		V_2 = (bool)((((RuntimeObject*)(Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_2;
		if (!L_1)
		{
			goto IL_000f;
		}
	}
	{
		goto IL_0028;
	}

IL_000f:
	{
		void* L_2;
		L_2 = IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline((&___positionsIntPtr1), NULL);
		V_0 = L_2;
		void* L_3 = V_0;
		int32_t L_4 = ___count0;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_5;
		L_5 = NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45(L_3, L_4, 0, NativeArrayUnsafeUtility_ConvertExistingDataToNativeArray_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m54B7956CC2EDB812766DCB8671D1995500436C45_RuntimeMethod_var);
		V_1 = L_5;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_6 = V_1;
		Tilemap_SendTilemapPositionsChangedCallback_m8F1D0E0F18A797349A83465F5E68DF01972D75D4(__this, L_6, NULL);
	}

IL_0028:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_SendTilemapTileChangedCallback_m66E5D12B134C48E57EF4C1B29658CD61B75366EF (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* ___syncTiles0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Exception_t* V_0 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
	}
	try
	{
		Action_2_t2E142A840461CBB0D9C4B088F1310607E995A8A1* L_0 = ((Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_StaticFields*)il2cpp_codegen_static_fields_for(Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var))->___tilemapTileChanged_4;
		SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* L_1 = ___syncTiles0;
		NullCheck(L_0);
		Action_2_Invoke_m66A9645921ABEA3CFC0BB0DB828D756440BDF41D_inline(L_0, __this, L_1, NULL);
		goto IL_001f;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0012;
		}
		throw e;
	}

CATCH_0012:
	{
		V_0 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
		Exception_t* L_2 = V_0;
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var)));
		Debug_LogException_m6A7A404239B24E1C7CA358508923F47ABDF40D05(L_2, __this, NULL);
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_001f;
	}

IL_001f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_SendTilemapPositionsChangedCallback_m8F1D0E0F18A797349A83465F5E68DF01972D75D4 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___positions0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Exception_t* V_0 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
	}
	try
	{
		Action_2_tC05151F65CF4D95A1C7A5EE21DFEE184110056B2* L_0 = ((Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_StaticFields*)il2cpp_codegen_static_fields_for(Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751_il2cpp_TypeInfo_var))->___tilemapPositionsChanged_5;
		NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF L_1 = ___positions0;
		NullCheck(L_0);
		Action_2_Invoke_m63AB8CDF184F8712FFDF64CD49CFAFF2FC9DF03D_inline(L_0, __this, L_1, NULL);
		goto IL_001f;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0012;
		}
		throw e;
	}

CATCH_0012:
	{
		V_0 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
		Exception_t* L_2 = V_0;
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var)));
		Debug_LogException_m6A7A404239B24E1C7CA358508923F47ABDF40D05(L_2, __this, NULL);
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_001f;
	}

IL_001f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_RefreshTile_mEF4F94212FD9B311431DFFAFE092A4A6EBA580DF (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___position0, const RuntimeMethod* method) 
{
	{
		Tilemap_RefreshTile_Injected_m99F1EC3F340590E282B01EC7C96F1F8D1BA03A69(__this, (&___position0), NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_RefreshTilesNative_mD73E77DFD7C808A3665CA8389F728CBC08A52232 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, void* ___positions0, int32_t ___count1, const RuntimeMethod* method) 
{
	typedef void (*Tilemap_RefreshTilesNative_mD73E77DFD7C808A3665CA8389F728CBC08A52232_ftn) (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751*, void*, int32_t);
	static Tilemap_RefreshTilesNative_mD73E77DFD7C808A3665CA8389F728CBC08A52232_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Tilemap_RefreshTilesNative_mD73E77DFD7C808A3665CA8389F728CBC08A52232_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Tilemaps.Tilemap::RefreshTilesNative(System.Void*,System.Int32)");
	_il2cpp_icall_func(__this, ___positions0, ___count1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_GetSyncTileCallbackSettings_m1630BBFA37F85D2E29E73EA92DB13C700CC86B29 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA* ___settings0, const RuntimeMethod* method) 
{
	{
		SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA* L_0 = ___settings0;
		bool L_1;
		L_1 = Tilemap_HasSyncTileCallback_mFA857D01EE281E4B09A3FB075B2E202020009FED(NULL);
		L_0->___hasSyncTileCallback_0 = L_1;
		SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA* L_2 = ___settings0;
		bool L_3;
		L_3 = Tilemap_HasPositionsChangedCallback_m0DC2724F4ACD2E248C2F226B3C8C5422C600A5E9(NULL);
		L_2->___hasPositionsChangedCallback_1 = L_3;
		SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA* L_4 = ___settings0;
		bool L_5;
		L_5 = Tilemap_get_bufferSyncTile_m5506F240CC262FD454CFF9B547F16530F9506B1D(__this, NULL);
		L_4->___isBufferSyncTile_2 = L_5;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_DoSyncTileCallback_m7BF07E7C678E7A55BDF116FA7C5BEF29963402A2 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* ___syncTiles0, const RuntimeMethod* method) 
{
	{
		SyncTileU5BU5D_t9B4B242D002401F11525388BC75BDAB6A45714FF* L_0 = ___syncTiles0;
		Tilemap_HandleSyncTileCallback_mF1D8059E6F8ED90041313259D5DCFC3DBEB8750A(__this, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_DoPositionsChangedCallback_mCD3C79A37783BB7DD22454981E0B51394B7990F4 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, int32_t ___count0, intptr_t ___positionsIntPtr1, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___count0;
		intptr_t L_1 = ___positionsIntPtr1;
		Tilemap_HandlePositionsChangedCallback_mCEC3B01A5328F6C83163C25CE9EDCD87E5895CD0(__this, L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Tilemap_RefreshTile_Injected_m99F1EC3F340590E282B01EC7C96F1F8D1BA03A69 (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751* __this, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___position0, const RuntimeMethod* method) 
{
	typedef void (*Tilemap_RefreshTile_Injected_m99F1EC3F340590E282B01EC7C96F1F8D1BA03A69_ftn) (Tilemap_t18C4166D0AC702D5BFC0C411FA73C4B61D9D1751*, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*);
	static Tilemap_RefreshTile_Injected_m99F1EC3F340590E282B01EC7C96F1F8D1BA03A69_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Tilemap_RefreshTile_Injected_m99F1EC3F340590E282B01EC7C96F1F8D1BA03A69_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Tilemaps.Tilemap::RefreshTile_Injected(UnityEngine.Vector3Int&)");
	_il2cpp_icall_func(__this, ___position0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshal_pinvoke(const SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C& unmarshaled, SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_Tile_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Tile' of type 'SyncTile': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Tile_1Exception, NULL);
}
IL2CPP_EXTERN_C void SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshal_pinvoke_back(const SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_pinvoke& marshaled, SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C& unmarshaled)
{
	Exception_t* ___m_Tile_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Tile' of type 'SyncTile': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Tile_1Exception, NULL);
}
IL2CPP_EXTERN_C void SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshal_pinvoke_cleanup(SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_pinvoke& marshaled)
{
}
IL2CPP_EXTERN_C void SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshal_com(const SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C& unmarshaled, SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_com& marshaled)
{
	Exception_t* ___m_Tile_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Tile' of type 'SyncTile': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Tile_1Exception, NULL);
}
IL2CPP_EXTERN_C void SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshal_com_back(const SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_com& marshaled, SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C& unmarshaled)
{
	Exception_t* ___m_Tile_1Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_Tile' of type 'SyncTile': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_Tile_1Exception, NULL);
}
IL2CPP_EXTERN_C void SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshal_com_cleanup(SyncTile_t0F06ED3A2623F91411C6F4773D87AB58EAD4EC2C_marshaled_com& marshaled)
{
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshal_pinvoke(const SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA& unmarshaled, SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_pinvoke& marshaled)
{
	marshaled.___hasSyncTileCallback_0 = static_cast<int32_t>(unmarshaled.___hasSyncTileCallback_0);
	marshaled.___hasPositionsChangedCallback_1 = static_cast<int32_t>(unmarshaled.___hasPositionsChangedCallback_1);
	marshaled.___isBufferSyncTile_2 = static_cast<int32_t>(unmarshaled.___isBufferSyncTile_2);
}
IL2CPP_EXTERN_C void SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshal_pinvoke_back(const SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_pinvoke& marshaled, SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA& unmarshaled)
{
	bool unmarshaledhasSyncTileCallback_temp_0 = false;
	unmarshaledhasSyncTileCallback_temp_0 = static_cast<bool>(marshaled.___hasSyncTileCallback_0);
	unmarshaled.___hasSyncTileCallback_0 = unmarshaledhasSyncTileCallback_temp_0;
	bool unmarshaledhasPositionsChangedCallback_temp_1 = false;
	unmarshaledhasPositionsChangedCallback_temp_1 = static_cast<bool>(marshaled.___hasPositionsChangedCallback_1);
	unmarshaled.___hasPositionsChangedCallback_1 = unmarshaledhasPositionsChangedCallback_temp_1;
	bool unmarshaledisBufferSyncTile_temp_2 = false;
	unmarshaledisBufferSyncTile_temp_2 = static_cast<bool>(marshaled.___isBufferSyncTile_2);
	unmarshaled.___isBufferSyncTile_2 = unmarshaledisBufferSyncTile_temp_2;
}
IL2CPP_EXTERN_C void SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshal_pinvoke_cleanup(SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_pinvoke& marshaled)
{
}
IL2CPP_EXTERN_C void SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshal_com(const SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA& unmarshaled, SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_com& marshaled)
{
	marshaled.___hasSyncTileCallback_0 = static_cast<int32_t>(unmarshaled.___hasSyncTileCallback_0);
	marshaled.___hasPositionsChangedCallback_1 = static_cast<int32_t>(unmarshaled.___hasPositionsChangedCallback_1);
	marshaled.___isBufferSyncTile_2 = static_cast<int32_t>(unmarshaled.___isBufferSyncTile_2);
}
IL2CPP_EXTERN_C void SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshal_com_back(const SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_com& marshaled, SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA& unmarshaled)
{
	bool unmarshaledhasSyncTileCallback_temp_0 = false;
	unmarshaledhasSyncTileCallback_temp_0 = static_cast<bool>(marshaled.___hasSyncTileCallback_0);
	unmarshaled.___hasSyncTileCallback_0 = unmarshaledhasSyncTileCallback_temp_0;
	bool unmarshaledhasPositionsChangedCallback_temp_1 = false;
	unmarshaledhasPositionsChangedCallback_temp_1 = static_cast<bool>(marshaled.___hasPositionsChangedCallback_1);
	unmarshaled.___hasPositionsChangedCallback_1 = unmarshaledhasPositionsChangedCallback_temp_1;
	bool unmarshaledisBufferSyncTile_temp_2 = false;
	unmarshaledisBufferSyncTile_temp_2 = static_cast<bool>(marshaled.___isBufferSyncTile_2);
	unmarshaled.___isBufferSyncTile_2 = unmarshaledisBufferSyncTile_temp_2;
}
IL2CPP_EXTERN_C void SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshal_com_cleanup(SyncTileCallbackSettings_tBBB8B7336BDE6E578C7A7B1D322A9B1273A76CDA_marshaled_com& marshaled)
{
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TilemapRenderer_RegisterSpriteAtlasRegistered_m5D7676A05B0B16ABCCF4CEE57BA9E28FA4D171BC (TilemapRenderer_t1A45FD335E86172CFBB77D657E1D6705A477A6CB* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D* L_0 = (Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D*)il2cpp_codegen_object_new(Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Action_1__ctor_mDAEB7161DF624FDF6A3DA3C6BE40319FFC05A2E3(L_0, __this, (intptr_t)((void*)TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_RuntimeMethod_var), NULL);
		SpriteAtlasManager_add_atlasRegistered_mF83F3AEB343B2111048330DCBBC25688B5F5F7AD(L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TilemapRenderer_UnregisterSpriteAtlasRegistered_mFE33C972CF738A50A631203D0DD7E325AADFCB08 (TilemapRenderer_t1A45FD335E86172CFBB77D657E1D6705A477A6CB* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D* L_0 = (Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D*)il2cpp_codegen_object_new(Action_1_tE96F2DDA71AE56E61CEEC5974B6503D38835E57D_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Action_1__ctor_mDAEB7161DF624FDF6A3DA3C6BE40319FFC05A2E3(L_0, __this, (intptr_t)((void*)TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_RuntimeMethod_var), NULL);
		SpriteAtlasManager_remove_atlasRegistered_m606C351B26C01824C922ACF29708D85F35072E9F(L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1 (TilemapRenderer_t1A45FD335E86172CFBB77D657E1D6705A477A6CB* __this, SpriteAtlas_t7B9620FBFBE1CCB781F2ED24A3B2DD37734F66A8* ___atlas0, const RuntimeMethod* method) 
{
	typedef void (*TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_ftn) (TilemapRenderer_t1A45FD335E86172CFBB77D657E1D6705A477A6CB*, SpriteAtlas_t7B9620FBFBE1CCB781F2ED24A3B2DD37734F66A8*);
	static TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TilemapRenderer_OnSpriteAtlasRegistered_m4348D78754045C8B10CEA76195A313790F412ED1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Tilemaps.TilemapRenderer::OnSpriteAtlasRegistered(UnityEngine.U2D.SpriteAtlas)");
	_il2cpp_icall_func(__this, ___atlas0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_sprite_m3566544847F9C9C27EDB154324B6FBDB446EFE94 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* G_B2_0 = NULL;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* G_B1_0 = NULL;
	int32_t G_B3_0 = 0;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* G_B3_1 = NULL;
	{
		Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* L_0 = ___value0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B1_0 = __this;
		if (L_1)
		{
			G_B2_0 = __this;
			goto IL_000e;
		}
	}
	{
		G_B3_0 = 0;
		G_B3_1 = G_B1_0;
		goto IL_0014;
	}

IL_000e:
	{
		Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* L_2 = ___value0;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = Object_GetInstanceID_m554FF4073C9465F3835574CC084E68AAEEC6CC6A(L_2, NULL);
		G_B3_0 = L_3;
		G_B3_1 = G_B2_0;
	}

IL_0014:
	{
		G_B3_1->___m_Sprite_0 = G_B3_0;
		return;
	}
}
IL2CPP_EXTERN_C  void TileData_set_sprite_m3566544847F9C9C27EDB154324B6FBDB446EFE94_AdjustorThunk (RuntimeObject* __this, Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___value0, const RuntimeMethod* method)
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F*>(__this + _offset);
	TileData_set_sprite_m3566544847F9C9C27EDB154324B6FBDB446EFE94(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_color_m5E759823878243A226EF46419FAD7C0CC3D5F40A (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___value0, const RuntimeMethod* method) 
{
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0 = ___value0;
		__this->___m_Color_1 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C  void TileData_set_color_m5E759823878243A226EF46419FAD7C0CC3D5F40A_AdjustorThunk (RuntimeObject* __this, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___value0, const RuntimeMethod* method)
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F*>(__this + _offset);
	TileData_set_color_m5E759823878243A226EF46419FAD7C0CC3D5F40A(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_transform_m71074A780C066292F940002A7165658E9CC01F9F (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = ___value0;
		__this->___m_Transform_2 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C  void TileData_set_transform_m71074A780C066292F940002A7165658E9CC01F9F_AdjustorThunk (RuntimeObject* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method)
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F*>(__this + _offset);
	TileData_set_transform_m71074A780C066292F940002A7165658E9CC01F9F(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_gameObject_m1CE5B2AAAB5BF5AEF36EBAF2BCE23E4D2E5A9E09 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* G_B2_0 = NULL;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* G_B1_0 = NULL;
	int32_t G_B3_0 = 0;
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* G_B3_1 = NULL;
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0 = ___value0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B1_0 = __this;
		if (L_1)
		{
			G_B2_0 = __this;
			goto IL_000e;
		}
	}
	{
		G_B3_0 = 0;
		G_B3_1 = G_B1_0;
		goto IL_0014;
	}

IL_000e:
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_2 = ___value0;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = Object_GetInstanceID_m554FF4073C9465F3835574CC084E68AAEEC6CC6A(L_2, NULL);
		G_B3_0 = L_3;
		G_B3_1 = G_B2_0;
	}

IL_0014:
	{
		G_B3_1->___m_GameObject_3 = G_B3_0;
		return;
	}
}
IL2CPP_EXTERN_C  void TileData_set_gameObject_m1CE5B2AAAB5BF5AEF36EBAF2BCE23E4D2E5A9E09_AdjustorThunk (RuntimeObject* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___value0, const RuntimeMethod* method)
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F*>(__this + _offset);
	TileData_set_gameObject_m1CE5B2AAAB5BF5AEF36EBAF2BCE23E4D2E5A9E09(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_flags_mEB46B1364D6DB7F77C2E1E43AFD31381B291BD30 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___value0;
		__this->___m_Flags_4 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C  void TileData_set_flags_mEB46B1364D6DB7F77C2E1E43AFD31381B291BD30_AdjustorThunk (RuntimeObject* __this, int32_t ___value0, const RuntimeMethod* method)
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F*>(__this + _offset);
	TileData_set_flags_mEB46B1364D6DB7F77C2E1E43AFD31381B291BD30(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData_set_colliderType_mE12359ADEF5F42CC0B635DCBAEC3035F0526FA96 (TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___value0;
		__this->___m_ColliderType_5 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C  void TileData_set_colliderType_mE12359ADEF5F42CC0B635DCBAEC3035F0526FA96_AdjustorThunk (RuntimeObject* __this, int32_t ___value0, const RuntimeMethod* method)
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F*>(__this + _offset);
	TileData_set_colliderType_mE12359ADEF5F42CC0B635DCBAEC3035F0526FA96(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F TileData_CreateDefault_m4E44C661D13D791B4CBB2024970E4BE662ACCB57 (const RuntimeMethod* method) 
{
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F V_0;
	memset((&V_0), 0, sizeof(V_0));
	TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F));
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0;
		L_0 = Color_get_white_m28BB6E19F27D4EE6858D3021A44F62BC74E20C43_inline(NULL);
		TileData_set_color_m5E759823878243A226EF46419FAD7C0CC3D5F40A((&V_0), L_0, NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_1;
		L_1 = Matrix4x4_get_identity_m94A09872C449C26863FF10D0FDF87842D91BECD6_inline(NULL);
		TileData_set_transform_m71074A780C066292F940002A7165658E9CC01F9F((&V_0), L_1, NULL);
		TileData_set_flags_mEB46B1364D6DB7F77C2E1E43AFD31381B291BD30((&V_0), 0, NULL);
		TileData_set_colliderType_mE12359ADEF5F42CC0B635DCBAEC3035F0526FA96((&V_0), 0, NULL);
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F L_2 = V_0;
		V_1 = L_2;
		goto IL_0039;
	}

IL_0039:
	{
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F L_3 = V_1;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TileData__cctor_m3B6542759030287C1159671D5A20FD8AB8F67BE8 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F L_0;
		L_0 = TileData_CreateDefault_m4E44C661D13D791B4CBB2024970E4BE662ACCB57(NULL);
		((TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_StaticFields*)il2cpp_codegen_static_fields_for(TileData_tFB814629D010ABD175127C0BE96FD96EA606E00F_il2cpp_TypeInfo_var))->___Default_6 = L_0;
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
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
IL2CPP_EXTERN_C void TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshal_pinvoke(const TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149& unmarshaled, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_AnimatedSprites_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AnimatedSprites' of type 'TileAnimationData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AnimatedSprites_0Exception, NULL);
}
IL2CPP_EXTERN_C void TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshal_pinvoke_back(const TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_pinvoke& marshaled, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149& unmarshaled)
{
	Exception_t* ___m_AnimatedSprites_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AnimatedSprites' of type 'TileAnimationData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AnimatedSprites_0Exception, NULL);
}
IL2CPP_EXTERN_C void TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshal_pinvoke_cleanup(TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_pinvoke& marshaled)
{
}
IL2CPP_EXTERN_C void TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshal_com(const TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149& unmarshaled, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_com& marshaled)
{
	Exception_t* ___m_AnimatedSprites_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AnimatedSprites' of type 'TileAnimationData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AnimatedSprites_0Exception, NULL);
}
IL2CPP_EXTERN_C void TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshal_com_back(const TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_com& marshaled, TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149& unmarshaled)
{
	Exception_t* ___m_AnimatedSprites_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_AnimatedSprites' of type 'TileAnimationData': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_AnimatedSprites_0Exception, NULL);
}
IL2CPP_EXTERN_C void TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshal_com_cleanup(TileAnimationData_tB7419BC111545576349DD19CAB0DEFD240CAF149_marshaled_com& marshaled)
{
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void* IntPtr_ToPointer_m1A0612EED3A1C8B8850BE2943CFC42523064B4F6_inline (intptr_t* __this, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = *__this;
		return (void*)(L_0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Color_get_white_m28BB6E19F27D4EE6858D3021A44F62BC74E20C43_inline (const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0;
		memset((&L_0), 0, sizeof(L_0));
		Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline((&L_0), (1.0f), (1.0f), (1.0f), (1.0f), NULL);
		V_0 = L_0;
		goto IL_001d;
	}

IL_001d:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_get_identity_m94A09872C449C26863FF10D0FDF87842D91BECD6_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = ((Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6_StaticFields*)il2cpp_codegen_static_fields_for(Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6_il2cpp_TypeInfo_var))->___identityMatrix_17;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_2_Invoke_m7BFCE0BBCF67689D263059B56A8D79161B698587_gshared_inline (Action_2_t156C43F079E7E68155FCDCD12DC77DD11AEF7E3C* __this, RuntimeObject* ___arg10, RuntimeObject* ___arg21, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___arg10, ___arg21, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_2_Invoke_m7B85C2674B1EB0681F20E9C5AF3D19563459CBC0_gshared_inline (Action_2_t0302727DEEDCFCC692E80AEEC31B8066AE8C5550* __this, RuntimeObject* ___arg10, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF ___arg21, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, NativeArray_1_t245D7224A42D1A32B87C64E49B7B434585EC91EF, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___arg10, ___arg21, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___r0, float ___g1, float ___b2, float ___a3, const RuntimeMethod* method) 
{
	{
		float L_0 = ___r0;
		__this->___r_0 = L_0;
		float L_1 = ___g1;
		__this->___g_1 = L_1;
		float L_2 = ___b2;
		__this->___b_2 = L_2;
		float L_3 = ___a3;
		__this->___a_3 = L_3;
		return;
	}
}
