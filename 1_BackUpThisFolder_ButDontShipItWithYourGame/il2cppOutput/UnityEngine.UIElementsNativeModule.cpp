#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


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
template <typename R, typename T1, typename T2>
struct VirtualFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4>
struct VirtualFuncInvoker4
{
	typedef R (*Func)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct GenericVirtualActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct GenericVirtualFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4>
struct GenericVirtualFuncInvoker4
{
	typedef R (*Func)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct InterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct InterfaceFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4>
struct InterfaceFuncInvoker4
{
	typedef R (*Func)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct GenericInterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct GenericInterfaceFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4>
struct GenericInterfaceFuncInvoker4
{
	typedef R (*Func)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};

struct Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C;
struct Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA;
struct Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2;
struct Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87;
struct IEnumerable_1_tF95C9E01A913DD50575531C8305932628663D9E9;
struct IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17;
struct IEnumerator_1_t74AEE2605F4B877C807DBE6BC93485F22AD46925;
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D;
struct List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct VertexAttributeDescriptorU5BU5D_t5D10E60612F12777F59B7E33939F9075DB0E02B2;
struct YogaNodeU5BU5D_t27301B567A9C8D13791534005522F3E81E19B61A;
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07;
struct BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679;
struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184;
struct Delegate_t;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA;
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB;
struct Logger_t092B1218ED93DD47180692D5761559B2054234A0;
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3;
struct MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D;
struct MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09;
struct MethodInfo_t;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct String_t;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E;
struct YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345;
struct YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA;
struct CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD;

IL2CPP_EXTERN_C RuntimeClass* Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IntPtr_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral2EB7EACAE6B3BFBFD70862A8840592343396CF46;
IL2CPP_EXTERN_C String_t* _stringLiteral3E4595538801AB36CCD7E4EFDA9DD0272DEA19EF;
IL2CPP_EXTERN_C String_t* _stringLiteral52BC61F0345FADE03AB730C8F5BC70C5256D169E;
IL2CPP_EXTERN_C String_t* _stringLiteral807D31E7D618CFE25644A0B838EBD88C978E78F1;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Insert_mA92B83F973FB95C659066E38F975266A82781288_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_RemoveAt_mBB0834285CA3155F375FB93327E51E35ADA652A8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m7F8A2C64FB277D2E5F22096BD170311CAE6BB5D9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m40CC53AA08CACE00E704271718B2EC1EA8370005_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* YogaConfig__ctor_mA5B9DCE1F40B5A6948D3D8848516F2CBCD2FABF4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* YogaNode_BaselineInternal_mEB097370DAFBC11A25FBAB6F7659B8A8937D88D3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* YogaNode_MeasureInternal_mBB82E0057A8C4E58268564EF52F13D2232303912_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* YogaNode__ctor_m824433D9174C4325E87EC380CD5EB5F10C20A35C_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
struct VertexAttributeDescriptorU5BU5D_t5D10E60612F12777F59B7E33939F9075DB0E02B2;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

struct U3CModuleU3E_tCFDAF3CE34E8117DEABC58BB3EBDB7B80EA66F5A 
{
};

struct EmptyEnumerable_1_t8C8873EF4F89FB0F86D91BA5B4D640E3A23AD28E  : public RuntimeObject
{
};

struct EmptyEnumerable_1_t8C8873EF4F89FB0F86D91BA5B4D640E3A23AD28E_StaticFields
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___Instance_0;
};

struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D  : public RuntimeObject
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____items_1;
	int32_t ____size_2;
	int32_t ____version_3;
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D_StaticFields
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___s_emptyArray_5;
};

struct List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165  : public RuntimeObject
{
	YogaNodeU5BU5D_t27301B567A9C8D13791534005522F3E81E19B61A* ____items_1;
	int32_t ____size_2;
	int32_t ____version_3;
	RuntimeObject* ____syncRoot_4;
};

struct List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165_StaticFields
{
	YogaNodeU5BU5D_t27301B567A9C8D13791534005522F3E81E19B61A* ___s_emptyArray_5;
};
struct Il2CppArrayBounds;

struct JobProcessor_t4352ED37B0302A3CDECBF7B11935A4E34C8EF317  : public RuntimeObject
{
};

struct MeasureOutput_t6C4FCF151309F81DF23561CF3FF1777445FBD84E  : public RuntimeObject
{
};

struct Native_t97ADC11284398663A27E9214C13A84F868A25614  : public RuntimeObject
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

struct UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938  : public RuntimeObject
{
};

struct UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_StaticFields
{
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___RepaintOverlayPanelsCallback_0;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___UpdateRuntimePanelsCallback_1;
};

struct UIPainter2D_t4E482B4E1A7EF4E0353EE1F74F3B1CD907A1BF96  : public RuntimeObject
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

struct YogaConstants_tE52AB48288567AEF285EDE0C8884AFD803AD9D3C  : public RuntimeObject
{
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

struct DrawBufferRange_t684F255F5C954760B12F6689F84E78811040C7A4 
{
	int32_t ___firstIndex_0;
	int32_t ___indexCount_1;
	int32_t ___minIndexVal_2;
	int32_t ___vertsReferenced_3;
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

struct RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 
{
	int32_t ___m_XMin_0;
	int32_t ___m_YMin_1;
	int32_t ___m_Width_2;
	int32_t ___m_Height_3;
};

struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value_0;
};

struct StencilState_tBE5F7C1134E50C5E93B45A626D4FB4690F1C91A9 
{
	uint8_t ___m_Enabled_0;
	uint8_t ___m_ReadMask_1;
	uint8_t ___m_WriteMask_2;
	uint8_t ___m_Padding_3;
	uint8_t ___m_CompareFunctionFront_4;
	uint8_t ___m_PassOperationFront_5;
	uint8_t ___m_FailOperationFront_6;
	uint8_t ___m_ZFailOperationFront_7;
	uint8_t ___m_CompareFunctionBack_8;
	uint8_t ___m_PassOperationBack_9;
	uint8_t ___m_FailOperationBack_10;
	uint8_t ___m_ZFailOperationBack_11;
};

struct UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455 
{
	uint16_t ___m_value_0;
};

struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value_0;
};

struct UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF 
{
	uint64_t ___m_value_0;
};

struct UIntPtr_t 
{
	void* ____pointer_1;
};

struct UIntPtr_t_StaticFields
{
	uintptr_t ___Zero_0;
};

struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	float ___x_2;
	float ___y_3;
	float ___z_4;
};

struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___zeroVector_5;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___oneVector_6;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upVector_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___downVector_8;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___leftVector_9;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rightVector_10;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forwardVector_11;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___backVector_12;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positiveInfinityVector_13;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___negativeInfinityVector_14;
};

