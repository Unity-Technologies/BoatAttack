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
template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263;
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129;
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
struct CancellationTokenSource_tAAE1E0033BCFC233801F8CB4CED5C852B350CB7B;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct String_t;
struct Type_t;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral1A021298794A95A088D89F0DFEE478EB088FC94B;
IL2CPP_EXTERN_C String_t* _stringLiteral8B9E56C5D95D7C3EED5199236F70D44573B11813;
IL2CPP_EXTERN_C String_t* _stringLiteral9149DCC4875937380DD00ED5471A7A1258254B95;
IL2CPP_EXTERN_C String_t* _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
IL2CPP_EXTERN_C String_t* _stringLiteralF3C6C902DBF80139640F6554F0C3392016A8ADF7;
IL2CPP_EXTERN_C const RuntimeMethod* JsonUtility_FromJson_mCA93DB12788DA2F120D6EC81758D3189D9341815_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* JsonUtility_ToJson_mA7B20656D12861446AAA157DF6E9ACBBD78EC0AC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeType* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_0_0_0_var;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

struct U3CModuleU3E_t2F9091E403B25A5364AE8A6B2C249E31D405E3F4 
{
};
struct Il2CppArrayBounds;

struct JsonUtility_t731013D97E03B7EDAE6186D6D6826A53B85F7197  : public RuntimeObject
{
};

struct MemberInfo_t  : public RuntimeObject
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

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString_5;
	String_t* ___FalseString_6;
};

struct IntPtr_t 
{
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	intptr_t ___Zero_1;
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

struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	intptr_t ___value_0;
};

struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
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

struct Type_t  : public MemberInfo_t
{
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl_8;
};

struct Type_t_StaticFields
{
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder_0;
	Il2CppChar ___Delimiter_1;
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes_2;
	RuntimeObject* ___Missing_3;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute_4;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName_5;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase_6;
};

struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	String_t* ____paramName_18;
};

struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
};

struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
	CancellationTokenSource_tAAE1E0033BCFC233801F8CB4CED5C852B350CB7B* ___m_CancellationTokenSource_4;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JsonUtility_ToJson_mA7B20656D12861446AAA157DF6E9ACBBD78EC0AC (RuntimeObject* ___obj0, bool ___prettyPrint1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___message0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JsonUtility_ToJsonInternal_m55BF38958854796C9A5296AD0DCDE29BB9D0C8CF (RuntimeObject* ___obj0, bool ___prettyPrint1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_m54CF0907E7C4F3AFB2E796A13DC751ECBB8DB64A (String_t* ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7 (Type_t* ___left0, Type_t* ___right1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* __this, String_t* ___paramName0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Type_get_IsAbstract_m16FA83463867635ED9DECAE1C5F6BE96B4579CE5 (Type_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E (RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ___handle0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m9B13B47FCB3DF61144D9647DDA05F527377251B0 (String_t* ___str00, String_t* ___str11, String_t* ___str22, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* JsonUtility_FromJsonInternal_m09DB5F8C633417622AD3F43780975B39EFACC364 (String_t* ___json0, RuntimeObject* ___objectToOverwrite1, Type_t* ___type2, const RuntimeMethod* method) ;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JsonUtility_ToJsonInternal_m55BF38958854796C9A5296AD0DCDE29BB9D0C8CF (RuntimeObject* ___obj0, bool ___prettyPrint1, const RuntimeMethod* method) 
{
	typedef String_t* (*JsonUtility_ToJsonInternal_m55BF38958854796C9A5296AD0DCDE29BB9D0C8CF_ftn) (RuntimeObject*, bool);
	static JsonUtility_ToJsonInternal_m55BF38958854796C9A5296AD0DCDE29BB9D0C8CF_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (JsonUtility_ToJsonInternal_m55BF38958854796C9A5296AD0DCDE29BB9D0C8CF_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.JsonUtility::ToJsonInternal(System.Object,System.Boolean)");
	String_t* icallRetVal = _il2cpp_icall_func(___obj0, ___prettyPrint1);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* JsonUtility_FromJsonInternal_m09DB5F8C633417622AD3F43780975B39EFACC364 (String_t* ___json0, RuntimeObject* ___objectToOverwrite1, Type_t* ___type2, const RuntimeMethod* method) 
{
	typedef RuntimeObject* (*JsonUtility_FromJsonInternal_m09DB5F8C633417622AD3F43780975B39EFACC364_ftn) (String_t*, RuntimeObject*, Type_t*);
	static JsonUtility_FromJsonInternal_m09DB5F8C633417622AD3F43780975B39EFACC364_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (JsonUtility_FromJsonInternal_m09DB5F8C633417622AD3F43780975B39EFACC364_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.JsonUtility::FromJsonInternal(System.String,System.Object,System.Type)");
	RuntimeObject* icallRetVal = _il2cpp_icall_func(___json0, ___objectToOverwrite1, ___type2);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JsonUtility_ToJson_mD0FB24DC5A8621A2473FC208E9B15AF43944EBCD (RuntimeObject* ___obj0, const RuntimeMethod* method) 
{
	String_t* V_0 = NULL;
	{
		RuntimeObject* L_0 = ___obj0;
		String_t* L_1;
		L_1 = JsonUtility_ToJson_mA7B20656D12861446AAA157DF6E9ACBBD78EC0AC(L_0, (bool)0, NULL);
		V_0 = L_1;
		goto IL_000b;
	}

IL_000b:
	{
		String_t* L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JsonUtility_ToJson_mA7B20656D12861446AAA157DF6E9ACBBD78EC0AC (RuntimeObject* ___obj0, bool ___prettyPrint1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	String_t* V_1 = NULL;
	bool V_2 = false;
	int32_t G_B6_0 = 0;
	int32_t G_B8_0 = 0;
	{
		RuntimeObject* L_0 = ___obj0;
		V_0 = (bool)((((RuntimeObject*)(RuntimeObject*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0011;
		}
	}
	{
		V_1 = _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
		goto IL_004c;
	}

IL_0011:
	{
		RuntimeObject* L_2 = ___obj0;
		if (!((Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)IsInstClass((RuntimeObject*)L_2, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var)))
		{
			goto IL_0032;
		}
	}
	{
		RuntimeObject* L_3 = ___obj0;
		if (((MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71*)IsInstClass((RuntimeObject*)L_3, MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71_il2cpp_TypeInfo_var)))
		{
			goto IL_002f;
		}
	}
	{
		RuntimeObject* L_4 = ___obj0;
		G_B6_0 = ((((int32_t)((!(((RuntimeObject*)(ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A*)((ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A*)IsInstClass((RuntimeObject*)L_4, ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A_il2cpp_TypeInfo_var))) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B6_0 = 0;
	}

IL_0030:
	{
		G_B8_0 = G_B6_0;
		goto IL_0033;
	}

IL_0032:
	{
		G_B8_0 = 0;
	}

IL_0033:
	{
		V_2 = (bool)G_B8_0;
		bool L_5 = V_2;
		if (!L_5)
		{
			goto IL_0042;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_6 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_6);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral8B9E56C5D95D7C3EED5199236F70D44573B11813)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&JsonUtility_ToJson_mA7B20656D12861446AAA157DF6E9ACBBD78EC0AC_RuntimeMethod_var)));
	}

IL_0042:
	{
		RuntimeObject* L_7 = ___obj0;
		bool L_8 = ___prettyPrint1;
		String_t* L_9;
		L_9 = JsonUtility_ToJsonInternal_m55BF38958854796C9A5296AD0DCDE29BB9D0C8CF(L_7, L_8, NULL);
		V_1 = L_9;
		goto IL_004c;
	}

IL_004c:
	{
		String_t* L_10 = V_1;
		return L_10;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* JsonUtility_FromJson_mCA93DB12788DA2F120D6EC81758D3189D9341815 (String_t* ___json0, Type_t* ___type1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	RuntimeObject* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t G_B7_0 = 0;
	{
		String_t* L_0 = ___json0;
		bool L_1;
		L_1 = String_IsNullOrEmpty_m54CF0907E7C4F3AFB2E796A13DC751ECBB8DB64A(L_0, NULL);
		V_0 = L_1;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_000f;
		}
	}
	{
		V_1 = NULL;
		goto IL_006a;
	}

IL_000f:
	{
		Type_t* L_3 = ___type1;
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_3, (Type_t*)NULL, NULL);
		V_2 = L_4;
		bool L_5 = V_2;
		if (!L_5)
		{
			goto IL_0025;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_6 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		NullCheck(L_6);
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF3C6C902DBF80139640F6554F0C3392016A8ADF7)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&JsonUtility_FromJson_mCA93DB12788DA2F120D6EC81758D3189D9341815_RuntimeMethod_var)));
	}

IL_0025:
	{
		Type_t* L_7 = ___type1;
		NullCheck(L_7);
		bool L_8;
		L_8 = Type_get_IsAbstract_m16FA83463867635ED9DECAE1C5F6BE96B4579CE5(L_7, NULL);
		if (L_8)
		{
			goto IL_003f;
		}
	}
	{
		Type_t* L_9 = ___type1;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		NullCheck(L_9);
		bool L_12;
		L_12 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(21, L_9, L_11);
		G_B7_0 = ((int32_t)(L_12));
		goto IL_0040;
	}

IL_003f:
	{
		G_B7_0 = 1;
	}

IL_0040:
	{
		V_3 = (bool)G_B7_0;
		bool L_13 = V_3;
		if (!L_13)
		{
			goto IL_005f;
		}
	}
	{
		Type_t* L_14 = ___type1;
		NullCheck(L_14);
		String_t* L_15;
		L_15 = VirtualFuncInvoker0< String_t* >::Invoke(8, L_14);
		String_t* L_16;
		L_16 = String_Concat_m9B13B47FCB3DF61144D9647DDA05F527377251B0(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral9149DCC4875937380DD00ED5471A7A1258254B95)), L_15, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral1A021298794A95A088D89F0DFEE478EB088FC94B)), NULL);
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_17 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_17);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_17, L_16, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_17, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&JsonUtility_FromJson_mCA93DB12788DA2F120D6EC81758D3189D9341815_RuntimeMethod_var)));
	}

IL_005f:
	{
		String_t* L_18 = ___json0;
		Type_t* L_19 = ___type1;
		RuntimeObject* L_20;
		L_20 = JsonUtility_FromJsonInternal_m09DB5F8C633417622AD3F43780975B39EFACC364(L_18, NULL, L_19, NULL);
		V_1 = L_20;
		goto IL_006a;
	}

IL_006a:
	{
		RuntimeObject* L_21 = V_1;
		return L_21;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
