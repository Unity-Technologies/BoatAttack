#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
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
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct InterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
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
template <typename R, typename T1>
struct InterfaceFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
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

struct Comparison_1_tEDDDA19F3EAE98490F38D2E8D4C34A6A6C593AA7;
struct Dictionary_2_tDFF23279733A30AC1A45EA9FEB8105F663D96705;
struct Dictionary_2_t29F94820877E2B83E48075DD7E4FB54F414D1F35;
struct Func_2_tAE218A7D889AC44BBCEC5E769D3C1F950095B512;
struct List_1_t899A658EFE11E82F22DA15F96306DABE3AFF7655;
struct List_1_t3895718121BD33A45F11A972C6A17E372C5FA43D;
struct List_1_tF512ECCA426FF10471372F52B5C8784FC96A7EAC;
struct List_1_t2C9A586FD2E1B8C67E6407386FCA1C121EC125B6;
struct List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
struct CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C;
struct StageU5BU5D_tF198CE3C6DE5C3D67552DAB4B9680F3BFF319981;
struct ItemU5BU5D_t60EF694EBD97EE6EE5145043113A4E06D1DCAC47;
struct TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1;
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354;
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA;
struct BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E;
struct CancellationTokenSource_tAAE1E0033BCFC233801F8CB4CED5C852B350CB7B;
struct Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0;
struct CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269;
struct CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E;
struct CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A;
struct CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A;
struct CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD;
struct CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065;
struct CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2;
struct CinemachineHardLockToTarget_tA87D10A864809C5E690916F194DBD61F8E64380A;
struct CinemachineHardLookAt_tF3F83D120480604E6173E3907DAA85CDEBB0FC8E;
struct CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303;
struct CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B;
struct CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D;
struct CinemachineSameAsFollowTarget_t3F3D720F4ED98F0E8608A0D077BB877F1A897141;
struct CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037;
struct CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5;
struct CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50;
struct CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE;
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3;
struct Delegate_t;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
struct HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA;
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
struct ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5;
struct ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82;
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE;
struct MethodInfo_t;
struct NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1;
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
struct PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E;
struct Rigidbody_t268697F5A994213ED97393309870968BC1C7393C;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct String_t;
struct StringBuilder_t;
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct IInputAxisProvider_tABB3BFF96A8D4C6D50FA42166CCF7AAF18F959E7;
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF;
struct BrainEvent_t849EB8BA11F9477DD4D1CCD463DF1C798A74B5E3;
struct VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154;
struct AxisInputDelegate_tE27958ACEDD7816DB591B6F485ACD7083541C452;
struct GetBlendOverrideDelegate_t36EFDCBF8770712A9E7B06F300B0C62C0C42B14A;
struct U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6;
struct UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60;
struct Appearance_t598AE4F607DDAB13B808E1D4ECEBE53E335967F8;
struct U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31;
struct CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC;
struct DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842;

IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IInputAxisProvider_tABB3BFF96A8D4C6D50FA42166CCF7AAF18F959E7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* RuntimeUtility_t29BFA2198191EF8D4466FBAC7EAB84A1F9702965_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* String_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral16DD21BE77B115D392226EB71A2D3A9FDC29E3F0;
IL2CPP_EXTERN_C String_t* _stringLiteral2386E77CF610F786B06A91AF2C1B3FD2282D2745;
IL2CPP_EXTERN_C String_t* _stringLiteral27C7727EAAAD675C621F6257F2BD5190CE343979;
IL2CPP_EXTERN_C String_t* _stringLiteral88BEE283254D7094E258B3A88730F4CC4F1E4AC7;
IL2CPP_EXTERN_C String_t* _stringLiteral9D254E50F4DE5BE7CA9E72BD2F890B87F910B88B;
IL2CPP_EXTERN_C String_t* _stringLiteral9F7A4B6C54C2F1E1424871D9ED5587D887F72E3C;
IL2CPP_EXTERN_C String_t* _stringLiteralD9691C4FD8A1F6B09DB1147CA32B442772FB46A1;
IL2CPP_EXTERN_C String_t* _stringLiteralE166C9564FBDE461738077E3B1B506525EB6ACCC;
IL2CPP_EXTERN_C const RuntimeMethod* Component_GetComponent_TisRigidbody_t268697F5A994213ED97393309870968BC1C7393C_m4B5CAD64B52D153BEA96432633CA9A45FA523DD8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m71F29A2B876EC3E6F1ACD24B3CEAEDA3FF79CB3F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec_U3C_ctorU3Eb__30_0_m9216ED998310150D666FF45C1BD6868BF4BF02DD_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE;;
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com;
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com;;
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke;
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke;;
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF;;
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com;
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com;;
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke;
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke;;

struct CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C;
struct TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

struct List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4  : public RuntimeObject
{
	CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C* ____items_1;
	int32_t ____size_2;
	int32_t ____version_3;
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4_StaticFields
{
	CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C* ___s_emptyArray_5;
};
struct Il2CppArrayBounds;

struct CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E  : public RuntimeObject
{
	RuntimeObject* ___CamA_0;
	RuntimeObject* ___CamB_1;
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___BlendCurve_2;
	float ___TimeInBlend_3;
	float ___Duration_4;
};

struct CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD  : public RuntimeObject
{
	List_1_t3895718121BD33A45F11A972C6A17E372C5FA43D* ___mActiveBrains_10;
	List_1_t2C9A586FD2E1B8C67E6407386FCA1C121EC125B6* ___mActiveCameras_11;
	bool ___m_ActiveCamerasAreSorted_12;
	int32_t ___m_ActivationSequence_13;
	List_1_t899A658EFE11E82F22DA15F96306DABE3AFF7655* ___mAllCameras_14;
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___mRoundRobinVcamLastFrame_15;
	Dictionary_2_tDFF23279733A30AC1A45EA9FEB8105F663D96705* ___mUpdateStatus_18;
	int32_t ___m_CurrentUpdateFilter_19;
};

struct CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_StaticFields
{
	int32_t ___kStreamingVersion_0;
	String_t* ___kVersionString_1;
	CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* ___sInstance_2;
	bool ___sShowHiddenObjects_3;
	AxisInputDelegate_tE27958ACEDD7816DB591B6F485ACD7083541C452* ___GetInputAxis_4;
	float ___UniformDeltaTimeOverride_5;
	float ___CurrentTimeOverride_6;
	GetBlendOverrideDelegate_t36EFDCBF8770712A9E7B06F300B0C62C0C42B14A* ___GetBlendOverride_7;
	BrainEvent_t849EB8BA11F9477DD4D1CCD463DF1C798A74B5E3* ___CameraUpdatedEvent_8;
	BrainEvent_t849EB8BA11F9477DD4D1CCD463DF1C798A74B5E3* ___CameraCutEvent_9;
	float ___s_LastUpdateTime_16;
	int32_t ___s_FixedFrameCount_17;
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

struct StringBuilder_t  : public RuntimeObject
{
	CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___m_ChunkChars_0;
	StringBuilder_t* ___m_ChunkPrevious_1;
	int32_t ___m_ChunkLength_2;
	int32_t ___m_ChunkOffset_3;
	int32_t ___m_MaxCapacity_4;
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

struct U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6  : public RuntimeObject
{
};

struct U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_StaticFields
{
	U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6* ___U3CU3E9_0;
	UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* ___U3CU3E9__30_0_1;
};

struct U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31  : public RuntimeObject
{
};

struct U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_StaticFields
{
	U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31* ___U3CU3E9_0;
	Comparison_1_tEDDDA19F3EAE98490F38D2E8D4C34A6A6C593AA7* ___U3CU3E9__38_0_1;
	Func_2_tAE218A7D889AC44BBCEC5E769D3C1F950095B512* ___U3CU3E9__47_0_2;
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

struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	double ___m_value_0;
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

struct LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB 
{
	int32_t ___m_Mask_0;
};

struct Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682 
{
	union
	{
		struct
		{
		};
		uint8_t Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682__padding[1];
	};
};

struct Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_StaticFields
{
	float ___Epsilon_0;
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

struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 
{
	float ___x_0;
	float ___y_1;
	float ___z_2;
	float ___w_3;
};

struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_StaticFields
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___identityQuaternion_4;
};

struct Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D 
{
	float ___m_XMin_0;
	float ___m_YMin_1;
	float ___m_Width_2;
	float ___m_Height_3;
};

struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value_0;
};

struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	float ___x_0;
	float ___y_1;
};

struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_StaticFields
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___zeroVector_2;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___oneVector_3;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___upVector_4;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___downVector_5;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___leftVector_6;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rightVector_7;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___positiveInfinityVector_8;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___negativeInfinityVector_9;
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

struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF 
{
	bool ___m_enabled_0;
	float ___m_WaitTime_1;
	float ___m_RecenteringTime_2;
	float ___mLastAxisInputTime_3;
	float ___mRecenteringVelocity_4;
	int32_t ___m_LegacyHeadingDefinition_5;
	int32_t ___m_LegacyVelocityFilterStrength_6;
};
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke
{
	int32_t ___m_enabled_0;
	float ___m_WaitTime_1;
	float ___m_RecenteringTime_2;
	float ___mLastAxisInputTime_3;
	float ___mRecenteringVelocity_4;
	int32_t ___m_LegacyHeadingDefinition_5;
	int32_t ___m_LegacyVelocityFilterStrength_6;
};
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com
{
	int32_t ___m_enabled_0;
	float ___m_WaitTime_1;
	float ___m_RecenteringTime_2;
	float ___mLastAxisInputTime_3;
	float ___mRecenteringVelocity_4;
	int32_t ___m_LegacyHeadingDefinition_5;
	int32_t ___m_LegacyVelocityFilterStrength_6;
};

struct CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB 
{
	Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___m_Custom_0;
	float ___m_Weight_1;
};

struct Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E 
{
	int32_t ___m_Definition_0;
	int32_t ___m_VelocityFilterStrength_1;
	float ___m_Bias_2;
};

struct AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115 
{
	bool ___m_Enabled_0;
	float ___m_PositionOffset_1;
	int32_t ___m_SearchRadius_2;
	int32_t ___m_SearchResolution_3;
};
struct AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_pinvoke
{
	int32_t ___m_Enabled_0;
	float ___m_PositionOffset_1;
	int32_t ___m_SearchRadius_2;
	int32_t ___m_SearchResolution_3;
};
struct AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_com
{
	int32_t ___m_Enabled_0;
	float ___m_PositionOffset_1;
	int32_t ___m_SearchRadius_2;
	int32_t ___m_SearchResolution_3;
};

struct TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA 
{
	int32_t ___m_BlendHint_0;
	bool ___m_InheritPosition_1;
	VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154* ___m_OnCameraLive_2;
};
struct TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA_marshaled_pinvoke
{
	int32_t ___m_BlendHint_0;
	int32_t ___m_InheritPosition_1;
	VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154* ___m_OnCameraLive_2;
};
struct TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA_marshaled_com
{
	int32_t ___m_BlendHint_0;
	int32_t ___m_InheritPosition_1;
	VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154* ___m_OnCameraLive_2;
};

struct NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240 
{
	float ___Frequency_0;
	float ___Amplitude_1;
	bool ___Constant_2;
};
struct NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_pinvoke
{
	float ___Frequency_0;
	float ___Amplitude_1;
	int32_t ___Constant_2;
};
struct NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_com
{
	float ___Frequency_0;
	float ___Amplitude_1;
	int32_t ___Constant_2;
};

struct TimeRange_t2D8D9BBC8BD1BB9F2988380CE7D7334899D9D0E0 
{
	float ___Start_0;
	float ___End_1;
};

struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354  : public RuntimeObject
{
	intptr_t ___m_Ptr_0;
};
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
};
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_com
{
	intptr_t ___m_Ptr_0;
};

struct AxisState_t6996FE8143104E02683986C908C18B0F62595736 
{
	float ___Value_0;
	int32_t ___m_SpeedMode_1;
	float ___m_MaxSpeed_2;
	float ___m_AccelTime_3;
	float ___m_DecelTime_4;
	String_t* ___m_InputAxisName_5;
	float ___m_InputAxisValue_6;
	bool ___m_InvertInput_7;
	float ___m_MinValue_8;
	float ___m_MaxValue_9;
	bool ___m_Wrap_10;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF ___m_Recentering_11;
	float ___m_CurrentSpeed_12;
	float ___m_LastUpdateTime_13;
	int32_t ___m_LastUpdateFrame_14;
	RuntimeObject* ___m_InputAxisProvider_16;
	int32_t ___m_InputAxisIndex_17;
	bool ___U3CValueRangeLockedU3Ek__BackingField_18;
	bool ___U3CHasRecenteringU3Ek__BackingField_19;
};
struct AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_pinvoke
{
	float ___Value_0;
	int32_t ___m_SpeedMode_1;
	float ___m_MaxSpeed_2;
	float ___m_AccelTime_3;
	float ___m_DecelTime_4;
	char* ___m_InputAxisName_5;
	float ___m_InputAxisValue_6;
	int32_t ___m_InvertInput_7;
	float ___m_MinValue_8;
	float ___m_MaxValue_9;
	int32_t ___m_Wrap_10;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke ___m_Recentering_11;
	float ___m_CurrentSpeed_12;
	float ___m_LastUpdateTime_13;
	int32_t ___m_LastUpdateFrame_14;
	RuntimeObject* ___m_InputAxisProvider_16;
	int32_t ___m_InputAxisIndex_17;
	int32_t ___U3CValueRangeLockedU3Ek__BackingField_18;
	int32_t ___U3CHasRecenteringU3Ek__BackingField_19;
};
struct AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_com
{
	float ___Value_0;
	int32_t ___m_SpeedMode_1;
	float ___m_MaxSpeed_2;
	float ___m_AccelTime_3;
	float ___m_DecelTime_4;
	Il2CppChar* ___m_InputAxisName_5;
	float ___m_InputAxisValue_6;
	int32_t ___m_InvertInput_7;
	float ___m_MinValue_8;
	float ___m_MaxValue_9;
	int32_t ___m_Wrap_10;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com ___m_Recentering_11;
	float ___m_CurrentSpeed_12;
	float ___m_LastUpdateTime_13;
	int32_t ___m_LastUpdateFrame_14;
	RuntimeObject* ___m_InputAxisProvider_16;
	int32_t ___m_InputAxisIndex_17;
	int32_t ___U3CValueRangeLockedU3Ek__BackingField_18;
	int32_t ___U3CHasRecenteringU3Ek__BackingField_19;
};

struct BoundingSphere_t2DDB3D1711A6920C0ECA9217D3E4E14AFF03C010 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position_0;
	float ___radius_1;
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

struct HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA  : public RuntimeObject
{
	ItemU5BU5D_t60EF694EBD97EE6EE5145043113A4E06D1DCAC47* ___mHistory_0;
	int32_t ___mTop_1;
	int32_t ___mBottom_2;
	int32_t ___mCount_3;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___mHeadingSum_4;
	float ___mWeightSum_5;
	float ___mWeightTime_6;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___mLastGoodHeading_7;
};

struct HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA_StaticFields
{
	float ___mDecayExponent_8;
};

struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE 
{
	float ___FieldOfView_1;
	float ___OrthographicSize_2;
	float ___NearClipPlane_3;
	float ___FarClipPlane_4;
	float ___Dutch_5;
	int32_t ___ModeOverride_6;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___LensShift_7;
	int32_t ___GateFit_8;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_SensorSize_9;
	bool ___m_OrthoFromCamera_10;
	bool ___m_PhysicalFromCamera_11;
};

struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_StaticFields
{
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___Default_0;
};
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke
{
	float ___FieldOfView_1;
	float ___OrthographicSize_2;
	float ___NearClipPlane_3;
	float ___FarClipPlane_4;
	float ___Dutch_5;
	int32_t ___ModeOverride_6;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___LensShift_7;
	int32_t ___GateFit_8;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_SensorSize_9;
	int32_t ___m_OrthoFromCamera_10;
	int32_t ___m_PhysicalFromCamera_11;
};
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com
{
	float ___FieldOfView_1;
	float ___OrthographicSize_2;
	float ___NearClipPlane_3;
	float ___FarClipPlane_4;
	float ___Dutch_5;
	int32_t ___ModeOverride_6;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___LensShift_7;
	int32_t ___GateFit_8;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_SensorSize_9;
	int32_t ___m_OrthoFromCamera_10;
	int32_t ___m_PhysicalFromCamera_11;
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

struct PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E  : public RuntimeObject
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Velocity_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_SmoothDampVelocity_1;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Pos_2;
	bool ___m_HavePos_3;
	float ___Smoothing_4;
};

struct RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Point_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Normal_1;
	uint32_t ___m_FaceID_2;
	float ___m_Distance_3;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_UV_4;
	int32_t ___m_Collider_5;
};

struct TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80  : public RuntimeObject
{
};

struct TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_StaticFields
{
	bool ___UseCache_0;
	int32_t ___m_CacheMode_2;
	float ___CurrentTime_3;
	int32_t ___CurrentFrame_4;
	bool ___IsCameraCut_5;
	Dictionary_2_t29F94820877E2B83E48075DD7E4FB54F414D1F35* ___m_Cache_6;
	TimeRange_t2D8D9BBC8BD1BB9F2988380CE7D7334899D9D0E0 ___m_CacheTimeRange_7;
};

struct FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED 
{
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___mFovSoftGuideRect_0;
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___mFovHardGuideRect_1;
	float ___mFovH_2;
	float ___mFov_3;
	float ___mOrthoSizeOverDistance_4;
	float ___mAspect_5;
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___mSoftGuideRect_6;
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___mHardGuideRect_7;
};

struct TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91 
{
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240 ___X_0;
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240 ___Y_1;
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240 ___Z_2;
};
struct TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91_marshaled_pinvoke
{
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_pinvoke ___X_0;
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_pinvoke ___Y_1;
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_pinvoke ___Z_2;
};
struct TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91_marshaled_com
{
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_com ___X_0;
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_com ___Y_1;
	NoiseParams_tFEE1B5C35BAFA843F32A882125A5967213B50240_marshaled_com ___Z_2;
};

struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 
{
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___Lens_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceUp_1;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceLookAt_2;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___RawPosition_4;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___RawOrientation_5;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionDampingBypass_6;
	float ___ShotQuality_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionCorrection_8;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___OrientationCorrection_9;
	int32_t ___BlendHint_10;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom0_11;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom1_12;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom2_13;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom3_14;
	List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* ___m_CustomOverflow_15;
	int32_t ___U3CNumCustomBlendablesU3Ek__BackingField_16;
};

struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_StaticFields
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___kNoPoint_3;
};
struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_pinvoke
{
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke ___Lens_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceUp_1;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceLookAt_2;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___RawPosition_4;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___RawOrientation_5;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionDampingBypass_6;
	float ___ShotQuality_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionCorrection_8;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___OrientationCorrection_9;
	int32_t ___BlendHint_10;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom0_11;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom1_12;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom2_13;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom3_14;
	List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* ___m_CustomOverflow_15;
	int32_t ___U3CNumCustomBlendablesU3Ek__BackingField_16;
};
struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_com
{
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com ___Lens_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceUp_1;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceLookAt_2;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___RawPosition_4;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___RawOrientation_5;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionDampingBypass_6;
	float ___ShotQuality_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionCorrection_8;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___OrientationCorrection_9;
	int32_t ___BlendHint_10;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom0_11;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom1_12;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom2_13;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom3_14;
	List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* ___m_CustomOverflow_15;
	int32_t ___U3CNumCustomBlendablesU3Ek__BackingField_16;
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

struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	String_t* ____paramName_18;
};

struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C  : public MulticastDelegate_t
{
};

struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

struct BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E  : public RuntimeObject
{
	CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* ___U3CBlendU3Ek__BackingField_0;
	int32_t ___U3CPriorityU3Ek__BackingField_1;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___U3CLookAtU3Ek__BackingField_2;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___U3CFollowU3Ek__BackingField_3;
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___U3CStateU3Ek__BackingField_4;
};

struct IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

struct Rigidbody_t268697F5A994213ED97393309870968BC1C7393C  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

struct SignalSourceAsset_t187094A020026D70B16096697802137226248D2B  : public ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A
{
};

struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

struct AxisInputDelegate_tE27958ACEDD7816DB591B6F485ACD7083541C452  : public MulticastDelegate_t
{
};

struct UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60  : public MulticastDelegate_t
{
};

struct CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC  : public MulticastDelegate_t
{
};

struct DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842  : public MulticastDelegate_t
{
};

struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
	CancellationTokenSource_tAAE1E0033BCFC233801F8CB4CED5C852B350CB7B* ___m_CancellationTokenSource_4;
};

struct NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1  : public SignalSourceAsset_t187094A020026D70B16096697802137226248D2B
{
	TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1* ___PositionNoise_4;
	TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1* ___OrientationNoise_5;
};

struct CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_vcamOwner_6;
};

struct CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	int32_t ___m_Resolution_5;
	Appearance_t598AE4F607DDAB13B808E1D4ECEBE53E335967F8* ___m_Appearance_6;
	SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___m_DistanceToPos_7;
	SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___m_PosToDistance_8;
	int32_t ___m_CachedSampleSteps_9;
	float ___m_PathLength_10;
	float ___m_cachedPosStepSize_11;
	float ___m_cachedDistanceStepSize_12;
};

struct CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___m_ExcludedPropertiesInInspector_5;
	StageU5BU5D_tF198CE3C6DE5C3D67552DAB4B9680F3BFF319981* ___m_LockStageInInspector_6;
	int32_t ___m_ValidatingStreamVersion_7;
	bool ___m_OnValidateCalled_8;
	int32_t ___m_StreamingVersion_9;
	int32_t ___m_Priority_10;
	int32_t ___m_ActivationId_11;
	float ___FollowTargetAttachment_12;
	float ___LookAtTargetAttachment_13;
	int32_t ___m_StandbyUpdate_14;
	List_1_tF512ECCA426FF10471372F52B5C8784FC96A7EAC* ___U3CmExtensionsU3Ek__BackingField_15;
	bool ___U3CPreviousStateIsValidU3Ek__BackingField_16;
	bool ___m_WasStarted_17;
	bool ___mSlaveStatusUpdated_18;
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_parentVcam_19;
	int32_t ___m_QueuePriority_20;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_CachedFollowTarget_21;
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_CachedFollowTargetVcam_22;
	RuntimeObject* ___m_CachedFollowTargetGroup_23;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_CachedLookAtTarget_24;
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_CachedLookAtTargetVcam_25;
	RuntimeObject* ___m_CachedLookAtTargetGroup_26;
	bool ___U3CFollowTargetChangedU3Ek__BackingField_27;
	bool ___U3CLookAtTargetChangedU3Ek__BackingField_28;
};

struct Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___Damping_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ShoulderOffset_8;
	float ___VerticalArmLength_9;
	float ___CameraSide_10;
	float ___CameraDistance_11;
	LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB ___CameraCollisionFilter_12;
	String_t* ___IgnoreTag_13;
	float ___CameraRadius_14;
	float ___DampingIntoCollision_15;
	float ___DampingFromCollision_16;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PreviousFollowTargetPosition_17;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_DampingCorrection_18;
	float ___m_CamPosCollisionCorrection_19;
};

struct CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1* ___m_NoiseProfile_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PivotOffset_8;
	float ___m_AmplitudeGain_9;
	float ___m_FrequencyGain_10;
	bool ___mInitialized_11;
	float ___mNoiseTime_12;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___mNoiseOffsets_13;
};

struct CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_TrackedObjectOffset_7;
	float ___m_LookaheadTime_8;
	float ___m_LookaheadSmoothing_9;
	bool ___m_LookaheadIgnoreY_10;
	float ___m_HorizontalDamping_11;
	float ___m_VerticalDamping_12;
	float ___m_ScreenX_13;
	float ___m_ScreenY_14;
	float ___m_DeadZoneWidth_15;
	float ___m_DeadZoneHeight_16;
	float ___m_SoftZoneWidth_17;
	float ___m_SoftZoneHeight_18;
	float ___m_BiasX_19;
	float ___m_BiasY_20;
	bool ___m_CenterOnActivate_21;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___U3CTrackedPointU3Ek__BackingField_22;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_CameraPosPrevFrame_23;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_LookAtPrevFrame_24;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_ScreenOffsetPrevFrame_25;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___m_CameraOrientationPrevFrame_26;
	PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* ___m_Predictor_27;
	FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED ___mCache_28;
};

struct CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_TrackedObjectOffset_7;
	float ___m_LookaheadTime_8;
	float ___m_LookaheadSmoothing_9;
	bool ___m_LookaheadIgnoreY_10;
	float ___m_XDamping_11;
	float ___m_YDamping_12;
	float ___m_ZDamping_13;
	bool ___m_TargetMovementOnly_14;
	float ___m_ScreenX_15;
	float ___m_ScreenY_16;
	float ___m_CameraDistance_17;
	float ___m_DeadZoneWidth_18;
	float ___m_DeadZoneHeight_19;
	float ___m_DeadZoneDepth_20;
	bool ___m_UnlimitedSoftZone_21;
	float ___m_SoftZoneWidth_22;
	float ___m_SoftZoneHeight_23;
	float ___m_BiasX_24;
	float ___m_BiasY_25;
	bool ___m_CenterOnActivate_26;
	int32_t ___m_GroupFramingMode_27;
	int32_t ___m_AdjustmentMode_28;
	float ___m_GroupFramingSize_29;
	float ___m_MaxDollyIn_30;
	float ___m_MaxDollyOut_31;
	float ___m_MinimumDistance_32;
	float ___m_MaximumDistance_33;
	float ___m_MinimumFOV_34;
	float ___m_MaximumFOV_35;
	float ___m_MinimumOrthoSize_36;
	float ___m_MaximumOrthoSize_37;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PreviousCameraPosition_40;
	PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* ___m_Predictor_41;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___U3CTrackedPointU3Ek__BackingField_42;
	bool ___m_InheritingPosition_43;
	float ___m_prevFOV_44;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___m_prevRotation_45;
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___U3CLastBoundsU3Ek__BackingField_46;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___U3CLastBoundsMatrixU3Ek__BackingField_47;
};

struct CinemachineHardLockToTarget_tA87D10A864809C5E690916F194DBD61F8E64380A  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	float ___m_Damping_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PreviousTargetPosition_8;
};

struct CinemachineHardLookAt_tF3F83D120480604E6173E3907DAA85CDEBB0FC8E  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
};

struct CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	int32_t ___m_RecenterTarget_7;
	AxisState_t6996FE8143104E02683986C908C18B0F62595736 ___m_VerticalAxis_8;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF ___m_VerticalRecentering_9;
	AxisState_t6996FE8143104E02683986C908C18B0F62595736 ___m_HorizontalAxis_10;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF ___m_HorizontalRecentering_11;
	bool ___m_ApplyBeforeBody_12;
};

struct CinemachineSameAsFollowTarget_t3F3D720F4ED98F0E8608A0D077BB877F1A897141  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	float ___m_Damping_7;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___m_PreviousReferenceOrientation_8;
};

struct CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* ___m_Path_7;
	float ___m_PathPosition_8;
	int32_t ___m_PositionUnits_9;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PathOffset_10;
	float ___m_XDamping_11;
	float ___m_YDamping_12;
	float ___m_ZDamping_13;
	int32_t ___m_CameraUp_14;
	float ___m_PitchDamping_15;
	float ___m_YawDamping_16;
	float ___m_RollDamping_17;
	AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115 ___m_AutoDolly_18;
	float ___m_PreviousPathPosition_19;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___m_PreviousOrientation_20;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PreviousCameraPosition_21;
};

struct CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	int32_t ___m_BindingMode_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_FollowOffset_8;
	float ___m_XDamping_9;
	float ___m_YDamping_10;
	float ___m_ZDamping_11;
	int32_t ___m_AngularDampingMode_12;
	float ___m_PitchDamping_13;
	float ___m_YawDamping_14;
	float ___m_RollDamping_15;
	float ___m_AngularDamping_16;
	bool ___U3CHideOffsetInInspectorU3Ek__BackingField_17;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PreviousTargetPosition_18;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___m_PreviousReferenceOrientation_19;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___m_targetOrientationOnAssign_20;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PreviousOffset_21;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_previousTarget_22;
};

struct CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50  : public CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE
{
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_LookAt_29;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_Follow_30;
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___m_Lens_31;
	TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA ___m_Transitions_32;
	int32_t ___m_LegacyBlendHint_33;
	bool ___m_UserIsDragging_37;
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___m_State_38;
	CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___m_ComponentPipeline_39;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_ComponentOwner_40;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___mCachedLookAtTarget_41;
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___mCachedLookAtTargetVcam_42;
};

struct CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_StaticFields
{
	CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* ___CreatePipelineOverride_35;
	DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* ___DestroyPipelineOverride_36;
};

struct CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2  : public CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A
{
	float ___m_GroupFramingSize_29;
	int32_t ___m_FramingMode_30;
	float ___m_FrameDamping_31;
	int32_t ___m_AdjustmentMode_32;
	float ___m_MaxDollyIn_33;
	float ___m_MaxDollyOut_34;
	float ___m_MinimumDistance_35;
	float ___m_MaximumDistance_36;
	float ___m_MinimumFOV_37;
	float ___m_MaximumFOV_38;
	float ___m_MinimumOrthoSize_39;
	float ___m_MaximumOrthoSize_40;
	float ___m_prevFramingDistance_41;
	float ___m_prevFOV_42;
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___U3CLastBoundsU3Ek__BackingField_43;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___U3CLastBoundsMatrixU3Ek__BackingField_44;
};

struct CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303  : public CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5
{
	Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E ___m_Heading_23;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF ___m_RecenterToTargetHeading_24;
	AxisState_t6996FE8143104E02683986C908C18B0F62595736 ___m_XAxis_25;
	float ___m_LegacyRadius_26;
	float ___m_LegacyHeightOffset_27;
	float ___m_LegacyHeadingBias_28;
	bool ___m_HeadingIsSlave_29;
	UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* ___HeadingUpdater_30;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_LastTargetPosition_31;
	HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* ___mHeadingTracker_32;
	Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* ___m_TargetRigidBody_33;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_PreviousTarget_34;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_LastCameraPosition_35;
	float ___m_LastHeading_36;
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
struct CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077  : public RuntimeArray
{
	ALIGN_FIELD (8) CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* m_Items[1];

	inline CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
struct TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1  : public RuntimeArray
{
	ALIGN_FIELD (8) TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91 m_Items[1];

	inline TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, TransformNoiseParams_t1056C699265C70FECE1BDF04D38CF74997002A91 value)
	{
		m_Items[index] = value;
	}
};
struct CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C  : public RuntimeArray
{
	ALIGN_FIELD (8) CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB m_Items[1];

	inline CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->___m_Custom_0), (void*)NULL);
	}
	inline CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->___m_Custom_0), (void*)NULL);
	}
};

IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_pinvoke(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_pinvoke_back(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke& marshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled);
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_pinvoke_cleanup(Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_com(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com& marshaled);
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_com_back(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com& marshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled);
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_com_cleanup(Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com& marshaled);
IL2CPP_EXTERN_C void LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshal_pinvoke(const LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE& unmarshaled, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshal_pinvoke_back(const LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke& marshaled, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE& unmarshaled);
IL2CPP_EXTERN_C void LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshal_pinvoke_cleanup(LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshal_com(const LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE& unmarshaled, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com& marshaled);
IL2CPP_EXTERN_C void LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshal_com_back(const LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com& marshaled, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE& unmarshaled);
IL2CPP_EXTERN_C void LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshal_com_cleanup(LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com& marshaled);

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Component_GetComponent_TisRuntimeObject_m7181F81CAEC2CF53F5D2BC79B7425C16E1F80D33_gshared (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_gshared_inline (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C_gshared (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, int32_t ___index0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m71F29A2B876EC3E6F1ACD24B3CEAEDA3FF79CB3F_gshared (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_gshared_inline (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___item0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR void List_1_AddWithResize_m4C218F14375DB7D7D5C0EC54E1FCF09D4C32E722_gshared (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___item0, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m0BD6B99048AA4888057E840317CE80F3789BBE8D (U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline (float ___value0, float ___min1, float ___max2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline (float ___a0, float ___b1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB LayerMask_op_Implicit_mDC9C22C4477684D460FCF25B1BFE6B54419FB922 (int32_t ___intVal0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeUtility_DestroyScratchCollider_m9A1C54492DCE4CD322DAA566818F06CA6F06988E (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1 (Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_PositionCamera_m13334AE8E5681B0F83EB4DC65607CCDEBBE7BC4A (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComponentBase_OnTargetObjectWarped_m3E083DBF03C47860948F0BB3A013B241AFDAF9A0 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotation0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___point1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Cinemachine3rdPersonFollow_GetHeading_mAF350E9785F2314EFD8016F12B0ED596E6C66843 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetRot0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotation0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m871E131EE59CEEC1B5691F5DC570B18816530C97 (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___initial0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___dampTime1, float ___deltaTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_GetRawRigPositions_mDE2296B2034978F905A1C9CBAA202EFB174CB1D5 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___root0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetRot1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___heading2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___shoulder3, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___hand4, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Cinemachine3rdPersonFollow_ResolveCollisions_m0803F98237E6C6D08D13173E1FECBDD506860BA4 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___root0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___tip1, float ___deltaTime2, float ___cameraRadius3, float* ___collisionCorrection4, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___vector0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___planeNormal1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_right_m13B7C3EAA64DC921EC23346C56A5A597B5481FF5_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forward0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upwards1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline (float ___a0, float ___b1, float ___t2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LayerMask_get_value_m70CBE32210A1F0FD4ECB850285DA90ED57B87974 (LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LayerMask_op_Implicit_m5D697E103A7CB05CADCED9F90FD4F6BAE955E763 (LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB ___mask0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool RuntimeUtility_SphereCastIgnoreTag_m87978D006531BAD6403611588E8D68DE989270A8 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rayStart0, float ___radius1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___dir2, RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5* ___hitInfo3, float ___rayLength4, int32_t ___layerMask5, String_t** ___ignoreTag6, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 RaycastHit_get_point_m02B764612562AFE0F998CC7CFB2EEDE41BA47F39 (RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 RaycastHit_get_normal_mD8741B70D2039C5CAFC4368D4CE59D89562040B5 (RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Damper_Damp_mFB62278C063E2CAA706D30E8D68AF55D50AE95D2 (float ___initial0, float ___dampTime1, float ___deltaTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBasicMultiChannelPerlin_Initialize_m1ADAFB3D2CAFBEBC0018D71B44BDCD24074EAEC2 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TargetPositionCache_get_CacheMode_mDCBA178980BB6A8FEEC18CA1238F52FFDFC8B5A4_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TargetPositionCache_get_HasCurrentTime_m143562F778152928D6FE2E609F81786513F6ED2F (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 NoiseSettings_GetCombinedFilterResults_mE35B3A4E1826146B200499B62617F8E629434F20 (TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1* ___noiseParams0, float ___time1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___timeOffsets2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Euler_m66E346161C9778DF8486DB4FE823D8F81A54AF1D_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___euler0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Inequality_m6A7FB1C9E9DE194708997BFA24C6E238D92D908E_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_UnaryNegation_m3AC523A7BED6E843165BDF598690F0560D8CAA63_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_Translate_m95D44EDD1A9856DD11C639692E47B7A35EF745E2 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___vector0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_Rotate_mE2C31B51EEC282F2969B9C2BE24BD73E312807E8 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___q0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_op_Multiply_m7649669D493400913FF60AFB04B1C19F14E0FDB0 (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___lhs0, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Matrix4x4_MultiplyPoint_m20E910B65693559BFDE99382472D8DD02C862E7E (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___point0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___lhs0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Random_Range_mF26F26EB446B76823B4815C91FA0907B484DF02B (float ___minInclusive0, float ___maxInclusive1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineCore_get_CurrentTime_mE95A89B5053FB5D86EB1E2D855CDC9E4D4CC5459 (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Equality_m15951D1B53E3BE36C9D265E229090020FBD72EBB_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBasicMultiChannelPerlin_ReSeed_m386B1BA6AEFB26B878A7431484D412F9FB2E9696 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CinemachineComponentBase_get_LookAtTarget_m7E6CF239A3905B1130A5C38B0E5668EB32D1BB04 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CinemachineComponentBase_get_LookAtTargetRotation_m49CBE00226BB55772DB73775412AF782892B8251 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineComposer_set_TrackedPoint_mC2806265609C1BADBE1F83DD18F800BDA064D5A6_inline (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool CinemachineVirtualCameraBase_get_LookAtTargetChanged_m6D2FF4FB863501796CB778CB7AABA0126E57C134_inline (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionPredictor_AddPosition_mB5EFA6BB6598A9D52D1CE6BD50400E56938C433C (PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, float ___deltaTime1, float ___lookaheadTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 PositionPredictor_PredictPositionDelta_mC16231F75C5C088B5CC2444D3C2FA12F6DACC4AD (PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* __this, float ___lookaheadTime0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionPredictor_ApplyTransformDelta_mDA012CCA329F143DDF342616369F0E75B2E2C97A (PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComponentBase_ForceCameraPosition_m3D22002EC0B4F5C1AF7CC283C00BA43D22120878 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rot1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Lerp_m57EE8D709A93B2B0FF8D499FA2947B1D61CB1FD6_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, float ___t2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Distance_m99C722723EDD875852EF854AD7B7C4F8AC4F84AB_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineComposer_get_SoftGuideRect_mFFE86E73B085263B4B15F2E5BD8053F8C033E8E1 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineComposer_get_HardGuideRect_mA2B70FA82432B7D2874E5213E3F9086CC152E69F (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FovCache_UpdateCache_m3462592E7672B43BEB32686E0F62B7C17F0E2999 (FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* __this, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___lens0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___softGuide1, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___hardGuide2, float ___targetDistance3, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Rect_get_center_mAA9A2E1F058B2C9F58E13CC4822F789F42975E5C_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_get_zero_m009B92B5D35AB02BD1610C2E1ACCE7C9CF964A6E_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect__ctor_m503705FE0E4E413041E3CE7F09270489F401C675_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___position0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___size1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_RotateToScreenBounds_m01D1A38D82DF6AE50EFF13027781D15DED32D7EF (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___state0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___screenRect1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___trackedPoint2, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___rigOrientation3, float ___fov4, float ___fovH5, float ___deltaTime6, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_UnaryNegation_m47556D28F72B018AC4D5160710C83A805F10A783_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 UnityQuaternionExtensions_ApplyCameraRotation_m75753B356C2E3BC79192192C8C2FC1F512643506 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___orient0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rot1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 UnityQuaternionExtensions_Normalized_mECDA291E5D4B3D2D610FE74D89D7F2F7ED0B5E68 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___q0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 UnityQuaternionExtensions_GetCameraRotationToTarget_mDA1EF1466263B671B863D70DABBD50DF9785C2B7 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___orient0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lookAtDir1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___x0, float ___y1, float ___width2, float ___height3, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_x_mB267B718E0D067F2BAE31BA477647FBF964916EB_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_y_mC733E8D49F3CE21B2A3D40A1B72D687F22C97F49_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Rect_get_position_m9B7E583E67443B6F4280A676E644BB0B9E7C4E38_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___x0, float ___y1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Addition_m704B5B98EAFE885978381E21B7F89D9DF83C2A60_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___b1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_position_m9CD8AA25A83A7A893429C0ED56C36641202C3F05_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline (float ___a0, float ___b1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Subtraction_m664419831773D5BBF06D9DE4E515F6409B2F92B8_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___b1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineComposer_ClampVerticalBounds_m65C191E116F577A8F7F1383C99875779254B934C (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* ___r0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___dir1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, float ___fov3, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_xMin_mE89C40702926D016A633399E20DB9501E251630D_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineVirtualCameraBase_DetachedLookAtTargetDamp_mFB6FAA90EB2A5263D19E3D91C30C072C972E849E (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, float ___initial0, float ___dampTime1, float ___deltaTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float UnityVectorExtensions_Angle_m531A3EF1C1C1F49B637BB83F3795128D571A2B93 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v10, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v21, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_yMin_m9F780E509B9215A9E5826178CF664BD0E486D4EE_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_yMax_mCF452040E0068A4B3CB15994C0B4B6AD4D78E04B_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionPredictor__ctor_m98DC334F817608D8CA4FA09966193AA59A16DB25 (PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555 (LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Rect_op_Inequality_m4698BE8DFFC2C4F79B03116FC33FE1BE823A8945_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___lhs0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rhs1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D (LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D FovCache_ScreenToFOV_m84AEDE8D18A7CE6A911AB93E622316E126980056 (FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rScreen0, float ___fov1, float ___fovH2, float ___aspect3, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect__ctor_m5665723DD0443E990EA203A54451B2BB324D8224_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___source0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_Perspective_mC8EE39379287917634B001BBA926CAFBB4B343BB (float ___fov0, float ___aspect1, float ___zNear2, float ___zFar3, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_get_inverse_m4F4A881CD789281EA90EB68CFD39F36C8A81E6BD (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_left_mA75C525C1E78B5BB99E9B7A63EF68C731043FE18_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float UnityVectorExtensions_SignedAngle_mEC66BAD4357C0F5F7ADE082AD38AD1FE70649315 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v10, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v21, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_xMin_mA873FCFAF9EABA46A026B73CA045192DF1946F19_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_xMax_m97C28D468455A6D19325D0D862E80A093240D49D_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* CinemachineCore_get_Instance_m761793890717527703D6C8BB3AC64FEC93745A85 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineCore_IsLiveInBlend_mFD1402FFF3B5D0CD0EC90914F89672724F49F778 (CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* __this, RuntimeObject* ___vcam0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool CinemachineVirtualCameraBase_get_FollowTargetChanged_m4CB9C2AA28F8B2898B82BBF51348C6670110ADF2_inline (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PositionPredictor_Reset_mDA454522FB1823437E5538169D712A2E18F956C5 (PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_back_mBA6E23860A365E6F0F9A2AADC3D19E698687230A_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CinemachineComponentBase_get_AbstractFollowTargetGroup_m91BD623311234A96B2D146A8AB6574567C8C9714 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineFramingTransposer_ComputeGroupBounds_mD7044C4EFA049F1BD91607D7EB5FE2F26E7A78D2 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, RuntimeObject* ___group0, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_TrackedPoint_m32FD1D5F85F4BDBFC3BF6DBF5CBC7A8D1DB44FDD_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineFramingTransposer_get_LastBounds_m6D98D46A49E2196A98E2B7E76C0061AC8310B45B_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 CinemachineFramingTransposer_get_LastBoundsMatrix_mB1296133E5C0BDD6B9C0879888C468C559BE95BB_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Matrix4x4_MultiplyPoint3x4_mACCBD70AFA82C63DA88555780B7B6B01281AB814 (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___point0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds_set_center_m891869DD5B1BEEE2D17907BBFB7EB79AAE44884B_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_LastBounds_m42F030170155BAC06C2B040E44F4FCB25251EF93_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Bounds_get_size_m0699A53A55A78B3201D7270D6F338DFA91B6FAD4_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Implicit_m8F73B300CB4E6F9B4EB5FB6130363D76CEAA230B_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineFramingTransposer_GetTargetHeight_m5CD0304B16E7442B6BA592E7915FE7C2F57D4A64 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___boundsSize0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Bounds_get_extents_mFE6DC407FCE2341BE2C750CB554055D211281D25_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineFramingTransposer_get_TrackedPoint_m893C86296D7D0C01FCD28D85D14B38124F9AFB52_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineFramingTransposer_get_SoftGuideRect_mCDC60214B6A81FBD8AAF9F6DECAEC86A562C504A (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineFramingTransposer_ScreenToOrtho_m07AF0DD2BFAEF10102EFEDBB9D87F31EAFA35D41 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rScreen0, float ___orthoSize1, float ___aspect2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineFramingTransposer_OrthoOffsetToScreenBounds_mB27FBC07BF36E7BBACD39AAE05C8D7D3B62A8A4E (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___targetPos2D0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___screenRect1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineFramingTransposer_get_HardGuideRect_m83469B076C3529941A2FD36E35FFE410EA3D7BA5 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m215A089B8451330FA8D7D6E4DB8E38400AD9E7CF (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, float ___initial0, float ___dampTime1, float ___deltaTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___q1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___s2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_LastBoundsMatrix_m13FAE68552F3910750A134D22AE4AF6845C0301D_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineFramingTransposer_GetScreenSpaceGroupBoundingBox_mD6B121234F24AC755C1485C22B9A486625B3F58D (RuntimeObject* ___group0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___pos1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___orientation2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Division_m69F64D545E3C023BE9927397572349A569141EBA_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, float ___d1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 UnityVectorExtensions_Abs_m4E617236E1CCFE843CA67854AC8E48AC22323BA9 (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___v0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_Max_m5FF3A49170F857E422CDD32A51CABEAE568E8088_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___lhs0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_Min_mAB64CD54A495856162FC5753B6C6B572AA4BEA1D_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___lhs0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rhs1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Multiply_m4EEB2FF3F4830390A53CE9B6076FB31801D65EED_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, float ___d1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds__ctor_mAF7B238B9FBF90C495E5D7951760085A93119C5A_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___center0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___size1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineComposer_GetMaxDampTime_m1D830B2C6BDB743F6C546C27AA62A60704BC4CA0 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CinemachineComponentBase_get_AbstractLookAtTargetGroup_m83547AD312D71E3080F9C6948DF4C5DA7B6B6054 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_MutateCameraState_m50DD037C33A1BF4956C47F8ADA6F6CBADDDA4B3A (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineGroupComposer_set_LastBoundsMatrix_m917FDDE19382BCDA1626CF4BB5E118E43C1D13A3_inline (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 CinemachineGroupComposer_get_LastBoundsMatrix_m67F9243F621C6474E2090615DDE98B6E69B81E52_inline (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_normalized_m736BBF65D5CDA7A18414370D15B4DFCC1E466F07_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineGroupComposer_set_LastBounds_mE2FCF71321530F97627893A8BA652B959D19110C_inline (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineGroupComposer_GetScreenSpaceGroupBoundingBox_m567C86F8FB8092CF4BABDE712030C3E1772A22A9 (RuntimeObject* ___group0, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___observer1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___newFwd2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineGroupComposer_GetTargetHeight_mE81E9435860ADF221E7DD164A4ADF411AB4C740A (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___boundsSize0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Matrix4x4_MultiplyVector_mFD12F86A473E90BBB0002149ABA3917B2A518937 (Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___vector0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer__ctor_m90D1EE7F962886981F03D129849E4214A106DCD8 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m12B68094CE823031220DD1E2EAB52AAD0AC25412 (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___initial0, float ___dampTime1, float ___deltaTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_FromToRotation_m041093DBB23CB3641118310881D6B7746E3B8418 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___fromDirection0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___toDirection1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Recentering_LegacyUpgrade_m17A3ED97851377053B2385331ED85BE3DA3D4D7D (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, int32_t* ___heading0, int32_t* ___velocityFilter1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_Validate_m1245D61F6D9A031C27F75F4B49E78A52AA91BDE5 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_Validate_m3F5EE15AE52BB8FF2B69E3963851CEE2600340D3 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_OnValidate_mFC57EE74F157499D7CAC4D30CC1D7A04ED6FC33E (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineOrbitalTransposer_UpdateHeading_m8718BA600DA5134C0E38C8646DBC2506AB4472AB (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, float ___deltaTime0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, AxisState_t6996FE8143104E02683986C908C18B0F62595736* ___axis2, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* ___recentering3, bool ___isLive4, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_Reset_m329065EBC9963460CD7733144EC5F47D107967C9 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_Update_mE86F039B78105160E5C13153B456E3A988AF28B4 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___deltaTime0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineOrbitalTransposer_GetTargetHeading_m7CDCBC39F6AF29C82492EC52B529A3936CFD6219 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, float ___currentHeading0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetOrientation1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, AxisState_t6996FE8143104E02683986C908C18B0F62595736* ___axis0, float ___deltaTime1, float ___recenterTarget2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer_UpdateInputAxisProvider_m2FA2059A198A20A0730E6BCAC2D572005513971D (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, int32_t ___axis0, RuntimeObject* ___provider1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CinemachineVirtualCameraBase_GetInputAxisProvider_mC735C4764E6CB8469D115142D842729C95D9C39E (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_OnTargetObjectWarped_m9E0D9DA06D752FF81CB08EDE999759FF47DEF741 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_ForceCameraPosition_m8E10E86DEDAF9FE53266FDB72F53E6D2083965B4 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rot1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineOrbitalTransposer_GetAxisClosestValue_m12E53A2B675F5EF62F5FC89AD55A3F398C005AFF (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___cameraPos0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_AngleAxis_m01A869DC10F976FAF493B66F15D6D6977BB61DA8 (float ___angle0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___axis1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_SignedAngle_mD30E71B2F64983C2C4D86F17E7023BAA84CE50BE_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___from0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___to1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___axis2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_InitPrevFrameStateInfo_m5640D1D85D4260B279D374618B009740EF6EC260 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) ;
inline Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* Component_GetComponent_TisRigidbody_t268697F5A994213ED97393309870968BC1C7393C_m4B5CAD64B52D153BEA96432633CA9A45FA523DD8 (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method)
{
	return ((  Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* (*) (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3*, const RuntimeMethod*))Component_GetComponent_TisRuntimeObject_m7181F81CAEC2CF53F5D2BC79B7425C16E1F80D33_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_inline (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_TrackTarget_m509CF4F1D4319A21D55CEAA20802DA09B46E2AC5 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, float ___deltaTime0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___desiredCameraOffset2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___outTargetPosition3, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___outTargetOrient4, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_GetOffsetForMinimumTargetDistance_m3AF6061743759E9C4BF3280862AA8841449A3172 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___dampedTargetPos0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___cameraOffset1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___cameraFwd2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up3, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___actualTargetPos4, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineComponentBase_get_LookAtTargetPosition_m79CE45A7F4D4A82BC47B01434F5EB35C91DC99A8 (CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_sqrMagnitude_m43C27DEC47C4811FB30AB474FF2131A963B66FC8_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 UnityVectorExtensions_SafeFromToRotation_mD10BFD5052B69EE3D1DE2FE9B74181BD797ACC03 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v10, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v21, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Quaternion_get_eulerAngles_m2DB5158B5C3A71FD60FC8A6EE43D3AAA1CFED122_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Rigidbody_get_velocity_mAE331303E7214402C93E2183D0AA1198F425F843 (Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t HeadingTracker_get_FilterSize_mEF06A6674D9D5FE8F1802922DECACF11BA7BE151 (HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HeadingTracker__ctor_m65E930C6FC3B44B9DE66B61332E4A960A14BE25B (HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* __this, int32_t ___filterSize0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HeadingTracker_DecayHistory_m9E2B8A0731C6C492AE78B36925860F4A3EFA1BB7 (HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HeadingTracker_Add_m9FC794FA982A8598BC1FA0DB46EFAA7507CB861D (HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___velocity0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 HeadingTracker_GetReliableHeading_m3277A5C1F94F1269E38655527EB71AACF594F695 (HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Heading__ctor_m8BA2E53862E9957B1942EF8A55E5C8284ACDAAAB (Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* __this, int32_t ___def0, int32_t ___filterStrength1, float ___bias2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, bool ___enabled0, float ___waitTime1, float ___recenteringTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState__ctor_m09348C6ABBA887484BF7D3961D4FB582C0E5A4F6 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___minValue0, float ___maxValue1, bool ___wrap2, bool ___rangeLocked3, float ___maxSpeed4, float ___accelTime5, float ___decelTime6, String_t* ___name7, bool ___invert8, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UpdateHeadingDelegate__ctor_m60911D320DFD3CDA2C31C8CC7E030A3B47EFF3F6 (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer__ctor_m66F1121D2339FDEDC9743EC432749AFB3CA846BC (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m86741AB1B49B0E3932CA01086C2B7FAFC221C361 (U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineCore_IsLive_m6F2EBE598087857FF7D04A078563E9972CA52678 (CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* __this, RuntimeObject* ___vcam0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_UpdateInputAxisProvider_m061C1326E834985C26CA2D74F90D2E52C590FC4D (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 CinemachinePOV_GetRecenterTarget_m222F334C80D4ABBD48B9284A6EFCF6C0B853460A (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Euler_mD4601D966F1F58F3FCA01B3FC19A12D0AD0396DD_inline (float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371 (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* Transform_get_parent_m65354E28A4C94EC00EBCF03532F7B0718380791E (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Transform_get_forward_mFCFACF7165FDAB21E80E384C494DF278386CEE2F (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachinePOV_NormalizeAngle_m44F87A756F3A1DE1CBCB5C4F776C86B837B2D68E (float ___angle0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_SetAxesForRotation_mDBC52583D2371432C6CE2DFE61689D7C906710BC (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetRot0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Slerp_m5FDA8C178E7EB209B43845F73263AFE9C02F3949 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___a0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___b1, float ___t2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTrackedDolly_get_AngularDamping_m5ED59BCFD88587E5AF232BB5D779B3FE03832DE9 (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachinePathBase_ToNativePathUnits_m71355B86B0027D58831E4B9489CCFEE69B7E9158 (CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* __this, float ___pos0, int32_t ___units1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Mathf_FloorToInt_mD086E41305DD8350180AD677833A22733B4789A9_inline (float ___f0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachinePathBase_FromPathNativeUnits_mEFCB692BFEC5A048AF23D9BA3EC74A4255D5D867 (CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* __this, float ___pos0, int32_t ___units1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachinePathBase_MaxUnit_mD6C8BEEF736AF66618CD9FEA69D61CC5C9854F76 (CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* __this, int32_t ___units0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CinemachinePathBase_EvaluateOrientationAtUnit_m28859D88DD40B298B14EE6D04A6358534E09C0A7 (CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* __this, float ___pos0, int32_t ___units1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachinePathBase_EvaluatePositionAtUnit_mCE1B51BBCAEFF5A65A68F1D3113390F7BC223843 (CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* __this, float ___pos0, int32_t ___units1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m29F4414A9D30B7C0CD8455C4B2F049E8CCF66745_inline (float ___d0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Damper_Damp_mF0862EDA3BDC1B7119E3E6310B12B2DA72420E47 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___initial0, float ___dampTime1, float ___deltaTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CinemachineTrackedDolly_GetCameraOrientationAtPathPoint_m8F4DB6F44E986BE7FC8C2C55FCC1556995DB4D54 (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___pathOrientation0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___index0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___index0, float ___value1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Damper_Damp_mC9AFD35CB8F0ADFC8A169489A0F839CE52891D62 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___initial0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___dampTime1, float ___deltaTime2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AutoDolly__ctor_m8DEA29EE4AE5C67F12B07FB0C51EEC0810FDDF20 (AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* __this, bool ___enabled0, float ___positionOffset1, int32_t ___searchRadius2, int32_t ___stepsPerSegment3, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_get_Damping_m0BD9EBB7534A2DB4AB31AEB2BBAC3DF1D01BF366 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_get_AngularDamping_m489A52D7C6AFD2B34710F4E97299EC2A18E5CDBE (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_get_normalized_m08AB963B13A0EC6F540A29886C5ACFCCCC0A6D16_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AxisState_set_ValueRangeLocked_m367AD65F7E97A0DFF0DE1CA0C74AEEBCCC36D000_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, bool ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AxisState_set_HasRecentering_m978B18A62A74813CC75078114997E708B6877D85_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, bool ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_get_HasInputProvider_mD82DACE6E188BCFE1B0B5FCB1328BF8FA738B091 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Time_get_frameCount_m88E5008FE9451A892DE1F43DC8587213075890A8 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Time_get_time_m0BEE9AACD0723FE414465B77C9C64D12263675F3 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_m54CF0907E7C4F3AFB2E796A13DC751ECBB8DB64A (String_t* ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float AxisInputDelegate_Invoke_m1C36C70E105C8A9091AED921BB6E7053C99F39CE_inline (AxisInputDelegate_tE27958ACEDD7816DB591B6F485ACD7083541C452* __this, String_t* ___axisName0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogError_m059825802BB6AF7EA9693FEBEEB0D85F59A3E38E (RuntimeObject* ___message0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_MaxSpeedUpdate_m59BC1A91869A0D4A07E53DA4ED4172D5FBBF1DBD (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___input0, float ___deltaTime1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___v0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline (float ___f0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AxisState_GetMaxSpeed_m323DC3125D2C40B79B0C041CBE7F5F126329E489 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool AxisState_get_ValueRangeLocked_m25A67A9600BCC5AFD35CA1A2C57AE0CFCB76E6B1_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool AxisState_get_HasRecentering_m24F7A4CEF751588924C04AAB32BD1B59389BA4DC_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_CopyStateFrom_m1DB1F919E2F17C4913D1F2605E71630004138D89 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* ___other0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_RecenterNow_m0A012C8E8ABA1B3D00765C8C0FDC3A96C3DB102C (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Mathf_SmoothDamp_m00E482452BCED3FE0F16B4033B2B5323C7E30829 (float ___current0, float ___target1, float* ___currentVelocity2, float ___smoothTime3, float ___maxSpeed4, float ___deltaTime5, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_get_FinalPosition_m4D482D1F3E008068C2151FC24FD85CB6F603AE12 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_get_FinalOrientation_m65D23E9A3C9264408AB177483C74FD609EFAB4B3 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB_inline (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CameraState_set_NumCustomBlendables_m599C74DAA99E17F8B5EF87CFD0A6238A81D05AD3_inline (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, int32_t ___value0, const RuntimeMethod* method) ;
inline int32_t List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_inline (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*, const RuntimeMethod*))List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_gshared_inline)(__this, method);
}
inline CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, int32_t ___index0, const RuntimeMethod* method)
{
	return ((  CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB (*) (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*, int32_t, const RuntimeMethod*))List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C_gshared)(__this, ___index0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CustomBlendable__ctor_mF38BF574AF05E415A01A2A46E506DE6B5086B303 (CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* __this, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___custom0, float ___weight1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB CameraState_GetCustomBlendable_mE19B33F6CEC1B42ACAEB34A0601E48A80577498E (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, int32_t ___index0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CameraState_FindCustomBlendable_m141410A5E7FF4B985E2D3979D72BF80F398DE57C (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___custom0, const RuntimeMethod* method) ;
inline void List_1__ctor_m71F29A2B876EC3E6F1ACD24B3CEAEDA3FF79CB3F (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*, const RuntimeMethod*))List_1__ctor_m71F29A2B876EC3E6F1ACD24B3CEAEDA3FF79CB3F_gshared)(__this, method);
}
inline void List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_inline (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB, const RuntimeMethod*))List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_gshared_inline)(__this, ___item0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CameraState_AddCustomBlendable_m1DA24CB5A397752C33B6A1773CFF38F02505AD3C (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___b0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Clamp01_mD921B23F47F5347996C56DC789D1DE16EE27D9B1_inline (float ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE LensSettings_Lerp_mC2FB90FBCCACFC3BFB8B35971CE0F034D11D8865 (LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___lensA0, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___lensB1, float ___t2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Slerp_mBA32C7EAC64C56C7D68480549FA9A892FA5C1728 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, float ___t2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_ApplyPosBlendHint_m652243F6FEEC671040EE65DDF83A1446305357CC (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posA0, int32_t ___hintA1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posB2, int32_t ___hintB3, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___original4, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___blended5, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_ApplyRotBlendHint_mF25F7D3F9315C2CE92CBB65CC06D519C228C3571 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotA0, int32_t ___hintA1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotB2, int32_t ___hintB3, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___original4, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___blended5, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Mathf_Approximately_m1C8DD0BB6A2D22A7DCF09AD7F8EE9ABD12D3F620_inline (float ___a0, float ___b1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CameraState_InterpolateFOV_m282EABB08641EDA6F6AA12818B9BE6D76639AFE1 (float ___fovA0, float ___fovB1, float ___dA2, float ___dB3, float ___t4, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_InterpolatePosition_m0754A646434C49674356B584F9BDBB67B0D4F707 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posA0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pivotA1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posB2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pivotB3, float ___t4, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Quaternion_Angle_m445E005E6F9211283EEA3F0BD4FF2DC20FE3640A_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___a0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___b1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 UnityQuaternionExtensions_SlerpWithReferenceUp_m462C015C97FF4D2E7B7E83B6C1E4A29ED4DD1474 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___qA0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___qB1, float ___t2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up3, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_Lerp_mF3BD6827807680A529E800FD027734D40A3597E1_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___b1, float ___t2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_ProjectOnPlane_mCAFA9F9416EA4740DCA8757B6E52260BF536770A_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___vector0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___planeNormal1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AnimationCurve_get_length_m259A67BB0870D3A153F6FEDBB06CB0D24089CD81 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineBlend_get_IsComplete_m927128CEC49DCADF02A6258F8D636B0957446686 (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AnimationCurve_Evaluate_m50B857043DE251A186032ADBCBB4CEF817F4EE3C (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* __this, float ___time0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineBlend_get_IsValid_m3C10BCF867EF0AA96AAF0A70FF0990808FB7C81C (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* CinemachineDebug_SBFromPool_m6F20FF73A5A0C5B5CD7D53ADC0887782A70DB5E5 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D (StringBuilder_t* __this, String_t* ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineBlend_get_BlendWeight_m0FFFD553C4A1176490E443AF34DC8AB87F0763A7 (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m283B617AC29FB0DD6F3A7D8C01D385C25A5F0FAA (StringBuilder_t* __this, int32_t ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineDebug_ReturnToPool_m486386674DD5B04481BC7B3FAB351E6122EE8630 (StringBuilder_t* ___sb0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* BlendSourceVirtualCamera_get_Blend_mAEA739F5A13237AF89E38325902ECA8316FC5719_inline (BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineBlend_Uses_m7EC8B1160B3D24C5609684B486D485B2DD806A26 (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, RuntimeObject* ___cam0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 CameraState_get_Default_mBF6F22B14C83DD400EF9F53BB8EACB240BD79398 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 CameraState_Lerp_mEF27BCEB2B6B51C4E1A2F8E5D5826963D0C787CD (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___stateA0, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___stateB1, float ___t2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Internal_FromEulerRad_m2842B9FFB31CDC0F80B7C2172E22831D11D91E93 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___euler0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quaternion__ctor_m868FD60AA65DD5A8AC0C5DEB0608381A8D85FCD8_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, float ___x0, float ___y1, float ___z2, float ___w3, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Rect_op_Equality_m3592AA7AF3B2C809AAB02110B166B9A6F9263AD8_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___lhs0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rhs1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Normalize_m6120F119433C5B60BBB28731D3D4A0DA50A84DDD_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Angle_m1B9CC61B142C3A0E7EEB0559983CC391D1582F56_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___from0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___to1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Quaternion_Internal_ToEulerRad_m9B2C77284AEE6F2C43B6C42F1F888FB4FC904462 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotation0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Quaternion_Internal_MakePositive_m864320DA2D027C186C95B2A5BC2C66B0EB4A6C11 (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___euler0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425 (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* __this, String_t* ___message0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Normalize_m63D60A4A9F97145AF0C7E2A4C044EBF17EF7CBC3_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___q0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Quaternion_Dot_m4A80D03D7B7DEC054E2175E53D072675649C6713_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___a0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___b1, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Quaternion_IsEqualUsingDot_m5C6AC5F5C56B27C25DDF612BEEF40F28CA44CA31_inline (float ___dot0, const RuntimeMethod* method) ;
inline void List_1_AddWithResize_m4C218F14375DB7D7D5C0EC54E1FCF09D4C32E722 (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB, const RuntimeMethod*))List_1_AddWithResize_m4C218F14375DB7D7D5C0EC54E1FCF09D4C32E722_gshared)(__this, ___item0, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Magnitude_m6AD0BEBF88AAF98188A851E62D7A32CB5B7830EF_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___vector0, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_Multicast(CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* retVal = NULL;
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* currentDelegate = reinterpret_cast<CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC*>(delegatesToInvoke[i]);
		typedef Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* (*FunctionPointerType) (RuntimeObject*, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50*, String_t*, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077*, const RuntimeMethod*);
		retVal = ((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___vcam0, ___name1, ___copyFrom2, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
	return retVal;
}
Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_Open(CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, const RuntimeMethod* method)
{
	typedef Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* (*FunctionPointerType) (CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50*, String_t*, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077*, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___method_ptr_0)(___vcam0, ___name1, ___copyFrom2, method);
}
Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenVirtual(CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, const RuntimeMethod* method)
{
	return VirtualFuncInvoker2< Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*, String_t*, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* >::Invoke(il2cpp_codegen_method_get_slot(method), ___vcam0, ___name1, ___copyFrom2);
}
Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenInterface(CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, const RuntimeMethod* method)
{
	return InterfaceFuncInvoker2< Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*, String_t*, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___vcam0, ___name1, ___copyFrom2);
}
Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenGenericVirtual(CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, const RuntimeMethod* method)
{
	return GenericVirtualFuncInvoker2< Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*, String_t*, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* >::Invoke(method, ___vcam0, ___name1, ___copyFrom2);
}
Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenGenericInterface(CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, const RuntimeMethod* method)
{
	return GenericInterfaceFuncInvoker2< Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*, String_t*, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* >::Invoke(method, ___vcam0, ___name1, ___copyFrom2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CreatePipelineDelegate__ctor_m1418B88041BF669A6692C2B815A8913C01EA7895 (CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
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
			__this->___invoke_impl_1 = (intptr_t)&CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_Open;
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
						__this->___invoke_impl_1 = (intptr_t)&CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_Open;
			}
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_Invoke_m64652CFF99A748B459CC4B834CE86FF147616188 (CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, const RuntimeMethod* method) 
{
	typedef Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* (*FunctionPointerType) (RuntimeObject*, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50*, String_t*, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077*, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___vcam0, ___name1, ___copyFrom2, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CreatePipelineDelegate_BeginInvoke_mB61683EAF5CD48DD6AFE3080DBD1738BD0180656 (CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___vcam0, String_t* ___name1, CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___copyFrom2, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback3, RuntimeObject* ___object4, const RuntimeMethod* method) 
{
	void *__d_args[4] = {0};
	__d_args[0] = ___vcam0;
	__d_args[1] = ___name1;
	__d_args[2] = ___copyFrom2;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback3, (RuntimeObject*)___object4);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* CreatePipelineDelegate_EndInvoke_m5CAEF82C0E0E204CDFDEB4E6A99BAA098B0050B3 (CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
{
	RuntimeObject *__result = il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
	return (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)__result;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void DestroyPipelineDelegate_Invoke_mE4428F322828BD410B9C74A0358DF87D3A1983F9_Multicast(DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___pipeline0, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* currentDelegate = reinterpret_cast<DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___pipeline0, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void DestroyPipelineDelegate_Invoke_mE4428F322828BD410B9C74A0358DF87D3A1983F9_Open(DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___pipeline0, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___pipeline0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DestroyPipelineDelegate__ctor_m33BC3713FE7D6659FDF1BB0BAF060F70032EBF60 (DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 1;
		if (isOpen)
			__this->___invoke_impl_1 = (intptr_t)&DestroyPipelineDelegate_Invoke_mE4428F322828BD410B9C74A0358DF87D3A1983F9_Open;
		else
			{
				__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
				__this->___method_code_6 = (intptr_t)__this->___m_target_2;
			}
	}
	else
	{
		bool isOpen = parameterCount == 0;
		if (isOpen)
		{
			__this->___invoke_impl_1 = (intptr_t)&DestroyPipelineDelegate_Invoke_mE4428F322828BD410B9C74A0358DF87D3A1983F9_Open;
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&DestroyPipelineDelegate_Invoke_mE4428F322828BD410B9C74A0358DF87D3A1983F9_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DestroyPipelineDelegate_Invoke_mE4428F322828BD410B9C74A0358DF87D3A1983F9 (DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___pipeline0, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___pipeline0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* DestroyPipelineDelegate_BeginInvoke_m2902F0B20085FB754D94A373177CBE6D9E7E42E5 (DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* __this, GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___pipeline0, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback1, RuntimeObject* ___object2, const RuntimeMethod* method) 
{
	void *__d_args[2] = {0};
	__d_args[0] = ___pipeline0;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback1, (RuntimeObject*)___object2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DestroyPipelineDelegate_EndInvoke_mBCC8462D17B7FDB6058C446202AAEBBDB9515D46 (DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__cctor_m5C55F17AEAEEFA023973776DB010B54D0D2F8456 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31* L_0 = (U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31*)il2cpp_codegen_object_new(U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CU3Ec__ctor_m0BD6B99048AA4888057E840317CE80F3789BBE8D(L_0, NULL);
		((U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_il2cpp_TypeInfo_var))->___U3CU3E9_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31_il2cpp_TypeInfo_var))->___U3CU3E9_0), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m0BD6B99048AA4888057E840317CE80F3789BBE8D (U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t U3CU3Ec_U3CUpdateComponentPipelineU3Eb__38_0_mB97A4390C0B4AF7335D8A31CABC30B99FC7BFA30 (U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31* __this, CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* ___c10, CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* ___c21, const RuntimeMethod* method) 
{
	{
		CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* L_0 = ___c10;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = VirtualFuncInvoker0< int32_t >::Invoke(6, L_0);
		CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* L_2 = ___c21;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = VirtualFuncInvoker0< int32_t >::Invoke(6, L_2);
		return ((int32_t)il2cpp_codegen_subtract((int32_t)L_1, (int32_t)L_3));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CU3Ec_U3CRequiresUserInputU3Eb__47_0_mBF26B23CBD1B39550F819A03518A8857549B0F31 (U3CU3Ec_t80D8219D255708CC8992C0FAD027B479CB4A4D31* __this, CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* ___c0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t G_B3_0 = 0;
	{
		CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* L_0 = ___c0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_0011;
		}
	}
	{
		CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A* L_2 = ___c0;
		NullCheck(L_2);
		bool L_3;
		L_3 = VirtualFuncInvoker0< bool >::Invoke(13, L_2);
		G_B3_0 = ((int32_t)(L_3));
		goto IL_0012;
	}

IL_0011:
	{
		G_B3_0 = 0;
	}

IL_0012:
	{
		return (bool)G_B3_0;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_OnValidate_m34565B92F078C01A788E839FD887B50F4043CE84 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___CameraSide_10;
		float L_1;
		L_1 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_0, (-1.0f), (1.0f), NULL);
		__this->___CameraSide_10 = L_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_2 = (&__this->___Damping_7);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_3 = (&__this->___Damping_7);
		float L_4 = L_3->___x_2;
		float L_5;
		L_5 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_4, NULL);
		L_2->___x_2 = L_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_6 = (&__this->___Damping_7);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_7 = (&__this->___Damping_7);
		float L_8 = L_7->___y_3;
		float L_9;
		L_9 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_8, NULL);
		L_6->___y_3 = L_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_10 = (&__this->___Damping_7);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_11 = (&__this->___Damping_7);
		float L_12 = L_11->___z_4;
		float L_13;
		L_13 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_12, NULL);
		L_10->___z_4 = L_13;
		float L_14 = __this->___CameraRadius_14;
		float L_15;
		L_15 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.00100000005f), L_14, NULL);
		__this->___CameraRadius_14 = L_15;
		float L_16 = __this->___DampingIntoCollision_15;
		float L_17;
		L_17 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_16, NULL);
		__this->___DampingIntoCollision_15 = L_17;
		float L_18 = __this->___DampingFromCollision_16;
		float L_19;
		L_19 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_18, NULL);
		__this->___DampingFromCollision_16 = L_19;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_Reset_m61AD95A9B447BCC760EDB5F6AF6EE9AFD23F065B (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		memset((&L_0), 0, sizeof(L_0));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_0), (0.5f), (-0.400000006f), (0.0f), NULL);
		__this->___ShoulderOffset_8 = L_0;
		__this->___VerticalArmLength_9 = (0.400000006f);
		__this->___CameraSide_10 = (1.0f);
		__this->___CameraDistance_11 = (2.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		memset((&L_1), 0, sizeof(L_1));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_1), (0.100000001f), (0.5f), (0.300000012f), NULL);
		__this->___Damping_7 = L_1;
		LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB L_2;
		L_2 = LayerMask_op_Implicit_mDC9C22C4477684D460FCF25B1BFE6B54419FB922(0, NULL);
		__this->___CameraCollisionFilter_12 = L_2;
		__this->___CameraRadius_14 = (0.200000003f);
		__this->___DampingIntoCollision_15 = (0.0f);
		__this->___DampingFromCollision_16 = (2.0f);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_OnDestroy_mE3EBAEDC7F1108559BFB0207EAE6E3605DEAAEAF (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RuntimeUtility_t29BFA2198191EF8D4466FBAC7EAB84A1F9702965_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(RuntimeUtility_t29BFA2198191EF8D4466FBAC7EAB84A1F9702965_il2cpp_TypeInfo_var);
		RuntimeUtility_DestroyScratchCollider_m9A1C54492DCE4CD322DAA566818F06CA6F06988E(NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Cinemachine3rdPersonFollow_get_IsValid_m3DA263484276CC7C240C2C3170966CB74597861B (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0017;
	}

IL_0016:
	{
		G_B3_0 = 0;
	}

IL_0017:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Cinemachine3rdPersonFollow_get_Stage_m8932622C583CBBDE9A4CF4614D622F76E0880CFC (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Cinemachine3rdPersonFollow_GetMaxDampTime_mE928D264574DE70999AB305FA793D028936D6BC2 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___DampingIntoCollision_15;
		float L_1 = __this->___DampingFromCollision_16;
		float L_2;
		L_2 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_0, L_1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_3 = (&__this->___Damping_7);
		float L_4 = L_3->___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_5 = (&__this->___Damping_7);
		float L_6 = L_5->___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_7 = (&__this->___Damping_7);
		float L_8 = L_7->___z_4;
		float L_9;
		L_9 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_6, L_8, NULL);
		float L_10;
		L_10 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_4, L_9, NULL);
		float L_11;
		L_11 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_2, L_10, NULL);
		V_0 = L_11;
		goto IL_0045;
	}

IL_0045:
	{
		float L_12 = V_0;
		return L_12;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_MutateCameraState_mEE2F997F216076C29851BA224DD63B0CC3F47C42 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_0 = L_0;
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_002f;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_2;
		L_2 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_2);
		bool L_3;
		L_3 = VirtualFuncInvoker0< bool >::Invoke(31, L_2);
		V_1 = (bool)((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0025;
		}
	}
	{
		___deltaTime1 = (-1.0f);
	}

IL_0025:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_5 = ___curState0;
		float L_6 = ___deltaTime1;
		Cinemachine3rdPersonFollow_PositionCamera_m13334AE8E5681B0F83EB4DC65607CCDEBBE7BC4A(__this, L_5, L_6, NULL);
	}

IL_002f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_OnTargetObjectWarped_mD0303D4A6D9EA4D13150C8C5E93AC843F04B0919 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_0 = ___target0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___positionDelta1;
		CinemachineComponentBase_OnTargetObjectWarped_m3E083DBF03C47860948F0BB3A013B241AFDAF9A0(__this, L_0, L_1, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2 = ___target0;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3;
		L_3 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_2, L_3, NULL);
		V_0 = L_4;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_002e;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = __this->___m_PreviousFollowTargetPosition_17;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___positionDelta1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_6, L_7, NULL);
		__this->___m_PreviousFollowTargetPosition_17 = L_8;
	}

IL_002e:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_PositionCamera_m13334AE8E5681B0F83EB4DC65607CCDEBBE7BC4A (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_7;
	memset((&V_7), 0, sizeof(V_7));
	float V_8 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_9;
	memset((&V_9), 0, sizeof(V_9));
	bool V_10 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_11;
	memset((&V_11), 0, sizeof(V_11));
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_0 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = L_0->___ReferenceUp_1;
		V_0 = L_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		V_1 = L_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3;
		L_3 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		V_2 = L_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		L_5 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_4, L_5, NULL);
		V_3 = L_6;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_7 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_9;
		L_9 = Cinemachine3rdPersonFollow_GetHeading_mAF350E9785F2314EFD8016F12B0ED596E6C66843(L_7, L_8, NULL);
		V_4 = L_9;
		float L_10 = ___deltaTime1;
		V_10 = (bool)((((float)L_10) < ((float)(0.0f)))? 1 : 0);
		bool L_11 = V_10;
		if (!L_11)
		{
			goto IL_0053;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_DampingCorrection_18 = L_12;
		__this->___m_CamPosCollisionCorrection_19 = (0.0f);
		goto IL_00a7;
	}

IL_0053:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = __this->___m_DampingCorrection_18;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_14 = V_4;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_15;
		L_15 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_14, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = __this->___m_PreviousFollowTargetPosition_17;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_16, L_17, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19;
		L_19 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_15, L_18, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20;
		L_20 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_13, L_19, NULL);
		__this->___m_DampingCorrection_18 = L_20;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = __this->___m_DampingCorrection_18;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_22;
		L_22 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = __this->___m_DampingCorrection_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = __this->___Damping_7;
		float L_25 = ___deltaTime1;
		NullCheck(L_22);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26;
		L_26 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m871E131EE59CEEC1B5691F5DC570B18816530C97(L_22, L_23, L_24, L_25, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27;
		L_27 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_21, L_26, NULL);
		__this->___m_DampingCorrection_18 = L_27;
	}

IL_00a7:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = V_1;
		__this->___m_PreviousFollowTargetPosition_17 = L_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29 = V_1;
		V_5 = L_29;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30 = V_5;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_31 = V_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_32 = V_4;
		Cinemachine3rdPersonFollow_GetRawRigPositions_mDE2296B2034978F905A1C9CBAA202EFB174CB1D5(__this, L_30, L_31, L_32, (&V_11), (&V_6), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34 = V_3;
		float L_35 = __this->___CameraDistance_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_36 = (&__this->___m_DampingCorrection_18);
		float L_37 = L_36->___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38;
		L_38 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_34, ((float)il2cpp_codegen_subtract(L_35, L_37)), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39;
		L_39 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_33, L_38, NULL);
		V_7 = L_39;
		V_8 = (0.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_41 = V_6;
		float L_42 = __this->___CameraRadius_14;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43;
		L_43 = Cinemachine3rdPersonFollow_ResolveCollisions_m0803F98237E6C6D08D13173E1FECBDD506860BA4(__this, L_40, L_41, (-1.0f), ((float)il2cpp_codegen_multiply(L_42, (1.04999995f))), (&V_8), NULL);
		V_9 = L_43;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_44 = V_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45 = V_7;
		float L_46 = ___deltaTime1;
		float L_47 = __this->___CameraRadius_14;
		float* L_48 = (&__this->___m_CamPosCollisionCorrection_19);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49;
		L_49 = Cinemachine3rdPersonFollow_ResolveCollisions_m0803F98237E6C6D08D13173E1FECBDD506860BA4(__this, L_44, L_45, L_46, L_47, L_48, NULL);
		V_7 = L_49;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_50 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51 = V_7;
		L_50->___RawPosition_4 = L_51;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_52 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_53 = V_2;
		L_52->___RawOrientation_5 = L_53;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_GetRigPositions_m030DC36FC5FC04F030AAE5DD1DDE3C586F73C534 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___root0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___shoulder1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___hand2, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_2;
	memset((&V_2), 0, sizeof(V_2));
	float V_3 = 0.0f;
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_0;
		L_0 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_0);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_1;
		L_1 = VirtualFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(25, L_0);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = L_1.___ReferenceUp_1;
		V_0 = L_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3;
		L_3 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		V_1 = L_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_6;
		L_6 = Cinemachine3rdPersonFollow_GetHeading_mAF350E9785F2314EFD8016F12B0ED596E6C66843(L_4, L_5, NULL);
		V_2 = L_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_7 = ___root0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = __this->___m_PreviousFollowTargetPosition_17;
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_7 = L_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_9 = ___root0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_9);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_11 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_13 = ___shoulder1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_14 = ___hand2;
		Cinemachine3rdPersonFollow_GetRawRigPositions_mDE2296B2034978F905A1C9CBAA202EFB174CB1D5(__this, L_10, L_11, L_12, L_13, L_14, NULL);
		V_3 = (0.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_15 = ___hand2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_16 = ___root0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_16);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_18 = ___hand2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_18);
		float L_20 = __this->___CameraRadius_14;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21;
		L_21 = Cinemachine3rdPersonFollow_ResolveCollisions_m0803F98237E6C6D08D13173E1FECBDD506860BA4(__this, L_17, L_19, (-1.0f), ((float)il2cpp_codegen_multiply(L_20, (1.04999995f))), (&V_3), NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_15 = L_21;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Cinemachine3rdPersonFollow_GetHeading_mAF350E9785F2314EFD8016F12B0ED596E6C66843 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetRot0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_3;
	memset((&V_3), 0, sizeof(V_3));
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ___targetRot0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_0, L_1, NULL);
		V_0 = L_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_4, L_5, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline(L_6, L_7, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		L_9 = Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline(L_3, L_8, NULL);
		V_1 = L_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_1;
		bool L_11;
		L_11 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_10, NULL);
		V_2 = L_11;
		bool L_12 = V_2;
		if (!L_12)
		{
			goto IL_003d;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_13 = ___targetRot0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14;
		L_14 = Vector3_get_right_m13B7C3EAA64DC921EC23346C56A5A597B5481FF5_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15;
		L_15 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_13, L_14, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		L_17 = Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline(L_15, L_16, NULL);
		V_1 = L_17;
	}

IL_003d:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20;
		L_20 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_18, L_19, NULL);
		V_3 = L_20;
		goto IL_0047;
	}

IL_0047:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_21 = V_3;
		return L_21;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow_GetRawRigPositions_mDE2296B2034978F905A1C9CBAA202EFB174CB1D5 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___root0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetRot1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___heading2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___shoulder3, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___hand4, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___ShoulderOffset_8;
		V_0 = L_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		float L_2 = L_1.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = V_0;
		float L_4 = L_3.___x_2;
		float L_5 = __this->___CameraSide_10;
		float L_6;
		L_6 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline(((-L_2)), L_4, L_5, NULL);
		(&V_0)->___x_2 = L_6;
		float* L_7 = (&(&V_0)->___x_2);
		float* L_8 = L_7;
		float L_9 = *((float*)L_8);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_10 = (&__this->___m_DampingCorrection_18);
		float L_11 = L_10->___x_2;
		*((float*)L_8) = (float)((float)il2cpp_codegen_add(L_9, L_11));
		float* L_12 = (&(&V_0)->___y_3);
		float* L_13 = L_12;
		float L_14 = *((float*)L_13);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_15 = (&__this->___m_DampingCorrection_18);
		float L_16 = L_15->___y_3;
		*((float*)L_13) = (float)((float)il2cpp_codegen_add(L_14, L_16));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_17 = ___shoulder3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = ___root0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_19 = ___heading2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21;
		L_21 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_19, L_20, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22;
		L_22 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_18, L_21, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_17 = L_22;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_23 = ___hand4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_24 = ___shoulder3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_24);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_26 = ___targetRot1;
		float L_27 = __this->___VerticalArmLength_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28;
		memset((&L_28), 0, sizeof(L_28));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_28), (0.0f), L_27, (0.0f), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29;
		L_29 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_26, L_28, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		L_30 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_25, L_29, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_23 = L_30;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Cinemachine3rdPersonFollow_ResolveCollisions_m0803F98237E6C6D08D13173E1FECBDD506860BA4 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___root0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___tip1, float ___deltaTime2, float ___cameraRadius3, float* ___collisionCorrection4, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RuntimeUtility_t29BFA2198191EF8D4466FBAC7EAB84A1F9702965_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	float V_1 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	float V_3 = 0.0f;
	RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 V_4;
	memset((&V_4), 0, sizeof(V_4));
	bool V_5 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	bool V_7 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_8;
	memset((&V_8), 0, sizeof(V_8));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_9;
	memset((&V_9), 0, sizeof(V_9));
	bool V_10 = false;
	float G_B9_0 = 0.0f;
	float* G_B9_1 = NULL;
	float G_B5_0 = 0.0f;
	float* G_B5_1 = NULL;
	float G_B7_0 = 0.0f;
	float G_B7_1 = 0.0f;
	float* G_B7_2 = NULL;
	float G_B6_0 = 0.0f;
	float G_B6_1 = 0.0f;
	float* G_B6_2 = NULL;
	float G_B8_0 = 0.0f;
	float G_B8_1 = 0.0f;
	float G_B8_2 = 0.0f;
	float* G_B8_3 = NULL;
	float G_B10_0 = 0.0f;
	float G_B10_1 = 0.0f;
	float* G_B10_2 = NULL;
	{
		LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB* L_0 = (&__this->___CameraCollisionFilter_12);
		int32_t L_1;
		L_1 = LayerMask_get_value_m70CBE32210A1F0FD4ECB850285DA90ED57B87974(L_0, NULL);
		V_5 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_5;
		if (!L_2)
		{
			goto IL_001e;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___tip1;
		V_6 = L_3;
		goto IL_00eb;
	}

IL_001e:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___tip1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = ___root0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_4, L_5, NULL);
		V_0 = L_6;
		float L_7;
		L_7 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_0), NULL);
		V_1 = L_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = V_0;
		float L_9 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10;
		L_10 = Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline(L_8, L_9, NULL);
		V_0 = L_10;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = ___tip1;
		V_2 = L_11;
		V_3 = (0.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = ___root0;
		float L_13 = ___cameraRadius3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = V_0;
		float L_15 = V_1;
		LayerMask_t97CB6BDADEDC3D6423C7BCFEA7F86DA2EC6241DB L_16 = __this->___CameraCollisionFilter_12;
		int32_t L_17;
		L_17 = LayerMask_op_Implicit_m5D697E103A7CB05CADCED9F90FD4F6BAE955E763(L_16, NULL);
		String_t** L_18 = (&__this->___IgnoreTag_13);
		il2cpp_codegen_runtime_class_init_inline(RuntimeUtility_t29BFA2198191EF8D4466FBAC7EAB84A1F9702965_il2cpp_TypeInfo_var);
		bool L_19;
		L_19 = RuntimeUtility_SphereCastIgnoreTag_m87978D006531BAD6403611588E8D68DE989270A8(L_12, L_13, L_14, (&V_4), L_15, L_17, L_18, NULL);
		V_7 = L_19;
		bool L_20 = V_7;
		if (!L_20)
		{
			goto IL_0091;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21;
		L_21 = RaycastHit_get_point_m02B764612562AFE0F998CC7CFB2EEDE41BA47F39((&V_4), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22;
		L_22 = RaycastHit_get_normal_mD8741B70D2039C5CAFC4368D4CE59D89562040B5((&V_4), NULL);
		float L_23 = ___cameraRadius3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_22, L_23, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_21, L_24, NULL);
		V_8 = L_25;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26 = V_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = ___tip1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28;
		L_28 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_26, L_27, NULL);
		V_9 = L_28;
		float L_29;
		L_29 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_9), NULL);
		V_3 = L_29;
	}

IL_0091:
	{
		float* L_30 = ___collisionCorrection4;
		float* L_31 = ___collisionCorrection4;
		float L_32 = *((float*)L_31);
		float L_33 = ___deltaTime2;
		G_B5_0 = L_32;
		G_B5_1 = L_30;
		if ((((float)L_33) < ((float)(0.0f))))
		{
			G_B9_0 = L_32;
			G_B9_1 = L_30;
			goto IL_00bf;
		}
	}
	{
		float L_34 = V_3;
		float* L_35 = ___collisionCorrection4;
		float L_36 = *((float*)L_35);
		float L_37 = V_3;
		float* L_38 = ___collisionCorrection4;
		float L_39 = *((float*)L_38);
		G_B6_0 = ((float)il2cpp_codegen_subtract(L_34, L_36));
		G_B6_1 = G_B5_0;
		G_B6_2 = G_B5_1;
		if ((((float)L_37) > ((float)L_39)))
		{
			G_B7_0 = ((float)il2cpp_codegen_subtract(L_34, L_36));
			G_B7_1 = G_B5_0;
			G_B7_2 = G_B5_1;
			goto IL_00b1;
		}
	}
	{
		float L_40 = __this->___DampingFromCollision_16;
		G_B8_0 = L_40;
		G_B8_1 = G_B6_0;
		G_B8_2 = G_B6_1;
		G_B8_3 = G_B6_2;
		goto IL_00b7;
	}

IL_00b1:
	{
		float L_41 = __this->___DampingIntoCollision_15;
		G_B8_0 = L_41;
		G_B8_1 = G_B7_0;
		G_B8_2 = G_B7_1;
		G_B8_3 = G_B7_2;
	}

IL_00b7:
	{
		float L_42 = ___deltaTime2;
		float L_43;
		L_43 = Damper_Damp_mFB62278C063E2CAA706D30E8D68AF55D50AE95D2(G_B8_1, G_B8_0, L_42, NULL);
		G_B10_0 = L_43;
		G_B10_1 = G_B8_2;
		G_B10_2 = G_B8_3;
		goto IL_00c4;
	}

IL_00bf:
	{
		float L_44 = V_3;
		float* L_45 = ___collisionCorrection4;
		float L_46 = *((float*)L_45);
		G_B10_0 = ((float)il2cpp_codegen_subtract(L_44, L_46));
		G_B10_1 = G_B9_0;
		G_B10_2 = G_B9_1;
	}

IL_00c4:
	{
		*((float*)G_B10_2) = (float)((float)il2cpp_codegen_add(G_B10_1, G_B10_0));
		float* L_47 = ___collisionCorrection4;
		float L_48 = *((float*)L_47);
		V_10 = (bool)((((float)L_48) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_49 = V_10;
		if (!L_49)
		{
			goto IL_00e6;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51 = V_0;
		float* L_52 = ___collisionCorrection4;
		float L_53 = *((float*)L_52);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_54;
		L_54 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_51, L_53, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_55;
		L_55 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_50, L_54, NULL);
		V_2 = L_55;
	}

IL_00e6:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_56 = V_2;
		V_6 = L_56;
		goto IL_00eb;
	}

IL_00eb:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_57 = V_6;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Cinemachine3rdPersonFollow__ctor_m239FDBE524C3BED33399C39822BBB7A63EFE95E9 (Cinemachine3rdPersonFollow_t1003E9360E9E904536DBA47C179836CF007B94D0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
		__this->___IgnoreTag_13 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___IgnoreTag_13), (void*)L_0);
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineBasicMultiChannelPerlin_get_IsValid_m8330E1B15909306345A589EFD1BA1A9AA223E0F3 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1* L_1 = __this->___m_NoiseProfile_7;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineBasicMultiChannelPerlin_get_Stage_mF7751E50B715EDFACEE2CE2A56999B0B3F40F024 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 2;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBasicMultiChannelPerlin_MutateCameraState_mD65925FD4858E9650DB79BFB8CBD75D0E2224CC4 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_5;
	memset((&V_5), 0, sizeof(V_5));
	int32_t G_B3_0 = 0;
	int32_t G_B10_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		float L_1 = ___deltaTime1;
		G_B3_0 = ((((float)L_1) < ((float)(0.0f)))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		V_1 = (bool)G_B3_0;
		bool L_2 = V_1;
		if (!L_2)
		{
			goto IL_0025;
		}
	}
	{
		__this->___mInitialized_11 = (bool)0;
		goto IL_0177;
	}

IL_0025:
	{
		bool L_3 = __this->___mInitialized_11;
		V_2 = (bool)((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0039;
		}
	}
	{
		CinemachineBasicMultiChannelPerlin_Initialize_m1ADAFB3D2CAFBEBC0018D71B44BDCD24074EAEC2(__this, NULL);
	}

IL_0039:
	{
		int32_t L_5;
		L_5 = TargetPositionCache_get_CacheMode_mDCBA178980BB6A8FEEC18CA1238F52FFDFC8B5A4_inline(NULL);
		if ((!(((uint32_t)L_5) == ((uint32_t)2))))
		{
			goto IL_0048;
		}
	}
	{
		bool L_6;
		L_6 = TargetPositionCache_get_HasCurrentTime_m143562F778152928D6FE2E609F81786513F6ED2F(NULL);
		G_B10_0 = ((int32_t)(L_6));
		goto IL_0049;
	}

IL_0048:
	{
		G_B10_0 = 0;
	}

IL_0049:
	{
		V_3 = (bool)G_B10_0;
		bool L_7 = V_3;
		if (!L_7)
		{
			goto IL_0061;
		}
	}
	{
		float L_8 = ((TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_StaticFields*)il2cpp_codegen_static_fields_for(TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_il2cpp_TypeInfo_var))->___CurrentTime_3;
		float L_9 = __this->___m_FrequencyGain_10;
		__this->___mNoiseTime_12 = ((float)il2cpp_codegen_multiply(L_8, L_9));
		goto IL_0076;
	}

IL_0061:
	{
		float L_10 = __this->___mNoiseTime_12;
		float L_11 = ___deltaTime1;
		float L_12 = __this->___m_FrequencyGain_10;
		__this->___mNoiseTime_12 = ((float)il2cpp_codegen_add(L_10, ((float)il2cpp_codegen_multiply(L_11, L_12))));
	}

IL_0076:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_13 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_14 = (&L_13->___PositionCorrection_8);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_15 = L_14;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_15);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_17 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_18;
		L_18 = CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8(L_17, NULL);
		NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1* L_19 = __this->___m_NoiseProfile_7;
		NullCheck(L_19);
		TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1* L_20 = L_19->___PositionNoise_4;
		float L_21 = __this->___mNoiseTime_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = __this->___mNoiseOffsets_13;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = NoiseSettings_GetCombinedFilterResults_mE35B3A4E1826146B200499B62617F8E629434F20(L_20, L_21, L_22, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_18, L_23, NULL);
		float L_25 = __this->___m_AmplitudeGain_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26;
		L_26 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_24, L_25, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27;
		L_27 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_16, L_26, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_15 = L_27;
		NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1* L_28 = __this->___m_NoiseProfile_7;
		NullCheck(L_28);
		TransformNoiseParamsU5BU5D_tF60A55DA82A2705F76287D97294759C1F37888A1* L_29 = L_28->___OrientationNoise_5;
		float L_30 = __this->___mNoiseTime_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = __this->___mNoiseOffsets_13;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = NoiseSettings_GetCombinedFilterResults_mE35B3A4E1826146B200499B62617F8E629434F20(L_29, L_30, L_31, NULL);
		float L_33 = __this->___m_AmplitudeGain_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34;
		L_34 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_32, L_33, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_35;
		L_35 = Quaternion_Euler_m66E346161C9778DF8486DB4FE823D8F81A54AF1D_inline(L_34, NULL);
		V_0 = L_35;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36 = __this->___m_PivotOffset_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_37;
		L_37 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		bool L_38;
		L_38 = Vector3_op_Inequality_m6A7FB1C9E9DE194708997BFA24C6E238D92D908E_inline(L_36, L_37, NULL);
		V_4 = L_38;
		bool L_39 = V_4;
		if (!L_39)
		{
			goto IL_0165;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40 = __this->___m_PivotOffset_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_41;
		L_41 = Vector3_op_UnaryNegation_m3AC523A7BED6E843165BDF598690F0560D8CAA63_inline(L_40, NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_42;
		L_42 = Matrix4x4_Translate_m95D44EDD1A9856DD11C639692E47B7A35EF745E2(L_41, NULL);
		V_5 = L_42;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_43 = V_0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_44;
		L_44 = Matrix4x4_Rotate_mE2C31B51EEC282F2969B9C2BE24BD73E312807E8(L_43, NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_45 = V_5;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_46;
		L_46 = Matrix4x4_op_Multiply_m7649669D493400913FF60AFB04B1C19F14E0FDB0(L_44, L_45, NULL);
		V_5 = L_46;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47 = __this->___m_PivotOffset_8;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_48;
		L_48 = Matrix4x4_Translate_m95D44EDD1A9856DD11C639692E47B7A35EF745E2(L_47, NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_49 = V_5;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_50;
		L_50 = Matrix4x4_op_Multiply_m7649669D493400913FF60AFB04B1C19F14E0FDB0(L_48, L_49, NULL);
		V_5 = L_50;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_51 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_52 = (&L_51->___PositionCorrection_8);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_53 = L_52;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_54 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_53);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_55 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_56;
		L_56 = CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8(L_55, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_57;
		L_57 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_58;
		L_58 = Matrix4x4_MultiplyPoint_m20E910B65693559BFDE99382472D8DD02C862E7E((&V_5), L_57, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_59;
		L_59 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_56, L_58, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_60;
		L_60 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_54, L_59, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_53 = L_60;
	}

IL_0165:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_61 = ___curState0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_62 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_63 = L_62->___OrientationCorrection_9;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_64 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_65;
		L_65 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_63, L_64, NULL);
		L_61->___OrientationCorrection_9 = L_65;
	}

IL_0177:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBasicMultiChannelPerlin_ReSeed_m386B1BA6AEFB26B878A7431484D412F9FB2E9696 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, const RuntimeMethod* method) 
{
	{
		float L_0;
		L_0 = Random_Range_mF26F26EB446B76823B4815C91FA0907B484DF02B((-1000.0f), (1000.0f), NULL);
		float L_1;
		L_1 = Random_Range_mF26F26EB446B76823B4815C91FA0907B484DF02B((-1000.0f), (1000.0f), NULL);
		float L_2;
		L_2 = Random_Range_mF26F26EB446B76823B4815C91FA0907B484DF02B((-1000.0f), (1000.0f), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		memset((&L_3), 0, sizeof(L_3));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_3), L_0, L_1, L_2, NULL);
		__this->___mNoiseOffsets_13 = L_3;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBasicMultiChannelPerlin_Initialize_m1ADAFB3D2CAFBEBC0018D71B44BDCD24074EAEC2 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		__this->___mInitialized_11 = (bool)1;
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		float L_0;
		L_0 = CinemachineCore_get_CurrentTime_mE95A89B5053FB5D86EB1E2D855CDC9E4D4CC5459(NULL);
		float L_1 = __this->___m_FrequencyGain_10;
		__this->___mNoiseTime_12 = ((float)il2cpp_codegen_multiply(L_0, L_1));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = __this->___mNoiseOffsets_13;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		bool L_4;
		L_4 = Vector3_op_Equality_m15951D1B53E3BE36C9D265E229090020FBD72EBB_inline(L_2, L_3, NULL);
		V_0 = L_4;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_0035;
		}
	}
	{
		CinemachineBasicMultiChannelPerlin_ReSeed_m386B1BA6AEFB26B878A7431484D412F9FB2E9696(__this, NULL);
	}

IL_0035:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBasicMultiChannelPerlin__ctor_mEE8548285D383571E5AC2DB0740D8FD906BF8A50 (CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_PivotOffset_8 = L_0;
		__this->___m_AmplitudeGain_9 = (1.0f);
		__this->___m_FrequencyGain_10 = (1.0f);
		__this->___mInitialized_11 = (bool)0;
		__this->___mNoiseTime_12 = (0.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___mNoiseOffsets_13 = L_1;
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineComposer_get_IsValid_mF1833F36F4B8823131C599CADEB5EE0A3CFCF062 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_LookAtTarget_m7E6CF239A3905B1130A5C38B0E5668EB32D1BB04(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineComposer_get_Stage_mF5E0C634D954BFFAB5A2EBFB4B4DA326D6853A6F (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 1;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___U3CTrackedPointU3Ek__BackingField_22;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_set_TrackedPoint_mC2806265609C1BADBE1F83DD18F800BDA064D5A6 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___value0;
		__this->___U3CTrackedPointU3Ek__BackingField_22 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineComposer_GetLookAtPointAndSetTrackedPoint_m5810F9F4FEC4860FE749CB7260E78E8BEE41E671 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lookAt0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, float ___deltaTime2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	bool V_5 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	int32_t G_B7_0 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B9_0;
	memset((&G_B9_0), 0, sizeof(G_B9_0));
	PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* G_B9_1 = NULL;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B8_0;
	memset((&G_B8_0), 0, sizeof(G_B8_0));
	PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* G_B8_1 = NULL;
	float G_B10_0 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B10_1;
	memset((&G_B10_1), 0, sizeof(G_B10_1));
	PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* G_B10_2 = NULL;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___lookAt0;
		V_0 = L_0;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_LookAtTarget_m7E6CF239A3905B1130A5C38B0E5668EB32D1BB04(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_1 = L_2;
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_002b;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_5;
		L_5 = CinemachineComponentBase_get_LookAtTargetRotation_m49CBE00226BB55772DB73775412AF782892B8251(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = __this->___m_TrackedObjectOffset_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_5, L_6, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_4, L_7, NULL);
		V_0 = L_8;
	}

IL_002b:
	{
		float L_9 = __this->___m_LookaheadTime_8;
		V_2 = (bool)((((float)L_9) < ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_10 = V_2;
		if (!L_10)
		{
			goto IL_0049;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = V_0;
		CinemachineComposer_set_TrackedPoint_mC2806265609C1BADBE1F83DD18F800BDA064D5A6_inline(__this, L_11, NULL);
		goto IL_00d1;
	}

IL_0049:
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_12;
		L_12 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_12);
		bool L_13;
		L_13 = CinemachineVirtualCameraBase_get_LookAtTargetChanged_m6D2FF4FB863501796CB778CB7AABA0126E57C134_inline(L_12, NULL);
		if (L_13)
		{
			goto IL_0067;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_14;
		L_14 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_14);
		bool L_15;
		L_15 = VirtualFuncInvoker0< bool >::Invoke(31, L_14);
		G_B7_0 = ((((int32_t)L_15) == ((int32_t)0))? 1 : 0);
		goto IL_0068;
	}

IL_0067:
	{
		G_B7_0 = 1;
	}

IL_0068:
	{
		V_3 = (bool)G_B7_0;
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_16 = __this->___m_Predictor_27;
		float L_17 = __this->___m_LookaheadSmoothing_9;
		NullCheck(L_16);
		L_16->___Smoothing_4 = L_17;
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_18 = __this->___m_Predictor_27;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = V_0;
		bool L_20 = V_3;
		G_B8_0 = L_19;
		G_B8_1 = L_18;
		if (L_20)
		{
			G_B9_0 = L_19;
			G_B9_1 = L_18;
			goto IL_0087;
		}
	}
	{
		float L_21 = ___deltaTime2;
		G_B10_0 = L_21;
		G_B10_1 = G_B8_0;
		G_B10_2 = G_B8_1;
		goto IL_008c;
	}

IL_0087:
	{
		G_B10_0 = (-1.0f);
		G_B10_1 = G_B9_0;
		G_B10_2 = G_B9_1;
	}

IL_008c:
	{
		float L_22 = __this->___m_LookaheadTime_8;
		NullCheck(G_B10_2);
		PositionPredictor_AddPosition_mB5EFA6BB6598A9D52D1CE6BD50400E56938C433C(G_B10_2, G_B10_1, G_B10_0, L_22, NULL);
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_23 = __this->___m_Predictor_27;
		float L_24 = __this->___m_LookaheadTime_8;
		NullCheck(L_23);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = PositionPredictor_PredictPositionDelta_mC16231F75C5C088B5CC2444D3C2FA12F6DACC4AD(L_23, L_24, NULL);
		V_4 = L_25;
		bool L_26 = __this->___m_LookaheadIgnoreY_10;
		V_5 = L_26;
		bool L_27 = V_5;
		if (!L_27)
		{
			goto IL_00c1;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		L_30 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_28, L_29, NULL);
		V_4 = L_30;
	}

IL_00c1:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33;
		L_33 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_31, L_32, NULL);
		CinemachineComposer_set_TrackedPoint_mC2806265609C1BADBE1F83DD18F800BDA064D5A6_inline(__this, L_33, NULL);
	}

IL_00d1:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34 = V_0;
		V_6 = L_34;
		goto IL_00d6;
	}

IL_00d6:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35 = V_6;
		return L_35;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_OnTargetObjectWarped_m14DFF01ED1173B5902E80C9A55AD2C1998481789 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_0 = ___target0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___positionDelta1;
		CinemachineComponentBase_OnTargetObjectWarped_m3E083DBF03C47860948F0BB3A013B241AFDAF9A0(__this, L_0, L_1, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2 = ___target0;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3;
		L_3 = CinemachineComponentBase_get_LookAtTarget_m7E6CF239A3905B1130A5C38B0E5668EB32D1BB04(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_2, L_3, NULL);
		V_0 = L_4;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_004d;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = __this->___m_CameraPosPrevFrame_23;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___positionDelta1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_6, L_7, NULL);
		__this->___m_CameraPosPrevFrame_23 = L_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = __this->___m_LookAtPrevFrame_24;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___positionDelta1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_9, L_10, NULL);
		__this->___m_LookAtPrevFrame_24 = L_11;
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_12 = __this->___m_Predictor_27;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = ___positionDelta1;
		NullCheck(L_12);
		PositionPredictor_ApplyTransformDelta_mDA012CCA329F143DDF342616369F0E75B2E2C97A(L_12, L_13, NULL);
	}

IL_004d:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_ForceCameraPosition_m190442A4F145C4B298B785DAE08EC8358B924B70 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rot1, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___pos0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = ___rot1;
		CinemachineComponentBase_ForceCameraPosition_m3D22002EC0B4F5C1AF7CC283C00BA43D22120878(__this, L_0, L_1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___pos0;
		__this->___m_CameraPosPrevFrame_23 = L_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3 = ___rot1;
		__this->___m_CameraOrientationPrevFrame_26 = L_3;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineComposer_GetMaxDampTime_m1D830B2C6BDB743F6C546C27AA62A60704BC4CA0 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_HorizontalDamping_11;
		float L_1 = __this->___m_VerticalDamping_12;
		float L_2;
		L_2 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_0, L_1, NULL);
		V_0 = L_2;
		goto IL_0015;
	}

IL_0015:
	{
		float L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_PrePipelineMutateCameraState_m6A2121831D76E0CD191FC63A7C63167AB917190B (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		if (!L_0)
		{
			goto IL_0011;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_1 = ___curState0;
		bool L_2;
		L_2 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC(L_1, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0012;
	}

IL_0011:
	{
		G_B3_0 = 0;
	}

IL_0012:
	{
		V_0 = (bool)G_B3_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_002f;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_4 = ___curState0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_5 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = L_5->___ReferenceLookAt_2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_7 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = L_7->___ReferenceUp_1;
		float L_9 = ___deltaTime1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10;
		L_10 = VirtualFuncInvoker3< Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, float >::Invoke(14, __this, L_6, L_8, L_9);
		L_4->___ReferenceLookAt_2 = L_10;
	}

IL_002f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_MutateCameraState_m50DD037C33A1BF4956C47F8ADA6F6CBADDDA4B3A (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	bool V_3 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	bool V_7 = false;
	float V_8 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_9;
	memset((&V_9), 0, sizeof(V_9));
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_13;
	memset((&V_13), 0, sizeof(V_13));
	bool V_14 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_15;
	memset((&V_15), 0, sizeof(V_15));
	bool V_16 = false;
	bool V_17 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B13_0 = 0;
	int32_t G_B19_0 = 0;
	int32_t G_B29_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_1 = ___curState0;
		bool L_2;
		L_2 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC(L_1, NULL);
		G_B3_0 = ((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_3 = V_2;
		if (!L_3)
		{
			goto IL_001e;
		}
	}
	{
		goto IL_033b;
	}

IL_001e:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4;
		L_4 = CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline(__this, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_5 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = L_5->___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_4, L_6, NULL);
		bool L_8;
		L_8 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_7, NULL);
		V_3 = (bool)((((int32_t)L_8) == ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_00c9;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_10 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089(L_10, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_12 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = L_12->___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14;
		L_14 = Vector3_Lerp_m57EE8D709A93B2B0FF8D499FA2947B1D61CB1FD6_inline(L_11, L_13, (0.5f), NULL);
		V_4 = L_14;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_15 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = L_15->___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_16, L_17, NULL);
		V_5 = L_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19;
		L_19 = CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21;
		L_21 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_19, L_20, NULL);
		V_6 = L_21;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = V_6;
		float L_24;
		L_24 = Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline(L_22, L_23, NULL);
		V_7 = (bool)((((float)L_24) < ((float)(0.0f)))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00c8;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_26 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = L_26->___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = V_4;
		float L_29;
		L_29 = Vector3_Distance_m99C722723EDD875852EF854AD7B7C4F8AC4F84AB_inline(L_27, L_28, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_30 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = L_30->___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline(__this, NULL);
		float L_33;
		L_33 = Vector3_Distance_m99C722723EDD875852EF854AD7B7C4F8AC4F84AB_inline(L_31, L_32, NULL);
		V_8 = ((float)(L_29/L_33));
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_34 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35 = L_34->___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36;
		L_36 = CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline(__this, NULL);
		float L_37 = V_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38;
		L_38 = Vector3_Lerp_m57EE8D709A93B2B0FF8D499FA2947B1D61CB1FD6_inline(L_35, L_36, L_37, NULL);
		CinemachineComposer_set_TrackedPoint_mC2806265609C1BADBE1F83DD18F800BDA064D5A6_inline(__this, L_38, NULL);
	}

IL_00c8:
	{
	}

IL_00c9:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39;
		L_39 = CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline(__this, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_40 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_41;
		L_41 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089(L_40, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42;
		L_42 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_39, L_41, NULL);
		V_9 = L_42;
		float L_43;
		L_43 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_9), NULL);
		V_0 = L_43;
		float L_44 = V_0;
		V_10 = (bool)((((float)L_44) < ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_45 = V_10;
		if (!L_45)
		{
			goto IL_0120;
		}
	}
	{
		float L_46 = ___deltaTime1;
		if ((!(((float)L_46) >= ((float)(0.0f)))))
		{
			goto IL_0108;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_47;
		L_47 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_47);
		bool L_48;
		L_48 = VirtualFuncInvoker0< bool >::Invoke(31, L_47);
		G_B13_0 = ((int32_t)(L_48));
		goto IL_0109;
	}

IL_0108:
	{
		G_B13_0 = 0;
	}

IL_0109:
	{
		V_11 = (bool)G_B13_0;
		bool L_49 = V_11;
		if (!L_49)
		{
			goto IL_011b;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_50 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_51 = __this->___m_CameraOrientationPrevFrame_26;
		L_50->___RawOrientation_5 = L_51;
	}

IL_011b:
	{
		goto IL_033b;
	}

IL_0120:
	{
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_52 = (&__this->___mCache_28);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_53 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_54 = L_53->___Lens_0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_55;
		L_55 = CinemachineComposer_get_SoftGuideRect_mFFE86E73B085263B4B15F2E5BD8053F8C033E8E1(__this, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_56;
		L_56 = CinemachineComposer_get_HardGuideRect_mA2B70FA82432B7D2874E5213E3F9086CC152E69F(__this, NULL);
		float L_57 = V_0;
		FovCache_UpdateCache_m3462592E7672B43BEB32686E0F62B7C17F0E2999(L_52, L_54, L_55, L_56, L_57, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_58 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_59 = L_58->___RawOrientation_5;
		V_1 = L_59;
		float L_60 = ___deltaTime1;
		if ((((float)L_60) < ((float)(0.0f))))
		{
			goto IL_015e;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_61;
		L_61 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_61);
		bool L_62;
		L_62 = VirtualFuncInvoker0< bool >::Invoke(31, L_61);
		G_B19_0 = ((((int32_t)L_62) == ((int32_t)0))? 1 : 0);
		goto IL_015f;
	}

IL_015e:
	{
		G_B19_0 = 1;
	}

IL_015f:
	{
		V_12 = (bool)G_B19_0;
		bool L_63 = V_12;
		if (!L_63)
		{
			goto IL_01dc;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_64 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_65;
		L_65 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_66;
		L_66 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_64, L_65, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_67 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_68 = L_67->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_69;
		L_69 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_66, L_68, NULL);
		V_1 = L_69;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_70 = (&__this->___mCache_28);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_71 = L_70->___mFovSoftGuideRect_0;
		V_13 = L_71;
		bool L_72 = __this->___m_CenterOnActivate_21;
		V_14 = L_72;
		bool L_73 = V_14;
		if (!L_73)
		{
			goto IL_01a9;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_74;
		L_74 = Rect_get_center_mAA9A2E1F058B2C9F58E13CC4822F789F42975E5C_inline((&V_13), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_75;
		L_75 = Vector2_get_zero_m009B92B5D35AB02BD1610C2E1ACCE7C9CF964A6E_inline(NULL);
		Rect__ctor_m503705FE0E4E413041E3CE7F09270489F401C675_inline((&V_13), L_74, L_75, NULL);
	}

IL_01a9:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_76 = ___curState0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_77 = V_13;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_78 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79 = L_78->___ReferenceLookAt_2;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_80 = (&__this->___mCache_28);
		float L_81 = L_80->___mFov_3;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_82 = (&__this->___mCache_28);
		float L_83 = L_82->___mFovH_2;
		CinemachineComposer_RotateToScreenBounds_m01D1A38D82DF6AE50EFF13027781D15DED32D7EF(__this, L_76, L_77, L_79, (&V_1), L_81, L_83, (-1.0f), NULL);
		goto IL_02e3;
	}

IL_01dc:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_84 = __this->___m_LookAtPrevFrame_24;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_85 = __this->___m_CameraPosPrevFrame_23;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_86;
		L_86 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_84, L_85, NULL);
		V_15 = L_86;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_87 = V_15;
		bool L_88;
		L_88 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_87, NULL);
		V_16 = L_88;
		bool L_89 = V_16;
		if (!L_89)
		{
			goto IL_021b;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_90 = __this->___m_CameraOrientationPrevFrame_26;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_91;
		L_91 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_92;
		L_92 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_90, L_91, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_93 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_94 = L_93->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_95;
		L_95 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_92, L_94, NULL);
		V_1 = L_95;
		goto IL_0257;
	}

IL_021b:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_96 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_97 = L_96->___PositionDampingBypass_6;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_98;
		L_98 = Quaternion_Euler_m66E346161C9778DF8486DB4FE823D8F81A54AF1D_inline(L_97, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_99 = V_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_100;
		L_100 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_98, L_99, NULL);
		V_15 = L_100;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_101 = V_15;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_102 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_103 = L_102->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_104;
		L_104 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_101, L_103, NULL);
		V_1 = L_104;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_105 = V_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_106 = __this->___m_ScreenOffsetPrevFrame_25;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_107;
		L_107 = Vector2_op_UnaryNegation_m47556D28F72B018AC4D5160710C83A805F10A783_inline(L_106, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_108 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_109 = L_108->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_110;
		L_110 = UnityQuaternionExtensions_ApplyCameraRotation_m75753B356C2E3BC79192192C8C2FC1F512643506(L_105, L_107, L_109, NULL);
		V_1 = L_110;
	}

IL_0257:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_111 = ___curState0;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_112 = (&__this->___mCache_28);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_113 = L_112->___mFovSoftGuideRect_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_114;
		L_114 = CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline(__this, NULL);
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_115 = (&__this->___mCache_28);
		float L_116 = L_115->___mFov_3;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_117 = (&__this->___mCache_28);
		float L_118 = L_117->___mFovH_2;
		float L_119 = ___deltaTime1;
		CinemachineComposer_RotateToScreenBounds_m01D1A38D82DF6AE50EFF13027781D15DED32D7EF(__this, L_111, L_113, L_114, (&V_1), L_116, L_118, L_119, NULL);
		float L_120 = ___deltaTime1;
		if ((((float)L_120) < ((float)(0.0f))))
		{
			goto IL_02a5;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_121;
		L_121 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_121);
		float L_122 = L_121->___LookAtTargetAttachment_13;
		G_B29_0 = ((((float)L_122) > ((float)(0.999899983f)))? 1 : 0);
		goto IL_02a6;
	}

IL_02a5:
	{
		G_B29_0 = 1;
	}

IL_02a6:
	{
		V_17 = (bool)G_B29_0;
		bool L_123 = V_17;
		if (!L_123)
		{
			goto IL_02e2;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_124 = ___curState0;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_125 = (&__this->___mCache_28);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_126 = L_125->___mFovHardGuideRect_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_127 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_128 = L_127->___ReferenceLookAt_2;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_129 = (&__this->___mCache_28);
		float L_130 = L_129->___mFov_3;
		FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* L_131 = (&__this->___mCache_28);
		float L_132 = L_131->___mFovH_2;
		CinemachineComposer_RotateToScreenBounds_m01D1A38D82DF6AE50EFF13027781D15DED32D7EF(__this, L_124, L_126, L_128, (&V_1), L_130, L_132, (-1.0f), NULL);
	}

IL_02e2:
	{
	}

IL_02e3:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_133 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_134;
		L_134 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089(L_133, NULL);
		__this->___m_CameraPosPrevFrame_23 = L_134;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_135;
		L_135 = CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline(__this, NULL);
		__this->___m_LookAtPrevFrame_24 = L_135;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_136 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_137;
		L_137 = UnityQuaternionExtensions_Normalized_mECDA291E5D4B3D2D610FE74D89D7F2F7ED0B5E68(L_136, NULL);
		__this->___m_CameraOrientationPrevFrame_26 = L_137;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_138 = __this->___m_CameraOrientationPrevFrame_26;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_139 = __this->___m_LookAtPrevFrame_24;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_140 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_141;
		L_141 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089(L_140, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_142;
		L_142 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_139, L_141, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_143 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_144 = L_143->___ReferenceUp_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_145;
		L_145 = UnityQuaternionExtensions_GetCameraRotationToTarget_mDA1EF1466263B671B863D70DABBD50DF9785C2B7(L_138, L_142, L_144, NULL);
		__this->___m_ScreenOffsetPrevFrame_25 = L_145;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_146 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_147 = __this->___m_CameraOrientationPrevFrame_26;
		L_146->___RawOrientation_5 = L_147;
	}

IL_033b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineComposer_get_SoftGuideRect_mFFE86E73B085263B4B15F2E5BD8053F8C033E8E1 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = __this->___m_ScreenX_13;
		float L_1 = __this->___m_DeadZoneWidth_15;
		float L_2 = __this->___m_ScreenY_14;
		float L_3 = __this->___m_DeadZoneHeight_16;
		float L_4 = __this->___m_DeadZoneWidth_15;
		float L_5 = __this->___m_DeadZoneHeight_16;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_6;
		memset((&L_6), 0, sizeof(L_6));
		Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23_inline((&L_6), ((float)il2cpp_codegen_subtract(L_0, ((float)(L_1/(2.0f))))), ((float)il2cpp_codegen_subtract(L_2, ((float)(L_3/(2.0f))))), L_4, L_5, NULL);
		V_0 = L_6;
		goto IL_003b;
	}

IL_003b:
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_7 = V_0;
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_set_SoftGuideRect_mF24C9DED070606ED93AC69CC0F2AB72BB55A1ADA (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___value0, const RuntimeMethod* method) 
{
	{
		float L_0;
		L_0 = Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline((&___value0), NULL);
		float L_1;
		L_1 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_0, (0.0f), (2.0f), NULL);
		__this->___m_DeadZoneWidth_15 = L_1;
		float L_2;
		L_2 = Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline((&___value0), NULL);
		float L_3;
		L_3 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_2, (0.0f), (2.0f), NULL);
		__this->___m_DeadZoneHeight_16 = L_3;
		float L_4;
		L_4 = Rect_get_x_mB267B718E0D067F2BAE31BA477647FBF964916EB_inline((&___value0), NULL);
		float L_5 = __this->___m_DeadZoneWidth_15;
		float L_6;
		L_6 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)il2cpp_codegen_add(L_4, ((float)(L_5/(2.0f))))), (-0.5f), (1.5f), NULL);
		__this->___m_ScreenX_13 = L_6;
		float L_7;
		L_7 = Rect_get_y_mC733E8D49F3CE21B2A3D40A1B72D687F22C97F49_inline((&___value0), NULL);
		float L_8 = __this->___m_DeadZoneHeight_16;
		float L_9;
		L_9 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)il2cpp_codegen_add(L_7, ((float)(L_8/(2.0f))))), (-0.5f), (1.5f), NULL);
		__this->___m_ScreenY_14 = L_9;
		float L_10 = __this->___m_SoftZoneWidth_17;
		float L_11 = __this->___m_DeadZoneWidth_15;
		float L_12;
		L_12 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_10, L_11, NULL);
		__this->___m_SoftZoneWidth_17 = L_12;
		float L_13 = __this->___m_SoftZoneHeight_18;
		float L_14 = __this->___m_DeadZoneHeight_16;
		float L_15;
		L_15 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_13, L_14, NULL);
		__this->___m_SoftZoneHeight_18 = L_15;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineComposer_get_HardGuideRect_mA2B70FA82432B7D2874E5213E3F9086CC152E69F (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_0;
	memset((&V_0), 0, sizeof(V_0));
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		float L_0 = __this->___m_ScreenX_13;
		float L_1 = __this->___m_SoftZoneWidth_17;
		float L_2 = __this->___m_ScreenY_14;
		float L_3 = __this->___m_SoftZoneHeight_18;
		float L_4 = __this->___m_SoftZoneWidth_17;
		float L_5 = __this->___m_SoftZoneHeight_18;
		Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23_inline((&V_0), ((float)il2cpp_codegen_subtract(L_0, ((float)(L_1/(2.0f))))), ((float)il2cpp_codegen_subtract(L_2, ((float)(L_3/(2.0f))))), L_4, L_5, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_6 = (&V_0);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_7;
		L_7 = Rect_get_position_m9B7E583E67443B6F4280A676E644BB0B9E7C4E38_inline(L_6, NULL);
		float L_8 = __this->___m_BiasX_19;
		float L_9 = __this->___m_SoftZoneWidth_17;
		float L_10 = __this->___m_DeadZoneWidth_15;
		float L_11 = __this->___m_BiasY_20;
		float L_12 = __this->___m_SoftZoneHeight_18;
		float L_13 = __this->___m_DeadZoneHeight_16;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_14), ((float)il2cpp_codegen_multiply(L_8, ((float)il2cpp_codegen_subtract(L_9, L_10)))), ((float)il2cpp_codegen_multiply(L_11, ((float)il2cpp_codegen_subtract(L_12, L_13)))), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_15;
		L_15 = Vector2_op_Addition_m704B5B98EAFE885978381E21B7F89D9DF83C2A60_inline(L_7, L_14, NULL);
		Rect_set_position_m9CD8AA25A83A7A893429C0ED56C36641202C3F05_inline(L_6, L_15, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_16 = V_0;
		V_1 = L_16;
		goto IL_007e;
	}

IL_007e:
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_17 = V_1;
		return L_17;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_set_HardGuideRect_m868567C4C94ED2BE86B092E4F69C548F98B167A5 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___value0, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_1;
	memset((&V_1), 0, sizeof(V_1));
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* G_B2_0 = NULL;
	CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* G_B1_0 = NULL;
	float G_B3_0 = 0.0f;
	CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* G_B3_1 = NULL;
	CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* G_B5_0 = NULL;
	CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* G_B4_0 = NULL;
	float G_B6_0 = 0.0f;
	CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* G_B6_1 = NULL;
	{
		float L_0;
		L_0 = Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline((&___value0), NULL);
		float L_1;
		L_1 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_0, (0.0f), (2.0f), NULL);
		__this->___m_SoftZoneWidth_17 = L_1;
		float L_2;
		L_2 = Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline((&___value0), NULL);
		float L_3;
		L_3 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_2, (0.0f), (2.0f), NULL);
		__this->___m_SoftZoneHeight_18 = L_3;
		float L_4 = __this->___m_DeadZoneWidth_15;
		float L_5 = __this->___m_SoftZoneWidth_17;
		float L_6;
		L_6 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_4, L_5, NULL);
		__this->___m_DeadZoneWidth_15 = L_6;
		float L_7 = __this->___m_DeadZoneHeight_16;
		float L_8 = __this->___m_SoftZoneHeight_18;
		float L_9;
		L_9 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_7, L_8, NULL);
		__this->___m_DeadZoneHeight_16 = L_9;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10;
		L_10 = Rect_get_center_mAA9A2E1F058B2C9F58E13CC4822F789F42975E5C_inline((&___value0), NULL);
		V_0 = L_10;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_11 = V_0;
		float L_12 = __this->___m_ScreenX_13;
		float L_13 = __this->___m_ScreenY_14;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_14), L_12, L_13, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_15;
		L_15 = Vector2_op_Subtraction_m664419831773D5BBF06D9DE4E515F6409B2F92B8_inline(L_11, L_14, NULL);
		V_1 = L_15;
		float L_16 = __this->___m_SoftZoneWidth_17;
		float L_17 = __this->___m_DeadZoneWidth_15;
		float L_18;
		L_18 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), ((float)il2cpp_codegen_subtract(L_16, L_17)), NULL);
		V_2 = L_18;
		float L_19 = __this->___m_SoftZoneHeight_18;
		float L_20 = __this->___m_DeadZoneHeight_16;
		float L_21;
		L_21 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), ((float)il2cpp_codegen_subtract(L_19, L_20)), NULL);
		V_3 = L_21;
		float L_22 = V_2;
		G_B1_0 = __this;
		if ((((float)L_22) < ((float)(9.99999975E-05f))))
		{
			G_B2_0 = __this;
			goto IL_00d9;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_23 = V_1;
		float L_24 = L_23.___x_0;
		float L_25 = V_2;
		float L_26;
		L_26 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)(L_24/L_25)), (-0.5f), (0.5f), NULL);
		G_B3_0 = L_26;
		G_B3_1 = G_B1_0;
		goto IL_00de;
	}

IL_00d9:
	{
		G_B3_0 = (0.0f);
		G_B3_1 = G_B2_0;
	}

IL_00de:
	{
		NullCheck(G_B3_1);
		G_B3_1->___m_BiasX_19 = G_B3_0;
		float L_27 = V_3;
		G_B4_0 = __this;
		if ((((float)L_27) < ((float)(9.99999975E-05f))))
		{
			G_B5_0 = __this;
			goto IL_0105;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_28 = V_1;
		float L_29 = L_28.___y_1;
		float L_30 = V_3;
		float L_31;
		L_31 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)(L_29/L_30)), (-0.5f), (0.5f), NULL);
		G_B6_0 = L_31;
		G_B6_1 = G_B4_0;
		goto IL_010a;
	}

IL_0105:
	{
		G_B6_0 = (0.0f);
		G_B6_1 = G_B5_0;
	}

IL_010a:
	{
		NullCheck(G_B6_1);
		G_B6_1->___m_BiasY_20 = G_B6_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer_RotateToScreenBounds_m01D1A38D82DF6AE50EFF13027781D15DED32D7EF (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___state0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___screenRect1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___trackedPoint2, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___rigOrientation3, float ___fov4, float ___fovH5, float ___deltaTime6, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_1;
	memset((&V_1), 0, sizeof(V_1));
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	bool V_8 = false;
	int32_t G_B13_0 = 0;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___trackedPoint2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_1 = ___state0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089(L_1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_0, L_2, NULL);
		V_0 = L_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_4 = ___rigOrientation3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_5 = (*(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)L_4);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = V_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_7 = ___state0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = L_7->___ReferenceUp_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_9;
		L_9 = UnityQuaternionExtensions_GetCameraRotationToTarget_mDA1EF1466263B671B863D70DABBD50DF9785C2B7(L_5, L_6, L_8, NULL);
		V_1 = L_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_11 = ___state0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = L_11->___ReferenceUp_1;
		float L_13 = ___fov4;
		bool L_14;
		L_14 = CinemachineComposer_ClampVerticalBounds_m65C191E116F577A8F7F1383C99875779254B934C(__this, (&___screenRect1), L_10, L_12, L_13, NULL);
		float L_15;
		L_15 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline((&___screenRect1), NULL);
		float L_16 = ___fov4;
		V_2 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_15, (0.5f))), L_16));
		float L_17;
		L_17 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline((&___screenRect1), NULL);
		float L_18 = ___fov4;
		V_3 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_17, (0.5f))), L_18));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_19 = V_1;
		float L_20 = L_19.___x_0;
		float L_21 = V_2;
		V_4 = (bool)((((float)L_20) < ((float)L_21))? 1 : 0);
		bool L_22 = V_4;
		if (!L_22)
		{
			goto IL_0073;
		}
	}
	{
		float* L_23 = (&(&V_1)->___x_0);
		float* L_24 = L_23;
		float L_25 = *((float*)L_24);
		float L_26 = V_2;
		*((float*)L_24) = (float)((float)il2cpp_codegen_subtract(L_25, L_26));
		goto IL_009c;
	}

IL_0073:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_27 = V_1;
		float L_28 = L_27.___x_0;
		float L_29 = V_3;
		V_5 = (bool)((((float)L_28) > ((float)L_29))? 1 : 0);
		bool L_30 = V_5;
		if (!L_30)
		{
			goto IL_0090;
		}
	}
	{
		float* L_31 = (&(&V_1)->___x_0);
		float* L_32 = L_31;
		float L_33 = *((float*)L_32);
		float L_34 = V_3;
		*((float*)L_32) = (float)((float)il2cpp_codegen_subtract(L_33, L_34));
		goto IL_009c;
	}

IL_0090:
	{
		(&V_1)->___x_0 = (0.0f);
	}

IL_009c:
	{
		float L_35;
		L_35 = Rect_get_xMin_mE89C40702926D016A633399E20DB9501E251630D_inline((&___screenRect1), NULL);
		float L_36 = ___fovH5;
		V_2 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_35, (0.5f))), L_36));
		float L_37;
		L_37 = Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline((&___screenRect1), NULL);
		float L_38 = ___fovH5;
		V_3 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_37, (0.5f))), L_38));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_39 = V_1;
		float L_40 = L_39.___y_1;
		float L_41 = V_2;
		V_6 = (bool)((((float)L_40) < ((float)L_41))? 1 : 0);
		bool L_42 = V_6;
		if (!L_42)
		{
			goto IL_00db;
		}
	}
	{
		float* L_43 = (&(&V_1)->___y_1);
		float* L_44 = L_43;
		float L_45 = *((float*)L_44);
		float L_46 = V_2;
		*((float*)L_44) = (float)((float)il2cpp_codegen_subtract(L_45, L_46));
		goto IL_0104;
	}

IL_00db:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_47 = V_1;
		float L_48 = L_47.___y_1;
		float L_49 = V_3;
		V_7 = (bool)((((float)L_48) > ((float)L_49))? 1 : 0);
		bool L_50 = V_7;
		if (!L_50)
		{
			goto IL_00f8;
		}
	}
	{
		float* L_51 = (&(&V_1)->___y_1);
		float* L_52 = L_51;
		float L_53 = *((float*)L_52);
		float L_54 = V_3;
		*((float*)L_52) = (float)((float)il2cpp_codegen_subtract(L_53, L_54));
		goto IL_0104;
	}

IL_00f8:
	{
		(&V_1)->___y_1 = (0.0f);
	}

IL_0104:
	{
		float L_55 = ___deltaTime6;
		if ((!(((float)L_55) >= ((float)(0.0f)))))
		{
			goto IL_011a;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_56;
		L_56 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_56);
		bool L_57;
		L_57 = VirtualFuncInvoker0< bool >::Invoke(31, L_56);
		G_B13_0 = ((int32_t)(L_57));
		goto IL_011b;
	}

IL_011a:
	{
		G_B13_0 = 0;
	}

IL_011b:
	{
		V_8 = (bool)G_B13_0;
		bool L_58 = V_8;
		if (!L_58)
		{
			goto IL_0163;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_59;
		L_59 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_60 = V_1;
		float L_61 = L_60.___x_0;
		float L_62 = __this->___m_VerticalDamping_12;
		float L_63 = ___deltaTime6;
		NullCheck(L_59);
		float L_64;
		L_64 = CinemachineVirtualCameraBase_DetachedLookAtTargetDamp_mFB6FAA90EB2A5263D19E3D91C30C072C972E849E(L_59, L_61, L_62, L_63, NULL);
		(&V_1)->___x_0 = L_64;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_65;
		L_65 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_66 = V_1;
		float L_67 = L_66.___y_1;
		float L_68 = __this->___m_HorizontalDamping_11;
		float L_69 = ___deltaTime6;
		NullCheck(L_65);
		float L_70;
		L_70 = CinemachineVirtualCameraBase_DetachedLookAtTargetDamp_mFB6FAA90EB2A5263D19E3D91C30C072C972E849E(L_65, L_67, L_68, L_69, NULL);
		(&V_1)->___y_1 = L_70;
	}

IL_0163:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_71 = ___rigOrientation3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_72 = ___rigOrientation3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_73 = (*(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)L_72);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_74 = V_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_75 = ___state0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_76 = L_75->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_77;
		L_77 = UnityQuaternionExtensions_ApplyCameraRotation_m75753B356C2E3BC79192192C8C2FC1F512643506(L_73, L_74, L_76, NULL);
		*(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)L_71 = L_77;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineComposer_ClampVerticalBounds_m65C191E116F577A8F7F1383C99875779254B934C (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* ___r0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___dir1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, float ___fov3, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	bool V_2 = false;
	float V_3 = 0.0f;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	float V_7 = 0.0f;
	bool V_8 = false;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___dir1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___up2;
		float L_2;
		L_2 = UnityVectorExtensions_Angle_m531A3EF1C1C1F49B637BB83F3795128D571A2B93(L_0, L_1, NULL);
		V_0 = L_2;
		float L_3 = ___fov3;
		V_1 = ((float)il2cpp_codegen_add(((float)(L_3/(2.0f))), (1.0f)));
		float L_4 = V_0;
		float L_5 = V_1;
		V_2 = (bool)((((float)L_4) < ((float)L_5))? 1 : 0);
		bool L_6 = V_2;
		if (!L_6)
		{
			goto IL_006a;
		}
	}
	{
		float L_7 = V_1;
		float L_8 = V_0;
		float L_9 = ___fov3;
		V_3 = ((float)il2cpp_codegen_subtract((1.0f), ((float)(((float)il2cpp_codegen_subtract(L_7, L_8))/L_9))));
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_10 = ___r0;
		float L_11;
		L_11 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline(L_10, NULL);
		float L_12 = V_3;
		V_4 = (bool)((((float)L_11) > ((float)L_12))? 1 : 0);
		bool L_13 = V_4;
		if (!L_13)
		{
			goto IL_0069;
		}
	}
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_14 = ___r0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_15 = ___r0;
		float L_16;
		L_16 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline(L_15, NULL);
		float L_17 = V_3;
		float L_18;
		L_18 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_16, L_17, NULL);
		Rect_set_yMin_m9F780E509B9215A9E5826178CF664BD0E486D4EE_inline(L_14, L_18, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_19 = ___r0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_20 = ___r0;
		float L_21;
		L_21 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline(L_20, NULL);
		float L_22 = V_3;
		float L_23;
		L_23 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_21, L_22, NULL);
		Rect_set_yMax_mCF452040E0068A4B3CB15994C0B4B6AD4D78E04B_inline(L_19, L_23, NULL);
		V_5 = (bool)1;
		goto IL_00cd;
	}

IL_0069:
	{
	}

IL_006a:
	{
		float L_24 = V_0;
		float L_25 = V_1;
		V_6 = (bool)((((float)L_24) > ((float)((float)il2cpp_codegen_subtract((180.0f), L_25))))? 1 : 0);
		bool L_26 = V_6;
		if (!L_26)
		{
			goto IL_00c8;
		}
	}
	{
		float L_27 = V_0;
		float L_28 = V_1;
		float L_29 = ___fov3;
		V_7 = ((float)(((float)il2cpp_codegen_subtract(L_27, ((float)il2cpp_codegen_subtract((180.0f), L_28))))/L_29));
		float L_30 = V_7;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_31 = ___r0;
		float L_32;
		L_32 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline(L_31, NULL);
		V_8 = (bool)((((float)L_30) > ((float)L_32))? 1 : 0);
		bool L_33 = V_8;
		if (!L_33)
		{
			goto IL_00c7;
		}
	}
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_34 = ___r0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_35 = ___r0;
		float L_36;
		L_36 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline(L_35, NULL);
		float L_37 = V_7;
		float L_38;
		L_38 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_36, L_37, NULL);
		Rect_set_yMin_m9F780E509B9215A9E5826178CF664BD0E486D4EE_inline(L_34, L_38, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_39 = ___r0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_40 = ___r0;
		float L_41;
		L_41 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline(L_40, NULL);
		float L_42 = V_7;
		float L_43;
		L_43 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_41, L_42, NULL);
		Rect_set_yMax_mCF452040E0068A4B3CB15994C0B4B6AD4D78E04B_inline(L_39, L_43, NULL);
		V_5 = (bool)1;
		goto IL_00cd;
	}

IL_00c7:
	{
	}

IL_00c8:
	{
		V_5 = (bool)0;
		goto IL_00cd;
	}

IL_00cd:
	{
		bool L_44 = V_5;
		return L_44;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineComposer__ctor_m90D1EE7F962886981F03D129849E4214A106DCD8 (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_TrackedObjectOffset_7 = L_0;
		__this->___m_LookaheadTime_8 = (0.0f);
		__this->___m_LookaheadSmoothing_9 = (0.0f);
		__this->___m_HorizontalDamping_11 = (0.5f);
		__this->___m_VerticalDamping_12 = (0.5f);
		__this->___m_ScreenX_13 = (0.5f);
		__this->___m_ScreenY_14 = (0.5f);
		__this->___m_DeadZoneWidth_15 = (0.0f);
		__this->___m_DeadZoneHeight_16 = (0.0f);
		__this->___m_SoftZoneWidth_17 = (0.800000012f);
		__this->___m_SoftZoneHeight_18 = (0.800000012f);
		__this->___m_BiasX_19 = (0.0f);
		__this->___m_BiasY_20 = (0.0f);
		__this->___m_CenterOnActivate_21 = (bool)1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_CameraPosPrevFrame_23 = L_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_LookAtPrevFrame_24 = L_2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_3;
		L_3 = Vector2_get_zero_m009B92B5D35AB02BD1610C2E1ACCE7C9CF964A6E_inline(NULL);
		__this->___m_ScreenOffsetPrevFrame_25 = L_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4;
		L_4 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		__this->___m_CameraOrientationPrevFrame_26 = L_4;
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_5 = (PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E*)il2cpp_codegen_object_new(PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		PositionPredictor__ctor_m98DC334F817608D8CA4FA09966193AA59A16DB25(L_5, NULL);
		__this->___m_Predictor_27 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_Predictor_27), (void*)L_5);
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FovCache_UpdateCache_m3462592E7672B43BEB32686E0F62B7C17F0E2999 (FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* __this, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___lens0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___softGuide1, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___hardGuide2, float ___targetDistance3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	float V_2 = 0.0f;
	bool V_3 = false;
	bool V_4 = false;
	float V_5 = 0.0f;
	bool V_6 = false;
	bool V_7 = false;
	double V_8 = 0.0;
	bool V_9 = false;
	int32_t G_B4_0 = 0;
	int32_t G_B8_0 = 0;
	{
		float L_0 = __this->___mAspect_5;
		float L_1;
		L_1 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&___lens0), NULL);
		if ((!(((float)L_0) == ((float)L_1))))
		{
			goto IL_002c;
		}
	}
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_2 = ___softGuide1;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_3 = __this->___mSoftGuideRect_6;
		bool L_4;
		L_4 = Rect_op_Inequality_m4698BE8DFFC2C4F79B03116FC33FE1BE823A8945_inline(L_2, L_3, NULL);
		if (L_4)
		{
			goto IL_002c;
		}
	}
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_5 = ___hardGuide2;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_6 = __this->___mHardGuideRect_7;
		bool L_7;
		L_7 = Rect_op_Inequality_m4698BE8DFFC2C4F79B03116FC33FE1BE823A8945_inline(L_5, L_6, NULL);
		G_B4_0 = ((int32_t)(L_7));
		goto IL_002d;
	}

IL_002c:
	{
		G_B4_0 = 1;
	}

IL_002d:
	{
		V_0 = (bool)G_B4_0;
		bool L_8;
		L_8 = LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D((&___lens0), NULL);
		V_1 = L_8;
		bool L_9 = V_1;
		if (!L_9)
		{
			goto IL_00c6;
		}
	}
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_10 = ___lens0;
		float L_11 = L_10.___OrthographicSize_2;
		float L_12 = ___targetDistance3;
		float L_13;
		L_13 = fabsf(((float)(L_11/L_12)));
		V_2 = L_13;
		float L_14 = __this->___mOrthoSizeOverDistance_4;
		if ((((float)L_14) == ((float)(0.0f))))
		{
			goto IL_007d;
		}
	}
	{
		float L_15 = V_2;
		float L_16 = __this->___mOrthoSizeOverDistance_4;
		float L_17;
		L_17 = fabsf(((float)il2cpp_codegen_subtract(L_15, L_16)));
		float L_18 = __this->___mOrthoSizeOverDistance_4;
		float L_19 = __this->___mOrthoSizeOverDistance_4;
		G_B8_0 = ((((float)((float)(L_17/L_18))) > ((float)((float)il2cpp_codegen_multiply(L_19, (0.00999999978f)))))? 1 : 0);
		goto IL_007e;
	}

IL_007d:
	{
		G_B8_0 = 1;
	}

IL_007e:
	{
		V_3 = (bool)G_B8_0;
		bool L_20 = V_3;
		if (!L_20)
		{
			goto IL_0084;
		}
	}
	{
		V_0 = (bool)1;
	}

IL_0084:
	{
		bool L_21 = V_0;
		V_4 = L_21;
		bool L_22 = V_4;
		if (!L_22)
		{
			goto IL_00c0;
		}
	}
	{
		float L_23 = V_2;
		float L_24;
		L_24 = atanf(L_23);
		__this->___mFov_3 = ((float)il2cpp_codegen_multiply((114.59156f), L_24));
		float L_25;
		L_25 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&___lens0), NULL);
		float L_26 = V_2;
		float L_27;
		L_27 = atanf(((float)il2cpp_codegen_multiply(L_25, L_26)));
		__this->___mFovH_2 = ((float)il2cpp_codegen_multiply((114.59156f), L_27));
		float L_28 = V_2;
		__this->___mOrthoSizeOverDistance_4 = L_28;
	}

IL_00c0:
	{
		goto IL_0146;
	}

IL_00c6:
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_29 = ___lens0;
		float L_30 = L_29.___FieldOfView_1;
		V_5 = L_30;
		float L_31 = __this->___mFov_3;
		float L_32 = V_5;
		V_6 = (bool)((((int32_t)((((float)L_31) == ((float)L_32))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_33 = V_6;
		if (!L_33)
		{
			goto IL_00e4;
		}
	}
	{
		V_0 = (bool)1;
	}

IL_00e4:
	{
		bool L_34 = V_0;
		V_7 = L_34;
		bool L_35 = V_7;
		if (!L_35)
		{
			goto IL_0145;
		}
	}
	{
		float L_36 = V_5;
		__this->___mFov_3 = L_36;
		float L_37 = __this->___mFov_3;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_38;
		L_38 = tan(((double)((float)(((float)il2cpp_codegen_multiply(L_37, (0.0174532924f)))/(2.0f)))));
		float L_39;
		L_39 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&___lens0), NULL);
		double L_40;
		L_40 = atan(((double)il2cpp_codegen_multiply(L_38, ((double)L_39))));
		V_8 = ((double)il2cpp_codegen_multiply((2.0), L_40));
		double L_41 = V_8;
		__this->___mFovH_2 = ((float)((double)il2cpp_codegen_multiply((57.295780181884766), L_41)));
		__this->___mOrthoSizeOverDistance_4 = (0.0f);
	}

IL_0145:
	{
	}

IL_0146:
	{
		bool L_42 = V_0;
		V_9 = L_42;
		bool L_43 = V_9;
		if (!L_43)
		{
			goto IL_01aa;
		}
	}
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_44 = ___softGuide1;
		float L_45 = __this->___mFov_3;
		float L_46 = __this->___mFovH_2;
		float L_47;
		L_47 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&___lens0), NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_48;
		L_48 = FovCache_ScreenToFOV_m84AEDE8D18A7CE6A911AB93E622316E126980056(__this, L_44, L_45, L_46, L_47, NULL);
		__this->___mFovSoftGuideRect_0 = L_48;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_49 = ___softGuide1;
		__this->___mSoftGuideRect_6 = L_49;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_50 = ___hardGuide2;
		float L_51 = __this->___mFov_3;
		float L_52 = __this->___mFovH_2;
		float L_53;
		L_53 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&___lens0), NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_54;
		L_54 = FovCache_ScreenToFOV_m84AEDE8D18A7CE6A911AB93E622316E126980056(__this, L_50, L_51, L_52, L_53, NULL);
		__this->___mFovHardGuideRect_1 = L_54;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_55 = ___hardGuide2;
		__this->___mHardGuideRect_7 = L_55;
		float L_56;
		L_56 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&___lens0), NULL);
		__this->___mAspect_5 = L_56;
	}

IL_01aa:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void FovCache_UpdateCache_m3462592E7672B43BEB32686E0F62B7C17F0E2999_AdjustorThunk (RuntimeObject* __this, LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___lens0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___softGuide1, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___hardGuide2, float ___targetDistance3, const RuntimeMethod* method)
{
	FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED*>(__this + _offset);
	FovCache_UpdateCache_m3462592E7672B43BEB32686E0F62B7C17F0E2999(_thisAdjusted, ___lens0, ___softGuide1, ___hardGuide2, ___targetDistance3, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D FovCache_ScreenToFOV_m84AEDE8D18A7CE6A911AB93E622316E126980056 (FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rScreen0, float ___fov1, float ___fovH2, float ___aspect3, const RuntimeMethod* method) 
{
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_0;
	memset((&V_0), 0, sizeof(V_0));
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	float V_3 = 0.0f;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_5;
	memset((&V_5), 0, sizeof(V_5));
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_0 = ___rScreen0;
		Rect__ctor_m5665723DD0443E990EA203A54451B2BB324D8224_inline((&V_0), L_0, NULL);
		float L_1 = ___fov1;
		float L_2 = ___aspect3;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_3;
		L_3 = Matrix4x4_Perspective_mC8EE39379287917634B001BBA926CAFBB4B343BB(L_1, L_2, (9.99999975E-05f), (2.0f), NULL);
		V_4 = L_3;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_4;
		L_4 = Matrix4x4_get_inverse_m4F4A881CD789281EA90EB68CFD39F36C8A81E6BD((&V_4), NULL);
		V_1 = L_4;
		float L_5;
		L_5 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline((&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_6), (0.0f), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_5, (2.0f))), (1.0f))), (0.5f), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Matrix4x4_MultiplyPoint_m20E910B65693559BFDE99382472D8DD02C862E7E((&V_1), L_6, NULL);
		V_2 = L_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = V_2;
		float L_9 = L_8.___z_4;
		(&V_2)->___z_4 = ((-L_9));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10;
		L_10 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Vector3_get_left_mA75C525C1E78B5BB99E9B7A63EF68C731043FE18_inline(NULL);
		float L_13;
		L_13 = UnityVectorExtensions_SignedAngle_mEC66BAD4357C0F5F7ADE082AD38AD1FE70649315(L_10, L_11, L_12, NULL);
		V_3 = L_13;
		float L_14 = ___fov1;
		float L_15 = V_3;
		float L_16 = ___fov1;
		Rect_set_yMin_m9F780E509B9215A9E5826178CF664BD0E486D4EE_inline((&V_0), ((float)(((float)il2cpp_codegen_add(((float)(L_14/(2.0f))), L_15))/L_16)), NULL);
		float L_17;
		L_17 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline((&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_18), (0.0f), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_17, (2.0f))), (1.0f))), (0.5f), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19;
		L_19 = Matrix4x4_MultiplyPoint_m20E910B65693559BFDE99382472D8DD02C862E7E((&V_1), L_18, NULL);
		V_2 = L_19;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = V_2;
		float L_21 = L_20.___z_4;
		(&V_2)->___z_4 = ((-L_21));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22;
		L_22 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Vector3_get_left_mA75C525C1E78B5BB99E9B7A63EF68C731043FE18_inline(NULL);
		float L_25;
		L_25 = UnityVectorExtensions_SignedAngle_mEC66BAD4357C0F5F7ADE082AD38AD1FE70649315(L_22, L_23, L_24, NULL);
		V_3 = L_25;
		float L_26 = ___fov1;
		float L_27 = V_3;
		float L_28 = ___fov1;
		Rect_set_yMax_mCF452040E0068A4B3CB15994C0B4B6AD4D78E04B_inline((&V_0), ((float)(((float)il2cpp_codegen_add(((float)(L_26/(2.0f))), L_27))/L_28)), NULL);
		float L_29;
		L_29 = Rect_get_xMin_mE89C40702926D016A633399E20DB9501E251630D_inline((&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		memset((&L_30), 0, sizeof(L_30));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_30), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_29, (2.0f))), (1.0f))), (0.0f), (0.5f), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31;
		L_31 = Matrix4x4_MultiplyPoint_m20E910B65693559BFDE99382472D8DD02C862E7E((&V_1), L_30, NULL);
		V_2 = L_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32 = V_2;
		float L_33 = L_32.___z_4;
		(&V_2)->___z_4 = ((-L_33));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34;
		L_34 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36;
		L_36 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		float L_37;
		L_37 = UnityVectorExtensions_SignedAngle_mEC66BAD4357C0F5F7ADE082AD38AD1FE70649315(L_34, L_35, L_36, NULL);
		V_3 = L_37;
		float L_38 = ___fovH2;
		float L_39 = V_3;
		float L_40 = ___fovH2;
		Rect_set_xMin_mA873FCFAF9EABA46A026B73CA045192DF1946F19_inline((&V_0), ((float)(((float)il2cpp_codegen_add(((float)(L_38/(2.0f))), L_39))/L_40)), NULL);
		float L_41;
		L_41 = Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline((&V_0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42;
		memset((&L_42), 0, sizeof(L_42));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_42), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_41, (2.0f))), (1.0f))), (0.0f), (0.5f), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43;
		L_43 = Matrix4x4_MultiplyPoint_m20E910B65693559BFDE99382472D8DD02C862E7E((&V_1), L_42, NULL);
		V_2 = L_43;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_44 = V_2;
		float L_45 = L_44.___z_4;
		(&V_2)->___z_4 = ((-L_45));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46;
		L_46 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_48;
		L_48 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		float L_49;
		L_49 = UnityVectorExtensions_SignedAngle_mEC66BAD4357C0F5F7ADE082AD38AD1FE70649315(L_46, L_47, L_48, NULL);
		V_3 = L_49;
		float L_50 = ___fovH2;
		float L_51 = V_3;
		float L_52 = ___fovH2;
		Rect_set_xMax_m97C28D468455A6D19325D0D862E80A093240D49D_inline((&V_0), ((float)(((float)il2cpp_codegen_add(((float)(L_50/(2.0f))), L_51))/L_52)), NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_53 = V_0;
		V_5 = L_53;
		goto IL_019a;
	}

IL_019a:
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_54 = V_5;
		return L_54;
	}
}
IL2CPP_EXTERN_C  Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D FovCache_ScreenToFOV_m84AEDE8D18A7CE6A911AB93E622316E126980056_AdjustorThunk (RuntimeObject* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rScreen0, float ___fov1, float ___fovH2, float ___aspect3, const RuntimeMethod* method)
{
	FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<FovCache_t55CA42AF1CF778524FCF1EBD252936E74F41DBED*>(__this + _offset);
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D _returnValue;
	_returnValue = FovCache_ScreenToFOV_m84AEDE8D18A7CE6A911AB93E622316E126980056(_thisAdjusted, ___rScreen0, ___fov1, ___fovH2, ___aspect3, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineFramingTransposer_get_SoftGuideRect_mCDC60214B6A81FBD8AAF9F6DECAEC86A562C504A (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = __this->___m_ScreenX_15;
		float L_1 = __this->___m_DeadZoneWidth_18;
		float L_2 = __this->___m_ScreenY_16;
		float L_3 = __this->___m_DeadZoneHeight_19;
		float L_4 = __this->___m_DeadZoneWidth_18;
		float L_5 = __this->___m_DeadZoneHeight_19;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_6;
		memset((&L_6), 0, sizeof(L_6));
		Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23_inline((&L_6), ((float)il2cpp_codegen_subtract(L_0, ((float)(L_1/(2.0f))))), ((float)il2cpp_codegen_subtract(L_2, ((float)(L_3/(2.0f))))), L_4, L_5, NULL);
		V_0 = L_6;
		goto IL_003b;
	}

IL_003b:
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_7 = V_0;
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_SoftGuideRect_mEEE1DEC1C703C7C8D54A3C8388EB659E32B30F23 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___value0, const RuntimeMethod* method) 
{
	{
		float L_0;
		L_0 = Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline((&___value0), NULL);
		float L_1;
		L_1 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_0, (0.0f), (2.0f), NULL);
		__this->___m_DeadZoneWidth_18 = L_1;
		float L_2;
		L_2 = Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline((&___value0), NULL);
		float L_3;
		L_3 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_2, (0.0f), (2.0f), NULL);
		__this->___m_DeadZoneHeight_19 = L_3;
		float L_4;
		L_4 = Rect_get_x_mB267B718E0D067F2BAE31BA477647FBF964916EB_inline((&___value0), NULL);
		float L_5 = __this->___m_DeadZoneWidth_18;
		float L_6;
		L_6 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)il2cpp_codegen_add(L_4, ((float)(L_5/(2.0f))))), (-0.5f), (1.5f), NULL);
		__this->___m_ScreenX_15 = L_6;
		float L_7;
		L_7 = Rect_get_y_mC733E8D49F3CE21B2A3D40A1B72D687F22C97F49_inline((&___value0), NULL);
		float L_8 = __this->___m_DeadZoneHeight_19;
		float L_9;
		L_9 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)il2cpp_codegen_add(L_7, ((float)(L_8/(2.0f))))), (-0.5f), (1.5f), NULL);
		__this->___m_ScreenY_16 = L_9;
		float L_10 = __this->___m_SoftZoneWidth_22;
		float L_11 = __this->___m_DeadZoneWidth_18;
		float L_12;
		L_12 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_10, L_11, NULL);
		__this->___m_SoftZoneWidth_22 = L_12;
		float L_13 = __this->___m_SoftZoneHeight_23;
		float L_14 = __this->___m_DeadZoneHeight_19;
		float L_15;
		L_15 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_13, L_14, NULL);
		__this->___m_SoftZoneHeight_23 = L_15;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineFramingTransposer_get_HardGuideRect_m83469B076C3529941A2FD36E35FFE410EA3D7BA5 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_0;
	memset((&V_0), 0, sizeof(V_0));
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		float L_0 = __this->___m_ScreenX_15;
		float L_1 = __this->___m_SoftZoneWidth_22;
		float L_2 = __this->___m_ScreenY_16;
		float L_3 = __this->___m_SoftZoneHeight_23;
		float L_4 = __this->___m_SoftZoneWidth_22;
		float L_5 = __this->___m_SoftZoneHeight_23;
		Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23_inline((&V_0), ((float)il2cpp_codegen_subtract(L_0, ((float)(L_1/(2.0f))))), ((float)il2cpp_codegen_subtract(L_2, ((float)(L_3/(2.0f))))), L_4, L_5, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* L_6 = (&V_0);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_7;
		L_7 = Rect_get_position_m9B7E583E67443B6F4280A676E644BB0B9E7C4E38_inline(L_6, NULL);
		float L_8 = __this->___m_BiasX_24;
		float L_9 = __this->___m_SoftZoneWidth_22;
		float L_10 = __this->___m_DeadZoneWidth_18;
		float L_11 = __this->___m_BiasY_25;
		float L_12 = __this->___m_SoftZoneHeight_23;
		float L_13 = __this->___m_DeadZoneHeight_19;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_14), ((float)il2cpp_codegen_multiply(L_8, ((float)il2cpp_codegen_subtract(L_9, L_10)))), ((float)il2cpp_codegen_multiply(L_11, ((float)il2cpp_codegen_subtract(L_12, L_13)))), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_15;
		L_15 = Vector2_op_Addition_m704B5B98EAFE885978381E21B7F89D9DF83C2A60_inline(L_7, L_14, NULL);
		Rect_set_position_m9CD8AA25A83A7A893429C0ED56C36641202C3F05_inline(L_6, L_15, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_16 = V_0;
		V_1 = L_16;
		goto IL_007e;
	}

IL_007e:
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_17 = V_1;
		return L_17;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_HardGuideRect_m215B19AF350146BA8E7C394D75EAD67C46BEF10E (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___value0, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_1;
	memset((&V_1), 0, sizeof(V_1));
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B2_0 = NULL;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B1_0 = NULL;
	float G_B3_0 = 0.0f;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B3_1 = NULL;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B5_0 = NULL;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B4_0 = NULL;
	float G_B6_0 = 0.0f;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B6_1 = NULL;
	{
		float L_0;
		L_0 = Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline((&___value0), NULL);
		float L_1;
		L_1 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_0, (0.0f), (2.0f), NULL);
		__this->___m_SoftZoneWidth_22 = L_1;
		float L_2;
		L_2 = Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline((&___value0), NULL);
		float L_3;
		L_3 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_2, (0.0f), (2.0f), NULL);
		__this->___m_SoftZoneHeight_23 = L_3;
		float L_4 = __this->___m_DeadZoneWidth_18;
		float L_5 = __this->___m_SoftZoneWidth_22;
		float L_6;
		L_6 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_4, L_5, NULL);
		__this->___m_DeadZoneWidth_18 = L_6;
		float L_7 = __this->___m_DeadZoneHeight_19;
		float L_8 = __this->___m_SoftZoneHeight_23;
		float L_9;
		L_9 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_7, L_8, NULL);
		__this->___m_DeadZoneHeight_19 = L_9;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10;
		L_10 = Rect_get_center_mAA9A2E1F058B2C9F58E13CC4822F789F42975E5C_inline((&___value0), NULL);
		V_0 = L_10;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_11 = V_0;
		float L_12 = __this->___m_ScreenX_15;
		float L_13 = __this->___m_ScreenY_16;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_14), L_12, L_13, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_15;
		L_15 = Vector2_op_Subtraction_m664419831773D5BBF06D9DE4E515F6409B2F92B8_inline(L_11, L_14, NULL);
		V_1 = L_15;
		float L_16 = __this->___m_SoftZoneWidth_22;
		float L_17 = __this->___m_DeadZoneWidth_18;
		float L_18;
		L_18 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), ((float)il2cpp_codegen_subtract(L_16, L_17)), NULL);
		V_2 = L_18;
		float L_19 = __this->___m_SoftZoneHeight_23;
		float L_20 = __this->___m_DeadZoneHeight_19;
		float L_21;
		L_21 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), ((float)il2cpp_codegen_subtract(L_19, L_20)), NULL);
		V_3 = L_21;
		float L_22 = V_2;
		G_B1_0 = __this;
		if ((((float)L_22) < ((float)(9.99999975E-05f))))
		{
			G_B2_0 = __this;
			goto IL_00d9;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_23 = V_1;
		float L_24 = L_23.___x_0;
		float L_25 = V_2;
		float L_26;
		L_26 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)(L_24/L_25)), (-0.5f), (0.5f), NULL);
		G_B3_0 = L_26;
		G_B3_1 = G_B1_0;
		goto IL_00de;
	}

IL_00d9:
	{
		G_B3_0 = (0.0f);
		G_B3_1 = G_B2_0;
	}

IL_00de:
	{
		NullCheck(G_B3_1);
		G_B3_1->___m_BiasX_24 = G_B3_0;
		float L_27 = V_3;
		G_B4_0 = __this;
		if ((((float)L_27) < ((float)(9.99999975E-05f))))
		{
			G_B5_0 = __this;
			goto IL_0105;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_28 = V_1;
		float L_29 = L_28.___y_1;
		float L_30 = V_3;
		float L_31;
		L_31 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)(L_29/L_30)), (-0.5f), (0.5f), NULL);
		G_B6_0 = L_31;
		G_B6_1 = G_B4_0;
		goto IL_010a;
	}

IL_0105:
	{
		G_B6_0 = (0.0f);
		G_B6_1 = G_B5_0;
	}

IL_010a:
	{
		NullCheck(G_B6_1);
		G_B6_1->___m_BiasY_25 = G_B6_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_OnValidate_m28F166F10297E84E587FC092E2E5DAB42A821AF8 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___m_CameraDistance_17;
		float L_1;
		L_1 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_0, (0.00999999978f), NULL);
		__this->___m_CameraDistance_17 = L_1;
		float L_2 = __this->___m_DeadZoneDepth_20;
		float L_3;
		L_3 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_2, (0.0f), NULL);
		__this->___m_DeadZoneDepth_20 = L_3;
		float L_4 = __this->___m_GroupFramingSize_29;
		float L_5;
		L_5 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.00100000005f), L_4, NULL);
		__this->___m_GroupFramingSize_29 = L_5;
		float L_6 = __this->___m_MaxDollyIn_30;
		float L_7;
		L_7 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_6, NULL);
		__this->___m_MaxDollyIn_30 = L_7;
		float L_8 = __this->___m_MaxDollyOut_31;
		float L_9;
		L_9 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_8, NULL);
		__this->___m_MaxDollyOut_31 = L_9;
		float L_10 = __this->___m_MinimumDistance_32;
		float L_11;
		L_11 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_10, NULL);
		__this->___m_MinimumDistance_32 = L_11;
		float L_12 = __this->___m_MinimumDistance_32;
		float L_13 = __this->___m_MaximumDistance_33;
		float L_14;
		L_14 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_12, L_13, NULL);
		__this->___m_MaximumDistance_33 = L_14;
		float L_15 = __this->___m_MinimumFOV_34;
		float L_16;
		L_16 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((1.0f), L_15, NULL);
		__this->___m_MinimumFOV_34 = L_16;
		float L_17 = __this->___m_MaximumFOV_35;
		float L_18 = __this->___m_MinimumFOV_34;
		float L_19;
		L_19 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_17, L_18, (179.0f), NULL);
		__this->___m_MaximumFOV_35 = L_19;
		float L_20 = __this->___m_MinimumOrthoSize_36;
		float L_21;
		L_21 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.00999999978f), L_20, NULL);
		__this->___m_MinimumOrthoSize_36 = L_21;
		float L_22 = __this->___m_MinimumOrthoSize_36;
		float L_23 = __this->___m_MaximumOrthoSize_37;
		float L_24;
		L_24 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_22, L_23, NULL);
		__this->___m_MaximumOrthoSize_37 = L_24;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineFramingTransposer_get_IsValid_mDE0B8E801C5BDDA9643075A935B8FF10151C11CE (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineFramingTransposer_get_Stage_m406D870FC51C1E3D0F463CD3F8124D4C13A78302 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineFramingTransposer_get_BodyAppliesAfterAim_m29E5668CF169FFABBB9CEEB03E9D733EAE1C693B (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		V_0 = (bool)1;
		goto IL_0005;
	}

IL_0005:
	{
		bool L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineFramingTransposer_get_TrackedPoint_m893C86296D7D0C01FCD28D85D14B38124F9AFB52 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___U3CTrackedPointU3Ek__BackingField_42;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_TrackedPoint_m32FD1D5F85F4BDBFC3BF6DBF5CBC7A8D1DB44FDD (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___value0;
		__this->___U3CTrackedPointU3Ek__BackingField_42 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_OnTargetObjectWarped_mAD4EE7D5CD54543EF73BF8D8DCD1781A57A6CCB4 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_0 = ___target0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___positionDelta1;
		CinemachineComponentBase_OnTargetObjectWarped_m3E083DBF03C47860948F0BB3A013B241AFDAF9A0(__this, L_0, L_1, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2 = ___target0;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3;
		L_3 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_2, L_3, NULL);
		V_0 = L_4;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_003b;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = __this->___m_PreviousCameraPosition_40;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___positionDelta1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_6, L_7, NULL);
		__this->___m_PreviousCameraPosition_40 = L_8;
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_9 = __this->___m_Predictor_41;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___positionDelta1;
		NullCheck(L_9);
		PositionPredictor_ApplyTransformDelta_mDA012CCA329F143DDF342616369F0E75B2E2C97A(L_9, L_10, NULL);
	}

IL_003b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_ForceCameraPosition_m7D0A6F764D394716B8F6700367A8F6DA53076546 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rot1, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___pos0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = ___rot1;
		CinemachineComponentBase_ForceCameraPosition_m3D22002EC0B4F5C1AF7CC283C00BA43D22120878(__this, L_0, L_1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___pos0;
		__this->___m_PreviousCameraPosition_40 = L_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3 = ___rot1;
		__this->___m_prevRotation_45 = L_3;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineFramingTransposer_GetMaxDampTime_m581B0A2F6493CCF2C3F1B0E68E8F0180EEB51B85 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_XDamping_11;
		float L_1 = __this->___m_YDamping_12;
		float L_2 = __this->___m_ZDamping_13;
		float L_3;
		L_3 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_1, L_2, NULL);
		float L_4;
		L_4 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_0, L_3, NULL);
		V_0 = L_4;
		goto IL_0020;
	}

IL_0020:
	{
		float L_5 = V_0;
		return L_5;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineFramingTransposer_OnTransitionFromCamera_m88B1E40E14D5612AE78AEFF401BC71442DF761AE (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, RuntimeObject* ___fromCam0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp1, float ___deltaTime2, TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA* ___transitionParams3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	int32_t G_B4_0 = 0;
	{
		RuntimeObject* L_0 = ___fromCam0;
		if (!L_0)
		{
			goto IL_0022;
		}
	}
	{
		TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA* L_1 = ___transitionParams3;
		bool L_2 = L_1->___m_InheritPosition_1;
		if (!L_2)
		{
			goto IL_0022;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* L_3;
		L_3 = CinemachineCore_get_Instance_m761793890717527703D6C8BB3AC64FEC93745A85(NULL);
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_4;
		L_4 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_3);
		bool L_5;
		L_5 = CinemachineCore_IsLiveInBlend_mFD1402FFF3B5D0CD0EC90914F89672724F49F778(L_3, L_4, NULL);
		G_B4_0 = ((((int32_t)L_5) == ((int32_t)0))? 1 : 0);
		goto IL_0023;
	}

IL_0022:
	{
		G_B4_0 = 0;
	}

IL_0023:
	{
		V_0 = (bool)G_B4_0;
		bool L_6 = V_0;
		if (!L_6)
		{
			goto IL_0055;
		}
	}
	{
		RuntimeObject* L_7 = ___fromCam0;
		NullCheck(L_7);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_8;
		L_8 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_7);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = L_8.___RawPosition_4;
		__this->___m_PreviousCameraPosition_40 = L_9;
		RuntimeObject* L_10 = ___fromCam0;
		NullCheck(L_10);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_11;
		L_11 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_10);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12 = L_11.___RawOrientation_5;
		__this->___m_prevRotation_45 = L_12;
		__this->___m_InheritingPosition_43 = (bool)1;
		V_1 = (bool)1;
		goto IL_0059;
	}

IL_0055:
	{
		V_1 = (bool)0;
		goto IL_0059;
	}

IL_0059:
	{
		bool L_13 = V_1;
		return L_13;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D CinemachineFramingTransposer_ScreenToOrtho_m07AF0DD2BFAEF10102EFEDBB9D87F31EAFA35D41 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rScreen0, float ___orthoSize1, float ___aspect2, const RuntimeMethod* method) 
{
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_0;
	memset((&V_0), 0, sizeof(V_0));
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D));
		float L_0 = ___orthoSize1;
		float L_1;
		L_1 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline((&___rScreen0), NULL);
		Rect_set_yMax_mCF452040E0068A4B3CB15994C0B4B6AD4D78E04B_inline((&V_0), ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((2.0f), L_0)), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_subtract((1.0f), L_1)), (0.5f))))), NULL);
		float L_2 = ___orthoSize1;
		float L_3;
		L_3 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline((&___rScreen0), NULL);
		Rect_set_yMin_m9F780E509B9215A9E5826178CF664BD0E486D4EE_inline((&V_0), ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((2.0f), L_2)), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_subtract((1.0f), L_3)), (0.5f))))), NULL);
		float L_4 = ___orthoSize1;
		float L_5 = ___aspect2;
		float L_6;
		L_6 = Rect_get_xMin_mE89C40702926D016A633399E20DB9501E251630D_inline((&___rScreen0), NULL);
		Rect_set_xMin_mA873FCFAF9EABA46A026B73CA045192DF1946F19_inline((&V_0), ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((2.0f), L_4)), L_5)), ((float)il2cpp_codegen_subtract(L_6, (0.5f))))), NULL);
		float L_7 = ___orthoSize1;
		float L_8 = ___aspect2;
		float L_9;
		L_9 = Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline((&___rScreen0), NULL);
		Rect_set_xMax_m97C28D468455A6D19325D0D862E80A093240D49D_inline((&V_0), ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((2.0f), L_7)), L_8)), ((float)il2cpp_codegen_subtract(L_9, (0.5f))))), NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_10 = V_0;
		V_1 = L_10;
		goto IL_0091;
	}

IL_0091:
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_11 = V_1;
		return L_11;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineFramingTransposer_OrthoOffsetToScreenBounds_mB27FBC07BF36E7BBACD39AAE05C8D7D3B62A8A4E (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___targetPos2D0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___screenRect1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_0 = L_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___targetPos2D0;
		float L_2 = L_1.___x_2;
		float L_3;
		L_3 = Rect_get_xMin_mE89C40702926D016A633399E20DB9501E251630D_inline((&___screenRect1), NULL);
		V_1 = (bool)((((float)L_2) < ((float)L_3))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0033;
		}
	}
	{
		float* L_5 = (&(&V_0)->___x_2);
		float* L_6 = L_5;
		float L_7 = *((float*)L_6);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___targetPos2D0;
		float L_9 = L_8.___x_2;
		float L_10;
		L_10 = Rect_get_xMin_mE89C40702926D016A633399E20DB9501E251630D_inline((&___screenRect1), NULL);
		*((float*)L_6) = (float)((float)il2cpp_codegen_add(L_7, ((float)il2cpp_codegen_subtract(L_9, L_10))));
	}

IL_0033:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = ___targetPos2D0;
		float L_12 = L_11.___x_2;
		float L_13;
		L_13 = Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline((&___screenRect1), NULL);
		V_2 = (bool)((((float)L_12) > ((float)L_13))? 1 : 0);
		bool L_14 = V_2;
		if (!L_14)
		{
			goto IL_005f;
		}
	}
	{
		float* L_15 = (&(&V_0)->___x_2);
		float* L_16 = L_15;
		float L_17 = *((float*)L_16);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = ___targetPos2D0;
		float L_19 = L_18.___x_2;
		float L_20;
		L_20 = Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline((&___screenRect1), NULL);
		*((float*)L_16) = (float)((float)il2cpp_codegen_add(L_17, ((float)il2cpp_codegen_subtract(L_19, L_20))));
	}

IL_005f:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = ___targetPos2D0;
		float L_22 = L_21.___y_3;
		float L_23;
		L_23 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline((&___screenRect1), NULL);
		V_3 = (bool)((((float)L_22) < ((float)L_23))? 1 : 0);
		bool L_24 = V_3;
		if (!L_24)
		{
			goto IL_008b;
		}
	}
	{
		float* L_25 = (&(&V_0)->___y_3);
		float* L_26 = L_25;
		float L_27 = *((float*)L_26);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = ___targetPos2D0;
		float L_29 = L_28.___y_3;
		float L_30;
		L_30 = Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline((&___screenRect1), NULL);
		*((float*)L_26) = (float)((float)il2cpp_codegen_add(L_27, ((float)il2cpp_codegen_subtract(L_29, L_30))));
	}

IL_008b:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = ___targetPos2D0;
		float L_32 = L_31.___y_3;
		float L_33;
		L_33 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline((&___screenRect1), NULL);
		V_4 = (bool)((((float)L_32) > ((float)L_33))? 1 : 0);
		bool L_34 = V_4;
		if (!L_34)
		{
			goto IL_00b9;
		}
	}
	{
		float* L_35 = (&(&V_0)->___y_3);
		float* L_36 = L_35;
		float L_37 = *((float*)L_36);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38 = ___targetPos2D0;
		float L_39 = L_38.___y_3;
		float L_40;
		L_40 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline((&___screenRect1), NULL);
		*((float*)L_36) = (float)((float)il2cpp_codegen_add(L_37, ((float)il2cpp_codegen_subtract(L_39, L_40))));
	}

IL_00b9:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_41 = V_0;
		V_5 = L_41;
		goto IL_00be;
	}

IL_00be:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42 = V_5;
		return L_42;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineFramingTransposer_get_LastBounds_m6D98D46A49E2196A98E2B7E76C0061AC8310B45B (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_0 = __this->___U3CLastBoundsU3Ek__BackingField_46;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_LastBounds_m42F030170155BAC06C2B040E44F4FCB25251EF93 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___value0, const RuntimeMethod* method) 
{
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_0 = ___value0;
		__this->___U3CLastBoundsU3Ek__BackingField_46 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 CinemachineFramingTransposer_get_LastBoundsMatrix_mB1296133E5C0BDD6B9C0879888C468C559BE95BB (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = __this->___U3CLastBoundsMatrixU3Ek__BackingField_47;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_LastBoundsMatrix_m13FAE68552F3910750A134D22AE4AF6845C0301D (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = ___value0;
		__this->___U3CLastBoundsMatrixU3Ek__BackingField_47 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_MutateCameraState_mCF6C11F8E364980D95EFFEDCE1BDC11FD1877734 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	float V_3 = 0.0f;
	RuntimeObject* V_4 = NULL;
	bool V_5 = false;
	float V_6 = 0.0f;
	bool V_7 = false;
	float V_8 = 0.0f;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_9;
	memset((&V_9), 0, sizeof(V_9));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_10;
	memset((&V_10), 0, sizeof(V_10));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_11;
	memset((&V_11), 0, sizeof(V_11));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_12;
	memset((&V_12), 0, sizeof(V_12));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_13;
	memset((&V_13), 0, sizeof(V_13));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_14;
	memset((&V_14), 0, sizeof(V_14));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_15;
	memset((&V_15), 0, sizeof(V_15));
	float V_16 = 0.0f;
	float V_17 = 0.0f;
	float V_18 = 0.0f;
	float V_19 = 0.0f;
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_20;
	memset((&V_20), 0, sizeof(V_20));
	bool V_21 = false;
	bool V_22 = false;
	bool V_23 = false;
	bool V_24 = false;
	bool V_25 = false;
	bool V_26 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_27;
	memset((&V_27), 0, sizeof(V_27));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_28;
	memset((&V_28), 0, sizeof(V_28));
	bool V_29 = false;
	bool V_30 = false;
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 V_31;
	memset((&V_31), 0, sizeof(V_31));
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_32;
	memset((&V_32), 0, sizeof(V_32));
	bool V_33 = false;
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 V_34;
	memset((&V_34), 0, sizeof(V_34));
	bool V_35 = false;
	float V_36 = 0.0f;
	float V_37 = 0.0f;
	bool V_38 = false;
	bool V_39 = false;
	float V_40 = 0.0f;
	bool V_41 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_42;
	memset((&V_42), 0, sizeof(V_42));
	bool V_43 = false;
	bool V_44 = false;
	bool V_45 = false;
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_46;
	memset((&V_46), 0, sizeof(V_46));
	bool V_47 = false;
	bool V_48 = false;
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D V_49;
	memset((&V_49), 0, sizeof(V_49));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_50;
	memset((&V_50), 0, sizeof(V_50));
	bool V_51 = false;
	bool V_52 = false;
	bool V_53 = false;
	bool V_54 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_55;
	memset((&V_55), 0, sizeof(V_55));
	float V_56 = 0.0f;
	float V_57 = 0.0f;
	bool V_58 = false;
	bool V_59 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B6_0 = 0;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B11_0 = NULL;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B10_0 = NULL;
	float G_B12_0 = 0.0f;
	CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* G_B12_1 = NULL;
	int32_t G_B15_0 = 0;
	int32_t G_B24_0 = 0;
	float G_B37_0 = 0.0f;
	int32_t G_B46_0 = 0;
	float G_B55_0 = 0.0f;
	int32_t G_B59_0 = 0;
	int32_t G_B66_0 = 0;
	int32_t G_B68_0 = 0;
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_0 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_1 = L_0->___Lens_0;
		V_0 = L_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3;
		L_3 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = __this->___m_TrackedObjectOffset_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		L_5 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_3, L_4, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_2, L_5, NULL);
		V_1 = L_6;
		float L_7 = ___deltaTime1;
		if ((!(((float)L_7) >= ((float)(0.0f)))))
		{
			goto IL_003a;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_8;
		L_8 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_8);
		bool L_9;
		L_9 = VirtualFuncInvoker0< bool >::Invoke(31, L_8);
		G_B3_0 = ((int32_t)(L_9));
		goto IL_003b;
	}

IL_003a:
	{
		G_B3_0 = 0;
	}

IL_003b:
	{
		V_2 = (bool)G_B3_0;
		bool L_10 = V_2;
		if (!L_10)
		{
			goto IL_004c;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_11;
		L_11 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_11);
		bool L_12;
		L_12 = CinemachineVirtualCameraBase_get_FollowTargetChanged_m4CB9C2AA28F8B2898B82BBF51348C6670110ADF2_inline(L_11, NULL);
		G_B6_0 = ((int32_t)(L_12));
		goto IL_004d;
	}

IL_004c:
	{
		G_B6_0 = 1;
	}

IL_004d:
	{
		V_21 = (bool)G_B6_0;
		bool L_13 = V_21;
		if (!L_13)
		{
			goto IL_005f;
		}
	}
	{
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_14 = __this->___m_Predictor_41;
		NullCheck(L_14);
		PositionPredictor_Reset_mDA454522FB1823437E5538169D712A2E18F956C5(L_14, NULL);
	}

IL_005f:
	{
		bool L_15 = V_2;
		V_22 = (bool)((((int32_t)L_15) == ((int32_t)0))? 1 : 0);
		bool L_16 = V_22;
		if (!L_16)
		{
			goto IL_00e5;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_17 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = L_17->___RawPosition_4;
		__this->___m_PreviousCameraPosition_40 = L_18;
		bool L_19;
		L_19 = LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D((&V_0), NULL);
		G_B10_0 = __this;
		if (L_19)
		{
			G_B11_0 = __this;
			goto IL_0088;
		}
	}
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_20 = V_0;
		float L_21 = L_20.___FieldOfView_1;
		G_B12_0 = L_21;
		G_B12_1 = G_B10_0;
		goto IL_008e;
	}

IL_0088:
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_22 = V_0;
		float L_23 = L_22.___OrthographicSize_2;
		G_B12_0 = L_23;
		G_B12_1 = G_B11_0;
	}

IL_008e:
	{
		NullCheck(G_B12_1);
		G_B12_1->___m_prevFOV_44 = G_B12_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_24 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_25 = L_24->___RawOrientation_5;
		__this->___m_prevRotation_45 = L_25;
		bool L_26 = __this->___m_InheritingPosition_43;
		if (L_26)
		{
			goto IL_00af;
		}
	}
	{
		bool L_27 = __this->___m_CenterOnActivate_26;
		G_B15_0 = ((int32_t)(L_27));
		goto IL_00b0;
	}

IL_00af:
	{
		G_B15_0 = 0;
	}

IL_00b0:
	{
		V_23 = (bool)G_B15_0;
		bool L_28 = V_23;
		if (!L_28)
		{
			goto IL_00e4;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29;
		L_29 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_30 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_31 = L_30->___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = Vector3_get_back_mBA6E23860A365E6F0F9A2AADC3D19E698687230A_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33;
		L_33 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_31, L_32, NULL);
		float L_34 = __this->___m_CameraDistance_17;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35;
		L_35 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_33, L_34, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36;
		L_36 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_29, L_35, NULL);
		__this->___m_PreviousCameraPosition_40 = L_36;
	}

IL_00e4:
	{
	}

IL_00e5:
	{
		bool L_37;
		L_37 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_24 = (bool)((((int32_t)L_37) == ((int32_t)0))? 1 : 0);
		bool L_38 = V_24;
		if (!L_38)
		{
			goto IL_0101;
		}
	}
	{
		__this->___m_InheritingPosition_43 = (bool)0;
		goto IL_0718;
	}

IL_0101:
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_39 = V_0;
		float L_40 = L_39.___FieldOfView_1;
		V_3 = L_40;
		RuntimeObject* L_41;
		L_41 = CinemachineComponentBase_get_AbstractFollowTargetGroup_m91BD623311234A96B2D146A8AB6574567C8C9714(__this, NULL);
		V_4 = L_41;
		RuntimeObject* L_42 = V_4;
		if (!L_42)
		{
			goto IL_0129;
		}
	}
	{
		int32_t L_43 = __this->___m_GroupFramingMode_27;
		if ((((int32_t)L_43) == ((int32_t)3)))
		{
			goto IL_0129;
		}
	}
	{
		RuntimeObject* L_44 = V_4;
		NullCheck(L_44);
		bool L_45;
		L_45 = InterfaceFuncInvoker0< bool >::Invoke(3, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_44);
		G_B24_0 = ((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		goto IL_012a;
	}

IL_0129:
	{
		G_B24_0 = 0;
	}

IL_012a:
	{
		V_5 = (bool)G_B24_0;
		bool L_46 = V_5;
		V_25 = L_46;
		bool L_47 = V_25;
		if (!L_47)
		{
			goto IL_013e;
		}
	}
	{
		RuntimeObject* L_48 = V_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_49 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50;
		L_50 = CinemachineFramingTransposer_ComputeGroupBounds_mD7044C4EFA049F1BD91607D7EB5FE2F26E7A78D2(__this, L_48, L_49, NULL);
		V_1 = L_50;
	}

IL_013e:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51 = V_1;
		CinemachineFramingTransposer_set_TrackedPoint_m32FD1D5F85F4BDBFC3BF6DBF5CBC7A8D1DB44FDD_inline(__this, L_51, NULL);
		float L_52 = __this->___m_LookaheadTime_8;
		V_26 = (bool)((((float)L_52) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_53 = V_26;
		if (!L_53)
		{
			goto IL_0203;
		}
	}
	{
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_54 = __this->___m_Predictor_41;
		float L_55 = __this->___m_LookaheadSmoothing_9;
		NullCheck(L_54);
		L_54->___Smoothing_4 = L_55;
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_56 = __this->___m_Predictor_41;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_57 = V_1;
		float L_58 = ___deltaTime1;
		float L_59 = __this->___m_LookaheadTime_8;
		NullCheck(L_56);
		PositionPredictor_AddPosition_mB5EFA6BB6598A9D52D1CE6BD50400E56938C433C(L_56, L_57, L_58, L_59, NULL);
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_60 = __this->___m_Predictor_41;
		float L_61 = __this->___m_LookaheadTime_8;
		NullCheck(L_60);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_62;
		L_62 = PositionPredictor_PredictPositionDelta_mC16231F75C5C088B5CC2444D3C2FA12F6DACC4AD(L_60, L_61, NULL);
		V_27 = L_62;
		bool L_63 = __this->___m_LookaheadIgnoreY_10;
		V_29 = L_63;
		bool L_64 = V_29;
		if (!L_64)
		{
			goto IL_01b0;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_65 = V_27;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_66 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_67 = L_66->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_68;
		L_68 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_65, L_67, NULL);
		V_27 = L_68;
	}

IL_01b0:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_69 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_70 = V_27;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_71;
		L_71 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_69, L_70, NULL);
		V_28 = L_71;
		bool L_72 = V_5;
		V_30 = L_72;
		bool L_73 = V_30;
		if (!L_73)
		{
			goto IL_01f9;
		}
	}
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_74;
		L_74 = CinemachineFramingTransposer_get_LastBounds_m6D98D46A49E2196A98E2B7E76C0061AC8310B45B_inline(__this, NULL);
		V_31 = L_74;
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* L_75 = (&V_31);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_76;
		L_76 = Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline(L_75, NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_77;
		L_77 = CinemachineFramingTransposer_get_LastBoundsMatrix_mB1296133E5C0BDD6B9C0879888C468C559BE95BB_inline(__this, NULL);
		V_32 = L_77;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_78 = V_27;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79;
		L_79 = Matrix4x4_MultiplyPoint3x4_mACCBD70AFA82C63DA88555780B7B6B01281AB814((&V_32), L_78, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_80;
		L_80 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_76, L_79, NULL);
		Bounds_set_center_m891869DD5B1BEEE2D17907BBFB7EB79AAE44884B_inline(L_75, L_80, NULL);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_81 = V_31;
		CinemachineFramingTransposer_set_LastBounds_m42F030170155BAC06C2B040E44F4FCB25251EF93_inline(__this, L_81, NULL);
	}

IL_01f9:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_82 = V_28;
		CinemachineFramingTransposer_set_TrackedPoint_m32FD1D5F85F4BDBFC3BF6DBF5CBC7A8D1DB44FDD_inline(__this, L_82, NULL);
	}

IL_0203:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_83 = ___curState0;
		bool L_84;
		L_84 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC(L_83, NULL);
		V_33 = (bool)((((int32_t)L_84) == ((int32_t)0))? 1 : 0);
		bool L_85 = V_33;
		if (!L_85)
		{
			goto IL_0219;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_86 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_87 = V_1;
		L_86->___ReferenceLookAt_2 = L_87;
	}

IL_0219:
	{
		float L_88 = __this->___m_CameraDistance_17;
		V_6 = L_88;
		bool L_89;
		L_89 = LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D((&V_0), NULL);
		V_7 = L_89;
		bool L_90 = V_5;
		if (L_90)
		{
			goto IL_0235;
		}
	}
	{
		G_B37_0 = (0.0f);
		goto IL_025a;
	}

IL_0235:
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_91;
		L_91 = CinemachineFramingTransposer_get_LastBounds_m6D98D46A49E2196A98E2B7E76C0061AC8310B45B_inline(__this, NULL);
		V_34 = L_91;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_92;
		L_92 = Bounds_get_size_m0699A53A55A78B3201D7270D6F338DFA91B6FAD4_inline((&V_34), NULL);
		float L_93 = __this->___m_GroupFramingSize_29;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_94;
		L_94 = Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline(L_92, L_93, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_95;
		L_95 = Vector2_op_Implicit_m8F73B300CB4E6F9B4EB5FB6130363D76CEAA230B_inline(L_94, NULL);
		float L_96;
		L_96 = CinemachineFramingTransposer_GetTargetHeight_m5CD0304B16E7442B6BA592E7915FE7C2F57D4A64(__this, L_95, NULL);
		G_B37_0 = L_96;
	}

IL_025a:
	{
		V_8 = G_B37_0;
		float L_97 = V_8;
		float L_98;
		L_98 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_97, (0.00999999978f), NULL);
		V_8 = L_98;
		bool L_99 = V_7;
		bool L_100 = V_5;
		V_35 = (bool)((int32_t)(((((int32_t)L_99) == ((int32_t)0))? 1 : 0)&(int32_t)L_100));
		bool L_101 = V_35;
		if (!L_101)
		{
			goto IL_033a;
		}
	}
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_102;
		L_102 = CinemachineFramingTransposer_get_LastBounds_m6D98D46A49E2196A98E2B7E76C0061AC8310B45B_inline(__this, NULL);
		V_34 = L_102;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_103;
		L_103 = Bounds_get_extents_mFE6DC407FCE2341BE2C750CB554055D211281D25_inline((&V_34), NULL);
		float L_104 = L_103.___z_4;
		V_36 = L_104;
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_105;
		L_105 = CinemachineFramingTransposer_get_LastBounds_m6D98D46A49E2196A98E2B7E76C0061AC8310B45B_inline(__this, NULL);
		V_34 = L_105;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_106;
		L_106 = Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline((&V_34), NULL);
		float L_107 = L_106.___z_4;
		V_37 = L_107;
		float L_108 = V_37;
		float L_109 = V_36;
		V_38 = (bool)((((float)L_108) > ((float)L_109))? 1 : 0);
		bool L_110 = V_38;
		if (!L_110)
		{
			goto IL_02ca;
		}
	}
	{
		float L_111 = V_8;
		float L_112 = V_37;
		float L_113 = V_36;
		float L_114 = V_37;
		float L_115;
		L_115 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline((0.0f), L_111, ((float)(((float)il2cpp_codegen_subtract(L_112, L_113))/L_114)), NULL);
		V_8 = L_115;
	}

IL_02ca:
	{
		int32_t L_116 = __this->___m_AdjustmentMode_28;
		V_39 = (bool)((!(((uint32_t)L_116) <= ((uint32_t)0)))? 1 : 0);
		bool L_117 = V_39;
		if (!L_117)
		{
			goto IL_0339;
		}
	}
	{
		float L_118 = V_8;
		float L_119 = V_3;
		float L_120;
		L_120 = tanf(((float)(((float)il2cpp_codegen_multiply(L_119, (0.0174532924f)))/(2.0f))));
		V_6 = ((float)(L_118/((float)il2cpp_codegen_multiply((2.0f), L_120))));
		float L_121 = V_6;
		float L_122 = __this->___m_MinimumDistance_32;
		float L_123 = __this->___m_MaximumDistance_33;
		float L_124;
		L_124 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_121, L_122, L_123, NULL);
		V_6 = L_124;
		float L_125 = V_6;
		float L_126 = __this->___m_CameraDistance_17;
		V_40 = ((float)il2cpp_codegen_subtract(L_125, L_126));
		float L_127 = V_40;
		float L_128 = __this->___m_MaxDollyIn_30;
		float L_129 = __this->___m_MaxDollyOut_31;
		float L_130;
		L_130 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_127, ((-L_128)), L_129, NULL);
		V_40 = L_130;
		float L_131 = __this->___m_CameraDistance_17;
		float L_132 = V_40;
		V_6 = ((float)il2cpp_codegen_add(L_131, L_132));
	}

IL_0339:
	{
	}

IL_033a:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_133 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_134 = L_133->___RawOrientation_5;
		V_9 = L_134;
		bool L_135 = V_2;
		if (!L_135)
		{
			goto IL_034d;
		}
	}
	{
		bool L_136 = __this->___m_TargetMovementOnly_14;
		G_B46_0 = ((int32_t)(L_136));
		goto IL_034e;
	}

IL_034d:
	{
		G_B46_0 = 0;
	}

IL_034e:
	{
		V_41 = (bool)G_B46_0;
		bool L_137 = V_41;
		if (!L_137)
		{
			goto IL_0393;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_138 = V_9;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_139 = __this->___m_prevRotation_45;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_140;
		L_140 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_139, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_141;
		L_141 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_138, L_140, NULL);
		V_42 = L_141;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_142;
		L_142 = CinemachineFramingTransposer_get_TrackedPoint_m893C86296D7D0C01FCD28D85D14B38124F9AFB52_inline(__this, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_143 = V_42;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_144 = __this->___m_PreviousCameraPosition_40;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_145;
		L_145 = CinemachineFramingTransposer_get_TrackedPoint_m893C86296D7D0C01FCD28D85D14B38124F9AFB52_inline(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_146;
		L_146 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_144, L_145, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_147;
		L_147 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_143, L_146, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_148;
		L_148 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_142, L_147, NULL);
		__this->___m_PreviousCameraPosition_40 = L_148;
	}

IL_0393:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_149 = V_9;
		__this->___m_prevRotation_45 = L_149;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_150 = __this->___m_PreviousCameraPosition_40;
		V_10 = L_150;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_151 = V_9;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_152;
		L_152 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_151, NULL);
		V_11 = L_152;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_153 = V_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_154 = V_10;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_155;
		L_155 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_153, L_154, NULL);
		V_12 = L_155;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_156 = V_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_157;
		L_157 = CinemachineFramingTransposer_get_TrackedPoint_m893C86296D7D0C01FCD28D85D14B38124F9AFB52_inline(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_158;
		L_158 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_156, L_157, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_159 = V_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_160;
		L_160 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_158, L_159, NULL);
		V_13 = L_160;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_161 = V_13;
		V_14 = L_161;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_162;
		L_162 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_15 = L_162;
		float L_163 = V_6;
		float L_164 = __this->___m_DeadZoneDepth_20;
		float L_165;
		L_165 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.00999999978f), ((float)il2cpp_codegen_subtract(L_163, ((float)(L_164/(2.0f))))), NULL);
		V_16 = L_165;
		float L_166 = V_16;
		float L_167 = V_6;
		float L_168 = __this->___m_DeadZoneDepth_20;
		float L_169;
		L_169 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_166, ((float)il2cpp_codegen_add(L_167, ((float)(L_168/(2.0f))))), NULL);
		V_17 = L_169;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_170 = V_13;
		float L_171 = L_170.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_172 = V_14;
		float L_173 = L_172.___z_4;
		float L_174;
		L_174 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_171, L_173, NULL);
		V_18 = L_174;
		float L_175 = V_18;
		float L_176 = V_16;
		V_43 = (bool)((((float)L_175) < ((float)L_176))? 1 : 0);
		bool L_177 = V_43;
		if (!L_177)
		{
			goto IL_0438;
		}
	}
	{
		float L_178 = V_18;
		float L_179 = V_16;
		(&V_15)->___z_4 = ((float)il2cpp_codegen_subtract(L_178, L_179));
	}

IL_0438:
	{
		float L_180 = V_18;
		float L_181 = V_17;
		V_44 = (bool)((((float)L_180) > ((float)L_181))? 1 : 0);
		bool L_182 = V_44;
		if (!L_182)
		{
			goto IL_0450;
		}
	}
	{
		float L_183 = V_18;
		float L_184 = V_17;
		(&V_15)->___z_4 = ((float)il2cpp_codegen_subtract(L_183, L_184));
	}

IL_0450:
	{
		bool L_185;
		L_185 = LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D((&V_0), NULL);
		if (L_185)
		{
			goto IL_0478;
		}
	}
	{
		float L_186 = V_3;
		float L_187;
		L_187 = tanf(((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((0.5f), L_186)), (0.0174532924f))));
		float L_188 = V_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_189 = V_15;
		float L_190 = L_189.___z_4;
		G_B55_0 = ((float)il2cpp_codegen_multiply(L_187, ((float)il2cpp_codegen_subtract(L_188, L_190))));
		goto IL_047e;
	}

IL_0478:
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_191 = V_0;
		float L_192 = L_191.___OrthographicSize_2;
		G_B55_0 = L_192;
	}

IL_047e:
	{
		V_19 = G_B55_0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_193;
		L_193 = CinemachineFramingTransposer_get_SoftGuideRect_mCDC60214B6A81FBD8AAF9F6DECAEC86A562C504A(__this, NULL);
		float L_194 = V_19;
		float L_195;
		L_195 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&V_0), NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_196;
		L_196 = CinemachineFramingTransposer_ScreenToOrtho_m07AF0DD2BFAEF10102EFEDBB9D87F31EAFA35D41(__this, L_193, L_194, L_195, NULL);
		V_20 = L_196;
		bool L_197 = V_2;
		V_45 = (bool)((((int32_t)L_197) == ((int32_t)0))? 1 : 0);
		bool L_198 = V_45;
		if (!L_198)
		{
			goto IL_04ec;
		}
	}
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_199 = V_20;
		V_46 = L_199;
		bool L_200 = __this->___m_CenterOnActivate_26;
		if (!L_200)
		{
			goto IL_04b9;
		}
	}
	{
		bool L_201 = __this->___m_InheritingPosition_43;
		G_B59_0 = ((((int32_t)L_201) == ((int32_t)0))? 1 : 0);
		goto IL_04ba;
	}

IL_04b9:
	{
		G_B59_0 = 0;
	}

IL_04ba:
	{
		V_47 = (bool)G_B59_0;
		bool L_202 = V_47;
		if (!L_202)
		{
			goto IL_04d3;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_203;
		L_203 = Rect_get_center_mAA9A2E1F058B2C9F58E13CC4822F789F42975E5C_inline((&V_46), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_204;
		L_204 = Vector2_get_zero_m009B92B5D35AB02BD1610C2E1ACCE7C9CF964A6E_inline(NULL);
		Rect__ctor_m503705FE0E4E413041E3CE7F09270489F401C675_inline((&V_46), L_203, L_204, NULL);
	}

IL_04d3:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_205 = V_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_206 = V_13;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_207 = V_46;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_208;
		L_208 = CinemachineFramingTransposer_OrthoOffsetToScreenBounds_mB27FBC07BF36E7BBACD39AAE05C8D7D3B62A8A4E(__this, L_206, L_207, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_209;
		L_209 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_205, L_208, NULL);
		V_15 = L_209;
		goto IL_059a;
	}

IL_04ec:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_210 = V_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_211 = V_13;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_212 = V_20;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_213;
		L_213 = CinemachineFramingTransposer_OrthoOffsetToScreenBounds_mB27FBC07BF36E7BBACD39AAE05C8D7D3B62A8A4E(__this, L_211, L_212, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_214;
		L_214 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_210, L_213, NULL);
		V_15 = L_214;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_215;
		L_215 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_216 = V_15;
		float L_217 = __this->___m_XDamping_11;
		float L_218 = __this->___m_YDamping_12;
		float L_219 = __this->___m_ZDamping_13;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_220;
		memset((&L_220), 0, sizeof(L_220));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_220), L_217, L_218, L_219, NULL);
		float L_221 = ___deltaTime1;
		NullCheck(L_215);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_222;
		L_222 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m871E131EE59CEEC1B5691F5DC570B18816530C97(L_215, L_216, L_220, L_221, NULL);
		V_15 = L_222;
		bool L_223 = __this->___m_UnlimitedSoftZone_21;
		if (L_223)
		{
			goto IL_054e;
		}
	}
	{
		float L_224 = ___deltaTime1;
		if ((((float)L_224) < ((float)(0.0f))))
		{
			goto IL_054b;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_225;
		L_225 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_225);
		float L_226 = L_225->___FollowTargetAttachment_12;
		G_B66_0 = ((((float)L_226) > ((float)(0.999899983f)))? 1 : 0);
		goto IL_054c;
	}

IL_054b:
	{
		G_B66_0 = 1;
	}

IL_054c:
	{
		G_B68_0 = G_B66_0;
		goto IL_054f;
	}

IL_054e:
	{
		G_B68_0 = 0;
	}

IL_054f:
	{
		V_48 = (bool)G_B68_0;
		bool L_227 = V_48;
		if (!L_227)
		{
			goto IL_0599;
		}
	}
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_228;
		L_228 = CinemachineFramingTransposer_get_HardGuideRect_m83469B076C3529941A2FD36E35FFE410EA3D7BA5(__this, NULL);
		float L_229 = V_19;
		float L_230;
		L_230 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555((&V_0), NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_231;
		L_231 = CinemachineFramingTransposer_ScreenToOrtho_m07AF0DD2BFAEF10102EFEDBB9D87F31EAFA35D41(__this, L_228, L_229, L_230, NULL);
		V_49 = L_231;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_232 = V_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_233 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_234;
		L_234 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_232, L_233, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_235 = V_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_236;
		L_236 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_234, L_235, NULL);
		V_50 = L_236;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_237 = V_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_238 = V_50;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_239 = V_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_240;
		L_240 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_238, L_239, NULL);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_241 = V_49;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_242;
		L_242 = CinemachineFramingTransposer_OrthoOffsetToScreenBounds_mB27FBC07BF36E7BBACD39AAE05C8D7D3B62A8A4E(__this, L_240, L_241, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_243;
		L_243 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_237, L_242, NULL);
		V_15 = L_243;
	}

IL_0599:
	{
	}

IL_059a:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_244 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_245 = V_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_246 = V_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_247 = V_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_248;
		L_248 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_246, L_247, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_249;
		L_249 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_245, L_248, NULL);
		L_244->___RawPosition_4 = L_249;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_250 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_251 = L_250->___RawPosition_4;
		__this->___m_PreviousCameraPosition_40 = L_251;
		bool L_252 = V_5;
		V_51 = L_252;
		bool L_253 = V_51;
		if (!L_253)
		{
			goto IL_0711;
		}
	}
	{
		bool L_254 = V_7;
		V_52 = L_254;
		bool L_255 = V_52;
		if (!L_255)
		{
			goto IL_0646;
		}
	}
	{
		float L_256 = V_8;
		float L_257 = __this->___m_MinimumOrthoSize_36;
		float L_258 = __this->___m_MaximumOrthoSize_37;
		float L_259;
		L_259 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)(L_256/(2.0f))), L_257, L_258, NULL);
		V_8 = L_259;
		bool L_260 = V_2;
		V_53 = L_260;
		bool L_261 = V_53;
		if (!L_261)
		{
			goto IL_0617;
		}
	}
	{
		float L_262 = __this->___m_prevFOV_44;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_263;
		L_263 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		float L_264 = V_8;
		float L_265 = __this->___m_prevFOV_44;
		float L_266 = __this->___m_ZDamping_13;
		float L_267 = ___deltaTime1;
		NullCheck(L_263);
		float L_268;
		L_268 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m215A089B8451330FA8D7D6E4DB8E38400AD9E7CF(L_263, ((float)il2cpp_codegen_subtract(L_264, L_265)), L_266, L_267, NULL);
		V_8 = ((float)il2cpp_codegen_add(L_262, L_268));
	}

IL_0617:
	{
		float L_269 = V_8;
		__this->___m_prevFOV_44 = L_269;
		float L_270 = V_8;
		float L_271 = __this->___m_MinimumOrthoSize_36;
		float L_272 = __this->___m_MaximumOrthoSize_37;
		float L_273;
		L_273 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_270, L_271, L_272, NULL);
		(&V_0)->___OrthographicSize_2 = L_273;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_274 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_275 = V_0;
		L_274->___Lens_0 = L_275;
		goto IL_0710;
	}

IL_0646:
	{
		int32_t L_276 = __this->___m_AdjustmentMode_28;
		V_54 = (bool)((((int32_t)((((int32_t)L_276) == ((int32_t)1))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_277 = V_54;
		if (!L_277)
		{
			goto IL_0710;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_278 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_279 = L_278->___RawOrientation_5;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_280;
		L_280 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_279, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_281 = V_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_282 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_283 = L_282->___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_284;
		L_284 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_281, L_283, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_285;
		L_285 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_280, L_284, NULL);
		V_55 = L_285;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_286 = V_55;
		float L_287 = L_286.___z_4;
		V_56 = L_287;
		V_57 = (179.0f);
		float L_288 = V_56;
		V_58 = (bool)((((float)L_288) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_289 = V_58;
		if (!L_289)
		{
			goto IL_06b7;
		}
	}
	{
		float L_290 = V_8;
		float L_291 = V_56;
		float L_292;
		L_292 = atanf(((float)(L_290/((float)il2cpp_codegen_multiply((2.0f), L_291)))));
		V_57 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((2.0f), L_292)), (57.2957802f)));
	}

IL_06b7:
	{
		float L_293 = V_57;
		float L_294 = __this->___m_MinimumFOV_34;
		float L_295 = __this->___m_MaximumFOV_35;
		float L_296;
		L_296 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_293, L_294, L_295, NULL);
		V_57 = L_296;
		bool L_297 = V_2;
		V_59 = L_297;
		bool L_298 = V_59;
		if (!L_298)
		{
			goto IL_06f7;
		}
	}
	{
		float L_299 = __this->___m_prevFOV_44;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_300;
		L_300 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		float L_301 = V_57;
		float L_302 = __this->___m_prevFOV_44;
		float L_303 = __this->___m_ZDamping_13;
		float L_304 = ___deltaTime1;
		NullCheck(L_300);
		float L_305;
		L_305 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m215A089B8451330FA8D7D6E4DB8E38400AD9E7CF(L_300, ((float)il2cpp_codegen_subtract(L_301, L_302)), L_303, L_304, NULL);
		V_57 = ((float)il2cpp_codegen_add(L_299, L_305));
	}

IL_06f7:
	{
		float L_306 = V_57;
		__this->___m_prevFOV_44 = L_306;
		float L_307 = V_57;
		(&V_0)->___FieldOfView_1 = L_307;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_308 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_309 = V_0;
		L_308->___Lens_0 = L_309;
	}

IL_0710:
	{
	}

IL_0711:
	{
		__this->___m_InheritingPosition_43 = (bool)0;
	}

IL_0718:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineFramingTransposer_GetTargetHeight_m5CD0304B16E7442B6BA592E7915FE7C2F57D4A64 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___boundsSize0, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 V_2;
	memset((&V_2), 0, sizeof(V_2));
	float V_3 = 0.0f;
	{
		int32_t L_0 = __this->___m_GroupFramingMode_27;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_001e;
			}
			case 1:
			{
				goto IL_003b;
			}
			case 2:
			{
				goto IL_0044;
			}
		}
	}
	{
		goto IL_0044;
	}

IL_001e:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_3 = ___boundsSize0;
		float L_4 = L_3.___x_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_5;
		L_5 = CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2(__this, NULL);
		V_2 = L_5;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_6 = (&(&V_2)->___Lens_0);
		float L_7;
		L_7 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555(L_6, NULL);
		V_3 = ((float)(L_4/L_7));
		goto IL_006c;
	}

IL_003b:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_8 = ___boundsSize0;
		float L_9 = L_8.___y_1;
		V_3 = L_9;
		goto IL_006c;
	}

IL_0044:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10 = ___boundsSize0;
		float L_11 = L_10.___x_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_12;
		L_12 = CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2(__this, NULL);
		V_2 = L_12;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_13 = (&(&V_2)->___Lens_0);
		float L_14;
		L_14 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555(L_13, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_15 = ___boundsSize0;
		float L_16 = L_15.___y_1;
		float L_17;
		L_17 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(((float)(L_11/L_14)), L_16, NULL);
		V_3 = L_17;
		goto IL_006c;
	}

IL_006c:
	{
		float L_18 = V_3;
		return L_18;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineFramingTransposer_ComputeGroupBounds_mD7044C4EFA049F1BD91607D7EB5FE2F26E7A78D2 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, RuntimeObject* ___group0, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_3;
	memset((&V_3), 0, sizeof(V_3));
	float V_4 = 0.0f;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_5;
	memset((&V_5), 0, sizeof(V_5));
	bool V_6 = false;
	float V_7 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_8;
	memset((&V_8), 0, sizeof(V_8));
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_0 = ___curState1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = L_0->___RawPosition_4;
		V_0 = L_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_2 = ___curState1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3 = L_2->___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4;
		L_4 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		L_5 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_3, L_4, NULL);
		V_1 = L_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = V_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_7 = ___curState1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_8 = L_7->___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		L_9 = Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline(NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_10;
		L_10 = Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680(L_6, L_8, L_9, NULL);
		CinemachineFramingTransposer_set_LastBoundsMatrix_m13FAE68552F3910750A134D22AE4AF6845C0301D_inline(__this, L_10, NULL);
		RuntimeObject* L_11 = ___group0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_12;
		L_12 = CinemachineFramingTransposer_get_LastBoundsMatrix_mB1296133E5C0BDD6B9C0879888C468C559BE95BB_inline(__this, NULL);
		NullCheck(L_11);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_13;
		L_13 = InterfaceFuncInvoker1< Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 >::Invoke(4, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_11, L_12);
		V_2 = L_13;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_14;
		L_14 = CinemachineFramingTransposer_get_LastBoundsMatrix_mB1296133E5C0BDD6B9C0879888C468C559BE95BB_inline(__this, NULL);
		V_5 = L_14;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15;
		L_15 = Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline((&V_2), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16;
		L_16 = Matrix4x4_MultiplyPoint3x4_mACCBD70AFA82C63DA88555780B7B6B01281AB814((&V_5), L_15, NULL);
		V_3 = L_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		L_17 = Bounds_get_extents_mFE6DC407FCE2341BE2C750CB554055D211281D25_inline((&V_2), NULL);
		float L_18 = L_17.___z_4;
		V_4 = L_18;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_19 = ___curState1;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_20 = (&L_19->___Lens_0);
		bool L_21;
		L_21 = LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D(L_20, NULL);
		V_6 = (bool)((((int32_t)L_21) == ((int32_t)0))? 1 : 0);
		bool L_22 = V_6;
		if (!L_22)
		{
			goto IL_00ee;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_23 = ___curState1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_24 = L_23->___RawOrientation_5;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_25;
		L_25 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_24, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28;
		L_28 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_26, L_27, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29;
		L_29 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_25, L_28, NULL);
		float L_30 = L_29.___z_4;
		V_7 = L_30;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32 = V_1;
		float L_33 = V_7;
		float L_34 = V_4;
		float L_35;
		L_35 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_33, L_34, NULL);
		float L_36 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_37;
		L_37 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_32, ((float)il2cpp_codegen_add(L_35, L_36)), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38;
		L_38 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_31, L_37, NULL);
		V_0 = L_38;
		RuntimeObject* L_39 = ___group0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_40 = ___curState1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_41 = L_40->___RawOrientation_5;
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_42;
		L_42 = CinemachineFramingTransposer_GetScreenSpaceGroupBoundingBox_mD6B121234F24AC755C1485C22B9A486625B3F58D(L_39, (&V_0), L_41, NULL);
		V_2 = L_42;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43 = V_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_44 = ___curState1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_45 = L_44->___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46;
		L_46 = Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline(NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_47;
		L_47 = Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680(L_43, L_45, L_46, NULL);
		CinemachineFramingTransposer_set_LastBoundsMatrix_m13FAE68552F3910750A134D22AE4AF6845C0301D_inline(__this, L_47, NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_48;
		L_48 = CinemachineFramingTransposer_get_LastBoundsMatrix_mB1296133E5C0BDD6B9C0879888C468C559BE95BB_inline(__this, NULL);
		V_5 = L_48;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49;
		L_49 = Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline((&V_2), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50;
		L_50 = Matrix4x4_MultiplyPoint3x4_mACCBD70AFA82C63DA88555780B7B6B01281AB814((&V_5), L_49, NULL);
		V_3 = L_50;
	}

IL_00ee:
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_51 = V_2;
		CinemachineFramingTransposer_set_LastBounds_m42F030170155BAC06C2B040E44F4FCB25251EF93_inline(__this, L_51, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_52 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_53 = V_1;
		float L_54 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_55;
		L_55 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_53, L_54, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_56;
		L_56 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_52, L_55, NULL);
		V_8 = L_56;
		goto IL_0108;
	}

IL_0108:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_57 = V_8;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineFramingTransposer_GetScreenSpaceGroupBoundingBox_mD6B121234F24AC755C1485C22B9A486625B3F58D (RuntimeObject* ___group0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___pos1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___orientation2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_5;
	memset((&V_5), 0, sizeof(V_5));
	float V_6 = 0.0f;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_7;
	memset((&V_7), 0, sizeof(V_7));
	bool V_8 = false;
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 V_9;
	memset((&V_9), 0, sizeof(V_9));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_0 = ___pos1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_0);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2 = ___orientation2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline(NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_4;
		L_4 = Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680(L_1, L_2, L_3, NULL);
		V_0 = L_4;
		RuntimeObject* L_5 = ___group0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_6 = V_0;
		NullCheck(L_5);
		InterfaceActionInvoker4< Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* >::Invoke(5, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_5, L_6, (&V_1), (&V_2), (&V_3));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_7 = V_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_8 = V_2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_9;
		L_9 = Vector2_op_Addition_m704B5B98EAFE885978381E21B7F89D9DF83C2A60_inline(L_7, L_8, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10;
		L_10 = Vector2_op_Division_m69F64D545E3C023BE9927397572349A569141EBA_inline(L_9, (2.0f), NULL);
		V_4 = L_10;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_11;
		L_11 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_12 = V_4;
		float L_13 = L_12.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_14 = V_4;
		float L_15 = L_14.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_16;
		memset((&L_16), 0, sizeof(L_16));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_16), ((-L_13)), L_15, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		L_17 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_18;
		L_18 = UnityQuaternionExtensions_ApplyCameraRotation_m75753B356C2E3BC79192192C8C2FC1F512643506(L_11, L_16, L_17, NULL);
		V_5 = L_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_19 = ___pos1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20 = V_5;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_21 = V_3;
		float L_22 = L_21.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_23 = V_3;
		float L_24 = L_23.___x_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		memset((&L_25), 0, sizeof(L_25));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_25), (0.0f), (0.0f), ((float)(((float)il2cpp_codegen_add(L_22, L_24))/(2.0f))), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26;
		L_26 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_20, L_25, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_19 = L_26;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_27 = ___pos1;
		L_27->___z_4 = (0.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_28 = ___pos1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_29 = ___pos1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_29);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31;
		L_31 = Matrix4x4_MultiplyPoint3x4_mACCBD70AFA82C63DA88555780B7B6B01281AB814((&V_0), L_30, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_28 = L_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_32 = ___pos1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_32);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_34 = ___orientation2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35;
		L_35 = Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline(NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_36;
		L_36 = Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680(L_33, L_34, L_35, NULL);
		V_0 = L_36;
		RuntimeObject* L_37 = ___group0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_38 = V_0;
		NullCheck(L_37);
		InterfaceActionInvoker4< Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* >::Invoke(5, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_37, L_38, (&V_1), (&V_2), (&V_3));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_39 = V_3;
		float L_40 = L_39.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_41 = V_3;
		float L_42 = L_41.___x_0;
		V_6 = ((float)il2cpp_codegen_add(L_40, L_42));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&V_7), (89.5f), (89.5f), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_43 = V_3;
		float L_44 = L_43.___x_0;
		V_8 = (bool)((((float)L_44) > ((float)(0.0f)))? 1 : 0);
		bool L_45 = V_8;
		if (!L_45)
		{
			goto IL_0121;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_46 = V_2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_47 = V_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_48;
		L_48 = UnityVectorExtensions_Abs_m4E617236E1CCFE843CA67854AC8E48AC22323BA9(L_47, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_49;
		L_49 = Vector2_Max_m5FF3A49170F857E422CDD32A51CABEAE568E8088_inline(L_46, L_48, NULL);
		V_7 = L_49;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_50 = V_7;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_51;
		memset((&L_51), 0, sizeof(L_51));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_51), (89.5f), (89.5f), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_52;
		L_52 = Vector2_Min_mAB64CD54A495856162FC5753B6C6B572AA4BEA1D_inline(L_50, L_51, NULL);
		V_7 = L_52;
	}

IL_0121:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_53 = V_7;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_54;
		L_54 = Vector2_op_Multiply_m4EEB2FF3F4830390A53CE9B6076FB31801D65EED_inline(L_53, (0.0174532924f), NULL);
		V_7 = L_54;
		float L_55 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_56;
		memset((&L_56), 0, sizeof(L_56));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_56), (0.0f), (0.0f), ((float)(L_55/(2.0f))), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_57 = V_7;
		float L_58 = L_57.___y_1;
		float L_59;
		L_59 = tanf(L_58);
		float L_60 = V_6;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_61 = V_7;
		float L_62 = L_61.___x_0;
		float L_63;
		L_63 = tanf(L_62);
		float L_64 = V_6;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_65 = V_3;
		float L_66 = L_65.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_67 = V_3;
		float L_68 = L_67.___x_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_69;
		memset((&L_69), 0, sizeof(L_69));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_69), ((float)il2cpp_codegen_multiply(L_59, L_60)), ((float)il2cpp_codegen_multiply(L_63, L_64)), ((float)il2cpp_codegen_subtract(L_66, L_68)), NULL);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_70;
		memset((&L_70), 0, sizeof(L_70));
		Bounds__ctor_mAF7B238B9FBF90C495E5D7951760085A93119C5A_inline((&L_70), L_56, L_69, NULL);
		V_9 = L_70;
		goto IL_017f;
	}

IL_017f:
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_71 = V_9;
		return L_71;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineFramingTransposer__ctor_mDC6AE4489F2CBA1B667DDE193E2C1D1C3D3332D5 (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->___m_LookaheadTime_8 = (0.0f);
		__this->___m_LookaheadSmoothing_9 = (0.0f);
		__this->___m_XDamping_11 = (1.0f);
		__this->___m_YDamping_12 = (1.0f);
		__this->___m_ZDamping_13 = (1.0f);
		__this->___m_TargetMovementOnly_14 = (bool)1;
		__this->___m_ScreenX_15 = (0.5f);
		__this->___m_ScreenY_16 = (0.5f);
		__this->___m_CameraDistance_17 = (10.0f);
		__this->___m_DeadZoneWidth_18 = (0.0f);
		__this->___m_DeadZoneHeight_19 = (0.0f);
		__this->___m_DeadZoneDepth_20 = (0.0f);
		__this->___m_UnlimitedSoftZone_21 = (bool)0;
		__this->___m_SoftZoneWidth_22 = (0.800000012f);
		__this->___m_SoftZoneHeight_23 = (0.800000012f);
		__this->___m_BiasX_24 = (0.0f);
		__this->___m_BiasY_25 = (0.0f);
		__this->___m_CenterOnActivate_26 = (bool)1;
		__this->___m_GroupFramingMode_27 = 2;
		__this->___m_AdjustmentMode_28 = 0;
		__this->___m_GroupFramingSize_29 = (0.800000012f);
		__this->___m_MaxDollyIn_30 = (5000.0f);
		__this->___m_MaxDollyOut_31 = (5000.0f);
		__this->___m_MinimumDistance_32 = (1.0f);
		__this->___m_MaximumDistance_33 = (5000.0f);
		__this->___m_MinimumFOV_34 = (3.0f);
		__this->___m_MaximumFOV_35 = (60.0f);
		__this->___m_MinimumOrthoSize_36 = (1.0f);
		__this->___m_MaximumOrthoSize_37 = (5000.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_PreviousCameraPosition_40 = L_0;
		PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E* L_1 = (PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E*)il2cpp_codegen_object_new(PositionPredictor_t088813DB07D6355BB293350EB983299B866F974E_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		PositionPredictor__ctor_m98DC334F817608D8CA4FA09966193AA59A16DB25(L_1, NULL);
		__this->___m_Predictor_41 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_Predictor_41), (void*)L_1);
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineGroupComposer_OnValidate_m4F578A19AB48C00C385A8AB096DFD5E8C8991D77 (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___m_GroupFramingSize_29;
		float L_1;
		L_1 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.00100000005f), L_0, NULL);
		__this->___m_GroupFramingSize_29 = L_1;
		float L_2 = __this->___m_MaxDollyIn_33;
		float L_3;
		L_3 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_2, NULL);
		__this->___m_MaxDollyIn_33 = L_3;
		float L_4 = __this->___m_MaxDollyOut_34;
		float L_5;
		L_5 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_4, NULL);
		__this->___m_MaxDollyOut_34 = L_5;
		float L_6 = __this->___m_MinimumDistance_35;
		float L_7;
		L_7 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_6, NULL);
		__this->___m_MinimumDistance_35 = L_7;
		float L_8 = __this->___m_MinimumDistance_35;
		float L_9 = __this->___m_MaximumDistance_36;
		float L_10;
		L_10 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_8, L_9, NULL);
		__this->___m_MaximumDistance_36 = L_10;
		float L_11 = __this->___m_MinimumFOV_37;
		float L_12;
		L_12 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((1.0f), L_11, NULL);
		__this->___m_MinimumFOV_37 = L_12;
		float L_13 = __this->___m_MaximumFOV_38;
		float L_14 = __this->___m_MinimumFOV_37;
		float L_15;
		L_15 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_13, L_14, (179.0f), NULL);
		__this->___m_MaximumFOV_38 = L_15;
		float L_16 = __this->___m_MinimumOrthoSize_39;
		float L_17;
		L_17 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.00999999978f), L_16, NULL);
		__this->___m_MinimumOrthoSize_39 = L_17;
		float L_18 = __this->___m_MinimumOrthoSize_39;
		float L_19 = __this->___m_MaximumOrthoSize_40;
		float L_20;
		L_20 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_18, L_19, NULL);
		__this->___m_MaximumOrthoSize_40 = L_20;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineGroupComposer_get_LastBounds_mC2ABA5C693EB4C5AC2676461601D5F9DC5615623 (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, const RuntimeMethod* method) 
{
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_0 = __this->___U3CLastBoundsU3Ek__BackingField_43;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineGroupComposer_set_LastBounds_mE2FCF71321530F97627893A8BA652B959D19110C (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___value0, const RuntimeMethod* method) 
{
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_0 = ___value0;
		__this->___U3CLastBoundsU3Ek__BackingField_43 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 CinemachineGroupComposer_get_LastBoundsMatrix_m67F9243F621C6474E2090615DDE98B6E69B81E52 (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = __this->___U3CLastBoundsMatrixU3Ek__BackingField_44;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineGroupComposer_set_LastBoundsMatrix_m917FDDE19382BCDA1626CF4BB5E118E43C1D13A3 (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = ___value0;
		__this->___U3CLastBoundsMatrixU3Ek__BackingField_44 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineGroupComposer_GetMaxDampTime_mED0FCE86105021DEFD27DC6546387EE1AEBEAFA0 (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0;
		L_0 = CinemachineComposer_GetMaxDampTime_m1D830B2C6BDB743F6C546C27AA62A60704BC4CA0(__this, NULL);
		float L_1 = __this->___m_FrameDamping_31;
		float L_2;
		L_2 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_0, L_1, NULL);
		V_0 = L_2;
		goto IL_0015;
	}

IL_0015:
	{
		float L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineGroupComposer_MutateCameraState_mBA96192C982AF7399B01AD3FCE14D48F6C27373A (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	bool V_1 = false;
	bool V_2 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	BoundingSphere_t2DDB3D1711A6920C0ECA9217D3E4E14AFF03C010 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_7;
	memset((&V_7), 0, sizeof(V_7));
	float V_8 = 0.0f;
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 V_9;
	memset((&V_9), 0, sizeof(V_9));
	float V_10 = 0.0f;
	float V_11 = 0.0f;
	bool V_12 = false;
	bool V_13 = false;
	bool V_14 = false;
	bool V_15 = false;
	Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 V_16;
	memset((&V_16), 0, sizeof(V_16));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_17;
	memset((&V_17), 0, sizeof(V_17));
	bool V_18 = false;
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE V_19;
	memset((&V_19), 0, sizeof(V_19));
	bool V_20 = false;
	float V_21 = 0.0f;
	bool V_22 = false;
	bool V_23 = false;
	float V_24 = 0.0f;
	float V_25 = 0.0f;
	bool V_26 = false;
	float V_27 = 0.0f;
	bool V_28 = false;
	float V_29 = 0.0f;
	float V_30 = 0.0f;
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE V_31;
	memset((&V_31), 0, sizeof(V_31));
	bool V_32 = false;
	bool V_33 = false;
	int32_t G_B5_0 = 0;
	int32_t G_B10_0 = 0;
	int32_t G_B19_0 = 0;
	int32_t G_B28_0 = 0;
	int32_t G_B38_0 = 0;
	{
		RuntimeObject* L_0;
		L_0 = CinemachineComponentBase_get_AbstractLookAtTargetGroup_m83547AD312D71E3080F9C6948DF4C5DA7B6B6054(__this, NULL);
		V_0 = L_0;
		RuntimeObject* L_1 = V_0;
		V_12 = (bool)((((RuntimeObject*)(RuntimeObject*)L_1) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_2 = V_12;
		if (!L_2)
		{
			goto IL_0021;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_3 = ___curState0;
		float L_4 = ___deltaTime1;
		CinemachineComposer_MutateCameraState_m50DD037C33A1BF4956C47F8ADA6F6CBADDDA4B3A(__this, L_3, L_4, NULL);
		goto IL_04a6;
	}

IL_0021:
	{
		bool L_5;
		L_5 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_6 = ___curState0;
		bool L_7;
		L_7 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC(L_6, NULL);
		G_B5_0 = ((((int32_t)L_7) == ((int32_t)0))? 1 : 0);
		goto IL_0035;
	}

IL_0034:
	{
		G_B5_0 = 1;
	}

IL_0035:
	{
		V_13 = (bool)G_B5_0;
		bool L_8 = V_13;
		if (!L_8)
		{
			goto IL_0057;
		}
	}
	{
		__this->___m_prevFramingDistance_41 = (0.0f);
		__this->___m_prevFOV_42 = (0.0f);
		goto IL_04a6;
	}

IL_0057:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_9 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_10 = (&L_9->___Lens_0);
		bool L_11;
		L_11 = LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D(L_10, NULL);
		V_1 = L_11;
		bool L_12 = V_1;
		if (L_12)
		{
			goto IL_0071;
		}
	}
	{
		int32_t L_13 = __this->___m_AdjustmentMode_32;
		G_B10_0 = ((!(((uint32_t)L_13) <= ((uint32_t)0)))? 1 : 0);
		goto IL_0072;
	}

IL_0071:
	{
		G_B10_0 = 0;
	}

IL_0072:
	{
		V_2 = (bool)G_B10_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_14 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = L_14->___ReferenceUp_1;
		V_3 = L_15;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_16 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = L_16->___RawPosition_4;
		V_4 = L_17;
		RuntimeObject* L_18 = V_0;
		NullCheck(L_18);
		BoundingSphere_t2DDB3D1711A6920C0ECA9217D3E4E14AFF03C010 L_19;
		L_19 = InterfaceFuncInvoker0< BoundingSphere_t2DDB3D1711A6920C0ECA9217D3E4E14AFF03C010 >::Invoke(2, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_18);
		V_5 = L_19;
		BoundingSphere_t2DDB3D1711A6920C0ECA9217D3E4E14AFF03C010 L_20 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = L_20.___position_0;
		V_6 = L_21;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_22, L_23, NULL);
		V_7 = L_24;
		float L_25;
		L_25 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_7), NULL);
		V_8 = L_25;
		float L_26 = V_8;
		V_14 = (bool)((((float)L_26) < ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_27 = V_14;
		if (!L_27)
		{
			goto IL_00bb;
		}
	}
	{
		goto IL_04a6;
	}

IL_00bb:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = V_7;
		float L_29 = V_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		L_30 = Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline(L_28, L_29, NULL);
		V_7 = L_30;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33 = V_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_34;
		L_34 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_32, L_33, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35;
		L_35 = Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline(NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_36;
		L_36 = Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680(L_31, L_34, L_35, NULL);
		CinemachineGroupComposer_set_LastBoundsMatrix_m917FDDE19382BCDA1626CF4BB5E118E43C1D13A3_inline(__this, L_36, NULL);
		bool L_37 = V_1;
		V_15 = L_37;
		bool L_38 = V_15;
		if (!L_38)
		{
			goto IL_0158;
		}
	}
	{
		RuntimeObject* L_39 = V_0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_40;
		L_40 = CinemachineGroupComposer_get_LastBoundsMatrix_m67F9243F621C6474E2090615DDE98B6E69B81E52_inline(__this, NULL);
		NullCheck(L_39);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_41;
		L_41 = InterfaceFuncInvoker1< Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 >::Invoke(4, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_39, L_40);
		V_9 = L_41;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_42;
		L_42 = CinemachineGroupComposer_get_LastBoundsMatrix_m67F9243F621C6474E2090615DDE98B6E69B81E52_inline(__this, NULL);
		V_16 = L_42;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43;
		L_43 = Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline((&V_9), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_44;
		L_44 = Matrix4x4_MultiplyPoint3x4_mACCBD70AFA82C63DA88555780B7B6B01281AB814((&V_16), L_43, NULL);
		V_6 = L_44;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47;
		L_47 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_45, L_46, NULL);
		V_17 = L_47;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_48;
		L_48 = Vector3_get_normalized_m736BBF65D5CDA7A18414370D15B4DFCC1E466F07_inline((&V_17), NULL);
		V_7 = L_48;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51 = V_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_52;
		L_52 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_50, L_51, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_53;
		L_53 = Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline(NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_54;
		L_54 = Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680(L_49, L_52, L_53, NULL);
		CinemachineGroupComposer_set_LastBoundsMatrix_m917FDDE19382BCDA1626CF4BB5E118E43C1D13A3_inline(__this, L_54, NULL);
		RuntimeObject* L_55 = V_0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_56;
		L_56 = CinemachineGroupComposer_get_LastBoundsMatrix_m67F9243F621C6474E2090615DDE98B6E69B81E52_inline(__this, NULL);
		NullCheck(L_55);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_57;
		L_57 = InterfaceFuncInvoker1< Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 >::Invoke(4, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_55, L_56);
		V_9 = L_57;
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_58 = V_9;
		CinemachineGroupComposer_set_LastBounds_mE2FCF71321530F97627893A8BA652B959D19110C_inline(__this, L_58, NULL);
		goto IL_01aa;
	}

IL_0158:
	{
		RuntimeObject* L_59 = V_0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_60;
		L_60 = CinemachineGroupComposer_get_LastBoundsMatrix_m67F9243F621C6474E2090615DDE98B6E69B81E52_inline(__this, NULL);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_61;
		L_61 = CinemachineGroupComposer_GetScreenSpaceGroupBoundingBox_m567C86F8FB8092CF4BABDE712030C3E1772A22A9(L_59, L_60, (&V_7), NULL);
		V_9 = L_61;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_62 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_63 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_64 = V_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_65;
		L_65 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_63, L_64, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_66;
		L_66 = Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline(NULL);
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_67;
		L_67 = Matrix4x4_TRS_mFEBA6926DB0044B96EF0CE98F30FEE7596820680(L_62, L_65, L_66, NULL);
		CinemachineGroupComposer_set_LastBoundsMatrix_m917FDDE19382BCDA1626CF4BB5E118E43C1D13A3_inline(__this, L_67, NULL);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_68 = V_9;
		CinemachineGroupComposer_set_LastBounds_mE2FCF71321530F97627893A8BA652B959D19110C_inline(__this, L_68, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_69 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_70 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_71;
		L_71 = Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline((&V_9), NULL);
		float L_72 = L_71.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_73;
		L_73 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_70, L_72, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_74;
		L_74 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_69, L_73, NULL);
		V_6 = L_74;
	}

IL_01aa:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_75;
		L_75 = Bounds_get_extents_mFE6DC407FCE2341BE2C750CB554055D211281D25_inline((&V_9), NULL);
		float L_76 = L_75.___z_4;
		V_10 = L_76;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_77;
		L_77 = Bounds_get_size_m0699A53A55A78B3201D7270D6F338DFA91B6FAD4_inline((&V_9), NULL);
		float L_78 = __this->___m_GroupFramingSize_29;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79;
		L_79 = Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline(L_77, L_78, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_80;
		L_80 = Vector2_op_Implicit_m8F73B300CB4E6F9B4EB5FB6130363D76CEAA230B_inline(L_79, NULL);
		float L_81;
		L_81 = CinemachineGroupComposer_GetTargetHeight_mE81E9435860ADF221E7DD164A4ADF411AB4C740A(__this, L_80, NULL);
		V_11 = L_81;
		bool L_82 = V_1;
		V_18 = L_82;
		bool L_83 = V_18;
		if (!L_83)
		{
			goto IL_0275;
		}
	}
	{
		float L_84 = V_11;
		float L_85 = __this->___m_MinimumOrthoSize_39;
		float L_86 = __this->___m_MaximumOrthoSize_40;
		float L_87;
		L_87 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)(L_84/(2.0f))), L_85, L_86, NULL);
		V_11 = L_87;
		float L_88 = ___deltaTime1;
		if ((!(((float)L_88) >= ((float)(0.0f)))))
		{
			goto IL_0212;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_89;
		L_89 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_89);
		bool L_90;
		L_90 = VirtualFuncInvoker0< bool >::Invoke(31, L_89);
		G_B19_0 = ((int32_t)(L_90));
		goto IL_0213;
	}

IL_0212:
	{
		G_B19_0 = 0;
	}

IL_0213:
	{
		V_20 = (bool)G_B19_0;
		bool L_91 = V_20;
		if (!L_91)
		{
			goto IL_023d;
		}
	}
	{
		float L_92 = __this->___m_prevFOV_42;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_93;
		L_93 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		float L_94 = V_11;
		float L_95 = __this->___m_prevFOV_42;
		float L_96 = __this->___m_FrameDamping_31;
		float L_97 = ___deltaTime1;
		NullCheck(L_93);
		float L_98;
		L_98 = CinemachineVirtualCameraBase_DetachedLookAtTargetDamp_mFB6FAA90EB2A5263D19E3D91C30C072C972E849E(L_93, ((float)il2cpp_codegen_subtract(L_94, L_95)), L_96, L_97, NULL);
		V_11 = ((float)il2cpp_codegen_add(L_92, L_98));
	}

IL_023d:
	{
		float L_99 = V_11;
		__this->___m_prevFOV_42 = L_99;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_100 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_101 = L_100->___Lens_0;
		V_19 = L_101;
		float L_102 = V_11;
		float L_103 = __this->___m_MinimumOrthoSize_39;
		float L_104 = __this->___m_MaximumOrthoSize_40;
		float L_105;
		L_105 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_102, L_103, L_104, NULL);
		(&V_19)->___OrthographicSize_2 = L_105;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_106 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_107 = V_19;
		L_106->___Lens_0 = L_107;
		goto IL_0488;
	}

IL_0275:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_108;
		L_108 = Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline((&V_9), NULL);
		float L_109 = L_108.___z_4;
		V_21 = L_109;
		float L_110 = V_21;
		float L_111 = V_10;
		V_22 = (bool)((((float)L_110) > ((float)L_111))? 1 : 0);
		bool L_112 = V_22;
		if (!L_112)
		{
			goto IL_02a6;
		}
	}
	{
		float L_113 = V_11;
		float L_114 = V_21;
		float L_115 = V_10;
		float L_116 = V_21;
		float L_117;
		L_117 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline((0.0f), L_113, ((float)(((float)il2cpp_codegen_subtract(L_114, L_115))/L_116)), NULL);
		V_11 = L_117;
	}

IL_02a6:
	{
		bool L_118 = V_2;
		V_23 = L_118;
		bool L_119 = V_23;
		if (!L_119)
		{
			goto IL_03a2;
		}
	}
	{
		float L_120 = V_10;
		float L_121 = V_11;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_122 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_123 = (&L_122->___Lens_0);
		float L_124 = L_123->___FieldOfView_1;
		float L_125;
		L_125 = tanf(((float)(((float)il2cpp_codegen_multiply(L_124, (0.0174532924f)))/(2.0f))));
		V_24 = ((float)il2cpp_codegen_add(L_120, ((float)(L_121/((float)il2cpp_codegen_multiply((2.0f), L_125))))));
		float L_126 = V_24;
		float L_127 = V_10;
		float L_128 = __this->___m_MinimumDistance_35;
		float L_129 = V_10;
		float L_130 = __this->___m_MaximumDistance_36;
		float L_131;
		L_131 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_126, ((float)il2cpp_codegen_add(L_127, L_128)), ((float)il2cpp_codegen_add(L_129, L_130)), NULL);
		V_24 = L_131;
		float L_132 = V_24;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_133 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_134 = L_133->___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_135 = V_6;
		float L_136;
		L_136 = Vector3_Distance_m99C722723EDD875852EF854AD7B7C4F8AC4F84AB_inline(L_134, L_135, NULL);
		V_25 = ((float)il2cpp_codegen_subtract(L_132, L_136));
		float L_137 = V_25;
		float L_138 = __this->___m_MaxDollyIn_33;
		float L_139 = __this->___m_MaxDollyOut_34;
		float L_140;
		L_140 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_137, ((-L_138)), L_139, NULL);
		V_25 = L_140;
		float L_141 = ___deltaTime1;
		if ((!(((float)L_141) >= ((float)(0.0f)))))
		{
			goto IL_0333;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_142;
		L_142 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_142);
		bool L_143;
		L_143 = VirtualFuncInvoker0< bool >::Invoke(31, L_142);
		G_B28_0 = ((int32_t)(L_143));
		goto IL_0334;
	}

IL_0333:
	{
		G_B28_0 = 0;
	}

IL_0334:
	{
		V_26 = (bool)G_B28_0;
		bool L_144 = V_26;
		if (!L_144)
		{
			goto IL_0368;
		}
	}
	{
		float L_145 = V_25;
		float L_146 = __this->___m_prevFramingDistance_41;
		V_27 = ((float)il2cpp_codegen_subtract(L_145, L_146));
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_147;
		L_147 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		float L_148 = V_27;
		float L_149 = __this->___m_FrameDamping_31;
		float L_150 = ___deltaTime1;
		NullCheck(L_147);
		float L_151;
		L_151 = CinemachineVirtualCameraBase_DetachedLookAtTargetDamp_mFB6FAA90EB2A5263D19E3D91C30C072C972E849E(L_147, L_148, L_149, L_150, NULL);
		V_27 = L_151;
		float L_152 = __this->___m_prevFramingDistance_41;
		float L_153 = V_27;
		V_25 = ((float)il2cpp_codegen_add(L_152, L_153));
	}

IL_0368:
	{
		float L_154 = V_25;
		__this->___m_prevFramingDistance_41 = L_154;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_155 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_156 = (&L_155->___PositionCorrection_8);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_157 = L_156;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_158 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_157);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_159 = V_7;
		float L_160 = V_25;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_161;
		L_161 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_159, L_160, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_162;
		L_162 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_158, L_161, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_157 = L_162;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_163 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_164 = V_7;
		float L_165 = V_25;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_166;
		L_166 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_164, L_165, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_167;
		L_167 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_163, L_166, NULL);
		V_4 = L_167;
	}

IL_03a2:
	{
		int32_t L_168 = __this->___m_AdjustmentMode_32;
		V_28 = (bool)((((int32_t)((((int32_t)L_168) == ((int32_t)1))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_169 = V_28;
		if (!L_169)
		{
			goto IL_0487;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_170 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_171 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_172;
		L_172 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_170, L_171, NULL);
		V_17 = L_172;
		float L_173;
		L_173 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_17), NULL);
		float L_174 = V_10;
		V_29 = ((float)il2cpp_codegen_subtract(L_173, L_174));
		V_30 = (179.0f);
		float L_175 = V_29;
		V_32 = (bool)((((float)L_175) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_176 = V_32;
		if (!L_176)
		{
			goto IL_0403;
		}
	}
	{
		float L_177 = V_11;
		float L_178 = V_29;
		float L_179;
		L_179 = atanf(((float)(L_177/((float)il2cpp_codegen_multiply((2.0f), L_178)))));
		V_30 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((2.0f), L_179)), (57.2957802f)));
	}

IL_0403:
	{
		float L_180 = V_30;
		float L_181 = __this->___m_MinimumFOV_37;
		float L_182 = __this->___m_MaximumFOV_38;
		float L_183;
		L_183 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_180, L_181, L_182, NULL);
		V_30 = L_183;
		float L_184 = ___deltaTime1;
		if ((!(((float)L_184) >= ((float)(0.0f)))))
		{
			goto IL_043a;
		}
	}
	{
		float L_185 = __this->___m_prevFOV_42;
		if ((((float)L_185) == ((float)(0.0f))))
		{
			goto IL_043a;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_186;
		L_186 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_186);
		bool L_187;
		L_187 = VirtualFuncInvoker0< bool >::Invoke(31, L_186);
		G_B38_0 = ((int32_t)(L_187));
		goto IL_043b;
	}

IL_043a:
	{
		G_B38_0 = 0;
	}

IL_043b:
	{
		V_33 = (bool)G_B38_0;
		bool L_188 = V_33;
		if (!L_188)
		{
			goto IL_0465;
		}
	}
	{
		float L_189 = __this->___m_prevFOV_42;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_190;
		L_190 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		float L_191 = V_30;
		float L_192 = __this->___m_prevFOV_42;
		float L_193 = __this->___m_FrameDamping_31;
		float L_194 = ___deltaTime1;
		NullCheck(L_190);
		float L_195;
		L_195 = CinemachineVirtualCameraBase_DetachedLookAtTargetDamp_mFB6FAA90EB2A5263D19E3D91C30C072C972E849E(L_190, ((float)il2cpp_codegen_subtract(L_191, L_192)), L_193, L_194, NULL);
		V_30 = ((float)il2cpp_codegen_add(L_189, L_195));
	}

IL_0465:
	{
		float L_196 = V_30;
		__this->___m_prevFOV_42 = L_196;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_197 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_198 = L_197->___Lens_0;
		V_31 = L_198;
		float L_199 = V_30;
		(&V_31)->___FieldOfView_1 = L_199;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_200 = ___curState0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_201 = V_31;
		L_200->___Lens_0 = L_201;
	}

IL_0487:
	{
	}

IL_0488:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_202 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_203 = V_6;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_204 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_205 = L_204->___ReferenceUp_1;
		float L_206 = ___deltaTime1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_207;
		L_207 = VirtualFuncInvoker3< Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, float >::Invoke(14, __this, L_203, L_205, L_206);
		L_202->___ReferenceLookAt_2 = L_207;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_208 = ___curState0;
		float L_209 = ___deltaTime1;
		CinemachineComposer_MutateCameraState_m50DD037C33A1BF4956C47F8ADA6F6CBADDDA4B3A(__this, L_208, L_209, NULL);
	}

IL_04a6:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineGroupComposer_GetTargetHeight_mE81E9435860ADF221E7DD164A4ADF411AB4C740A (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___boundsSize0, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 V_2;
	memset((&V_2), 0, sizeof(V_2));
	float V_3 = 0.0f;
	{
		int32_t L_0 = __this->___m_FramingMode_30;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_001e;
			}
			case 1:
			{
				goto IL_0045;
			}
			case 2:
			{
				goto IL_0058;
			}
		}
	}
	{
		goto IL_0058;
	}

IL_001e:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_3 = ___boundsSize0;
		float L_4 = L_3.___x_0;
		float L_5;
		L_5 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((9.99999975E-05f), L_4, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_6;
		L_6 = CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2(__this, NULL);
		V_2 = L_6;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_7 = (&(&V_2)->___Lens_0);
		float L_8;
		L_8 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555(L_7, NULL);
		V_3 = ((float)(L_5/L_8));
		goto IL_0094;
	}

IL_0045:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_9 = ___boundsSize0;
		float L_10 = L_9.___y_1;
		float L_11;
		L_11 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((9.99999975E-05f), L_10, NULL);
		V_3 = L_11;
		goto IL_0094;
	}

IL_0058:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_12 = ___boundsSize0;
		float L_13 = L_12.___x_0;
		float L_14;
		L_14 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((9.99999975E-05f), L_13, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_15;
		L_15 = CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2(__this, NULL);
		V_2 = L_15;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_16 = (&(&V_2)->___Lens_0);
		float L_17;
		L_17 = LensSettings_get_Aspect_m47C88E8BFBCFA1394AF0259DF528CCC4786A2555(L_16, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_18 = ___boundsSize0;
		float L_19 = L_18.___y_1;
		float L_20;
		L_20 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((9.99999975E-05f), L_19, NULL);
		float L_21;
		L_21 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(((float)(L_14/L_17)), L_20, NULL);
		V_3 = L_21;
		goto IL_0094;
	}

IL_0094:
	{
		float L_22 = V_3;
		return L_22;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineGroupComposer_GetScreenSpaceGroupBoundingBox_m567C86F8FB8092CF4BABDE712030C3E1772A22A9 (RuntimeObject* ___group0, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___observer1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___newFwd2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_3;
	memset((&V_3), 0, sizeof(V_3));
	float V_4 = 0.0f;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 V_6;
	memset((&V_6), 0, sizeof(V_6));
	{
		RuntimeObject* L_0 = ___group0;
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_1 = ___observer1;
		NullCheck(L_0);
		InterfaceActionInvoker4< Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* >::Invoke(5, ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B_il2cpp_TypeInfo_var, L_0, L_1, (&V_0), (&V_1), (&V_2));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = V_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_3 = V_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4;
		L_4 = Vector2_op_Addition_m704B5B98EAFE885978381E21B7F89D9DF83C2A60_inline(L_2, L_3, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5;
		L_5 = Vector2_op_Division_m69F64D545E3C023BE9927397572349A569141EBA_inline(L_4, (2.0f), NULL);
		V_3 = L_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_6 = ___newFwd2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_7;
		L_7 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_8 = V_3;
		float L_9 = L_8.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10 = V_3;
		float L_11 = L_10.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_12), ((-L_9)), L_11, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13;
		L_13 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_14;
		L_14 = UnityQuaternionExtensions_ApplyCameraRotation_m75753B356C2E3BC79192192C8C2FC1F512643506(L_7, L_12, L_13, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15;
		L_15 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16;
		L_16 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_14, L_15, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_6 = L_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_17 = ___newFwd2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_18 = ___newFwd2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_18);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20;
		L_20 = Matrix4x4_MultiplyVector_mFD12F86A473E90BBB0002149ABA3917B2A518937((&___observer1), L_19, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_17 = L_20;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_21 = V_2;
		float L_22 = L_21.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_23 = V_2;
		float L_24 = L_23.___x_0;
		V_4 = ((float)il2cpp_codegen_add(L_22, L_24));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_25 = V_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_26 = V_3;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_27;
		L_27 = Vector2_op_Subtraction_m664419831773D5BBF06D9DE4E515F6409B2F92B8_inline(L_25, L_26, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_28;
		memset((&L_28), 0, sizeof(L_28));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_28), (89.5f), (89.5f), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_29;
		L_29 = Vector2_Min_mAB64CD54A495856162FC5753B6C6B572AA4BEA1D_inline(L_27, L_28, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_30;
		L_30 = Vector2_op_Multiply_m4EEB2FF3F4830390A53CE9B6076FB31801D65EED_inline(L_29, (0.0174532924f), NULL);
		V_5 = L_30;
		float L_31 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		memset((&L_32), 0, sizeof(L_32));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_32), (0.0f), (0.0f), ((float)(L_31/(2.0f))), NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_33 = V_5;
		float L_34 = L_33.___y_1;
		float L_35;
		L_35 = tanf(L_34);
		float L_36 = V_4;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_37 = V_5;
		float L_38 = L_37.___x_0;
		float L_39;
		L_39 = tanf(L_38);
		float L_40 = V_4;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_41 = V_2;
		float L_42 = L_41.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_43 = V_2;
		float L_44 = L_43.___x_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45;
		memset((&L_45), 0, sizeof(L_45));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_45), ((float)il2cpp_codegen_multiply(L_35, L_36)), ((float)il2cpp_codegen_multiply(L_39, L_40)), ((float)il2cpp_codegen_subtract(L_42, L_44)), NULL);
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_46;
		memset((&L_46), 0, sizeof(L_46));
		Bounds__ctor_mAF7B238B9FBF90C495E5D7951760085A93119C5A_inline((&L_46), L_32, L_45, NULL);
		V_6 = L_46;
		goto IL_00eb;
	}

IL_00eb:
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineGroupComposer__ctor_m971E14E2A389C00A5DB8E27648BC6143D96CDFAC (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_GroupFramingSize_29 = (0.800000012f);
		__this->___m_FramingMode_30 = 2;
		__this->___m_FrameDamping_31 = (2.0f);
		__this->___m_AdjustmentMode_32 = 0;
		__this->___m_MaxDollyIn_33 = (5000.0f);
		__this->___m_MaxDollyOut_34 = (5000.0f);
		__this->___m_MinimumDistance_35 = (1.0f);
		__this->___m_MaximumDistance_36 = (5000.0f);
		__this->___m_MinimumFOV_37 = (3.0f);
		__this->___m_MaximumFOV_38 = (60.0f);
		__this->___m_MinimumOrthoSize_39 = (1.0f);
		__this->___m_MaximumOrthoSize_40 = (5000.0f);
		CinemachineComposer__ctor_m90D1EE7F962886981F03D129849E4214A106DCD8(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineHardLockToTarget_get_IsValid_m3283683207CBE04A66BDE3CC3731D04AD4E11D7F (CinemachineHardLockToTarget_tA87D10A864809C5E690916F194DBD61F8E64380A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineHardLockToTarget_get_Stage_m67CC2097CE1F227F1A4080108D68E8C9D6E21896 (CinemachineHardLockToTarget_tA87D10A864809C5E690916F194DBD61F8E64380A* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineHardLockToTarget_GetMaxDampTime_mCC6C1B1C21332DD63B0CC7F435280080B0B76B70 (CinemachineHardLockToTarget_tA87D10A864809C5E690916F194DBD61F8E64380A* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_Damping_7;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineHardLockToTarget_MutateCameraState_m511263D61277FC8FF50CEE06B367F0B75CCA8D52 (CinemachineHardLockToTarget_tA87D10A864809C5E690916F194DBD61F8E64380A* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	bool V_2 = false;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_1 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_0010;
		}
	}
	{
		goto IL_005e;
	}

IL_0010:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		V_0 = L_2;
		float L_3 = ___deltaTime1;
		V_2 = (bool)((((int32_t)((!(((float)L_3) >= ((float)(0.0f))))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0050;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = __this->___m_PreviousTargetPosition_8;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_6;
		L_6 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = __this->___m_PreviousTargetPosition_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		L_9 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_7, L_8, NULL);
		float L_10 = __this->___m_Damping_7;
		float L_11 = ___deltaTime1;
		NullCheck(L_6);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m12B68094CE823031220DD1E2EAB52AAD0AC25412(L_6, L_9, L_10, L_11, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13;
		L_13 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_5, L_12, NULL);
		V_0 = L_13;
	}

IL_0050:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = V_0;
		__this->___m_PreviousTargetPosition_8 = L_14;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_15 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = V_0;
		L_15->___RawPosition_4 = L_16;
	}

IL_005e:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineHardLockToTarget__ctor_m905CAEB127D9D192FEAAA8F014F2C096F450F4C8 (CinemachineHardLockToTarget_tA87D10A864809C5E690916F194DBD61F8E64380A* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_Damping_7 = (0.0f);
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineHardLookAt_get_IsValid_m2281D65323EDD1BFA20E167912C262447A29D901 (CinemachineHardLookAt_tF3F83D120480604E6173E3907DAA85CDEBB0FC8E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_LookAtTarget_m7E6CF239A3905B1130A5C38B0E5668EB32D1BB04(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineHardLookAt_get_Stage_mC4BD7DB16560529621EEAEFFA65006A030832907 (CinemachineHardLookAt_tF3F83D120480604E6173E3907DAA85CDEBB0FC8E* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 1;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineHardLookAt_MutateCameraState_mE2A0FF4E4AE1F96D12E53368316B7F14ACD71E2B (CinemachineHardLookAt_tF3F83D120480604E6173E3907DAA85CDEBB0FC8E* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	bool V_3 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		if (!L_0)
		{
			goto IL_0011;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_1 = ___curState0;
		bool L_2;
		L_2 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC(L_1, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0012;
	}

IL_0011:
	{
		G_B3_0 = 0;
	}

IL_0012:
	{
		V_0 = (bool)G_B3_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0089;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_4 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = L_4->___ReferenceLookAt_2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_6 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089(L_6, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_5, L_7, NULL);
		V_1 = L_8;
		float L_9;
		L_9 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_1), NULL);
		V_2 = (bool)((((float)L_9) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_10 = V_2;
		if (!L_10)
		{
			goto IL_0088;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = Vector3_get_normalized_m736BBF65D5CDA7A18414370D15B4DFCC1E466F07_inline((&V_1), NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_12 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = L_12->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14;
		L_14 = Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline(L_11, L_13, NULL);
		V_4 = L_14;
		float L_15;
		L_15 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_4), NULL);
		V_3 = (bool)((((float)L_15) < ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_16 = V_3;
		if (!L_16)
		{
			goto IL_0075;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_17 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20;
		L_20 = Quaternion_FromToRotation_m041093DBB23CB3641118310881D6B7746E3B8418(L_18, L_19, NULL);
		L_17->___RawOrientation_5 = L_20;
		goto IL_0087;
	}

IL_0075:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_21 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = V_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_23 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = L_23->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_25;
		L_25 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_22, L_24, NULL);
		L_21->___RawOrientation_5 = L_25;
	}

IL_0087:
	{
	}

IL_0088:
	{
	}

IL_0089:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineHardLookAt__ctor_m673A99093725D7083A4C47B1C2328BB05647B70B (CinemachineHardLookAt_tF3F83D120480604E6173E3907DAA85CDEBB0FC8E* __this, const RuntimeMethod* method) 
{
	{
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer_OnValidate_m3782FFE204D5E142643EC56897EE4EDD4CD91100 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	float V_2 = 0.0f;
	bool V_3 = false;
	int32_t G_B4_0 = 0;
	{
		float L_0 = __this->___m_LegacyRadius_26;
		if ((((float)L_0) == ((float)((std::numeric_limits<float>::max)()))))
		{
			goto IL_002d;
		}
	}
	{
		float L_1 = __this->___m_LegacyHeightOffset_27;
		if ((((float)L_1) == ((float)((std::numeric_limits<float>::max)()))))
		{
			goto IL_002d;
		}
	}
	{
		float L_2 = __this->___m_LegacyHeadingBias_28;
		G_B4_0 = ((((int32_t)((((float)L_2) == ((float)((std::numeric_limits<float>::max)())))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_002e;
	}

IL_002d:
	{
		G_B4_0 = 0;
	}

IL_002e:
	{
		V_0 = (bool)G_B4_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_00f4;
		}
	}
	{
		float L_4 = __this->___m_LegacyHeightOffset_27;
		float L_5 = __this->___m_LegacyRadius_26;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_6), (0.0f), L_4, ((-L_5)), NULL);
		((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_FollowOffset_8 = L_6;
		float L_7 = ((std::numeric_limits<float>::max)());
		V_2 = L_7;
		__this->___m_LegacyRadius_26 = L_7;
		float L_8 = V_2;
		__this->___m_LegacyHeightOffset_27 = L_8;
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_9 = (&__this->___m_Heading_23);
		float L_10 = __this->___m_LegacyHeadingBias_28;
		L_9->___m_Bias_2 = L_10;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_11 = (&__this->___m_XAxis_25);
		float* L_12 = (&L_11->___m_MaxSpeed_2);
		float* L_13 = L_12;
		float L_14 = *((float*)L_13);
		*((float*)L_13) = (float)((float)(L_14/(10.0f)));
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_15 = (&__this->___m_XAxis_25);
		float* L_16 = (&L_15->___m_AccelTime_3);
		float* L_17 = L_16;
		float L_18 = *((float*)L_17);
		*((float*)L_17) = (float)((float)(L_18/(10.0f)));
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_19 = (&__this->___m_XAxis_25);
		float* L_20 = (&L_19->___m_DecelTime_4);
		float* L_21 = L_20;
		float L_22 = *((float*)L_21);
		*((float*)L_21) = (float)((float)(L_22/(10.0f)));
		__this->___m_LegacyHeadingBias_28 = ((std::numeric_limits<float>::max)());
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_23 = (&__this->___m_Heading_23);
		int32_t L_24 = L_23->___m_Definition_0;
		V_1 = L_24;
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_25 = (&__this->___m_RecenterToTargetHeading_24);
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_26 = (&__this->___m_Heading_23);
		int32_t* L_27 = (&L_26->___m_VelocityFilterStrength_1);
		bool L_28;
		L_28 = Recentering_LegacyUpgrade_m17A3ED97851377053B2385331ED85BE3DA3D4D7D(L_25, (&V_1), L_27, NULL);
		V_3 = L_28;
		bool L_29 = V_3;
		if (!L_29)
		{
			goto IL_00f3;
		}
	}
	{
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_30 = (&__this->___m_Heading_23);
		int32_t L_31 = V_1;
		L_30->___m_Definition_0 = L_31;
	}

IL_00f3:
	{
	}

IL_00f4:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_32 = (&__this->___m_XAxis_25);
		AxisState_Validate_m1245D61F6D9A031C27F75F4B49E78A52AA91BDE5(L_32, NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_33 = (&__this->___m_RecenterToTargetHeading_24);
		Recentering_Validate_m3F5EE15AE52BB8FF2B69E3963851CEE2600340D3(L_33, NULL);
		CinemachineTransposer_OnValidate_mFC57EE74F157499D7CAC4D30CC1D7A04ED6FC33E(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineOrbitalTransposer_UpdateHeading_m237761CC9CA559C83FA849BA7FB15661911A953A (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, float ___deltaTime0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, AxisState_t6996FE8143104E02683986C908C18B0F62595736* ___axis2, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = ___deltaTime0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___up1;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_2 = ___axis2;
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_3 = (&__this->___m_RecenterToTargetHeading_24);
		float L_4;
		L_4 = CinemachineOrbitalTransposer_UpdateHeading_m8718BA600DA5134C0E38C8646DBC2506AB4472AB(__this, L_0, L_1, L_2, L_3, (bool)1, NULL);
		V_0 = L_4;
		goto IL_0014;
	}

IL_0014:
	{
		float L_5 = V_0;
		return L_5;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineOrbitalTransposer_UpdateHeading_m8718BA600DA5134C0E38C8646DBC2506AB4472AB (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, float ___deltaTime0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, AxisState_t6996FE8143104E02683986C908C18B0F62595736* ___axis2, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* ___recentering3, bool ___isLive4, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	float V_5 = 0.0f;
	float V_6 = 0.0f;
	int32_t G_B6_0 = 0;
	{
		int32_t L_0 = ((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_BindingMode_7;
		V_1 = (bool)((((int32_t)L_0) == ((int32_t)5))? 1 : 0);
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_0026;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_2 = ___axis2;
		L_2->___m_MinValue_8 = (-180.0f);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_3 = ___axis2;
		L_3->___m_MaxValue_9 = (180.0f);
	}

IL_0026:
	{
		float L_4 = ___deltaTime0;
		if ((((float)L_4) < ((float)(0.0f))))
		{
			goto IL_0042;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_5;
		L_5 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_5);
		bool L_6;
		L_6 = VirtualFuncInvoker0< bool >::Invoke(31, L_5);
		if (!L_6)
		{
			goto IL_0042;
		}
	}
	{
		bool L_7 = ___isLive4;
		G_B6_0 = ((((int32_t)L_7) == ((int32_t)0))? 1 : 0);
		goto IL_0043;
	}

IL_0042:
	{
		G_B6_0 = 1;
	}

IL_0043:
	{
		V_2 = (bool)G_B6_0;
		bool L_8 = V_2;
		if (!L_8)
		{
			goto IL_005a;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_9 = ___axis2;
		AxisState_Reset_m329065EBC9963460CD7733144EC5F47D107967C9(L_9, NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_10 = ___recentering3;
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(L_10, NULL);
		goto IL_006d;
	}

IL_005a:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_11 = ___axis2;
		float L_12 = ___deltaTime0;
		bool L_13;
		L_13 = AxisState_Update_mE86F039B78105160E5C13153B456E3A988AF28B4(L_11, L_12, NULL);
		V_3 = L_13;
		bool L_14 = V_3;
		if (!L_14)
		{
			goto IL_006d;
		}
	}
	{
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_15 = ___recentering3;
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(L_15, NULL);
	}

IL_006d:
	{
		int32_t L_16 = ((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_BindingMode_7;
		V_4 = (bool)((((int32_t)L_16) == ((int32_t)5))? 1 : 0);
		bool L_17 = V_4;
		if (!L_17)
		{
			goto IL_0096;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_18 = ___axis2;
		float L_19 = L_18->___Value_0;
		V_5 = L_19;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_20 = ___axis2;
		L_20->___Value_0 = (0.0f);
		float L_21 = V_5;
		V_6 = L_21;
		goto IL_00bf;
	}

IL_0096:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_22 = ___axis2;
		float L_23 = L_22->___Value_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_25;
		L_25 = CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE(__this, L_24, NULL);
		float L_26;
		L_26 = CinemachineOrbitalTransposer_GetTargetHeading_m7CDCBC39F6AF29C82492EC52B529A3936CFD6219(__this, L_23, L_25, NULL);
		V_0 = L_26;
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_27 = ___recentering3;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_28 = ___axis2;
		float L_29 = ___deltaTime0;
		float L_30 = V_0;
		Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A(L_27, L_28, L_29, L_30, NULL);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_31 = ___axis2;
		float L_32 = L_31->___Value_0;
		V_6 = L_32;
		goto IL_00bf;
	}

IL_00bf:
	{
		float L_33 = V_6;
		return L_33;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer_OnEnable_m6C7E95C1EAE2BACB03E324BBE303DBFFE14CDAF6 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_PreviousTarget_34 = (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_PreviousTarget_34), (void*)(Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_LastTargetPosition_31 = L_0;
		CinemachineOrbitalTransposer_UpdateInputAxisProvider_m2FA2059A198A20A0730E6BCAC2D572005513971D(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer_UpdateInputAxisProvider_m2FA2059A198A20A0730E6BCAC2D572005513971D (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	RuntimeObject* V_1 = NULL;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_0 = (&__this->___m_XAxis_25);
		AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85(L_0, 0, (RuntimeObject*)NULL, NULL);
		bool L_1 = __this->___m_HeadingIsSlave_29;
		if (L_1)
		{
			goto IL_0025;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_2;
		L_2 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_2, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_3));
		goto IL_0026;
	}

IL_0025:
	{
		G_B3_0 = 0;
	}

IL_0026:
	{
		V_0 = (bool)G_B3_0;
		bool L_4 = V_0;
		if (!L_4)
		{
			goto IL_004e;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_5;
		L_5 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_5);
		RuntimeObject* L_6;
		L_6 = CinemachineVirtualCameraBase_GetInputAxisProvider_mC735C4764E6CB8469D115142D842729C95D9C39E(L_5, NULL);
		V_1 = L_6;
		RuntimeObject* L_7 = V_1;
		V_2 = (bool)((!(((RuntimeObject*)(RuntimeObject*)L_7) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_8 = V_2;
		if (!L_8)
		{
			goto IL_004d;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_9 = (&__this->___m_XAxis_25);
		RuntimeObject* L_10 = V_1;
		AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85(L_9, 0, L_10, NULL);
	}

IL_004d:
	{
	}

IL_004e:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer_OnTargetObjectWarped_mE2BFEBB6D56EB26F27F01CBF307D1EBF4B060B5E (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_0 = ___target0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___positionDelta1;
		CinemachineTransposer_OnTargetObjectWarped_m9E0D9DA06D752FF81CB08EDE999759FF47DEF741(__this, L_0, L_1, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2 = ___target0;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3;
		L_3 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_2, L_3, NULL);
		V_0 = L_4;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_0040;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = __this->___m_LastTargetPosition_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___positionDelta1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_6, L_7, NULL);
		__this->___m_LastTargetPosition_31 = L_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = __this->___m_LastCameraPosition_35;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___positionDelta1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_9, L_10, NULL);
		__this->___m_LastCameraPosition_35 = L_11;
	}

IL_0040:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer_ForceCameraPosition_m58355A8C31130A765A8D0B8E03CFFAC74A375195 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rot1, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___pos0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = ___rot1;
		CinemachineTransposer_ForceCameraPosition_m8E10E86DEDAF9FE53266FDB72F53E6D2083965B4(__this, L_0, L_1, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___pos0;
		__this->___m_LastCameraPosition_35 = L_2;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_3 = (&__this->___m_XAxis_25);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___pos0;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_5;
		L_5 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_5);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_6;
		L_6 = VirtualFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(25, L_5);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = L_6.___ReferenceUp_1;
		float L_8;
		L_8 = CinemachineOrbitalTransposer_GetAxisClosestValue_m12E53A2B675F5EF62F5FC89AD55A3F398C005AFF(__this, L_4, L_7, NULL);
		L_3->___Value_0 = L_8;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineOrbitalTransposer_OnTransitionFromCamera_m20B42EEE01538F55F944E042459D5FC87B6CC204 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, RuntimeObject* ___fromCam0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp1, float ___deltaTime2, TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA* ___transitionParams3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	int32_t G_B5_0 = 0;
	{
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_0 = (&__this->___m_RecenterToTargetHeading_24);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_1 = (&__this->___m_XAxis_25);
		Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A(L_0, L_1, (-1.0f), (0.0f), NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_2 = (&__this->___m_RecenterToTargetHeading_24);
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(L_2, NULL);
		RuntimeObject* L_3 = ___fromCam0;
		if (!L_3)
		{
			goto IL_0053;
		}
	}
	{
		int32_t L_4 = ((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_BindingMode_7;
		if ((((int32_t)L_4) == ((int32_t)5)))
		{
			goto IL_0053;
		}
	}
	{
		TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA* L_5 = ___transitionParams3;
		bool L_6 = L_5->___m_InheritPosition_1;
		if (!L_6)
		{
			goto IL_0053;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* L_7;
		L_7 = CinemachineCore_get_Instance_m761793890717527703D6C8BB3AC64FEC93745A85(NULL);
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_8;
		L_8 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_7);
		bool L_9;
		L_9 = CinemachineCore_IsLiveInBlend_mFD1402FFF3B5D0CD0EC90914F89672724F49F778(L_7, L_8, NULL);
		G_B5_0 = ((((int32_t)L_9) == ((int32_t)0))? 1 : 0);
		goto IL_0054;
	}

IL_0053:
	{
		G_B5_0 = 0;
	}

IL_0054:
	{
		V_0 = (bool)G_B5_0;
		bool L_10 = V_0;
		if (!L_10)
		{
			goto IL_007a;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_11 = (&__this->___m_XAxis_25);
		RuntimeObject* L_12 = ___fromCam0;
		NullCheck(L_12);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_13;
		L_13 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_12);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = L_13.___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = ___worldUp1;
		float L_16;
		L_16 = CinemachineOrbitalTransposer_GetAxisClosestValue_m12E53A2B675F5EF62F5FC89AD55A3F398C005AFF(__this, L_14, L_15, NULL);
		L_11->___Value_0 = L_16;
		V_1 = (bool)1;
		goto IL_007e;
	}

IL_007a:
	{
		V_1 = (bool)0;
		goto IL_007e;
	}

IL_007e:
	{
		bool L_17 = V_1;
		return L_17;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineOrbitalTransposer_GetAxisClosestValue_m12E53A2B675F5EF62F5FC89AD55A3F398C005AFF (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___cameraPos0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	float V_3 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_7;
	memset((&V_7), 0, sizeof(V_7));
	bool V_8 = false;
	float V_9 = 0.0f;
	int32_t G_B3_0 = 0;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1;
		L_1 = CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE(__this, L_0, NULL);
		V_0 = L_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4;
		L_4 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_2, L_3, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_4, L_5, NULL);
		V_1 = L_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = V_1;
		bool L_8;
		L_8 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_7, NULL);
		if (L_8)
		{
			goto IL_0031;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_9;
		L_9 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_10;
		L_10 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_9, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_10));
		goto IL_0032;
	}

IL_0031:
	{
		G_B3_0 = 0;
	}

IL_0032:
	{
		V_2 = (bool)G_B3_0;
		bool L_11 = V_2;
		if (!L_11)
		{
			goto IL_00ba;
		}
	}
	{
		V_3 = (0.0f);
		int32_t L_12 = ((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_BindingMode_7;
		V_8 = (bool)((((int32_t)((((int32_t)L_12) == ((int32_t)5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_13 = V_8;
		if (!L_13)
		{
			goto IL_0060;
		}
	}
	{
		float L_14 = V_3;
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_15 = (&__this->___m_Heading_23);
		float L_16 = L_15->___m_Bias_2;
		V_3 = ((float)il2cpp_codegen_add(L_14, L_16));
	}

IL_0060:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_17 = V_0;
		float L_18 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20;
		L_20 = Quaternion_AngleAxis_m01A869DC10F976FAF493B66F15D6D6977BB61DA8(L_18, L_19, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_21;
		L_21 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_17, L_20, NULL);
		V_0 = L_21;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22;
		L_22 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		V_4 = L_22;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = V_4;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_24 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26;
		L_26 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_24, L_25, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27;
		L_27 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_23, L_26, NULL);
		V_5 = L_27;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		L_30 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_28, L_29, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_30, L_31, NULL);
		V_6 = L_32;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33 = ___cameraPos0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35;
		L_35 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_33, L_34, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_37;
		L_37 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_35, L_36, NULL);
		V_7 = L_37;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40 = ___up1;
		float L_41;
		L_41 = Vector3_SignedAngle_mD30E71B2F64983C2C4D86F17E7023BAA84CE50BE_inline(L_38, L_39, L_40, NULL);
		V_9 = L_41;
		goto IL_00c4;
	}

IL_00ba:
	{
		float L_42 = __this->___m_LastHeading_36;
		V_9 = L_42;
		goto IL_00c4;
	}

IL_00c4:
	{
		float L_43 = V_9;
		return L_43;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer_MutateCameraState_m1AB5EA636D64DC31FBC22AA18878307B645514C1 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Component_GetComponent_TisRigidbody_t268697F5A994213ED97393309870968BC1C7393C_m4B5CAD64B52D153BEA96432633CA9A45FA523DD8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	bool V_1 = false;
	bool V_2 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_7;
	memset((&V_7), 0, sizeof(V_7));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_8;
	memset((&V_8), 0, sizeof(V_8));
	bool V_9 = false;
	bool V_10 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_11;
	memset((&V_11), 0, sizeof(V_11));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_12;
	memset((&V_12), 0, sizeof(V_12));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_13;
	memset((&V_13), 0, sizeof(V_13));
	bool V_14 = false;
	bool V_15 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_16;
	memset((&V_16), 0, sizeof(V_16));
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B3_0 = NULL;
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B2_0 = NULL;
	Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* G_B4_0 = NULL;
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B4_1 = NULL;
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B6_0 = NULL;
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B5_0 = NULL;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B7_0;
	memset((&G_B7_0), 0, sizeof(G_B7_0));
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B7_1 = NULL;
	int32_t G_B14_0 = 0;
	int32_t G_B20_0 = 0;
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_0 = ___curState0;
		float L_1 = ___deltaTime1;
		CinemachineTransposer_InitPrevFrameStateInfo_m5640D1D85D4260B279D374618B009740EF6EC260(__this, L_0, L_1, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2;
		L_2 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3 = __this->___m_PreviousTarget_34;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_2, L_3, NULL);
		V_1 = L_4;
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_007c;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_6;
		L_6 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		__this->___m_PreviousTarget_34 = L_6;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_PreviousTarget_34), (void*)L_6);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_7 = __this->___m_PreviousTarget_34;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_8;
		L_8 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_7, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B2_0 = __this;
		if (L_8)
		{
			G_B3_0 = __this;
			goto IL_0048;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_9 = __this->___m_PreviousTarget_34;
		NullCheck(L_9);
		Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* L_10;
		L_10 = Component_GetComponent_TisRigidbody_t268697F5A994213ED97393309870968BC1C7393C_m4B5CAD64B52D153BEA96432633CA9A45FA523DD8(L_9, Component_GetComponent_TisRigidbody_t268697F5A994213ED97393309870968BC1C7393C_m4B5CAD64B52D153BEA96432633CA9A45FA523DD8_RuntimeMethod_var);
		G_B4_0 = L_10;
		G_B4_1 = G_B2_0;
		goto IL_0049;
	}

IL_0048:
	{
		G_B4_0 = ((Rigidbody_t268697F5A994213ED97393309870968BC1C7393C*)(NULL));
		G_B4_1 = G_B3_0;
	}

IL_0049:
	{
		NullCheck(G_B4_1);
		G_B4_1->___m_TargetRigidBody_33 = G_B4_0;
		Il2CppCodeGenWriteBarrier((void**)(&G_B4_1->___m_TargetRigidBody_33), (void*)G_B4_0);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_11 = __this->___m_PreviousTarget_34;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_12;
		L_12 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_11, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B5_0 = __this;
		if (L_12)
		{
			G_B6_0 = __this;
			goto IL_006a;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_13 = __this->___m_PreviousTarget_34;
		NullCheck(L_13);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14;
		L_14 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_13, NULL);
		G_B7_0 = L_14;
		G_B7_1 = G_B5_0;
		goto IL_006f;
	}

IL_006a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15;
		L_15 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		G_B7_0 = L_15;
		G_B7_1 = G_B6_0;
	}

IL_006f:
	{
		NullCheck(G_B7_1);
		G_B7_1->___m_LastTargetPosition_31 = G_B7_0;
		__this->___mHeadingTracker_32 = (HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___mHeadingTracker_32), (void*)(HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA*)NULL);
	}

IL_007c:
	{
		UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* L_16 = __this->___HeadingUpdater_30;
		float L_17 = ___deltaTime1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_18 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = L_18->___ReferenceUp_1;
		NullCheck(L_16);
		float L_20;
		L_20 = UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_inline(L_16, __this, L_17, L_19, NULL);
		__this->___m_LastHeading_36 = L_20;
		float L_21 = __this->___m_LastHeading_36;
		V_0 = L_21;
		bool L_22;
		L_22 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_2 = L_22;
		bool L_23 = V_2;
		if (!L_23)
		{
			goto IL_0210;
		}
	}
	{
		int32_t L_24 = ((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_BindingMode_7;
		V_9 = (bool)((((int32_t)((((int32_t)L_24) == ((int32_t)5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_25 = V_9;
		if (!L_25)
		{
			goto IL_00ca;
		}
	}
	{
		float L_26 = V_0;
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_27 = (&__this->___m_Heading_23);
		float L_28 = L_27->___m_Bias_2;
		V_0 = ((float)il2cpp_codegen_add(L_26, L_28));
	}

IL_00ca:
	{
		float L_29 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		L_30 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_31;
		L_31 = Quaternion_AngleAxis_m01A869DC10F976FAF493B66F15D6D6977BB61DA8(L_29, L_30, NULL);
		V_3 = L_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25(__this, NULL);
		V_4 = L_32;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_33 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35;
		L_35 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_33, L_34, NULL);
		V_5 = L_35;
		float L_36 = ___deltaTime1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_37 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38 = L_37->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39 = V_5;
		CinemachineTransposer_TrackTarget_m509CF4F1D4319A21D55CEAA20802DA09B46E2AC5(__this, L_36, L_38, L_39, (&V_6), (&V_7), NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_40 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_41 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42;
		L_42 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_40, L_41, NULL);
		V_5 = L_42;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_43 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_44 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45;
		L_45 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46;
		L_46 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_44, L_45, NULL);
		L_43->___ReferenceUp_1 = L_46;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47;
		L_47 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		V_8 = L_47;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_48 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50 = V_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_51 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_52 = L_51->___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_53;
		L_53 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_54;
		L_54 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_52, L_53, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_55 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_56 = L_55->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_57 = V_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_58;
		L_58 = CinemachineTransposer_GetOffsetForMinimumTargetDistance_m3AF6061743759E9C4BF3280862AA8841449A3172(__this, L_49, L_50, L_54, L_56, L_57, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_59;
		L_59 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_48, L_58, NULL);
		V_6 = L_59;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_60 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_61 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_62 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_63;
		L_63 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_61, L_62, NULL);
		L_60->___RawPosition_4 = L_63;
		float L_64 = ___deltaTime1;
		if ((!(((float)L_64) >= ((float)(0.0f)))))
		{
			goto IL_0170;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_65;
		L_65 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_65);
		bool L_66;
		L_66 = VirtualFuncInvoker0< bool >::Invoke(31, L_65);
		G_B14_0 = ((int32_t)(L_66));
		goto IL_0171;
	}

IL_0170:
	{
		G_B14_0 = 0;
	}

IL_0171:
	{
		V_10 = (bool)G_B14_0;
		bool L_67 = V_10;
		if (!L_67)
		{
			goto IL_01fb;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_68 = V_8;
		V_11 = L_68;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_69;
		L_69 = CinemachineComponentBase_get_LookAtTarget_m7E6CF239A3905B1130A5C38B0E5668EB32D1BB04(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_70;
		L_70 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_69, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_14 = L_70;
		bool L_71 = V_14;
		if (!L_71)
		{
			goto IL_0199;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_72;
		L_72 = CinemachineComponentBase_get_LookAtTargetPosition_m79CE45A7F4D4A82BC47B01434F5EB35C91DC99A8(__this, NULL);
		V_11 = L_72;
	}

IL_0199:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_73 = __this->___m_LastCameraPosition_35;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_74 = V_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_75;
		L_75 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_73, L_74, NULL);
		V_12 = L_75;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_76 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_77 = L_76->___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_78 = V_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79;
		L_79 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_77, L_78, NULL);
		V_13 = L_79;
		float L_80;
		L_80 = Vector3_get_sqrMagnitude_m43C27DEC47C4811FB30AB474FF2131A963B66FC8_inline((&V_12), NULL);
		if ((!(((float)L_80) > ((float)(0.00999999978f)))))
		{
			goto IL_01d5;
		}
	}
	{
		float L_81;
		L_81 = Vector3_get_sqrMagnitude_m43C27DEC47C4811FB30AB474FF2131A963B66FC8_inline((&V_13), NULL);
		G_B20_0 = ((((float)L_81) > ((float)(0.00999999978f)))? 1 : 0);
		goto IL_01d6;
	}

IL_01d5:
	{
		G_B20_0 = 0;
	}

IL_01d6:
	{
		V_15 = (bool)G_B20_0;
		bool L_82 = V_15;
		if (!L_82)
		{
			goto IL_01fa;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_83 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_84 = V_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_85 = V_13;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_86 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_87 = L_86->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_88;
		L_88 = UnityVectorExtensions_SafeFromToRotation_mD10BFD5052B69EE3D1DE2FE9B74181BD797ACC03(L_84, L_85, L_87, NULL);
		V_16 = L_88;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_89;
		L_89 = Quaternion_get_eulerAngles_m2DB5158B5C3A71FD60FC8A6EE43D3AAA1CFED122_inline((&V_16), NULL);
		L_83->___PositionDampingBypass_6 = L_89;
	}

IL_01fa:
	{
	}

IL_01fb:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_90 = V_8;
		__this->___m_LastTargetPosition_31 = L_90;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_91 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_92 = L_91->___RawPosition_4;
		__this->___m_LastCameraPosition_35 = L_92;
	}

IL_0210:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineOrbitalTransposer_GetTargetCameraPosition_m67992ACDFA01B5C8150D7AC9488086FABF473652 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	bool V_3 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	bool V_5 = false;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_3 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_3;
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_4 = L_2;
		goto IL_0077;
	}

IL_0017:
	{
		float L_3 = __this->___m_LastHeading_36;
		V_0 = L_3;
		int32_t L_4 = ((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_BindingMode_7;
		V_5 = (bool)((((int32_t)((((int32_t)L_4) == ((int32_t)5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_5 = V_5;
		if (!L_5)
		{
			goto IL_003e;
		}
	}
	{
		float L_6 = V_0;
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_7 = (&__this->___m_Heading_23);
		float L_8 = L_7->___m_Bias_2;
		V_0 = ((float)il2cpp_codegen_add(L_6, L_8));
	}

IL_003e:
	{
		float L_9 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10;
		L_10 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_11;
		L_11 = Quaternion_AngleAxis_m01A869DC10F976FAF493B66F15D6D6977BB61DA8(L_9, L_10, NULL);
		V_1 = L_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = ___worldUp0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_13;
		L_13 = CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE(__this, L_12, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_14 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_15;
		L_15 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_13, L_14, NULL);
		V_1 = L_15;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_16 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		L_17 = CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_16, L_17, NULL);
		V_2 = L_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = __this->___m_LastTargetPosition_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21;
		L_21 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_19, L_20, NULL);
		V_2 = L_21;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = V_2;
		V_4 = L_22;
		goto IL_0077;
	}

IL_0077:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = V_4;
		return L_23;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineOrbitalTransposer_get_RequiresUserInput_m4B493CC95DFD622F1389A7C11ABD68041B216448 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, const RuntimeMethod* method) 
{
	{
		return (bool)1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineOrbitalTransposer_GetTargetHeading_m7CDCBC39F6AF29C82492EC52B529A3936CFD6219 (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, float ___currentHeading0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetOrientation1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	bool V_3 = false;
	float V_4 = 0.0f;
	bool V_5 = false;
	bool V_6 = false;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	bool V_9 = false;
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B7_0 = 0;
	int32_t G_B19_0 = 0;
	{
		int32_t L_0 = ((CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5*)__this)->___m_BindingMode_7;
		V_3 = (bool)((((int32_t)L_0) == ((int32_t)5))? 1 : 0);
		bool L_1 = V_3;
		if (!L_1)
		{
			goto IL_001a;
		}
	}
	{
		V_4 = (0.0f);
		goto IL_0182;
	}

IL_001a:
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2;
		L_2 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_2, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_5 = L_3;
		bool L_4 = V_5;
		if (!L_4)
		{
			goto IL_0034;
		}
	}
	{
		float L_5 = ___currentHeading0;
		V_4 = L_5;
		goto IL_0182;
	}

IL_0034:
	{
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_6 = (&__this->___m_Heading_23);
		int32_t L_7 = L_6->___m_Definition_0;
		V_0 = L_7;
		int32_t L_8 = V_0;
		if ((!(((uint32_t)L_8) == ((uint32_t)1))))
		{
			goto IL_0052;
		}
	}
	{
		Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* L_9 = __this->___m_TargetRigidBody_33;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_10;
		L_10 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_9, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B7_0 = ((int32_t)(L_10));
		goto IL_0053;
	}

IL_0052:
	{
		G_B7_0 = 0;
	}

IL_0053:
	{
		V_6 = (bool)G_B7_0;
		bool L_11 = V_6;
		if (!L_11)
		{
			goto IL_005b;
		}
	}
	{
		V_0 = 0;
	}

IL_005b:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_1 = L_12;
		int32_t L_13 = V_0;
		V_8 = L_13;
		int32_t L_14 = V_8;
		V_7 = L_14;
		int32_t L_15 = V_7;
		switch (L_15)
		{
			case 0:
			{
				goto IL_008f;
			}
			case 1:
			{
				goto IL_0081;
			}
			case 2:
			{
				goto IL_00a3;
			}
			case 3:
			{
				goto IL_00b6;
			}
		}
	}
	{
		goto IL_00b6;
	}

IL_0081:
	{
		Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* L_16 = __this->___m_TargetRigidBody_33;
		NullCheck(L_16);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		L_17 = Rigidbody_get_velocity_mAE331303E7214402C93E2183D0AA1198F425F843(L_16, NULL);
		V_1 = L_17;
		goto IL_00c2;
	}

IL_008f:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = __this->___m_LastTargetPosition_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20;
		L_20 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_18, L_19, NULL);
		V_1 = L_20;
		goto IL_00c2;
	}

IL_00a3:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_21;
		L_21 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22;
		L_22 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_21, L_22, NULL);
		V_1 = L_23;
		goto IL_00c2;
	}

IL_00b6:
	{
		V_4 = (0.0f);
		goto IL_0182;
	}

IL_00c2:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_24 = ___targetOrientation1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26;
		L_26 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_24, L_25, NULL);
		V_2 = L_26;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29;
		L_29 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_27, L_28, NULL);
		V_1 = L_29;
		int32_t L_30 = V_0;
		V_9 = (bool)((((int32_t)((((int32_t)L_30) == ((int32_t)2))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_31 = V_9;
		if (!L_31)
		{
			goto IL_0158;
		}
	}
	{
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* L_32 = (&__this->___m_Heading_23);
		int32_t L_33 = L_32->___m_VelocityFilterStrength_1;
		V_10 = ((int32_t)il2cpp_codegen_multiply(L_33, 5));
		HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* L_34 = __this->___mHeadingTracker_32;
		if (!L_34)
		{
			goto IL_010f;
		}
	}
	{
		HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* L_35 = __this->___mHeadingTracker_32;
		NullCheck(L_35);
		int32_t L_36;
		L_36 = HeadingTracker_get_FilterSize_mEF06A6674D9D5FE8F1802922DECACF11BA7BE151(L_35, NULL);
		int32_t L_37 = V_10;
		G_B19_0 = ((((int32_t)((((int32_t)L_36) == ((int32_t)L_37))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0110;
	}

IL_010f:
	{
		G_B19_0 = 1;
	}

IL_0110:
	{
		V_11 = (bool)G_B19_0;
		bool L_38 = V_11;
		if (!L_38)
		{
			goto IL_0123;
		}
	}
	{
		int32_t L_39 = V_10;
		HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* L_40 = (HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA*)il2cpp_codegen_object_new(HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA_il2cpp_TypeInfo_var);
		NullCheck(L_40);
		HeadingTracker__ctor_m65E930C6FC3B44B9DE66B61332E4A960A14BE25B(L_40, L_39, NULL);
		__this->___mHeadingTracker_32 = L_40;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___mHeadingTracker_32), (void*)L_40);
	}

IL_0123:
	{
		HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* L_41 = __this->___mHeadingTracker_32;
		NullCheck(L_41);
		HeadingTracker_DecayHistory_m9E2B8A0731C6C492AE78B36925860F4A3EFA1BB7(L_41, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42 = V_1;
		bool L_43;
		L_43 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_42, NULL);
		V_12 = (bool)((((int32_t)L_43) == ((int32_t)0))? 1 : 0);
		bool L_44 = V_12;
		if (!L_44)
		{
			goto IL_014b;
		}
	}
	{
		HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* L_45 = __this->___mHeadingTracker_32;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46 = V_1;
		NullCheck(L_45);
		HeadingTracker_Add_m9FC794FA982A8598BC1FA0DB46EFAA7507CB861D(L_45, L_46, NULL);
	}

IL_014b:
	{
		HeadingTracker_tAB917CE7B50C972CE3BD85A6086AE8FE2BF931FA* L_47 = __this->___mHeadingTracker_32;
		NullCheck(L_47);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_48;
		L_48 = HeadingTracker_GetReliableHeading_m3277A5C1F94F1269E38655527EB71AACF594F695(L_47, NULL);
		V_1 = L_48;
	}

IL_0158:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49 = V_1;
		bool L_50;
		L_50 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_49, NULL);
		V_13 = (bool)((((int32_t)L_50) == ((int32_t)0))? 1 : 0);
		bool L_51 = V_13;
		if (!L_51)
		{
			goto IL_017d;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_52 = ___targetOrientation1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_53;
		L_53 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_54;
		L_54 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_52, L_53, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_55 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_56 = V_2;
		float L_57;
		L_57 = UnityVectorExtensions_SignedAngle_mEC66BAD4357C0F5F7ADE082AD38AD1FE70649315(L_54, L_55, L_56, NULL);
		V_4 = L_57;
		goto IL_0182;
	}

IL_017d:
	{
		float L_58 = ___currentHeading0;
		V_4 = L_58;
		goto IL_0182;
	}

IL_0182:
	{
		float L_59 = V_4;
		return L_59;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineOrbitalTransposer__ctor_m8BD1ED063A460BEF9B0A489B63769DA9CD1511FC (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_U3C_ctorU3Eb__30_0_m9216ED998310150D666FF45C1BD6868BF4BF02DD_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral88BEE283254D7094E258B3A88730F4CC4F1E4AC7);
		s_Il2CppMethodInitialized = true;
	}
	UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* G_B2_0 = NULL;
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B2_1 = NULL;
	UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* G_B1_0 = NULL;
	CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* G_B1_1 = NULL;
	{
		Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E L_0;
		memset((&L_0), 0, sizeof(L_0));
		Heading__ctor_m8BA2E53862E9957B1942EF8A55E5C8284ACDAAAB((&L_0), 2, 4, (0.0f), NULL);
		__this->___m_Heading_23 = L_0;
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF L_1;
		memset((&L_1), 0, sizeof(L_1));
		Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476((&L_1), (bool)1, (1.0f), (2.0f), NULL);
		__this->___m_RecenterToTargetHeading_24 = L_1;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736 L_2;
		memset((&L_2), 0, sizeof(L_2));
		AxisState__ctor_m09348C6ABBA887484BF7D3961D4FB582C0E5A4F6((&L_2), (-180.0f), (180.0f), (bool)1, (bool)0, (300.0f), (0.100000001f), (0.100000001f), _stringLiteral88BEE283254D7094E258B3A88730F4CC4F1E4AC7, (bool)1, NULL);
		__this->___m_XAxis_25 = L_2;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___m_XAxis_25))->___m_InputAxisName_5), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___m_XAxis_25))->___m_InputAxisProvider_16), (void*)NULL);
		#endif
		__this->___m_LegacyRadius_26 = ((std::numeric_limits<float>::max)());
		__this->___m_LegacyHeightOffset_27 = ((std::numeric_limits<float>::max)());
		__this->___m_LegacyHeadingBias_28 = ((std::numeric_limits<float>::max)());
		__this->___m_HeadingIsSlave_29 = (bool)0;
		il2cpp_codegen_runtime_class_init_inline(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var);
		UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* L_3 = ((U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var))->___U3CU3E9__30_0_1;
		UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* L_4 = L_3;
		G_B1_0 = L_4;
		G_B1_1 = __this;
		if (L_4)
		{
			G_B2_0 = L_4;
			G_B2_1 = __this;
			goto IL_009c;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var);
		U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6* L_5 = ((U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var))->___U3CU3E9_0;
		UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* L_6 = (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60*)il2cpp_codegen_object_new(UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60_il2cpp_TypeInfo_var);
		NullCheck(L_6);
		UpdateHeadingDelegate__ctor_m60911D320DFD3CDA2C31C8CC7E030A3B47EFF3F6(L_6, L_5, (intptr_t)((void*)U3CU3Ec_U3C_ctorU3Eb__30_0_m9216ED998310150D666FF45C1BD6868BF4BF02DD_RuntimeMethod_var), NULL);
		UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* L_7 = L_6;
		((U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var))->___U3CU3E9__30_0_1 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&((U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var))->___U3CU3E9__30_0_1), (void*)L_7);
		G_B2_0 = L_7;
		G_B2_1 = G_B1_1;
	}

IL_009c:
	{
		NullCheck(G_B2_1);
		G_B2_1->___HeadingUpdater_30 = G_B2_0;
		Il2CppCodeGenWriteBarrier((void**)(&G_B2_1->___HeadingUpdater_30), (void*)G_B2_0);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_LastTargetPosition_31 = L_8;
		__this->___m_TargetRigidBody_33 = (Rigidbody_t268697F5A994213ED97393309870968BC1C7393C*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_TargetRigidBody_33), (void*)(Rigidbody_t268697F5A994213ED97393309870968BC1C7393C*)NULL);
		CinemachineTransposer__ctor_m66F1121D2339FDEDC9743EC432749AFB3CA846BC(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Heading__ctor_m8BA2E53862E9957B1942EF8A55E5C8284ACDAAAB (Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* __this, int32_t ___def0, int32_t ___filterStrength1, float ___bias2, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___def0;
		__this->___m_Definition_0 = L_0;
		int32_t L_1 = ___filterStrength1;
		__this->___m_VelocityFilterStrength_1 = L_1;
		float L_2 = ___bias2;
		__this->___m_Bias_2 = L_2;
		return;
	}
}
IL2CPP_EXTERN_C  void Heading__ctor_m8BA2E53862E9957B1942EF8A55E5C8284ACDAAAB_AdjustorThunk (RuntimeObject* __this, int32_t ___def0, int32_t ___filterStrength1, float ___bias2, const RuntimeMethod* method)
{
	Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E*>(__this + _offset);
	Heading__ctor_m8BA2E53862E9957B1942EF8A55E5C8284ACDAAAB(_thisAdjusted, ___def0, ___filterStrength1, ___bias2, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_Multicast(UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	float retVal = 0.0f;
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* currentDelegate = reinterpret_cast<UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60*>(delegatesToInvoke[i]);
		typedef float (*FunctionPointerType) (RuntimeObject*, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303*, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, const RuntimeMethod*);
		retVal = ((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___orbital0, ___deltaTime1, ___up2, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
	return retVal;
}
float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_Open(UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method)
{
	typedef float (*FunctionPointerType) (CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303*, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___method_ptr_0)(___orbital0, ___deltaTime1, ___up2, method);
}
float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenVirtual(UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method)
{
	return VirtualFuncInvoker2< float, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 >::Invoke(il2cpp_codegen_method_get_slot(method), ___orbital0, ___deltaTime1, ___up2);
}
float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenInterface(UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method)
{
	return InterfaceFuncInvoker2< float, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___orbital0, ___deltaTime1, ___up2);
}
float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenGenericVirtual(UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method)
{
	return GenericVirtualFuncInvoker2< float, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 >::Invoke(method, ___orbital0, ___deltaTime1, ___up2);
}
float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenGenericInterface(UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method)
{
	return GenericInterfaceFuncInvoker2< float, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 >::Invoke(method, ___orbital0, ___deltaTime1, ___up2);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UpdateHeadingDelegate__ctor_m60911D320DFD3CDA2C31C8CC7E030A3B47EFF3F6 (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
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
			__this->___invoke_impl_1 = (intptr_t)&UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_Open;
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
						__this->___invoke_impl_1 = (intptr_t)&UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_Open;
			}
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method) 
{
	typedef float (*FunctionPointerType) (RuntimeObject*, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303*, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___orbital0, ___deltaTime1, ___up2, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UpdateHeadingDelegate_BeginInvoke_mF9371D7AA17A9372F2FAB2891F8E66CA67FE5AAE (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback3, RuntimeObject* ___object4, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[4] = {0};
	__d_args[0] = ___orbital0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___deltaTime1);
	__d_args[2] = Box(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var, &___up2);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback3, (RuntimeObject*)___object4);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float UpdateHeadingDelegate_EndInvoke_mCF8E24E08925233FAA0FB6E5AFAFEFCF67FBE8CF (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
{
	RuntimeObject *__result = il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
	return *(float*)UnBox ((RuntimeObject*)__result);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__cctor_mC4BBE7E060D7D62BDA15539A4E1FB07BEC64C7BC (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6* L_0 = (U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6*)il2cpp_codegen_object_new(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CU3Ec__ctor_m86741AB1B49B0E3932CA01086C2B7FAFC221C361(L_0, NULL);
		((U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var))->___U3CU3E9_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6_il2cpp_TypeInfo_var))->___U3CU3E9_0), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m86741AB1B49B0E3932CA01086C2B7FAFC221C361 (U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float U3CU3Ec_U3C_ctorU3Eb__30_0_m9216ED998310150D666FF45C1BD6868BF4BF02DD (U3CU3Ec_t382FDC8BD22EECDEF925FEC728CC7C973C3659D6* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	{
		CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* L_0 = ___orbital0;
		float L_1 = ___deltaTime1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___up2;
		CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* L_3 = ___orbital0;
		NullCheck(L_3);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_4 = (&L_3->___m_XAxis_25);
		CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* L_5 = ___orbital0;
		NullCheck(L_5);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_6 = (&L_5->___m_RecenterToTargetHeading_24);
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* L_7;
		L_7 = CinemachineCore_get_Instance_m761793890717527703D6C8BB3AC64FEC93745A85(NULL);
		CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* L_8 = ___orbital0;
		NullCheck(L_8);
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_9;
		L_9 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(L_8, NULL);
		NullCheck(L_7);
		bool L_10;
		L_10 = CinemachineCore_IsLive_m6F2EBE598087857FF7D04A078563E9972CA52678(L_7, L_9, NULL);
		NullCheck(L_0);
		float L_11;
		L_11 = CinemachineOrbitalTransposer_UpdateHeading_m8718BA600DA5134C0E38C8646DBC2506AB4472AB(L_0, L_1, L_2, L_4, L_6, L_10, NULL);
		V_0 = L_11;
		goto IL_0028;
	}

IL_0028:
	{
		float L_12 = V_0;
		return L_12;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachinePOV_get_IsValid_m05C868F4435523397654A39A1BF8593CF0F59ECF (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachinePOV_get_Stage_mFE8B3BB72F863545A8347D3CA587EE97D9A9EA5D (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 1;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_OnValidate_m016AFFEFBEFECF40D1507E5AF33A6C0E1013D228 (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_0 = (&__this->___m_VerticalAxis_8);
		AxisState_Validate_m1245D61F6D9A031C27F75F4B49E78A52AA91BDE5(L_0, NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_1 = (&__this->___m_VerticalRecentering_9);
		Recentering_Validate_m3F5EE15AE52BB8FF2B69E3963851CEE2600340D3(L_1, NULL);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_2 = (&__this->___m_HorizontalAxis_10);
		AxisState_Validate_m1245D61F6D9A031C27F75F4B49E78A52AA91BDE5(L_2, NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_3 = (&__this->___m_HorizontalRecentering_11);
		Recentering_Validate_m3F5EE15AE52BB8FF2B69E3963851CEE2600340D3(L_3, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_OnEnable_m3A517E2080784B6C7A31A3227796D3B994FF647B (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	{
		CinemachinePOV_UpdateInputAxisProvider_m061C1326E834985C26CA2D74F90D2E52C590FC4D(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_UpdateInputAxisProvider_m061C1326E834985C26CA2D74F90D2E52C590FC4D (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	RuntimeObject* V_1 = NULL;
	bool V_2 = false;
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_0 = (&__this->___m_HorizontalAxis_10);
		AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85(L_0, 0, (RuntimeObject*)NULL, NULL);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_1 = (&__this->___m_VerticalAxis_8);
		AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85(L_1, 1, (RuntimeObject*)NULL, NULL);
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_2;
		L_2 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_2, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_0 = L_3;
		bool L_4 = V_0;
		if (!L_4)
		{
			goto IL_0061;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_5;
		L_5 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_5);
		RuntimeObject* L_6;
		L_6 = CinemachineVirtualCameraBase_GetInputAxisProvider_mC735C4764E6CB8469D115142D842729C95D9C39E(L_5, NULL);
		V_1 = L_6;
		RuntimeObject* L_7 = V_1;
		V_2 = (bool)((!(((RuntimeObject*)(RuntimeObject*)L_7) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_8 = V_2;
		if (!L_8)
		{
			goto IL_0060;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_9 = (&__this->___m_HorizontalAxis_10);
		RuntimeObject* L_10 = V_1;
		AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85(L_9, 0, L_10, NULL);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_11 = (&__this->___m_VerticalAxis_8);
		RuntimeObject* L_12 = V_1;
		AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85(L_11, 1, L_12, NULL);
	}

IL_0060:
	{
	}

IL_0061:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_PrePipelineMutateCameraState_mBA43F716320C330EE8502DC1F49CD30512D8DF0B (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___state0, float ___deltaTime1, const RuntimeMethod* method) 
{
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_MutateCameraState_m7D3F0F0979A4D487630A47A0BDB8B6C01F58A4EE (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_4;
	memset((&V_4), 0, sizeof(V_4));
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t G_B5_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_2 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_2;
		if (!L_1)
		{
			goto IL_0013;
		}
	}
	{
		goto IL_0116;
	}

IL_0013:
	{
		float L_2 = ___deltaTime1;
		if ((!(((float)L_2) >= ((float)(0.0f)))))
		{
			goto IL_002d;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* L_3;
		L_3 = CinemachineCore_get_Instance_m761793890717527703D6C8BB3AC64FEC93745A85(NULL);
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_4;
		L_4 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_3);
		bool L_5;
		L_5 = CinemachineCore_IsLive_m6F2EBE598087857FF7D04A078563E9972CA52678(L_3, L_4, NULL);
		G_B5_0 = ((int32_t)(L_5));
		goto IL_002e;
	}

IL_002d:
	{
		G_B5_0 = 0;
	}

IL_002e:
	{
		V_3 = (bool)G_B5_0;
		bool L_6 = V_3;
		if (!L_6)
		{
			goto IL_00ac;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_7 = (&__this->___m_HorizontalAxis_10);
		float L_8 = ___deltaTime1;
		bool L_9;
		L_9 = AxisState_Update_mE86F039B78105160E5C13153B456E3A988AF28B4(L_7, L_8, NULL);
		V_5 = L_9;
		bool L_10 = V_5;
		if (!L_10)
		{
			goto IL_0051;
		}
	}
	{
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_11 = (&__this->___m_HorizontalRecentering_11);
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(L_11, NULL);
	}

IL_0051:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_12 = (&__this->___m_VerticalAxis_8);
		float L_13 = ___deltaTime1;
		bool L_14;
		L_14 = AxisState_Update_mE86F039B78105160E5C13153B456E3A988AF28B4(L_12, L_13, NULL);
		V_6 = L_14;
		bool L_15 = V_6;
		if (!L_15)
		{
			goto IL_006f;
		}
	}
	{
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_16 = (&__this->___m_VerticalRecentering_9);
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(L_16, NULL);
	}

IL_006f:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_17;
		L_17 = CinemachinePOV_GetRecenterTarget_m222F334C80D4ABBD48B9284A6EFCF6C0B853460A(__this, NULL);
		V_4 = L_17;
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_18 = (&__this->___m_HorizontalRecentering_11);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_19 = (&__this->___m_HorizontalAxis_10);
		float L_20 = ___deltaTime1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_21 = V_4;
		float L_22 = L_21.___x_0;
		Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A(L_18, L_19, L_20, L_22, NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_23 = (&__this->___m_VerticalRecentering_9);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_24 = (&__this->___m_VerticalAxis_8);
		float L_25 = ___deltaTime1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_26 = V_4;
		float L_27 = L_26.___y_1;
		Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A(L_23, L_24, L_25, L_27, NULL);
	}

IL_00ac:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_28 = (&__this->___m_VerticalAxis_8);
		float L_29 = L_28->___Value_0;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_30 = (&__this->___m_HorizontalAxis_10);
		float L_31 = L_30->___Value_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_32;
		L_32 = Quaternion_Euler_mD4601D966F1F58F3FCA01B3FC19A12D0AD0396DD_inline(L_29, L_31, (0.0f), NULL);
		V_0 = L_32;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_33;
		L_33 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_33);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_34;
		L_34 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_33, NULL);
		NullCheck(L_34);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_35;
		L_35 = Transform_get_parent_m65354E28A4C94EC00EBCF03532F7B0718380791E(L_34, NULL);
		V_1 = L_35;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_36 = V_1;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_37;
		L_37 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_36, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_7 = L_37;
		bool L_38 = V_7;
		if (!L_38)
		{
			goto IL_00f8;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_39 = V_1;
		NullCheck(L_39);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_40;
		L_40 = Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C(L_39, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_41 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_42;
		L_42 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_40, L_41, NULL);
		V_0 = L_42;
	}

IL_00f8:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43;
		L_43 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_44 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45 = L_44->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_46;
		L_46 = Quaternion_FromToRotation_m041093DBB23CB3641118310881D6B7746E3B8418(L_43, L_45, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_47 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_48;
		L_48 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_46, L_47, NULL);
		V_0 = L_48;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_49 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_50 = V_0;
		L_49->___RawOrientation_5 = L_50;
	}

IL_0116:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 CinemachinePOV_GetRecenterTarget_m222F334C80D4ABBD48B9284A6EFCF6C0B853460A (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	bool V_3 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* V_5 = NULL;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	bool V_7 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_8;
	memset((&V_8), 0, sizeof(V_8));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_9;
	memset((&V_9), 0, sizeof(V_9));
	{
		V_0 = (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)NULL;
		int32_t L_0 = __this->___m_RecenterTarget_7;
		V_2 = L_0;
		int32_t L_1 = V_2;
		V_1 = L_1;
		int32_t L_2 = V_1;
		if ((((int32_t)L_2) == ((int32_t)1)))
		{
			goto IL_0018;
		}
	}
	{
		goto IL_0012;
	}

IL_0012:
	{
		int32_t L_3 = V_1;
		if ((((int32_t)L_3) == ((int32_t)2)))
		{
			goto IL_0026;
		}
	}
	{
		goto IL_0034;
	}

IL_0018:
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_4;
		L_4 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_4);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_5;
		L_5 = VirtualFuncInvoker0< Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* >::Invoke(29, L_4);
		V_0 = L_5;
		goto IL_0036;
	}

IL_0026:
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_6;
		L_6 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_6);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_7;
		L_7 = VirtualFuncInvoker0< Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* >::Invoke(27, L_6);
		V_0 = L_7;
		goto IL_0036;
	}

IL_0034:
	{
		goto IL_0036;
	}

IL_0036:
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_8 = V_0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_9;
		L_9 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_8, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_3 = L_9;
		bool L_10 = V_3;
		if (!L_10)
		{
			goto IL_00b2;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_11 = V_0;
		NullCheck(L_11);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Transform_get_forward_mFCFACF7165FDAB21E80E384C494DF278386CEE2F(L_11, NULL);
		V_4 = L_12;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_13;
		L_13 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_13);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_14;
		L_14 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_13, NULL);
		NullCheck(L_14);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_15;
		L_15 = Transform_get_parent_m65354E28A4C94EC00EBCF03532F7B0718380791E(L_14, NULL);
		V_5 = L_15;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_16 = V_5;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_17;
		L_17 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_16, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_7 = L_17;
		bool L_18 = V_7;
		if (!L_18)
		{
			goto IL_007a;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_19 = V_5;
		NullCheck(L_19);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20;
		L_20 = Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C(L_19, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22;
		L_22 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_20, L_21, NULL);
		V_4 = L_22;
	}

IL_007a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = V_4;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_25;
		L_25 = Quaternion_FromToRotation_m041093DBB23CB3641118310881D6B7746E3B8418(L_23, L_24, NULL);
		V_8 = L_25;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26;
		L_26 = Quaternion_get_eulerAngles_m2DB5158B5C3A71FD60FC8A6EE43D3AAA1CFED122_inline((&V_8), NULL);
		V_6 = L_26;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = V_6;
		float L_28 = L_27.___y_3;
		float L_29;
		L_29 = CinemachinePOV_NormalizeAngle_m44F87A756F3A1DE1CBCB5C4F776C86B837B2D68E(L_28, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30 = V_6;
		float L_31 = L_30.___x_2;
		float L_32;
		L_32 = CinemachinePOV_NormalizeAngle_m44F87A756F3A1DE1CBCB5C4F776C86B837B2D68E(L_31, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_33;
		memset((&L_33), 0, sizeof(L_33));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_33), L_29, L_32, NULL);
		V_9 = L_33;
		goto IL_00bb;
	}

IL_00b2:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_34;
		L_34 = Vector2_get_zero_m009B92B5D35AB02BD1610C2E1ACCE7C9CF964A6E_inline(NULL);
		V_9 = L_34;
		goto IL_00bb;
	}

IL_00bb:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_35 = V_9;
		return L_35;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachinePOV_NormalizeAngle_m44F87A756F3A1DE1CBCB5C4F776C86B837B2D68E (float ___angle0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = ___angle0;
		V_0 = ((float)il2cpp_codegen_subtract((fmodf(((float)il2cpp_codegen_add(L_0, (180.0f))), (360.0f))), (180.0f)));
		goto IL_0017;
	}

IL_0017:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_ForceCameraPosition_m454958C55A58DD989A25D0443138AADBF608BB52 (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rot1, const RuntimeMethod* method) 
{
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ___rot1;
		CinemachinePOV_SetAxesForRotation_mDBC52583D2371432C6CE2DFE61689D7C906710BC(__this, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachinePOV_OnTransitionFromCamera_m491BDC05FF82D94CD9F0F5E381FABD26B836D32F (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, RuntimeObject* ___fromCam0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp1, float ___deltaTime2, TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA* ___transitionParams3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	int32_t G_B4_0 = 0;
	{
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_0 = (&__this->___m_HorizontalRecentering_11);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_1 = (&__this->___m_HorizontalAxis_10);
		Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A(L_0, L_1, (-1.0f), (0.0f), NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_2 = (&__this->___m_VerticalRecentering_9);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_3 = (&__this->___m_VerticalAxis_8);
		Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A(L_2, L_3, (-1.0f), (0.0f), NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_4 = (&__this->___m_HorizontalRecentering_11);
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(L_4, NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_5 = (&__this->___m_VerticalRecentering_9);
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(L_5, NULL);
		RuntimeObject* L_6 = ___fromCam0;
		if (!L_6)
		{
			goto IL_0072;
		}
	}
	{
		TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA* L_7 = ___transitionParams3;
		bool L_8 = L_7->___m_InheritPosition_1;
		if (!L_8)
		{
			goto IL_0072;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD* L_9;
		L_9 = CinemachineCore_get_Instance_m761793890717527703D6C8BB3AC64FEC93745A85(NULL);
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_10;
		L_10 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_9);
		bool L_11;
		L_11 = CinemachineCore_IsLiveInBlend_mFD1402FFF3B5D0CD0EC90914F89672724F49F778(L_9, L_10, NULL);
		G_B4_0 = ((((int32_t)L_11) == ((int32_t)0))? 1 : 0);
		goto IL_0073;
	}

IL_0072:
	{
		G_B4_0 = 0;
	}

IL_0073:
	{
		V_0 = (bool)G_B4_0;
		bool L_12 = V_0;
		if (!L_12)
		{
			goto IL_008e;
		}
	}
	{
		RuntimeObject* L_13 = ___fromCam0;
		NullCheck(L_13);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_14;
		L_14 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_13);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_15 = L_14.___RawOrientation_5;
		CinemachinePOV_SetAxesForRotation_mDBC52583D2371432C6CE2DFE61689D7C906710BC(__this, L_15, NULL);
		V_1 = (bool)1;
		goto IL_0092;
	}

IL_008e:
	{
		V_1 = (bool)0;
		goto IL_0092;
	}

IL_0092:
	{
		bool L_16 = V_1;
		return L_16;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachinePOV_get_RequiresUserInput_mF3866C5A3BF1A75C3EBF06998987999FC37A558B (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	{
		return (bool)1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV_SetAxesForRotation_mDBC52583D2371432C6CE2DFE61689D7C906710BC (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___targetRot0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* V_2 = NULL;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	bool V_7 = false;
	bool V_8 = false;
	bool V_9 = false;
	int32_t G_B5_0 = 0;
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_0;
		L_0 = CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = L_0.___ReferenceUp_1;
		V_0 = L_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		V_1 = L_2;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_3;
		L_3 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_3);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_4;
		L_4 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_3, NULL);
		NullCheck(L_4);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_5;
		L_5 = Transform_get_parent_m65354E28A4C94EC00EBCF03532F7B0718380791E(L_4, NULL);
		V_2 = L_5;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_6 = V_2;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_7;
		L_7 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_6, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_7 = L_7;
		bool L_8 = V_7;
		if (!L_8)
		{
			goto IL_003e;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_9 = V_2;
		NullCheck(L_9);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_10;
		L_10 = Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C(L_9, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_10, L_11, NULL);
		V_1 = L_12;
	}

IL_003e:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_13 = (&__this->___m_HorizontalAxis_10);
		L_13->___Value_0 = (0.0f);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_14 = (&__this->___m_HorizontalAxis_10);
		AxisState_Reset_m329065EBC9963460CD7733144EC5F47D107967C9(L_14, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_15 = ___targetRot0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16;
		L_16 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		L_17 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_15, L_16, NULL);
		V_3 = L_17;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20;
		L_20 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_18, L_19, NULL);
		V_4 = L_20;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_21, L_22, NULL);
		V_5 = L_23;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = V_4;
		bool L_25;
		L_25 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_24, NULL);
		if (L_25)
		{
			goto IL_008d;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26 = V_5;
		bool L_27;
		L_27 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_26, NULL);
		G_B5_0 = ((((int32_t)L_27) == ((int32_t)0))? 1 : 0);
		goto IL_008e;
	}

IL_008d:
	{
		G_B5_0 = 0;
	}

IL_008e:
	{
		V_8 = (bool)G_B5_0;
		bool L_28 = V_8;
		if (!L_28)
		{
			goto IL_00a9;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_29 = (&__this->___m_HorizontalAxis_10);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32 = V_0;
		float L_33;
		L_33 = Vector3_SignedAngle_mD30E71B2F64983C2C4D86F17E7023BAA84CE50BE_inline(L_30, L_31, L_32, NULL);
		L_29->___Value_0 = L_33;
	}

IL_00a9:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_34 = (&__this->___m_VerticalAxis_8);
		L_34->___Value_0 = (0.0f);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_35 = (&__this->___m_VerticalAxis_8);
		AxisState_Reset_m329065EBC9963460CD7733144EC5F47D107967C9(L_35, NULL);
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_36 = (&__this->___m_HorizontalAxis_10);
		float L_37 = L_36->___Value_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_39;
		L_39 = Quaternion_AngleAxis_m01A869DC10F976FAF493B66F15D6D6977BB61DA8(L_37, L_38, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_41;
		L_41 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_39, L_40, NULL);
		V_1 = L_41;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_44;
		L_44 = Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline(L_42, L_43, NULL);
		V_6 = L_44;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45 = V_6;
		bool L_46;
		L_46 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_45, NULL);
		V_9 = (bool)((((int32_t)L_46) == ((int32_t)0))? 1 : 0);
		bool L_47 = V_9;
		if (!L_47)
		{
			goto IL_010a;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_48 = (&__this->___m_VerticalAxis_8);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51 = V_6;
		float L_52;
		L_52 = Vector3_SignedAngle_mD30E71B2F64983C2C4D86F17E7023BAA84CE50BE_inline(L_49, L_50, L_51, NULL);
		L_48->___Value_0 = L_52;
	}

IL_010a:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachinePOV__ctor_m362B77E97F02F0B022F654161A5FA5120BD0DD17 (CinemachinePOV_t18E8D389A12DA59CCC99E0871996448E1B4AB05B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral16DD21BE77B115D392226EB71A2D3A9FDC29E3F0);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral88BEE283254D7094E258B3A88730F4CC4F1E4AC7);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->___m_RecenterTarget_7 = 0;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736 L_0;
		memset((&L_0), 0, sizeof(L_0));
		AxisState__ctor_m09348C6ABBA887484BF7D3961D4FB582C0E5A4F6((&L_0), (-70.0f), (70.0f), (bool)0, (bool)0, (300.0f), (0.100000001f), (0.100000001f), _stringLiteral16DD21BE77B115D392226EB71A2D3A9FDC29E3F0, (bool)1, NULL);
		__this->___m_VerticalAxis_8 = L_0;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___m_VerticalAxis_8))->___m_InputAxisName_5), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___m_VerticalAxis_8))->___m_InputAxisProvider_16), (void*)NULL);
		#endif
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF L_1;
		memset((&L_1), 0, sizeof(L_1));
		Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476((&L_1), (bool)0, (1.0f), (2.0f), NULL);
		__this->___m_VerticalRecentering_9 = L_1;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736 L_2;
		memset((&L_2), 0, sizeof(L_2));
		AxisState__ctor_m09348C6ABBA887484BF7D3961D4FB582C0E5A4F6((&L_2), (-180.0f), (180.0f), (bool)1, (bool)0, (300.0f), (0.100000001f), (0.100000001f), _stringLiteral88BEE283254D7094E258B3A88730F4CC4F1E4AC7, (bool)0, NULL);
		__this->___m_HorizontalAxis_10 = L_2;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___m_HorizontalAxis_10))->___m_InputAxisName_5), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___m_HorizontalAxis_10))->___m_InputAxisProvider_16), (void*)NULL);
		#endif
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF L_3;
		memset((&L_3), 0, sizeof(L_3));
		Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476((&L_3), (bool)0, (1.0f), (2.0f), NULL);
		__this->___m_HorizontalRecentering_11 = L_3;
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineSameAsFollowTarget_get_IsValid_mC6D1503DFD8DC214605C36C1CAE502935D15BFEA (CinemachineSameAsFollowTarget_t3F3D720F4ED98F0E8608A0D077BB877F1A897141* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineSameAsFollowTarget_get_Stage_mC807B568193EE1879B9A384DD9867E7FB1FFEA48 (CinemachineSameAsFollowTarget_t3F3D720F4ED98F0E8608A0D077BB877F1A897141* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 1;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineSameAsFollowTarget_GetMaxDampTime_m043AF23A9A983ECE05922C0472DB7FC1BF8542FB (CinemachineSameAsFollowTarget_t3F3D720F4ED98F0E8608A0D077BB877F1A897141* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_Damping_7;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineSameAsFollowTarget_MutateCameraState_mE752F9E346D7A3380316A3446D5210988467B4F0 (CinemachineSameAsFollowTarget_t3F3D720F4ED98F0E8608A0D077BB877F1A897141* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	bool V_2 = false;
	float V_3 = 0.0f;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_1 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_1;
		if (!L_1)
		{
			goto IL_0010;
		}
	}
	{
		goto IL_0061;
	}

IL_0010:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2;
		L_2 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		V_0 = L_2;
		float L_3 = ___deltaTime1;
		V_2 = (bool)((((int32_t)((!(((float)L_3) >= ((float)(0.0f))))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0053;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_5;
		L_5 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		float L_6 = __this->___m_Damping_7;
		float L_7 = ___deltaTime1;
		NullCheck(L_5);
		float L_8;
		L_8 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m215A089B8451330FA8D7D6E4DB8E38400AD9E7CF(L_5, (1.0f), L_6, L_7, NULL);
		V_3 = L_8;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_9 = __this->___m_PreviousReferenceOrientation_8;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_10;
		L_10 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		float L_11 = V_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12;
		L_12 = Quaternion_Slerp_m5FDA8C178E7EB209B43845F73263AFE9C02F3949(L_9, L_10, L_11, NULL);
		V_0 = L_12;
	}

IL_0053:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_13 = V_0;
		__this->___m_PreviousReferenceOrientation_8 = L_13;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_14 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_15 = V_0;
		L_14->___RawOrientation_5 = L_15;
	}

IL_0061:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineSameAsFollowTarget__ctor_m4CB9434EC6F54E7AB3287343A9C5416C8079BD09 (CinemachineSameAsFollowTarget_t3F3D720F4ED98F0E8608A0D077BB877F1A897141* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_Damping_7 = (0.0f);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0;
		L_0 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		__this->___m_PreviousReferenceOrientation_8 = L_0;
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineTrackedDolly_get_IsValid_m280F6EE398F406E248920DAEC9A2FB4C0A78CD20 (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_1 = __this->___m_Path_7;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineTrackedDolly_get_Stage_m71C0F0AEBCCACD06836E5186C06F8E157DEB44D4 (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineTrackedDolly_GetMaxDampTime_m8387A78C47A4689A44BC60168DAD135BF2F14E20 (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = CinemachineTrackedDolly_get_AngularDamping_m5ED59BCFD88587E5AF232BB5D779B3FE03832DE9(__this, NULL);
		V_0 = L_0;
		float L_1 = __this->___m_XDamping_11;
		float L_2 = __this->___m_YDamping_12;
		float L_3 = __this->___m_ZDamping_13;
		float L_4;
		L_4 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_2, L_3, NULL);
		float L_5;
		L_5 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_1, L_4, NULL);
		V_1 = L_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = V_0;
		float L_7 = L_6.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = V_0;
		float L_9 = L_8.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_0;
		float L_11 = L_10.___z_4;
		float L_12;
		L_12 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_9, L_11, NULL);
		float L_13;
		L_13 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_7, L_12, NULL);
		V_2 = L_13;
		float L_14 = V_1;
		float L_15 = V_2;
		float L_16;
		L_16 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_14, L_15, NULL);
		V_3 = L_16;
		goto IL_004c;
	}

IL_004c:
	{
		float L_17 = V_3;
		return L_17;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTrackedDolly_MutateCameraState_m520EE451BF883F43059C628A4FEED072C6ACFECE (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_6;
	memset((&V_6), 0, sizeof(V_6));
	bool V_7 = false;
	bool V_8 = false;
	bool V_9 = false;
	float V_10 = 0.0f;
	bool V_11 = false;
	float V_12 = 0.0f;
	float V_13 = 0.0f;
	bool V_14 = false;
	float V_15 = 0.0f;
	float V_16 = 0.0f;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_20;
	memset((&V_20), 0, sizeof(V_20));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_21;
	memset((&V_21), 0, sizeof(V_21));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_22;
	memset((&V_22), 0, sizeof(V_22));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_23;
	memset((&V_23), 0, sizeof(V_23));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_24;
	memset((&V_24), 0, sizeof(V_24));
	bool V_25 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_26;
	memset((&V_26), 0, sizeof(V_26));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_27;
	memset((&V_27), 0, sizeof(V_27));
	int32_t V_28 = 0;
	bool V_29 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* V_30 = NULL;
	int32_t V_31 = 0;
	bool V_32 = false;
	bool V_33 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B10_0 = 0;
	int32_t G_B14_0 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B14_1;
	memset((&G_B14_1), 0, sizeof(G_B14_1));
	CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* G_B14_2 = NULL;
	CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* G_B14_3 = NULL;
	int32_t G_B12_0 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B12_1;
	memset((&G_B12_1), 0, sizeof(G_B12_1));
	CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* G_B12_2 = NULL;
	CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* G_B12_3 = NULL;
	int32_t G_B13_0 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B13_1;
	memset((&G_B13_1), 0, sizeof(G_B13_1));
	CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* G_B13_2 = NULL;
	CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* G_B13_3 = NULL;
	int32_t G_B15_0 = 0;
	int32_t G_B15_1 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B15_2;
	memset((&G_B15_2), 0, sizeof(G_B15_2));
	CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* G_B15_3 = NULL;
	CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* G_B15_4 = NULL;
	int32_t G_B19_0 = 0;
	int32_t G_B24_0 = 0;
	int32_t G_B34_0 = 0;
	int32_t G_B39_0 = 0;
	{
		float L_0 = ___deltaTime1;
		if ((((float)L_0) < ((float)(0.0f))))
		{
			goto IL_0019;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_1;
		L_1 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_1);
		bool L_2;
		L_2 = VirtualFuncInvoker0< bool >::Invoke(31, L_1);
		G_B3_0 = ((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		goto IL_001a;
	}

IL_0019:
	{
		G_B3_0 = 1;
	}

IL_001a:
	{
		V_7 = (bool)G_B3_0;
		bool L_3 = V_7;
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		float L_4 = __this->___m_PathPosition_8;
		__this->___m_PreviousPathPosition_19 = L_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_5 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = L_5->___RawPosition_4;
		__this->___m_PreviousCameraPosition_21 = L_6;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_7 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_8 = L_7->___RawOrientation_5;
		__this->___m_PreviousOrientation_20 = L_8;
	}

IL_0046:
	{
		bool L_9;
		L_9 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_8 = (bool)((((int32_t)L_9) == ((int32_t)0))? 1 : 0);
		bool L_10 = V_8;
		if (!L_10)
		{
			goto IL_005a;
		}
	}
	{
		goto IL_042f;
	}

IL_005a:
	{
		AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* L_11 = (&__this->___m_AutoDolly_18);
		bool L_12 = L_11->___m_Enabled_0;
		if (!L_12)
		{
			goto IL_0075;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_13;
		L_13 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_14;
		L_14 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_13, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B10_0 = ((int32_t)(L_14));
		goto IL_0076;
	}

IL_0075:
	{
		G_B10_0 = 0;
	}

IL_0076:
	{
		V_9 = (bool)G_B10_0;
		bool L_15 = V_9;
		if (!L_15)
		{
			goto IL_011c;
		}
	}
	{
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_16 = __this->___m_Path_7;
		float L_17 = __this->___m_PreviousPathPosition_19;
		int32_t L_18 = __this->___m_PositionUnits_9;
		NullCheck(L_16);
		float L_19;
		L_19 = CinemachinePathBase_ToNativePathUnits_m71355B86B0027D58831E4B9489CCFEE69B7E9158(L_16, L_17, L_18, NULL);
		V_10 = L_19;
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_20 = __this->___m_Path_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21;
		L_21 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		float L_22 = V_10;
		int32_t L_23;
		L_23 = Mathf_FloorToInt_mD086E41305DD8350180AD677833A22733B4789A9_inline(L_22, NULL);
		float L_24 = ___deltaTime1;
		G_B12_0 = L_23;
		G_B12_1 = L_21;
		G_B12_2 = L_20;
		G_B12_3 = __this;
		if ((((float)L_24) < ((float)(0.0f))))
		{
			G_B14_0 = L_23;
			G_B14_1 = L_21;
			G_B14_2 = L_20;
			G_B14_3 = __this;
			goto IL_00d0;
		}
	}
	{
		AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* L_25 = (&__this->___m_AutoDolly_18);
		int32_t L_26 = L_25->___m_SearchRadius_2;
		G_B13_0 = G_B12_0;
		G_B13_1 = G_B12_1;
		G_B13_2 = G_B12_2;
		G_B13_3 = G_B12_3;
		if ((((int32_t)L_26) <= ((int32_t)0)))
		{
			G_B14_0 = G_B12_0;
			G_B14_1 = G_B12_1;
			G_B14_2 = G_B12_2;
			G_B14_3 = G_B12_3;
			goto IL_00d0;
		}
	}
	{
		AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* L_27 = (&__this->___m_AutoDolly_18);
		int32_t L_28 = L_27->___m_SearchRadius_2;
		G_B15_0 = L_28;
		G_B15_1 = G_B13_0;
		G_B15_2 = G_B13_1;
		G_B15_3 = G_B13_2;
		G_B15_4 = G_B13_3;
		goto IL_00d1;
	}

IL_00d0:
	{
		G_B15_0 = (-1);
		G_B15_1 = G_B14_0;
		G_B15_2 = G_B14_1;
		G_B15_3 = G_B14_2;
		G_B15_4 = G_B14_3;
	}

IL_00d1:
	{
		AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* L_29 = (&__this->___m_AutoDolly_18);
		int32_t L_30 = L_29->___m_SearchResolution_3;
		NullCheck(G_B15_3);
		float L_31;
		L_31 = VirtualFuncInvoker4< float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, int32_t, int32_t, int32_t >::Invoke(11, G_B15_3, G_B15_2, G_B15_1, G_B15_0, L_30);
		NullCheck(G_B15_4);
		G_B15_4->___m_PathPosition_8 = L_31;
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_32 = __this->___m_Path_7;
		float L_33 = __this->___m_PathPosition_8;
		int32_t L_34 = __this->___m_PositionUnits_9;
		NullCheck(L_32);
		float L_35;
		L_35 = CinemachinePathBase_FromPathNativeUnits_mEFCB692BFEC5A048AF23D9BA3EC74A4255D5D867(L_32, L_33, L_34, NULL);
		__this->___m_PathPosition_8 = L_35;
		float L_36 = __this->___m_PathPosition_8;
		AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* L_37 = (&__this->___m_AutoDolly_18);
		float L_38 = L_37->___m_PositionOffset_1;
		__this->___m_PathPosition_8 = ((float)il2cpp_codegen_add(L_36, L_38));
	}

IL_011c:
	{
		float L_39 = __this->___m_PathPosition_8;
		V_0 = L_39;
		float L_40 = ___deltaTime1;
		if ((!(((float)L_40) >= ((float)(0.0f)))))
		{
			goto IL_0138;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_41;
		L_41 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_41);
		bool L_42;
		L_42 = VirtualFuncInvoker0< bool >::Invoke(31, L_41);
		G_B19_0 = ((int32_t)(L_42));
		goto IL_0139;
	}

IL_0138:
	{
		G_B19_0 = 0;
	}

IL_0139:
	{
		V_11 = (bool)G_B19_0;
		bool L_43 = V_11;
		if (!L_43)
		{
			goto IL_020f;
		}
	}
	{
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_44 = __this->___m_Path_7;
		int32_t L_45 = __this->___m_PositionUnits_9;
		NullCheck(L_44);
		float L_46;
		L_46 = CinemachinePathBase_MaxUnit_mD6C8BEEF736AF66618CD9FEA69D61CC5C9854F76(L_44, L_45, NULL);
		V_12 = L_46;
		float L_47 = V_12;
		V_14 = (bool)((((float)L_47) > ((float)(0.0f)))? 1 : 0);
		bool L_48 = V_14;
		if (!L_48)
		{
			goto IL_01ea;
		}
	}
	{
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_49 = __this->___m_Path_7;
		float L_50 = __this->___m_PreviousPathPosition_19;
		int32_t L_51 = __this->___m_PositionUnits_9;
		NullCheck(L_49);
		float L_52;
		L_52 = VirtualFuncInvoker2< float, float, int32_t >::Invoke(12, L_49, L_50, L_51);
		V_15 = L_52;
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_53 = __this->___m_Path_7;
		float L_54 = V_0;
		int32_t L_55 = __this->___m_PositionUnits_9;
		NullCheck(L_53);
		float L_56;
		L_56 = VirtualFuncInvoker2< float, float, int32_t >::Invoke(12, L_53, L_54, L_55);
		V_16 = L_56;
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_57 = __this->___m_Path_7;
		NullCheck(L_57);
		bool L_58;
		L_58 = VirtualFuncInvoker0< bool >::Invoke(6, L_57);
		if (!L_58)
		{
			goto IL_01b9;
		}
	}
	{
		float L_59 = V_16;
		float L_60 = V_15;
		float L_61;
		L_61 = fabsf(((float)il2cpp_codegen_subtract(L_59, L_60)));
		float L_62 = V_12;
		G_B24_0 = ((((float)L_61) > ((float)((float)(L_62/(2.0f)))))? 1 : 0);
		goto IL_01ba;
	}

IL_01b9:
	{
		G_B24_0 = 0;
	}

IL_01ba:
	{
		V_17 = (bool)G_B24_0;
		bool L_63 = V_17;
		if (!L_63)
		{
			goto IL_01de;
		}
	}
	{
		float L_64 = V_16;
		float L_65 = V_15;
		V_18 = (bool)((((float)L_64) > ((float)L_65))? 1 : 0);
		bool L_66 = V_18;
		if (!L_66)
		{
			goto IL_01d6;
		}
	}
	{
		float L_67 = V_15;
		float L_68 = V_12;
		V_15 = ((float)il2cpp_codegen_add(L_67, L_68));
		goto IL_01dd;
	}

IL_01d6:
	{
		float L_69 = V_15;
		float L_70 = V_12;
		V_15 = ((float)il2cpp_codegen_subtract(L_69, L_70));
	}

IL_01dd:
	{
	}

IL_01de:
	{
		float L_71 = V_15;
		__this->___m_PreviousPathPosition_19 = L_71;
		float L_72 = V_16;
		V_0 = L_72;
	}

IL_01ea:
	{
		float L_73 = __this->___m_PreviousPathPosition_19;
		float L_74 = V_0;
		V_13 = ((float)il2cpp_codegen_subtract(L_73, L_74));
		float L_75 = V_13;
		float L_76 = __this->___m_ZDamping_13;
		float L_77 = ___deltaTime1;
		float L_78;
		L_78 = Damper_Damp_mFB62278C063E2CAA706D30E8D68AF55D50AE95D2(L_75, L_76, L_77, NULL);
		V_13 = L_78;
		float L_79 = __this->___m_PreviousPathPosition_19;
		float L_80 = V_13;
		V_0 = ((float)il2cpp_codegen_subtract(L_79, L_80));
	}

IL_020f:
	{
		float L_81 = V_0;
		__this->___m_PreviousPathPosition_19 = L_81;
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_82 = __this->___m_Path_7;
		float L_83 = V_0;
		int32_t L_84 = __this->___m_PositionUnits_9;
		NullCheck(L_82);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_85;
		L_85 = CinemachinePathBase_EvaluateOrientationAtUnit_m28859D88DD40B298B14EE6D04A6358534E09C0A7(L_82, L_83, L_84, NULL);
		V_1 = L_85;
		CinemachinePathBase_t9BA180040D1DA9F876C41BC313973F3A24EE7B8D* L_86 = __this->___m_Path_7;
		float L_87 = V_0;
		int32_t L_88 = __this->___m_PositionUnits_9;
		NullCheck(L_86);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_89;
		L_89 = CinemachinePathBase_EvaluatePositionAtUnit_mCE1B51BBCAEFF5A65A68F1D3113390F7BC223843(L_86, L_87, L_88, NULL);
		V_2 = L_89;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_90 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_91;
		L_91 = Vector3_get_right_m13B7C3EAA64DC921EC23346C56A5A597B5481FF5_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_92;
		L_92 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_90, L_91, NULL);
		V_3 = L_92;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_93 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_94;
		L_94 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_95;
		L_95 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_93, L_94, NULL);
		V_4 = L_95;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_96 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_97;
		L_97 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_98;
		L_98 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_96, L_97, NULL);
		V_5 = L_98;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_99 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_100 = (&__this->___m_PathOffset_10);
		float L_101 = L_100->___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_102 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_103;
		L_103 = Vector3_op_Multiply_m29F4414A9D30B7C0CD8455C4B2F049E8CCF66745_inline(L_101, L_102, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_104;
		L_104 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_99, L_103, NULL);
		V_2 = L_104;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_105 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_106 = (&__this->___m_PathOffset_10);
		float L_107 = L_106->___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_108 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_109;
		L_109 = Vector3_op_Multiply_m29F4414A9D30B7C0CD8455C4B2F049E8CCF66745_inline(L_107, L_108, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_110;
		L_110 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_105, L_109, NULL);
		V_2 = L_110;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_111 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_112 = (&__this->___m_PathOffset_10);
		float L_113 = L_112->___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_114 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_115;
		L_115 = Vector3_op_Multiply_m29F4414A9D30B7C0CD8455C4B2F049E8CCF66745_inline(L_113, L_114, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_116;
		L_116 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_111, L_115, NULL);
		V_2 = L_116;
		float L_117 = ___deltaTime1;
		if ((!(((float)L_117) >= ((float)(0.0f)))))
		{
			goto IL_02c1;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_118;
		L_118 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_118);
		bool L_119;
		L_119 = VirtualFuncInvoker0< bool >::Invoke(31, L_118);
		G_B34_0 = ((int32_t)(L_119));
		goto IL_02c2;
	}

IL_02c1:
	{
		G_B34_0 = 0;
	}

IL_02c2:
	{
		V_19 = (bool)G_B34_0;
		bool L_120 = V_19;
		if (!L_120)
		{
			goto IL_032a;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_121 = __this->___m_PreviousCameraPosition_21;
		V_20 = L_121;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_122 = V_20;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_123 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_124;
		L_124 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_122, L_123, NULL);
		V_21 = L_124;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_125 = V_21;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_126 = V_4;
		float L_127;
		L_127 = Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline(L_125, L_126, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_128 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_129;
		L_129 = Vector3_op_Multiply_m29F4414A9D30B7C0CD8455C4B2F049E8CCF66745_inline(L_127, L_128, NULL);
		V_22 = L_129;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_130 = V_21;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_131 = V_22;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_132;
		L_132 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_130, L_131, NULL);
		V_23 = L_132;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_133 = V_23;
		float L_134 = __this->___m_XDamping_11;
		float L_135 = ___deltaTime1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_136;
		L_136 = Damper_Damp_mF0862EDA3BDC1B7119E3E6310B12B2DA72420E47(L_133, L_134, L_135, NULL);
		V_23 = L_136;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_137 = V_22;
		float L_138 = __this->___m_YDamping_12;
		float L_139 = ___deltaTime1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_140;
		L_140 = Damper_Damp_mF0862EDA3BDC1B7119E3E6310B12B2DA72420E47(L_137, L_138, L_139, NULL);
		V_22 = L_140;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_141 = V_20;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_142 = V_23;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_143 = V_22;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_144;
		L_144 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_142, L_143, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_145;
		L_145 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_141, L_144, NULL);
		V_2 = L_145;
	}

IL_032a:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_146 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_147 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_148 = L_147;
		V_24 = L_148;
		__this->___m_PreviousCameraPosition_21 = L_148;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_149 = V_24;
		L_146->___RawPosition_4 = L_149;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_150 = V_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_151 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_152 = L_151->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_153;
		L_153 = CinemachineTrackedDolly_GetCameraOrientationAtPathPoint_m8F4DB6F44E986BE7FC8C2C55FCC1556995DB4D54(__this, L_150, L_152, NULL);
		V_6 = L_153;
		float L_154 = ___deltaTime1;
		if ((!(((float)L_154) >= ((float)(0.0f)))))
		{
			goto IL_0360;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_155;
		L_155 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_155);
		bool L_156;
		L_156 = VirtualFuncInvoker0< bool >::Invoke(31, L_155);
		G_B39_0 = ((int32_t)(L_156));
		goto IL_0361;
	}

IL_0360:
	{
		G_B39_0 = 0;
	}

IL_0361:
	{
		V_25 = (bool)G_B39_0;
		bool L_157 = V_25;
		if (!L_157)
		{
			goto IL_03fa;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_158 = __this->___m_PreviousOrientation_20;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_159;
		L_159 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_158, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_160 = V_6;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_161;
		L_161 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_159, L_160, NULL);
		V_27 = L_161;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_162;
		L_162 = Quaternion_get_eulerAngles_m2DB5158B5C3A71FD60FC8A6EE43D3AAA1CFED122_inline((&V_27), NULL);
		V_26 = L_162;
		V_28 = 0;
		goto IL_03ca;
	}

IL_038d:
	{
		int32_t L_163 = V_28;
		float L_164;
		L_164 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline((&V_26), L_163, NULL);
		V_29 = (bool)((((float)L_164) > ((float)(180.0f)))? 1 : 0);
		bool L_165 = V_29;
		if (!L_165)
		{
			goto IL_03c4;
		}
	}
	{
		V_30 = (&V_26);
		int32_t L_166 = V_28;
		V_31 = L_166;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_167 = V_30;
		int32_t L_168 = V_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_169 = V_30;
		int32_t L_170 = V_31;
		float L_171;
		L_171 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_169, L_170, NULL);
		Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline(L_167, L_168, ((float)il2cpp_codegen_subtract(L_171, (360.0f))), NULL);
	}

IL_03c4:
	{
		int32_t L_172 = V_28;
		V_28 = ((int32_t)il2cpp_codegen_add(L_172, 1));
	}

IL_03ca:
	{
		int32_t L_173 = V_28;
		V_32 = (bool)((((int32_t)L_173) < ((int32_t)3))? 1 : 0);
		bool L_174 = V_32;
		if (L_174)
		{
			goto IL_038d;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_175 = V_26;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_176;
		L_176 = CinemachineTrackedDolly_get_AngularDamping_m5ED59BCFD88587E5AF232BB5D779B3FE03832DE9(__this, NULL);
		float L_177 = ___deltaTime1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_178;
		L_178 = Damper_Damp_mC9AFD35CB8F0ADFC8A169489A0F839CE52891D62(L_175, L_176, L_177, NULL);
		V_26 = L_178;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_179 = __this->___m_PreviousOrientation_20;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_180 = V_26;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_181;
		L_181 = Quaternion_Euler_m66E346161C9778DF8486DB4FE823D8F81A54AF1D_inline(L_180, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_182;
		L_182 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_179, L_181, NULL);
		V_6 = L_182;
	}

IL_03fa:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_183 = V_6;
		__this->___m_PreviousOrientation_20 = L_183;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_184 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_185 = V_6;
		L_184->___RawOrientation_5 = L_185;
		int32_t L_186 = __this->___m_CameraUp_14;
		V_33 = (bool)((!(((uint32_t)L_186) <= ((uint32_t)0)))? 1 : 0);
		bool L_187 = V_33;
		if (!L_187)
		{
			goto IL_042f;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_188 = ___curState0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_189 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_190 = L_189->___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_191;
		L_191 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_192;
		L_192 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_190, L_191, NULL);
		L_188->___ReferenceUp_1 = L_192;
	}

IL_042f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CinemachineTrackedDolly_GetCameraOrientationAtPathPoint_m8F4DB6F44E986BE7FC8C2C55FCC1556995DB4D54 (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___pathOrientation0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_2;
	memset((&V_2), 0, sizeof(V_2));
	bool V_3 = false;
	bool V_4 = false;
	{
		int32_t L_0 = __this->___m_CameraUp_14;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_0026;
			}
			case 1:
			{
				goto IL_0028;
			}
			case 2:
			{
				goto IL_002c;
			}
			case 3:
			{
				goto IL_0040;
			}
			case 4:
			{
				goto IL_005b;
			}
		}
	}
	{
		goto IL_0026;
	}

IL_0026:
	{
		goto IL_0088;
	}

IL_0028:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3 = ___pathOrientation0;
		V_2 = L_3;
		goto IL_00ab;
	}

IL_002c:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4 = ___pathOrientation0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		L_5 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_4, L_5, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_8;
		L_8 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_6, L_7, NULL);
		V_2 = L_8;
		goto IL_00ab;
	}

IL_0040:
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_9;
		L_9 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_10;
		L_10 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_9, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_3 = L_10;
		bool L_11 = V_3;
		if (!L_11)
		{
			goto IL_0059;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12;
		L_12 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		V_2 = L_12;
		goto IL_00ab;
	}

IL_0059:
	{
		goto IL_0088;
	}

IL_005b:
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_13;
		L_13 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_14;
		L_14 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_13, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_4 = L_14;
		bool L_15 = V_4;
		if (!L_15)
		{
			goto IL_0086;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_16;
		L_16 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		L_17 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_16, L_17, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20;
		L_20 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_18, L_19, NULL);
		V_2 = L_20;
		goto IL_00ab;
	}

IL_0086:
	{
		goto IL_0088;
	}

IL_0088:
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_21;
		L_21 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_21);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_22;
		L_22 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_21, NULL);
		NullCheck(L_22);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_23;
		L_23 = Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C(L_22, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_23, L_24, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_27;
		L_27 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_25, L_26, NULL);
		V_2 = L_27;
		goto IL_00ab;
	}

IL_00ab:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_28 = V_2;
		return L_28;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTrackedDolly_get_AngularDamping_m5ED59BCFD88587E5AF232BB5D779B3FE03832DE9 (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		int32_t L_0 = __this->___m_CameraUp_14;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_003f;
			}
			case 1:
			{
				goto IL_0047;
			}
			case 2:
			{
				goto IL_0026;
			}
			case 3:
			{
				goto IL_0047;
			}
			case 4:
			{
				goto IL_0026;
			}
		}
	}
	{
		goto IL_0047;
	}

IL_0026:
	{
		float L_3 = __this->___m_PitchDamping_15;
		float L_4 = __this->___m_YawDamping_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		memset((&L_5), 0, sizeof(L_5));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_5), L_3, L_4, (0.0f), NULL);
		V_2 = L_5;
		goto IL_0061;
	}

IL_003f:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_2 = L_6;
		goto IL_0061;
	}

IL_0047:
	{
		float L_7 = __this->___m_PitchDamping_15;
		float L_8 = __this->___m_YawDamping_16;
		float L_9 = __this->___m_RollDamping_17;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10;
		memset((&L_10), 0, sizeof(L_10));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_10), L_7, L_8, L_9, NULL);
		V_2 = L_10;
		goto IL_0061;
	}

IL_0061:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = V_2;
		return L_11;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTrackedDolly__ctor_m632C7211074603AA91B9313A426A224C1E9490ED (CinemachineTrackedDolly_tF6AD39CDE4ECE4A1828476535B327CF2EF9D4037* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_PositionUnits_9 = 0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_PathOffset_10 = L_0;
		__this->___m_XDamping_11 = (0.0f);
		__this->___m_YDamping_12 = (0.0f);
		__this->___m_ZDamping_13 = (1.0f);
		__this->___m_CameraUp_14 = 0;
		__this->___m_PitchDamping_15 = (0.0f);
		__this->___m_YawDamping_16 = (0.0f);
		__this->___m_RollDamping_17 = (0.0f);
		AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115 L_1;
		memset((&L_1), 0, sizeof(L_1));
		AutoDolly__ctor_m8DEA29EE4AE5C67F12B07FB0C51EEC0810FDDF20((&L_1), (bool)0, (0.0f), 2, 5, NULL);
		__this->___m_AutoDolly_18 = L_1;
		__this->___m_PreviousPathPosition_19 = (0.0f);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2;
		L_2 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		__this->___m_PreviousOrientation_20 = L_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_PreviousCameraPosition_21 = L_3;
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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
IL2CPP_EXTERN_C void AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshal_pinvoke(const AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115& unmarshaled, AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_pinvoke& marshaled)
{
	marshaled.___m_Enabled_0 = static_cast<int32_t>(unmarshaled.___m_Enabled_0);
	marshaled.___m_PositionOffset_1 = unmarshaled.___m_PositionOffset_1;
	marshaled.___m_SearchRadius_2 = unmarshaled.___m_SearchRadius_2;
	marshaled.___m_SearchResolution_3 = unmarshaled.___m_SearchResolution_3;
}
IL2CPP_EXTERN_C void AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshal_pinvoke_back(const AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_pinvoke& marshaled, AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115& unmarshaled)
{
	bool unmarshaledm_Enabled_temp_0 = false;
	unmarshaledm_Enabled_temp_0 = static_cast<bool>(marshaled.___m_Enabled_0);
	unmarshaled.___m_Enabled_0 = unmarshaledm_Enabled_temp_0;
	float unmarshaledm_PositionOffset_temp_1 = 0.0f;
	unmarshaledm_PositionOffset_temp_1 = marshaled.___m_PositionOffset_1;
	unmarshaled.___m_PositionOffset_1 = unmarshaledm_PositionOffset_temp_1;
	int32_t unmarshaledm_SearchRadius_temp_2 = 0;
	unmarshaledm_SearchRadius_temp_2 = marshaled.___m_SearchRadius_2;
	unmarshaled.___m_SearchRadius_2 = unmarshaledm_SearchRadius_temp_2;
	int32_t unmarshaledm_SearchResolution_temp_3 = 0;
	unmarshaledm_SearchResolution_temp_3 = marshaled.___m_SearchResolution_3;
	unmarshaled.___m_SearchResolution_3 = unmarshaledm_SearchResolution_temp_3;
}
IL2CPP_EXTERN_C void AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshal_pinvoke_cleanup(AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_pinvoke& marshaled)
{
}
IL2CPP_EXTERN_C void AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshal_com(const AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115& unmarshaled, AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_com& marshaled)
{
	marshaled.___m_Enabled_0 = static_cast<int32_t>(unmarshaled.___m_Enabled_0);
	marshaled.___m_PositionOffset_1 = unmarshaled.___m_PositionOffset_1;
	marshaled.___m_SearchRadius_2 = unmarshaled.___m_SearchRadius_2;
	marshaled.___m_SearchResolution_3 = unmarshaled.___m_SearchResolution_3;
}
IL2CPP_EXTERN_C void AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshal_com_back(const AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_com& marshaled, AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115& unmarshaled)
{
	bool unmarshaledm_Enabled_temp_0 = false;
	unmarshaledm_Enabled_temp_0 = static_cast<bool>(marshaled.___m_Enabled_0);
	unmarshaled.___m_Enabled_0 = unmarshaledm_Enabled_temp_0;
	float unmarshaledm_PositionOffset_temp_1 = 0.0f;
	unmarshaledm_PositionOffset_temp_1 = marshaled.___m_PositionOffset_1;
	unmarshaled.___m_PositionOffset_1 = unmarshaledm_PositionOffset_temp_1;
	int32_t unmarshaledm_SearchRadius_temp_2 = 0;
	unmarshaledm_SearchRadius_temp_2 = marshaled.___m_SearchRadius_2;
	unmarshaled.___m_SearchRadius_2 = unmarshaledm_SearchRadius_temp_2;
	int32_t unmarshaledm_SearchResolution_temp_3 = 0;
	unmarshaledm_SearchResolution_temp_3 = marshaled.___m_SearchResolution_3;
	unmarshaled.___m_SearchResolution_3 = unmarshaledm_SearchResolution_temp_3;
}
IL2CPP_EXTERN_C void AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshal_com_cleanup(AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115_marshaled_com& marshaled)
{
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AutoDolly__ctor_m8DEA29EE4AE5C67F12B07FB0C51EEC0810FDDF20 (AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* __this, bool ___enabled0, float ___positionOffset1, int32_t ___searchRadius2, int32_t ___stepsPerSegment3, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___enabled0;
		__this->___m_Enabled_0 = L_0;
		float L_1 = ___positionOffset1;
		__this->___m_PositionOffset_1 = L_1;
		int32_t L_2 = ___searchRadius2;
		__this->___m_SearchRadius_2 = L_2;
		int32_t L_3 = ___stepsPerSegment3;
		__this->___m_SearchResolution_3 = L_3;
		return;
	}
}
IL2CPP_EXTERN_C  void AutoDolly__ctor_m8DEA29EE4AE5C67F12B07FB0C51EEC0810FDDF20_AdjustorThunk (RuntimeObject* __this, bool ___enabled0, float ___positionOffset1, int32_t ___searchRadius2, int32_t ___stepsPerSegment3, const RuntimeMethod* method)
{
	AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AutoDolly_t2A1304C5BB63C2FF83D89FEDB930C94D9ECA0115*>(__this + _offset);
	AutoDolly__ctor_m8DEA29EE4AE5C67F12B07FB0C51EEC0810FDDF20(_thisAdjusted, ___enabled0, ___positionOffset1, ___searchRadius2, ___stepsPerSegment3, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_OnValidate_mFC57EE74F157499D7CAC4D30CC1D7A04ED6FC33E (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25(__this, NULL);
		__this->___m_FollowOffset_8 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineTransposer_get_HideOffsetInInspector_mD7DBED85FE7830CDCD7BD3782022D88EC77F7774 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CHideOffsetInInspectorU3Ek__BackingField_17;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_set_HideOffsetInInspector_m9D1049D2BCA245506F7768F1D1CDF53548FE528F (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___value0;
		__this->___U3CHideOffsetInInspectorU3Ek__BackingField_17 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___m_FollowOffset_8;
		V_0 = L_0;
		int32_t L_1 = __this->___m_BindingMode_7;
		V_1 = (bool)((((int32_t)L_1) == ((int32_t)5))? 1 : 0);
		bool L_2 = V_1;
		if (!L_2)
		{
			goto IL_0036;
		}
	}
	{
		(&V_0)->___x_2 = (0.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = V_0;
		float L_4 = L_3.___z_4;
		float L_5;
		L_5 = fabsf(L_4);
		(&V_0)->___z_4 = ((-L_5));
	}

IL_0036:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = V_0;
		V_2 = L_6;
		goto IL_003a;
	}

IL_003a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = V_2;
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineTransposer_get_IsValid_m700545C70F86F2083F9FD2C1E97DC68FB8FC98C1 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = Behaviour_get_enabled_mAAC9F15E9EBF552217A5AE2681589CC0BFA300C1(__this, NULL);
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_1;
		L_1 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0018;
	}

IL_0017:
	{
		G_B3_0 = 0;
	}

IL_0018:
	{
		V_0 = (bool)G_B3_0;
		goto IL_001b;
	}

IL_001b:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CinemachineTransposer_get_Stage_mAD7ABE84591669BA748174CDB9880821BB0A132C (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 0;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineTransposer_GetMaxDampTime_m91977B2D8B63655ABA75BE4E9EFE6C68A0A5A094 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	float V_4 = 0.0f;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = CinemachineTransposer_get_Damping_m0BD9EBB7534A2DB4AB31AEB2BBAC3DF1D01BF366(__this, NULL);
		V_0 = L_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = CinemachineTransposer_get_AngularDamping_m489A52D7C6AFD2B34710F4E97299EC2A18E5CDBE(__this, NULL);
		V_1 = L_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = V_0;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = V_0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = V_0;
		float L_7 = L_6.___z_4;
		float L_8;
		L_8 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_5, L_7, NULL);
		float L_9;
		L_9 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_3, L_8, NULL);
		V_2 = L_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_1;
		float L_11 = L_10.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = V_1;
		float L_13 = L_12.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = V_1;
		float L_15 = L_14.___z_4;
		float L_16;
		L_16 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_13, L_15, NULL);
		float L_17;
		L_17 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_11, L_16, NULL);
		V_3 = L_17;
		float L_18 = V_2;
		float L_19 = V_3;
		float L_20;
		L_20 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_18, L_19, NULL);
		V_4 = L_20;
		goto IL_0054;
	}

IL_0054:
	{
		float L_21 = V_4;
		return L_21;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_MutateCameraState_m5B36F2ACE48727E2893C57FFEAD3162A6ECCAF65 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_0 = ___curState0;
		float L_1 = ___deltaTime1;
		CinemachineTransposer_InitPrevFrameStateInfo_m5640D1D85D4260B279D374618B009740EF6EC260(__this, L_0, L_1, NULL);
		bool L_2;
		L_2 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_0 = L_2;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0085;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4;
		L_4 = CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25(__this, NULL);
		V_1 = L_4;
		float L_5 = ___deltaTime1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_6 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = L_6->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = V_1;
		CinemachineTransposer_TrackTarget_m509CF4F1D4319A21D55CEAA20802DA09B46E2AC5(__this, L_5, L_7, L_8, (&V_2), (&V_3), NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_9 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_9, L_10, NULL);
		V_1 = L_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		V_4 = L_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = V_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_16 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_17 = L_16->___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19;
		L_19 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_17, L_18, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_20 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = L_20->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = CinemachineTransposer_GetOffsetForMinimumTargetDistance_m3AF6061743759E9C4BF3280862AA8841449A3172(__this, L_14, L_15, L_19, L_21, L_22, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_13, L_23, NULL);
		V_2 = L_24;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_25 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28;
		L_28 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_26, L_27, NULL);
		L_25->___RawPosition_4 = L_28;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_29 = ___curState0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_30 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31;
		L_31 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_30, L_31, NULL);
		L_29->___ReferenceUp_1 = L_32;
	}

IL_0085:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_OnTargetObjectWarped_m9E0D9DA06D752FF81CB08EDE999759FF47DEF741 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positionDelta1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_0 = ___target0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___positionDelta1;
		CinemachineComponentBase_OnTargetObjectWarped_m3E083DBF03C47860948F0BB3A013B241AFDAF9A0(__this, L_0, L_1, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2 = ___target0;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3;
		L_3 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_2, L_3, NULL);
		V_0 = L_4;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_002c;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = __this->___m_PreviousTargetPosition_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___positionDelta1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_6, L_7, NULL);
		__this->___m_PreviousTargetPosition_18 = L_8;
	}

IL_002c:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_ForceCameraPosition_m8E10E86DEDAF9FE53266FDB72F53E6D2083965B4 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pos0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rot1, const RuntimeMethod* method) 
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 G_B3_0;
	memset((&G_B3_0), 0, sizeof(G_B3_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___pos0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = ___rot1;
		CinemachineComponentBase_ForceCameraPosition_m3D22002EC0B4F5C1AF7CC283C00BA43D22120878(__this, L_0, L_1, NULL);
		int32_t L_2 = __this->___m_BindingMode_7;
		if ((((int32_t)L_2) == ((int32_t)5)))
		{
			goto IL_002b;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_3;
		L_3 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_3);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_4;
		L_4 = VirtualFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(25, L_3);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = L_4.___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_6;
		L_6 = CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE(__this, L_5, NULL);
		G_B3_0 = L_6;
		goto IL_002c;
	}

IL_002b:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_7 = ___rot1;
		G_B3_0 = L_7;
	}

IL_002c:
	{
		V_0 = G_B3_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___pos0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_9 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10;
		L_10 = CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_9, L_10, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_8, L_11, NULL);
		__this->___m_PreviousTargetPosition_18 = L_12;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_InitPrevFrameStateInfo_m5640D1D85D4260B279D374618B009740EF6EC260 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* ___curState0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B6_0 = 0;
	{
		float L_0 = ___deltaTime1;
		if ((!(((float)L_0) >= ((float)(0.0f)))))
		{
			goto IL_0016;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_1;
		L_1 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_1);
		bool L_2;
		L_2 = VirtualFuncInvoker0< bool >::Invoke(31, L_1);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0017;
	}

IL_0016:
	{
		G_B3_0 = 0;
	}

IL_0017:
	{
		V_0 = (bool)G_B3_0;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3 = __this->___m_previousTarget_22;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_4;
		L_4 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_5;
		L_5 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_3, L_4, NULL);
		if (L_5)
		{
			goto IL_0031;
		}
	}
	{
		bool L_6 = V_0;
		G_B6_0 = ((((int32_t)L_6) == ((int32_t)0))? 1 : 0);
		goto IL_0032;
	}

IL_0031:
	{
		G_B6_0 = 1;
	}

IL_0032:
	{
		V_1 = (bool)G_B6_0;
		bool L_7 = V_1;
		if (!L_7)
		{
			goto IL_0050;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_8;
		L_8 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		__this->___m_previousTarget_22 = L_8;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_previousTarget_22), (void*)L_8);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_9;
		L_9 = CinemachineComponentBase_get_FollowTargetRotation_m9C7A5F1A91CCBC93B69F934060F9D4C08FA547F3(__this, NULL);
		__this->___m_targetOrientationOnAssign_20 = L_9;
	}

IL_0050:
	{
		bool L_10 = V_0;
		V_2 = (bool)((((int32_t)L_10) == ((int32_t)0))? 1 : 0);
		bool L_11 = V_2;
		if (!L_11)
		{
			goto IL_0078;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		__this->___m_PreviousTargetPosition_18 = L_12;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* L_13 = ___curState0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = L_13->___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_15;
		L_15 = CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE(__this, L_14, NULL);
		__this->___m_PreviousReferenceOrientation_19 = L_15;
	}

IL_0078:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer_TrackTarget_m509CF4F1D4319A21D55CEAA20802DA09B46E2AC5 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, float ___deltaTime0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___desiredCameraOffset2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___outTargetPosition3, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* ___outTargetOrient4, const RuntimeMethod* method) 
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_5;
	memset((&V_5), 0, sizeof(V_5));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_7;
	memset((&V_7), 0, sizeof(V_7));
	bool V_8 = false;
	bool V_9 = false;
	float V_10 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_11;
	memset((&V_11), 0, sizeof(V_11));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_12;
	memset((&V_12), 0, sizeof(V_12));
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* V_16 = NULL;
	int32_t V_17 = 0;
	bool V_18 = false;
	bool V_19 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_20;
	memset((&V_20), 0, sizeof(V_20));
	bool V_21 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_22;
	memset((&V_22), 0, sizeof(V_22));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_23;
	memset((&V_23), 0, sizeof(V_23));
	bool V_24 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_25;
	memset((&V_25), 0, sizeof(V_25));
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B21_0;
	memset((&G_B21_0), 0, sizeof(G_B21_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1;
		L_1 = CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE(__this, L_0, NULL);
		V_0 = L_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2 = V_0;
		V_1 = L_2;
		float L_3 = ___deltaTime0;
		if ((!(((float)L_3) >= ((float)(0.0f)))))
		{
			goto IL_0020;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_4;
		L_4 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_4);
		bool L_5;
		L_5 = VirtualFuncInvoker0< bool >::Invoke(31, L_4);
		G_B3_0 = ((int32_t)(L_5));
		goto IL_0021;
	}

IL_0020:
	{
		G_B3_0 = 0;
	}

IL_0021:
	{
		V_2 = (bool)G_B3_0;
		bool L_6 = V_2;
		V_8 = L_6;
		bool L_7 = V_8;
		if (!L_7)
		{
			goto IL_013a;
		}
	}
	{
		int32_t L_8 = __this->___m_AngularDampingMode_12;
		if ((!(((uint32_t)L_8) == ((uint32_t)1))))
		{
			goto IL_0041;
		}
	}
	{
		int32_t L_9 = __this->___m_BindingMode_7;
		G_B7_0 = ((((int32_t)L_9) == ((int32_t)3))? 1 : 0);
		goto IL_0042;
	}

IL_0041:
	{
		G_B7_0 = 0;
	}

IL_0042:
	{
		V_9 = (bool)G_B7_0;
		bool L_10 = V_9;
		if (!L_10)
		{
			goto IL_0077;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_11;
		L_11 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		float L_12 = __this->___m_AngularDamping_16;
		float L_13 = ___deltaTime0;
		NullCheck(L_11);
		float L_14;
		L_14 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m215A089B8451330FA8D7D6E4DB8E38400AD9E7CF(L_11, (1.0f), L_12, L_13, NULL);
		V_10 = L_14;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_15 = __this->___m_PreviousReferenceOrientation_19;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_16 = V_0;
		float L_17 = V_10;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_18;
		L_18 = Quaternion_Slerp_m5FDA8C178E7EB209B43845F73263AFE9C02F3949(L_15, L_16, L_17, NULL);
		V_1 = L_18;
		goto IL_0139;
	}

IL_0077:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_19 = __this->___m_PreviousReferenceOrientation_19;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20;
		L_20 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_19, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_21 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_22;
		L_22 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_20, L_21, NULL);
		V_12 = L_22;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		L_23 = Quaternion_get_eulerAngles_m2DB5158B5C3A71FD60FC8A6EE43D3AAA1CFED122_inline((&V_12), NULL);
		V_11 = L_23;
		V_13 = 0;
		goto IL_0104;
	}

IL_0099:
	{
		int32_t L_24 = V_13;
		float L_25;
		L_25 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline((&V_11), L_24, NULL);
		float L_26;
		L_26 = fabsf(L_25);
		V_14 = (bool)((((float)L_26) < ((float)(0.00999999978f)))? 1 : 0);
		bool L_27 = V_14;
		if (!L_27)
		{
			goto IL_00c6;
		}
	}
	{
		int32_t L_28 = V_13;
		Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline((&V_11), L_28, (0.0f), NULL);
		goto IL_00fd;
	}

IL_00c6:
	{
		int32_t L_29 = V_13;
		float L_30;
		L_30 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline((&V_11), L_29, NULL);
		V_15 = (bool)((((float)L_30) > ((float)(180.0f)))? 1 : 0);
		bool L_31 = V_15;
		if (!L_31)
		{
			goto IL_00fd;
		}
	}
	{
		V_16 = (&V_11);
		int32_t L_32 = V_13;
		V_17 = L_32;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_33 = V_16;
		int32_t L_34 = V_17;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_35 = V_16;
		int32_t L_36 = V_17;
		float L_37;
		L_37 = Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline(L_35, L_36, NULL);
		Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline(L_33, L_34, ((float)il2cpp_codegen_subtract(L_37, (360.0f))), NULL);
	}

IL_00fd:
	{
		int32_t L_38 = V_13;
		V_13 = ((int32_t)il2cpp_codegen_add(L_38, 1));
	}

IL_0104:
	{
		int32_t L_39 = V_13;
		V_18 = (bool)((((int32_t)L_39) < ((int32_t)3))? 1 : 0);
		bool L_40 = V_18;
		if (L_40)
		{
			goto IL_0099;
		}
	}
	{
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_41;
		L_41 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42 = V_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43;
		L_43 = CinemachineTransposer_get_AngularDamping_m489A52D7C6AFD2B34710F4E97299EC2A18E5CDBE(__this, NULL);
		float L_44 = ___deltaTime0;
		NullCheck(L_41);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45;
		L_45 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m871E131EE59CEEC1B5691F5DC570B18816530C97(L_41, L_42, L_43, L_44, NULL);
		V_11 = L_45;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_46 = __this->___m_PreviousReferenceOrientation_19;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47 = V_11;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_48;
		L_48 = Quaternion_Euler_m66E346161C9778DF8486DB4FE823D8F81A54AF1D_inline(L_47, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_49;
		L_49 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_46, L_48, NULL);
		V_1 = L_49;
	}

IL_0139:
	{
	}

IL_013a:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_50 = V_1;
		__this->___m_PreviousReferenceOrientation_19 = L_50;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51;
		L_51 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		V_3 = L_51;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_52 = __this->___m_PreviousTargetPosition_18;
		V_4 = L_52;
		bool L_53 = V_2;
		if (L_53)
		{
			goto IL_0156;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_54 = ___desiredCameraOffset2;
		G_B21_0 = L_54;
		goto IL_015c;
	}

IL_0156:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_55 = __this->___m_PreviousOffset_21;
		G_B21_0 = L_55;
	}

IL_015c:
	{
		V_5 = G_B21_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_56 = ___desiredCameraOffset2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_57 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_58;
		L_58 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_56, L_57, NULL);
		V_6 = L_58;
		float L_59;
		L_59 = Vector3_get_sqrMagnitude_m43C27DEC47C4811FB30AB474FF2131A963B66FC8_inline((&V_6), NULL);
		V_19 = (bool)((((float)L_59) > ((float)(0.00999999978f)))? 1 : 0);
		bool L_60 = V_19;
		if (!L_60)
		{
			goto IL_01b4;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_61 = __this->___m_PreviousOffset_21;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_62 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_63;
		L_63 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_61, L_62, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_64 = ___desiredCameraOffset2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_65 = ___up1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_66;
		L_66 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_64, L_65, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_67 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_68;
		L_68 = UnityVectorExtensions_SafeFromToRotation_mD10BFD5052B69EE3D1DE2FE9B74181BD797ACC03(L_63, L_66, L_67, NULL);
		V_20 = L_68;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_69 = V_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_70 = V_20;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_71 = __this->___m_PreviousTargetPosition_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_72 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_73;
		L_73 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_71, L_72, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_74;
		L_74 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_70, L_73, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_75;
		L_75 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_69, L_74, NULL);
		V_4 = L_75;
	}

IL_01b4:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_76 = ___desiredCameraOffset2;
		__this->___m_PreviousOffset_21 = L_76;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_77 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_78 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79;
		L_79 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_77, L_78, NULL);
		V_7 = L_79;
		bool L_80 = V_2;
		V_21 = L_80;
		bool L_81 = V_21;
		if (!L_81)
		{
			goto IL_0229;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_82 = ___desiredCameraOffset2;
		bool L_83;
		L_83 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_82, NULL);
		V_24 = L_83;
		bool L_84 = V_24;
		if (!L_84)
		{
			goto IL_01e8;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_85;
		L_85 = CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2(__this, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_86 = L_85.___RawOrientation_5;
		V_22 = L_86;
		goto IL_01f7;
	}

IL_01e8:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_87 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_88 = ___desiredCameraOffset2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_89;
		L_89 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_87, L_88, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_90 = ___up1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_91;
		L_91 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_89, L_90, NULL);
		V_22 = L_91;
	}

IL_01f7:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_92 = V_22;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_93;
		L_93 = Quaternion_Inverse_m7597DECDAD37194FAC86D1A11DCE3F0C7747F817(L_92, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_94 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_95;
		L_95 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_93, L_94, NULL);
		V_23 = L_95;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_96;
		L_96 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_97 = V_23;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_98;
		L_98 = CinemachineTransposer_get_Damping_m0BD9EBB7534A2DB4AB31AEB2BBAC3DF1D01BF366(__this, NULL);
		float L_99 = ___deltaTime0;
		NullCheck(L_96);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_100;
		L_100 = CinemachineVirtualCameraBase_DetachedFollowTargetDamp_m871E131EE59CEEC1B5691F5DC570B18816530C97(L_96, L_97, L_98, L_99, NULL);
		V_23 = L_100;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_101 = V_22;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_102 = V_23;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_103;
		L_103 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_101, L_102, NULL);
		V_7 = L_103;
	}

IL_0229:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_104 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_105 = V_7;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_106;
		L_106 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_104, L_105, NULL);
		V_4 = L_106;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_107 = ___outTargetPosition3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_108 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_109 = L_108;
		V_25 = L_109;
		__this->___m_PreviousTargetPosition_18 = L_109;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_110 = V_25;
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_107 = L_110;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_111 = ___outTargetOrient4;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_112 = V_1;
		*(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)L_111 = L_112;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_GetOffsetForMinimumTargetDistance_m3AF6061743759E9C4BF3280862AA8841449A3172 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___dampedTargetPos0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___cameraOffset1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___cameraFwd2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up3, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___actualTargetPos4, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	float V_2 = 0.0f;
	bool V_3 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	float V_5 = 0.0f;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	bool V_7 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_8;
	memset((&V_8), 0, sizeof(V_8));
	float V_9 = 0.0f;
	bool V_10 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_11;
	memset((&V_11), 0, sizeof(V_11));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_0 = L_0;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_1;
		L_1 = CinemachineComponentBase_get_VirtualCamera_mB83A44E630B22D8CD9A75521079ABC1691120223(__this, NULL);
		NullCheck(L_1);
		float L_2 = L_1->___FollowTargetAttachment_12;
		V_1 = (bool)((((float)L_2) > ((float)(0.999899983f)))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_00f3;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___cameraOffset1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = ___up3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_4, L_5, NULL);
		___cameraOffset1 = L_6;
		float L_7;
		L_7 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&___cameraOffset1), NULL);
		V_2 = ((float)il2cpp_codegen_multiply(L_7, (0.200000003f)));
		float L_8 = V_2;
		V_3 = (bool)((((float)L_8) > ((float)(0.0f)))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_00f2;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___actualTargetPos4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = ___up3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_10, L_11, NULL);
		___actualTargetPos4 = L_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = ___dampedTargetPos0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = ___up3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15;
		L_15 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_13, L_14, NULL);
		___dampedTargetPos0 = L_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = ___dampedTargetPos0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = ___cameraOffset1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_16, L_17, NULL);
		V_4 = L_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = ___actualTargetPos4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21;
		L_21 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_19, L_20, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = ___dampedTargetPos0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_22, L_23, NULL);
		V_6 = L_24;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = Vector3_get_normalized_m736BBF65D5CDA7A18414370D15B4DFCC1E466F07_inline((&V_6), NULL);
		float L_26;
		L_26 = Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline(L_21, L_25, NULL);
		V_5 = L_26;
		float L_27 = V_5;
		float L_28 = V_2;
		V_7 = (bool)((((float)L_27) < ((float)L_28))? 1 : 0);
		bool L_29 = V_7;
		if (!L_29)
		{
			goto IL_00df;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30 = ___actualTargetPos4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = ___dampedTargetPos0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_30, L_31, NULL);
		V_8 = L_32;
		float L_33;
		L_33 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_8), NULL);
		V_9 = L_33;
		float L_34 = V_9;
		V_10 = (bool)((((float)L_34) < ((float)(0.00999999978f)))? 1 : 0);
		bool L_35 = V_10;
		if (!L_35)
		{
			goto IL_00c7;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36 = ___cameraFwd2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_37 = ___up3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38;
		L_38 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_36, L_37, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39;
		L_39 = Vector3_op_UnaryNegation_m3AC523A7BED6E843165BDF598690F0560D8CAA63_inline(L_38, NULL);
		V_8 = L_39;
		goto IL_00d2;
	}

IL_00c7:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40 = V_8;
		float L_41 = V_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42;
		L_42 = Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline(L_40, L_41, NULL);
		V_8 = L_42;
	}

IL_00d2:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43 = V_8;
		float L_44 = V_2;
		float L_45 = V_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46;
		L_46 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_43, ((float)il2cpp_codegen_subtract(L_44, L_45)), NULL);
		V_0 = L_46;
	}

IL_00df:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47 = __this->___m_PreviousTargetPosition_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_48 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49;
		L_49 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_47, L_48, NULL);
		__this->___m_PreviousTargetPosition_18 = L_49;
	}

IL_00f2:
	{
	}

IL_00f3:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50 = V_0;
		V_11 = L_50;
		goto IL_00f8;
	}

IL_00f8:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51 = V_11;
		return L_51;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_get_Damping_m0BD9EBB7534A2DB4AB31AEB2BBAC3DF1D01BF366 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		int32_t L_0 = __this->___m_BindingMode_7;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) == ((int32_t)5)))
		{
			goto IL_0010;
		}
	}
	{
		goto IL_0029;
	}

IL_0010:
	{
		float L_3 = __this->___m_YDamping_10;
		float L_4 = __this->___m_ZDamping_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		memset((&L_5), 0, sizeof(L_5));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_5), (0.0f), L_3, L_4, NULL);
		V_2 = L_5;
		goto IL_0043;
	}

IL_0029:
	{
		float L_6 = __this->___m_XDamping_9;
		float L_7 = __this->___m_YDamping_10;
		float L_8 = __this->___m_ZDamping_11;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_9), L_6, L_7, L_8, NULL);
		V_2 = L_9;
		goto IL_0043;
	}

IL_0043:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_2;
		return L_10;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_get_AngularDamping_m489A52D7C6AFD2B34710F4E97299EC2A18E5CDBE (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		int32_t L_0 = __this->___m_BindingMode_7;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_005b;
			}
			case 1:
			{
				goto IL_0043;
			}
			case 2:
			{
				goto IL_002a;
			}
			case 3:
			{
				goto IL_0063;
			}
			case 4:
			{
				goto IL_005b;
			}
			case 5:
			{
				goto IL_005b;
			}
		}
	}
	{
		goto IL_0063;
	}

IL_002a:
	{
		float L_3 = __this->___m_PitchDamping_13;
		float L_4 = __this->___m_YawDamping_14;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		memset((&L_5), 0, sizeof(L_5));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_5), L_3, L_4, (0.0f), NULL);
		V_2 = L_5;
		goto IL_007d;
	}

IL_0043:
	{
		float L_6 = __this->___m_YawDamping_14;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		memset((&L_7), 0, sizeof(L_7));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_7), (0.0f), L_6, (0.0f), NULL);
		V_2 = L_7;
		goto IL_007d;
	}

IL_005b:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_2 = L_8;
		goto IL_007d;
	}

IL_0063:
	{
		float L_9 = __this->___m_PitchDamping_13;
		float L_10 = __this->___m_YawDamping_14;
		float L_11 = __this->___m_RollDamping_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_12), L_9, L_10, L_11, NULL);
		V_2 = L_12;
		goto IL_007d;
	}

IL_007d:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = V_2;
		return L_13;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineTransposer_GetTargetCameraPosition_m504AE0BA123B7A208257661232FF2A40AB408B92 (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(4, __this);
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0016;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_1 = L_2;
		goto IL_0036;
	}

IL_0016:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___worldUp0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_5;
		L_5 = CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE(__this, L_4, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = CinemachineTransposer_get_EffectiveOffset_mF79BE447AD9A91A1829011B346B5AF18F6E1CE25(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_5, L_6, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_3, L_7, NULL);
		V_1 = L_8;
		goto IL_0036;
	}

IL_0036:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = V_1;
		return L_9;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CinemachineTransposer_GetReferenceOrientation_m3CBF0CBBB1639E68901C407E2A6A739D079915AE (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_3;
	memset((&V_3), 0, sizeof(V_3));
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	bool V_7 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_8;
	memset((&V_8), 0, sizeof(V_8));
	bool V_9 = false;
	{
		int32_t L_0 = __this->___m_BindingMode_7;
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)4))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0019;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2;
		L_2 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		V_1 = L_2;
		goto IL_0103;
	}

IL_0019:
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_3;
		L_3 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_3, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_2 = L_4;
		bool L_5 = V_2;
		if (!L_5)
		{
			goto IL_00f5;
		}
	}
	{
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_6;
		L_6 = CinemachineComponentBase_get_FollowTarget_m656475012F330FF1C680CD7E62C81D2E7EC4AB74(__this, NULL);
		NullCheck(L_6);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_7;
		L_7 = Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C(L_6, NULL);
		V_3 = L_7;
		int32_t L_8 = __this->___m_BindingMode_7;
		V_5 = L_8;
		int32_t L_9 = V_5;
		V_4 = L_9;
		int32_t L_10 = V_4;
		switch (L_10)
		{
			case 0:
			{
				goto IL_0069;
			}
			case 1:
			{
				goto IL_0075;
			}
			case 2:
			{
				goto IL_00a3;
			}
			case 3:
			{
				goto IL_00b7;
			}
			case 4:
			{
				goto IL_00f4;
			}
			case 5:
			{
				goto IL_00bb;
			}
		}
	}
	{
		goto IL_00f4;
	}

IL_0069:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_11 = __this->___m_targetOrientationOnAssign_20;
		V_1 = L_11;
		goto IL_0103;
	}

IL_0075:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13;
		L_13 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14;
		L_14 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_12, L_13, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = ___worldUp0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16;
		L_16 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_14, L_15, NULL);
		V_6 = L_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = V_6;
		bool L_18;
		L_18 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_17, NULL);
		V_7 = L_18;
		bool L_19 = V_7;
		if (!L_19)
		{
			goto IL_0098;
		}
	}
	{
		goto IL_00f4;
	}

IL_0098:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = ___worldUp0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_22;
		L_22 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_20, L_21, NULL);
		V_1 = L_22;
		goto IL_0103;
	}

IL_00a3:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_23 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		L_24 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_23, L_24, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26 = ___worldUp0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_27;
		L_27 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_25, L_26, NULL);
		V_1 = L_27;
		goto IL_0103;
	}

IL_00b7:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_28 = V_3;
		V_1 = L_28;
		goto IL_0103;
	}

IL_00bb:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29;
		L_29 = CinemachineComponentBase_get_FollowTargetPosition_m1039B11144B61D09459CACDA7A7E38626A601CC2(__this, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_30;
		L_30 = CinemachineComponentBase_get_VcamState_m17C5F4CFD04B41EA7559216C8C50CB980140D9A2(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = L_30.___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_29, L_31, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33 = ___worldUp0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34;
		L_34 = UnityVectorExtensions_ProjectOntoPlane_mBBA5D8DA7E6B626A800731A0FE6BADF7C4220D9B(L_32, L_33, NULL);
		V_8 = L_34;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35 = V_8;
		bool L_36;
		L_36 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_35, NULL);
		V_9 = L_36;
		bool L_37 = V_9;
		if (!L_37)
		{
			goto IL_00e9;
		}
	}
	{
		goto IL_00f4;
	}

IL_00e9:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38 = V_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39 = ___worldUp0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_40;
		L_40 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_38, L_39, NULL);
		V_1 = L_40;
		goto IL_0103;
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* L_41 = (&__this->___m_PreviousReferenceOrientation_19);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_42;
		L_42 = Quaternion_get_normalized_m08AB963B13A0EC6F540A29886C5ACFCCCC0A6D16_inline(L_41, NULL);
		V_1 = L_42;
		goto IL_0103;
	}

IL_0103:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_43 = V_1;
		return L_43;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineTransposer__ctor_m66F1121D2339FDEDC9743EC432749AFB3CA846BC (CinemachineTransposer_t717A803D8D1FD7AECBA2A38489853887E5A1CFF5* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_BindingMode_7 = 1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		L_0 = Vector3_get_back_mBA6E23860A365E6F0F9A2AADC3D19E698687230A_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_0, (10.0f), NULL);
		__this->___m_FollowOffset_8 = L_1;
		__this->___m_XDamping_9 = (1.0f);
		__this->___m_YDamping_10 = (1.0f);
		__this->___m_ZDamping_11 = (1.0f);
		__this->___m_AngularDampingMode_12 = 0;
		__this->___m_PitchDamping_13 = (0.0f);
		__this->___m_YawDamping_14 = (0.0f);
		__this->___m_RollDamping_15 = (0.0f);
		__this->___m_AngularDamping_16 = (0.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		__this->___m_PreviousTargetPosition_18 = L_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3;
		L_3 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		__this->___m_PreviousReferenceOrientation_19 = L_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4;
		L_4 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		__this->___m_targetOrientationOnAssign_20 = L_4;
		__this->___m_previousTarget_22 = (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_previousTarget_22), (void*)(Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)NULL);
		CinemachineComponentBase__ctor_mFA2A3C88B75CD71B7F359220C38B253AC1353B19(__this, NULL);
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


IL2CPP_EXTERN_C void AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshal_pinvoke(const AxisState_t6996FE8143104E02683986C908C18B0F62595736& unmarshaled, AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_InputAxisProvider_16Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_InputAxisProvider' of type 'AxisState': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_InputAxisProvider_16Exception, NULL);
}
IL2CPP_EXTERN_C void AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshal_pinvoke_back(const AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_pinvoke& marshaled, AxisState_t6996FE8143104E02683986C908C18B0F62595736& unmarshaled)
{
	Exception_t* ___m_InputAxisProvider_16Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_InputAxisProvider' of type 'AxisState': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_InputAxisProvider_16Exception, NULL);
}
IL2CPP_EXTERN_C void AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshal_pinvoke_cleanup(AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_pinvoke& marshaled)
{
}


IL2CPP_EXTERN_C void AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshal_com(const AxisState_t6996FE8143104E02683986C908C18B0F62595736& unmarshaled, AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_com& marshaled)
{
	Exception_t* ___m_InputAxisProvider_16Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_InputAxisProvider' of type 'AxisState': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_InputAxisProvider_16Exception, NULL);
}
IL2CPP_EXTERN_C void AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshal_com_back(const AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_com& marshaled, AxisState_t6996FE8143104E02683986C908C18B0F62595736& unmarshaled)
{
	Exception_t* ___m_InputAxisProvider_16Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_InputAxisProvider' of type 'AxisState': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_InputAxisProvider_16Exception, NULL);
}
IL2CPP_EXTERN_C void AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshal_com_cleanup(AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_com& marshaled)
{
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState__ctor_m09348C6ABBA887484BF7D3961D4FB582C0E5A4F6 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___minValue0, float ___maxValue1, bool ___wrap2, bool ___rangeLocked3, float ___maxSpeed4, float ___accelTime5, float ___decelTime6, String_t* ___name7, bool ___invert8, const RuntimeMethod* method) 
{
	{
		float L_0 = ___minValue0;
		__this->___m_MinValue_8 = L_0;
		float L_1 = ___maxValue1;
		__this->___m_MaxValue_9 = L_1;
		bool L_2 = ___wrap2;
		__this->___m_Wrap_10 = L_2;
		bool L_3 = ___rangeLocked3;
		AxisState_set_ValueRangeLocked_m367AD65F7E97A0DFF0DE1CA0C74AEEBCCC36D000_inline(__this, L_3, NULL);
		AxisState_set_HasRecentering_m978B18A62A74813CC75078114997E708B6877D85_inline(__this, (bool)0, NULL);
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF L_4;
		memset((&L_4), 0, sizeof(L_4));
		Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476((&L_4), (bool)0, (1.0f), (2.0f), NULL);
		__this->___m_Recentering_11 = L_4;
		__this->___m_SpeedMode_1 = 0;
		float L_5 = ___maxSpeed4;
		__this->___m_MaxSpeed_2 = L_5;
		float L_6 = ___accelTime5;
		__this->___m_AccelTime_3 = L_6;
		float L_7 = ___decelTime6;
		__this->___m_DecelTime_4 = L_7;
		float L_8 = ___minValue0;
		float L_9 = ___maxValue1;
		__this->___Value_0 = ((float)(((float)il2cpp_codegen_add(L_8, L_9))/(2.0f)));
		String_t* L_10 = ___name7;
		__this->___m_InputAxisName_5 = L_10;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_InputAxisName_5), (void*)L_10);
		__this->___m_InputAxisValue_6 = (0.0f);
		bool L_11 = ___invert8;
		__this->___m_InvertInput_7 = L_11;
		__this->___m_CurrentSpeed_12 = (0.0f);
		__this->___m_InputAxisProvider_16 = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_InputAxisProvider_16), (void*)(RuntimeObject*)NULL);
		__this->___m_InputAxisIndex_17 = 0;
		__this->___m_LastUpdateTime_13 = (0.0f);
		__this->___m_LastUpdateFrame_14 = 0;
		return;
	}
}
IL2CPP_EXTERN_C  void AxisState__ctor_m09348C6ABBA887484BF7D3961D4FB582C0E5A4F6_AdjustorThunk (RuntimeObject* __this, float ___minValue0, float ___maxValue1, bool ___wrap2, bool ___rangeLocked3, float ___maxSpeed4, float ___accelTime5, float ___decelTime6, String_t* ___name7, bool ___invert8, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	AxisState__ctor_m09348C6ABBA887484BF7D3961D4FB582C0E5A4F6(_thisAdjusted, ___minValue0, ___maxValue1, ___wrap2, ___rangeLocked3, ___maxSpeed4, ___accelTime5, ___decelTime6, ___name7, ___invert8, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_Validate_m1245D61F6D9A031C27F75F4B49E78A52AA91BDE5 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0 = __this->___m_SpeedMode_1;
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0024;
		}
	}
	{
		float L_2 = __this->___m_MaxSpeed_2;
		float L_3;
		L_3 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_2, NULL);
		__this->___m_MaxSpeed_2 = L_3;
	}

IL_0024:
	{
		float L_4 = __this->___m_AccelTime_3;
		float L_5;
		L_5 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_4, NULL);
		__this->___m_AccelTime_3 = L_5;
		float L_6 = __this->___m_DecelTime_4;
		float L_7;
		L_7 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_6, NULL);
		__this->___m_DecelTime_4 = L_7;
		float L_8 = __this->___m_MaxValue_9;
		float L_9 = __this->___m_MinValue_8;
		float L_10 = __this->___m_MaxValue_9;
		float L_11;
		L_11 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_8, L_9, L_10, NULL);
		__this->___m_MaxValue_9 = L_11;
		return;
	}
}
IL2CPP_EXTERN_C  void AxisState_Validate_m1245D61F6D9A031C27F75F4B49E78A52AA91BDE5_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	AxisState_Validate_m1245D61F6D9A031C27F75F4B49E78A52AA91BDE5(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_Reset_m329065EBC9963460CD7733144EC5F47D107967C9 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_InputAxisValue_6 = (0.0f);
		__this->___m_CurrentSpeed_12 = (0.0f);
		__this->___m_LastUpdateTime_13 = (0.0f);
		__this->___m_LastUpdateFrame_14 = 0;
		return;
	}
}
IL2CPP_EXTERN_C  void AxisState_Reset_m329065EBC9963460CD7733144EC5F47D107967C9_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	AxisState_Reset_m329065EBC9963460CD7733144EC5F47D107967C9(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, int32_t ___axis0, RuntimeObject* ___provider1, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___axis0;
		__this->___m_InputAxisIndex_17 = L_0;
		RuntimeObject* L_1 = ___provider1;
		__this->___m_InputAxisProvider_16 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_InputAxisProvider_16), (void*)L_1);
		return;
	}
}
IL2CPP_EXTERN_C  void AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85_AdjustorThunk (RuntimeObject* __this, int32_t ___axis0, RuntimeObject* ___provider1, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	AxisState_SetInputAxisProvider_m9FBC0D9C885EDF31C4FFDA8A70029C5FC9089C85(_thisAdjusted, ___axis0, ___provider1, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_get_HasInputProvider_mD82DACE6E188BCFE1B0B5FCB1328BF8FA738B091 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___m_InputAxisProvider_16;
		return (bool)((!(((RuntimeObject*)(RuntimeObject*)L_0) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
	}
}
IL2CPP_EXTERN_C  bool AxisState_get_HasInputProvider_mD82DACE6E188BCFE1B0B5FCB1328BF8FA738B091_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	bool _returnValue;
	_returnValue = AxisState_get_HasInputProvider_mD82DACE6E188BCFE1B0B5FCB1328BF8FA738B091(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_Update_mE86F039B78105160E5C13153B456E3A988AF28B4 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___deltaTime0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IInputAxisProvider_tABB3BFF96A8D4C6D50FA42166CCF7AAF18F959E7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* V_7 = NULL;
	bool V_8 = false;
	bool V_9 = false;
	bool V_10 = false;
	float V_11 = 0.0f;
	float V_12 = 0.0f;
	float V_13 = 0.0f;
	bool V_14 = false;
	float V_15 = 0.0f;
	float V_16 = 0.0f;
	float V_17 = 0.0f;
	bool V_18 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	int32_t G_B7_0 = 0;
	float G_B25_0 = 0.0f;
	int32_t G_B29_0 = 0;
	float G_B33_0 = 0.0f;
	int32_t G_B36_0 = 0;
	{
		int32_t L_0;
		L_0 = Time_get_frameCount_m88E5008FE9451A892DE1F43DC8587213075890A8(NULL);
		int32_t L_1 = __this->___m_LastUpdateFrame_14;
		V_1 = (bool)((((int32_t)L_0) == ((int32_t)L_1))? 1 : 0);
		bool L_2 = V_1;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_0266;
	}

IL_0019:
	{
		int32_t L_3;
		L_3 = Time_get_frameCount_m88E5008FE9451A892DE1F43DC8587213075890A8(NULL);
		__this->___m_LastUpdateFrame_14 = L_3;
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		float L_4 = ((CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_StaticFields*)il2cpp_codegen_static_fields_for(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var))->___UniformDeltaTimeOverride_5;
		V_3 = (bool)((((int32_t)((!(((float)L_4) >= ((float)(0.0f))))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_5 = V_3;
		if (!L_5)
		{
			goto IL_0040;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		float L_6 = ((CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_StaticFields*)il2cpp_codegen_static_fields_for(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var))->___UniformDeltaTimeOverride_5;
		___deltaTime0 = L_6;
		goto IL_006f;
	}

IL_0040:
	{
		float L_7 = ___deltaTime0;
		if ((!(((float)L_7) >= ((float)(0.0f)))))
		{
			goto IL_005a;
		}
	}
	{
		float L_8 = __this->___m_LastUpdateTime_13;
		G_B7_0 = ((((int32_t)((((float)L_8) == ((float)(0.0f)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_005b;
	}

IL_005a:
	{
		G_B7_0 = 0;
	}

IL_005b:
	{
		V_4 = (bool)G_B7_0;
		bool L_9 = V_4;
		if (!L_9)
		{
			goto IL_006f;
		}
	}
	{
		float L_10;
		L_10 = Time_get_time_m0BEE9AACD0723FE414465B77C9C64D12263675F3(NULL);
		float L_11 = __this->___m_LastUpdateTime_13;
		___deltaTime0 = ((float)il2cpp_codegen_subtract(L_10, L_11));
	}

IL_006f:
	{
		float L_12;
		L_12 = Time_get_time_m0BEE9AACD0723FE414465B77C9C64D12263675F3(NULL);
		__this->___m_LastUpdateTime_13 = L_12;
		RuntimeObject* L_13 = __this->___m_InputAxisProvider_16;
		V_5 = (bool)((!(((RuntimeObject*)(RuntimeObject*)L_13) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_14 = V_5;
		if (!L_14)
		{
			goto IL_00a2;
		}
	}
	{
		RuntimeObject* L_15 = __this->___m_InputAxisProvider_16;
		int32_t L_16 = __this->___m_InputAxisIndex_17;
		NullCheck(L_15);
		float L_17;
		L_17 = InterfaceFuncInvoker1< float, int32_t >::Invoke(0, IInputAxisProvider_tABB3BFF96A8D4C6D50FA42166CCF7AAF18F959E7_il2cpp_TypeInfo_var, L_15, L_16);
		__this->___m_InputAxisValue_6 = L_17;
		goto IL_00e5;
	}

IL_00a2:
	{
		String_t* L_18 = __this->___m_InputAxisName_5;
		bool L_19;
		L_19 = String_IsNullOrEmpty_m54CF0907E7C4F3AFB2E796A13DC751ECBB8DB64A(L_18, NULL);
		V_6 = (bool)((((int32_t)L_19) == ((int32_t)0))? 1 : 0);
		bool L_20 = V_6;
		if (!L_20)
		{
			goto IL_00e5;
		}
	}
	{
	}
	try
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		AxisInputDelegate_tE27958ACEDD7816DB591B6F485ACD7083541C452* L_21 = ((CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_StaticFields*)il2cpp_codegen_static_fields_for(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var))->___GetInputAxis_4;
		String_t* L_22 = __this->___m_InputAxisName_5;
		NullCheck(L_21);
		float L_23;
		L_23 = AxisInputDelegate_Invoke_m1C36C70E105C8A9091AED921BB6E7053C99F39CE_inline(L_21, L_22, NULL);
		__this->___m_InputAxisValue_6 = L_23;
		goto IL_00e4;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_00d1;
		}
		throw e;
	}

CATCH_00d1:
	{
		V_7 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_24 = V_7;
		NullCheck(L_24);
		String_t* L_25;
		L_25 = VirtualFuncInvoker0< String_t* >::Invoke(3, L_24);
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var)));
		Debug_LogError_m059825802BB6AF7EA9693FEBEEB0D85F59A3E38E(L_25, NULL);
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_00e4;
	}

IL_00e4:
	{
	}

IL_00e5:
	{
		float L_26 = __this->___m_InputAxisValue_6;
		V_0 = L_26;
		bool L_27 = __this->___m_InvertInput_7;
		V_8 = L_27;
		bool L_28 = V_8;
		if (!L_28)
		{
			goto IL_0100;
		}
	}
	{
		float L_29 = V_0;
		V_0 = ((float)il2cpp_codegen_multiply(L_29, (-1.0f)));
	}

IL_0100:
	{
		int32_t L_30 = __this->___m_SpeedMode_1;
		V_9 = (bool)((((int32_t)L_30) == ((int32_t)0))? 1 : 0);
		bool L_31 = V_9;
		if (!L_31)
		{
			goto IL_011d;
		}
	}
	{
		float L_32 = V_0;
		float L_33 = ___deltaTime0;
		bool L_34;
		L_34 = AxisState_MaxSpeedUpdate_m59BC1A91869A0D4A07E53DA4ED4172D5FBBF1DBD(__this, L_32, L_33, NULL);
		V_2 = L_34;
		goto IL_0266;
	}

IL_011d:
	{
		float L_35 = V_0;
		float L_36 = __this->___m_MaxSpeed_2;
		V_0 = ((float)il2cpp_codegen_multiply(L_35, L_36));
		float L_37 = ___deltaTime0;
		V_10 = (bool)((((float)L_37) < ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_38 = V_10;
		if (!L_38)
		{
			goto IL_0144;
		}
	}
	{
		__this->___m_CurrentSpeed_12 = (0.0f);
		goto IL_0242;
	}

IL_0144:
	{
		float L_39 = V_0;
		float L_40 = ___deltaTime0;
		V_11 = ((float)(L_39/L_40));
		float L_41 = V_11;
		float L_42;
		L_42 = fabsf(L_41);
		float L_43 = __this->___m_CurrentSpeed_12;
		float L_44;
		L_44 = fabsf(L_43);
		if ((((float)L_42) < ((float)L_44)))
		{
			goto IL_0166;
		}
	}
	{
		float L_45 = __this->___m_AccelTime_3;
		G_B25_0 = L_45;
		goto IL_016c;
	}

IL_0166:
	{
		float L_46 = __this->___m_DecelTime_4;
		G_B25_0 = L_46;
	}

IL_016c:
	{
		V_12 = G_B25_0;
		float L_47 = __this->___m_CurrentSpeed_12;
		float L_48 = V_11;
		float L_49 = __this->___m_CurrentSpeed_12;
		float L_50 = V_12;
		float L_51 = ___deltaTime0;
		float L_52;
		L_52 = Damper_Damp_mFB62278C063E2CAA706D30E8D68AF55D50AE95D2(((float)il2cpp_codegen_subtract(L_48, L_49)), L_50, L_51, NULL);
		V_11 = ((float)il2cpp_codegen_add(L_47, L_52));
		float L_53 = V_11;
		__this->___m_CurrentSpeed_12 = L_53;
		float L_54 = __this->___m_MaxValue_9;
		float L_55 = __this->___m_MinValue_8;
		V_13 = ((float)il2cpp_codegen_subtract(L_54, L_55));
		bool L_56 = __this->___m_Wrap_10;
		if (L_56)
		{
			goto IL_01bf;
		}
	}
	{
		float L_57 = __this->___m_DecelTime_4;
		if ((!(((float)L_57) > ((float)(9.99999975E-05f)))))
		{
			goto IL_01bf;
		}
	}
	{
		float L_58 = V_13;
		G_B29_0 = ((((float)L_58) > ((float)(9.99999975E-05f)))? 1 : 0);
		goto IL_01c0;
	}

IL_01bf:
	{
		G_B29_0 = 0;
	}

IL_01c0:
	{
		V_14 = (bool)G_B29_0;
		bool L_59 = V_14;
		if (!L_59)
		{
			goto IL_023c;
		}
	}
	{
		float L_60 = __this->___Value_0;
		float L_61;
		L_61 = AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F(__this, L_60, NULL);
		V_15 = L_61;
		float L_62 = V_15;
		float L_63 = V_11;
		float L_64 = ___deltaTime0;
		float L_65;
		L_65 = AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F(__this, ((float)il2cpp_codegen_add(L_62, ((float)il2cpp_codegen_multiply(L_63, L_64)))), NULL);
		V_16 = L_65;
		float L_66 = V_11;
		if ((((float)L_66) > ((float)(0.0f))))
		{
			goto IL_01f8;
		}
	}
	{
		float L_67 = V_16;
		float L_68 = __this->___m_MinValue_8;
		G_B33_0 = ((float)il2cpp_codegen_subtract(L_67, L_68));
		goto IL_0201;
	}

IL_01f8:
	{
		float L_69 = __this->___m_MaxValue_9;
		float L_70 = V_16;
		G_B33_0 = ((float)il2cpp_codegen_subtract(L_69, L_70));
	}

IL_0201:
	{
		V_17 = G_B33_0;
		float L_71 = V_17;
		float L_72 = V_13;
		if ((!(((float)L_71) < ((float)((float)il2cpp_codegen_multiply((0.100000001f), L_72))))))
		{
			goto IL_021f;
		}
	}
	{
		float L_73 = V_11;
		float L_74;
		L_74 = fabsf(L_73);
		G_B36_0 = ((((float)L_74) > ((float)(9.99999975E-05f)))? 1 : 0);
		goto IL_0220;
	}

IL_021f:
	{
		G_B36_0 = 0;
	}

IL_0220:
	{
		V_18 = (bool)G_B36_0;
		bool L_75 = V_18;
		if (!L_75)
		{
			goto IL_023b;
		}
	}
	{
		float L_76 = V_16;
		float L_77 = V_15;
		float L_78 = __this->___m_DecelTime_4;
		float L_79 = ___deltaTime0;
		float L_80;
		L_80 = Damper_Damp_mFB62278C063E2CAA706D30E8D68AF55D50AE95D2(((float)il2cpp_codegen_subtract(L_76, L_77)), L_78, L_79, NULL);
		float L_81 = ___deltaTime0;
		V_11 = ((float)(L_80/L_81));
	}

IL_023b:
	{
	}

IL_023c:
	{
		float L_82 = V_11;
		float L_83 = ___deltaTime0;
		V_0 = ((float)il2cpp_codegen_multiply(L_82, L_83));
	}

IL_0242:
	{
		float L_84 = __this->___Value_0;
		float L_85 = V_0;
		float L_86;
		L_86 = AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F(__this, ((float)il2cpp_codegen_add(L_84, L_85)), NULL);
		__this->___Value_0 = L_86;
		float L_87 = V_0;
		float L_88;
		L_88 = fabsf(L_87);
		V_2 = (bool)((((float)L_88) > ((float)(9.99999975E-05f)))? 1 : 0);
		goto IL_0266;
	}

IL_0266:
	{
		bool L_89 = V_2;
		return L_89;
	}
}
IL2CPP_EXTERN_C  bool AxisState_Update_mE86F039B78105160E5C13153B456E3A988AF28B4_AdjustorThunk (RuntimeObject* __this, float ___deltaTime0, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	bool _returnValue;
	_returnValue = AxisState_Update_mE86F039B78105160E5C13153B456E3A988AF28B4(_thisAdjusted, ___deltaTime0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___v0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	bool V_1 = false;
	float V_2 = 0.0f;
	int32_t G_B3_0 = 0;
	float G_B6_0 = 0.0f;
	float G_B6_1 = 0.0f;
	float G_B5_0 = 0.0f;
	float G_B5_1 = 0.0f;
	float G_B7_0 = 0.0f;
	float G_B7_1 = 0.0f;
	float G_B7_2 = 0.0f;
	{
		float L_0 = __this->___m_MaxValue_9;
		float L_1 = __this->___m_MinValue_8;
		V_0 = ((float)il2cpp_codegen_subtract(L_0, L_1));
		bool L_2 = __this->___m_Wrap_10;
		if (!L_2)
		{
			goto IL_0021;
		}
	}
	{
		float L_3 = V_0;
		G_B3_0 = ((((float)L_3) > ((float)(9.99999975E-05f)))? 1 : 0);
		goto IL_0022;
	}

IL_0021:
	{
		G_B3_0 = 0;
	}

IL_0022:
	{
		V_1 = (bool)G_B3_0;
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_004f;
		}
	}
	{
		float L_5 = ___v0;
		float L_6 = __this->___m_MinValue_8;
		float L_7 = V_0;
		___v0 = (fmodf(((float)il2cpp_codegen_subtract(L_5, L_6)), L_7));
		float L_8 = ___v0;
		float L_9 = __this->___m_MinValue_8;
		float L_10 = ___v0;
		G_B5_0 = L_9;
		G_B5_1 = L_8;
		if ((((float)L_10) < ((float)(0.0f))))
		{
			G_B6_0 = L_9;
			G_B6_1 = L_8;
			goto IL_0049;
		}
	}
	{
		G_B7_0 = (0.0f);
		G_B7_1 = G_B5_0;
		G_B7_2 = G_B5_1;
		goto IL_004a;
	}

IL_0049:
	{
		float L_11 = V_0;
		G_B7_0 = L_11;
		G_B7_1 = G_B6_0;
		G_B7_2 = G_B6_1;
	}

IL_004a:
	{
		___v0 = ((float)il2cpp_codegen_add(G_B7_2, ((float)il2cpp_codegen_add(G_B7_1, G_B7_0))));
	}

IL_004f:
	{
		float L_12 = ___v0;
		float L_13 = __this->___m_MinValue_8;
		float L_14 = __this->___m_MaxValue_9;
		float L_15;
		L_15 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_12, L_13, L_14, NULL);
		V_2 = L_15;
		goto IL_0064;
	}

IL_0064:
	{
		float L_16 = V_2;
		return L_16;
	}
}
IL2CPP_EXTERN_C  float AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F_AdjustorThunk (RuntimeObject* __this, float ___v0, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	float _returnValue;
	_returnValue = AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F(_thisAdjusted, ___v0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_MaxSpeedUpdate_m59BC1A91869A0D4A07E53DA4ED4172D5FBBF1DBD (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, float ___input0, float ___deltaTime1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	bool V_1 = false;
	bool V_2 = false;
	float V_3 = 0.0f;
	bool V_4 = false;
	float V_5 = 0.0f;
	float V_6 = 0.0f;
	float V_7 = 0.0f;
	bool V_8 = false;
	bool V_9 = false;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t G_B5_0 = 0;
	int32_t G_B7_0 = 0;
	int32_t G_B12_0 = 0;
	int32_t G_B19_0 = 0;
	{
		float L_0 = __this->___m_MaxSpeed_2;
		V_2 = (bool)((((float)L_0) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_1 = V_2;
		if (!L_1)
		{
			goto IL_0126;
		}
	}
	{
		float L_2 = ___input0;
		float L_3 = __this->___m_MaxSpeed_2;
		V_3 = ((float)il2cpp_codegen_multiply(L_2, L_3));
		float L_4 = V_3;
		float L_5;
		L_5 = fabsf(L_4);
		if ((((float)L_5) < ((float)(9.99999975E-05f))))
		{
			goto IL_0057;
		}
	}
	{
		float L_6 = __this->___m_CurrentSpeed_12;
		float L_7;
		L_7 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(L_6, NULL);
		float L_8 = V_3;
		float L_9;
		L_9 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(L_8, NULL);
		if ((!(((float)L_7) == ((float)L_9))))
		{
			goto IL_0054;
		}
	}
	{
		float L_10 = V_3;
		float L_11;
		L_11 = fabsf(L_10);
		float L_12 = __this->___m_CurrentSpeed_12;
		float L_13;
		L_13 = fabsf(L_12);
		G_B5_0 = ((((float)L_11) < ((float)L_13))? 1 : 0);
		goto IL_0055;
	}

IL_0054:
	{
		G_B5_0 = 0;
	}

IL_0055:
	{
		G_B7_0 = G_B5_0;
		goto IL_0058;
	}

IL_0057:
	{
		G_B7_0 = 1;
	}

IL_0058:
	{
		V_4 = (bool)G_B7_0;
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_00b3;
		}
	}
	{
		float L_15 = V_3;
		float L_16 = __this->___m_CurrentSpeed_12;
		float L_17;
		L_17 = fabsf(((float)il2cpp_codegen_subtract(L_15, L_16)));
		float L_18 = __this->___m_DecelTime_4;
		float L_19;
		L_19 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((9.99999975E-05f), L_18, NULL);
		V_5 = ((float)(L_17/L_19));
		float L_20 = V_5;
		float L_21 = ___deltaTime1;
		float L_22 = __this->___m_CurrentSpeed_12;
		float L_23;
		L_23 = fabsf(L_22);
		float L_24;
		L_24 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(((float)il2cpp_codegen_multiply(L_20, L_21)), L_23, NULL);
		V_6 = L_24;
		float L_25 = __this->___m_CurrentSpeed_12;
		float L_26 = __this->___m_CurrentSpeed_12;
		float L_27;
		L_27 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(L_26, NULL);
		float L_28 = V_6;
		__this->___m_CurrentSpeed_12 = ((float)il2cpp_codegen_subtract(L_25, ((float)il2cpp_codegen_multiply(L_27, L_28))));
		goto IL_0125;
	}

IL_00b3:
	{
		float L_29 = V_3;
		float L_30 = __this->___m_CurrentSpeed_12;
		float L_31;
		L_31 = fabsf(((float)il2cpp_codegen_subtract(L_29, L_30)));
		float L_32 = __this->___m_AccelTime_3;
		float L_33;
		L_33 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((9.99999975E-05f), L_32, NULL);
		V_7 = ((float)(L_31/L_33));
		float L_34 = __this->___m_CurrentSpeed_12;
		float L_35 = V_3;
		float L_36;
		L_36 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(L_35, NULL);
		float L_37 = V_7;
		float L_38 = ___deltaTime1;
		__this->___m_CurrentSpeed_12 = ((float)il2cpp_codegen_add(L_34, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply(L_36, L_37)), L_38))));
		float L_39 = __this->___m_CurrentSpeed_12;
		float L_40;
		L_40 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(L_39, NULL);
		float L_41 = V_3;
		float L_42;
		L_42 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(L_41, NULL);
		if ((!(((float)L_40) == ((float)L_42))))
		{
			goto IL_0114;
		}
	}
	{
		float L_43 = __this->___m_CurrentSpeed_12;
		float L_44;
		L_44 = fabsf(L_43);
		float L_45 = V_3;
		float L_46;
		L_46 = fabsf(L_45);
		G_B12_0 = ((((float)L_44) > ((float)L_46))? 1 : 0);
		goto IL_0115;
	}

IL_0114:
	{
		G_B12_0 = 0;
	}

IL_0115:
	{
		V_8 = (bool)G_B12_0;
		bool L_47 = V_8;
		if (!L_47)
		{
			goto IL_0124;
		}
	}
	{
		float L_48 = V_3;
		__this->___m_CurrentSpeed_12 = L_48;
	}

IL_0124:
	{
	}

IL_0125:
	{
	}

IL_0126:
	{
		float L_49;
		L_49 = AxisState_GetMaxSpeed_m323DC3125D2C40B79B0C041CBE7F5F126329E489(__this, NULL);
		V_0 = L_49;
		float L_50 = __this->___m_CurrentSpeed_12;
		float L_51 = V_0;
		float L_52 = V_0;
		float L_53;
		L_53 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_50, ((-L_51)), L_52, NULL);
		__this->___m_CurrentSpeed_12 = L_53;
		float L_54 = __this->___Value_0;
		float L_55 = __this->___m_CurrentSpeed_12;
		float L_56 = ___deltaTime1;
		__this->___Value_0 = ((float)il2cpp_codegen_add(L_54, ((float)il2cpp_codegen_multiply(L_55, L_56))));
		float L_57 = __this->___Value_0;
		float L_58 = __this->___m_MaxValue_9;
		if ((((float)L_57) > ((float)L_58)))
		{
			goto IL_0174;
		}
	}
	{
		float L_59 = __this->___Value_0;
		float L_60 = __this->___m_MinValue_8;
		G_B19_0 = ((((float)L_59) < ((float)L_60))? 1 : 0);
		goto IL_0175;
	}

IL_0174:
	{
		G_B19_0 = 1;
	}

IL_0175:
	{
		V_1 = (bool)G_B19_0;
		bool L_61 = V_1;
		V_9 = L_61;
		bool L_62 = V_9;
		if (!L_62)
		{
			goto IL_0206;
		}
	}
	{
		bool L_63 = __this->___m_Wrap_10;
		V_10 = L_63;
		bool L_64 = V_10;
		if (!L_64)
		{
			goto IL_01db;
		}
	}
	{
		float L_65 = __this->___Value_0;
		float L_66 = __this->___m_MaxValue_9;
		V_11 = (bool)((((float)L_65) > ((float)L_66))? 1 : 0);
		bool L_67 = V_11;
		if (!L_67)
		{
			goto IL_01be;
		}
	}
	{
		float L_68 = __this->___m_MinValue_8;
		float L_69 = __this->___Value_0;
		float L_70 = __this->___m_MaxValue_9;
		__this->___Value_0 = ((float)il2cpp_codegen_add(L_68, ((float)il2cpp_codegen_subtract(L_69, L_70))));
		goto IL_01d8;
	}

IL_01be:
	{
		float L_71 = __this->___m_MaxValue_9;
		float L_72 = __this->___Value_0;
		float L_73 = __this->___m_MinValue_8;
		__this->___Value_0 = ((float)il2cpp_codegen_add(L_71, ((float)il2cpp_codegen_subtract(L_72, L_73))));
	}

IL_01d8:
	{
		goto IL_0205;
	}

IL_01db:
	{
		float L_74 = __this->___Value_0;
		float L_75 = __this->___m_MinValue_8;
		float L_76 = __this->___m_MaxValue_9;
		float L_77;
		L_77 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_74, L_75, L_76, NULL);
		__this->___Value_0 = L_77;
		__this->___m_CurrentSpeed_12 = (0.0f);
	}

IL_0205:
	{
	}

IL_0206:
	{
		float L_78 = ___input0;
		float L_79;
		L_79 = fabsf(L_78);
		V_12 = (bool)((((float)L_79) > ((float)(9.99999975E-05f)))? 1 : 0);
		goto IL_0217;
	}

IL_0217:
	{
		bool L_80 = V_12;
		return L_80;
	}
}
IL2CPP_EXTERN_C  bool AxisState_MaxSpeedUpdate_m59BC1A91869A0D4A07E53DA4ED4172D5FBBF1DBD_AdjustorThunk (RuntimeObject* __this, float ___input0, float ___deltaTime1, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	bool _returnValue;
	_returnValue = AxisState_MaxSpeedUpdate_m59BC1A91869A0D4A07E53DA4ED4172D5FBBF1DBD(_thisAdjusted, ___input0, ___deltaTime1, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AxisState_GetMaxSpeed_m323DC3125D2C40B79B0C041CBE7F5F126329E489 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	bool V_1 = false;
	float V_2 = 0.0f;
	bool V_3 = false;
	float V_4 = 0.0f;
	float V_5 = 0.0f;
	bool V_6 = false;
	float V_7 = 0.0f;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	int32_t G_B12_0 = 0;
	{
		float L_0 = __this->___m_MaxValue_9;
		float L_1 = __this->___m_MinValue_8;
		V_0 = ((float)il2cpp_codegen_subtract(L_0, L_1));
		bool L_2 = __this->___m_Wrap_10;
		if (L_2)
		{
			goto IL_0021;
		}
	}
	{
		float L_3 = V_0;
		G_B3_0 = ((((float)L_3) > ((float)(0.0f)))? 1 : 0);
		goto IL_0022;
	}

IL_0021:
	{
		G_B3_0 = 0;
	}

IL_0022:
	{
		V_1 = (bool)G_B3_0;
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_00cd;
		}
	}
	{
		float L_5 = V_0;
		V_2 = ((float)(L_5/(10.0f)));
		float L_6 = __this->___m_CurrentSpeed_12;
		if ((!(((float)L_6) > ((float)(0.0f)))))
		{
			goto IL_0051;
		}
	}
	{
		float L_7 = __this->___m_MaxValue_9;
		float L_8 = __this->___Value_0;
		float L_9 = V_2;
		G_B7_0 = ((((float)((float)il2cpp_codegen_subtract(L_7, L_8))) < ((float)L_9))? 1 : 0);
		goto IL_0052;
	}

IL_0051:
	{
		G_B7_0 = 0;
	}

IL_0052:
	{
		V_3 = (bool)G_B7_0;
		bool L_10 = V_3;
		if (!L_10)
		{
			goto IL_007e;
		}
	}
	{
		float L_11 = __this->___m_MaxValue_9;
		float L_12 = __this->___Value_0;
		float L_13 = V_2;
		V_4 = ((float)(((float)il2cpp_codegen_subtract(L_11, L_12))/L_13));
		float L_14 = __this->___m_MaxSpeed_2;
		float L_15 = V_4;
		float L_16;
		L_16 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline((0.0f), L_14, L_15, NULL);
		V_5 = L_16;
		goto IL_00d7;
	}

IL_007e:
	{
		float L_17 = __this->___m_CurrentSpeed_12;
		if ((!(((float)L_17) < ((float)(0.0f)))))
		{
			goto IL_009d;
		}
	}
	{
		float L_18 = __this->___Value_0;
		float L_19 = __this->___m_MinValue_8;
		float L_20 = V_2;
		G_B12_0 = ((((float)((float)il2cpp_codegen_subtract(L_18, L_19))) < ((float)L_20))? 1 : 0);
		goto IL_009e;
	}

IL_009d:
	{
		G_B12_0 = 0;
	}

IL_009e:
	{
		V_6 = (bool)G_B12_0;
		bool L_21 = V_6;
		if (!L_21)
		{
			goto IL_00cc;
		}
	}
	{
		float L_22 = __this->___Value_0;
		float L_23 = __this->___m_MinValue_8;
		float L_24 = V_2;
		V_7 = ((float)(((float)il2cpp_codegen_subtract(L_22, L_23))/L_24));
		float L_25 = __this->___m_MaxSpeed_2;
		float L_26 = V_7;
		float L_27;
		L_27 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline((0.0f), L_25, L_26, NULL);
		V_5 = L_27;
		goto IL_00d7;
	}

IL_00cc:
	{
	}

IL_00cd:
	{
		float L_28 = __this->___m_MaxSpeed_2;
		V_5 = L_28;
		goto IL_00d7;
	}

IL_00d7:
	{
		float L_29 = V_5;
		return L_29;
	}
}
IL2CPP_EXTERN_C  float AxisState_GetMaxSpeed_m323DC3125D2C40B79B0C041CBE7F5F126329E489_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	float _returnValue;
	_returnValue = AxisState_GetMaxSpeed_m323DC3125D2C40B79B0C041CBE7F5F126329E489(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_get_ValueRangeLocked_m25A67A9600BCC5AFD35CA1A2C57AE0CFCB76E6B1 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CValueRangeLockedU3Ek__BackingField_18;
		return L_0;
	}
}
IL2CPP_EXTERN_C  bool AxisState_get_ValueRangeLocked_m25A67A9600BCC5AFD35CA1A2C57AE0CFCB76E6B1_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	bool _returnValue;
	_returnValue = AxisState_get_ValueRangeLocked_m25A67A9600BCC5AFD35CA1A2C57AE0CFCB76E6B1_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_set_ValueRangeLocked_m367AD65F7E97A0DFF0DE1CA0C74AEEBCCC36D000 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___value0;
		__this->___U3CValueRangeLockedU3Ek__BackingField_18 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C  void AxisState_set_ValueRangeLocked_m367AD65F7E97A0DFF0DE1CA0C74AEEBCCC36D000_AdjustorThunk (RuntimeObject* __this, bool ___value0, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	AxisState_set_ValueRangeLocked_m367AD65F7E97A0DFF0DE1CA0C74AEEBCCC36D000_inline(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AxisState_get_HasRecentering_m24F7A4CEF751588924C04AAB32BD1B59389BA4DC (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CHasRecenteringU3Ek__BackingField_19;
		return L_0;
	}
}
IL2CPP_EXTERN_C  bool AxisState_get_HasRecentering_m24F7A4CEF751588924C04AAB32BD1B59389BA4DC_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	bool _returnValue;
	_returnValue = AxisState_get_HasRecentering_m24F7A4CEF751588924C04AAB32BD1B59389BA4DC_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AxisState_set_HasRecentering_m978B18A62A74813CC75078114997E708B6877D85 (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___value0;
		__this->___U3CHasRecenteringU3Ek__BackingField_19 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C  void AxisState_set_HasRecentering_m978B18A62A74813CC75078114997E708B6877D85_AdjustorThunk (RuntimeObject* __this, bool ___value0, const RuntimeMethod* method)
{
	AxisState_t6996FE8143104E02683986C908C18B0F62595736* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<AxisState_t6996FE8143104E02683986C908C18B0F62595736*>(__this + _offset);
	AxisState_set_HasRecentering_m978B18A62A74813CC75078114997E708B6877D85_inline(_thisAdjusted, ___value0, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_pinvoke(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke& marshaled)
{
	marshaled.___m_enabled_0 = static_cast<int32_t>(unmarshaled.___m_enabled_0);
	marshaled.___m_WaitTime_1 = unmarshaled.___m_WaitTime_1;
	marshaled.___m_RecenteringTime_2 = unmarshaled.___m_RecenteringTime_2;
	marshaled.___mLastAxisInputTime_3 = unmarshaled.___mLastAxisInputTime_3;
	marshaled.___mRecenteringVelocity_4 = unmarshaled.___mRecenteringVelocity_4;
	marshaled.___m_LegacyHeadingDefinition_5 = unmarshaled.___m_LegacyHeadingDefinition_5;
	marshaled.___m_LegacyVelocityFilterStrength_6 = unmarshaled.___m_LegacyVelocityFilterStrength_6;
}
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_pinvoke_back(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke& marshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled)
{
	bool unmarshaledm_enabled_temp_0 = false;
	unmarshaledm_enabled_temp_0 = static_cast<bool>(marshaled.___m_enabled_0);
	unmarshaled.___m_enabled_0 = unmarshaledm_enabled_temp_0;
	float unmarshaledm_WaitTime_temp_1 = 0.0f;
	unmarshaledm_WaitTime_temp_1 = marshaled.___m_WaitTime_1;
	unmarshaled.___m_WaitTime_1 = unmarshaledm_WaitTime_temp_1;
	float unmarshaledm_RecenteringTime_temp_2 = 0.0f;
	unmarshaledm_RecenteringTime_temp_2 = marshaled.___m_RecenteringTime_2;
	unmarshaled.___m_RecenteringTime_2 = unmarshaledm_RecenteringTime_temp_2;
	float unmarshaledmLastAxisInputTime_temp_3 = 0.0f;
	unmarshaledmLastAxisInputTime_temp_3 = marshaled.___mLastAxisInputTime_3;
	unmarshaled.___mLastAxisInputTime_3 = unmarshaledmLastAxisInputTime_temp_3;
	float unmarshaledmRecenteringVelocity_temp_4 = 0.0f;
	unmarshaledmRecenteringVelocity_temp_4 = marshaled.___mRecenteringVelocity_4;
	unmarshaled.___mRecenteringVelocity_4 = unmarshaledmRecenteringVelocity_temp_4;
	int32_t unmarshaledm_LegacyHeadingDefinition_temp_5 = 0;
	unmarshaledm_LegacyHeadingDefinition_temp_5 = marshaled.___m_LegacyHeadingDefinition_5;
	unmarshaled.___m_LegacyHeadingDefinition_5 = unmarshaledm_LegacyHeadingDefinition_temp_5;
	int32_t unmarshaledm_LegacyVelocityFilterStrength_temp_6 = 0;
	unmarshaledm_LegacyVelocityFilterStrength_temp_6 = marshaled.___m_LegacyVelocityFilterStrength_6;
	unmarshaled.___m_LegacyVelocityFilterStrength_6 = unmarshaledm_LegacyVelocityFilterStrength_temp_6;
}
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_pinvoke_cleanup(Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke& marshaled)
{
}
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_com(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com& marshaled)
{
	marshaled.___m_enabled_0 = static_cast<int32_t>(unmarshaled.___m_enabled_0);
	marshaled.___m_WaitTime_1 = unmarshaled.___m_WaitTime_1;
	marshaled.___m_RecenteringTime_2 = unmarshaled.___m_RecenteringTime_2;
	marshaled.___mLastAxisInputTime_3 = unmarshaled.___mLastAxisInputTime_3;
	marshaled.___mRecenteringVelocity_4 = unmarshaled.___mRecenteringVelocity_4;
	marshaled.___m_LegacyHeadingDefinition_5 = unmarshaled.___m_LegacyHeadingDefinition_5;
	marshaled.___m_LegacyVelocityFilterStrength_6 = unmarshaled.___m_LegacyVelocityFilterStrength_6;
}
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_com_back(const Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com& marshaled, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF& unmarshaled)
{
	bool unmarshaledm_enabled_temp_0 = false;
	unmarshaledm_enabled_temp_0 = static_cast<bool>(marshaled.___m_enabled_0);
	unmarshaled.___m_enabled_0 = unmarshaledm_enabled_temp_0;
	float unmarshaledm_WaitTime_temp_1 = 0.0f;
	unmarshaledm_WaitTime_temp_1 = marshaled.___m_WaitTime_1;
	unmarshaled.___m_WaitTime_1 = unmarshaledm_WaitTime_temp_1;
	float unmarshaledm_RecenteringTime_temp_2 = 0.0f;
	unmarshaledm_RecenteringTime_temp_2 = marshaled.___m_RecenteringTime_2;
	unmarshaled.___m_RecenteringTime_2 = unmarshaledm_RecenteringTime_temp_2;
	float unmarshaledmLastAxisInputTime_temp_3 = 0.0f;
	unmarshaledmLastAxisInputTime_temp_3 = marshaled.___mLastAxisInputTime_3;
	unmarshaled.___mLastAxisInputTime_3 = unmarshaledmLastAxisInputTime_temp_3;
	float unmarshaledmRecenteringVelocity_temp_4 = 0.0f;
	unmarshaledmRecenteringVelocity_temp_4 = marshaled.___mRecenteringVelocity_4;
	unmarshaled.___mRecenteringVelocity_4 = unmarshaledmRecenteringVelocity_temp_4;
	int32_t unmarshaledm_LegacyHeadingDefinition_temp_5 = 0;
	unmarshaledm_LegacyHeadingDefinition_temp_5 = marshaled.___m_LegacyHeadingDefinition_5;
	unmarshaled.___m_LegacyHeadingDefinition_5 = unmarshaledm_LegacyHeadingDefinition_temp_5;
	int32_t unmarshaledm_LegacyVelocityFilterStrength_temp_6 = 0;
	unmarshaledm_LegacyVelocityFilterStrength_temp_6 = marshaled.___m_LegacyVelocityFilterStrength_6;
	unmarshaled.___m_LegacyVelocityFilterStrength_6 = unmarshaledm_LegacyVelocityFilterStrength_temp_6;
}
IL2CPP_EXTERN_C void Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshal_com_cleanup(Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com& marshaled)
{
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, bool ___enabled0, float ___waitTime1, float ___recenteringTime2, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		bool L_0 = ___enabled0;
		__this->___m_enabled_0 = L_0;
		float L_1 = ___waitTime1;
		__this->___m_WaitTime_1 = L_1;
		float L_2 = ___recenteringTime2;
		__this->___m_RecenteringTime_2 = L_2;
		__this->___mLastAxisInputTime_3 = (0.0f);
		__this->___mRecenteringVelocity_4 = (0.0f);
		int32_t L_3 = (-1);
		V_0 = L_3;
		__this->___m_LegacyVelocityFilterStrength_6 = L_3;
		int32_t L_4 = V_0;
		__this->___m_LegacyHeadingDefinition_5 = L_4;
		return;
	}
}
IL2CPP_EXTERN_C  void Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476_AdjustorThunk (RuntimeObject* __this, bool ___enabled0, float ___waitTime1, float ___recenteringTime2, const RuntimeMethod* method)
{
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Recentering_tB00B86249E96CFC65822315C710253B1E02459EF*>(__this + _offset);
	Recentering__ctor_mD885C396DC27C43D79A1FAA42F5ADD7D05CF2476(_thisAdjusted, ___enabled0, ___waitTime1, ___recenteringTime2, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_Validate_m3F5EE15AE52BB8FF2B69E3963851CEE2600340D3 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___m_WaitTime_1;
		float L_1;
		L_1 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_0, NULL);
		__this->___m_WaitTime_1 = L_1;
		float L_2 = __this->___m_RecenteringTime_2;
		float L_3;
		L_3 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline((0.0f), L_2, NULL);
		__this->___m_RecenteringTime_2 = L_3;
		return;
	}
}
IL2CPP_EXTERN_C  void Recentering_Validate_m3F5EE15AE52BB8FF2B69E3963851CEE2600340D3_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Recentering_tB00B86249E96CFC65822315C710253B1E02459EF*>(__this + _offset);
	Recentering_Validate_m3F5EE15AE52BB8FF2B69E3963851CEE2600340D3(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_CopyStateFrom_m1DB1F919E2F17C4913D1F2605E71630004138D89 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* ___other0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		float L_0 = __this->___mLastAxisInputTime_3;
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_1 = ___other0;
		float L_2 = L_1->___mLastAxisInputTime_3;
		V_0 = (bool)((((int32_t)((((float)L_0) == ((float)L_2))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0021;
		}
	}
	{
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_4 = ___other0;
		L_4->___mRecenteringVelocity_4 = (0.0f);
	}

IL_0021:
	{
		Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* L_5 = ___other0;
		float L_6 = L_5->___mLastAxisInputTime_3;
		__this->___mLastAxisInputTime_3 = L_6;
		return;
	}
}
IL2CPP_EXTERN_C  void Recentering_CopyStateFrom_m1DB1F919E2F17C4913D1F2605E71630004138D89_AdjustorThunk (RuntimeObject* __this, Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* ___other0, const RuntimeMethod* method)
{
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Recentering_tB00B86249E96CFC65822315C710253B1E02459EF*>(__this + _offset);
	Recentering_CopyStateFrom_m1DB1F919E2F17C4913D1F2605E71630004138D89(_thisAdjusted, ___other0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90 (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		float L_0;
		L_0 = CinemachineCore_get_CurrentTime_mE95A89B5053FB5D86EB1E2D855CDC9E4D4CC5459(NULL);
		__this->___mLastAxisInputTime_3 = L_0;
		__this->___mRecenteringVelocity_4 = (0.0f);
		return;
	}
}
IL2CPP_EXTERN_C  void Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Recentering_tB00B86249E96CFC65822315C710253B1E02459EF*>(__this + _offset);
	Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_RecenterNow_m0A012C8E8ABA1B3D00765C8C0FDC3A96C3DB102C (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, const RuntimeMethod* method) 
{
	{
		__this->___mLastAxisInputTime_3 = (0.0f);
		return;
	}
}
IL2CPP_EXTERN_C  void Recentering_RecenterNow_m0A012C8E8ABA1B3D00765C8C0FDC3A96C3DB102C_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Recentering_tB00B86249E96CFC65822315C710253B1E02459EF*>(__this + _offset);
	Recentering_RecenterNow_m0A012C8E8ABA1B3D00765C8C0FDC3A96C3DB102C(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, AxisState_t6996FE8143104E02683986C908C18B0F62595736* ___axis0, float ___deltaTime1, float ___recenterTarget2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	bool V_8 = false;
	bool V_9 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B16_0 = 0;
	{
		bool L_0 = __this->___m_enabled_0;
		if (L_0)
		{
			goto IL_0016;
		}
	}
	{
		float L_1 = ___deltaTime1;
		G_B3_0 = ((((int32_t)((!(((float)L_1) >= ((float)(0.0f))))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0017;
	}

IL_0016:
	{
		G_B3_0 = 0;
	}

IL_0017:
	{
		V_3 = (bool)G_B3_0;
		bool L_2 = V_3;
		if (!L_2)
		{
			goto IL_0020;
		}
	}
	{
		goto IL_0110;
	}

IL_0020:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_3 = ___axis0;
		float L_4 = ___recenterTarget2;
		float L_5;
		L_5 = AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F(L_3, L_4, NULL);
		___recenterTarget2 = L_5;
		float L_6 = ___deltaTime1;
		V_4 = (bool)((((float)L_6) < ((float)(0.0f)))? 1 : 0);
		bool L_7 = V_4;
		if (!L_7)
		{
			goto IL_0057;
		}
	}
	{
		Recentering_CancelRecentering_mB79FB4BE6A929EA524224E11C885AFBA1C212D90(__this, NULL);
		bool L_8 = __this->___m_enabled_0;
		V_5 = L_8;
		bool L_9 = V_5;
		if (!L_9)
		{
			goto IL_0052;
		}
	}
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_10 = ___axis0;
		float L_11 = ___recenterTarget2;
		L_10->___Value_0 = L_11;
	}

IL_0052:
	{
		goto IL_0110;
	}

IL_0057:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_12 = ___axis0;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_13 = ___axis0;
		float L_14 = L_13->___Value_0;
		float L_15;
		L_15 = AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F(L_12, L_14, NULL);
		V_0 = L_15;
		float L_16 = ___recenterTarget2;
		float L_17 = V_0;
		V_1 = ((float)il2cpp_codegen_subtract(L_16, L_17));
		float L_18 = V_1;
		V_6 = (bool)((((float)L_18) == ((float)(0.0f)))? 1 : 0);
		bool L_19 = V_6;
		if (!L_19)
		{
			goto IL_007b;
		}
	}
	{
		goto IL_0110;
	}

IL_007b:
	{
		il2cpp_codegen_runtime_class_init_inline(CinemachineCore_tDF9B8A03802F28C49A554F76418E61DFC12AC0FD_il2cpp_TypeInfo_var);
		float L_20;
		L_20 = CinemachineCore_get_CurrentTime_mE95A89B5053FB5D86EB1E2D855CDC9E4D4CC5459(NULL);
		float L_21 = __this->___mLastAxisInputTime_3;
		float L_22 = __this->___m_WaitTime_1;
		V_7 = (bool)((((float)L_20) < ((float)((float)il2cpp_codegen_add(L_21, L_22))))? 1 : 0);
		bool L_23 = V_7;
		if (!L_23)
		{
			goto IL_0097;
		}
	}
	{
		goto IL_0110;
	}

IL_0097:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_24 = ___axis0;
		float L_25 = L_24->___m_MaxValue_9;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_26 = ___axis0;
		float L_27 = L_26->___m_MinValue_8;
		V_2 = ((float)il2cpp_codegen_subtract(L_25, L_27));
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_28 = ___axis0;
		bool L_29 = L_28->___m_Wrap_10;
		if (!L_29)
		{
			goto IL_00be;
		}
	}
	{
		float L_30 = V_1;
		float L_31;
		L_31 = fabsf(L_30);
		float L_32 = V_2;
		G_B16_0 = ((((float)L_31) > ((float)((float)il2cpp_codegen_multiply(L_32, (0.5f)))))? 1 : 0);
		goto IL_00bf;
	}

IL_00be:
	{
		G_B16_0 = 0;
	}

IL_00bf:
	{
		V_8 = (bool)G_B16_0;
		bool L_33 = V_8;
		if (!L_33)
		{
			goto IL_00d2;
		}
	}
	{
		float L_34 = V_0;
		float L_35 = ___recenterTarget2;
		float L_36 = V_0;
		float L_37;
		L_37 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(((float)il2cpp_codegen_subtract(L_35, L_36)), NULL);
		float L_38 = V_2;
		V_0 = ((float)il2cpp_codegen_add(L_34, ((float)il2cpp_codegen_multiply(L_37, L_38))));
	}

IL_00d2:
	{
		float L_39 = __this->___m_RecenteringTime_2;
		V_9 = (bool)((((float)L_39) < ((float)(0.00100000005f)))? 1 : 0);
		bool L_40 = V_9;
		if (!L_40)
		{
			goto IL_00e9;
		}
	}
	{
		float L_41 = ___recenterTarget2;
		V_0 = L_41;
		goto IL_0103;
	}

IL_00e9:
	{
		float L_42 = V_0;
		float L_43 = ___recenterTarget2;
		float* L_44 = (&__this->___mRecenteringVelocity_4);
		float L_45 = __this->___m_RecenteringTime_2;
		float L_46 = ___deltaTime1;
		float L_47;
		L_47 = Mathf_SmoothDamp_m00E482452BCED3FE0F16B4033B2B5323C7E30829(L_42, L_43, L_44, L_45, (9999.0f), L_46, NULL);
		V_0 = L_47;
	}

IL_0103:
	{
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_48 = ___axis0;
		AxisState_t6996FE8143104E02683986C908C18B0F62595736* L_49 = ___axis0;
		float L_50 = V_0;
		float L_51;
		L_51 = AxisState_ClampValue_m2985D75E8FF57E3F88BF31B24CC719511507837F(L_49, L_50, NULL);
		L_48->___Value_0 = L_51;
	}

IL_0110:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A_AdjustorThunk (RuntimeObject* __this, AxisState_t6996FE8143104E02683986C908C18B0F62595736* ___axis0, float ___deltaTime1, float ___recenterTarget2, const RuntimeMethod* method)
{
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Recentering_tB00B86249E96CFC65822315C710253B1E02459EF*>(__this + _offset);
	Recentering_DoRecentering_m7B1730622484A958AF9FD87F2056A388D96EA01A(_thisAdjusted, ___axis0, ___deltaTime1, ___recenterTarget2, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Recentering_LegacyUpgrade_m17A3ED97851377053B2385331ED85BE3DA3D4D7D (Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* __this, int32_t* ___heading0, int32_t* ___velocityFilter1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		int32_t L_0 = __this->___m_LegacyHeadingDefinition_5;
		if ((((int32_t)L_0) == ((int32_t)(-1))))
		{
			goto IL_0018;
		}
	}
	{
		int32_t L_1 = __this->___m_LegacyVelocityFilterStrength_6;
		G_B3_0 = ((((int32_t)((((int32_t)L_1) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0019;
	}

IL_0018:
	{
		G_B3_0 = 0;
	}

IL_0019:
	{
		V_0 = (bool)G_B3_0;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0042;
		}
	}
	{
		int32_t* L_3 = ___heading0;
		int32_t L_4 = __this->___m_LegacyHeadingDefinition_5;
		*((int32_t*)L_3) = (int32_t)L_4;
		int32_t* L_5 = ___velocityFilter1;
		int32_t L_6 = __this->___m_LegacyVelocityFilterStrength_6;
		*((int32_t*)L_5) = (int32_t)L_6;
		int32_t L_7 = (-1);
		V_1 = L_7;
		__this->___m_LegacyVelocityFilterStrength_6 = L_7;
		int32_t L_8 = V_1;
		__this->___m_LegacyHeadingDefinition_5 = L_8;
		V_2 = (bool)1;
		goto IL_0046;
	}

IL_0042:
	{
		V_2 = (bool)0;
		goto IL_0046;
	}

IL_0046:
	{
		bool L_9 = V_2;
		return L_9;
	}
}
IL2CPP_EXTERN_C  bool Recentering_LegacyUpgrade_m17A3ED97851377053B2385331ED85BE3DA3D4D7D_AdjustorThunk (RuntimeObject* __this, int32_t* ___heading0, int32_t* ___velocityFilter1, const RuntimeMethod* method)
{
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Recentering_tB00B86249E96CFC65822315C710253B1E02459EF*>(__this + _offset);
	bool _returnValue;
	_returnValue = Recentering_LegacyUpgrade_m17A3ED97851377053B2385331ED85BE3DA3D4D7D(_thisAdjusted, ___heading0, ___velocityFilter1, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif


IL2CPP_EXTERN_C void CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshal_pinvoke(const CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156& unmarshaled, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_pinvoke& marshaled)
{
	Exception_t* ___m_CustomOverflow_15Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_CustomOverflow' of type 'CameraState'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_CustomOverflow_15Exception, NULL);
}
IL2CPP_EXTERN_C void CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshal_pinvoke_back(const CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_pinvoke& marshaled, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156& unmarshaled)
{
	Exception_t* ___m_CustomOverflow_15Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_CustomOverflow' of type 'CameraState'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_CustomOverflow_15Exception, NULL);
}
IL2CPP_EXTERN_C void CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshal_pinvoke_cleanup(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_pinvoke& marshaled)
{
}


IL2CPP_EXTERN_C void CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshal_com(const CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156& unmarshaled, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_com& marshaled)
{
	Exception_t* ___m_CustomOverflow_15Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_CustomOverflow' of type 'CameraState'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_CustomOverflow_15Exception, NULL);
}
IL2CPP_EXTERN_C void CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshal_com_back(const CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_com& marshaled, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156& unmarshaled)
{
	Exception_t* ___m_CustomOverflow_15Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field 'm_CustomOverflow' of type 'CameraState'.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___m_CustomOverflow_15Exception, NULL);
}
IL2CPP_EXTERN_C void CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshal_com_cleanup(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_com& marshaled)
{
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = __this->___ReferenceLookAt_2;
		bool L_2;
		L_2 = Vector3_op_Equality_m15951D1B53E3BE36C9D265E229090020FBD72EBB_inline(L_0, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C  bool CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	bool _returnValue;
	_returnValue = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = __this->___PositionCorrection_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_0, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C  Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 _returnValue;
	_returnValue = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) 
{
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = __this->___RawOrientation_5;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = __this->___OrientationCorrection_9;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2;
		L_2 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_0, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C  Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 _returnValue;
	_returnValue = CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_get_FinalPosition_m4D482D1F3E008068C2151FC24FD85CB6F603AE12 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = __this->___PositionCorrection_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_0, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C  Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_get_FinalPosition_m4D482D1F3E008068C2151FC24FD85CB6F603AE12_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 _returnValue;
	_returnValue = CameraState_get_FinalPosition_m4D482D1F3E008068C2151FC24FD85CB6F603AE12(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_get_FinalOrientation_m65D23E9A3C9264408AB177483C74FD609EFAB4B3 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_0 = (&__this->___Lens_0);
		float L_1 = L_0->___Dutch_5;
		float L_2;
		L_2 = fabsf(L_1);
		V_0 = (bool)((((float)L_2) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_003f;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4;
		L_4 = CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8(__this, NULL);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_5 = (&__this->___Lens_0);
		float L_6 = L_5->___Dutch_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline(NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_8;
		L_8 = Quaternion_AngleAxis_m01A869DC10F976FAF493B66F15D6D6977BB61DA8(L_6, L_7, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_9;
		L_9 = Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline(L_4, L_8, NULL);
		V_1 = L_9;
		goto IL_0048;
	}

IL_003f:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_10;
		L_10 = CameraState_get_CorrectedOrientation_m04987B71E708B14A28973FFF81645C8834FD04E8(__this, NULL);
		V_1 = L_10;
		goto IL_0048;
	}

IL_0048:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_11 = V_1;
		return L_11;
	}
}
IL2CPP_EXTERN_C  Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_get_FinalOrientation_m65D23E9A3C9264408AB177483C74FD609EFAB4B3_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 _returnValue;
	_returnValue = CameraState_get_FinalOrientation_m65D23E9A3C9264408AB177483C74FD609EFAB4B3(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 CameraState_get_Default_mBF6F22B14C83DD400EF9F53BB8EACB240BD79398 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 V_0;
	memset((&V_0), 0, sizeof(V_0));
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156));
		il2cpp_codegen_runtime_class_init_inline(LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_il2cpp_TypeInfo_var);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_0 = ((LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_StaticFields*)il2cpp_codegen_static_fields_for(LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_il2cpp_TypeInfo_var))->___Default_0;
		(&V_0)->___Lens_0 = L_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		(&V_0)->___ReferenceUp_1 = L_1;
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ((CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_StaticFields*)il2cpp_codegen_static_fields_for(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var))->___kNoPoint_3;
		(&V_0)->___ReferenceLookAt_2 = L_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		(&V_0)->___RawPosition_4 = L_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4;
		L_4 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		(&V_0)->___RawOrientation_5 = L_4;
		(&V_0)->___ShotQuality_7 = (1.0f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		L_5 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		(&V_0)->___PositionCorrection_8 = L_5;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_6;
		L_6 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		(&V_0)->___OrientationCorrection_9 = L_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		(&V_0)->___PositionDampingBypass_6 = L_7;
		(&V_0)->___BlendHint_10 = 0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_8 = V_0;
		V_1 = L_8;
		goto IL_0081;
	}

IL_0081:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_9 = V_1;
		return L_9;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CNumCustomBlendablesU3Ek__BackingField_16;
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CameraState_set_NumCustomBlendables_m599C74DAA99E17F8B5EF87CFD0A6238A81D05AD3 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___value0;
		__this->___U3CNumCustomBlendablesU3Ek__BackingField_16 = L_0;
		return;
	}
}
IL2CPP_EXTERN_C  void CameraState_set_NumCustomBlendables_m599C74DAA99E17F8B5EF87CFD0A6238A81D05AD3_AdjustorThunk (RuntimeObject* __this, int32_t ___value0, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	CameraState_set_NumCustomBlendables_m599C74DAA99E17F8B5EF87CFD0A6238A81D05AD3_inline(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB CameraState_GetCustomBlendable_mE19B33F6CEC1B42ACAEB34A0601E48A80577498E (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, int32_t ___index0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB V_2;
	memset((&V_2), 0, sizeof(V_2));
	bool V_3 = false;
	int32_t G_B9_0 = 0;
	{
		int32_t L_0 = ___index0;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_001d;
			}
			case 1:
			{
				goto IL_0026;
			}
			case 2:
			{
				goto IL_002f;
			}
			case 3:
			{
				goto IL_0038;
			}
		}
	}
	{
		goto IL_0041;
	}

IL_001d:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_3 = __this->___mCustom0_11;
		V_2 = L_3;
		goto IL_0081;
	}

IL_0026:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_4 = __this->___mCustom1_12;
		V_2 = L_4;
		goto IL_0081;
	}

IL_002f:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_5 = __this->___mCustom2_13;
		V_2 = L_5;
		goto IL_0081;
	}

IL_0038:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_6 = __this->___mCustom3_14;
		V_2 = L_6;
		goto IL_0081;
	}

IL_0041:
	{
		int32_t L_7 = ___index0;
		___index0 = ((int32_t)il2cpp_codegen_subtract(L_7, 4));
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_8 = __this->___m_CustomOverflow_15;
		if (!L_8)
		{
			goto IL_005f;
		}
	}
	{
		int32_t L_9 = ___index0;
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_10 = __this->___m_CustomOverflow_15;
		NullCheck(L_10);
		int32_t L_11;
		L_11 = List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_inline(L_10, List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_RuntimeMethod_var);
		G_B9_0 = ((((int32_t)L_9) < ((int32_t)L_11))? 1 : 0);
		goto IL_0060;
	}

IL_005f:
	{
		G_B9_0 = 0;
	}

IL_0060:
	{
		V_3 = (bool)G_B9_0;
		bool L_12 = V_3;
		if (!L_12)
		{
			goto IL_0073;
		}
	}
	{
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_13 = __this->___m_CustomOverflow_15;
		int32_t L_14 = ___index0;
		NullCheck(L_13);
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_15;
		L_15 = List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C(L_13, L_14, List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C_RuntimeMethod_var);
		V_2 = L_15;
		goto IL_0081;
	}

IL_0073:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_16;
		memset((&L_16), 0, sizeof(L_16));
		CustomBlendable__ctor_mF38BF574AF05E415A01A2A46E506DE6B5086B303((&L_16), (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, (0.0f), NULL);
		V_2 = L_16;
		goto IL_0081;
	}

IL_0081:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_17 = V_2;
		return L_17;
	}
}
IL2CPP_EXTERN_C  CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB CameraState_GetCustomBlendable_mE19B33F6CEC1B42ACAEB34A0601E48A80577498E_AdjustorThunk (RuntimeObject* __this, int32_t ___index0, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB _returnValue;
	_returnValue = CameraState_GetCustomBlendable_mE19B33F6CEC1B42ACAEB34A0601E48A80577498E(_thisAdjusted, ___index0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t CameraState_FindCustomBlendable_m141410A5E7FF4B985E2D3979D72BF80F398DE57C (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___custom0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	int32_t V_6 = 0;
	bool V_7 = false;
	bool V_8 = false;
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* L_0 = (&__this->___mCustom0_11);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_1 = L_0->___m_Custom_0;
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_2 = ___custom0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_1, L_2, NULL);
		V_0 = L_3;
		bool L_4 = V_0;
		if (!L_4)
		{
			goto IL_001d;
		}
	}
	{
		V_1 = 0;
		goto IL_00c7;
	}

IL_001d:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* L_5 = (&__this->___mCustom1_12);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_6 = L_5->___m_Custom_0;
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_7 = ___custom0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_8;
		L_8 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_6, L_7, NULL);
		V_2 = L_8;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_0039;
		}
	}
	{
		V_1 = 1;
		goto IL_00c7;
	}

IL_0039:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* L_10 = (&__this->___mCustom2_13);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_11 = L_10->___m_Custom_0;
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_12 = ___custom0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_13;
		L_13 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_11, L_12, NULL);
		V_3 = L_13;
		bool L_14 = V_3;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		V_1 = 2;
		goto IL_00c7;
	}

IL_0052:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* L_15 = (&__this->___mCustom3_14);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_16 = L_15->___m_Custom_0;
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_17 = ___custom0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_18;
		L_18 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_16, L_17, NULL);
		V_4 = L_18;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006d;
		}
	}
	{
		V_1 = 3;
		goto IL_00c7;
	}

IL_006d:
	{
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_20 = __this->___m_CustomOverflow_15;
		V_5 = (bool)((!(((RuntimeObject*)(List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*)L_20) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
		bool L_21 = V_5;
		if (!L_21)
		{
			goto IL_00c3;
		}
	}
	{
		V_6 = 0;
		goto IL_00ad;
	}

IL_0082:
	{
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_22 = __this->___m_CustomOverflow_15;
		int32_t L_23 = V_6;
		NullCheck(L_22);
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_24;
		L_24 = List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C(L_22, L_23, List_1_get_Item_m18DD04FEEF59CAA34D11ED27848B84C54E35CF5C_RuntimeMethod_var);
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_25 = L_24.___m_Custom_0;
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_26 = ___custom0;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_27;
		L_27 = Object_op_Equality_mD3DB0D72CE0250C84033DC2A90AEF9D59896E536(L_25, L_26, NULL);
		V_7 = L_27;
		bool L_28 = V_7;
		if (!L_28)
		{
			goto IL_00a7;
		}
	}
	{
		int32_t L_29 = V_6;
		V_1 = ((int32_t)il2cpp_codegen_add(L_29, 4));
		goto IL_00c7;
	}

IL_00a7:
	{
		int32_t L_30 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add(L_30, 1));
	}

IL_00ad:
	{
		int32_t L_31 = V_6;
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_32 = __this->___m_CustomOverflow_15;
		NullCheck(L_32);
		int32_t L_33;
		L_33 = List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_inline(L_32, List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_RuntimeMethod_var);
		V_8 = (bool)((((int32_t)L_31) < ((int32_t)L_33))? 1 : 0);
		bool L_34 = V_8;
		if (L_34)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00c3:
	{
		V_1 = (-1);
		goto IL_00c7;
	}

IL_00c7:
	{
		int32_t L_35 = V_1;
		return L_35;
	}
}
IL2CPP_EXTERN_C  int32_t CameraState_FindCustomBlendable_m141410A5E7FF4B985E2D3979D72BF80F398DE57C_AdjustorThunk (RuntimeObject* __this, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___custom0, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = CameraState_FindCustomBlendable_m141410A5E7FF4B985E2D3979D72BF80F398DE57C(_thisAdjusted, ___custom0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CameraState_AddCustomBlendable_m1DA24CB5A397752C33B6A1773CFF38F02505AD3C (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___b0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m71F29A2B876EC3E6F1ACD24B3CEAEDA3FF79CB3F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	bool V_1 = false;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_0 = ___b0;
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_1 = L_0.___m_Custom_0;
		int32_t L_2;
		L_2 = CameraState_FindCustomBlendable_m141410A5E7FF4B985E2D3979D72BF80F398DE57C(__this, L_1, NULL);
		V_0 = L_2;
		int32_t L_3 = V_0;
		V_1 = (bool)((((int32_t)((((int32_t)L_3) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0032;
		}
	}
	{
		float* L_5 = (&(&___b0)->___m_Weight_1);
		float* L_6 = L_5;
		float L_7 = *((float*)L_6);
		int32_t L_8 = V_0;
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_9;
		L_9 = CameraState_GetCustomBlendable_mE19B33F6CEC1B42ACAEB34A0601E48A80577498E(__this, L_8, NULL);
		float L_10 = L_9.___m_Weight_1;
		*((float*)L_6) = (float)((float)il2cpp_codegen_add(L_7, L_10));
		goto IL_0045;
	}

IL_0032:
	{
		int32_t L_11;
		L_11 = CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB_inline(__this, NULL);
		V_0 = L_11;
		int32_t L_12 = V_0;
		CameraState_set_NumCustomBlendables_m599C74DAA99E17F8B5EF87CFD0A6238A81D05AD3_inline(__this, ((int32_t)il2cpp_codegen_add(L_12, 1)), NULL);
	}

IL_0045:
	{
		int32_t L_13 = V_0;
		V_3 = L_13;
		int32_t L_14 = V_3;
		V_2 = L_14;
		int32_t L_15 = V_2;
		switch (L_15)
		{
			case 0:
			{
				goto IL_0061;
			}
			case 1:
			{
				goto IL_006a;
			}
			case 2:
			{
				goto IL_0073;
			}
			case 3:
			{
				goto IL_007c;
			}
		}
	}
	{
		goto IL_0085;
	}

IL_0061:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_16 = ___b0;
		__this->___mCustom0_11 = L_16;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___mCustom0_11))->___m_Custom_0), (void*)NULL);
		goto IL_00af;
	}

IL_006a:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_17 = ___b0;
		__this->___mCustom1_12 = L_17;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___mCustom1_12))->___m_Custom_0), (void*)NULL);
		goto IL_00af;
	}

IL_0073:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_18 = ___b0;
		__this->___mCustom2_13 = L_18;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___mCustom2_13))->___m_Custom_0), (void*)NULL);
		goto IL_00af;
	}

IL_007c:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_19 = ___b0;
		__this->___mCustom3_14 = L_19;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->___mCustom3_14))->___m_Custom_0), (void*)NULL);
		goto IL_00af;
	}

IL_0085:
	{
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_20 = __this->___m_CustomOverflow_15;
		V_4 = (bool)((((RuntimeObject*)(List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*)L_20) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_21 = V_4;
		if (!L_21)
		{
			goto IL_00a0;
		}
	}
	{
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_22 = (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4*)il2cpp_codegen_object_new(List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4_il2cpp_TypeInfo_var);
		NullCheck(L_22);
		List_1__ctor_m71F29A2B876EC3E6F1ACD24B3CEAEDA3FF79CB3F(L_22, List_1__ctor_m71F29A2B876EC3E6F1ACD24B3CEAEDA3FF79CB3F_RuntimeMethod_var);
		__this->___m_CustomOverflow_15 = L_22;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_CustomOverflow_15), (void*)L_22);
	}

IL_00a0:
	{
		List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* L_23 = __this->___m_CustomOverflow_15;
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_24 = ___b0;
		NullCheck(L_23);
		List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_inline(L_23, L_24, List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_RuntimeMethod_var);
		goto IL_00af;
	}

IL_00af:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void CameraState_AddCustomBlendable_m1DA24CB5A397752C33B6A1773CFF38F02505AD3C_AdjustorThunk (RuntimeObject* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___b0, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	CameraState_AddCustomBlendable_m1DA24CB5A397752C33B6A1773CFF38F02505AD3C(_thisAdjusted, ___b0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 CameraState_Lerp_mEF27BCEB2B6B51C4E1A2F8E5D5826963D0C787CD (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___stateA0, CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___stateB1, float ___t2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 V_1;
	memset((&V_1), 0, sizeof(V_1));
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_2;
	memset((&V_2), 0, sizeof(V_2));
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	bool V_8 = false;
	bool V_9 = false;
	bool V_10 = false;
	bool V_11 = false;
	float V_12 = 0.0f;
	float V_13 = 0.0f;
	bool V_14 = false;
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE V_15;
	memset((&V_15), 0, sizeof(V_15));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_16;
	memset((&V_16), 0, sizeof(V_16));
	bool V_17 = false;
	bool V_18 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_19;
	memset((&V_19), 0, sizeof(V_19));
	bool V_20 = false;
	float V_21 = 0.0f;
	bool V_22 = false;
	bool V_23 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_24;
	memset((&V_24), 0, sizeof(V_24));
	bool V_25 = false;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_26;
	memset((&V_26), 0, sizeof(V_26));
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_27;
	memset((&V_27), 0, sizeof(V_27));
	int32_t V_28 = 0;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB V_29;
	memset((&V_29), 0, sizeof(V_29));
	bool V_30 = false;
	bool V_31 = false;
	int32_t V_32 = 0;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB V_33;
	memset((&V_33), 0, sizeof(V_33));
	bool V_34 = false;
	bool V_35 = false;
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 V_36;
	memset((&V_36), 0, sizeof(V_36));
	int32_t G_B20_0 = 0;
	int32_t G_B26_0 = 0;
	int32_t G_B32_0 = 0;
	int32_t G_B42_0 = 0;
	{
		float L_0 = ___t2;
		float L_1;
		L_1 = Mathf_Clamp01_mD921B23F47F5347996C56DC789D1DE16EE27D9B1_inline(L_0, NULL);
		___t2 = L_1;
		float L_2 = ___t2;
		V_0 = L_2;
		il2cpp_codegen_initobj((&V_1), sizeof(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156));
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_3 = ___stateA0;
		int32_t L_4 = L_3.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_5 = ___stateB1;
		int32_t L_6 = L_5.___BlendHint_10;
		V_3 = (bool)((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_4&(int32_t)L_6))&1))) <= ((uint32_t)0)))? 1 : 0);
		bool L_7 = V_3;
		if (!L_7)
		{
			goto IL_0035;
		}
	}
	{
		int32_t* L_8 = (&(&V_1)->___BlendHint_10);
		int32_t* L_9 = L_8;
		int32_t L_10 = *((int32_t*)L_9);
		*((int32_t*)L_9) = (int32_t)((int32_t)(L_10|1));
	}

IL_0035:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_11 = ___stateA0;
		int32_t L_12 = L_11.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_13 = ___stateB1;
		int32_t L_14 = L_13.___BlendHint_10;
		V_4 = (bool)((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_12&(int32_t)L_14))&2))) <= ((uint32_t)0)))? 1 : 0);
		bool L_15 = V_4;
		if (!L_15)
		{
			goto IL_0059;
		}
	}
	{
		int32_t* L_16 = (&(&V_1)->___BlendHint_10);
		int32_t* L_17 = L_16;
		int32_t L_18 = *((int32_t*)L_17);
		*((int32_t*)L_17) = (int32_t)((int32_t)(L_18|2));
	}

IL_0059:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_19 = ___stateA0;
		int32_t L_20 = L_19.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_21 = ___stateB1;
		int32_t L_22 = L_21.___BlendHint_10;
		V_5 = (bool)((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_20&(int32_t)L_22))&((int32_t)64)))) <= ((uint32_t)0)))? 1 : 0);
		bool L_23 = V_5;
		if (!L_23)
		{
			goto IL_007f;
		}
	}
	{
		int32_t* L_24 = (&(&V_1)->___BlendHint_10);
		int32_t* L_25 = L_24;
		int32_t L_26 = *((int32_t*)L_25);
		*((int32_t*)L_25) = (int32_t)((int32_t)(L_26|((int32_t)64)));
	}

IL_007f:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_27 = ___stateA0;
		int32_t L_28 = L_27.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_29 = ___stateB1;
		int32_t L_30 = L_29.___BlendHint_10;
		V_6 = (bool)((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_28|(int32_t)L_30))&4))) <= ((uint32_t)0)))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_00a3;
		}
	}
	{
		int32_t* L_32 = (&(&V_1)->___BlendHint_10);
		int32_t* L_33 = L_32;
		int32_t L_34 = *((int32_t*)L_33);
		*((int32_t*)L_33) = (int32_t)((int32_t)(L_34|4));
	}

IL_00a3:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_35 = ___stateA0;
		int32_t L_36 = L_35.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_37 = ___stateB1;
		int32_t L_38 = L_37.___BlendHint_10;
		V_7 = (bool)((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_36|(int32_t)L_38))&8))) <= ((uint32_t)0)))? 1 : 0);
		bool L_39 = V_7;
		if (!L_39)
		{
			goto IL_00c7;
		}
	}
	{
		int32_t* L_40 = (&(&V_1)->___BlendHint_10);
		int32_t* L_41 = L_40;
		int32_t L_42 = *((int32_t*)L_41);
		*((int32_t*)L_41) = (int32_t)((int32_t)(L_42|8));
	}

IL_00c7:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_43 = ___stateA0;
		int32_t L_44 = L_43.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_45 = ___stateB1;
		int32_t L_46 = L_45.___BlendHint_10;
		V_8 = (bool)((((int32_t)((int32_t)(((int32_t)((int32_t)L_44|(int32_t)L_46))&((int32_t)64)))) == ((int32_t)0))? 1 : 0);
		bool L_47 = V_8;
		if (!L_47)
		{
			goto IL_00fb;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_48 = ___stateA0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_49 = L_48.___Lens_0;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_50 = ___stateB1;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_51 = L_50.___Lens_0;
		float L_52 = ___t2;
		il2cpp_codegen_runtime_class_init_inline(LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_il2cpp_TypeInfo_var);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_53;
		L_53 = LensSettings_Lerp_mC2FB90FBCCACFC3BFB8B35971CE0F034D11D8865(L_49, L_51, L_52, NULL);
		(&V_1)->___Lens_0 = L_53;
		goto IL_0144;
	}

IL_00fb:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_54 = ___stateA0;
		int32_t L_55 = L_54.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_56 = ___stateB1;
		int32_t L_57 = L_56.___BlendHint_10;
		V_9 = (bool)((((int32_t)((int32_t)(((int32_t)((int32_t)L_55&(int32_t)L_57))&((int32_t)64)))) == ((int32_t)0))? 1 : 0);
		bool L_58 = V_9;
		if (!L_58)
		{
			goto IL_0144;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_59 = ___stateA0;
		int32_t L_60 = L_59.___BlendHint_10;
		V_10 = (bool)((!(((uint32_t)((int32_t)((int32_t)L_60&((int32_t)64)))) <= ((uint32_t)0)))? 1 : 0);
		bool L_61 = V_10;
		if (!L_61)
		{
			goto IL_0136;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_62 = ___stateB1;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_63 = L_62.___Lens_0;
		(&V_1)->___Lens_0 = L_63;
		goto IL_0143;
	}

IL_0136:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_64 = ___stateA0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_65 = L_64.___Lens_0;
		(&V_1)->___Lens_0 = L_65;
	}

IL_0143:
	{
	}

IL_0144:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_66 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_67 = L_66.___ReferenceUp_1;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_68 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_69 = L_68.___ReferenceUp_1;
		float L_70 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_71;
		L_71 = Vector3_Slerp_mBA32C7EAC64C56C7D68480549FA9A892FA5C1728(L_67, L_69, L_70, NULL);
		(&V_1)->___ReferenceUp_1 = L_71;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_72 = ___stateA0;
		float L_73 = L_72.___ShotQuality_7;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_74 = ___stateB1;
		float L_75 = L_74.___ShotQuality_7;
		float L_76 = ___t2;
		float L_77;
		L_77 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline(L_73, L_75, L_76, NULL);
		(&V_1)->___ShotQuality_7 = L_77;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_78 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79 = L_78.___PositionCorrection_8;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_80 = ___stateA0;
		int32_t L_81 = L_80.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_82 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_83 = L_82.___PositionCorrection_8;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_84 = ___stateB1;
		int32_t L_85 = L_84.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_86 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_87 = L_86.___PositionCorrection_8;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_88 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_89 = L_88.___PositionCorrection_8;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_90 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_91 = L_90.___PositionCorrection_8;
		float L_92 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_93;
		L_93 = Vector3_Lerp_m57EE8D709A93B2B0FF8D499FA2947B1D61CB1FD6_inline(L_89, L_91, L_92, NULL);
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_94;
		L_94 = CameraState_ApplyPosBlendHint_m652243F6FEEC671040EE65DDF83A1446305357CC(L_79, L_81, L_83, L_85, L_87, L_93, NULL);
		(&V_1)->___PositionCorrection_8 = L_94;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_95 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_96 = L_95.___OrientationCorrection_9;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_97 = ___stateA0;
		int32_t L_98 = L_97.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_99 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_100 = L_99.___OrientationCorrection_9;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_101 = ___stateB1;
		int32_t L_102 = L_101.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_103 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_104 = L_103.___OrientationCorrection_9;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_105 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_106 = L_105.___OrientationCorrection_9;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_107 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_108 = L_107.___OrientationCorrection_9;
		float L_109 = ___t2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_110;
		L_110 = Quaternion_Slerp_m5FDA8C178E7EB209B43845F73263AFE9C02F3949(L_106, L_108, L_109, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_111;
		L_111 = CameraState_ApplyRotBlendHint_mF25F7D3F9315C2CE92CBB65CC06D519C228C3571(L_96, L_98, L_100, L_102, L_104, L_110, NULL);
		(&V_1)->___OrientationCorrection_9 = L_111;
		bool L_112;
		L_112 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC((&___stateA0), NULL);
		if (!L_112)
		{
			goto IL_0203;
		}
	}
	{
		bool L_113;
		L_113 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC((&___stateB1), NULL);
		G_B20_0 = ((((int32_t)L_113) == ((int32_t)0))? 1 : 0);
		goto IL_0204;
	}

IL_0203:
	{
		G_B20_0 = 1;
	}

IL_0204:
	{
		V_11 = (bool)G_B20_0;
		bool L_114 = V_11;
		if (!L_114)
		{
			goto IL_021b;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_115 = ((CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_StaticFields*)il2cpp_codegen_static_fields_for(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var))->___kNoPoint_3;
		(&V_1)->___ReferenceLookAt_2 = L_115;
		goto IL_0318;
	}

IL_021b:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_116 = ___stateA0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_117 = L_116.___Lens_0;
		float L_118 = L_117.___FieldOfView_1;
		V_12 = L_118;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_119 = ___stateB1;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_120 = L_119.___Lens_0;
		float L_121 = L_120.___FieldOfView_1;
		V_13 = L_121;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_122 = ___stateA0;
		int32_t L_123 = L_122.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_124 = ___stateB1;
		int32_t L_125 = L_124.___BlendHint_10;
		if (((int32_t)(((int32_t)((int32_t)L_123|(int32_t)L_125))&((int32_t)64))))
		{
			goto IL_0264;
		}
	}
	{
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_126 = (&(&V_1)->___Lens_0);
		bool L_127;
		L_127 = LensSettings_get_Orthographic_m198D9052494017EEE832066A64F81ADD2B75C17D(L_126, NULL);
		if (L_127)
		{
			goto IL_0264;
		}
	}
	{
		float L_128 = V_12;
		float L_129 = V_13;
		bool L_130;
		L_130 = Mathf_Approximately_m1C8DD0BB6A2D22A7DCF09AD7F8EE9ABD12D3F620_inline(L_128, L_129, NULL);
		G_B26_0 = ((((int32_t)L_130) == ((int32_t)0))? 1 : 0);
		goto IL_0265;
	}

IL_0264:
	{
		G_B26_0 = 0;
	}

IL_0265:
	{
		V_14 = (bool)G_B26_0;
		bool L_131 = V_14;
		if (!L_131)
		{
			goto IL_02fe;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_132 = V_1;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_133 = L_132.___Lens_0;
		V_15 = L_133;
		float L_134 = V_12;
		float L_135 = V_13;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_136 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_137 = L_136.___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_138;
		L_138 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089((&___stateA0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_139;
		L_139 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_137, L_138, NULL);
		V_16 = L_139;
		float L_140;
		L_140 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_16), NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_141 = ___stateA0;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_142 = L_141.___Lens_0;
		float L_143 = L_142.___NearClipPlane_3;
		float L_144;
		L_144 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_140, L_143, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_145 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_146 = L_145.___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_147;
		L_147 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089((&___stateB1), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_148;
		L_148 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_146, L_147, NULL);
		V_16 = L_148;
		float L_149;
		L_149 = Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline((&V_16), NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_150 = ___stateB1;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_151 = L_150.___Lens_0;
		float L_152 = L_151.___NearClipPlane_3;
		float L_153;
		L_153 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_149, L_152, NULL);
		float L_154 = ___t2;
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		float L_155;
		L_155 = CameraState_InterpolateFOV_m282EABB08641EDA6F6AA12818B9BE6D76639AFE1(L_134, L_135, L_144, L_153, L_154, NULL);
		(&V_15)->___FieldOfView_1 = L_155;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_156 = V_15;
		(&V_1)->___Lens_0 = L_156;
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE L_157 = V_15;
		float L_158 = L_157.___FieldOfView_1;
		float L_159 = V_12;
		float L_160 = V_13;
		float L_161 = V_12;
		float L_162;
		L_162 = fabsf(((float)(((float)il2cpp_codegen_subtract(L_158, L_159))/((float)il2cpp_codegen_subtract(L_160, L_161)))));
		V_0 = L_162;
	}

IL_02fe:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_163 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_164 = L_163.___ReferenceLookAt_2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_165 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_166 = L_165.___ReferenceLookAt_2;
		float L_167 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_168;
		L_168 = Vector3_Lerp_m57EE8D709A93B2B0FF8D499FA2947B1D61CB1FD6_inline(L_164, L_166, L_167, NULL);
		(&V_1)->___ReferenceLookAt_2 = L_168;
	}

IL_0318:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_169 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_170 = L_169.___RawPosition_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_171 = ___stateA0;
		int32_t L_172 = L_171.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_173 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_174 = L_173.___RawPosition_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_175 = ___stateB1;
		int32_t L_176 = L_175.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_177 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_178 = L_177.___RawPosition_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_179 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_180 = L_179.___RawPosition_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_181 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_182 = L_181.___ReferenceLookAt_2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_183 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_184 = L_183.___RawPosition_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_185 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_186 = L_185.___ReferenceLookAt_2;
		float L_187 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_188;
		L_188 = CameraState_InterpolatePosition_m0754A646434C49674356B584F9BDBB67B0D4F707((&V_1), L_180, L_182, L_184, L_186, L_187, NULL);
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_189;
		L_189 = CameraState_ApplyPosBlendHint_m652243F6FEEC671040EE65DDF83A1446305357CC(L_170, L_172, L_174, L_176, L_178, L_188, NULL);
		(&V_1)->___RawPosition_4 = L_189;
		bool L_190;
		L_190 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC((&V_1), NULL);
		if (!L_190)
		{
			goto IL_0380;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_191 = ___stateA0;
		int32_t L_192 = L_191.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_193 = ___stateB1;
		int32_t L_194 = L_193.___BlendHint_10;
		G_B32_0 = ((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_192|(int32_t)L_194))&((int32_t)16)))) <= ((uint32_t)0)))? 1 : 0);
		goto IL_0381;
	}

IL_0380:
	{
		G_B32_0 = 0;
	}

IL_0381:
	{
		V_17 = (bool)G_B32_0;
		bool L_195 = V_17;
		if (!L_195)
		{
			goto IL_03c3;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_196 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_197 = L_196.___RawPosition_4;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_198 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_199 = L_198.___ReferenceLookAt_2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_200 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_201 = L_200.___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_202;
		L_202 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_199, L_201, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_203 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_204 = L_203.___ReferenceLookAt_2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_205 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_206 = L_205.___RawPosition_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_207;
		L_207 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_204, L_206, NULL);
		float L_208 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_209;
		L_209 = Vector3_Slerp_mBA32C7EAC64C56C7D68480549FA9A892FA5C1728(L_202, L_207, L_208, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_210;
		L_210 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_197, L_209, NULL);
		(&V_1)->___ReferenceLookAt_2 = L_210;
	}

IL_03c3:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_211 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_212 = L_211.___RawOrientation_5;
		V_2 = L_212;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_213 = ___stateA0;
		int32_t L_214 = L_213.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_215 = ___stateB1;
		int32_t L_216 = L_215.___BlendHint_10;
		V_18 = (bool)((((int32_t)((int32_t)(((int32_t)((int32_t)L_214|(int32_t)L_216))&2))) == ((int32_t)0))? 1 : 0);
		bool L_217 = V_18;
		if (!L_217)
		{
			goto IL_053a;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_218;
		L_218 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_19 = L_218;
		bool L_219;
		L_219 = CameraState_get_HasLookAt_m2581CDE02E0998E65DF1AA58B170AAB84CBFD0AC((&V_1), NULL);
		V_20 = L_219;
		bool L_220 = V_20;
		if (!L_220)
		{
			goto IL_0432;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_221 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_222 = L_221.___RawOrientation_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_223 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_224 = L_223.___RawOrientation_5;
		float L_225;
		L_225 = Quaternion_Angle_m445E005E6F9211283EEA3F0BD4FF2DC20FE3640A_inline(L_222, L_224, NULL);
		V_21 = L_225;
		float L_226 = V_21;
		V_22 = (bool)((((float)L_226) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_227 = V_22;
		if (!L_227)
		{
			goto IL_0431;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_228 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_229 = L_228.___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_230;
		L_230 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089((&V_1), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_231;
		L_231 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_229, L_230, NULL);
		V_19 = L_231;
	}

IL_0431:
	{
	}

IL_0432:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_232 = V_19;
		bool L_233;
		L_233 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_232, NULL);
		if (L_233)
		{
			goto IL_0450;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_234 = ___stateA0;
		int32_t L_235 = L_234.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_236 = ___stateB1;
		int32_t L_237 = L_236.___BlendHint_10;
		G_B42_0 = ((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_235|(int32_t)L_237))&((int32_t)32)))) <= ((uint32_t)0)))? 1 : 0);
		goto IL_0451;
	}

IL_0450:
	{
		G_B42_0 = 1;
	}

IL_0451:
	{
		V_23 = (bool)G_B42_0;
		bool L_238 = V_23;
		if (!L_238)
		{
			goto IL_0477;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_239 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_240 = L_239.___RawOrientation_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_241 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_242 = L_241.___RawOrientation_5;
		float L_243 = ___t2;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_244 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_245 = L_244.___ReferenceUp_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_246;
		L_246 = UnityQuaternionExtensions_SlerpWithReferenceUp_m462C015C97FF4D2E7B7E83B6C1E4A29ED4DD1474(L_240, L_242, L_243, L_245, NULL);
		V_2 = L_246;
		goto IL_0539;
	}

IL_0477:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_247 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_248 = L_247.___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_249;
		L_249 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_250;
		L_250 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_248, L_249, NULL);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_251 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_252 = L_251.___RawOrientation_5;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_253;
		L_253 = Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline(NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_254;
		L_254 = Quaternion_op_Multiply_mF1348668A6CCD46FBFF98D39182F89358ED74AC0(L_252, L_253, NULL);
		float L_255 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_256;
		L_256 = Vector3_Slerp_mBA32C7EAC64C56C7D68480549FA9A892FA5C1728(L_250, L_254, L_255, NULL);
		V_24 = L_256;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_257 = V_19;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_258 = V_24;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_259;
		L_259 = Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline(L_257, L_258, NULL);
		bool L_260;
		L_260 = UnityVectorExtensions_AlmostZero_mB3A4F32774344F1374F65D503CC29C569F5F7D24(L_259, NULL);
		V_25 = L_260;
		bool L_261 = V_25;
		if (!L_261)
		{
			goto IL_04cd;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_262 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_263 = L_262.___RawOrientation_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_264 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_265 = L_264.___RawOrientation_5;
		float L_266 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_267 = V_24;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_268;
		L_268 = UnityQuaternionExtensions_SlerpWithReferenceUp_m462C015C97FF4D2E7B7E83B6C1E4A29ED4DD1474(L_263, L_265, L_266, L_267, NULL);
		V_2 = L_268;
		goto IL_0538;
	}

IL_04cd:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_269 = V_19;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_270 = V_24;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_271;
		L_271 = Quaternion_LookRotation_mE6859FEBE85BC0AE72A14159988151FF69BF4401(L_269, L_270, NULL);
		V_2 = L_271;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_272 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_273 = L_272.___RawOrientation_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_274 = ___stateA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_275 = L_274.___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_276;
		L_276 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089((&___stateA0), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_277;
		L_277 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_275, L_276, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_278 = V_24;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_279;
		L_279 = UnityQuaternionExtensions_GetCameraRotationToTarget_mDA1EF1466263B671B863D70DABBD50DF9785C2B7(L_273, L_277, L_278, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_280;
		L_280 = Vector2_op_UnaryNegation_m47556D28F72B018AC4D5160710C83A805F10A783_inline(L_279, NULL);
		V_26 = L_280;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_281 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_282 = L_281.___RawOrientation_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_283 = ___stateB1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_284 = L_283.___ReferenceLookAt_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_285;
		L_285 = CameraState_get_CorrectedPosition_m2F96F0F6D3AE57BCEDE566FCE49D1488CA057089((&___stateB1), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_286;
		L_286 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_284, L_285, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_287 = V_24;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_288;
		L_288 = UnityQuaternionExtensions_GetCameraRotationToTarget_mDA1EF1466263B671B863D70DABBD50DF9785C2B7(L_282, L_286, L_287, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_289;
		L_289 = Vector2_op_UnaryNegation_m47556D28F72B018AC4D5160710C83A805F10A783_inline(L_288, NULL);
		V_27 = L_289;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_290 = V_2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_291 = V_26;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_292 = V_27;
		float L_293 = V_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_294;
		L_294 = Vector2_Lerp_mF3BD6827807680A529E800FD027734D40A3597E1_inline(L_291, L_292, L_293, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_295 = V_24;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_296;
		L_296 = UnityQuaternionExtensions_ApplyCameraRotation_m75753B356C2E3BC79192192C8C2FC1F512643506(L_290, L_294, L_295, NULL);
		V_2 = L_296;
	}

IL_0538:
	{
	}

IL_0539:
	{
	}

IL_053a:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_297 = ___stateA0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_298 = L_297.___RawOrientation_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_299 = ___stateA0;
		int32_t L_300 = L_299.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_301 = ___stateB1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_302 = L_301.___RawOrientation_5;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_303 = ___stateB1;
		int32_t L_304 = L_303.___BlendHint_10;
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_305 = V_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_306 = L_305.___RawOrientation_5;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_307 = V_2;
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_308;
		L_308 = CameraState_ApplyRotBlendHint_mF25F7D3F9315C2CE92CBB65CC06D519C228C3571(L_298, L_300, L_302, L_304, L_306, L_307, NULL);
		(&V_1)->___RawOrientation_5 = L_308;
		V_28 = 0;
		goto IL_05ad;
	}

IL_056a:
	{
		int32_t L_309 = V_28;
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_310;
		L_310 = CameraState_GetCustomBlendable_mE19B33F6CEC1B42ACAEB34A0601E48A80577498E((&___stateA0), L_309, NULL);
		V_29 = L_310;
		float* L_311 = (&(&V_29)->___m_Weight_1);
		float* L_312 = L_311;
		float L_313 = *((float*)L_312);
		float L_314 = ___t2;
		*((float*)L_312) = (float)((float)il2cpp_codegen_multiply(L_313, ((float)il2cpp_codegen_subtract((1.0f), L_314))));
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_315 = V_29;
		float L_316 = L_315.___m_Weight_1;
		V_30 = (bool)((((float)L_316) > ((float)(0.0f)))? 1 : 0);
		bool L_317 = V_30;
		if (!L_317)
		{
			goto IL_05a6;
		}
	}
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_318 = V_29;
		CameraState_AddCustomBlendable_m1DA24CB5A397752C33B6A1773CFF38F02505AD3C((&V_1), L_318, NULL);
	}

IL_05a6:
	{
		int32_t L_319 = V_28;
		V_28 = ((int32_t)il2cpp_codegen_add(L_319, 1));
	}

IL_05ad:
	{
		int32_t L_320 = V_28;
		int32_t L_321;
		L_321 = CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB_inline((&___stateA0), NULL);
		V_31 = (bool)((((int32_t)L_320) < ((int32_t)L_321))? 1 : 0);
		bool L_322 = V_31;
		if (L_322)
		{
			goto IL_056a;
		}
	}
	{
		V_32 = 0;
		goto IL_0600;
	}

IL_05c3:
	{
		int32_t L_323 = V_32;
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_324;
		L_324 = CameraState_GetCustomBlendable_mE19B33F6CEC1B42ACAEB34A0601E48A80577498E((&___stateB1), L_323, NULL);
		V_33 = L_324;
		float* L_325 = (&(&V_33)->___m_Weight_1);
		float* L_326 = L_325;
		float L_327 = *((float*)L_326);
		float L_328 = ___t2;
		*((float*)L_326) = (float)((float)il2cpp_codegen_multiply(L_327, L_328));
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_329 = V_33;
		float L_330 = L_329.___m_Weight_1;
		V_34 = (bool)((((float)L_330) > ((float)(0.0f)))? 1 : 0);
		bool L_331 = V_34;
		if (!L_331)
		{
			goto IL_05f9;
		}
	}
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_332 = V_33;
		CameraState_AddCustomBlendable_m1DA24CB5A397752C33B6A1773CFF38F02505AD3C((&V_1), L_332, NULL);
	}

IL_05f9:
	{
		int32_t L_333 = V_32;
		V_32 = ((int32_t)il2cpp_codegen_add(L_333, 1));
	}

IL_0600:
	{
		int32_t L_334 = V_32;
		int32_t L_335;
		L_335 = CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB_inline((&___stateB1), NULL);
		V_35 = (bool)((((int32_t)L_334) < ((int32_t)L_335))? 1 : 0);
		bool L_336 = V_35;
		if (L_336)
		{
			goto IL_05c3;
		}
	}
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_337 = V_1;
		V_36 = L_337;
		goto IL_0616;
	}

IL_0616:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_338 = V_36;
		return L_338;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CameraState_InterpolateFOV_m282EABB08641EDA6F6AA12818B9BE6D76639AFE1 (float ___fovA0, float ___fovB1, float ___dA2, float ___dB3, float ___t4, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	float V_4 = 0.0f;
	bool V_5 = false;
	float V_6 = 0.0f;
	{
		float L_0 = ___dA2;
		float L_1 = ___fovA0;
		float L_2;
		L_2 = tanf(((float)(((float)il2cpp_codegen_multiply(L_1, (0.0174532924f)))/(2.0f))));
		V_0 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply(L_0, (2.0f))), L_2));
		float L_3 = ___dB3;
		float L_4 = ___fovB1;
		float L_5;
		L_5 = tanf(((float)(((float)il2cpp_codegen_multiply(L_4, (0.0174532924f)))/(2.0f))));
		V_1 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply(L_3, (2.0f))), L_5));
		float L_6 = V_0;
		float L_7 = V_1;
		float L_8 = ___t4;
		float L_9;
		L_9 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline(L_6, L_7, L_8, NULL);
		V_2 = L_9;
		V_3 = (179.0f);
		float L_10 = ___dA2;
		float L_11 = ___dB3;
		float L_12 = ___t4;
		float L_13;
		L_13 = Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline(L_10, L_11, L_12, NULL);
		V_4 = L_13;
		float L_14 = V_4;
		V_5 = (bool)((((float)L_14) > ((float)(9.99999975E-05f)))? 1 : 0);
		bool L_15 = V_5;
		if (!L_15)
		{
			goto IL_007d;
		}
	}
	{
		float L_16 = V_2;
		float L_17 = V_4;
		float L_18;
		L_18 = atanf(((float)(L_16/((float)il2cpp_codegen_multiply((2.0f), L_17)))));
		V_3 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply((2.0f), L_18)), (57.2957802f)));
	}

IL_007d:
	{
		float L_19 = V_3;
		float L_20 = ___fovA0;
		float L_21 = ___fovB1;
		float L_22;
		L_22 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_20, L_21, NULL);
		float L_23 = ___fovA0;
		float L_24 = ___fovB1;
		float L_25;
		L_25 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_23, L_24, NULL);
		float L_26;
		L_26 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(L_19, L_22, L_25, NULL);
		V_6 = L_26;
		goto IL_0095;
	}

IL_0095:
	{
		float L_27 = V_6;
		return L_27;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_ApplyPosBlendHint_m652243F6FEEC671040EE65DDF83A1446305357CC (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posA0, int32_t ___hintA1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posB2, int32_t ___hintB3, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___original4, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___blended5, const RuntimeMethod* method) 
{
	bool V_0 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	bool V_3 = false;
	{
		int32_t L_0 = ___hintA1;
		int32_t L_1 = ___hintB3;
		V_0 = (bool)((((int32_t)((int32_t)(((int32_t)((int32_t)L_0|(int32_t)L_1))&1))) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0012;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___blended5;
		V_1 = L_3;
		goto IL_0035;
	}

IL_0012:
	{
		int32_t L_4 = ___hintA1;
		int32_t L_5 = ___hintB3;
		V_2 = (bool)((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_4&(int32_t)L_5))&1))) <= ((uint32_t)0)))? 1 : 0);
		bool L_6 = V_2;
		if (!L_6)
		{
			goto IL_0023;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___original4;
		V_1 = L_7;
		goto IL_0035;
	}

IL_0023:
	{
		int32_t L_8 = ___hintA1;
		V_3 = (bool)((!(((uint32_t)((int32_t)((int32_t)L_8&1))) <= ((uint32_t)0)))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_0031;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___posB2;
		V_1 = L_10;
		goto IL_0035;
	}

IL_0031:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = ___posA0;
		V_1 = L_11;
		goto IL_0035;
	}

IL_0035:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = V_1;
		return L_12;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 CameraState_ApplyRotBlendHint_mF25F7D3F9315C2CE92CBB65CC06D519C228C3571 (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotA0, int32_t ___hintA1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotB2, int32_t ___hintB3, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___original4, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___blended5, const RuntimeMethod* method) 
{
	bool V_0 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	bool V_3 = false;
	{
		int32_t L_0 = ___hintA1;
		int32_t L_1 = ___hintB3;
		V_0 = (bool)((((int32_t)((int32_t)(((int32_t)((int32_t)L_0|(int32_t)L_1))&2))) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0012;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3 = ___blended5;
		V_1 = L_3;
		goto IL_0035;
	}

IL_0012:
	{
		int32_t L_4 = ___hintA1;
		int32_t L_5 = ___hintB3;
		V_2 = (bool)((!(((uint32_t)((int32_t)(((int32_t)((int32_t)L_4&(int32_t)L_5))&2))) <= ((uint32_t)0)))? 1 : 0);
		bool L_6 = V_2;
		if (!L_6)
		{
			goto IL_0023;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_7 = ___original4;
		V_1 = L_7;
		goto IL_0035;
	}

IL_0023:
	{
		int32_t L_8 = ___hintA1;
		V_3 = (bool)((!(((uint32_t)((int32_t)((int32_t)L_8&2))) <= ((uint32_t)0)))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_0031;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_10 = ___rotB2;
		V_1 = L_10;
		goto IL_0035;
	}

IL_0031:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_11 = ___rotA0;
		V_1 = L_11;
		goto IL_0035;
	}

IL_0035:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12 = V_1;
		return L_12;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_InterpolatePosition_m0754A646434C49674356B584F9BDBB67B0D4F707 (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posA0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pivotA1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posB2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pivotB3, float ___t4, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_3;
	memset((&V_3), 0, sizeof(V_3));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_4;
	memset((&V_4), 0, sizeof(V_4));
	bool V_5 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_6;
	memset((&V_6), 0, sizeof(V_6));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_7;
	memset((&V_7), 0, sizeof(V_7));
	int32_t G_B3_0 = 0;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___pivotA1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___pivotA1;
		bool L_2;
		L_2 = Vector3_op_Equality_m15951D1B53E3BE36C9D265E229090020FBD72EBB_inline(L_0, L_1, NULL);
		if (!L_2)
		{
			goto IL_0015;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___pivotB3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___pivotB3;
		bool L_5;
		L_5 = Vector3_op_Equality_m15951D1B53E3BE36C9D265E229090020FBD72EBB_inline(L_3, L_4, NULL);
		G_B3_0 = ((int32_t)(L_5));
		goto IL_0016;
	}

IL_0015:
	{
		G_B3_0 = 0;
	}

IL_0016:
	{
		V_0 = (bool)G_B3_0;
		bool L_6 = V_0;
		if (!L_6)
		{
			goto IL_00c4;
		}
	}
	{
		int32_t L_7 = __this->___BlendHint_10;
		V_1 = (bool)((!(((uint32_t)((int32_t)((int32_t)L_7&8))) <= ((uint32_t)0)))? 1 : 0);
		bool L_8 = V_1;
		if (!L_8)
		{
			goto IL_0083;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = ___posA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___pivotA1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_9, L_10, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = __this->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13;
		L_13 = Vector3_ProjectOnPlane_mCAFA9F9416EA4740DCA8757B6E52260BF536770A_inline(L_11, L_12, NULL);
		V_2 = L_13;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = ___posB2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = ___pivotB3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16;
		L_16 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_14, L_15, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = __this->___ReferenceUp_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18;
		L_18 = Vector3_ProjectOnPlane_mCAFA9F9416EA4740DCA8757B6E52260BF536770A_inline(L_16, L_17, NULL);
		V_3 = L_18;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = V_3;
		float L_21 = ___t4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22;
		L_22 = Vector3_Slerp_mBA32C7EAC64C56C7D68480549FA9A892FA5C1728(L_19, L_20, L_21, NULL);
		V_4 = L_22;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = ___posA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25;
		L_25 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_23, L_24, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_26 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27;
		L_27 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_25, L_26, NULL);
		___posA0 = L_27;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28 = ___posB2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29 = V_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		L_30 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_28, L_29, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_31 = V_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_32;
		L_32 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_30, L_31, NULL);
		___posB2 = L_32;
		goto IL_00c3;
	}

IL_0083:
	{
		int32_t L_33 = __this->___BlendHint_10;
		V_5 = (bool)((!(((uint32_t)((int32_t)((int32_t)L_33&4))) <= ((uint32_t)0)))? 1 : 0);
		bool L_34 = V_5;
		if (!L_34)
		{
			goto IL_00c3;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_35 = ___posA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36 = ___pivotA1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_37;
		L_37 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_35, L_36, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_38 = ___posB2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39 = ___pivotB3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40;
		L_40 = Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline(L_38, L_39, NULL);
		float L_41 = ___t4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_42;
		L_42 = Vector3_Slerp_mBA32C7EAC64C56C7D68480549FA9A892FA5C1728(L_37, L_40, L_41, NULL);
		V_6 = L_42;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43 = ___pivotA1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_44 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_45;
		L_45 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_43, L_44, NULL);
		___posA0 = L_45;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46 = ___pivotB3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_48;
		L_48 = Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline(L_46, L_47, NULL);
		___posB2 = L_48;
	}

IL_00c3:
	{
	}

IL_00c4:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_49 = ___posA0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50 = ___posB2;
		float L_51 = ___t4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_52;
		L_52 = Vector3_Lerp_m57EE8D709A93B2B0FF8D499FA2947B1D61CB1FD6_inline(L_49, L_50, L_51, NULL);
		V_7 = L_52;
		goto IL_00d1;
	}

IL_00d1:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_53 = V_7;
		return L_53;
	}
}
IL2CPP_EXTERN_C  Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CameraState_InterpolatePosition_m0754A646434C49674356B584F9BDBB67B0D4F707_AdjustorThunk (RuntimeObject* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posA0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pivotA1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___posB2, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___pivotB3, float ___t4, const RuntimeMethod* method)
{
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156*>(__this + _offset);
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 _returnValue;
	_returnValue = CameraState_InterpolatePosition_m0754A646434C49674356B584F9BDBB67B0D4F707(_thisAdjusted, ___posA0, ___pivotA1, ___posB2, ___pivotB3, ___t4, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CameraState__cctor_m9BBB4AD958A7ABC70589EEDE18AF906E59EFF584 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		memset((&L_0), 0, sizeof(L_0));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_0), (std::numeric_limits<float>::quiet_NaN()), (std::numeric_limits<float>::quiet_NaN()), (std::numeric_limits<float>::quiet_NaN()), NULL);
		((CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_StaticFields*)il2cpp_codegen_static_fields_for(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var))->___kNoPoint_3 = L_0;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CustomBlendable__ctor_mF38BF574AF05E415A01A2A46E506DE6B5086B303 (CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* __this, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___custom0, float ___weight1, const RuntimeMethod* method) 
{
	{
		Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* L_0 = ___custom0;
		__this->___m_Custom_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___m_Custom_0), (void*)L_0);
		float L_1 = ___weight1;
		__this->___m_Weight_1 = L_1;
		return;
	}
}
IL2CPP_EXTERN_C  void CustomBlendable__ctor_mF38BF574AF05E415A01A2A46E506DE6B5086B303_AdjustorThunk (RuntimeObject* __this, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___custom0, float ___weight1, const RuntimeMethod* method)
{
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB*>(__this + _offset);
	CustomBlendable__ctor_mF38BF574AF05E415A01A2A46E506DE6B5086B303(_thisAdjusted, ___custom0, ___weight1, method);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float CinemachineBlend_get_BlendWeight_m0FFFD553C4A1176490E443AF34DC8AB87F0763A7 (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	float V_1 = 0.0f;
	int32_t G_B4_0 = 0;
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_0 = __this->___BlendCurve_2;
		if (!L_0)
		{
			goto IL_001f;
		}
	}
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_1 = __this->___BlendCurve_2;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = AnimationCurve_get_length_m259A67BB0870D3A153F6FEDBB06CB0D24089CD81(L_1, NULL);
		if ((((int32_t)L_2) < ((int32_t)2)))
		{
			goto IL_001f;
		}
	}
	{
		bool L_3;
		L_3 = CinemachineBlend_get_IsComplete_m927128CEC49DCADF02A6258F8D636B0957446686(__this, NULL);
		G_B4_0 = ((int32_t)(L_3));
		goto IL_0020;
	}

IL_001f:
	{
		G_B4_0 = 1;
	}

IL_0020:
	{
		V_0 = (bool)G_B4_0;
		bool L_4 = V_0;
		if (!L_4)
		{
			goto IL_002c;
		}
	}
	{
		V_1 = (1.0f);
		goto IL_004c;
	}

IL_002c:
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___BlendCurve_2;
		float L_6 = __this->___TimeInBlend_3;
		float L_7 = __this->___Duration_4;
		NullCheck(L_5);
		float L_8;
		L_8 = AnimationCurve_Evaluate_m50B857043DE251A186032ADBCBB4CEF817F4EE3C(L_5, ((float)(L_6/L_7)), NULL);
		float L_9;
		L_9 = Mathf_Clamp01_mD921B23F47F5347996C56DC789D1DE16EE27D9B1_inline(L_8, NULL);
		V_1 = L_9;
		goto IL_004c;
	}

IL_004c:
	{
		float L_10 = V_1;
		return L_10;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineBlend_get_IsValid_m3C10BCF867EF0AA96AAF0A70FF0990808FB7C81C (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t G_B5_0 = 0;
	int32_t G_B7_0 = 0;
	{
		RuntimeObject* L_0 = __this->___CamA_0;
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		RuntimeObject* L_1 = __this->___CamA_0;
		NullCheck(L_1);
		bool L_2;
		L_2 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_1);
		if (L_2)
		{
			goto IL_002d;
		}
	}

IL_0015:
	{
		RuntimeObject* L_3 = __this->___CamB_1;
		if (!L_3)
		{
			goto IL_002a;
		}
	}
	{
		RuntimeObject* L_4 = __this->___CamB_1;
		NullCheck(L_4);
		bool L_5;
		L_5 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_4);
		G_B5_0 = ((int32_t)(L_5));
		goto IL_002b;
	}

IL_002a:
	{
		G_B5_0 = 0;
	}

IL_002b:
	{
		G_B7_0 = G_B5_0;
		goto IL_002e;
	}

IL_002d:
	{
		G_B7_0 = 1;
	}

IL_002e:
	{
		return (bool)G_B7_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineBlend_get_IsComplete_m927128CEC49DCADF02A6258F8D636B0957446686 (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		float L_0 = __this->___TimeInBlend_3;
		float L_1 = __this->___Duration_4;
		if ((((float)L_0) >= ((float)L_1)))
		{
			goto IL_0019;
		}
	}
	{
		bool L_2;
		L_2 = CinemachineBlend_get_IsValid_m3C10BCF867EF0AA96AAF0A70FF0990808FB7C81C(__this, NULL);
		G_B3_0 = ((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		goto IL_001a;
	}

IL_0019:
	{
		G_B3_0 = 1;
	}

IL_001a:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* CinemachineBlend_get_Description_mC4378A79CCE5E2FF0FA5A175B6AB3DF7E6A6374C (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2386E77CF610F786B06A91AF2C1B3FD2282D2745);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9D254E50F4DE5BE7CA9E72BD2F890B87F910B88B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9F7A4B6C54C2F1E1424871D9ED5587D887F72E3C);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD9691C4FD8A1F6B09DB1147CA32B442772FB46A1);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE166C9564FBDE461738077E3B1B506525EB6ACCC);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t* V_0 = NULL;
	String_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	String_t* V_4 = NULL;
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		StringBuilder_t* L_0;
		L_0 = CinemachineDebug_SBFromPool_m6F20FF73A5A0C5B5CD7D53ADC0887782A70DB5E5(NULL);
		V_0 = L_0;
		RuntimeObject* L_1 = __this->___CamB_1;
		if (!L_1)
		{
			goto IL_001f;
		}
	}
	{
		RuntimeObject* L_2 = __this->___CamB_1;
		NullCheck(L_2);
		bool L_3;
		L_3 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_2);
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0020;
	}

IL_001f:
	{
		G_B3_0 = 1;
	}

IL_0020:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0032;
		}
	}
	{
		StringBuilder_t* L_5 = V_0;
		NullCheck(L_5);
		StringBuilder_t* L_6;
		L_6 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_5, _stringLiteral9D254E50F4DE5BE7CA9E72BD2F890B87F910B88B, NULL);
		goto IL_005e;
	}

IL_0032:
	{
		StringBuilder_t* L_7 = V_0;
		NullCheck(L_7);
		StringBuilder_t* L_8;
		L_8 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_7, _stringLiteralD9691C4FD8A1F6B09DB1147CA32B442772FB46A1, NULL);
		StringBuilder_t* L_9 = V_0;
		RuntimeObject* L_10 = __this->___CamB_1;
		NullCheck(L_10);
		String_t* L_11;
		L_11 = InterfaceFuncInvoker0< String_t* >::Invoke(0, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_10);
		NullCheck(L_9);
		StringBuilder_t* L_12;
		L_12 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_9, L_11, NULL);
		StringBuilder_t* L_13 = V_0;
		NullCheck(L_13);
		StringBuilder_t* L_14;
		L_14 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_13, _stringLiteralE166C9564FBDE461738077E3B1B506525EB6ACCC, NULL);
	}

IL_005e:
	{
		StringBuilder_t* L_15 = V_0;
		NullCheck(L_15);
		StringBuilder_t* L_16;
		L_16 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_15, _stringLiteral2386E77CF610F786B06A91AF2C1B3FD2282D2745, NULL);
		StringBuilder_t* L_17 = V_0;
		float L_18;
		L_18 = CinemachineBlend_get_BlendWeight_m0FFFD553C4A1176490E443AF34DC8AB87F0763A7(__this, NULL);
		NullCheck(L_17);
		StringBuilder_t* L_19;
		L_19 = StringBuilder_Append_m283B617AC29FB0DD6F3A7D8C01D385C25A5F0FAA(L_17, il2cpp_codegen_cast_double_to_int<int32_t>(((float)il2cpp_codegen_multiply(L_18, (100.0f)))), NULL);
		StringBuilder_t* L_20 = V_0;
		NullCheck(L_20);
		StringBuilder_t* L_21;
		L_21 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_20, _stringLiteral9F7A4B6C54C2F1E1424871D9ED5587D887F72E3C, NULL);
		RuntimeObject* L_22 = __this->___CamA_0;
		if (!L_22)
		{
			goto IL_00a2;
		}
	}
	{
		RuntimeObject* L_23 = __this->___CamA_0;
		NullCheck(L_23);
		bool L_24;
		L_24 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_23);
		G_B9_0 = ((((int32_t)L_24) == ((int32_t)0))? 1 : 0);
		goto IL_00a3;
	}

IL_00a2:
	{
		G_B9_0 = 1;
	}

IL_00a3:
	{
		V_3 = (bool)G_B9_0;
		bool L_25 = V_3;
		if (!L_25)
		{
			goto IL_00b5;
		}
	}
	{
		StringBuilder_t* L_26 = V_0;
		NullCheck(L_26);
		StringBuilder_t* L_27;
		L_27 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_26, _stringLiteral9D254E50F4DE5BE7CA9E72BD2F890B87F910B88B, NULL);
		goto IL_00e1;
	}

IL_00b5:
	{
		StringBuilder_t* L_28 = V_0;
		NullCheck(L_28);
		StringBuilder_t* L_29;
		L_29 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_28, _stringLiteralD9691C4FD8A1F6B09DB1147CA32B442772FB46A1, NULL);
		StringBuilder_t* L_30 = V_0;
		RuntimeObject* L_31 = __this->___CamA_0;
		NullCheck(L_31);
		String_t* L_32;
		L_32 = InterfaceFuncInvoker0< String_t* >::Invoke(0, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_31);
		NullCheck(L_30);
		StringBuilder_t* L_33;
		L_33 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_30, L_32, NULL);
		StringBuilder_t* L_34 = V_0;
		NullCheck(L_34);
		StringBuilder_t* L_35;
		L_35 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_34, _stringLiteralE166C9564FBDE461738077E3B1B506525EB6ACCC, NULL);
	}

IL_00e1:
	{
		StringBuilder_t* L_36 = V_0;
		NullCheck(L_36);
		String_t* L_37;
		L_37 = VirtualFuncInvoker0< String_t* >::Invoke(3, L_36);
		V_1 = L_37;
		StringBuilder_t* L_38 = V_0;
		CinemachineDebug_ReturnToPool_m486386674DD5B04481BC7B3FAB351E6122EE8630(L_38, NULL);
		String_t* L_39 = V_1;
		V_4 = L_39;
		goto IL_00f4;
	}

IL_00f4:
	{
		String_t* L_40 = V_4;
		return L_40;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CinemachineBlend_Uses_m7EC8B1160B3D24C5609684B486D485B2DD806A26 (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, RuntimeObject* ___cam0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E* V_0 = NULL;
	bool V_1 = false;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B8_0 = 0;
	int32_t G_B13_0 = 0;
	{
		RuntimeObject* L_0 = ___cam0;
		RuntimeObject* L_1 = __this->___CamA_0;
		if ((((RuntimeObject*)(RuntimeObject*)L_0) == ((RuntimeObject*)(RuntimeObject*)L_1)))
		{
			goto IL_0015;
		}
	}
	{
		RuntimeObject* L_2 = ___cam0;
		RuntimeObject* L_3 = __this->___CamB_1;
		G_B3_0 = ((((RuntimeObject*)(RuntimeObject*)L_2) == ((RuntimeObject*)(RuntimeObject*)L_3))? 1 : 0);
		goto IL_0016;
	}

IL_0015:
	{
		G_B3_0 = 1;
	}

IL_0016:
	{
		V_1 = (bool)G_B3_0;
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_001e;
		}
	}
	{
		V_2 = (bool)1;
		goto IL_0070;
	}

IL_001e:
	{
		RuntimeObject* L_5 = __this->___CamA_0;
		V_0 = ((BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E*)IsInstClass((RuntimeObject*)L_5, BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E_il2cpp_TypeInfo_var));
		BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E* L_6 = V_0;
		if (!L_6)
		{
			goto IL_003b;
		}
	}
	{
		BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E* L_7 = V_0;
		NullCheck(L_7);
		CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* L_8;
		L_8 = BlendSourceVirtualCamera_get_Blend_mAEA739F5A13237AF89E38325902ECA8316FC5719_inline(L_7, NULL);
		RuntimeObject* L_9 = ___cam0;
		NullCheck(L_8);
		bool L_10;
		L_10 = CinemachineBlend_Uses_m7EC8B1160B3D24C5609684B486D485B2DD806A26(L_8, L_9, NULL);
		G_B8_0 = ((int32_t)(L_10));
		goto IL_003c;
	}

IL_003b:
	{
		G_B8_0 = 0;
	}

IL_003c:
	{
		V_3 = (bool)G_B8_0;
		bool L_11 = V_3;
		if (!L_11)
		{
			goto IL_0044;
		}
	}
	{
		V_2 = (bool)1;
		goto IL_0070;
	}

IL_0044:
	{
		RuntimeObject* L_12 = __this->___CamB_1;
		V_0 = ((BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E*)IsInstClass((RuntimeObject*)L_12, BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E_il2cpp_TypeInfo_var));
		BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E* L_13 = V_0;
		if (!L_13)
		{
			goto IL_0061;
		}
	}
	{
		BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E* L_14 = V_0;
		NullCheck(L_14);
		CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* L_15;
		L_15 = BlendSourceVirtualCamera_get_Blend_mAEA739F5A13237AF89E38325902ECA8316FC5719_inline(L_14, NULL);
		RuntimeObject* L_16 = ___cam0;
		NullCheck(L_15);
		bool L_17;
		L_17 = CinemachineBlend_Uses_m7EC8B1160B3D24C5609684B486D485B2DD806A26(L_15, L_16, NULL);
		G_B13_0 = ((int32_t)(L_17));
		goto IL_0062;
	}

IL_0061:
	{
		G_B13_0 = 0;
	}

IL_0062:
	{
		V_4 = (bool)G_B13_0;
		bool L_18 = V_4;
		if (!L_18)
		{
			goto IL_006c;
		}
	}
	{
		V_2 = (bool)1;
		goto IL_0070;
	}

IL_006c:
	{
		V_2 = (bool)0;
		goto IL_0070;
	}

IL_0070:
	{
		bool L_19 = V_2;
		return L_19;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBlend__ctor_m36DEF2F2190A7392298D71CDC78C6A032FC8FC1D (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, RuntimeObject* ___a0, RuntimeObject* ___b1, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___curve2, float ___duration3, float ___t4, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0 = ___a0;
		__this->___CamA_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___CamA_0), (void*)L_0);
		RuntimeObject* L_1 = ___b1;
		__this->___CamB_1 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___CamB_1), (void*)L_1);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___curve2;
		__this->___BlendCurve_2 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___BlendCurve_2), (void*)L_2);
		float L_3 = ___t4;
		__this->___TimeInBlend_3 = L_3;
		float L_4 = ___duration3;
		__this->___Duration_4 = L_4;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineBlend_UpdateCameraState_m07AC58D1D550924255FC4B13BF6BBDC903B44493 (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___worldUp0, float ___deltaTime1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B8_0 = 0;
	{
		RuntimeObject* L_0 = __this->___CamA_0;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		RuntimeObject* L_1 = __this->___CamA_0;
		NullCheck(L_1);
		bool L_2;
		L_2 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_1);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0017;
	}

IL_0016:
	{
		G_B3_0 = 0;
	}

IL_0017:
	{
		V_0 = (bool)G_B3_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0029;
		}
	}
	{
		RuntimeObject* L_4 = __this->___CamA_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = ___worldUp0;
		float L_6 = ___deltaTime1;
		NullCheck(L_4);
		InterfaceActionInvoker2< Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, float >::Invoke(13, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_4, L_5, L_6);
	}

IL_0029:
	{
		RuntimeObject* L_7 = __this->___CamB_1;
		if (!L_7)
		{
			goto IL_003e;
		}
	}
	{
		RuntimeObject* L_8 = __this->___CamB_1;
		NullCheck(L_8);
		bool L_9;
		L_9 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_8);
		G_B8_0 = ((int32_t)(L_9));
		goto IL_003f;
	}

IL_003e:
	{
		G_B8_0 = 0;
	}

IL_003f:
	{
		V_1 = (bool)G_B8_0;
		bool L_10 = V_1;
		if (!L_10)
		{
			goto IL_0051;
		}
	}
	{
		RuntimeObject* L_11 = __this->___CamB_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = ___worldUp0;
		float L_13 = ___deltaTime1;
		NullCheck(L_11);
		InterfaceActionInvoker2< Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, float >::Invoke(13, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_11, L_12, L_13);
	}

IL_0051:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 CinemachineBlend_get_State_m6667F2BD63E27F3A1FD5130CD23FA9CA11BA5DDC (CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 V_2;
	memset((&V_2), 0, sizeof(V_2));
	bool V_3 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	int32_t G_B13_0 = 0;
	{
		RuntimeObject* L_0 = __this->___CamA_0;
		if (!L_0)
		{
			goto IL_0019;
		}
	}
	{
		RuntimeObject* L_1 = __this->___CamA_0;
		NullCheck(L_1);
		bool L_2;
		L_2 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_1);
		G_B3_0 = ((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		goto IL_001a;
	}

IL_0019:
	{
		G_B3_0 = 1;
	}

IL_001a:
	{
		V_0 = (bool)G_B3_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0052;
		}
	}
	{
		RuntimeObject* L_4 = __this->___CamB_1;
		if (!L_4)
		{
			goto IL_0037;
		}
	}
	{
		RuntimeObject* L_5 = __this->___CamB_1;
		NullCheck(L_5);
		bool L_6;
		L_6 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_5);
		G_B7_0 = ((((int32_t)L_6) == ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 1;
	}

IL_0038:
	{
		V_1 = (bool)G_B7_0;
		bool L_7 = V_1;
		if (!L_7)
		{
			goto IL_0044;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_8;
		L_8 = CameraState_get_Default_mBF6F22B14C83DD400EF9F53BB8EACB240BD79398(NULL);
		V_2 = L_8;
		goto IL_00a1;
	}

IL_0044:
	{
		RuntimeObject* L_9 = __this->___CamB_1;
		NullCheck(L_9);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_10;
		L_10 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_9);
		V_2 = L_10;
		goto IL_00a1;
	}

IL_0052:
	{
		RuntimeObject* L_11 = __this->___CamB_1;
		if (!L_11)
		{
			goto IL_006a;
		}
	}
	{
		RuntimeObject* L_12 = __this->___CamB_1;
		NullCheck(L_12);
		bool L_13;
		L_13 = InterfaceFuncInvoker0< bool >::Invoke(10, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_12);
		G_B13_0 = ((((int32_t)L_13) == ((int32_t)0))? 1 : 0);
		goto IL_006b;
	}

IL_006a:
	{
		G_B13_0 = 1;
	}

IL_006b:
	{
		V_3 = (bool)G_B13_0;
		bool L_14 = V_3;
		if (!L_14)
		{
			goto IL_007d;
		}
	}
	{
		RuntimeObject* L_15 = __this->___CamA_0;
		NullCheck(L_15);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_16;
		L_16 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_15);
		V_2 = L_16;
		goto IL_00a1;
	}

IL_007d:
	{
		RuntimeObject* L_17 = __this->___CamA_0;
		NullCheck(L_17);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_18;
		L_18 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_17);
		RuntimeObject* L_19 = __this->___CamB_1;
		NullCheck(L_19);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_20;
		L_20 = InterfaceFuncInvoker0< CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 >::Invoke(8, ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5_il2cpp_TypeInfo_var, L_19);
		float L_21;
		L_21 = CinemachineBlend_get_BlendWeight_m0FFFD553C4A1176490E443AF34DC8AB87F0763A7(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_il2cpp_TypeInfo_var);
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_22;
		L_22 = CameraState_Lerp_mEF27BCEB2B6B51C4E1A2F8E5D5826963D0C787CD(L_18, L_20, L_21, NULL);
		V_2 = L_22;
		goto IL_00a1;
	}

IL_00a1:
	{
		CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 L_23 = V_2;
		return L_23;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline (float ___value0, float ___min1, float ___max2, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	float V_2 = 0.0f;
	{
		float L_0 = ___value0;
		float L_1 = ___min1;
		V_0 = (bool)((((float)L_0) < ((float)L_1))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_000e;
		}
	}
	{
		float L_3 = ___min1;
		___value0 = L_3;
		goto IL_0019;
	}

IL_000e:
	{
		float L_4 = ___value0;
		float L_5 = ___max2;
		V_1 = (bool)((((float)L_4) > ((float)L_5))? 1 : 0);
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0019;
		}
	}
	{
		float L_7 = ___max2;
		___value0 = L_7;
	}

IL_0019:
	{
		float L_8 = ___value0;
		V_2 = L_8;
		goto IL_001d;
	}

IL_001d:
	{
		float L_9 = V_2;
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline (float ___a0, float ___b1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float G_B3_0 = 0.0f;
	{
		float L_0 = ___a0;
		float L_1 = ___b1;
		if ((((float)L_0) > ((float)L_1)))
		{
			goto IL_0008;
		}
	}
	{
		float L_2 = ___b1;
		G_B3_0 = L_2;
		goto IL_0009;
	}

IL_0008:
	{
		float L_3 = ___a0;
		G_B3_0 = L_3;
	}

IL_0009:
	{
		V_0 = G_B3_0;
		goto IL_000c;
	}

IL_000c:
	{
		float L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_2 = L_0;
		float L_1 = ___y1;
		__this->___y_3 = L_1;
		float L_2 = ___z2;
		__this->___z_4 = L_2;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Addition_m087D6F0EC60843D455F9F83D25FE42B2433AAD1D_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___b1;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___b1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___a0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___b1;
		float L_11 = L_10.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_12), ((float)il2cpp_codegen_add(L_1, L_3)), ((float)il2cpp_codegen_add(L_5, L_7)), ((float)il2cpp_codegen_add(L_9, L_11)), NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_forward_mEBAB24D77FC02FC88ED880738C3B1D47C758B3EB_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___forwardVector_11;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___zeroVector_5;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Subtraction_m1690F44F6DC92B770A940B6CF8AE0535625A9824_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___b1;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___b1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___a0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___b1;
		float L_11 = L_10.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_12), ((float)il2cpp_codegen_subtract(L_1, L_3)), ((float)il2cpp_codegen_subtract(L_5, L_7)), ((float)il2cpp_codegen_subtract(L_9, L_11)), NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		float L_2 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___a0;
		float L_4 = L_3.___y_3;
		float L_5 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___a0;
		float L_7 = L_6.___z_4;
		float L_8 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_9), ((float)il2cpp_codegen_multiply(L_1, L_2)), ((float)il2cpp_codegen_multiply(L_4, L_5)), ((float)il2cpp_codegen_multiply(L_7, L_8)), NULL);
		V_0 = L_9;
		goto IL_0021;
	}

IL_0021:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Cross_m77F64620D73934C56BEE37A64016DBDCB9D21DB8_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___lhs0;
		float L_1 = L_0.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___rhs1;
		float L_3 = L_2.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___lhs0;
		float L_5 = L_4.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___rhs1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___lhs0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___rhs1;
		float L_11 = L_10.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = ___lhs0;
		float L_13 = L_12.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = ___rhs1;
		float L_15 = L_14.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = ___lhs0;
		float L_17 = L_16.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = ___rhs1;
		float L_19 = L_18.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = ___lhs0;
		float L_21 = L_20.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = ___rhs1;
		float L_23 = L_22.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		memset((&L_24), 0, sizeof(L_24));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_24), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_1, L_3)), ((float)il2cpp_codegen_multiply(L_5, L_7)))), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_9, L_11)), ((float)il2cpp_codegen_multiply(L_13, L_15)))), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_17, L_19)), ((float)il2cpp_codegen_multiply(L_21, L_23)))), NULL);
		V_0 = L_24;
		goto IL_005a;
	}

IL_005a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25 = V_0;
		return L_25;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_right_m13B7C3EAA64DC921EC23346C56A5A597B5481FF5_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___rightVector_10;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Lerp_mFB4910B358B986AFB22114ED90458E8341867479_inline (float ___a0, float ___b1, float ___t2, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = ___a0;
		float L_1 = ___b1;
		float L_2 = ___a0;
		float L_3 = ___t2;
		float L_4;
		L_4 = Mathf_Clamp01_mD921B23F47F5347996C56DC789D1DE16EE27D9B1_inline(L_3, NULL);
		V_0 = ((float)il2cpp_codegen_add(L_0, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_1, L_2)), L_4))));
		goto IL_0010;
	}

IL_0010:
	{
		float L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_magnitude_mF0D6017E90B345F1F52D1CC564C640F1A847AF2D_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	{
		float L_0 = __this->___x_2;
		float L_1 = __this->___x_2;
		float L_2 = __this->___y_3;
		float L_3 = __this->___y_3;
		float L_4 = __this->___z_4;
		float L_5 = __this->___z_4;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_6;
		L_6 = sqrt(((double)((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_0, L_1)), ((float)il2cpp_codegen_multiply(L_2, L_3)))), ((float)il2cpp_codegen_multiply(L_4, L_5))))));
		V_0 = ((float)L_6);
		goto IL_0034;
	}

IL_0034:
	{
		float L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		float L_2 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___a0;
		float L_4 = L_3.___y_3;
		float L_5 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___a0;
		float L_7 = L_6.___z_4;
		float L_8 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_9), ((float)(L_1/L_2)), ((float)(L_4/L_5)), ((float)(L_7/L_8)), NULL);
		V_0 = L_9;
		goto IL_0021;
	}

IL_0021:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TargetPositionCache_get_CacheMode_mDCBA178980BB6A8FEEC18CA1238F52FFDFC8B5A4_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ((TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_StaticFields*)il2cpp_codegen_static_fields_for(TargetPositionCache_t8232F376771398F9FE91D8BE9D70FC5621F98F80_il2cpp_TypeInfo_var))->___m_CacheMode_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Euler_m66E346161C9778DF8486DB4FE823D8F81A54AF1D_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___euler0, const RuntimeMethod* method) 
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___euler0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_0, (0.0174532924f), NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2;
		L_2 = Quaternion_Internal_FromEulerRad_m2842B9FFB31CDC0F80B7C2172E22831D11D91E93(L_1, NULL);
		V_0 = L_2;
		goto IL_0014;
	}

IL_0014:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_3 = V_0;
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Inequality_m6A7FB1C9E9DE194708997BFA24C6E238D92D908E_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___lhs0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___rhs1;
		bool L_2;
		L_2 = Vector3_op_Equality_m15951D1B53E3BE36C9D265E229090020FBD72EBB_inline(L_0, L_1, NULL);
		V_0 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		goto IL_000e;
	}

IL_000e:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_UnaryNegation_m3AC523A7BED6E843165BDF598690F0560D8CAA63_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___a0;
		float L_3 = L_2.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_6), ((-L_1)), ((-L_3)), ((-L_5)), NULL);
		V_0 = L_6;
		goto IL_001e;
	}

IL_001e:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_op_Multiply_m5AC8B39C55015059BDD09122E04E47D4BFAB2276_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___lhs0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rhs1, const RuntimeMethod* method) 
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ___lhs0;
		float L_1 = L_0.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2 = ___rhs1;
		float L_3 = L_2.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4 = ___lhs0;
		float L_5 = L_4.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_6 = ___rhs1;
		float L_7 = L_6.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_8 = ___lhs0;
		float L_9 = L_8.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_10 = ___rhs1;
		float L_11 = L_10.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12 = ___lhs0;
		float L_13 = L_12.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_14 = ___rhs1;
		float L_15 = L_14.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_16 = ___lhs0;
		float L_17 = L_16.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_18 = ___rhs1;
		float L_19 = L_18.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20 = ___lhs0;
		float L_21 = L_20.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_22 = ___rhs1;
		float L_23 = L_22.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_24 = ___lhs0;
		float L_25 = L_24.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_26 = ___rhs1;
		float L_27 = L_26.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_28 = ___lhs0;
		float L_29 = L_28.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_30 = ___rhs1;
		float L_31 = L_30.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_32 = ___lhs0;
		float L_33 = L_32.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_34 = ___rhs1;
		float L_35 = L_34.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_36 = ___lhs0;
		float L_37 = L_36.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_38 = ___rhs1;
		float L_39 = L_38.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_40 = ___lhs0;
		float L_41 = L_40.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_42 = ___rhs1;
		float L_43 = L_42.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_44 = ___lhs0;
		float L_45 = L_44.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_46 = ___rhs1;
		float L_47 = L_46.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_48 = ___lhs0;
		float L_49 = L_48.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_50 = ___rhs1;
		float L_51 = L_50.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_52 = ___lhs0;
		float L_53 = L_52.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_54 = ___rhs1;
		float L_55 = L_54.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_56 = ___lhs0;
		float L_57 = L_56.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_58 = ___rhs1;
		float L_59 = L_58.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_60 = ___lhs0;
		float L_61 = L_60.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_62 = ___rhs1;
		float L_63 = L_62.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_64;
		memset((&L_64), 0, sizeof(L_64));
		Quaternion__ctor_m868FD60AA65DD5A8AC0C5DEB0608381A8D85FCD8_inline((&L_64), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_1, L_3)), ((float)il2cpp_codegen_multiply(L_5, L_7)))), ((float)il2cpp_codegen_multiply(L_9, L_11)))), ((float)il2cpp_codegen_multiply(L_13, L_15)))), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_17, L_19)), ((float)il2cpp_codegen_multiply(L_21, L_23)))), ((float)il2cpp_codegen_multiply(L_25, L_27)))), ((float)il2cpp_codegen_multiply(L_29, L_31)))), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_33, L_35)), ((float)il2cpp_codegen_multiply(L_37, L_39)))), ((float)il2cpp_codegen_multiply(L_41, L_43)))), ((float)il2cpp_codegen_multiply(L_45, L_47)))), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_49, L_51)), ((float)il2cpp_codegen_multiply(L_53, L_55)))), ((float)il2cpp_codegen_multiply(L_57, L_59)))), ((float)il2cpp_codegen_multiply(L_61, L_63)))), NULL);
		V_0 = L_64;
		goto IL_00e5;
	}

IL_00e5:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_65 = V_0;
		return L_65;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector3_op_Equality_m15951D1B53E3BE36C9D265E229090020FBD72EBB_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	bool V_4 = false;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___lhs0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___rhs1;
		float L_3 = L_2.___x_2;
		V_0 = ((float)il2cpp_codegen_subtract(L_1, L_3));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___lhs0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___rhs1;
		float L_7 = L_6.___y_3;
		V_1 = ((float)il2cpp_codegen_subtract(L_5, L_7));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___lhs0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___rhs1;
		float L_11 = L_10.___z_4;
		V_2 = ((float)il2cpp_codegen_subtract(L_9, L_11));
		float L_12 = V_0;
		float L_13 = V_0;
		float L_14 = V_1;
		float L_15 = V_1;
		float L_16 = V_2;
		float L_17 = V_2;
		V_3 = ((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_12, L_13)), ((float)il2cpp_codegen_multiply(L_14, L_15)))), ((float)il2cpp_codegen_multiply(L_16, L_17))));
		float L_18 = V_3;
		V_4 = (bool)((((float)L_18) < ((float)(9.99999944E-11f)))? 1 : 0);
		goto IL_0043;
	}

IL_0043:
	{
		bool L_19 = V_4;
		return L_19;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineComposer_set_TrackedPoint_mC2806265609C1BADBE1F83DD18F800BDA064D5A6_inline (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___value0;
		__this->___U3CTrackedPointU3Ek__BackingField_22 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool CinemachineVirtualCameraBase_get_LookAtTargetChanged_m6D2FF4FB863501796CB778CB7AABA0126E57C134_inline (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CLookAtTargetChangedU3Ek__BackingField_28;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineComposer_get_TrackedPoint_m164861743F7BD7E49747B46076F228CBD8785F33_inline (CinemachineComposer_t9531E578E8280C4203B209F59CECE36F3F262A5A* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___U3CTrackedPointU3Ek__BackingField_22;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Lerp_m57EE8D709A93B2B0FF8D499FA2947B1D61CB1FD6_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, float ___t2, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = ___t2;
		float L_1;
		L_1 = Mathf_Clamp01_mD921B23F47F5347996C56DC789D1DE16EE27D9B1_inline(L_0, NULL);
		___t2 = L_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___a0;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___b1;
		float L_5 = L_4.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___a0;
		float L_7 = L_6.___x_2;
		float L_8 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = ___a0;
		float L_10 = L_9.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = ___b1;
		float L_12 = L_11.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = ___a0;
		float L_14 = L_13.___y_3;
		float L_15 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = ___a0;
		float L_17 = L_16.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = ___b1;
		float L_19 = L_18.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = ___a0;
		float L_21 = L_20.___z_4;
		float L_22 = ___t2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23;
		memset((&L_23), 0, sizeof(L_23));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_23), ((float)il2cpp_codegen_add(L_3, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_5, L_7)), L_8)))), ((float)il2cpp_codegen_add(L_10, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_12, L_14)), L_15)))), ((float)il2cpp_codegen_add(L_17, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_19, L_21)), L_22)))), NULL);
		V_0 = L_23;
		goto IL_0053;
	}

IL_0053:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = V_0;
		return L_24;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___lhs0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___rhs1;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___lhs0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___rhs1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___lhs0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___rhs1;
		float L_11 = L_10.___z_4;
		V_0 = ((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_1, L_3)), ((float)il2cpp_codegen_multiply(L_5, L_7)))), ((float)il2cpp_codegen_multiply(L_9, L_11))));
		goto IL_002d;
	}

IL_002d:
	{
		float L_12 = V_0;
		return L_12;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Distance_m99C722723EDD875852EF854AD7B7C4F8AC4F84AB_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___b1;
		float L_3 = L_2.___x_2;
		V_0 = ((float)il2cpp_codegen_subtract(L_1, L_3));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___b1;
		float L_7 = L_6.___y_3;
		V_1 = ((float)il2cpp_codegen_subtract(L_5, L_7));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___a0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___b1;
		float L_11 = L_10.___z_4;
		V_2 = ((float)il2cpp_codegen_subtract(L_9, L_11));
		float L_12 = V_0;
		float L_13 = V_0;
		float L_14 = V_1;
		float L_15 = V_1;
		float L_16 = V_2;
		float L_17 = V_2;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_18;
		L_18 = sqrt(((double)((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_12, L_13)), ((float)il2cpp_codegen_multiply(L_14, L_15)))), ((float)il2cpp_codegen_multiply(L_16, L_17))))));
		V_3 = ((float)L_18);
		goto IL_0040;
	}

IL_0040:
	{
		float L_19 = V_3;
		return L_19;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Rect_get_center_mAA9A2E1F058B2C9F58E13CC4822F789F42975E5C_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0;
		L_0 = Rect_get_x_mB267B718E0D067F2BAE31BA477647FBF964916EB_inline(__this, NULL);
		float L_1 = __this->___m_Width_2;
		float L_2;
		L_2 = Rect_get_y_mC733E8D49F3CE21B2A3D40A1B72D687F22C97F49_inline(__this, NULL);
		float L_3 = __this->___m_Height_3;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_4), ((float)il2cpp_codegen_add(L_0, ((float)(L_1/(2.0f))))), ((float)il2cpp_codegen_add(L_2, ((float)(L_3/(2.0f))))), NULL);
		V_0 = L_4;
		goto IL_002f;
	}

IL_002f:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_get_zero_m009B92B5D35AB02BD1610C2E1ACCE7C9CF964A6E_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ((Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_StaticFields*)il2cpp_codegen_static_fields_for(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_il2cpp_TypeInfo_var))->___zeroVector_2;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect__ctor_m503705FE0E4E413041E3CE7F09270489F401C675_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___position0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___size1, const RuntimeMethod* method) 
{
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___position0;
		float L_1 = L_0.___x_0;
		__this->___m_XMin_0 = L_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___position0;
		float L_3 = L_2.___y_1;
		__this->___m_YMin_1 = L_3;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4 = ___size1;
		float L_5 = L_4.___x_0;
		__this->___m_Width_2 = L_5;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_6 = ___size1;
		float L_7 = L_6.___y_1;
		__this->___m_Height_3 = L_7;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_UnaryNegation_m47556D28F72B018AC4D5160710C83A805F10A783_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___a0;
		float L_1 = L_0.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___a0;
		float L_3 = L_2.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_4), ((-L_1)), ((-L_3)), NULL);
		V_0 = L_4;
		goto IL_0017;
	}

IL_0017:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___x0, float ___y1, float ___width2, float ___height3, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___m_XMin_0 = L_0;
		float L_1 = ___y1;
		__this->___m_YMin_1 = L_1;
		float L_2 = ___width2;
		__this->___m_Width_2 = L_2;
		float L_3 = ___height3;
		__this->___m_Height_3 = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_Width_2;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_Height_3;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_x_mB267B718E0D067F2BAE31BA477647FBF964916EB_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_XMin_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_y_mC733E8D49F3CE21B2A3D40A1B72D687F22C97F49_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_YMin_1;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Rect_get_position_m9B7E583E67443B6F4280A676E644BB0B9E7C4E38_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = __this->___m_XMin_0;
		float L_1 = __this->___m_YMin_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_2), L_0, L_1, NULL);
		V_0 = L_2;
		goto IL_0015;
	}

IL_0015:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_3 = V_0;
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___x0, float ___y1, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_0 = L_0;
		float L_1 = ___y1;
		__this->___y_1 = L_1;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Addition_m704B5B98EAFE885978381E21B7F89D9DF83C2A60_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___b1, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___a0;
		float L_1 = L_0.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___b1;
		float L_3 = L_2.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4 = ___a0;
		float L_5 = L_4.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_6 = ___b1;
		float L_7 = L_6.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_8;
		memset((&L_8), 0, sizeof(L_8));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_8), ((float)il2cpp_codegen_add(L_1, L_3)), ((float)il2cpp_codegen_add(L_5, L_7)), NULL);
		V_0 = L_8;
		goto IL_0023;
	}

IL_0023:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_9 = V_0;
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_position_m9CD8AA25A83A7A893429C0ED56C36641202C3F05_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___value0, const RuntimeMethod* method) 
{
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___value0;
		float L_1 = L_0.___x_0;
		__this->___m_XMin_0 = L_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___value0;
		float L_3 = L_2.___y_1;
		__this->___m_YMin_1 = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline (float ___a0, float ___b1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float G_B3_0 = 0.0f;
	{
		float L_0 = ___a0;
		float L_1 = ___b1;
		if ((((float)L_0) < ((float)L_1)))
		{
			goto IL_0008;
		}
	}
	{
		float L_2 = ___b1;
		G_B3_0 = L_2;
		goto IL_0009;
	}

IL_0008:
	{
		float L_3 = ___a0;
		G_B3_0 = L_3;
	}

IL_0009:
	{
		V_0 = G_B3_0;
		goto IL_000c;
	}

IL_000c:
	{
		float L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Subtraction_m664419831773D5BBF06D9DE4E515F6409B2F92B8_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___b1, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___a0;
		float L_1 = L_0.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___b1;
		float L_3 = L_2.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4 = ___a0;
		float L_5 = L_4.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_6 = ___b1;
		float L_7 = L_6.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_8;
		memset((&L_8), 0, sizeof(L_8));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_8), ((float)il2cpp_codegen_subtract(L_1, L_3)), ((float)il2cpp_codegen_subtract(L_5, L_7)), NULL);
		V_0 = L_8;
		goto IL_0023;
	}

IL_0023:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_9 = V_0;
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_yMin_mB19848FB25DE61EDF958F7A22CFDD86DE103062F_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_YMin_1;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_Height_3;
		float L_1 = __this->___m_YMin_1;
		V_0 = ((float)il2cpp_codegen_add(L_0, L_1));
		goto IL_0011;
	}

IL_0011:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_xMin_mE89C40702926D016A633399E20DB9501E251630D_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_XMin_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___m_Width_2;
		float L_1 = __this->___m_XMin_0;
		V_0 = ((float)il2cpp_codegen_add(L_0, L_1));
		goto IL_0011;
	}

IL_0011:
	{
		float L_2 = V_0;
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_yMin_m9F780E509B9215A9E5826178CF664BD0E486D4EE_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0;
		L_0 = Rect_get_yMax_mBC37BEE1CD632AADD8B9EAF9FE3BA143F79CAF8E_inline(__this, NULL);
		V_0 = L_0;
		float L_1 = ___value0;
		__this->___m_YMin_1 = L_1;
		float L_2 = V_0;
		float L_3 = __this->___m_YMin_1;
		__this->___m_Height_3 = ((float)il2cpp_codegen_subtract(L_2, L_3));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_yMax_mCF452040E0068A4B3CB15994C0B4B6AD4D78E04B_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		float L_0 = ___value0;
		float L_1 = __this->___m_YMin_1;
		__this->___m_Height_3 = ((float)il2cpp_codegen_subtract(L_0, L_1));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ((Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_StaticFields*)il2cpp_codegen_static_fields_for(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_il2cpp_TypeInfo_var))->___identityQuaternion_4;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Rect_op_Inequality_m4698BE8DFFC2C4F79B03116FC33FE1BE823A8945_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___lhs0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rhs1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_0 = ___lhs0;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_1 = ___rhs1;
		bool L_2;
		L_2 = Rect_op_Equality_m3592AA7AF3B2C809AAB02110B166B9A6F9263AD8_inline(L_0, L_1, NULL);
		V_0 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		goto IL_000e;
	}

IL_000e:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect__ctor_m5665723DD0443E990EA203A54451B2BB324D8224_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___source0, const RuntimeMethod* method) 
{
	{
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_0 = ___source0;
		float L_1 = L_0.___m_XMin_0;
		__this->___m_XMin_0 = L_1;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_2 = ___source0;
		float L_3 = L_2.___m_YMin_1;
		__this->___m_YMin_1 = L_3;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_4 = ___source0;
		float L_5 = L_4.___m_Width_2;
		__this->___m_Width_2 = L_5;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_6 = ___source0;
		float L_7 = L_6.___m_Height_3;
		__this->___m_Height_3 = L_7;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_left_mA75C525C1E78B5BB99E9B7A63EF68C731043FE18_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___leftVector_9;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_up_mAB5269BFCBCB1BD241450C9BF2F156303D30E0C3_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___upVector_7;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_xMin_mA873FCFAF9EABA46A026B73CA045192DF1946F19_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0;
		L_0 = Rect_get_xMax_m2339C7D2FCDA98A9B007F815F6E2059BA6BE425F_inline(__this, NULL);
		V_0 = L_0;
		float L_1 = ___value0;
		__this->___m_XMin_0 = L_1;
		float L_2 = V_0;
		float L_3 = __this->___m_XMin_0;
		__this->___m_Width_2 = ((float)il2cpp_codegen_subtract(L_2, L_3));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Rect_set_xMax_m97C28D468455A6D19325D0D862E80A093240D49D_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		float L_0 = ___value0;
		float L_1 = __this->___m_XMin_0;
		__this->___m_Width_2 = ((float)il2cpp_codegen_subtract(L_0, L_1));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool CinemachineVirtualCameraBase_get_FollowTargetChanged_m4CB9C2AA28F8B2898B82BBF51348C6670110ADF2_inline (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CFollowTargetChangedU3Ek__BackingField_27;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_back_mBA6E23860A365E6F0F9A2AADC3D19E698687230A_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___backVector_12;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_TrackedPoint_m32FD1D5F85F4BDBFC3BF6DBF5CBC7A8D1DB44FDD_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___value0;
		__this->___U3CTrackedPointU3Ek__BackingField_42 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 CinemachineFramingTransposer_get_LastBounds_m6D98D46A49E2196A98E2B7E76C0061AC8310B45B_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_0 = __this->___U3CLastBoundsU3Ek__BackingField_46;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Bounds_get_center_m5B05F81CB835EB6DD8628FDA24B638F477984DC3_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___m_Center_0;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 CinemachineFramingTransposer_get_LastBoundsMatrix_mB1296133E5C0BDD6B9C0879888C468C559BE95BB_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = __this->___U3CLastBoundsMatrixU3Ek__BackingField_47;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds_set_center_m891869DD5B1BEEE2D17907BBFB7EB79AAE44884B_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___value0;
		__this->___m_Center_0 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_LastBounds_m42F030170155BAC06C2B040E44F4FCB25251EF93_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___value0, const RuntimeMethod* method) 
{
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_0 = ___value0;
		__this->___U3CLastBoundsU3Ek__BackingField_46 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Bounds_get_size_m0699A53A55A78B3201D7270D6F338DFA91B6FAD4_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___m_Extents_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_0, (2.0f), NULL);
		V_0 = L_1;
		goto IL_0014;
	}

IL_0014:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = V_0;
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Implicit_m8F73B300CB4E6F9B4EB5FB6130363D76CEAA230B_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v0, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___v0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___v0;
		float L_3 = L_2.___y_3;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_4), L_1, L_3, NULL);
		V_0 = L_4;
		goto IL_0015;
	}

IL_0015:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Bounds_get_extents_mFE6DC407FCE2341BE2C750CB554055D211281D25_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___m_Extents_1;
		V_0 = L_0;
		goto IL_000a;
	}

IL_000a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 CinemachineFramingTransposer_get_TrackedPoint_m893C86296D7D0C01FCD28D85D14B38124F9AFB52_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = __this->___U3CTrackedPointU3Ek__BackingField_42;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_one_mE6A2D5C6578E94268024613B596BF09F990B1260_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___oneVector_6;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineFramingTransposer_set_LastBoundsMatrix_m13FAE68552F3910750A134D22AE4AF6845C0301D_inline (CinemachineFramingTransposer_t19450FC1D17FF88D379C2B50048062DF4ED91065* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = ___value0;
		__this->___U3CLastBoundsMatrixU3Ek__BackingField_47 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Division_m69F64D545E3C023BE9927397572349A569141EBA_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, float ___d1, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___a0;
		float L_1 = L_0.___x_0;
		float L_2 = ___d1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_3 = ___a0;
		float L_4 = L_3.___y_1;
		float L_5 = ___d1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_6), ((float)(L_1/L_2)), ((float)(L_4/L_5)), NULL);
		V_0 = L_6;
		goto IL_0019;
	}

IL_0019:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_Max_m5FF3A49170F857E422CDD32A51CABEAE568E8088_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___lhs0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rhs1, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___lhs0;
		float L_1 = L_0.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___rhs1;
		float L_3 = L_2.___x_0;
		float L_4;
		L_4 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_1, L_3, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5 = ___lhs0;
		float L_6 = L_5.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_7 = ___rhs1;
		float L_8 = L_7.___y_1;
		float L_9;
		L_9 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_6, L_8, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10;
		memset((&L_10), 0, sizeof(L_10));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_10), L_4, L_9, NULL);
		V_0 = L_10;
		goto IL_002b;
	}

IL_002b:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_11 = V_0;
		return L_11;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_Min_mAB64CD54A495856162FC5753B6C6B572AA4BEA1D_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___lhs0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rhs1, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___lhs0;
		float L_1 = L_0.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___rhs1;
		float L_3 = L_2.___x_0;
		float L_4;
		L_4 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_1, L_3, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5 = ___lhs0;
		float L_6 = L_5.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_7 = ___rhs1;
		float L_8 = L_7.___y_1;
		float L_9;
		L_9 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_6, L_8, NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10;
		memset((&L_10), 0, sizeof(L_10));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_10), L_4, L_9, NULL);
		V_0 = L_10;
		goto IL_002b;
	}

IL_002b:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_11 = V_0;
		return L_11;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Multiply_m4EEB2FF3F4830390A53CE9B6076FB31801D65EED_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, float ___d1, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_0 = ___a0;
		float L_1 = L_0.___x_0;
		float L_2 = ___d1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_3 = ___a0;
		float L_4 = L_3.___y_1;
		float L_5 = ___d1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_6), ((float)il2cpp_codegen_multiply(L_1, L_2)), ((float)il2cpp_codegen_multiply(L_4, L_5)), NULL);
		V_0 = L_6;
		goto IL_0019;
	}

IL_0019:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Bounds__ctor_mAF7B238B9FBF90C495E5D7951760085A93119C5A_inline (Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___center0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___size1, const RuntimeMethod* method) 
{
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___center0;
		__this->___m_Center_0 = L_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___size1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_1, (0.5f), NULL);
		__this->___m_Extents_1 = L_2;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineGroupComposer_set_LastBoundsMatrix_m917FDDE19382BCDA1626CF4BB5E118E43C1D13A3_inline (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 ___value0, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = ___value0;
		__this->___U3CLastBoundsMatrixU3Ek__BackingField_44 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 CinemachineGroupComposer_get_LastBoundsMatrix_m67F9243F621C6474E2090615DDE98B6E69B81E52_inline (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, const RuntimeMethod* method) 
{
	{
		Matrix4x4_tDB70CF134A14BA38190C59AA700BCE10E2AED3E6 L_0 = __this->___U3CLastBoundsMatrixU3Ek__BackingField_44;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_normalized_m736BBF65D5CDA7A18414370D15B4DFCC1E466F07_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = (*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)__this);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Vector3_Normalize_m6120F119433C5B60BBB28731D3D4A0DA50A84DDD_inline(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = V_0;
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineGroupComposer_set_LastBounds_mE2FCF71321530F97627893A8BA652B959D19110C_inline (CinemachineGroupComposer_t2223D762149F80F7E7B2CC7C7DACD5F0890509B2* __this, Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___value0, const RuntimeMethod* method) 
{
	{
		Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 L_0 = ___value0;
		__this->___U3CLastBoundsU3Ek__BackingField_43 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_SignedAngle_mD30E71B2F64983C2C4D86F17E7023BAA84CE50BE_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___from0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___to1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___axis2, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float V_2 = 0.0f;
	float V_3 = 0.0f;
	float V_4 = 0.0f;
	float V_5 = 0.0f;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___from0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___to1;
		float L_2;
		L_2 = Vector3_Angle_m1B9CC61B142C3A0E7EEB0559983CC391D1582F56_inline(L_0, L_1, NULL);
		V_0 = L_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___from0;
		float L_4 = L_3.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = ___to1;
		float L_6 = L_5.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___from0;
		float L_8 = L_7.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = ___to1;
		float L_10 = L_9.___y_3;
		V_1 = ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_4, L_6)), ((float)il2cpp_codegen_multiply(L_8, L_10))));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11 = ___from0;
		float L_12 = L_11.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = ___to1;
		float L_14 = L_13.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = ___from0;
		float L_16 = L_15.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17 = ___to1;
		float L_18 = L_17.___z_4;
		V_2 = ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_12, L_14)), ((float)il2cpp_codegen_multiply(L_16, L_18))));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_19 = ___from0;
		float L_20 = L_19.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_21 = ___to1;
		float L_22 = L_21.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_23 = ___from0;
		float L_24 = L_23.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25 = ___to1;
		float L_26 = L_25.___x_2;
		V_3 = ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_20, L_22)), ((float)il2cpp_codegen_multiply(L_24, L_26))));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = ___axis2;
		float L_28 = L_27.___x_2;
		float L_29 = V_1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30 = ___axis2;
		float L_31 = L_30.___y_3;
		float L_32 = V_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33 = ___axis2;
		float L_34 = L_33.___z_4;
		float L_35 = V_3;
		float L_36;
		L_36 = Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline(((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_28, L_29)), ((float)il2cpp_codegen_multiply(L_31, L_32)))), ((float)il2cpp_codegen_multiply(L_34, L_35)))), NULL);
		V_4 = L_36;
		float L_37 = V_0;
		float L_38 = V_4;
		V_5 = ((float)il2cpp_codegen_multiply(L_37, L_38));
		goto IL_0086;
	}

IL_0086:
	{
		float L_39 = V_5;
		return L_39;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float UpdateHeadingDelegate_Invoke_mD63AFD811D3492ECF335D17B0B858E3655D8019A_inline (UpdateHeadingDelegate_tAE5B0953FD3BCBC040EB4AF4964F18C4AC2CED60* __this, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303* ___orbital0, float ___deltaTime1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up2, const RuntimeMethod* method) 
{
	typedef float (*FunctionPointerType) (RuntimeObject*, CinemachineOrbitalTransposer_t63DD735782502DE953A27665F7578A190775A303*, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___orbital0, ___deltaTime1, ___up2, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_sqrMagnitude_m43C27DEC47C4811FB30AB474FF2131A963B66FC8_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = __this->___x_2;
		float L_1 = __this->___x_2;
		float L_2 = __this->___y_3;
		float L_3 = __this->___y_3;
		float L_4 = __this->___z_4;
		float L_5 = __this->___z_4;
		V_0 = ((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_0, L_1)), ((float)il2cpp_codegen_multiply(L_2, L_3)))), ((float)il2cpp_codegen_multiply(L_4, L_5))));
		goto IL_002d;
	}

IL_002d:
	{
		float L_6 = V_0;
		return L_6;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Quaternion_get_eulerAngles_m2DB5158B5C3A71FD60FC8A6EE43D3AAA1CFED122_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = (*(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)__this);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1;
		L_1 = Quaternion_Internal_ToEulerRad_m9B2C77284AEE6F2C43B6C42F1F888FB4FC904462(L_0, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2;
		L_2 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_1, (57.2957802f), NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Quaternion_Internal_MakePositive_m864320DA2D027C186C95B2A5BC2C66B0EB4A6C11(L_2, NULL);
		V_0 = L_3;
		goto IL_001e;
	}

IL_001e:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Euler_mD4601D966F1F58F3FCA01B3FC19A12D0AD0396DD_inline (float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) 
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = ___x0;
		float L_1 = ___y1;
		float L_2 = ___z2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		memset((&L_3), 0, sizeof(L_3));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_3), L_0, L_1, L_2, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4;
		L_4 = Vector3_op_Multiply_m516FE285F5342F922C6EB3FCB33197E9017FF484_inline(L_3, (0.0174532924f), NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_5;
		L_5 = Quaternion_Internal_FromEulerRad_m2842B9FFB31CDC0F80B7C2172E22831D11D91E93(L_4, NULL);
		V_0 = L_5;
		goto IL_001b;
	}

IL_001b:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_6 = V_0;
		return L_6;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Mathf_FloorToInt_mD086E41305DD8350180AD677833A22733B4789A9_inline (float ___f0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		float L_0 = ___f0;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_1;
		L_1 = floor(((double)L_0));
		V_0 = il2cpp_codegen_cast_double_to_int<int32_t>(L_1);
		goto IL_000c;
	}

IL_000c:
	{
		int32_t L_2 = V_0;
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m29F4414A9D30B7C0CD8455C4B2F049E8CCF66745_inline (float ___d0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a1;
		float L_1 = L_0.___x_2;
		float L_2 = ___d0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___a1;
		float L_4 = L_3.___y_3;
		float L_5 = ___d0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___a1;
		float L_7 = L_6.___z_4;
		float L_8 = ___d0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_9), ((float)il2cpp_codegen_multiply(L_1, L_2)), ((float)il2cpp_codegen_multiply(L_4, L_5)), ((float)il2cpp_codegen_multiply(L_7, L_8)), NULL);
		V_0 = L_9;
		goto IL_0021;
	}

IL_0021:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___index0, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	float V_2 = 0.0f;
	{
		int32_t L_0 = ___index0;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_0019;
			}
			case 1:
			{
				goto IL_0022;
			}
			case 2:
			{
				goto IL_002b;
			}
		}
	}
	{
		goto IL_0034;
	}

IL_0019:
	{
		float L_3 = __this->___x_2;
		V_2 = L_3;
		goto IL_003f;
	}

IL_0022:
	{
		float L_4 = __this->___y_3;
		V_2 = L_4;
		goto IL_003f;
	}

IL_002b:
	{
		float L_5 = __this->___z_4;
		V_2 = L_5;
		goto IL_003f;
	}

IL_0034:
	{
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_6 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		NullCheck(L_6);
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral27C7727EAAAD675C621F6257F2BD5190CE343979)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector3_get_Item_m163510BFC2F7BFAD1B601DC9F3606B799CF199F2_RuntimeMethod_var)));
	}

IL_003f:
	{
		float L_7 = V_2;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, int32_t ___index0, float ___value1, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		int32_t L_0 = ___index0;
		V_1 = L_0;
		int32_t L_1 = V_1;
		V_0 = L_1;
		int32_t L_2 = V_0;
		switch (L_2)
		{
			case 0:
			{
				goto IL_0019;
			}
			case 1:
			{
				goto IL_0022;
			}
			case 2:
			{
				goto IL_002b;
			}
		}
	}
	{
		goto IL_0034;
	}

IL_0019:
	{
		float L_3 = ___value1;
		__this->___x_2 = L_3;
		goto IL_003f;
	}

IL_0022:
	{
		float L_4 = ___value1;
		__this->___y_3 = L_4;
		goto IL_003f;
	}

IL_002b:
	{
		float L_5 = ___value1;
		__this->___z_4 = L_5;
		goto IL_003f;
	}

IL_0034:
	{
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_6 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		NullCheck(L_6);
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral27C7727EAAAD675C621F6257F2BD5190CE343979)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector3_set_Item_m79136861DEC5862CE7EC20AB3B0EF10A3957CEC3_RuntimeMethod_var)));
	}

IL_003f:
	{
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_get_normalized_m08AB963B13A0EC6F540A29886C5ACFCCCC0A6D16_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, const RuntimeMethod* method) 
{
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = (*(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974*)__this);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1;
		L_1 = Quaternion_Normalize_m63D60A4A9F97145AF0C7E2A4C044EBF17EF7CBC3_inline(L_0, NULL);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2 = V_0;
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AxisState_set_ValueRangeLocked_m367AD65F7E97A0DFF0DE1CA0C74AEEBCCC36D000_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___value0;
		__this->___U3CValueRangeLockedU3Ek__BackingField_18 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AxisState_set_HasRecentering_m978B18A62A74813CC75078114997E708B6877D85_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___value0;
		__this->___U3CHasRecenteringU3Ek__BackingField_19 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float AxisInputDelegate_Invoke_m1C36C70E105C8A9091AED921BB6E7053C99F39CE_inline (AxisInputDelegate_tE27958ACEDD7816DB591B6F485ACD7083541C452* __this, String_t* ___axisName0, const RuntimeMethod* method) 
{
	typedef float (*FunctionPointerType) (RuntimeObject*, String_t*, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___axisName0, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Sign_m015249B312238B8DCA3493489FAFC3055E2FFEF8_inline (float ___f0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float G_B3_0 = 0.0f;
	{
		float L_0 = ___f0;
		if ((((float)L_0) >= ((float)(0.0f))))
		{
			goto IL_0010;
		}
	}
	{
		G_B3_0 = (-1.0f);
		goto IL_0015;
	}

IL_0010:
	{
		G_B3_0 = (1.0f);
	}

IL_0015:
	{
		V_0 = G_B3_0;
		goto IL_0018;
	}

IL_0018:
	{
		float L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool AxisState_get_ValueRangeLocked_m25A67A9600BCC5AFD35CA1A2C57AE0CFCB76E6B1_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CValueRangeLockedU3Ek__BackingField_18;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool AxisState_get_HasRecentering_m24F7A4CEF751588924C04AAB32BD1B59389BA4DC_inline (AxisState_t6996FE8143104E02683986C908C18B0F62595736* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CHasRecenteringU3Ek__BackingField_19;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t CameraState_get_NumCustomBlendables_mA7FC428A3F135FA88769EC45E2C5521F2D1169DB_inline (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CNumCustomBlendablesU3Ek__BackingField_16;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CameraState_set_NumCustomBlendables_m599C74DAA99E17F8B5EF87CFD0A6238A81D05AD3_inline (CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___value0;
		__this->___U3CNumCustomBlendablesU3Ek__BackingField_16 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Clamp01_mD921B23F47F5347996C56DC789D1DE16EE27D9B1_inline (float ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	float V_1 = 0.0f;
	bool V_2 = false;
	{
		float L_0 = ___value0;
		V_0 = (bool)((((float)L_0) < ((float)(0.0f)))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0015;
		}
	}
	{
		V_1 = (0.0f);
		goto IL_002d;
	}

IL_0015:
	{
		float L_2 = ___value0;
		V_2 = (bool)((((float)L_2) > ((float)(1.0f)))? 1 : 0);
		bool L_3 = V_2;
		if (!L_3)
		{
			goto IL_0029;
		}
	}
	{
		V_1 = (1.0f);
		goto IL_002d;
	}

IL_0029:
	{
		float L_4 = ___value0;
		V_1 = L_4;
		goto IL_002d;
	}

IL_002d:
	{
		float L_5 = V_1;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Mathf_Approximately_m1C8DD0BB6A2D22A7DCF09AD7F8EE9ABD12D3F620_inline (float ___a0, float ___b1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		float L_0 = ___b1;
		float L_1 = ___a0;
		float L_2;
		L_2 = fabsf(((float)il2cpp_codegen_subtract(L_0, L_1)));
		float L_3 = ___a0;
		float L_4;
		L_4 = fabsf(L_3);
		float L_5 = ___b1;
		float L_6;
		L_6 = fabsf(L_5);
		float L_7;
		L_7 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(L_4, L_6, NULL);
		float L_8 = ((Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_StaticFields*)il2cpp_codegen_static_fields_for(Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var))->___Epsilon_0;
		float L_9;
		L_9 = Mathf_Max_mA9DCA91E87D6D27034F56ABA52606A9090406016_inline(((float)il2cpp_codegen_multiply((9.99999997E-07f), L_7)), ((float)il2cpp_codegen_multiply(L_8, (8.0f))), NULL);
		V_0 = (bool)((((float)L_2) < ((float)L_9))? 1 : 0);
		goto IL_0035;
	}

IL_0035:
	{
		bool L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Quaternion_Angle_m445E005E6F9211283EEA3F0BD4FF2DC20FE3640A_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___a0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___b1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	float G_B3_0 = 0.0f;
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ___a0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = ___b1;
		float L_2;
		L_2 = Quaternion_Dot_m4A80D03D7B7DEC054E2175E53D072675649C6713_inline(L_0, L_1, NULL);
		float L_3;
		L_3 = fabsf(L_2);
		float L_4;
		L_4 = Mathf_Min_m4F2A9C5128DC3F9E84865EE7ADA8DB5DA6B8B507_inline(L_3, (1.0f), NULL);
		V_0 = L_4;
		float L_5 = V_0;
		bool L_6;
		L_6 = Quaternion_IsEqualUsingDot_m5C6AC5F5C56B27C25DDF612BEEF40F28CA44CA31_inline(L_5, NULL);
		if (L_6)
		{
			goto IL_0034;
		}
	}
	{
		float L_7 = V_0;
		float L_8;
		L_8 = acosf(L_7);
		G_B3_0 = ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_multiply(L_8, (2.0f))), (57.2957802f)));
		goto IL_0039;
	}

IL_0034:
	{
		G_B3_0 = (0.0f);
	}

IL_0039:
	{
		V_1 = G_B3_0;
		goto IL_003c;
	}

IL_003c:
	{
		float L_9 = V_1;
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_Lerp_mF3BD6827807680A529E800FD027734D40A3597E1_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___a0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___b1, float ___t2, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = ___t2;
		float L_1;
		L_1 = Mathf_Clamp01_mD921B23F47F5347996C56DC789D1DE16EE27D9B1_inline(L_0, NULL);
		___t2 = L_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_2 = ___a0;
		float L_3 = L_2.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4 = ___b1;
		float L_5 = L_4.___x_0;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_6 = ___a0;
		float L_7 = L_6.___x_0;
		float L_8 = ___t2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_9 = ___a0;
		float L_10 = L_9.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_11 = ___b1;
		float L_12 = L_11.___y_1;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_13 = ___a0;
		float L_14 = L_13.___y_1;
		float L_15 = ___t2;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_16;
		memset((&L_16), 0, sizeof(L_16));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_16), ((float)il2cpp_codegen_add(L_3, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_5, L_7)), L_8)))), ((float)il2cpp_codegen_add(L_10, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_12, L_14)), L_15)))), NULL);
		V_0 = L_16;
		goto IL_003d;
	}

IL_003d:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_17 = V_0;
		return L_17;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_ProjectOnPlane_mCAFA9F9416EA4740DCA8757B6E52260BF536770A_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___vector0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___planeNormal1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	bool V_1 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	float V_3 = 0.0f;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___planeNormal1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = ___planeNormal1;
		float L_2;
		L_2 = Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline(L_0, L_1, NULL);
		V_0 = L_2;
		float L_3 = V_0;
		float L_4 = ((Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_StaticFields*)il2cpp_codegen_static_fields_for(Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var))->___Epsilon_0;
		V_1 = (bool)((((float)L_3) < ((float)L_4))? 1 : 0);
		bool L_5 = V_1;
		if (!L_5)
		{
			goto IL_0019;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___vector0;
		V_2 = L_6;
		goto IL_005d;
	}

IL_0019:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = ___vector0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___planeNormal1;
		float L_9;
		L_9 = Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline(L_7, L_8, NULL);
		V_3 = L_9;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___vector0;
		float L_11 = L_10.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = ___planeNormal1;
		float L_13 = L_12.___x_2;
		float L_14 = V_3;
		float L_15 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = ___vector0;
		float L_17 = L_16.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = ___planeNormal1;
		float L_19 = L_18.___y_3;
		float L_20 = V_3;
		float L_21 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = ___vector0;
		float L_23 = L_22.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = ___planeNormal1;
		float L_25 = L_24.___z_4;
		float L_26 = V_3;
		float L_27 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_28;
		memset((&L_28), 0, sizeof(L_28));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_28), ((float)il2cpp_codegen_subtract(L_11, ((float)(((float)il2cpp_codegen_multiply(L_13, L_14))/L_15)))), ((float)il2cpp_codegen_subtract(L_17, ((float)(((float)il2cpp_codegen_multiply(L_19, L_20))/L_21)))), ((float)il2cpp_codegen_subtract(L_23, ((float)(((float)il2cpp_codegen_multiply(L_25, L_26))/L_27)))), NULL);
		V_2 = L_28;
		goto IL_005d;
	}

IL_005d:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29 = V_2;
		return L_29;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* BlendSourceVirtualCamera_get_Blend_mAEA739F5A13237AF89E38325902ECA8316FC5719_inline (BlendSourceVirtualCamera_tBC5D4467B011DBBCCC2ECA69DE4A5F5257A4AF0E* __this, const RuntimeMethod* method) 
{
	{
		CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* L_0 = __this->___U3CBlendU3Ek__BackingField_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_mC9234CA4A835A608EC061116AB47E1F46B61CBB8_gshared_inline (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = (int32_t)__this->____size_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mC0E779187C6A6323C881ECDB91DCEDD828AD4423_gshared_inline (List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* __this, CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___item0, const RuntimeMethod* method) 
{
	CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C* V_0 = NULL;
	int32_t V_1 = 0;
	{
		int32_t L_0 = (int32_t)__this->____version_3;
		__this->____version_3 = ((int32_t)il2cpp_codegen_add(L_0, 1));
		CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C* L_1 = (CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C*)__this->____items_1;
		V_0 = L_1;
		int32_t L_2 = (int32_t)__this->____size_2;
		V_1 = L_2;
		int32_t L_3 = V_1;
		CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C* L_4 = V_0;
		NullCheck(L_4);
		if ((!(((uint32_t)L_3) < ((uint32_t)((int32_t)(((RuntimeArray*)L_4)->max_length))))))
		{
			goto IL_0034;
		}
	}
	{
		int32_t L_5 = V_1;
		__this->____size_2 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		CustomBlendableU5BU5D_t65CAAB17DA17F8AE296C99E8F0EDE61D97A67F4C* L_6 = V_0;
		int32_t L_7 = V_1;
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_8 = ___item0;
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(L_7), (CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB)L_8);
		return;
	}

IL_0034:
	{
		CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB L_9 = ___item0;
		List_1_AddWithResize_m4C218F14375DB7D7D5C0EC54E1FCF09D4C32E722(__this, L_9, il2cpp_rgctx_method(method->klass->rgctx_data, 14));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Quaternion__ctor_m868FD60AA65DD5A8AC0C5DEB0608381A8D85FCD8_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974* __this, float ___x0, float ___y1, float ___z2, float ___w3, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_0 = L_0;
		float L_1 = ___y1;
		__this->___y_1 = L_1;
		float L_2 = ___z2;
		__this->___z_2 = L_2;
		float L_3 = ___w3;
		__this->___w_3 = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Rect_op_Equality_m3592AA7AF3B2C809AAB02110B166B9A6F9263AD8_inline (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___lhs0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___rhs1, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t G_B5_0 = 0;
	{
		float L_0;
		L_0 = Rect_get_x_mB267B718E0D067F2BAE31BA477647FBF964916EB_inline((&___lhs0), NULL);
		float L_1;
		L_1 = Rect_get_x_mB267B718E0D067F2BAE31BA477647FBF964916EB_inline((&___rhs1), NULL);
		if ((!(((float)L_0) == ((float)L_1))))
		{
			goto IL_0043;
		}
	}
	{
		float L_2;
		L_2 = Rect_get_y_mC733E8D49F3CE21B2A3D40A1B72D687F22C97F49_inline((&___lhs0), NULL);
		float L_3;
		L_3 = Rect_get_y_mC733E8D49F3CE21B2A3D40A1B72D687F22C97F49_inline((&___rhs1), NULL);
		if ((!(((float)L_2) == ((float)L_3))))
		{
			goto IL_0043;
		}
	}
	{
		float L_4;
		L_4 = Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline((&___lhs0), NULL);
		float L_5;
		L_5 = Rect_get_width_m620D67551372073C9C32C4C4624C2A5713F7F9A9_inline((&___rhs1), NULL);
		if ((!(((float)L_4) == ((float)L_5))))
		{
			goto IL_0043;
		}
	}
	{
		float L_6;
		L_6 = Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline((&___lhs0), NULL);
		float L_7;
		L_7 = Rect_get_height_mE1AA6C6C725CCD2D317BD2157396D3CF7D47C9D8_inline((&___rhs1), NULL);
		G_B5_0 = ((((float)L_6) == ((float)L_7))? 1 : 0);
		goto IL_0044;
	}

IL_0043:
	{
		G_B5_0 = 0;
	}

IL_0044:
	{
		V_0 = (bool)G_B5_0;
		goto IL_0047;
	}

IL_0047:
	{
		bool L_8 = V_0;
		return L_8;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Normalize_m6120F119433C5B60BBB28731D3D4A0DA50A84DDD_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	bool V_1 = false;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___value0;
		float L_1;
		L_1 = Vector3_Magnitude_m6AD0BEBF88AAF98188A851E62D7A32CB5B7830EF_inline(L_0, NULL);
		V_0 = L_1;
		float L_2 = V_0;
		V_1 = (bool)((((float)L_2) > ((float)(9.99999975E-06f)))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_001e;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___value0;
		float L_5 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		L_6 = Vector3_op_Division_mD7200D6D432BAFC4135C5B17A0B0A812203B0270_inline(L_4, L_5, NULL);
		V_2 = L_6;
		goto IL_0026;
	}

IL_001e:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Vector3_get_zero_m9D7F7B580B5A276411267E96AA3425736D9BDC83_inline(NULL);
		V_2 = L_7;
		goto IL_0026;
	}

IL_0026:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = V_2;
		return L_8;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Angle_m1B9CC61B142C3A0E7EEB0559983CC391D1582F56_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___from0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___to1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	bool V_2 = false;
	float V_3 = 0.0f;
	{
		float L_0;
		L_0 = Vector3_get_sqrMagnitude_m43C27DEC47C4811FB30AB474FF2131A963B66FC8_inline((&___from0), NULL);
		float L_1;
		L_1 = Vector3_get_sqrMagnitude_m43C27DEC47C4811FB30AB474FF2131A963B66FC8_inline((&___to1), NULL);
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_2;
		L_2 = sqrt(((double)((float)il2cpp_codegen_multiply(L_0, L_1))));
		V_0 = ((float)L_2);
		float L_3 = V_0;
		V_2 = (bool)((((float)L_3) < ((float)(1.0E-15f)))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_002c;
		}
	}
	{
		V_3 = (0.0f);
		goto IL_0056;
	}

IL_002c:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = ___from0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___to1;
		float L_7;
		L_7 = Vector3_Dot_m4688A1A524306675DBDB1E6D483F35E85E3CE6D8_inline(L_5, L_6, NULL);
		float L_8 = V_0;
		float L_9;
		L_9 = Mathf_Clamp_m154E404AF275A3B2EC99ECAA3879B4CB9F0606DC_inline(((float)(L_7/L_8)), (-1.0f), (1.0f), NULL);
		V_1 = L_9;
		float L_10 = V_1;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_11;
		L_11 = acos(((double)L_10));
		V_3 = ((float)il2cpp_codegen_multiply(((float)L_11), (57.2957802f)));
		goto IL_0056;
	}

IL_0056:
	{
		float L_12 = V_3;
		return L_12;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_Normalize_m63D60A4A9F97145AF0C7E2A4C044EBF17EF7CBC3_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___q0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	bool V_1 = false;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ___q0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = ___q0;
		float L_2;
		L_2 = Quaternion_Dot_m4A80D03D7B7DEC054E2175E53D072675649C6713_inline(L_0, L_1, NULL);
		float L_3;
		L_3 = sqrtf(L_2);
		V_0 = L_3;
		float L_4 = V_0;
		float L_5 = ((Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_StaticFields*)il2cpp_codegen_static_fields_for(Mathf_tE284D016E3B297B72311AAD9EB8F0E643F6A4682_il2cpp_TypeInfo_var))->___Epsilon_0;
		V_1 = (bool)((((float)L_4) < ((float)L_5))? 1 : 0);
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0022;
		}
	}
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_7;
		L_7 = Quaternion_get_identity_mB9CAEEB21BC81352CBF32DB9664BFC06FA7EA27B_inline(NULL);
		V_2 = L_7;
		goto IL_004a;
	}

IL_0022:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_8 = ___q0;
		float L_9 = L_8.___x_0;
		float L_10 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_11 = ___q0;
		float L_12 = L_11.___y_1;
		float L_13 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_14 = ___q0;
		float L_15 = L_14.___z_2;
		float L_16 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_17 = ___q0;
		float L_18 = L_17.___w_3;
		float L_19 = V_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Quaternion__ctor_m868FD60AA65DD5A8AC0C5DEB0608381A8D85FCD8_inline((&L_20), ((float)(L_9/L_10)), ((float)(L_12/L_13)), ((float)(L_15/L_16)), ((float)(L_18/L_19)), NULL);
		V_2 = L_20;
		goto IL_004a;
	}

IL_004a:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_21 = V_2;
		return L_21;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Quaternion_Dot_m4A80D03D7B7DEC054E2175E53D072675649C6713_inline (Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___a0, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___b1, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ___a0;
		float L_1 = L_0.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_2 = ___b1;
		float L_3 = L_2.___x_0;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_4 = ___a0;
		float L_5 = L_4.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_6 = ___b1;
		float L_7 = L_6.___y_1;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_8 = ___a0;
		float L_9 = L_8.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_10 = ___b1;
		float L_11 = L_10.___z_2;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_12 = ___a0;
		float L_13 = L_12.___w_3;
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_14 = ___b1;
		float L_15 = L_14.___w_3;
		V_0 = ((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_1, L_3)), ((float)il2cpp_codegen_multiply(L_5, L_7)))), ((float)il2cpp_codegen_multiply(L_9, L_11)))), ((float)il2cpp_codegen_multiply(L_13, L_15))));
		goto IL_003b;
	}

IL_003b:
	{
		float L_16 = V_0;
		return L_16;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Quaternion_IsEqualUsingDot_m5C6AC5F5C56B27C25DDF612BEEF40F28CA44CA31_inline (float ___dot0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		float L_0 = ___dot0;
		V_0 = (bool)((((float)L_0) > ((float)(0.999998987f)))? 1 : 0);
		goto IL_000c;
	}

IL_000c:
	{
		bool L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Vector3_Magnitude_m6AD0BEBF88AAF98188A851E62D7A32CB5B7830EF_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___vector0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___vector0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___vector0;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___vector0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___vector0;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___vector0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___vector0;
		float L_11 = L_10.___z_4;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		double L_12;
		L_12 = sqrt(((double)((float)il2cpp_codegen_add(((float)il2cpp_codegen_add(((float)il2cpp_codegen_multiply(L_1, L_3)), ((float)il2cpp_codegen_multiply(L_5, L_7)))), ((float)il2cpp_codegen_multiply(L_9, L_11))))));
		V_0 = ((float)L_12);
		goto IL_0034;
	}

IL_0034:
	{
		float L_13 = V_0;
		return L_13;
	}
}