struct VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76 
{
	int32_t ___U3CattributeU3Ek__BackingField_0;
	int32_t ___U3CformatU3Ek__BackingField_1;
	int32_t ___U3CdimensionU3Ek__BackingField_2;
	int32_t ___U3CstreamU3Ek__BackingField_3;
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

struct YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA 
{
	float ___width_0;
	float ___height_1;
};

struct YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C 
{
	float ___value_0;
	int32_t ___unit_1;
};

struct Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Center_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Extents_1;
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

struct GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC 
{
	intptr_t ___handle_0;
};

struct GfxUpdateBufferRange_tC47258BCB472B0727B4FCE21A2A53506644C1A97 
{
	uint32_t ___offsetFromWriteStart_0;
	uint32_t ___size_1;
	uintptr_t ___source_2;
};

struct JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 
{
	intptr_t ___jobGroup_0;
	int32_t ___version_1;
};

struct MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D  : public RuntimeObject
{
	intptr_t ___m_Ptr_0;
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

struct ProfilerMarker_tA256E18DA86EDBC5528CE066FC91C96EE86501AD 
{
	intptr_t ___m_Ptr_0;
};

struct YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345  : public RuntimeObject
{
	intptr_t ____ygConfig_1;
	Logger_t092B1218ED93DD47180692D5761559B2054234A0* ____logger_2;
};

struct YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_StaticFields
{
	YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___Default_0;
};

struct YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA  : public RuntimeObject
{
	intptr_t ____ygNode_0;
	YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ____config_1;
	WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E* ____parent_2;
	List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* ____children_3;
	MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* ____measureFunction_4;
	BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* ____baselineFunction_5;
	RuntimeObject* ____data_6;
};

struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
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

struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

struct Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD  : public RuntimeObject
{
};

struct Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields
{
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* ___GraphicsResourcesRecreate_0;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___EngineUpdate_1;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___FlushPendingResources_2;
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* ___RegisterIntermediateRenderers_3;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* ___RenderNodeAdd_4;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* ___RenderNodeExecute_5;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* ___RenderNodeCleanup_6;
	ProfilerMarker_tA256E18DA86EDBC5528CE066FC91C96EE86501AD ___s_MarkerRaiseEngineUpdate_7;
};

struct WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E  : public RuntimeObject
{
	bool ___isLongReference_0;
	GCHandle_tC44F6F72EE68BD4CFABA24309DA7A179D41127DC ___gcHandle_1;
};

struct Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C  : public MulticastDelegate_t
{
};

struct Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA  : public MulticastDelegate_t
{
};

struct Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2  : public MulticastDelegate_t
{
};

struct Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87  : public MulticastDelegate_t
{
};

struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07  : public MulticastDelegate_t
{
};

struct BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679  : public MulticastDelegate_t
{
};

struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

struct Logger_t092B1218ED93DD47180692D5761559B2054234A0  : public MulticastDelegate_t
{
};

struct MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09  : public MulticastDelegate_t
{
};

struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_StaticFields
{
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPreCull_8;
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPreRender_9;
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPostRender_10;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
struct VertexAttributeDescriptorU5BU5D_t5D10E60612F12777F59B7E33939F9075DB0E02B2  : public RuntimeArray
{
	ALIGN_FIELD (8) VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76 m_Items[1];

	inline VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, VertexAttributeDescriptor_tD4231FBF57335465D16308D2A18E8E83D36BFA76 value)
	{
		m_Items[index] = value;
	}
};
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918  : public RuntimeArray
{
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m76CBBC3E2F0583F5AD30CE592CEA1225C06A0428_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, int32_t ___capacity0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_Insert_m9C9559248941FED50561DB029D55DF08DEF3B094_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, int32_t ___index0, RuntimeObject* ___item1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, int32_t ___index0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_RemoveAt_m54F62297ADEE4D4FDA697F49ED807BF901201B54_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, int32_t ___index0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* Enumerable_Empty_TisRuntimeObject_m42BB34F154440C9F0AC402FC3E9BD08C8D678F21_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_m69C8773D6967F3B224777183E24EA621CE056F8F_gshared_inline (Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* __this, bool ___obj0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_m783EC8C62449882812B741E4DE67BF3106686D9C_gshared_inline (Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* __this, intptr_t ___obj0, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IntPtr_op_Equality_m73759B51FE326460AC87A0E386480226EF2FABED (intptr_t ___value10, intptr_t ___value21, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162 (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* __this, String_t* ___message0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Native_YGConfigNew_mF7FEFE8A2720C25879AF4FE4980871A8A79E965E (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaConfig__ctor_mA5B9DCE1F40B5A6948D3D8848516F2CBCD2FABF4 (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, intptr_t ___ygConfig0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object_Finalize_mC98C96301CCABFE00F1A7EF8E15DF507CACD42B2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t YogaConfig_get_Handle_m7E2D8171E4E8AA98BC1D886218B6207D602281DD (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IntPtr_op_Inequality_m2F715312CBFCE7E1A81D0689F68B97218E37E5D1 (intptr_t ___value10, intptr_t ___value21, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigFree_m198862BC2FB3B175A26C67839EAA617CA317D448 (intptr_t ___config0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Native_YGConfigGetUseWebDefaults_m59FA5C9CB4C476D492ECC25E5448AC9D2BDDA977 (intptr_t ___config0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigSetUseWebDefaults_m3FE3F425CF46BF1D635E9A46ADBB36A70C494229 (intptr_t ___config0, bool ___useWebDefaults1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigSetPointScaleFactor_m15305FABF31635D5F42C30DE0781B60BB82F63B1 (intptr_t ___config0, float ___pixelsInPoint1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Native_YGConfigGetDefault_m917168A4E8FA4CC2005973DB2C7CD87BC035C96E (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Single_IsNaN_m684B090AA2F895FD91821CA8684CBC11D784E4DD_inline (float ___f0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeFreeInternal_m60521071D72CE5C994D4C27179E01D36FCF72C1F (intptr_t ___ygNode0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigFreeInternal_m358F0E85047319077713EEE97547C8B372930A2A (intptr_t ___config0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void* IntPtr_op_Explicit_m693F2F9E685EE117D4AC080342B8959DAF684294 (intptr_t ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA YogaNode_MeasureInternal_mBB82E0057A8C4E58268564EF52F13D2232303912 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_BaselineInternal_mEB097370DAFBC11A25FBAB6F7659B8A8937D88D3 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Native_YGNodeNewWithConfig_m4BADFC3F80863E78BDB5FA46F61C471BCF1E84D4 (intptr_t ___config0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeFree_m9E5FEC6827B8296A5B674569008027150E1980FE (intptr_t ___ygNode0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeSetConfig_mF882824F130DCE227D2B48A57D2BBC3C74B52966 (intptr_t ___ygNode0, intptr_t ___config1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Native_YGNodeIsDirty_mBD46D37EBADC5461AE91B0C95B8FD646D9780BD1 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeMarkDirty_m8107F56D4BE2A266294A39F0430A56423DC78D89 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Native_YGNodeGetHasNewLayout_m0A7DE10C4D95B992479353AAE7135C27A003A9C5 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeCopyStyle_m9D5D2CBA0B40C0D5431F74947B8706729D42394B (intptr_t ___dstNode0, intptr_t ___srcNode1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexDirection_m150F6EFCFD965963E9D206226396317AD48DF3BF (intptr_t ___node0, int32_t ___flexDirection1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetJustifyContent_mA45440CBEA3DD733B9C5031DC7C94BBFF7B4541B (intptr_t ___node0, int32_t ___justifyContent1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetDisplay_m76EE649F8BBBD773A069E95E51EBE3EFCD94EA97 (intptr_t ___node0, int32_t ___display1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetAlignItems_m897DD75F642F60F5684E37E6CC30D2D62898AFE4 (intptr_t ___node0, int32_t ___alignItems1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetAlignSelf_m32AF1214C3B0A5E56E9706659A828143B92ABF12 (intptr_t ___node0, int32_t ___alignSelf1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetAlignContent_m436932D80EAA2FFF82EA5DD41AA220A47D9D3945 (intptr_t ___node0, int32_t ___alignContent1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPositionType_m26C36EE82EE28CE1E1106D75A4A642FFC18D8FD0 (intptr_t ___node0, int32_t ___positionType1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexWrap_mC611BBFF56FC26E6A93CE874A8CD61435CE65E37 (intptr_t ___node0, int32_t ___flexWrap1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlex_mFF7012530FCC88266A00BF7A69940DAC6EB1ED6C (intptr_t ___node0, float ___flex1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexGrow_m56C8FB64F02228A7CDE449E0405C82BDBEDDBDFB (intptr_t ___node0, float ___flexGrow1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexShrink_m7ACF9472AC51523670FE7640F7ACD4875ADA4635 (intptr_t ___node0, float ___flexShrink1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900 (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexBasisPercent_m22672DC96B27B4C7E0A7D23A974E3449AE64FB0A (intptr_t ___node0, float ___flexBasis1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexBasisAuto_mA6B5F8FCD81C4328EF6A32011889345B3C90EA10 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexBasis_m7D3390C0993FFB845708254B32A52AE907581352 (intptr_t ___node0, float ___flexBasis1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetWidthPercent_m7051570F172E071DE73F1D6FE3FC0C24D9AB0866 (intptr_t ___node0, float ___width1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetWidthAuto_mF7E15C1BD54ED04A538A7E6374473FF32CA3EBF5 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetWidth_m8E500EE5BF635FEBD32F63D73C08CBB6D308D555 (intptr_t ___node0, float ___width1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetHeightPercent_mB14285FBEEBB58E99F5329AFDFA55345EB1503BB (intptr_t ___node0, float ___height1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetHeightAuto_m80090E2A427A05BF4B310680DD6137E300B5E9A4 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetHeight_mD587BA4AE75897D9E335F6D7DD084CB579CB2F71 (intptr_t ___node0, float ___height1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxWidthPercent_m8134B86C8E0BDD36B6910E6E69A496F4C1B60A0A (intptr_t ___node0, float ___maxWidth1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxWidth_m9ACC3DD5528EA7831590E5FCF9A9674263048972 (intptr_t ___node0, float ___maxWidth1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxHeightPercent_mA145490CBEE28201E08E6132A32CF5CB6C9FEC34 (intptr_t ___node0, float ___maxHeight1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxHeight_m92DE27BA06CD74FB4B70D1173880EE9DEEA08268 (intptr_t ___node0, float ___maxHeight1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinWidthPercent_m24384D17BBA8CD168C0D5D452D116DE4876DB7A2 (intptr_t ___node0, float ___minWidth1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinWidth_mFD0182554D716A2CBF44278D8DEC7D48828A7618 (intptr_t ___node0, float ___minWidth1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinHeightPercent_m4945109EAD0F65DB30AFBF93751102462C2B03E9 (intptr_t ___node0, float ___minHeight1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinHeight_m85D89605026C54D1A71F01AC8948430EDC966EFE (intptr_t ___node0, float ___minHeight1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetLeft_m6E5B560CDA74FFA7A3C762A90D791A59A0860976 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetTop_m60CDD8A7A2D1623D0014FD3505F758F07D856ED2 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetRight_m83E1CADD797933807D34DD9073762C4990D2BF10 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetBottom_m8725DE50F08BAB04FD8254183DAAB6F75C641457 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetWidth_mE2410FE497C00ABA40E053D0FD4A203ABB88CD9D (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetHeight_mC423C0EB25D27AE7F74387F7C9A6C6898B87B254 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetOverflow_m14D9D8F8BC2E38729E18E22B28D9CB640A3E1755 (intptr_t ___node0, int32_t ___flexWrap1, const RuntimeMethod* method) ;
inline int32_t List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_inline (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*, const RuntimeMethod*))List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeSetHasNewLayout_m22EA7B1DA4E2AA20DEDBE1AD1A776A1D303E30DA (intptr_t ___node0, bool ___hasNewLayout1, const RuntimeMethod* method) ;
inline void List_1__ctor_m7F8A2C64FB277D2E5F22096BD170311CAE6BB5D9 (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* __this, int32_t ___capacity0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*, int32_t, const RuntimeMethod*))List_1__ctor_m76CBBC3E2F0583F5AD30CE592CEA1225C06A0428_gshared)(__this, ___capacity0, method);
}
inline void List_1_Insert_mA92B83F973FB95C659066E38F975266A82781288 (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* __this, int32_t ___index0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___item1, const RuntimeMethod* method)
{
	((  void (*) (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*, int32_t, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, const RuntimeMethod*))List_1_Insert_m9C9559248941FED50561DB029D55DF08DEF3B094_gshared)(__this, ___index0, ___item1, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void WeakReference__ctor_m5F9E2F970CD85965A003C0B37ABDBFAA1F5CF241 (WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E* __this, RuntimeObject* ___target0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeInsertChild_mA5D0DFFDFD846F112A7FDCE846CF9A5231280CB9 (intptr_t ___node0, intptr_t ___child1, uint32_t ___index2, const RuntimeMethod* method) ;
inline YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* List_1_get_Item_m40CC53AA08CACE00E704271718B2EC1EA8370005 (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* __this, int32_t ___index0, const RuntimeMethod* method)
{
	return ((  YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* (*) (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*, int32_t, const RuntimeMethod*))List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared)(__this, ___index0, method);
}
inline void List_1_RemoveAt_mBB0834285CA3155F375FB93327E51E35ADA652A8 (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* __this, int32_t ___index0, const RuntimeMethod* method)
{
	((  void (*) (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*, int32_t, const RuntimeMethod*))List_1_RemoveAt_m54F62297ADEE4D4FDA697F49ED807BF901201B54_gshared)(__this, ___index0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeRemoveChild_m98FE1F99F5233E763801CAEFE89272AB264A1F0C (intptr_t ___node0, intptr_t ___child1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_RemoveAt_m344D767FF02FB69813F270953ACFEE28E5DEF83F (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___index0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaNode_get_IsBaselineDefined_m7E3BFBBB4F59F44881E6A58B342FABB672119DF5 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGSetManagedObject_m2CCD688B498F6519A453E4FA30E6F81F31F68B71 (intptr_t ___ygNode0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeRemoveMeasureFunc_m69C7422D474A3E47CD52CF2742FE5F8A682F632A (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeSetMeasureFunc_mBC3464D096E2B65400DAA28A6AC49BFE40569643 (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Native_YGNodeStyleGetDirection_mE3F698167ADF40E414DCF74E394EF6393395216B (intptr_t ___node0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeCalculateLayout_m54489A4F0F5B1B991920DB4953E3CD7D23376B89 (intptr_t ___node0, float ___availableWidth1, float ___availableHeight2, int32_t ___parentDirection3, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_inline (MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_inline (BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method) ;
inline RuntimeObject* Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_inline (const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (const RuntimeMethod*))Enumerable_Empty_TisRuntimeObject_m42BB34F154440C9F0AC402FC3E9BD08C8D678F21_gshared_inline)(method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_SetStylePosition_m17081B8019875ACCC6D5215A1FB0D6B64C9FD7CF (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___edge0, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPositionPercent_m0B220FFEEAAC8D66B48BAFD10DFC91AD4FD1072B (intptr_t ___node0, int32_t ___edge1, float ___position2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPosition_m5F2C22B45049D8A1D038B8B25BB7ED4F1BCBD968 (intptr_t ___node0, int32_t ___edge1, float ___position2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_SetStyleMargin_m9F59AA83FE83F289CC286EF0C33F8558055A8065 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___edge0, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMarginPercent_mE967F7476BD0D973E61FCE5662DC1FD0874EDBDF (intptr_t ___node0, int32_t ___edge1, float ___margin2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMarginAuto_mE08483C5081E2AE8E6DBA5E782B72B072C1B8A17 (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMargin_m7785C8F0BFB107B19C71F301ADC044B7821DD8F6 (intptr_t ___node0, int32_t ___edge1, float ___margin2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_SetStylePadding_m4591446410152C5EFEEFC41D208431CEDFBBF707 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___edge0, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPaddingPercent_mD46DCE885F761260AD11E120D17C573AE4E1A463 (intptr_t ___node0, int32_t ___edge1, float ___padding2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPadding_mAFC55FBA93FFB5DC4B86DA5B6574E9C3DD727F53 (intptr_t ___node0, int32_t ___edge1, float ___padding2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A (intptr_t ___node0, int32_t ___edge1, float ___border2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106 (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497 (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaConstants_IsUndefined_m315EAE3D71B71011D7AE90F2F5C0617AC55DEDD9 (float ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Single_Equals_m97C79E2B80F39214DB3F7E714FF2BCA45A0A8BF9 (float* __this, float ___obj0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaValue_Equals_m7D39A876BF907A38C1F82FCF5303B9AD3CD1BC3F (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___other0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaValue_Equals_mC37A099D3DB33896B40843065EC84D6F290FCCBD (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2 (float* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t YogaValue_GetHashCode_m8E287A9A127C7B15B870756A948C3BB6C4A12672 (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C YogaValue_Point_mA1955877796F9582C8F3B9ADDA817CD2B87E613E (float ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Combine_m8B9D24CED35033C7FC56501DFE650F5CB7FF012C (Delegate_t* ___a0, Delegate_t* ___b1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Remove_m40506877934EC1AD4ADAE57F5E97AF0BC0F96116 (Delegate_t* ___source0, Delegate_t* ___value1, const RuntimeMethod* method) ;
inline void Action_1_Invoke_m69C8773D6967F3B224777183E24EA621CE056F8F_inline (Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* __this, bool ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*, bool, const RuntimeMethod*))Action_1_Invoke_m69C8773D6967F3B224777183E24EA621CE056F8F_gshared_inline)(__this, ___obj0, method);
}
inline void Action_1_Invoke_mCEB98AA7C8ED536CE7A592667637829D2D609DCF_inline (Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* __this, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*, const RuntimeMethod*))Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline)(__this, ___obj0, method);
}
inline void Action_1_Invoke_m783EC8C62449882812B741E4DE67BF3106686D9C_inline (Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* __this, intptr_t ___obj0, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*, intptr_t, const RuntimeMethod*))Action_1_Invoke_m783EC8C62449882812B741E4DE67BF3106686D9C_gshared_inline)(__this, ___obj0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RegisterIntermediateRenderer_Injected_m95245CEE2B093C661065C6262AD1BD16CF171BE2 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___camera0, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___material1, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* ___transform2, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* ___aabb3, int32_t ___renderLayer4, int32_t ___shadowCasting5, bool ___receiveShadows6, int32_t ___sameDistanceSortPriority7, uint64_t ___sceneCullingMask8, int32_t ___rendererCallbackFlags9, intptr_t ___userData10, int32_t ___userDataSize11, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_SetScissorRect_Injected_m713B7CE9313C2696047C98A6AFC339C8BAFA8993 (RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8* ___scissorRect0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Utility_CreateStencilState_Injected_mF7304A13703CB8BBC4E5E2CE66EAF56AEC117C8B (StencilState_tBE5F7C1134E50C5E93B45A626D4FB4690F1C91A9* ___stencilState0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_GetActiveViewport_Injected_m60650AF751F179D62E35B34CCC6E2068291F0CB0 (RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8* ___ret0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_GetUnityProjectionMatrix_Injected_m8DE89F47F848B2071774E05D2F23DA10435E643D (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* ___ret0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ProfilerMarker__ctor_mDD68B0A8B71E0301F592AF8891560150E55699C8_inline (ProfilerMarker_tA256E18DA86EDBC5528CE066FC91C96EE86501AD* __this, String_t* ___name0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JobProcessor_ScheduleNudgeJobs_Injected_mC7B666DCC73B067A211EE6BFBF285A2B6C0D65D4 (intptr_t ___buffer0, int32_t ___jobCount1, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08* ___ret2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JobProcessor_ScheduleConvertMeshJobs_Injected_mD2E53BA62D67928253C21A40FB6D4C093D753037 (intptr_t ___buffer0, int32_t ___jobCount1, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08* ___ret2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JobProcessor_ScheduleCopyClosingMeshJobs_Injected_mF4E9EF047BB15991B068DBFF4064BD7623098DA6 (intptr_t ___buffer0, int32_t ___jobCount1, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08* ___ret2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t BitConverter_SingleToInt32Bits_mA1902D40966CA4C89A8974B10E5680A06E88566B_inline (float ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t ProfilerUnsafeUtility_CreateMarker_m27DDE00D41B95677982DBFCE074D45B79E50C7CC (String_t* ___name0, uint16_t ___categoryId1, uint16_t ___flags2, int32_t ___metadataCount3, const RuntimeMethod* method) ;
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
float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_Multicast(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	float retVal = 0.0f;
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* currentDelegate = reinterpret_cast<BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679*>(delegatesToInvoke[i]);
		typedef float (*FunctionPointerType) (RuntimeObject*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, float, const RuntimeMethod*);
		retVal = ((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___node0, ___width1, ___height2, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
	return retVal;
}
float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_Open(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method)
{
	typedef float (*FunctionPointerType) (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, float, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___method_ptr_0)(___node0, ___width1, ___height2, method);
}
float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenVirtual(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method)
{
	return VirtualFuncInvoker2< float, float, float >::Invoke(il2cpp_codegen_method_get_slot(method), ___node0, ___width1, ___height2);
}
float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenInterface(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method)
{
	return InterfaceFuncInvoker2< float, float, float >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___node0, ___width1, ___height2);
}
float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenGenericVirtual(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method)
{
	return GenericVirtualFuncInvoker2< float, float, float >::Invoke(method, ___node0, ___width1, ___height2);
}
float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenGenericInterface(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method)
{
	return GenericInterfaceFuncInvoker2< float, float, float >::Invoke(method, ___node0, ___width1, ___height2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaselineFunction__ctor_m525AED7069E4DFB2C8770618315000F96E7FD500 (BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 3;
		if (isOpen)
			__this->___invoke_impl_1 = (intptr_t)&BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_Open;
		else
			{
				__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
				__this->___method_code_6 = (intptr_t)__this->___m_target_2;
			}
	}
	else
	{
		bool isOpen = parameterCount == 2;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_Open;
			}
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109 (BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method) 
{
	typedef float (*FunctionPointerType) (RuntimeObject*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, float, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___node0, ___width1, ___height2, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_Multicast(Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, int32_t ___level2, String_t* ___message3, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Logger_t092B1218ED93DD47180692D5761559B2054234A0* currentDelegate = reinterpret_cast<Logger_t092B1218ED93DD47180692D5761559B2054234A0*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, int32_t, String_t*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___config0, ___node1, ___level2, ___message3, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_Open(Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, int32_t ___level2, String_t* ___message3, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, int32_t, String_t*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___config0, ___node1, ___level2, ___message3, method);
}
void Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenVirtual(Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, int32_t ___level2, String_t* ___message3, const RuntimeMethod* method)
{
	VirtualActionInvoker3< YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, int32_t, String_t* >::Invoke(il2cpp_codegen_method_get_slot(method), ___config0, ___node1, ___level2, ___message3);
}
void Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenInterface(Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, int32_t ___level2, String_t* ___message3, const RuntimeMethod* method)
{
	InterfaceActionInvoker3< YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, int32_t, String_t* >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___config0, ___node1, ___level2, ___message3);
}
void Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenGenericVirtual(Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, int32_t ___level2, String_t* ___message3, const RuntimeMethod* method)
{
	GenericVirtualActionInvoker3< YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, int32_t, String_t* >::Invoke(method, ___config0, ___node1, ___level2, ___message3);
}
void Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenGenericInterface(Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, int32_t ___level2, String_t* ___message3, const RuntimeMethod* method)
{
	GenericInterfaceActionInvoker3< YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, int32_t, String_t* >::Invoke(method, ___config0, ___node1, ___level2, ___message3);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Logger__ctor_m411B63478FF6F8FEDFB36E338920ECF6D44FCE89 (Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 4;
		if (isOpen)
			__this->___invoke_impl_1 = (intptr_t)&Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_Open;
		else
			{
				__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
				__this->___method_code_6 = (intptr_t)__this->___m_target_2;
			}
	}
	else
	{
		bool isOpen = parameterCount == 3;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_Open;
			}
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Logger_Invoke_mB64732D7138E5BFC958D540B1F27686BFAC815CF (Logger_t092B1218ED93DD47180692D5761559B2054234A0* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, int32_t ___level2, String_t* ___message3, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, int32_t, String_t*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___config0, ___node1, ___level2, ___message3, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_Multicast(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA retVal;
	memset((&retVal), 0, sizeof(retVal));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* currentDelegate = reinterpret_cast<MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09*>(delegatesToInvoke[i]);
		typedef YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA (*FunctionPointerType) (RuntimeObject*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, int32_t, float, int32_t, const RuntimeMethod*);
		retVal = ((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___node0, ___width1, ___widthMode2, ___height3, ___heightMode4, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
	return retVal;
}
YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_Open(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method)
{
	typedef YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA (*FunctionPointerType) (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, int32_t, float, int32_t, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___method_ptr_0)(___node0, ___width1, ___widthMode2, ___height3, ___heightMode4, method);
}
YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenVirtual(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method)
{
	return VirtualFuncInvoker4< YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA, float, int32_t, float, int32_t >::Invoke(il2cpp_codegen_method_get_slot(method), ___node0, ___width1, ___widthMode2, ___height3, ___heightMode4);
}
YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenInterface(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method)
{
	return InterfaceFuncInvoker4< YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA, float, int32_t, float, int32_t >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___node0, ___width1, ___widthMode2, ___height3, ___heightMode4);
}
YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenGenericVirtual(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method)
{
	return GenericVirtualFuncInvoker4< YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA, float, int32_t, float, int32_t >::Invoke(method, ___node0, ___width1, ___widthMode2, ___height3, ___heightMode4);
}
YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenGenericInterface(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method)
{
	return GenericInterfaceFuncInvoker4< YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA, float, int32_t, float, int32_t >::Invoke(method, ___node0, ___width1, ___widthMode2, ___height3, ___heightMode4);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MeasureFunction__ctor_mE08DFEFBD622065D2E123492910EA66C4A80A0BA (MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 5;
		if (isOpen)
			__this->___invoke_impl_1 = (intptr_t)&MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_Open;
		else
			{
				__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
				__this->___method_code_6 = (intptr_t)__this->___m_target_2;
			}
	}
	else
	{
		bool isOpen = parameterCount == 4;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_Open;
			}
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE (MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method) 
{
	typedef YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA (*FunctionPointerType) (RuntimeObject*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, int32_t, float, int32_t, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___node0, ___width1, ___widthMode2, ___height3, ___heightMode4, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureOutput_Make_m164C17D1EEB5DCFB522C4A5D1CD43F56B7F9F15C (float ___width0, float ___height1, const RuntimeMethod* method) 
{
	YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA V_0;
	memset((&V_0), 0, sizeof(V_0));
	YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA));
		float L_0 = ___width0;
		(&V_0)->___width_0 = L_0;
		float L_1 = ___height1;
		(&V_0)->___height_1 = L_1;
		YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA L_2 = V_0;
		V_1 = L_2;
		goto IL_001d;
	}

IL_001d:
	{
		YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA L_3 = V_1;
		return L_3;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaConfig__ctor_mA5B9DCE1F40B5A6948D3D8848516F2CBCD2FABF4 (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, intptr_t ___ygConfig0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntPtr_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		intptr_t L_0 = ___ygConfig0;
		__this->____ygConfig_1 = L_0;
		intptr_t L_1 = __this->____ygConfig_1;
		bool L_2;
		L_2 = IntPtr_op_Equality_m73759B51FE326460AC87A0E386480226EF2FABED(L_1, (0), NULL);
		V_0 = L_2;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_002f;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_4 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral52BC61F0345FADE03AB730C8F5BC70C5256D169E)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&YogaConfig__ctor_mA5B9DCE1F40B5A6948D3D8848516F2CBCD2FABF4_RuntimeMethod_var)));
	}

IL_002f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaConfig__ctor_m81D3E486916576BD67674EA5F26C8F2B45CCB6DD (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, const RuntimeMethod* method) 
{
	{
		intptr_t L_0;
		L_0 = Native_YGConfigNew_mF7FEFE8A2720C25879AF4FE4980871A8A79E965E(NULL);
		YogaConfig__ctor_mA5B9DCE1F40B5A6948D3D8848516F2CBCD2FABF4(__this, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaConfig_Finalize_m395FFF204239D6A9DC076105B4D935706B29D631 (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_002b:
			{
				Object_Finalize_mC98C96301CCABFE00F1A7EF8E15DF507CACD42B2(__this, NULL);
				return;
			}
		});
		try
		{
			{
				intptr_t L_0;
				L_0 = YogaConfig_get_Handle_m7E2D8171E4E8AA98BC1D886218B6207D602281DD(__this, NULL);
				il2cpp_codegen_runtime_class_init_inline(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
				YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_1 = ((YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_StaticFields*)il2cpp_codegen_static_fields_for(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var))->___Default_0;
				NullCheck(L_1);
				intptr_t L_2;
				L_2 = YogaConfig_get_Handle_m7E2D8171E4E8AA98BC1D886218B6207D602281DD(L_1, NULL);
				bool L_3;
				L_3 = IntPtr_op_Inequality_m2F715312CBFCE7E1A81D0689F68B97218E37E5D1(L_0, L_2, NULL);
				V_0 = L_3;
				bool L_4 = V_0;
				if (!L_4)
				{
					goto IL_0029_1;
				}
			}
			{
				intptr_t L_5;
				L_5 = YogaConfig_get_Handle_m7E2D8171E4E8AA98BC1D886218B6207D602281DD(__this, NULL);
				Native_YGConfigFree_m198862BC2FB3B175A26C67839EAA617CA317D448(L_5, NULL);
			}

IL_0029_1:
			{
				goto IL_0033;
			}
		}
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0033:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t YogaConfig_get_Handle_m7E2D8171E4E8AA98BC1D886218B6207D602281DD (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, const RuntimeMethod* method) 
{
	intptr_t V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		intptr_t L_0 = __this->____ygConfig_1;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		intptr_t L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaConfig_get_UseWebDefaults_mB64415ACFDF7FB34F6F5BB42059BFD8E3705AD9D (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		intptr_t L_0 = __this->____ygConfig_1;
		bool L_1;
		L_1 = Native_YGConfigGetUseWebDefaults_m59FA5C9CB4C476D492ECC25E5448AC9D2BDDA977(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaConfig_set_UseWebDefaults_m96AB3442B80FDA12436C4452D8605AA8DA1C8B81 (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygConfig_1;
		bool L_1 = ___value0;
		Native_YGConfigSetUseWebDefaults_m3FE3F425CF46BF1D635E9A46ADBB36A70C494229(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaConfig_set_PointScaleFactor_mF61D0EFB38778BC4B6DE323F53348485B8AC643D (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygConfig_1;
		float L_1 = ___value0;
		Native_YGConfigSetPointScaleFactor_m15305FABF31635D5F42C30DE0781B60BB82F63B1(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaConfig__cctor_m399106957D1C93E2B758F91F5640515D57D03E25 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		intptr_t L_0;
		L_0 = Native_YGConfigGetDefault_m917168A4E8FA4CC2005973DB2C7CD87BC035C96E(NULL);
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_1 = (YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345*)il2cpp_codegen_object_new(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		YogaConfig__ctor_mA5B9DCE1F40B5A6948D3D8848516F2CBCD2FABF4(L_1, L_0, NULL);
		((YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_StaticFields*)il2cpp_codegen_static_fields_for(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var))->___Default_0 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&((YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_StaticFields*)il2cpp_codegen_static_fields_for(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var))->___Default_0), (void*)L_1);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaConstants_IsUndefined_m315EAE3D71B71011D7AE90F2F5C0617AC55DEDD9 (float ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		float L_0 = ___value0;
		bool L_1;
		L_1 = Single_IsNaN_m684B090AA2F895FD91821CA8684CBC11D784E4DD_inline(L_0, NULL);
		V_0 = L_1;
		goto IL_000a;
	}

IL_000a:
	{
		bool L_2 = V_0;
		return L_2;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Native_YGNodeNewWithConfig_m4BADFC3F80863E78BDB5FA46F61C471BCF1E84D4 (intptr_t ___config0, const RuntimeMethod* method) 
{
	typedef intptr_t (*Native_YGNodeNewWithConfig_m4BADFC3F80863E78BDB5FA46F61C471BCF1E84D4_ftn) (intptr_t);
	static Native_YGNodeNewWithConfig_m4BADFC3F80863E78BDB5FA46F61C471BCF1E84D4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeNewWithConfig_m4BADFC3F80863E78BDB5FA46F61C471BCF1E84D4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeNewWithConfig(System.IntPtr)");
	intptr_t icallRetVal = _il2cpp_icall_func(___config0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeFree_m9E5FEC6827B8296A5B674569008027150E1980FE (intptr_t ___ygNode0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntPtr_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		intptr_t L_0 = ___ygNode0;
		bool L_1;
		L_1 = IntPtr_op_Equality_m73759B51FE326460AC87A0E386480226EF2FABED(L_0, (0), NULL);
		V_0 = L_1;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0012;
		}
	}
	{
		goto IL_0019;
	}

IL_0012:
	{
		intptr_t L_3 = ___ygNode0;
		Native_YGNodeFreeInternal_m60521071D72CE5C994D4C27179E01D36FCF72C1F(L_3, NULL);
	}

IL_0019:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeFreeInternal_m60521071D72CE5C994D4C27179E01D36FCF72C1F (intptr_t ___ygNode0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeFreeInternal_m60521071D72CE5C994D4C27179E01D36FCF72C1F_ftn) (intptr_t);
	static Native_YGNodeFreeInternal_m60521071D72CE5C994D4C27179E01D36FCF72C1F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeFreeInternal_m60521071D72CE5C994D4C27179E01D36FCF72C1F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeFreeInternal(System.IntPtr)");
	_il2cpp_icall_func(___ygNode0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGSetManagedObject_m2CCD688B498F6519A453E4FA30E6F81F31F68B71 (intptr_t ___ygNode0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGSetManagedObject_m2CCD688B498F6519A453E4FA30E6F81F31F68B71_ftn) (intptr_t, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*);
	static Native_YGSetManagedObject_m2CCD688B498F6519A453E4FA30E6F81F31F68B71_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGSetManagedObject_m2CCD688B498F6519A453E4FA30E6F81F31F68B71_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGSetManagedObject(System.IntPtr,UnityEngine.Yoga.YogaNode)");
	_il2cpp_icall_func(___ygNode0, ___node1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeSetConfig_mF882824F130DCE227D2B48A57D2BBC3C74B52966 (intptr_t ___ygNode0, intptr_t ___config1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeSetConfig_mF882824F130DCE227D2B48A57D2BBC3C74B52966_ftn) (intptr_t, intptr_t);
	static Native_YGNodeSetConfig_mF882824F130DCE227D2B48A57D2BBC3C74B52966_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeSetConfig_mF882824F130DCE227D2B48A57D2BBC3C74B52966_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeSetConfig(System.IntPtr,System.IntPtr)");
	_il2cpp_icall_func(___ygNode0, ___config1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Native_YGConfigGetDefault_m917168A4E8FA4CC2005973DB2C7CD87BC035C96E (const RuntimeMethod* method) 
{
	typedef intptr_t (*Native_YGConfigGetDefault_m917168A4E8FA4CC2005973DB2C7CD87BC035C96E_ftn) ();
	static Native_YGConfigGetDefault_m917168A4E8FA4CC2005973DB2C7CD87BC035C96E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGConfigGetDefault_m917168A4E8FA4CC2005973DB2C7CD87BC035C96E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGConfigGetDefault()");
	intptr_t icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Native_YGConfigNew_mF7FEFE8A2720C25879AF4FE4980871A8A79E965E (const RuntimeMethod* method) 
{
	typedef intptr_t (*Native_YGConfigNew_mF7FEFE8A2720C25879AF4FE4980871A8A79E965E_ftn) ();
	static Native_YGConfigNew_mF7FEFE8A2720C25879AF4FE4980871A8A79E965E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGConfigNew_mF7FEFE8A2720C25879AF4FE4980871A8A79E965E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGConfigNew()");
	intptr_t icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigFree_m198862BC2FB3B175A26C67839EAA617CA317D448 (intptr_t ___config0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntPtr_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		intptr_t L_0 = ___config0;
		bool L_1;
		L_1 = IntPtr_op_Equality_m73759B51FE326460AC87A0E386480226EF2FABED(L_0, (0), NULL);
		V_0 = L_1;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0012;
		}
	}
	{
		goto IL_0019;
	}

IL_0012:
	{
		intptr_t L_3 = ___config0;
		Native_YGConfigFreeInternal_m358F0E85047319077713EEE97547C8B372930A2A(L_3, NULL);
	}

IL_0019:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigFreeInternal_m358F0E85047319077713EEE97547C8B372930A2A (intptr_t ___config0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGConfigFreeInternal_m358F0E85047319077713EEE97547C8B372930A2A_ftn) (intptr_t);
	static Native_YGConfigFreeInternal_m358F0E85047319077713EEE97547C8B372930A2A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGConfigFreeInternal_m358F0E85047319077713EEE97547C8B372930A2A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGConfigFreeInternal(System.IntPtr)");
	_il2cpp_icall_func(___config0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigSetUseWebDefaults_m3FE3F425CF46BF1D635E9A46ADBB36A70C494229 (intptr_t ___config0, bool ___useWebDefaults1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGConfigSetUseWebDefaults_m3FE3F425CF46BF1D635E9A46ADBB36A70C494229_ftn) (intptr_t, bool);
	static Native_YGConfigSetUseWebDefaults_m3FE3F425CF46BF1D635E9A46ADBB36A70C494229_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGConfigSetUseWebDefaults_m3FE3F425CF46BF1D635E9A46ADBB36A70C494229_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGConfigSetUseWebDefaults(System.IntPtr,System.Boolean)");
	_il2cpp_icall_func(___config0, ___useWebDefaults1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Native_YGConfigGetUseWebDefaults_m59FA5C9CB4C476D492ECC25E5448AC9D2BDDA977 (intptr_t ___config0, const RuntimeMethod* method) 
{
	typedef bool (*Native_YGConfigGetUseWebDefaults_m59FA5C9CB4C476D492ECC25E5448AC9D2BDDA977_ftn) (intptr_t);
	static Native_YGConfigGetUseWebDefaults_m59FA5C9CB4C476D492ECC25E5448AC9D2BDDA977_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGConfigGetUseWebDefaults_m59FA5C9CB4C476D492ECC25E5448AC9D2BDDA977_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGConfigGetUseWebDefaults(System.IntPtr)");
	bool icallRetVal = _il2cpp_icall_func(___config0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGConfigSetPointScaleFactor_m15305FABF31635D5F42C30DE0781B60BB82F63B1 (intptr_t ___config0, float ___pixelsInPoint1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGConfigSetPointScaleFactor_m15305FABF31635D5F42C30DE0781B60BB82F63B1_ftn) (intptr_t, float);
	static Native_YGConfigSetPointScaleFactor_m15305FABF31635D5F42C30DE0781B60BB82F63B1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGConfigSetPointScaleFactor_m15305FABF31635D5F42C30DE0781B60BB82F63B1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGConfigSetPointScaleFactor(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___config0, ___pixelsInPoint1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeInsertChild_mA5D0DFFDFD846F112A7FDCE846CF9A5231280CB9 (intptr_t ___node0, intptr_t ___child1, uint32_t ___index2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeInsertChild_mA5D0DFFDFD846F112A7FDCE846CF9A5231280CB9_ftn) (intptr_t, intptr_t, uint32_t);
	static Native_YGNodeInsertChild_mA5D0DFFDFD846F112A7FDCE846CF9A5231280CB9_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeInsertChild_mA5D0DFFDFD846F112A7FDCE846CF9A5231280CB9_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeInsertChild(System.IntPtr,System.IntPtr,System.UInt32)");
	_il2cpp_icall_func(___node0, ___child1, ___index2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeRemoveChild_m98FE1F99F5233E763801CAEFE89272AB264A1F0C (intptr_t ___node0, intptr_t ___child1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeRemoveChild_m98FE1F99F5233E763801CAEFE89272AB264A1F0C_ftn) (intptr_t, intptr_t);
	static Native_YGNodeRemoveChild_m98FE1F99F5233E763801CAEFE89272AB264A1F0C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeRemoveChild_m98FE1F99F5233E763801CAEFE89272AB264A1F0C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeRemoveChild(System.IntPtr,System.IntPtr)");
	_il2cpp_icall_func(___node0, ___child1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeCalculateLayout_m54489A4F0F5B1B991920DB4953E3CD7D23376B89 (intptr_t ___node0, float ___availableWidth1, float ___availableHeight2, int32_t ___parentDirection3, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeCalculateLayout_m54489A4F0F5B1B991920DB4953E3CD7D23376B89_ftn) (intptr_t, float, float, int32_t);
	static Native_YGNodeCalculateLayout_m54489A4F0F5B1B991920DB4953E3CD7D23376B89_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeCalculateLayout_m54489A4F0F5B1B991920DB4953E3CD7D23376B89_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeCalculateLayout(System.IntPtr,System.Single,System.Single,UnityEngine.Yoga.YogaDirection)");
	_il2cpp_icall_func(___node0, ___availableWidth1, ___availableHeight2, ___parentDirection3);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeMarkDirty_m8107F56D4BE2A266294A39F0430A56423DC78D89 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeMarkDirty_m8107F56D4BE2A266294A39F0430A56423DC78D89_ftn) (intptr_t);
	static Native_YGNodeMarkDirty_m8107F56D4BE2A266294A39F0430A56423DC78D89_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeMarkDirty_m8107F56D4BE2A266294A39F0430A56423DC78D89_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeMarkDirty(System.IntPtr)");
	_il2cpp_icall_func(___node0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Native_YGNodeIsDirty_mBD46D37EBADC5461AE91B0C95B8FD646D9780BD1 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef bool (*Native_YGNodeIsDirty_mBD46D37EBADC5461AE91B0C95B8FD646D9780BD1_ftn) (intptr_t);
	static Native_YGNodeIsDirty_mBD46D37EBADC5461AE91B0C95B8FD646D9780BD1_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeIsDirty_mBD46D37EBADC5461AE91B0C95B8FD646D9780BD1_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeIsDirty(System.IntPtr)");
	bool icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeCopyStyle_m9D5D2CBA0B40C0D5431F74947B8706729D42394B (intptr_t ___dstNode0, intptr_t ___srcNode1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeCopyStyle_m9D5D2CBA0B40C0D5431F74947B8706729D42394B_ftn) (intptr_t, intptr_t);
	static Native_YGNodeCopyStyle_m9D5D2CBA0B40C0D5431F74947B8706729D42394B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeCopyStyle_m9D5D2CBA0B40C0D5431F74947B8706729D42394B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeCopyStyle(System.IntPtr,System.IntPtr)");
	_il2cpp_icall_func(___dstNode0, ___srcNode1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeSetMeasureFunc_mBC3464D096E2B65400DAA28A6AC49BFE40569643 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeSetMeasureFunc_mBC3464D096E2B65400DAA28A6AC49BFE40569643_ftn) (intptr_t);
	static Native_YGNodeSetMeasureFunc_mBC3464D096E2B65400DAA28A6AC49BFE40569643_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeSetMeasureFunc_mBC3464D096E2B65400DAA28A6AC49BFE40569643_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeSetMeasureFunc(System.IntPtr)");
	_il2cpp_icall_func(___node0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeRemoveMeasureFunc_m69C7422D474A3E47CD52CF2742FE5F8A682F632A (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeRemoveMeasureFunc_m69C7422D474A3E47CD52CF2742FE5F8A682F632A_ftn) (intptr_t);
	static Native_YGNodeRemoveMeasureFunc_m69C7422D474A3E47CD52CF2742FE5F8A682F632A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeRemoveMeasureFunc_m69C7422D474A3E47CD52CF2742FE5F8A682F632A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeRemoveMeasureFunc(System.IntPtr)");
	_il2cpp_icall_func(___node0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeMeasureInvoke_mAE8E00280ED5522C07C630B135A9ECD9A0AC9441 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, intptr_t ___returnValueAddress5, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = ___returnValueAddress5;
		void* L_1;
		L_1 = IntPtr_op_Explicit_m693F2F9E685EE117D4AC080342B8959DAF684294(L_0, NULL);
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_2 = ___node0;
		float L_3 = ___width1;
		int32_t L_4 = ___widthMode2;
		float L_5 = ___height3;
		int32_t L_6 = ___heightMode4;
		YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA L_7;
		L_7 = YogaNode_MeasureInternal_mBB82E0057A8C4E58268564EF52F13D2232303912(L_2, L_3, L_4, L_5, L_6, NULL);
		*(YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA*)L_1 = L_7;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeBaselineInvoke_m68F86D69C1E31AAB5A6EF330B5656AD5F29C72FC (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, intptr_t ___returnValueAddress3, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = ___returnValueAddress3;
		void* L_1;
		L_1 = IntPtr_op_Explicit_m693F2F9E685EE117D4AC080342B8959DAF684294(L_0, NULL);
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_2 = ___node0;
		float L_3 = ___width1;
		float L_4 = ___height2;
		float L_5;
		L_5 = YogaNode_BaselineInternal_mEB097370DAFBC11A25FBAB6F7659B8A8937D88D3(L_2, L_3, L_4, NULL);
		*((float*)L_1) = (float)L_5;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeSetHasNewLayout_m22EA7B1DA4E2AA20DEDBE1AD1A776A1D303E30DA (intptr_t ___node0, bool ___hasNewLayout1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeSetHasNewLayout_m22EA7B1DA4E2AA20DEDBE1AD1A776A1D303E30DA_ftn) (intptr_t, bool);
	static Native_YGNodeSetHasNewLayout_m22EA7B1DA4E2AA20DEDBE1AD1A776A1D303E30DA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeSetHasNewLayout_m22EA7B1DA4E2AA20DEDBE1AD1A776A1D303E30DA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeSetHasNewLayout(System.IntPtr,System.Boolean)");
	_il2cpp_icall_func(___node0, ___hasNewLayout1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Native_YGNodeGetHasNewLayout_m0A7DE10C4D95B992479353AAE7135C27A003A9C5 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef bool (*Native_YGNodeGetHasNewLayout_m0A7DE10C4D95B992479353AAE7135C27A003A9C5_ftn) (intptr_t);
	static Native_YGNodeGetHasNewLayout_m0A7DE10C4D95B992479353AAE7135C27A003A9C5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeGetHasNewLayout_m0A7DE10C4D95B992479353AAE7135C27A003A9C5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeGetHasNewLayout(System.IntPtr)");
	bool icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Native_YGNodeStyleGetDirection_mE3F698167ADF40E414DCF74E394EF6393395216B (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef int32_t (*Native_YGNodeStyleGetDirection_mE3F698167ADF40E414DCF74E394EF6393395216B_ftn) (intptr_t);
	static Native_YGNodeStyleGetDirection_mE3F698167ADF40E414DCF74E394EF6393395216B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleGetDirection_mE3F698167ADF40E414DCF74E394EF6393395216B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleGetDirection(System.IntPtr)");
	int32_t icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexDirection_m150F6EFCFD965963E9D206226396317AD48DF3BF (intptr_t ___node0, int32_t ___flexDirection1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlexDirection_m150F6EFCFD965963E9D206226396317AD48DF3BF_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetFlexDirection_m150F6EFCFD965963E9D206226396317AD48DF3BF_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlexDirection_m150F6EFCFD965963E9D206226396317AD48DF3BF_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlexDirection(System.IntPtr,UnityEngine.Yoga.YogaFlexDirection)");
	_il2cpp_icall_func(___node0, ___flexDirection1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetJustifyContent_mA45440CBEA3DD733B9C5031DC7C94BBFF7B4541B (intptr_t ___node0, int32_t ___justifyContent1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetJustifyContent_mA45440CBEA3DD733B9C5031DC7C94BBFF7B4541B_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetJustifyContent_mA45440CBEA3DD733B9C5031DC7C94BBFF7B4541B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetJustifyContent_mA45440CBEA3DD733B9C5031DC7C94BBFF7B4541B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetJustifyContent(System.IntPtr,UnityEngine.Yoga.YogaJustify)");
	_il2cpp_icall_func(___node0, ___justifyContent1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetAlignContent_m436932D80EAA2FFF82EA5DD41AA220A47D9D3945 (intptr_t ___node0, int32_t ___alignContent1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetAlignContent_m436932D80EAA2FFF82EA5DD41AA220A47D9D3945_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetAlignContent_m436932D80EAA2FFF82EA5DD41AA220A47D9D3945_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetAlignContent_m436932D80EAA2FFF82EA5DD41AA220A47D9D3945_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetAlignContent(System.IntPtr,UnityEngine.Yoga.YogaAlign)");
	_il2cpp_icall_func(___node0, ___alignContent1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetAlignItems_m897DD75F642F60F5684E37E6CC30D2D62898AFE4 (intptr_t ___node0, int32_t ___alignItems1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetAlignItems_m897DD75F642F60F5684E37E6CC30D2D62898AFE4_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetAlignItems_m897DD75F642F60F5684E37E6CC30D2D62898AFE4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetAlignItems_m897DD75F642F60F5684E37E6CC30D2D62898AFE4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetAlignItems(System.IntPtr,UnityEngine.Yoga.YogaAlign)");
	_il2cpp_icall_func(___node0, ___alignItems1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetAlignSelf_m32AF1214C3B0A5E56E9706659A828143B92ABF12 (intptr_t ___node0, int32_t ___alignSelf1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetAlignSelf_m32AF1214C3B0A5E56E9706659A828143B92ABF12_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetAlignSelf_m32AF1214C3B0A5E56E9706659A828143B92ABF12_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetAlignSelf_m32AF1214C3B0A5E56E9706659A828143B92ABF12_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetAlignSelf(System.IntPtr,UnityEngine.Yoga.YogaAlign)");
	_il2cpp_icall_func(___node0, ___alignSelf1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPositionType_m26C36EE82EE28CE1E1106D75A4A642FFC18D8FD0 (intptr_t ___node0, int32_t ___positionType1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetPositionType_m26C36EE82EE28CE1E1106D75A4A642FFC18D8FD0_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetPositionType_m26C36EE82EE28CE1E1106D75A4A642FFC18D8FD0_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetPositionType_m26C36EE82EE28CE1E1106D75A4A642FFC18D8FD0_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetPositionType(System.IntPtr,UnityEngine.Yoga.YogaPositionType)");
	_il2cpp_icall_func(___node0, ___positionType1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexWrap_mC611BBFF56FC26E6A93CE874A8CD61435CE65E37 (intptr_t ___node0, int32_t ___flexWrap1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlexWrap_mC611BBFF56FC26E6A93CE874A8CD61435CE65E37_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetFlexWrap_mC611BBFF56FC26E6A93CE874A8CD61435CE65E37_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlexWrap_mC611BBFF56FC26E6A93CE874A8CD61435CE65E37_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlexWrap(System.IntPtr,UnityEngine.Yoga.YogaWrap)");
	_il2cpp_icall_func(___node0, ___flexWrap1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetOverflow_m14D9D8F8BC2E38729E18E22B28D9CB640A3E1755 (intptr_t ___node0, int32_t ___flexWrap1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetOverflow_m14D9D8F8BC2E38729E18E22B28D9CB640A3E1755_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetOverflow_m14D9D8F8BC2E38729E18E22B28D9CB640A3E1755_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetOverflow_m14D9D8F8BC2E38729E18E22B28D9CB640A3E1755_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetOverflow(System.IntPtr,UnityEngine.Yoga.YogaOverflow)");
	_il2cpp_icall_func(___node0, ___flexWrap1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetDisplay_m76EE649F8BBBD773A069E95E51EBE3EFCD94EA97 (intptr_t ___node0, int32_t ___display1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetDisplay_m76EE649F8BBBD773A069E95E51EBE3EFCD94EA97_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetDisplay_m76EE649F8BBBD773A069E95E51EBE3EFCD94EA97_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetDisplay_m76EE649F8BBBD773A069E95E51EBE3EFCD94EA97_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetDisplay(System.IntPtr,UnityEngine.Yoga.YogaDisplay)");
	_il2cpp_icall_func(___node0, ___display1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlex_mFF7012530FCC88266A00BF7A69940DAC6EB1ED6C (intptr_t ___node0, float ___flex1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlex_mFF7012530FCC88266A00BF7A69940DAC6EB1ED6C_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetFlex_mFF7012530FCC88266A00BF7A69940DAC6EB1ED6C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlex_mFF7012530FCC88266A00BF7A69940DAC6EB1ED6C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlex(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___flex1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexGrow_m56C8FB64F02228A7CDE449E0405C82BDBEDDBDFB (intptr_t ___node0, float ___flexGrow1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlexGrow_m56C8FB64F02228A7CDE449E0405C82BDBEDDBDFB_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetFlexGrow_m56C8FB64F02228A7CDE449E0405C82BDBEDDBDFB_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlexGrow_m56C8FB64F02228A7CDE449E0405C82BDBEDDBDFB_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlexGrow(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___flexGrow1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexShrink_m7ACF9472AC51523670FE7640F7ACD4875ADA4635 (intptr_t ___node0, float ___flexShrink1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlexShrink_m7ACF9472AC51523670FE7640F7ACD4875ADA4635_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetFlexShrink_m7ACF9472AC51523670FE7640F7ACD4875ADA4635_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlexShrink_m7ACF9472AC51523670FE7640F7ACD4875ADA4635_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlexShrink(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___flexShrink1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexBasis_m7D3390C0993FFB845708254B32A52AE907581352 (intptr_t ___node0, float ___flexBasis1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlexBasis_m7D3390C0993FFB845708254B32A52AE907581352_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetFlexBasis_m7D3390C0993FFB845708254B32A52AE907581352_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlexBasis_m7D3390C0993FFB845708254B32A52AE907581352_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlexBasis(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___flexBasis1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexBasisPercent_m22672DC96B27B4C7E0A7D23A974E3449AE64FB0A (intptr_t ___node0, float ___flexBasis1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlexBasisPercent_m22672DC96B27B4C7E0A7D23A974E3449AE64FB0A_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetFlexBasisPercent_m22672DC96B27B4C7E0A7D23A974E3449AE64FB0A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlexBasisPercent_m22672DC96B27B4C7E0A7D23A974E3449AE64FB0A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlexBasisPercent(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___flexBasis1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetFlexBasisAuto_mA6B5F8FCD81C4328EF6A32011889345B3C90EA10 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetFlexBasisAuto_mA6B5F8FCD81C4328EF6A32011889345B3C90EA10_ftn) (intptr_t);
	static Native_YGNodeStyleSetFlexBasisAuto_mA6B5F8FCD81C4328EF6A32011889345B3C90EA10_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetFlexBasisAuto_mA6B5F8FCD81C4328EF6A32011889345B3C90EA10_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetFlexBasisAuto(System.IntPtr)");
	_il2cpp_icall_func(___node0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetWidth_m8E500EE5BF635FEBD32F63D73C08CBB6D308D555 (intptr_t ___node0, float ___width1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetWidth_m8E500EE5BF635FEBD32F63D73C08CBB6D308D555_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetWidth_m8E500EE5BF635FEBD32F63D73C08CBB6D308D555_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetWidth_m8E500EE5BF635FEBD32F63D73C08CBB6D308D555_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetWidth(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___width1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetWidthPercent_m7051570F172E071DE73F1D6FE3FC0C24D9AB0866 (intptr_t ___node0, float ___width1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetWidthPercent_m7051570F172E071DE73F1D6FE3FC0C24D9AB0866_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetWidthPercent_m7051570F172E071DE73F1D6FE3FC0C24D9AB0866_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetWidthPercent_m7051570F172E071DE73F1D6FE3FC0C24D9AB0866_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetWidthPercent(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___width1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetWidthAuto_mF7E15C1BD54ED04A538A7E6374473FF32CA3EBF5 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetWidthAuto_mF7E15C1BD54ED04A538A7E6374473FF32CA3EBF5_ftn) (intptr_t);
	static Native_YGNodeStyleSetWidthAuto_mF7E15C1BD54ED04A538A7E6374473FF32CA3EBF5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetWidthAuto_mF7E15C1BD54ED04A538A7E6374473FF32CA3EBF5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetWidthAuto(System.IntPtr)");
	_il2cpp_icall_func(___node0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetHeight_mD587BA4AE75897D9E335F6D7DD084CB579CB2F71 (intptr_t ___node0, float ___height1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetHeight_mD587BA4AE75897D9E335F6D7DD084CB579CB2F71_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetHeight_mD587BA4AE75897D9E335F6D7DD084CB579CB2F71_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetHeight_mD587BA4AE75897D9E335F6D7DD084CB579CB2F71_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetHeight(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___height1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetHeightPercent_mB14285FBEEBB58E99F5329AFDFA55345EB1503BB (intptr_t ___node0, float ___height1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetHeightPercent_mB14285FBEEBB58E99F5329AFDFA55345EB1503BB_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetHeightPercent_mB14285FBEEBB58E99F5329AFDFA55345EB1503BB_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetHeightPercent_mB14285FBEEBB58E99F5329AFDFA55345EB1503BB_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetHeightPercent(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___height1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetHeightAuto_m80090E2A427A05BF4B310680DD6137E300B5E9A4 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetHeightAuto_m80090E2A427A05BF4B310680DD6137E300B5E9A4_ftn) (intptr_t);
	static Native_YGNodeStyleSetHeightAuto_m80090E2A427A05BF4B310680DD6137E300B5E9A4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetHeightAuto_m80090E2A427A05BF4B310680DD6137E300B5E9A4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetHeightAuto(System.IntPtr)");
	_il2cpp_icall_func(___node0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinWidth_mFD0182554D716A2CBF44278D8DEC7D48828A7618 (intptr_t ___node0, float ___minWidth1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMinWidth_mFD0182554D716A2CBF44278D8DEC7D48828A7618_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMinWidth_mFD0182554D716A2CBF44278D8DEC7D48828A7618_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMinWidth_mFD0182554D716A2CBF44278D8DEC7D48828A7618_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMinWidth(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___minWidth1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinWidthPercent_m24384D17BBA8CD168C0D5D452D116DE4876DB7A2 (intptr_t ___node0, float ___minWidth1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMinWidthPercent_m24384D17BBA8CD168C0D5D452D116DE4876DB7A2_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMinWidthPercent_m24384D17BBA8CD168C0D5D452D116DE4876DB7A2_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMinWidthPercent_m24384D17BBA8CD168C0D5D452D116DE4876DB7A2_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMinWidthPercent(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___minWidth1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinHeight_m85D89605026C54D1A71F01AC8948430EDC966EFE (intptr_t ___node0, float ___minHeight1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMinHeight_m85D89605026C54D1A71F01AC8948430EDC966EFE_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMinHeight_m85D89605026C54D1A71F01AC8948430EDC966EFE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMinHeight_m85D89605026C54D1A71F01AC8948430EDC966EFE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMinHeight(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___minHeight1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMinHeightPercent_m4945109EAD0F65DB30AFBF93751102462C2B03E9 (intptr_t ___node0, float ___minHeight1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMinHeightPercent_m4945109EAD0F65DB30AFBF93751102462C2B03E9_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMinHeightPercent_m4945109EAD0F65DB30AFBF93751102462C2B03E9_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMinHeightPercent_m4945109EAD0F65DB30AFBF93751102462C2B03E9_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMinHeightPercent(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___minHeight1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxWidth_m9ACC3DD5528EA7831590E5FCF9A9674263048972 (intptr_t ___node0, float ___maxWidth1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMaxWidth_m9ACC3DD5528EA7831590E5FCF9A9674263048972_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMaxWidth_m9ACC3DD5528EA7831590E5FCF9A9674263048972_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMaxWidth_m9ACC3DD5528EA7831590E5FCF9A9674263048972_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMaxWidth(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___maxWidth1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxWidthPercent_m8134B86C8E0BDD36B6910E6E69A496F4C1B60A0A (intptr_t ___node0, float ___maxWidth1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMaxWidthPercent_m8134B86C8E0BDD36B6910E6E69A496F4C1B60A0A_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMaxWidthPercent_m8134B86C8E0BDD36B6910E6E69A496F4C1B60A0A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMaxWidthPercent_m8134B86C8E0BDD36B6910E6E69A496F4C1B60A0A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMaxWidthPercent(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___maxWidth1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxHeight_m92DE27BA06CD74FB4B70D1173880EE9DEEA08268 (intptr_t ___node0, float ___maxHeight1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMaxHeight_m92DE27BA06CD74FB4B70D1173880EE9DEEA08268_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMaxHeight_m92DE27BA06CD74FB4B70D1173880EE9DEEA08268_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMaxHeight_m92DE27BA06CD74FB4B70D1173880EE9DEEA08268_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMaxHeight(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___maxHeight1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMaxHeightPercent_mA145490CBEE28201E08E6132A32CF5CB6C9FEC34 (intptr_t ___node0, float ___maxHeight1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMaxHeightPercent_mA145490CBEE28201E08E6132A32CF5CB6C9FEC34_ftn) (intptr_t, float);
	static Native_YGNodeStyleSetMaxHeightPercent_mA145490CBEE28201E08E6132A32CF5CB6C9FEC34_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMaxHeightPercent_mA145490CBEE28201E08E6132A32CF5CB6C9FEC34_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMaxHeightPercent(System.IntPtr,System.Single)");
	_il2cpp_icall_func(___node0, ___maxHeight1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPosition_m5F2C22B45049D8A1D038B8B25BB7ED4F1BCBD968 (intptr_t ___node0, int32_t ___edge1, float ___position2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetPosition_m5F2C22B45049D8A1D038B8B25BB7ED4F1BCBD968_ftn) (intptr_t, int32_t, float);
	static Native_YGNodeStyleSetPosition_m5F2C22B45049D8A1D038B8B25BB7ED4F1BCBD968_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetPosition_m5F2C22B45049D8A1D038B8B25BB7ED4F1BCBD968_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetPosition(System.IntPtr,UnityEngine.Yoga.YogaEdge,System.Single)");
	_il2cpp_icall_func(___node0, ___edge1, ___position2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPositionPercent_m0B220FFEEAAC8D66B48BAFD10DFC91AD4FD1072B (intptr_t ___node0, int32_t ___edge1, float ___position2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetPositionPercent_m0B220FFEEAAC8D66B48BAFD10DFC91AD4FD1072B_ftn) (intptr_t, int32_t, float);
	static Native_YGNodeStyleSetPositionPercent_m0B220FFEEAAC8D66B48BAFD10DFC91AD4FD1072B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetPositionPercent_m0B220FFEEAAC8D66B48BAFD10DFC91AD4FD1072B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetPositionPercent(System.IntPtr,UnityEngine.Yoga.YogaEdge,System.Single)");
	_il2cpp_icall_func(___node0, ___edge1, ___position2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMargin_m7785C8F0BFB107B19C71F301ADC044B7821DD8F6 (intptr_t ___node0, int32_t ___edge1, float ___margin2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMargin_m7785C8F0BFB107B19C71F301ADC044B7821DD8F6_ftn) (intptr_t, int32_t, float);
	static Native_YGNodeStyleSetMargin_m7785C8F0BFB107B19C71F301ADC044B7821DD8F6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMargin_m7785C8F0BFB107B19C71F301ADC044B7821DD8F6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMargin(System.IntPtr,UnityEngine.Yoga.YogaEdge,System.Single)");
	_il2cpp_icall_func(___node0, ___edge1, ___margin2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMarginPercent_mE967F7476BD0D973E61FCE5662DC1FD0874EDBDF (intptr_t ___node0, int32_t ___edge1, float ___margin2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMarginPercent_mE967F7476BD0D973E61FCE5662DC1FD0874EDBDF_ftn) (intptr_t, int32_t, float);
	static Native_YGNodeStyleSetMarginPercent_mE967F7476BD0D973E61FCE5662DC1FD0874EDBDF_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMarginPercent_mE967F7476BD0D973E61FCE5662DC1FD0874EDBDF_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMarginPercent(System.IntPtr,UnityEngine.Yoga.YogaEdge,System.Single)");
	_il2cpp_icall_func(___node0, ___edge1, ___margin2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetMarginAuto_mE08483C5081E2AE8E6DBA5E782B72B072C1B8A17 (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetMarginAuto_mE08483C5081E2AE8E6DBA5E782B72B072C1B8A17_ftn) (intptr_t, int32_t);
	static Native_YGNodeStyleSetMarginAuto_mE08483C5081E2AE8E6DBA5E782B72B072C1B8A17_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetMarginAuto_mE08483C5081E2AE8E6DBA5E782B72B072C1B8A17_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetMarginAuto(System.IntPtr,UnityEngine.Yoga.YogaEdge)");
	_il2cpp_icall_func(___node0, ___edge1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPadding_mAFC55FBA93FFB5DC4B86DA5B6574E9C3DD727F53 (intptr_t ___node0, int32_t ___edge1, float ___padding2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetPadding_mAFC55FBA93FFB5DC4B86DA5B6574E9C3DD727F53_ftn) (intptr_t, int32_t, float);
	static Native_YGNodeStyleSetPadding_mAFC55FBA93FFB5DC4B86DA5B6574E9C3DD727F53_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetPadding_mAFC55FBA93FFB5DC4B86DA5B6574E9C3DD727F53_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetPadding(System.IntPtr,UnityEngine.Yoga.YogaEdge,System.Single)");
	_il2cpp_icall_func(___node0, ___edge1, ___padding2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetPaddingPercent_mD46DCE885F761260AD11E120D17C573AE4E1A463 (intptr_t ___node0, int32_t ___edge1, float ___padding2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetPaddingPercent_mD46DCE885F761260AD11E120D17C573AE4E1A463_ftn) (intptr_t, int32_t, float);
	static Native_YGNodeStyleSetPaddingPercent_mD46DCE885F761260AD11E120D17C573AE4E1A463_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetPaddingPercent_mD46DCE885F761260AD11E120D17C573AE4E1A463_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetPaddingPercent(System.IntPtr,UnityEngine.Yoga.YogaEdge,System.Single)");
	_il2cpp_icall_func(___node0, ___edge1, ___padding2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A (intptr_t ___node0, int32_t ___edge1, float ___border2, const RuntimeMethod* method) 
{
	typedef void (*Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A_ftn) (intptr_t, int32_t, float);
	static Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeStyleSetBorder(System.IntPtr,UnityEngine.Yoga.YogaEdge,System.Single)");
	_il2cpp_icall_func(___node0, ___edge1, ___border2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetLeft_m6E5B560CDA74FFA7A3C762A90D791A59A0860976 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetLeft_m6E5B560CDA74FFA7A3C762A90D791A59A0860976_ftn) (intptr_t);
	static Native_YGNodeLayoutGetLeft_m6E5B560CDA74FFA7A3C762A90D791A59A0860976_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetLeft_m6E5B560CDA74FFA7A3C762A90D791A59A0860976_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetLeft(System.IntPtr)");
	float icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetTop_m60CDD8A7A2D1623D0014FD3505F758F07D856ED2 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetTop_m60CDD8A7A2D1623D0014FD3505F758F07D856ED2_ftn) (intptr_t);
	static Native_YGNodeLayoutGetTop_m60CDD8A7A2D1623D0014FD3505F758F07D856ED2_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetTop_m60CDD8A7A2D1623D0014FD3505F758F07D856ED2_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetTop(System.IntPtr)");
	float icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetRight_m83E1CADD797933807D34DD9073762C4990D2BF10 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetRight_m83E1CADD797933807D34DD9073762C4990D2BF10_ftn) (intptr_t);
	static Native_YGNodeLayoutGetRight_m83E1CADD797933807D34DD9073762C4990D2BF10_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetRight_m83E1CADD797933807D34DD9073762C4990D2BF10_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetRight(System.IntPtr)");
	float icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetBottom_m8725DE50F08BAB04FD8254183DAAB6F75C641457 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetBottom_m8725DE50F08BAB04FD8254183DAAB6F75C641457_ftn) (intptr_t);
	static Native_YGNodeLayoutGetBottom_m8725DE50F08BAB04FD8254183DAAB6F75C641457_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetBottom_m8725DE50F08BAB04FD8254183DAAB6F75C641457_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetBottom(System.IntPtr)");
	float icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetWidth_mE2410FE497C00ABA40E053D0FD4A203ABB88CD9D (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetWidth_mE2410FE497C00ABA40E053D0FD4A203ABB88CD9D_ftn) (intptr_t);
	static Native_YGNodeLayoutGetWidth_mE2410FE497C00ABA40E053D0FD4A203ABB88CD9D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetWidth_mE2410FE497C00ABA40E053D0FD4A203ABB88CD9D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetWidth(System.IntPtr)");
	float icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetHeight_mC423C0EB25D27AE7F74387F7C9A6C6898B87B254 (intptr_t ___node0, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetHeight_mC423C0EB25D27AE7F74387F7C9A6C6898B87B254_ftn) (intptr_t);
	static Native_YGNodeLayoutGetHeight_mC423C0EB25D27AE7F74387F7C9A6C6898B87B254_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetHeight_mC423C0EB25D27AE7F74387F7C9A6C6898B87B254_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetHeight(System.IntPtr)");
	float icallRetVal = _il2cpp_icall_func(___node0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B_ftn) (intptr_t, int32_t);
	static Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetMargin(System.IntPtr,UnityEngine.Yoga.YogaEdge)");
	float icallRetVal = _il2cpp_icall_func(___node0, ___edge1);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106 (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106_ftn) (intptr_t, int32_t);
	static Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetPadding(System.IntPtr,UnityEngine.Yoga.YogaEdge)");
	float icallRetVal = _il2cpp_icall_func(___node0, ___edge1);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497 (intptr_t ___node0, int32_t ___edge1, const RuntimeMethod* method) 
{
	typedef float (*Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497_ftn) (intptr_t, int32_t);
	static Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Yoga.Native::YGNodeLayoutGetBorder(System.IntPtr,UnityEngine.Yoga.YogaEdge)");
	float icallRetVal = _il2cpp_icall_func(___node0, ___edge1);
	return icallRetVal;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode__ctor_m824433D9174C4325E87EC380CD5EB5F10C20A35C (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___config0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntPtr_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* G_B2_0 = NULL;
	YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* G_B1_0 = NULL;
	YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* G_B3_0 = NULL;
	YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* G_B3_1 = NULL;
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_0 = ___config0;
		G_B1_0 = __this;
		if (!L_0)
		{
			G_B2_0 = __this;
			goto IL_000f;
		}
	}
	{
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_1 = ___config0;
		G_B3_0 = L_1;
		G_B3_1 = G_B1_0;
		goto IL_0014;
	}

IL_000f:
	{
		il2cpp_codegen_runtime_class_init_inline(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_2 = ((YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_StaticFields*)il2cpp_codegen_static_fields_for(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var))->___Default_0;
		G_B3_0 = L_2;
		G_B3_1 = G_B2_0;
	}

IL_0014:
	{
		NullCheck(G_B3_1);
		G_B3_1->____config_1 = G_B3_0;
		Il2CppCodeGenWriteBarrier((void**)(&G_B3_1->____config_1), (void*)G_B3_0);
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_3 = __this->____config_1;
		NullCheck(L_3);
		intptr_t L_4;
		L_4 = YogaConfig_get_Handle_m7E2D8171E4E8AA98BC1D886218B6207D602281DD(L_3, NULL);
		intptr_t L_5;
		L_5 = Native_YGNodeNewWithConfig_m4BADFC3F80863E78BDB5FA46F61C471BCF1E84D4(L_4, NULL);
		__this->____ygNode_0 = L_5;
		intptr_t L_6 = __this->____ygNode_0;
		bool L_7;
		L_7 = IntPtr_op_Equality_m73759B51FE326460AC87A0E386480226EF2FABED(L_6, (0), NULL);
		V_0 = L_7;
		bool L_8 = V_0;
		if (!L_8)
		{
			goto IL_004f;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_9 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_9);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral52BC61F0345FADE03AB730C8F5BC70C5256D169E)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&YogaNode__ctor_m824433D9174C4325E87EC380CD5EB5F10C20A35C_RuntimeMethod_var)));
	}

IL_004f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_Finalize_mD0E1733478B7861392542C1A2F8161B462CD6327 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	{
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0010:
			{
				Object_Finalize_mC98C96301CCABFE00F1A7EF8E15DF507CACD42B2(__this, NULL);
				return;
			}
		});
		try
		{
			intptr_t L_0 = __this->____ygNode_0;
			Native_YGNodeFree_m9E5FEC6827B8296A5B674569008027150E1980FE(L_0, NULL);
			goto IL_0018;
		}
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0018:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Config_mFEE688C9B0B7EFFE581F278746A7C4CD76449DE5 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* G_B2_0 = NULL;
	YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* G_B2_1 = NULL;
	YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* G_B1_0 = NULL;
	YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* G_B1_1 = NULL;
	{
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_0 = ___value0;
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_1 = L_0;
		G_B1_0 = L_1;
		G_B1_1 = __this;
		if (L_1)
		{
			G_B2_0 = L_1;
			G_B2_1 = __this;
			goto IL_000c;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var);
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_2 = ((YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_StaticFields*)il2cpp_codegen_static_fields_for(YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345_il2cpp_TypeInfo_var))->___Default_0;
		G_B2_0 = L_2;
		G_B2_1 = G_B1_1;
	}

IL_000c:
	{
		NullCheck(G_B2_1);
		G_B2_1->____config_1 = G_B2_0;
		Il2CppCodeGenWriteBarrier((void**)(&G_B2_1->____config_1), (void*)G_B2_0);
		intptr_t L_3 = __this->____ygNode_0;
		YogaConfig_tE8B56F99460C291C1F7F46DBD8BAC9F0B653A345* L_4 = __this->____config_1;
		NullCheck(L_4);
		intptr_t L_5;
		L_5 = YogaConfig_get_Handle_m7E2D8171E4E8AA98BC1D886218B6207D602281DD(L_4, NULL);
		Native_YGNodeSetConfig_mF882824F130DCE227D2B48A57D2BBC3C74B52966(L_3, L_5, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaNode_get_IsDirty_m24743ABB33BC9F32F946B3FD9C5DB85F77285781 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		intptr_t L_0 = __this->____ygNode_0;
		bool L_1;
		L_1 = Native_YGNodeIsDirty_mBD46D37EBADC5461AE91B0C95B8FD646D9780BD1(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_MarkDirty_mCCCABC1717DCAF3E313846069AD503959B184930 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		Native_YGNodeMarkDirty_m8107F56D4BE2A266294A39F0430A56423DC78D89(L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaNode_get_HasNewLayout_m801E00B631071A29A968ACA0489B1BDC2CE3CE05 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		intptr_t L_0 = __this->____ygNode_0;
		bool L_1;
		L_1 = Native_YGNodeGetHasNewLayout_m0A7DE10C4D95B992479353AAE7135C27A003A9C5(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaNode_get_IsMeasureDefined_m14B27C81AD102F307669F55E3FDFEE7E7E61B7EC (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* L_0 = __this->____measureFunction_4;
		V_0 = (bool)((!(((RuntimeObject*)(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaNode_get_IsBaselineDefined_m7E3BFBBB4F59F44881E6A58B342FABB672119DF5 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* L_0 = __this->____baselineFunction_5;
		V_0 = (bool)((!(((RuntimeObject*)(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		goto IL_000d;
	}

IL_000d:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_CopyStyle_mB3AFC6604AA23297A7DA93E5DE9A36CC3CD4B65C (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___srcNode0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_1 = ___srcNode0;
		NullCheck(L_1);
		intptr_t L_2 = L_1->____ygNode_0;
		Native_YGNodeCopyStyle_m9D5D2CBA0B40C0D5431F74947B8706729D42394B(L_0, L_2, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_FlexDirection_mFF74AB011A465EFD90BAFDE41F00207619429306 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetFlexDirection_m150F6EFCFD965963E9D206226396317AD48DF3BF(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_JustifyContent_m008464E5DA37AEDD2DDA37E89CEB2E3A1C25C286 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetJustifyContent_mA45440CBEA3DD733B9C5031DC7C94BBFF7B4541B(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Display_mCD8A7B298E87852734559A41DC01EF96827032C2 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetDisplay_m76EE649F8BBBD773A069E95E51EBE3EFCD94EA97(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_AlignItems_m8443F468878AF728A2F82505F4B53D2065DA89BF (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetAlignItems_m897DD75F642F60F5684E37E6CC30D2D62898AFE4(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_AlignSelf_mD678D097FA3DB20EF1568A9B17C7423CC8B0BCBF (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetAlignSelf_m32AF1214C3B0A5E56E9706659A828143B92ABF12(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_AlignContent_m9AC19A64AAAACEB85DA4FCF94D9372A4556F0845 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetAlignContent_m436932D80EAA2FFF82EA5DD41AA220A47D9D3945(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_PositionType_m958F7BB665C87711439BED68CCB9E7C63798FEA5 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetPositionType_m26C36EE82EE28CE1E1106D75A4A642FFC18D8FD0(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Wrap_m01F365128F74AC617966A2B3EEF340150AB59EE6 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetFlexWrap_mC611BBFF56FC26E6A93CE874A8CD61435CE65E37(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Flex_mCFCB82869C82DD5CB40151681576F4A40F381D6A (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___value0;
		Native_YGNodeStyleSetFlex_mFF7012530FCC88266A00BF7A69940DAC6EB1ED6C(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_FlexGrow_m884FDA11A3F7FAF051CB840829442FE14CC3CC2B (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___value0;
		Native_YGNodeStyleSetFlexGrow_m56C8FB64F02228A7CDE449E0405C82BDBEDDBDFB(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_FlexShrink_m30FC430AB92EB6FF05B394D25D728DC4DB2B4FA5 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___value0;
		Native_YGNodeStyleSetFlexShrink_m7ACF9472AC51523670FE7640F7ACD4875ADA4635(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_FlexBasis_m24CCC6C38C4612359E942EEF5EA5FDF4D24E7671 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetFlexBasisPercent_m22672DC96B27B4C7E0A7D23A974E3449AE64FB0A(L_2, L_3, NULL);
		goto IL_0059;
	}

IL_0026:
	{
		int32_t L_4;
		L_4 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_1 = (bool)((((int32_t)L_4) == ((int32_t)3))? 1 : 0);
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_0044;
		}
	}
	{
		intptr_t L_6 = __this->____ygNode_0;
		Native_YGNodeStyleSetFlexBasisAuto_mA6B5F8FCD81C4328EF6A32011889345B3C90EA10(L_6, NULL);
		goto IL_0059;
	}

IL_0044:
	{
		intptr_t L_7 = __this->____ygNode_0;
		float L_8;
		L_8 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetFlexBasis_m7D3390C0993FFB845708254B32A52AE907581352(L_7, L_8, NULL);
	}

IL_0059:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Width_mA267DDF44981884C4C630FCBC602595F58AB05E8 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetWidthPercent_m7051570F172E071DE73F1D6FE3FC0C24D9AB0866(L_2, L_3, NULL);
		goto IL_0059;
	}

IL_0026:
	{
		int32_t L_4;
		L_4 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_1 = (bool)((((int32_t)L_4) == ((int32_t)3))? 1 : 0);
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_0044;
		}
	}
	{
		intptr_t L_6 = __this->____ygNode_0;
		Native_YGNodeStyleSetWidthAuto_mF7E15C1BD54ED04A538A7E6374473FF32CA3EBF5(L_6, NULL);
		goto IL_0059;
	}

IL_0044:
	{
		intptr_t L_7 = __this->____ygNode_0;
		float L_8;
		L_8 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetWidth_m8E500EE5BF635FEBD32F63D73C08CBB6D308D555(L_7, L_8, NULL);
	}

IL_0059:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Height_m4AFF9C286F42919CA1C5C7A152A4ED477C56969E (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetHeightPercent_mB14285FBEEBB58E99F5329AFDFA55345EB1503BB(L_2, L_3, NULL);
		goto IL_0059;
	}

IL_0026:
	{
		int32_t L_4;
		L_4 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_1 = (bool)((((int32_t)L_4) == ((int32_t)3))? 1 : 0);
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_0044;
		}
	}
	{
		intptr_t L_6 = __this->____ygNode_0;
		Native_YGNodeStyleSetHeightAuto_m80090E2A427A05BF4B310680DD6137E300B5E9A4(L_6, NULL);
		goto IL_0059;
	}

IL_0044:
	{
		intptr_t L_7 = __this->____ygNode_0;
		float L_8;
		L_8 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetHeight_mD587BA4AE75897D9E335F6D7DD084CB579CB2F71(L_7, L_8, NULL);
	}

IL_0059:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MaxWidth_m18194AF8ECC926D70493BAC8C8041349DCF0DE43 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMaxWidthPercent_m8134B86C8E0BDD36B6910E6E69A496F4C1B60A0A(L_2, L_3, NULL);
		goto IL_003b;
	}

IL_0026:
	{
		intptr_t L_4 = __this->____ygNode_0;
		float L_5;
		L_5 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMaxWidth_m9ACC3DD5528EA7831590E5FCF9A9674263048972(L_4, L_5, NULL);
	}

IL_003b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MaxHeight_m25F7366BA8516D5C4B3EBDA5A797B33704A4CAB8 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMaxHeightPercent_mA145490CBEE28201E08E6132A32CF5CB6C9FEC34(L_2, L_3, NULL);
		goto IL_003b;
	}

IL_0026:
	{
		intptr_t L_4 = __this->____ygNode_0;
		float L_5;
		L_5 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMaxHeight_m92DE27BA06CD74FB4B70D1173880EE9DEEA08268(L_4, L_5, NULL);
	}

IL_003b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MinWidth_mC876A8736AA69BC6100AA5E361A0E9190D02DB21 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMinWidthPercent_m24384D17BBA8CD168C0D5D452D116DE4876DB7A2(L_2, L_3, NULL);
		goto IL_003b;
	}

IL_0026:
	{
		intptr_t L_4 = __this->____ygNode_0;
		float L_5;
		L_5 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMinWidth_mFD0182554D716A2CBF44278D8DEC7D48828A7618(L_4, L_5, NULL);
	}

IL_003b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MinHeight_mB3301DB6766234FE7D594DE46DF59C31F0F29643 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value0), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMinHeightPercent_m4945109EAD0F65DB30AFBF93751102462C2B03E9(L_2, L_3, NULL);
		goto IL_003b;
	}

IL_0026:
	{
		intptr_t L_4 = __this->____ygNode_0;
		float L_5;
		L_5 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value0), NULL);
		Native_YGNodeStyleSetMinHeight_m85D89605026C54D1A71F01AC8948430EDC966EFE(L_4, L_5, NULL);
	}

IL_003b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutX_mEEE47120D6DB656AC643A1294AFE3CC79E93C492 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetLeft_m6E5B560CDA74FFA7A3C762A90D791A59A0860976(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutY_m79DCF02D705920434DCE9B534FFAAC936A268173 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetTop_m60CDD8A7A2D1623D0014FD3505F758F07D856ED2(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutRight_mEBCE0188575C7FE3D72255011803E1EC56685F24 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetRight_m83E1CADD797933807D34DD9073762C4990D2BF10(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutBottom_m2F6857AB410F79908EA7098DA19F09BE07245269 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetBottom_m8725DE50F08BAB04FD8254183DAAB6F75C641457(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutWidth_mF68064634C5682A2C0C70DAAF6CB45C39D3F216A (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetWidth_mE2410FE497C00ABA40E053D0FD4A203ABB88CD9D(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutHeight_m0A56155F1B067D0127E5A38204C2F0A9BAB605BD (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetHeight_mC423C0EB25D27AE7F74387F7C9A6C6898B87B254(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Overflow_m5DD8FEB426E1376D210ED0057C4A12DD8E18417F (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		int32_t L_1 = ___value0;
		Native_YGNodeStyleSetOverflow_m14D9D8F8BC2E38729E18E22B28D9CB640A3E1755(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t YogaNode_get_Count_mBBD0D15ACBBA109563C7D22EAB1F58094C4562AD (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_0 = __this->____children_3;
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		G_B3_0 = 0;
		goto IL_0017;
	}

IL_000c:
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_1 = __this->____children_3;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_inline(L_1, List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_RuntimeMethod_var);
		G_B3_0 = L_2;
	}

IL_0017:
	{
		V_0 = G_B3_0;
		goto IL_001a;
	}

IL_001a:
	{
		int32_t L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_MarkLayoutSeen_m899C39B9392134C5B7835217D18FCC8D5E7A1E5A (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		Native_YGNodeSetHasNewLayout_m22EA7B1DA4E2AA20DEDBE1AD1A776A1D303E30DA(L_0, (bool)0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_Insert_m9182FC436BFB915BDAB6492465B6E7832B1921CF (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___index0, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Insert_mA92B83F973FB95C659066E38F975266A82781288_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m7F8A2C64FB277D2E5F22096BD170311CAE6BB5D9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_0 = __this->____children_3;
		V_0 = (bool)((((RuntimeObject*)(List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_001c;
		}
	}
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_2 = (List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*)il2cpp_codegen_object_new(List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		List_1__ctor_m7F8A2C64FB277D2E5F22096BD170311CAE6BB5D9(L_2, 4, List_1__ctor_m7F8A2C64FB277D2E5F22096BD170311CAE6BB5D9_RuntimeMethod_var);
		__this->____children_3 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____children_3), (void*)L_2);
	}

IL_001c:
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_3 = __this->____children_3;
		int32_t L_4 = ___index0;
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_5 = ___node1;
		NullCheck(L_3);
		List_1_Insert_mA92B83F973FB95C659066E38F975266A82781288(L_3, L_4, L_5, List_1_Insert_mA92B83F973FB95C659066E38F975266A82781288_RuntimeMethod_var);
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_6 = ___node1;
		WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E* L_7 = (WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E*)il2cpp_codegen_object_new(WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E_il2cpp_TypeInfo_var);
		NullCheck(L_7);
		WeakReference__ctor_m5F9E2F970CD85965A003C0B37ABDBFAA1F5CF241(L_7, __this, NULL);
		NullCheck(L_6);
		L_6->____parent_2 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&L_6->____parent_2), (void*)L_7);
		intptr_t L_8 = __this->____ygNode_0;
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_9 = ___node1;
		NullCheck(L_9);
		intptr_t L_10 = L_9->____ygNode_0;
		int32_t L_11 = ___index0;
		Native_YGNodeInsertChild_mA5D0DFFDFD846F112A7FDCE846CF9A5231280CB9(L_8, L_10, L_11, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_RemoveAt_m344D767FF02FB69813F270953ACFEE28E5DEF83F (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___index0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_RemoveAt_mBB0834285CA3155F375FB93327E51E35ADA652A8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m40CC53AA08CACE00E704271718B2EC1EA8370005_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* V_0 = NULL;
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_0 = __this->____children_3;
		int32_t L_1 = ___index0;
		NullCheck(L_0);
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_2;
		L_2 = List_1_get_Item_m40CC53AA08CACE00E704271718B2EC1EA8370005(L_0, L_1, List_1_get_Item_m40CC53AA08CACE00E704271718B2EC1EA8370005_RuntimeMethod_var);
		V_0 = L_2;
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_3 = V_0;
		NullCheck(L_3);
		L_3->____parent_2 = (WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&L_3->____parent_2), (void*)(WeakReference_tD4B0518CE911FFD9FAAB3FCD492644A354312D8E*)NULL);
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_4 = __this->____children_3;
		int32_t L_5 = ___index0;
		NullCheck(L_4);
		List_1_RemoveAt_mBB0834285CA3155F375FB93327E51E35ADA652A8(L_4, L_5, List_1_RemoveAt_mBB0834285CA3155F375FB93327E51E35ADA652A8_RuntimeMethod_var);
		intptr_t L_6 = __this->____ygNode_0;
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_7 = V_0;
		NullCheck(L_7);
		intptr_t L_8 = L_7->____ygNode_0;
		Native_YGNodeRemoveChild_m98FE1F99F5233E763801CAEFE89272AB264A1F0C(L_6, L_8, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_Clear_mCB7D5DF9967646CFD9A156DEAC56E13A0BA60826 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_0 = __this->____children_3;
		V_0 = (bool)((!(((RuntimeObject*)(List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_003a;
		}
	}
	{
		goto IL_0027;
	}

IL_0011:
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_2 = __this->____children_3;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_inline(L_2, List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_RuntimeMethod_var);
		YogaNode_RemoveAt_m344D767FF02FB69813F270953ACFEE28E5DEF83F(__this, ((int32_t)il2cpp_codegen_subtract(L_3, 1)), NULL);
	}

IL_0027:
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_4 = __this->____children_3;
		NullCheck(L_4);
		int32_t L_5;
		L_5 = List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_inline(L_4, List_1_get_Count_m1733F3D0927028C67ADD808F9E5808F07053C114_RuntimeMethod_var);
		V_1 = (bool)((((int32_t)L_5) > ((int32_t)0))? 1 : 0);
		bool L_6 = V_1;
		if (L_6)
		{
			goto IL_0011;
		}
	}
	{
	}

IL_003a:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_SetMeasureFunction_mD658FA9C0543C022DB09D54B49BA38354B558D04 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* ___measureFunction0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	{
		MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* L_0 = ___measureFunction0;
		__this->____measureFunction_4 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____measureFunction_4), (void*)L_0);
		MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* L_1 = ___measureFunction0;
		V_0 = (bool)((((RuntimeObject*)(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09*)L_1) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_003c;
		}
	}
	{
		bool L_3;
		L_3 = YogaNode_get_IsBaselineDefined_m7E3BFBBB4F59F44881E6A58B342FABB672119DF5(__this, NULL);
		V_1 = (bool)((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_002d;
		}
	}
	{
		intptr_t L_5 = __this->____ygNode_0;
		Native_YGSetManagedObject_m2CCD688B498F6519A453E4FA30E6F81F31F68B71(L_5, (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*)NULL, NULL);
	}

IL_002d:
	{
		intptr_t L_6 = __this->____ygNode_0;
		Native_YGNodeRemoveMeasureFunc_m69C7422D474A3E47CD52CF2742FE5F8A682F632A(L_6, NULL);
		goto IL_0057;
	}

IL_003c:
	{
		intptr_t L_7 = __this->____ygNode_0;
		Native_YGSetManagedObject_m2CCD688B498F6519A453E4FA30E6F81F31F68B71(L_7, __this, NULL);
		intptr_t L_8 = __this->____ygNode_0;
		Native_YGNodeSetMeasureFunc_mBC3464D096E2B65400DAA28A6AC49BFE40569643(L_8, NULL);
	}

IL_0057:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_CalculateLayout_mF1185A522FA0E60BA47039893A3EE3419B6F1D37 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___width0, float ___height1, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___width0;
		float L_2 = ___height1;
		intptr_t L_3 = __this->____ygNode_0;
		int32_t L_4;
		L_4 = Native_YGNodeStyleGetDirection_mE3F698167ADF40E414DCF74E394EF6393395216B(L_3, NULL);
		Native_YGNodeCalculateLayout_m54489A4F0F5B1B991920DB4953E3CD7D23376B89(L_0, L_1, L_2, L_4, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA YogaNode_MeasureInternal_mBB82E0057A8C4E58268564EF52F13D2232303912 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method) 
{
	bool V_0 = false;
	YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t G_B3_0 = 0;
	{
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_0 = ___node0;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_1 = ___node0;
		NullCheck(L_1);
		MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* L_2 = L_1->____measureFunction_4;
		G_B3_0 = ((((RuntimeObject*)(MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09*)L_2) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		goto IL_0010;
	}

IL_000f:
	{
		G_B3_0 = 1;
	}

IL_0010:
	{
		V_0 = (bool)G_B3_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0020;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_4 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral807D31E7D618CFE25644A0B838EBD88C978E78F1)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&YogaNode_MeasureInternal_mBB82E0057A8C4E58268564EF52F13D2232303912_RuntimeMethod_var)));
	}

IL_0020:
	{
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_5 = ___node0;
		NullCheck(L_5);
		MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* L_6 = L_5->____measureFunction_4;
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_7 = ___node0;
		float L_8 = ___width1;
		int32_t L_9 = ___widthMode2;
		float L_10 = ___height3;
		int32_t L_11 = ___heightMode4;
		NullCheck(L_6);
		YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA L_12;
		L_12 = MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_inline(L_6, L_7, L_8, L_9, L_10, L_11, NULL);
		V_1 = L_12;
		goto IL_0034;
	}

IL_0034:
	{
		YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA L_13 = V_1;
		return L_13;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_BaselineInternal_mEB097370DAFBC11A25FBAB6F7659B8A8937D88D3 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method) 
{
	bool V_0 = false;
	float V_1 = 0.0f;
	int32_t G_B3_0 = 0;
	{
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_0 = ___node0;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_1 = ___node0;
		NullCheck(L_1);
		BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* L_2 = L_1->____baselineFunction_5;
		G_B3_0 = ((((RuntimeObject*)(BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679*)L_2) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		goto IL_0010;
	}

IL_000f:
	{
		G_B3_0 = 1;
	}

IL_0010:
	{
		V_0 = (bool)G_B3_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0020;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_4 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_4);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral2EB7EACAE6B3BFBFD70862A8840592343396CF46)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&YogaNode_BaselineInternal_mEB097370DAFBC11A25FBAB6F7659B8A8937D88D3_RuntimeMethod_var)));
	}

IL_0020:
	{
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_5 = ___node0;
		NullCheck(L_5);
		BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* L_6 = L_5->____baselineFunction_5;
		YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* L_7 = ___node0;
		float L_8 = ___width1;
		float L_9 = ___height2;
		NullCheck(L_6);
		float L_10;
		L_10 = BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_inline(L_6, L_7, L_8, L_9, NULL);
		V_1 = L_10;
		goto IL_0031;
	}

IL_0031:
	{
		float L_11 = V_1;
		return L_11;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* YogaNode_GetEnumerator_m93CA3A3DC1ED5F958FB6E7D3CFB534F9A374B394 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	RuntimeObject* G_B3_0 = NULL;
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_0 = __this->____children_3;
		if (L_0)
		{
			goto IL_0015;
		}
	}
	{
		RuntimeObject* L_1;
		L_1 = Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_inline(Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_RuntimeMethod_var);
		NullCheck(L_1);
		RuntimeObject* L_2;
		L_2 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0, IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17_il2cpp_TypeInfo_var, L_1);
		G_B3_0 = L_2;
		goto IL_0020;
	}

IL_0015:
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_3 = __this->____children_3;
		NullCheck(L_3);
		RuntimeObject* L_4;
		L_4 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0, IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17_il2cpp_TypeInfo_var, L_3);
		G_B3_0 = L_4;
	}

IL_0020:
	{
		V_0 = G_B3_0;
		goto IL_0023;
	}

IL_0023:
	{
		RuntimeObject* L_5 = V_0;
		return L_5;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* YogaNode_System_Collections_IEnumerable_GetEnumerator_mF3D17F0F0C2E0C5FA4ECE8EDE724F0E332E900FA (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	RuntimeObject* G_B3_0 = NULL;
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_0 = __this->____children_3;
		if (L_0)
		{
			goto IL_0015;
		}
	}
	{
		RuntimeObject* L_1;
		L_1 = Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_inline(Enumerable_Empty_TisYogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA_m5F185515F94E7B13787034072EAB772730FA75A8_RuntimeMethod_var);
		NullCheck(L_1);
		RuntimeObject* L_2;
		L_2 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0, IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17_il2cpp_TypeInfo_var, L_1);
		G_B3_0 = L_2;
		goto IL_0020;
	}

IL_0015:
	{
		List_1_t84B666107A8A3ECB0F5A24B0243137D056DA9165* L_3 = __this->____children_3;
		NullCheck(L_3);
		RuntimeObject* L_4;
		L_4 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0, IEnumerable_1_t1A289AA616E33E751647D01D6EEEB0565390CC17_il2cpp_TypeInfo_var, L_3);
		G_B3_0 = L_4;
	}

IL_0020:
	{
		V_0 = G_B3_0;
		goto IL_0023;
	}

IL_0023:
	{
		RuntimeObject* L_5 = V_0;
		return L_5;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Left_m45FA7CF627DF74C1F795DA1488EF943DA77067A6 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePosition_m17081B8019875ACCC6D5215A1FB0D6B64C9FD7CF(__this, 0, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Top_m2F3AE8DA9025B7A1EB370C67C8B4560BA23CE5A4 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePosition_m17081B8019875ACCC6D5215A1FB0D6B64C9FD7CF(__this, 1, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Right_m35D7139ECEB7CC1B82A5DCFBFDC96EA9AFC686E5 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePosition_m17081B8019875ACCC6D5215A1FB0D6B64C9FD7CF(__this, 2, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_Bottom_m03A39B84DE5056608BCFE43E98956BF58035347F (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePosition_m17081B8019875ACCC6D5215A1FB0D6B64C9FD7CF(__this, 3, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_SetStylePosition_m17081B8019875ACCC6D5215A1FB0D6B64C9FD7CF (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___edge0, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value1), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0027;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		int32_t L_3 = ___edge0;
		float L_4;
		L_4 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value1), NULL);
		Native_YGNodeStyleSetPositionPercent_m0B220FFEEAAC8D66B48BAFD10DFC91AD4FD1072B(L_2, L_3, L_4, NULL);
		goto IL_003d;
	}

IL_0027:
	{
		intptr_t L_5 = __this->____ygNode_0;
		int32_t L_6 = ___edge0;
		float L_7;
		L_7 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value1), NULL);
		Native_YGNodeStyleSetPosition_m5F2C22B45049D8A1D038B8B25BB7ED4F1BCBD968(L_5, L_6, L_7, NULL);
	}

IL_003d:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MarginLeft_m6DD0D35E142EB59ED9280D1C4EA2F038C132FC4B (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStyleMargin_m9F59AA83FE83F289CC286EF0C33F8558055A8065(__this, 0, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MarginTop_mA43AB8E85422F7980BECF2DEF66F736C27E8E972 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStyleMargin_m9F59AA83FE83F289CC286EF0C33F8558055A8065(__this, 1, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MarginRight_m4D2DF290FF89E2A9CF33DA815985B79DFA864A3C (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStyleMargin_m9F59AA83FE83F289CC286EF0C33F8558055A8065(__this, 2, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_MarginBottom_m0CCF6AF5FC2C6ACA8E2E084AABC83322A215AEEC (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStyleMargin_m9F59AA83FE83F289CC286EF0C33F8558055A8065(__this, 3, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_SetStyleMargin_m9F59AA83FE83F289CC286EF0C33F8558055A8065 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___edge0, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value1), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0027;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		int32_t L_3 = ___edge0;
		float L_4;
		L_4 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value1), NULL);
		Native_YGNodeStyleSetMarginPercent_mE967F7476BD0D973E61FCE5662DC1FD0874EDBDF(L_2, L_3, L_4, NULL);
		goto IL_005c;
	}

IL_0027:
	{
		int32_t L_5;
		L_5 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value1), NULL);
		V_1 = (bool)((((int32_t)L_5) == ((int32_t)3))? 1 : 0);
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0046;
		}
	}
	{
		intptr_t L_7 = __this->____ygNode_0;
		int32_t L_8 = ___edge0;
		Native_YGNodeStyleSetMarginAuto_mE08483C5081E2AE8E6DBA5E782B72B072C1B8A17(L_7, L_8, NULL);
		goto IL_005c;
	}

IL_0046:
	{
		intptr_t L_9 = __this->____ygNode_0;
		int32_t L_10 = ___edge0;
		float L_11;
		L_11 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value1), NULL);
		Native_YGNodeStyleSetMargin_m7785C8F0BFB107B19C71F301ADC044B7821DD8F6(L_9, L_10, L_11, NULL);
	}

IL_005c:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_PaddingLeft_mDC797F410F72554FAD67A14DC5002656C985D06D (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePadding_m4591446410152C5EFEEFC41D208431CEDFBBF707(__this, 0, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_PaddingTop_mE59506FA241E2BFD3AC4CEB219000993CC950F01 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePadding_m4591446410152C5EFEEFC41D208431CEDFBBF707(__this, 1, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_PaddingRight_mA277C8926B03AE1FE89F46A6A24882D61155E7F8 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePadding_m4591446410152C5EFEEFC41D208431CEDFBBF707(__this, 2, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_PaddingBottom_mD4BE8EAD7054982975BB95088DC507B355B57D32 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value0, const RuntimeMethod* method) 
{
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = ___value0;
		YogaNode_SetStylePadding_m4591446410152C5EFEEFC41D208431CEDFBBF707(__this, 3, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_SetStylePadding_m4591446410152C5EFEEFC41D208431CEDFBBF707 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, int32_t ___edge0, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___value1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___value1), NULL);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)2))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0027;
		}
	}
	{
		intptr_t L_2 = __this->____ygNode_0;
		int32_t L_3 = ___edge0;
		float L_4;
		L_4 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value1), NULL);
		Native_YGNodeStyleSetPaddingPercent_mD46DCE885F761260AD11E120D17C573AE4E1A463(L_2, L_3, L_4, NULL);
		goto IL_003d;
	}

IL_0027:
	{
		intptr_t L_5 = __this->____ygNode_0;
		int32_t L_6 = ___edge0;
		float L_7;
		L_7 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___value1), NULL);
		Native_YGNodeStyleSetPadding_mAFC55FBA93FFB5DC4B86DA5B6574E9C3DD727F53(L_5, L_6, L_7, NULL);
	}

IL_003d:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_BorderLeftWidth_m6F0ADE17EA294DC33E0EBBB17E4DF867B5E73CA5 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___value0;
		Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A(L_0, 0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_BorderTopWidth_m39A26DC4E61833C0F8F58EA28A71AA35C4553005 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___value0;
		Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A(L_0, 1, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_BorderRightWidth_m047EE6ECCF13C9E44885BCE8FA20D2FD0DA498C6 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___value0;
		Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A(L_0, 2, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void YogaNode_set_BorderBottomWidth_m10BD7CB272CE0342EEA05F413A78BB6CE34FD8F3 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1 = ___value0;
		Native_YGNodeStyleSetBorder_m8F54DC0939E0B80CA94377F2E70F377DAD37E45A(L_0, 3, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutMarginLeft_mBBDC00F49301F60C09C5B3BF8782EAB5C814DFB4 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B(L_0, 0, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutMarginTop_m010905C6DDD8C42E540AAB4DDCD2AFA6FFE13BE6 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B(L_0, 1, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutMarginRight_mE6BDC383CDA9AFD8C827B928A86EF13A8D50A566 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B(L_0, 2, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutMarginBottom_m46D9999CE1CF2957DE68BA4024B36F9A50F08151 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetMargin_mF652440347917736559C418261B120953A70E42B(L_0, 3, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutPaddingLeft_m315AB18C71CFF8207E9DBC8D7538BFE0A0569421 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106(L_0, 0, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutPaddingTop_m76AB547D25D8C51B5CA987BD7D8D586AF284E8D8 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106(L_0, 1, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutPaddingRight_m3AB9145B687CB1ADE6B6EFBDBBF2928301B0FEB1 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106(L_0, 2, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutPaddingBottom_m08100BDABCA07492B6BBF8FD57BCB06AD460049C (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetPadding_m6732C0B3A36F53EE252248B834992E9E36966106(L_0, 3, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutBorderLeft_mC799A7EC6C1ED244DDD852634ACC768CEADFD366 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497(L_0, 0, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutBorderTop_m5FEAEE25D61F72B530BCC9B8B11A374BAD94D637 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497(L_0, 1, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutBorderRight_mC22B436C97ABEF06221F3BF9F1506E527E9CEF99 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497(L_0, 2, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaNode_get_LayoutBorderBottom_m06786864F2149A50CBD5F551977E46737A614D91 (YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		intptr_t L_0 = __this->____ygNode_0;
		float L_1;
		L_1 = Native_YGNodeLayoutGetBorder_mE2599ACF460B0212F479303CA784D6EC7AC06497(L_0, 3, NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		float L_2 = V_0;
		return L_2;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900 (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->___unit_1;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___value_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C  float YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*>(__this + _offset);
	float _returnValue;
	_returnValue = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C YogaValue_Point_mA1955877796F9582C8F3B9ADDA817CD2B87E613E (float ___value0, const RuntimeMethod* method) 
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C V_0;
	memset((&V_0), 0, sizeof(V_0));
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C V_1;
	memset((&V_1), 0, sizeof(V_1));
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* G_B2_0 = NULL;
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* G_B1_0 = NULL;
	int32_t G_B3_0 = 0;
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* G_B3_1 = NULL;
	{
		il2cpp_codegen_initobj((&V_0), sizeof(YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C));
		float L_0 = ___value0;
		(&V_0)->___value_0 = L_0;
		float L_1 = ___value0;
		bool L_2;
		L_2 = YogaConstants_IsUndefined_m315EAE3D71B71011D7AE90F2F5C0617AC55DEDD9(L_1, NULL);
		G_B1_0 = (&V_0);
		if (L_2)
		{
			G_B2_0 = (&V_0);
			goto IL_001e;
		}
	}
	{
		G_B3_0 = 1;
		G_B3_1 = G_B1_0;
		goto IL_001f;
	}

IL_001e:
	{
		G_B3_0 = 0;
		G_B3_1 = G_B2_0;
	}

IL_001f:
	{
		G_B3_1->___unit_1 = G_B3_0;
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_3 = V_0;
		V_1 = L_3;
		goto IL_0028;
	}

IL_0028:
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_4 = V_1;
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaValue_Equals_m7D39A876BF907A38C1F82FCF5303B9AD3CD1BC3F (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___other0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	bool V_1 = false;
	int32_t G_B4_0 = 0;
	int32_t G_B6_0 = 0;
	{
		int32_t L_0;
		L_0 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900(__this, NULL);
		int32_t L_1;
		L_1 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900((&___other0), NULL);
		if ((!(((uint32_t)L_0) == ((uint32_t)L_1))))
		{
			goto IL_0035;
		}
	}
	{
		float L_2;
		L_2 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A(__this, NULL);
		V_0 = L_2;
		float L_3;
		L_3 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A((&___other0), NULL);
		bool L_4;
		L_4 = Single_Equals_m97C79E2B80F39214DB3F7E714FF2BCA45A0A8BF9((&V_0), L_3, NULL);
		if (L_4)
		{
			goto IL_0032;
		}
	}
	{
		int32_t L_5;
		L_5 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900(__this, NULL);
		G_B4_0 = ((((int32_t)L_5) == ((int32_t)0))? 1 : 0);
		goto IL_0033;
	}

IL_0032:
	{
		G_B4_0 = 1;
	}

IL_0033:
	{
		G_B6_0 = G_B4_0;
		goto IL_0036;
	}

IL_0035:
	{
		G_B6_0 = 0;
	}

IL_0036:
	{
		V_1 = (bool)G_B6_0;
		goto IL_0039;
	}

IL_0039:
	{
		bool L_6 = V_1;
		return L_6;
	}
}
IL2CPP_EXTERN_C  bool YogaValue_Equals_m7D39A876BF907A38C1F82FCF5303B9AD3CD1BC3F_AdjustorThunk (RuntimeObject* __this, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C ___other0, const RuntimeMethod* method)
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*>(__this + _offset);
	bool _returnValue;
	_returnValue = YogaValue_Equals_m7D39A876BF907A38C1F82FCF5303B9AD3CD1BC3F(_thisAdjusted, ___other0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool YogaValue_Equals_mC37A099D3DB33896B40843065EC84D6F290FCCBD (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	int32_t G_B5_0 = 0;
	{
		RuntimeObject* L_0 = ___obj0;
		V_0 = (bool)((((RuntimeObject*)(RuntimeObject*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_000d;
		}
	}
	{
		V_1 = (bool)0;
		goto IL_0027;
	}

IL_000d:
	{
		RuntimeObject* L_2 = ___obj0;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_2, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C_il2cpp_TypeInfo_var)))
		{
			goto IL_0023;
		}
	}
	{
		RuntimeObject* L_3 = ___obj0;
		bool L_4;
		L_4 = YogaValue_Equals_m7D39A876BF907A38C1F82FCF5303B9AD3CD1BC3F(__this, ((*(YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*)((YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*)(YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*)UnBox(L_3, YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C_il2cpp_TypeInfo_var)))), NULL);
		G_B5_0 = ((int32_t)(L_4));
		goto IL_0024;
	}

IL_0023:
	{
		G_B5_0 = 0;
	}

IL_0024:
	{
		V_1 = (bool)G_B5_0;
		goto IL_0027;
	}

IL_0027:
	{
		bool L_5 = V_1;
		return L_5;
	}
}
IL2CPP_EXTERN_C  bool YogaValue_Equals_mC37A099D3DB33896B40843065EC84D6F290FCCBD_AdjustorThunk (RuntimeObject* __this, RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*>(__this + _offset);
	bool _returnValue;
	_returnValue = YogaValue_Equals_mC37A099D3DB33896B40843065EC84D6F290FCCBD(_thisAdjusted, ___obj0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t YogaValue_GetHashCode_m8E287A9A127C7B15B870756A948C3BB6C4A12672 (YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	int32_t V_1 = 0;
	{
		float L_0;
		L_0 = YogaValue_get_Value_m142314AA36484CD328E08A06D6A750F5CA1C112A(__this, NULL);
		V_0 = L_0;
		int32_t L_1;
		L_1 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2((&V_0), NULL);
		int32_t L_2;
		L_2 = YogaValue_get_Unit_m4387357877C0D183FAFD5A3857AEF4C3E52CA900(__this, NULL);
		V_1 = ((int32_t)(((int32_t)il2cpp_codegen_multiply(L_1, ((int32_t)397)))^(int32_t)L_2));
		goto IL_0020;
	}

IL_0020:
	{
		int32_t L_3 = V_1;
		return L_3;
	}
}
IL2CPP_EXTERN_C  int32_t YogaValue_GetHashCode_m8E287A9A127C7B15B870756A948C3BB6C4A12672_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = YogaValue_GetHashCode_m8E287A9A127C7B15B870756A948C3BB6C4A12672(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C YogaValue_Auto_m73BFEAE3C23C6B9BD11BFD462B007BF7A6A58C96 (const RuntimeMethod* method) 
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C V_0;
	memset((&V_0), 0, sizeof(V_0));
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C));
		(&V_0)->___value_0 = (std::numeric_limits<float>::quiet_NaN());
		(&V_0)->___unit_1 = 3;
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_0 = V_0;
		V_1 = L_0;
		goto IL_0021;
	}

IL_0021:
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_1 = V_1;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C YogaValue_Percent_m9AE97691AE76135B4BAD62C862884D5240D7C8C2 (float ___value0, const RuntimeMethod* method) 
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C V_0;
	memset((&V_0), 0, sizeof(V_0));
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C V_1;
	memset((&V_1), 0, sizeof(V_1));
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* G_B2_0 = NULL;
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* G_B1_0 = NULL;
	int32_t G_B3_0 = 0;
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C* G_B3_1 = NULL;
	{
		il2cpp_codegen_initobj((&V_0), sizeof(YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C));
		float L_0 = ___value0;
		(&V_0)->___value_0 = L_0;
		float L_1 = ___value0;
		bool L_2;
		L_2 = YogaConstants_IsUndefined_m315EAE3D71B71011D7AE90F2F5C0617AC55DEDD9(L_1, NULL);
		G_B1_0 = (&V_0);
		if (L_2)
		{
			G_B2_0 = (&V_0);
			goto IL_001e;
		}
	}
	{
		G_B3_0 = 2;
		G_B3_1 = G_B1_0;
		goto IL_001f;
	}

IL_001e:
	{
		G_B3_0 = 0;
		G_B3_1 = G_B2_0;
	}

IL_001f:
	{
		G_B3_1->___unit_1 = G_B3_0;
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_3 = V_0;
		V_1 = L_3;
		goto IL_0028;
	}

IL_0028:
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_4 = V_1;
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C YogaValue_op_Implicit_mEDC38BD42737237B50A97DB49530A6DDE4E10DA3 (float ___pointValue0, const RuntimeMethod* method) 
{
	YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = ___pointValue0;
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_1;
		L_1 = YogaValue_Point_mA1955877796F9582C8F3B9ADDA817CD2B87E613E(L_0, NULL);
		V_0 = L_1;
		goto IL_000a;
	}

IL_000a:
	{
		YogaValue_t9066126971BFC18D9B4A8AB11435557F19598F8C L_2 = V_0;
		return L_2;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t UIPainter2D_Create_m2BEB468BFF2D7C82710F14648680986BE525EF02 (float ___maxArcRadius0, const RuntimeMethod* method) 
{
	typedef intptr_t (*UIPainter2D_Create_m2BEB468BFF2D7C82710F14648680986BE525EF02_ftn) (float);
	static UIPainter2D_Create_m2BEB468BFF2D7C82710F14648680986BE525EF02_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (UIPainter2D_Create_m2BEB468BFF2D7C82710F14648680986BE525EF02_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIPainter2D::Create(System.Single)");
	intptr_t icallRetVal = _il2cpp_icall_func(___maxArcRadius0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UIPainter2D_Destroy_mE24EE0D191DBD6733A41DB3876626CF955F94F3C (intptr_t ___handle0, const RuntimeMethod* method) 
{
	typedef void (*UIPainter2D_Destroy_mE24EE0D191DBD6733A41DB3876626CF955F94F3C_ftn) (intptr_t);
	static UIPainter2D_Destroy_mE24EE0D191DBD6733A41DB3876626CF955F94F3C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (UIPainter2D_Destroy_mE24EE0D191DBD6733A41DB3876626CF955F94F3C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIPainter2D::Destroy(System.IntPtr)");
	_il2cpp_icall_func(___handle0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UIPainter2D_Reset_mE80EE1E232371F88D6C0EFED325967F9994E8BFD (intptr_t ___handle0, const RuntimeMethod* method) 
{
	typedef void (*UIPainter2D_Reset_mE80EE1E232371F88D6C0EFED325967F9994E8BFD_ftn) (intptr_t);
	static UIPainter2D_Reset_mE80EE1E232371F88D6C0EFED325967F9994E8BFD_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (UIPainter2D_Reset_mE80EE1E232371F88D6C0EFED325967F9994E8BFD_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIPainter2D::Reset(System.IntPtr)");
	_il2cpp_icall_func(___handle0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UIElementsRuntimeUtilityNative_RepaintOverlayPanels_m9F9B960B858876372942CEADDB1527DF98503A9D (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B2_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B1_0 = NULL;
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_StaticFields*)il2cpp_codegen_static_fields_for(UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_il2cpp_TypeInfo_var))->___RepaintOverlayPanelsCallback_0;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0012;
	}

IL_000c:
	{
		NullCheck(G_B2_0);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(G_B2_0, NULL);
	}

IL_0012:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UIElementsRuntimeUtilityNative_UpdateRuntimePanels_mADFB4DA9D98A7A7A5D9DA06C4870560FA96910F9 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B2_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B1_0 = NULL;
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_StaticFields*)il2cpp_codegen_static_fields_for(UIElementsRuntimeUtilityNative_t9DE2C23158D553BB693212D0D8AEAE8594E75938_il2cpp_TypeInfo_var))->___UpdateRuntimePanelsCallback_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0012;
	}

IL_000c:
	{
		NullCheck(G_B2_0);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(G_B2_0, NULL);
	}

IL_0012:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UIElementsRuntimeUtilityNative_RegisterPlayerloopCallback_mF2DB7B25BFB9E0EC485CD6EDA1DABFEDA61C68F6 (const RuntimeMethod* method) 
{
	typedef void (*UIElementsRuntimeUtilityNative_RegisterPlayerloopCallback_mF2DB7B25BFB9E0EC485CD6EDA1DABFEDA61C68F6_ftn) ();
	static UIElementsRuntimeUtilityNative_RegisterPlayerloopCallback_mF2DB7B25BFB9E0EC485CD6EDA1DABFEDA61C68F6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (UIElementsRuntimeUtilityNative_RegisterPlayerloopCallback_mF2DB7B25BFB9E0EC485CD6EDA1DABFEDA61C68F6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIElementsRuntimeUtilityNative::RegisterPlayerloopCallback()");
	_il2cpp_icall_func();
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UIElementsRuntimeUtilityNative_UnregisterPlayerloopCallback_mBA667716C3B6341DF99E03EB4F760463A42BE9DA (const RuntimeMethod* method) 
{
	typedef void (*UIElementsRuntimeUtilityNative_UnregisterPlayerloopCallback_mBA667716C3B6341DF99E03EB4F760463A42BE9DA_ftn) ();
	static UIElementsRuntimeUtilityNative_UnregisterPlayerloopCallback_mBA667716C3B6341DF99E03EB4F760463A42BE9DA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (UIElementsRuntimeUtilityNative_UnregisterPlayerloopCallback_mBA667716C3B6341DF99E03EB4F760463A42BE9DA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIElementsRuntimeUtilityNative::UnregisterPlayerloopCallback()");
	_il2cpp_icall_func();
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UIElementsRuntimeUtilityNative_VisualElementCreation_mC2040C48791455FEF1ED2E80174A2D075CDA993D (const RuntimeMethod* method) 
{
	typedef void (*UIElementsRuntimeUtilityNative_VisualElementCreation_mC2040C48791455FEF1ED2E80174A2D075CDA993D_ftn) ();
	static UIElementsRuntimeUtilityNative_VisualElementCreation_mC2040C48791455FEF1ED2E80174A2D075CDA993D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (UIElementsRuntimeUtilityNative_VisualElementCreation_mC2040C48791455FEF1ED2E80174A2D075CDA993D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIElementsRuntimeUtilityNative::VisualElementCreation()");
	_il2cpp_icall_func();
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_add_GraphicsResourcesRecreate_m11A4A0B4368B22DE41056758D2A4208AB871DF54 (Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* V_0 = NULL;
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* V_1 = NULL;
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___GraphicsResourcesRecreate_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_1 = V_0;
		V_1 = L_1;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_2 = V_1;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m8B9D24CED35033C7FC56501DFE650F5CB7FF012C(L_2, L_3, NULL);
		V_2 = ((Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*)Castclass((RuntimeObject*)L_4, Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_5 = V_2;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_6 = V_1;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___GraphicsResourcesRecreate_0), L_5, L_6);
		V_0 = L_7;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_8 = V_0;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*)L_8) == ((RuntimeObject*)(Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_remove_GraphicsResourcesRecreate_m7EFCE9A98AA841D4CAC8F1781359500A32559105 (Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* V_0 = NULL;
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* V_1 = NULL;
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___GraphicsResourcesRecreate_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_1 = V_0;
		V_1 = L_1;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_2 = V_1;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m40506877934EC1AD4ADAE57F5E97AF0BC0F96116(L_2, L_3, NULL);
		V_2 = ((Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*)Castclass((RuntimeObject*)L_4, Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_5 = V_2;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_6 = V_1;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___GraphicsResourcesRecreate_0), L_5, L_6);
		V_0 = L_7;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_8 = V_0;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*)L_8) == ((RuntimeObject*)(Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_add_EngineUpdate_mFD3568341033913331E4CAA041B0A0F5E78D58B0 (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_1 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___EngineUpdate_1;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = V_0;
		V_1 = L_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_2 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m8B9D24CED35033C7FC56501DFE650F5CB7FF012C(L_2, L_3, NULL);
		V_2 = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_4, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_5 = V_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___EngineUpdate_1), L_5, L_6);
		V_0 = L_7;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_8 = V_0;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_8) == ((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_remove_EngineUpdate_mFCD631B1906D9C0B0162B359F5D27D4B569C3971 (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_1 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___EngineUpdate_1;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = V_0;
		V_1 = L_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_2 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m40506877934EC1AD4ADAE57F5E97AF0BC0F96116(L_2, L_3, NULL);
		V_2 = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_4, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_5 = V_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___EngineUpdate_1), L_5, L_6);
		V_0 = L_7;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_8 = V_0;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_8) == ((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_add_FlushPendingResources_m0603289F1CA8051CA6248A8A3769EF185113A768 (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_1 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___FlushPendingResources_2;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = V_0;
		V_1 = L_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_2 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m8B9D24CED35033C7FC56501DFE650F5CB7FF012C(L_2, L_3, NULL);
		V_2 = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_4, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_5 = V_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___FlushPendingResources_2), L_5, L_6);
		V_0 = L_7;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_8 = V_0;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_8) == ((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_remove_FlushPendingResources_m1547E32B87BD90E968B2E8B51B2AD206C1A3A311 (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_1 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___FlushPendingResources_2;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = V_0;
		V_1 = L_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_2 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m40506877934EC1AD4ADAE57F5E97AF0BC0F96116(L_2, L_3, NULL);
		V_2 = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_4, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_5 = V_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___FlushPendingResources_2), L_5, L_6);
		V_0 = L_7;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_8 = V_0;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_8) == ((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_add_RegisterIntermediateRenderers_m7B68C3555B2795D696838A82FB7F7F3F1BDD0A0A (Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* V_0 = NULL;
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* V_1 = NULL;
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RegisterIntermediateRenderers_3;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_1 = V_0;
		V_1 = L_1;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_2 = V_1;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m8B9D24CED35033C7FC56501DFE650F5CB7FF012C(L_2, L_3, NULL);
		V_2 = ((Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*)Castclass((RuntimeObject*)L_4, Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_5 = V_2;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_6 = V_1;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RegisterIntermediateRenderers_3), L_5, L_6);
		V_0 = L_7;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_8 = V_0;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*)L_8) == ((RuntimeObject*)(Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_remove_RegisterIntermediateRenderers_m33218BE02318488C8196C0C4B314809B5BA15B1B (Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* V_0 = NULL;
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* V_1 = NULL;
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RegisterIntermediateRenderers_3;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_1 = V_0;
		V_1 = L_1;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_2 = V_1;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m40506877934EC1AD4ADAE57F5E97AF0BC0F96116(L_2, L_3, NULL);
		V_2 = ((Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*)Castclass((RuntimeObject*)L_4, Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_5 = V_2;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_6 = V_1;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RegisterIntermediateRenderers_3), L_5, L_6);
		V_0 = L_7;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_8 = V_0;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*)L_8) == ((RuntimeObject*)(Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_add_RenderNodeExecute_mC630B888D39B3CE6D6B254491C9992451FAECD77 (Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* V_0 = NULL;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* V_1 = NULL;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RenderNodeExecute_5;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_1 = V_0;
		V_1 = L_1;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_2 = V_1;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m8B9D24CED35033C7FC56501DFE650F5CB7FF012C(L_2, L_3, NULL);
		V_2 = ((Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*)Castclass((RuntimeObject*)L_4, Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_5 = V_2;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_6 = V_1;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RenderNodeExecute_5), L_5, L_6);
		V_0 = L_7;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_8 = V_0;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*)L_8) == ((RuntimeObject*)(Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_remove_RenderNodeExecute_m3C6D90276B125884F2B00A025ABC14AA76049C8A (Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* V_0 = NULL;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* V_1 = NULL;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* V_2 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RenderNodeExecute_5;
		V_0 = L_0;
	}

IL_0006:
	{
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_1 = V_0;
		V_1 = L_1;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_2 = V_1;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m40506877934EC1AD4ADAE57F5E97AF0BC0F96116(L_2, L_3, NULL);
		V_2 = ((Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*)Castclass((RuntimeObject*)L_4, Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2_il2cpp_TypeInfo_var));
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_5 = V_2;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_6 = V_1;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_7;
		L_7 = InterlockedCompareExchangeImpl<Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*>((&((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RenderNodeExecute_5), L_5, L_6);
		V_0 = L_7;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_8 = V_0;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_9 = V_1;
		if ((!(((RuntimeObject*)(Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*)L_8) == ((RuntimeObject*)(Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RaiseGraphicsResourcesRecreate_m0501A6352C072455A5524B718A859768DD71B373 (bool ___recreate0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* G_B2_0 = NULL;
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* G_B1_0 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___GraphicsResourcesRecreate_0;
		Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0013;
	}

IL_000c:
	{
		bool L_2 = ___recreate0;
		NullCheck(G_B2_0);
		Action_1_Invoke_m69C8773D6967F3B224777183E24EA621CE056F8F_inline(G_B2_0, L_2, NULL);
	}

IL_0013:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RaiseEngineUpdate_mDEB8F6DCB0D42B6FDBF178D51F3AAAE5E7726CEB (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___EngineUpdate_1;
		V_0 = (bool)((!(((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_001a;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_2 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___EngineUpdate_1;
		NullCheck(L_2);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(L_2, NULL);
	}

IL_001a:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RaiseFlushPendingResources_m7F4B9153DB09CE954D0625F04C2682CDC65A58C2 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B2_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* G_B1_0 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___FlushPendingResources_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0012;
	}

IL_000c:
	{
		NullCheck(G_B2_0);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(G_B2_0, NULL);
	}

IL_0012:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RaiseRegisterIntermediateRenderers_mCF9B113F6CBF24039CD28343E6FDE82ABB78D18B (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___camera0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* G_B2_0 = NULL;
	Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* G_B1_0 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RegisterIntermediateRenderers_3;
		Action_1_t268986DA4CF361AC17B40338506A83AFB35832EA* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0013;
	}

IL_000c:
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_2 = ___camera0;
		NullCheck(G_B2_0);
		Action_1_Invoke_mCEB98AA7C8ED536CE7A592667637829D2D609DCF_inline(G_B2_0, L_2, NULL);
	}

IL_0013:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RaiseRenderNodeAdd_mBEFE7A4093DD6669BE5FDF15C6A3808881D6D0C5 (intptr_t ___userData0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* G_B2_0 = NULL;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* G_B1_0 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RenderNodeAdd_4;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0013;
	}

IL_000c:
	{
		intptr_t L_2 = ___userData0;
		NullCheck(G_B2_0);
		Action_1_Invoke_m783EC8C62449882812B741E4DE67BF3106686D9C_inline(G_B2_0, L_2, NULL);
	}

IL_0013:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RaiseRenderNodeExecute_m8A18D92E0CB6FA1CD0AA1E439164142F56705798 (intptr_t ___userData0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* G_B2_0 = NULL;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* G_B1_0 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RenderNodeExecute_5;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0013;
	}

IL_000c:
	{
		intptr_t L_2 = ___userData0;
		NullCheck(G_B2_0);
		Action_1_Invoke_m783EC8C62449882812B741E4DE67BF3106686D9C_inline(G_B2_0, L_2, NULL);
	}

IL_0013:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RaiseRenderNodeCleanup_mEF4A55AD5C19506566901C4CD5CFC29C1FD3EBA7 (intptr_t ___userData0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* G_B2_0 = NULL;
	Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* G_B1_0 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_0 = ((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___RenderNodeCleanup_6;
		Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000c;
		}
	}
	{
		goto IL_0013;
	}

IL_000c:
	{
		intptr_t L_2 = ___userData0;
		NullCheck(G_B2_0);
		Action_1_Invoke_m783EC8C62449882812B741E4DE67BF3106686D9C_inline(G_B2_0, L_2, NULL);
	}

IL_0013:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Utility_AllocateBuffer_m79C0A0B1748A573ABF499E8589F206628F06005C (int32_t ___elementCount0, int32_t ___elementStride1, bool ___vertexBuffer2, const RuntimeMethod* method) 
{
	typedef intptr_t (*Utility_AllocateBuffer_m79C0A0B1748A573ABF499E8589F206628F06005C_ftn) (int32_t, int32_t, bool);
	static Utility_AllocateBuffer_m79C0A0B1748A573ABF499E8589F206628F06005C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_AllocateBuffer_m79C0A0B1748A573ABF499E8589F206628F06005C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::AllocateBuffer(System.Int32,System.Int32,System.Boolean)");
	intptr_t icallRetVal = _il2cpp_icall_func(___elementCount0, ___elementStride1, ___vertexBuffer2);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_FreeBuffer_m710B8442D3809F3E10202F0FD5076A6C63B92F7C (intptr_t ___buffer0, const RuntimeMethod* method) 
{
	typedef void (*Utility_FreeBuffer_m710B8442D3809F3E10202F0FD5076A6C63B92F7C_ftn) (intptr_t);
	static Utility_FreeBuffer_m710B8442D3809F3E10202F0FD5076A6C63B92F7C_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_FreeBuffer_m710B8442D3809F3E10202F0FD5076A6C63B92F7C_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::FreeBuffer(System.IntPtr)");
	_il2cpp_icall_func(___buffer0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_UpdateBufferRanges_m7E4FAAD598CA0D57796007E65D2822A781F0B07A (intptr_t ___buffer0, intptr_t ___ranges1, int32_t ___rangeCount2, int32_t ___writeRangeStart3, int32_t ___writeRangeEnd4, const RuntimeMethod* method) 
{
	typedef void (*Utility_UpdateBufferRanges_m7E4FAAD598CA0D57796007E65D2822A781F0B07A_ftn) (intptr_t, intptr_t, int32_t, int32_t, int32_t);
	static Utility_UpdateBufferRanges_m7E4FAAD598CA0D57796007E65D2822A781F0B07A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_UpdateBufferRanges_m7E4FAAD598CA0D57796007E65D2822A781F0B07A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::UpdateBufferRanges(System.IntPtr,System.IntPtr,System.Int32,System.Int32,System.Int32)");
	_il2cpp_icall_func(___buffer0, ___ranges1, ___rangeCount2, ___writeRangeStart3, ___writeRangeEnd4);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_SetVectorArray_m6C8F08342C9D3D33A183B29536DA13B07E2763FA (MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* ___props0, int32_t ___name1, intptr_t ___vector4s2, int32_t ___count3, const RuntimeMethod* method) 
{
	typedef void (*Utility_SetVectorArray_m6C8F08342C9D3D33A183B29536DA13B07E2763FA_ftn) (MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D*, int32_t, intptr_t, int32_t);
	static Utility_SetVectorArray_m6C8F08342C9D3D33A183B29536DA13B07E2763FA_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_SetVectorArray_m6C8F08342C9D3D33A183B29536DA13B07E2763FA_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::SetVectorArray(UnityEngine.MaterialPropertyBlock,System.Int32,System.IntPtr,System.Int32)");
	_il2cpp_icall_func(___props0, ___name1, ___vector4s2, ___count3);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Utility_GetVertexDeclaration_mE471CC1D9A47B11E64E4DF232E0732FAF8B1AF33 (VertexAttributeDescriptorU5BU5D_t5D10E60612F12777F59B7E33939F9075DB0E02B2* ___vertexAttributes0, const RuntimeMethod* method) 
{
	typedef intptr_t (*Utility_GetVertexDeclaration_mE471CC1D9A47B11E64E4DF232E0732FAF8B1AF33_ftn) (VertexAttributeDescriptorU5BU5D_t5D10E60612F12777F59B7E33939F9075DB0E02B2*);
	static Utility_GetVertexDeclaration_mE471CC1D9A47B11E64E4DF232E0732FAF8B1AF33_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_GetVertexDeclaration_mE471CC1D9A47B11E64E4DF232E0732FAF8B1AF33_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::GetVertexDeclaration(UnityEngine.Rendering.VertexAttributeDescriptor[])");
	intptr_t icallRetVal = _il2cpp_icall_func(___vertexAttributes0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RegisterIntermediateRenderer_m46C340A1198D0D39E65E65550B9D697BAAB1F617 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___camera0, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___material1, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___transform2, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___aabb3, int32_t ___renderLayer4, int32_t ___shadowCasting5, bool ___receiveShadows6, int32_t ___sameDistanceSortPriority7, uint64_t ___sceneCullingMask8, int32_t ___rendererCallbackFlags9, intptr_t ___userData10, int32_t ___userDataSize11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_0 = ___camera0;
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_1 = ___material1;
		int32_t L_2 = ___renderLayer4;
		int32_t L_3 = ___shadowCasting5;
		bool L_4 = ___receiveShadows6;
		int32_t L_5 = ___sameDistanceSortPriority7;
		uint64_t L_6 = ___sceneCullingMask8;
		int32_t L_7 = ___rendererCallbackFlags9;
		intptr_t L_8 = ___userData10;
		int32_t L_9 = ___userDataSize11;
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Utility_RegisterIntermediateRenderer_Injected_m95245CEE2B093C661065C6262AD1BD16CF171BE2(L_0, L_1, (&___transform2), (&___aabb3), L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_DrawRanges_m5C054AC5885504B35399A861D70E9492DBC957A6 (intptr_t ___ib0, intptr_t* ___vertexStreams1, int32_t ___streamCount2, intptr_t ___ranges3, int32_t ___rangeCount4, intptr_t ___vertexDecl5, const RuntimeMethod* method) 
{
	typedef void (*Utility_DrawRanges_m5C054AC5885504B35399A861D70E9492DBC957A6_ftn) (intptr_t, intptr_t*, int32_t, intptr_t, int32_t, intptr_t);
	static Utility_DrawRanges_m5C054AC5885504B35399A861D70E9492DBC957A6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_DrawRanges_m5C054AC5885504B35399A861D70E9492DBC957A6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::DrawRanges(System.IntPtr,System.IntPtr*,System.Int32,System.IntPtr,System.Int32,System.IntPtr)");
	_il2cpp_icall_func(___ib0, ___vertexStreams1, ___streamCount2, ___ranges3, ___rangeCount4, ___vertexDecl5);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_SetPropertyBlock_m186F7D4B9C21DB895748F5B7E01F5AB6DB286AA5 (MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D* ___props0, const RuntimeMethod* method) 
{
	typedef void (*Utility_SetPropertyBlock_m186F7D4B9C21DB895748F5B7E01F5AB6DB286AA5_ftn) (MaterialPropertyBlock_t2308669579033A857EFE6E4831909F638B27411D*);
	static Utility_SetPropertyBlock_m186F7D4B9C21DB895748F5B7E01F5AB6DB286AA5_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_SetPropertyBlock_m186F7D4B9C21DB895748F5B7E01F5AB6DB286AA5_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::SetPropertyBlock(UnityEngine.MaterialPropertyBlock)");
	_il2cpp_icall_func(___props0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_SetScissorRect_m088F8070879B9480C4A6E12EB3229E9EEB718245 (RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 ___scissorRect0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Utility_SetScissorRect_Injected_m713B7CE9313C2696047C98A6AFC339C8BAFA8993((&___scissorRect0), NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_DisableScissor_m2FD26952211AEA29D4AD48204857F4C096E8B6B6 (const RuntimeMethod* method) 
{
	typedef void (*Utility_DisableScissor_m2FD26952211AEA29D4AD48204857F4C096E8B6B6_ftn) ();
	static Utility_DisableScissor_m2FD26952211AEA29D4AD48204857F4C096E8B6B6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_DisableScissor_m2FD26952211AEA29D4AD48204857F4C096E8B6B6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::DisableScissor()");
	_il2cpp_icall_func();
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Utility_CreateStencilState_m41C69707D8046FB8BE53B7866A7370AA9A1BB871 (StencilState_tBE5F7C1134E50C5E93B45A626D4FB4690F1C91A9 ___stencilState0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		intptr_t L_0;
		L_0 = Utility_CreateStencilState_Injected_mF7304A13703CB8BBC4E5E2CE66EAF56AEC117C8B((&___stencilState0), NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_SetStencilState_m7F941AD337300C43989A9096E9396E3CC7D6979D (intptr_t ___stencilState0, int32_t ___stencilRef1, const RuntimeMethod* method) 
{
	typedef void (*Utility_SetStencilState_m7F941AD337300C43989A9096E9396E3CC7D6979D_ftn) (intptr_t, int32_t);
	static Utility_SetStencilState_m7F941AD337300C43989A9096E9396E3CC7D6979D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_SetStencilState_m7F941AD337300C43989A9096E9396E3CC7D6979D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::SetStencilState(System.IntPtr,System.Int32)");
	_il2cpp_icall_func(___stencilState0, ___stencilRef1);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Utility_HasMappedBufferRange_m43535D979D7B03DAE2140D2A4DDF29A9B77CB92B (const RuntimeMethod* method) 
{
	typedef bool (*Utility_HasMappedBufferRange_m43535D979D7B03DAE2140D2A4DDF29A9B77CB92B_ftn) ();
	static Utility_HasMappedBufferRange_m43535D979D7B03DAE2140D2A4DDF29A9B77CB92B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_HasMappedBufferRange_m43535D979D7B03DAE2140D2A4DDF29A9B77CB92B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::HasMappedBufferRange()");
	bool icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t Utility_InsertCPUFence_m8200A4F7724581FDE487AF45E4D9B6B9FFEF883E (const RuntimeMethod* method) 
{
	typedef uint32_t (*Utility_InsertCPUFence_m8200A4F7724581FDE487AF45E4D9B6B9FFEF883E_ftn) ();
	static Utility_InsertCPUFence_m8200A4F7724581FDE487AF45E4D9B6B9FFEF883E_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_InsertCPUFence_m8200A4F7724581FDE487AF45E4D9B6B9FFEF883E_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::InsertCPUFence()");
	uint32_t icallRetVal = _il2cpp_icall_func();
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Utility_CPUFencePassed_mF2311BE2687767B2BD1952FBFC46E6BBA7753969 (uint32_t ___fence0, const RuntimeMethod* method) 
{
	typedef bool (*Utility_CPUFencePassed_mF2311BE2687767B2BD1952FBFC46E6BBA7753969_ftn) (uint32_t);
	static Utility_CPUFencePassed_mF2311BE2687767B2BD1952FBFC46E6BBA7753969_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_CPUFencePassed_mF2311BE2687767B2BD1952FBFC46E6BBA7753969_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::CPUFencePassed(System.UInt32)");
	bool icallRetVal = _il2cpp_icall_func(___fence0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_WaitForCPUFencePassed_mACEE12861CF9457367124C6137464CD2D8F3CB36 (uint32_t ___fence0, const RuntimeMethod* method) 
{
	typedef void (*Utility_WaitForCPUFencePassed_mACEE12861CF9457367124C6137464CD2D8F3CB36_ftn) (uint32_t);
	static Utility_WaitForCPUFencePassed_mACEE12861CF9457367124C6137464CD2D8F3CB36_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_WaitForCPUFencePassed_mACEE12861CF9457367124C6137464CD2D8F3CB36_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::WaitForCPUFencePassed(System.UInt32)");
	_il2cpp_icall_func(___fence0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_SyncRenderThread_mBC093FC01ADBC4307BABCE385DC19B2C6C38F65F (const RuntimeMethod* method) 
{
	typedef void (*Utility_SyncRenderThread_mBC093FC01ADBC4307BABCE385DC19B2C6C38F65F_ftn) ();
	static Utility_SyncRenderThread_mBC093FC01ADBC4307BABCE385DC19B2C6C38F65F_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_SyncRenderThread_mBC093FC01ADBC4307BABCE385DC19B2C6C38F65F_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::SyncRenderThread()");
	_il2cpp_icall_func();
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 Utility_GetActiveViewport_m6219330120AEDFC96C9AA0EE75023E9431EB189D (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Utility_GetActiveViewport_Injected_m60650AF751F179D62E35B34CCC6E2068291F0CB0((&V_0), NULL);
		RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8 L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_ProfileDrawChainBegin_m1105D022C7484592F020401C02ABEDA4237BD6DF (const RuntimeMethod* method) 
{
	typedef void (*Utility_ProfileDrawChainBegin_m1105D022C7484592F020401C02ABEDA4237BD6DF_ftn) ();
	static Utility_ProfileDrawChainBegin_m1105D022C7484592F020401C02ABEDA4237BD6DF_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_ProfileDrawChainBegin_m1105D022C7484592F020401C02ABEDA4237BD6DF_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::ProfileDrawChainBegin()");
	_il2cpp_icall_func();
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_ProfileDrawChainEnd_m6445051B594B0DDCD869D4751398DAD3AAA28A01 (const RuntimeMethod* method) 
{
	typedef void (*Utility_ProfileDrawChainEnd_m6445051B594B0DDCD869D4751398DAD3AAA28A01_ftn) ();
	static Utility_ProfileDrawChainEnd_m6445051B594B0DDCD869D4751398DAD3AAA28A01_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_ProfileDrawChainEnd_m6445051B594B0DDCD869D4751398DAD3AAA28A01_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::ProfileDrawChainEnd()");
	_il2cpp_icall_func();
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_NotifyOfUIREvents_mB355BB746BD3C095223AB96CC5C39669A61C922B (bool ___subscribe0, const RuntimeMethod* method) 
{
	typedef void (*Utility_NotifyOfUIREvents_mB355BB746BD3C095223AB96CC5C39669A61C922B_ftn) (bool);
	static Utility_NotifyOfUIREvents_mB355BB746BD3C095223AB96CC5C39669A61C922B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_NotifyOfUIREvents_mB355BB746BD3C095223AB96CC5C39669A61C922B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::NotifyOfUIREvents(System.Boolean)");
	_il2cpp_icall_func(___subscribe0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Utility_GetUnityProjectionMatrix_mA019D5445D1641B0CD89A79DDDE8B1B7E5FE0EBB (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		il2cpp_codegen_runtime_class_init_inline(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		Utility_GetUnityProjectionMatrix_Injected_m8DE89F47F848B2071774E05D2F23DA10435E643D((&V_0), NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility__cctor_mCB0529D224E4D67079BC12BA37789C20EE0D5980 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral3E4595538801AB36CCD7E4EFDA9DD0272DEA19EF);
		s_Il2CppMethodInitialized = true;
	}
	{
		ProfilerMarker_tA256E18DA86EDBC5528CE066FC91C96EE86501AD L_0;
		memset((&L_0), 0, sizeof(L_0));
		ProfilerMarker__ctor_mDD68B0A8B71E0301F592AF8891560150E55699C8_inline((&L_0), _stringLiteral3E4595538801AB36CCD7E4EFDA9DD0272DEA19EF, NULL);
		((Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_StaticFields*)il2cpp_codegen_static_fields_for(Utility_t8BCC393462C6270211734BE47CF5350F05EC97AD_il2cpp_TypeInfo_var))->___s_MarkerRaiseEngineUpdate_7 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_RegisterIntermediateRenderer_Injected_m95245CEE2B093C661065C6262AD1BD16CF171BE2 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___camera0, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___material1, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* ___transform2, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* ___aabb3, int32_t ___renderLayer4, int32_t ___shadowCasting5, bool ___receiveShadows6, int32_t ___sameDistanceSortPriority7, uint64_t ___sceneCullingMask8, int32_t ___rendererCallbackFlags9, intptr_t ___userData10, int32_t ___userDataSize11, const RuntimeMethod* method) 
{
	typedef void (*Utility_RegisterIntermediateRenderer_Injected_m95245CEE2B093C661065C6262AD1BD16CF171BE2_ftn) (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3*, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6*, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3*, int32_t, int32_t, bool, int32_t, uint64_t, int32_t, intptr_t, int32_t);
	static Utility_RegisterIntermediateRenderer_Injected_m95245CEE2B093C661065C6262AD1BD16CF171BE2_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_RegisterIntermediateRenderer_Injected_m95245CEE2B093C661065C6262AD1BD16CF171BE2_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::RegisterIntermediateRenderer_Injected(UnityEngine.Camera,UnityEngine.Material,UnityEngine.Matrix4x4&,UnityEngine.Bounds&,System.Int32,System.Int32,System.Boolean,System.Int32,System.UInt64,System.Int32,System.IntPtr,System.Int32)");
	_il2cpp_icall_func(___camera0, ___material1, ___transform2, ___aabb3, ___renderLayer4, ___shadowCasting5, ___receiveShadows6, ___sameDistanceSortPriority7, ___sceneCullingMask8, ___rendererCallbackFlags9, ___userData10, ___userDataSize11);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_SetScissorRect_Injected_m713B7CE9313C2696047C98A6AFC339C8BAFA8993 (RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8* ___scissorRect0, const RuntimeMethod* method) 
{
	typedef void (*Utility_SetScissorRect_Injected_m713B7CE9313C2696047C98A6AFC339C8BAFA8993_ftn) (RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8*);
	static Utility_SetScissorRect_Injected_m713B7CE9313C2696047C98A6AFC339C8BAFA8993_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_SetScissorRect_Injected_m713B7CE9313C2696047C98A6AFC339C8BAFA8993_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::SetScissorRect_Injected(UnityEngine.RectInt&)");
	_il2cpp_icall_func(___scissorRect0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR intptr_t Utility_CreateStencilState_Injected_mF7304A13703CB8BBC4E5E2CE66EAF56AEC117C8B (StencilState_tBE5F7C1134E50C5E93B45A626D4FB4690F1C91A9* ___stencilState0, const RuntimeMethod* method) 
{
	typedef intptr_t (*Utility_CreateStencilState_Injected_mF7304A13703CB8BBC4E5E2CE66EAF56AEC117C8B_ftn) (StencilState_tBE5F7C1134E50C5E93B45A626D4FB4690F1C91A9*);
	static Utility_CreateStencilState_Injected_mF7304A13703CB8BBC4E5E2CE66EAF56AEC117C8B_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_CreateStencilState_Injected_mF7304A13703CB8BBC4E5E2CE66EAF56AEC117C8B_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::CreateStencilState_Injected(UnityEngine.Rendering.StencilState&)");
	intptr_t icallRetVal = _il2cpp_icall_func(___stencilState0);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_GetActiveViewport_Injected_m60650AF751F179D62E35B34CCC6E2068291F0CB0 (RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8* ___ret0, const RuntimeMethod* method) 
{
	typedef void (*Utility_GetActiveViewport_Injected_m60650AF751F179D62E35B34CCC6E2068291F0CB0_ftn) (RectInt_t1744D10E1063135DA9D574F95205B98DAC600CB8*);
	static Utility_GetActiveViewport_Injected_m60650AF751F179D62E35B34CCC6E2068291F0CB0_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_GetActiveViewport_Injected_m60650AF751F179D62E35B34CCC6E2068291F0CB0_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::GetActiveViewport_Injected(UnityEngine.RectInt&)");
	_il2cpp_icall_func(___ret0);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Utility_GetUnityProjectionMatrix_Injected_m8DE89F47F848B2071774E05D2F23DA10435E643D (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* ___ret0, const RuntimeMethod* method) 
{
	typedef void (*Utility_GetUnityProjectionMatrix_Injected_m8DE89F47F848B2071774E05D2F23DA10435E643D_ftn) (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6*);
	static Utility_GetUnityProjectionMatrix_Injected_m8DE89F47F848B2071774E05D2F23DA10435E643D_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (Utility_GetUnityProjectionMatrix_Injected_m8DE89F47F848B2071774E05D2F23DA10435E643D_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.Utility::GetUnityProjectionMatrix_Injected(UnityEngine.Matrix4x4&)");
	_il2cpp_icall_func(___ret0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 JobProcessor_ScheduleNudgeJobs_m66D15256827ABD6085A43440DDDF27DAF4A64DA9 (intptr_t ___buffer0, int32_t ___jobCount1, const RuntimeMethod* method) 
{
	JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		intptr_t L_0 = ___buffer0;
		int32_t L_1 = ___jobCount1;
		JobProcessor_ScheduleNudgeJobs_Injected_mC7B666DCC73B067A211EE6BFBF285A2B6C0D65D4(L_0, L_1, (&V_0), NULL);
		JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 JobProcessor_ScheduleConvertMeshJobs_m24049B4C1B205F5D5BD7FB8ABF5B60718FDFD748 (intptr_t ___buffer0, int32_t ___jobCount1, const RuntimeMethod* method) 
{
	JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		intptr_t L_0 = ___buffer0;
		int32_t L_1 = ___jobCount1;
		JobProcessor_ScheduleConvertMeshJobs_Injected_mD2E53BA62D67928253C21A40FB6D4C093D753037(L_0, L_1, (&V_0), NULL);
		JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 JobProcessor_ScheduleCopyClosingMeshJobs_m38A8E0F914F8050BFFF8D905C5D1DBF1679DDAC8 (intptr_t ___buffer0, int32_t ___jobCount1, const RuntimeMethod* method) 
{
	JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		intptr_t L_0 = ___buffer0;
		int32_t L_1 = ___jobCount1;
		JobProcessor_ScheduleCopyClosingMeshJobs_Injected_mF4E9EF047BB15991B068DBFF4064BD7623098DA6(L_0, L_1, (&V_0), NULL);
		JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08 L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JobProcessor_ScheduleNudgeJobs_Injected_mC7B666DCC73B067A211EE6BFBF285A2B6C0D65D4 (intptr_t ___buffer0, int32_t ___jobCount1, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08* ___ret2, const RuntimeMethod* method) 
{
	typedef void (*JobProcessor_ScheduleNudgeJobs_Injected_mC7B666DCC73B067A211EE6BFBF285A2B6C0D65D4_ftn) (intptr_t, int32_t, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08*);
	static JobProcessor_ScheduleNudgeJobs_Injected_mC7B666DCC73B067A211EE6BFBF285A2B6C0D65D4_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (JobProcessor_ScheduleNudgeJobs_Injected_mC7B666DCC73B067A211EE6BFBF285A2B6C0D65D4_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.JobProcessor::ScheduleNudgeJobs_Injected(System.IntPtr,System.Int32,Unity.Jobs.JobHandle&)");
	_il2cpp_icall_func(___buffer0, ___jobCount1, ___ret2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JobProcessor_ScheduleConvertMeshJobs_Injected_mD2E53BA62D67928253C21A40FB6D4C093D753037 (intptr_t ___buffer0, int32_t ___jobCount1, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08* ___ret2, const RuntimeMethod* method) 
{
	typedef void (*JobProcessor_ScheduleConvertMeshJobs_Injected_mD2E53BA62D67928253C21A40FB6D4C093D753037_ftn) (intptr_t, int32_t, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08*);
	static JobProcessor_ScheduleConvertMeshJobs_Injected_mD2E53BA62D67928253C21A40FB6D4C093D753037_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (JobProcessor_ScheduleConvertMeshJobs_Injected_mD2E53BA62D67928253C21A40FB6D4C093D753037_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.JobProcessor::ScheduleConvertMeshJobs_Injected(System.IntPtr,System.Int32,Unity.Jobs.JobHandle&)");
	_il2cpp_icall_func(___buffer0, ___jobCount1, ___ret2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JobProcessor_ScheduleCopyClosingMeshJobs_Injected_mF4E9EF047BB15991B068DBFF4064BD7623098DA6 (intptr_t ___buffer0, int32_t ___jobCount1, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08* ___ret2, const RuntimeMethod* method) 
{
	typedef void (*JobProcessor_ScheduleCopyClosingMeshJobs_Injected_mF4E9EF047BB15991B068DBFF4064BD7623098DA6_ftn) (intptr_t, int32_t, JobHandle_t5DF5F99902FED3C801A81C05205CEA6CE039EF08*);
	static JobProcessor_ScheduleCopyClosingMeshJobs_Injected_mF4E9EF047BB15991B068DBFF4064BD7623098DA6_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (JobProcessor_ScheduleCopyClosingMeshJobs_Injected_mF4E9EF047BB15991B068DBFF4064BD7623098DA6_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.UIElements.UIR.JobProcessor::ScheduleCopyClosingMeshJobs_Injected(System.IntPtr,System.Int32,Unity.Jobs.JobHandle&)");
	_il2cpp_icall_func(___buffer0, ___jobCount1, ___ret2);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Single_IsNaN_m684B090AA2F895FD91821CA8684CBC11D784E4DD_inline (float ___f0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		float L_0 = ___f0;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = BitConverter_SingleToInt32Bits_mA1902D40966CA4C89A8974B10E5680A06E88566B_inline(L_0, NULL);
		return (bool)((((int32_t)((int32_t)(L_1&((int32_t)2147483647LL)))) > ((int32_t)((int32_t)2139095040)))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA MeasureFunction_Invoke_m280560A27915B9D2F3D7E75056A63084925EEFCE_inline (MeasureFunction_t60EBED1328F5328D4FA7E26335967E59E73B4D09* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, int32_t ___widthMode2, float ___height3, int32_t ___heightMode4, const RuntimeMethod* method) 
{
	typedef YogaSize_tA276812CB1E90E7AA2028A9474EA6EA46B3B38EA (*FunctionPointerType) (RuntimeObject*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, int32_t, float, int32_t, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___node0, ___width1, ___widthMode2, ___height3, ___heightMode4, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float BaselineFunction_Invoke_m2DDB6CB96A11C1AF2F557FB363F99BA3A2E6E109_inline (BaselineFunction_t13AFADEF52F63320B2159C237635948AEB801679* __this, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA* ___node0, float ___width1, float ___height2, const RuntimeMethod* method) 
{
	typedef float (*FunctionPointerType) (RuntimeObject*, YogaNode_t4B5B593220CCB315B5A60CB48BA4795636F04DDA*, float, float, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___node0, ___width1, ___height2, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ProfilerMarker__ctor_mDD68B0A8B71E0301F592AF8891560150E55699C8_inline (ProfilerMarker_tA256E18DA86EDBC5528CE066FC91C96EE86501AD* __this, String_t* ___name0, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___name0;
		intptr_t L_1;
		L_1 = ProfilerUnsafeUtility_CreateMarker_m27DDE00D41B95677982DBFCE074D45B79E50C7CC(L_0, (uint16_t)1, 0, 0, NULL);
		__this->___m_Ptr_0 = L_1;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = (int32_t)__this->____size_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* Enumerable_Empty_TisRuntimeObject_m42BB34F154440C9F0AC402FC3E9BD08C8D678F21_gshared_inline (const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(method->rgctx_data, 2));
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_0 = ((EmptyEnumerable_1_t8C8873EF4F89FB0F86D91BA5B4D640E3A23AD28E_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(method->rgctx_data, 2)))->___Instance_0;
		return (RuntimeObject*)L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_m69C8773D6967F3B224777183E24EA621CE056F8F_gshared_inline (Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* __this, bool ___obj0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___obj0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___obj0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_m783EC8C62449882812B741E4DE67BF3106686D9C_gshared_inline (Action_1_t2DF1ED40E3084E997390FF52F462390882271FE2* __this, intptr_t ___obj0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, intptr_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___obj0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t BitConverter_SingleToInt32Bits_mA1902D40966CA4C89A8974B10E5680A06E88566B_inline (float ___value0, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = *((int32_t*)((uintptr_t)(&___value0)));
		return L_0;
	}
}
