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
struct InterfaceFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1>
struct InvokerActionInvoker1;
template <typename T1>
struct InvokerActionInvoker1<T1*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1)
	{
		void* params[1] = { p1 };
		method->invoker_method(methodPtr, method, obj, params, params[0]);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2;
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1, T2*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1 p1, T2* p2)
	{
		void* params[2] = { &p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, params[1]);
	}
};
template <typename R, typename T1, typename T2>
struct InvokerFuncInvoker2;
template <typename R, typename T1, typename T2>
struct InvokerFuncInvoker2<R, T1*, T2*>
{
	static inline R Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2)
	{
		R ret;
		void* params[2] = { p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, &ret);
		return ret;
	}
};

struct Dictionary_2_t9FA6D82CAFC18769F7515BB51D1C56DAE09381C3;
struct Dictionary_2_tE1603CE612C16451D1E56FF4D4859D4FE4087C28;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
struct Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B;
struct CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57;
struct CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D;
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0;
struct DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IFormatProvider_tC202922D43BFF3525109ABF3FB79625F5646AB52;
struct IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82;
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A;
struct NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct String_t;
struct StringBuilder_t;
struct TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4;
struct Type_t;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* StringBuilder_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral3DCC6243286938BE75C3FA773B9BA71160A2E869;
IL2CPP_EXTERN_C String_t* _stringLiteral491788442E76F5D7830F0DBFCF8EDD98854F636F;
IL2CPP_EXTERN_C String_t* _stringLiteralE310274B02A605A3985345944A620D7D2E019A1A;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_GetAllBitsSetValue_m5AEB1D20298C13CBD8F8A67B7FBE15ECF8DFCB1E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_GetOneValue_m5547048AF495EEF927EF7BD8647DAAD6D237CB3A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_InitializeCount_m41FB8B7B182526C04FD387334B598146762AB198_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_InitializeCount_mE82AC635FE85862D388CE15B6CC68AE715A77543_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_ScalarEquals_mFF6DBE46F1E8F7B060FBFB3F1C003C55494F4EA8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeType* Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var;
struct CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_com;
struct CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_pinvoke;
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_com;
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct Il2CppArrayBounds;

struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0  : public RuntimeObject
{
	bool ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	bool ___m_useUserOverride_9;
	NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* ___numInfo_10;
	DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A* ___dateTimeInfo_11;
	TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4* ___textInfo_12;
	String_t* ___m_name_13;
	String_t* ___englishname_14;
	String_t* ___nativename_15;
	String_t* ___iso3lang_16;
	String_t* ___iso2lang_17;
	String_t* ___win3lang_18;
	String_t* ___territory_19;
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___native_calendar_names_20;
	CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57* ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B* ___calendar_24;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___parent_culture_25;
	bool ___constructed_26;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___cached_serialized_form_27;
	CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D* ___m_cultureData_28;
	bool ___m_isInherited_29;
};

struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_StaticFields
{
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___invariant_culture_info_0;
	RuntimeObject* ___shared_table_lock_1;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___default_current_culture_2;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___s_DefaultThreadCurrentUICulture_34;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___s_DefaultThreadCurrentCulture_35;
	Dictionary_2_t9FA6D82CAFC18769F7515BB51D1C56DAE09381C3* ___shared_by_number_36;
	Dictionary_2_tE1603CE612C16451D1E56FF4D4859D4FE4087C28* ___shared_by_name_37;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___s_UserPreferredCultureInfoInAppX_38;
	bool ___IsTaiwanSku_39;
};
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_pinvoke
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* ___numInfo_10;
	DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A* ___dateTimeInfo_11;
	TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4* ___textInfo_12;
	char* ___m_name_13;
	char* ___englishname_14;
	char* ___nativename_15;
	char* ___iso3lang_16;
	char* ___iso2lang_17;
	char* ___win3lang_18;
	char* ___territory_19;
	char** ___native_calendar_names_20;
	CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57* ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B* ___calendar_24;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_pinvoke* ___parent_culture_25;
	int32_t ___constructed_26;
	Il2CppSafeArray* ___cached_serialized_form_27;
	CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_pinvoke* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_com
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* ___numInfo_10;
	DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A* ___dateTimeInfo_11;
	TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4* ___textInfo_12;
	Il2CppChar* ___m_name_13;
	Il2CppChar* ___englishname_14;
	Il2CppChar* ___nativename_15;
	Il2CppChar* ___iso3lang_16;
	Il2CppChar* ___iso2lang_17;
	Il2CppChar* ___win3lang_18;
	Il2CppChar* ___territory_19;
	Il2CppChar** ___native_calendar_names_20;
	CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57* ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B* ___calendar_24;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_com* ___parent_culture_25;
	int32_t ___constructed_26;
	Il2CppSafeArray* ___cached_serialized_form_27;
	CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_com* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};

struct MemberInfo_t  : public RuntimeObject
{
};

struct NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472  : public RuntimeObject
{
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___numberGroupSizes_1;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___currencyGroupSizes_2;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___percentGroupSizes_3;
	String_t* ___positiveSign_4;
	String_t* ___negativeSign_5;
	String_t* ___numberDecimalSeparator_6;
	String_t* ___numberGroupSeparator_7;
	String_t* ___currencyGroupSeparator_8;
	String_t* ___currencyDecimalSeparator_9;
	String_t* ___currencySymbol_10;
	String_t* ___ansiCurrencySymbol_11;
	String_t* ___nanSymbol_12;
	String_t* ___positiveInfinitySymbol_13;
	String_t* ___negativeInfinitySymbol_14;
	String_t* ___percentDecimalSeparator_15;
	String_t* ___percentGroupSeparator_16;
	String_t* ___percentSymbol_17;
	String_t* ___perMilleSymbol_18;
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___nativeDigits_19;
	int32_t ___m_dataItem_20;
	int32_t ___numberDecimalDigits_21;
	int32_t ___currencyDecimalDigits_22;
	int32_t ___currencyPositivePattern_23;
	int32_t ___currencyNegativePattern_24;
	int32_t ___numberNegativePattern_25;
	int32_t ___percentPositivePattern_26;
	int32_t ___percentNegativePattern_27;
	int32_t ___percentDecimalDigits_28;
	int32_t ___digitSubstitution_29;
	bool ___isReadOnly_30;
	bool ___m_useUserOverride_31;
	bool ___m_isInvariant_32;
	bool ___validForParseAsNumber_33;
	bool ___validForParseAsCurrency_34;
};

struct NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472_StaticFields
{
	NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* ___invariantInfo_0;
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

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString_5;
	String_t* ___FalseString_6;
};

struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value_0;
};

struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	Il2CppChar ___m_value_0;
};

struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1_3;
};

struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	double ___m_value_0;
};

struct Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175 
{
	int16_t ___m_value_0;
};

struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value_0;
};

struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	int64_t ___m_value_0;
};

struct IntPtr_t 
{
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	intptr_t ___Zero_1;
};

struct Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A 
{
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			uint8_t ___byte_0_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint8_t ___byte_0_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_1_1_OffsetPadding[1];
			uint8_t ___byte_1_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_1_1_OffsetPadding_forAlignmentOnly[1];
			uint8_t ___byte_1_1_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_2_2_OffsetPadding[2];
			uint8_t ___byte_2_2;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_2_2_OffsetPadding_forAlignmentOnly[2];
			uint8_t ___byte_2_2_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_3_3_OffsetPadding[3];
			uint8_t ___byte_3_3;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_3_3_OffsetPadding_forAlignmentOnly[3];
			uint8_t ___byte_3_3_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_4_4_OffsetPadding[4];
			uint8_t ___byte_4_4;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_4_4_OffsetPadding_forAlignmentOnly[4];
			uint8_t ___byte_4_4_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_5_5_OffsetPadding[5];
			uint8_t ___byte_5_5;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_5_5_OffsetPadding_forAlignmentOnly[5];
			uint8_t ___byte_5_5_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_6_6_OffsetPadding[6];
			uint8_t ___byte_6_6;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_6_6_OffsetPadding_forAlignmentOnly[6];
			uint8_t ___byte_6_6_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_7_7_OffsetPadding[7];
			uint8_t ___byte_7_7;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_7_7_OffsetPadding_forAlignmentOnly[7];
			uint8_t ___byte_7_7_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_8_8_OffsetPadding[8];
			uint8_t ___byte_8_8;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_8_8_OffsetPadding_forAlignmentOnly[8];
			uint8_t ___byte_8_8_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_9_9_OffsetPadding[9];
			uint8_t ___byte_9_9;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_9_9_OffsetPadding_forAlignmentOnly[9];
			uint8_t ___byte_9_9_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_10_10_OffsetPadding[10];
			uint8_t ___byte_10_10;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_10_10_OffsetPadding_forAlignmentOnly[10];
			uint8_t ___byte_10_10_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_11_11_OffsetPadding[11];
			uint8_t ___byte_11_11;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_11_11_OffsetPadding_forAlignmentOnly[11];
			uint8_t ___byte_11_11_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_12_12_OffsetPadding[12];
			uint8_t ___byte_12_12;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_12_12_OffsetPadding_forAlignmentOnly[12];
			uint8_t ___byte_12_12_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_13_13_OffsetPadding[13];
			uint8_t ___byte_13_13;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_13_13_OffsetPadding_forAlignmentOnly[13];
			uint8_t ___byte_13_13_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_14_14_OffsetPadding[14];
			uint8_t ___byte_14_14;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_14_14_OffsetPadding_forAlignmentOnly[14];
			uint8_t ___byte_14_14_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___byte_15_15_OffsetPadding[15];
			uint8_t ___byte_15_15;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___byte_15_15_OffsetPadding_forAlignmentOnly[15];
			uint8_t ___byte_15_15_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			int8_t ___sbyte_0_16;
		};
		#pragma pack(pop, tp)
		struct
		{
			int8_t ___sbyte_0_16_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_1_17_OffsetPadding[1];
			int8_t ___sbyte_1_17;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_1_17_OffsetPadding_forAlignmentOnly[1];
			int8_t ___sbyte_1_17_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_2_18_OffsetPadding[2];
			int8_t ___sbyte_2_18;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_2_18_OffsetPadding_forAlignmentOnly[2];
			int8_t ___sbyte_2_18_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_3_19_OffsetPadding[3];
			int8_t ___sbyte_3_19;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_3_19_OffsetPadding_forAlignmentOnly[3];
			int8_t ___sbyte_3_19_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_4_20_OffsetPadding[4];
			int8_t ___sbyte_4_20;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_4_20_OffsetPadding_forAlignmentOnly[4];
			int8_t ___sbyte_4_20_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_5_21_OffsetPadding[5];
			int8_t ___sbyte_5_21;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_5_21_OffsetPadding_forAlignmentOnly[5];
			int8_t ___sbyte_5_21_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_6_22_OffsetPadding[6];
			int8_t ___sbyte_6_22;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_6_22_OffsetPadding_forAlignmentOnly[6];
			int8_t ___sbyte_6_22_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_7_23_OffsetPadding[7];
			int8_t ___sbyte_7_23;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_7_23_OffsetPadding_forAlignmentOnly[7];
			int8_t ___sbyte_7_23_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_8_24_OffsetPadding[8];
			int8_t ___sbyte_8_24;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_8_24_OffsetPadding_forAlignmentOnly[8];
			int8_t ___sbyte_8_24_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_9_25_OffsetPadding[9];
			int8_t ___sbyte_9_25;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_9_25_OffsetPadding_forAlignmentOnly[9];
			int8_t ___sbyte_9_25_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_10_26_OffsetPadding[10];
			int8_t ___sbyte_10_26;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_10_26_OffsetPadding_forAlignmentOnly[10];
			int8_t ___sbyte_10_26_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_11_27_OffsetPadding[11];
			int8_t ___sbyte_11_27;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_11_27_OffsetPadding_forAlignmentOnly[11];
			int8_t ___sbyte_11_27_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_12_28_OffsetPadding[12];
			int8_t ___sbyte_12_28;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_12_28_OffsetPadding_forAlignmentOnly[12];
			int8_t ___sbyte_12_28_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_13_29_OffsetPadding[13];
			int8_t ___sbyte_13_29;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_13_29_OffsetPadding_forAlignmentOnly[13];
			int8_t ___sbyte_13_29_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_14_30_OffsetPadding[14];
			int8_t ___sbyte_14_30;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_14_30_OffsetPadding_forAlignmentOnly[14];
			int8_t ___sbyte_14_30_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___sbyte_15_31_OffsetPadding[15];
			int8_t ___sbyte_15_31;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___sbyte_15_31_OffsetPadding_forAlignmentOnly[15];
			int8_t ___sbyte_15_31_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			uint16_t ___uint16_0_32;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint16_t ___uint16_0_32_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint16_1_33_OffsetPadding[2];
			uint16_t ___uint16_1_33;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint16_1_33_OffsetPadding_forAlignmentOnly[2];
			uint16_t ___uint16_1_33_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint16_2_34_OffsetPadding[4];
			uint16_t ___uint16_2_34;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint16_2_34_OffsetPadding_forAlignmentOnly[4];
			uint16_t ___uint16_2_34_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint16_3_35_OffsetPadding[6];
			uint16_t ___uint16_3_35;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint16_3_35_OffsetPadding_forAlignmentOnly[6];
			uint16_t ___uint16_3_35_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint16_4_36_OffsetPadding[8];
			uint16_t ___uint16_4_36;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint16_4_36_OffsetPadding_forAlignmentOnly[8];
			uint16_t ___uint16_4_36_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint16_5_37_OffsetPadding[10];
			uint16_t ___uint16_5_37;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint16_5_37_OffsetPadding_forAlignmentOnly[10];
			uint16_t ___uint16_5_37_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint16_6_38_OffsetPadding[12];
			uint16_t ___uint16_6_38;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint16_6_38_OffsetPadding_forAlignmentOnly[12];
			uint16_t ___uint16_6_38_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint16_7_39_OffsetPadding[14];
			uint16_t ___uint16_7_39;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint16_7_39_OffsetPadding_forAlignmentOnly[14];
			uint16_t ___uint16_7_39_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			int16_t ___int16_0_40;
		};
		#pragma pack(pop, tp)
		struct
		{
			int16_t ___int16_0_40_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int16_1_41_OffsetPadding[2];
			int16_t ___int16_1_41;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int16_1_41_OffsetPadding_forAlignmentOnly[2];
			int16_t ___int16_1_41_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int16_2_42_OffsetPadding[4];
			int16_t ___int16_2_42;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int16_2_42_OffsetPadding_forAlignmentOnly[4];
			int16_t ___int16_2_42_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int16_3_43_OffsetPadding[6];
			int16_t ___int16_3_43;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int16_3_43_OffsetPadding_forAlignmentOnly[6];
			int16_t ___int16_3_43_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int16_4_44_OffsetPadding[8];
			int16_t ___int16_4_44;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int16_4_44_OffsetPadding_forAlignmentOnly[8];
			int16_t ___int16_4_44_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int16_5_45_OffsetPadding[10];
			int16_t ___int16_5_45;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int16_5_45_OffsetPadding_forAlignmentOnly[10];
			int16_t ___int16_5_45_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int16_6_46_OffsetPadding[12];
			int16_t ___int16_6_46;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int16_6_46_OffsetPadding_forAlignmentOnly[12];
			int16_t ___int16_6_46_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int16_7_47_OffsetPadding[14];
			int16_t ___int16_7_47;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int16_7_47_OffsetPadding_forAlignmentOnly[14];
			int16_t ___int16_7_47_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			uint32_t ___uint32_0_48;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint32_t ___uint32_0_48_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint32_1_49_OffsetPadding[4];
			uint32_t ___uint32_1_49;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint32_1_49_OffsetPadding_forAlignmentOnly[4];
			uint32_t ___uint32_1_49_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint32_2_50_OffsetPadding[8];
			uint32_t ___uint32_2_50;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint32_2_50_OffsetPadding_forAlignmentOnly[8];
			uint32_t ___uint32_2_50_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint32_3_51_OffsetPadding[12];
			uint32_t ___uint32_3_51;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint32_3_51_OffsetPadding_forAlignmentOnly[12];
			uint32_t ___uint32_3_51_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			int32_t ___int32_0_52;
		};
		#pragma pack(pop, tp)
		struct
		{
			int32_t ___int32_0_52_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int32_1_53_OffsetPadding[4];
			int32_t ___int32_1_53;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int32_1_53_OffsetPadding_forAlignmentOnly[4];
			int32_t ___int32_1_53_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int32_2_54_OffsetPadding[8];
			int32_t ___int32_2_54;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int32_2_54_OffsetPadding_forAlignmentOnly[8];
			int32_t ___int32_2_54_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int32_3_55_OffsetPadding[12];
			int32_t ___int32_3_55;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int32_3_55_OffsetPadding_forAlignmentOnly[12];
			int32_t ___int32_3_55_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			uint64_t ___uint64_0_56;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint64_t ___uint64_0_56_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___uint64_1_57_OffsetPadding[8];
			uint64_t ___uint64_1_57;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___uint64_1_57_OffsetPadding_forAlignmentOnly[8];
			uint64_t ___uint64_1_57_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			int64_t ___int64_0_58;
		};
		#pragma pack(pop, tp)
		struct
		{
			int64_t ___int64_0_58_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___int64_1_59_OffsetPadding[8];
			int64_t ___int64_1_59;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___int64_1_59_OffsetPadding_forAlignmentOnly[8];
			int64_t ___int64_1_59_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			float ___single_0_60;
		};
		#pragma pack(pop, tp)
		struct
		{
			float ___single_0_60_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___single_1_61_OffsetPadding[4];
			float ___single_1_61;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___single_1_61_OffsetPadding_forAlignmentOnly[4];
			float ___single_1_61_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___single_2_62_OffsetPadding[8];
			float ___single_2_62;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___single_2_62_OffsetPadding_forAlignmentOnly[8];
			float ___single_2_62_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___single_3_63_OffsetPadding[12];
			float ___single_3_63;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___single_3_63_OffsetPadding_forAlignmentOnly[12];
			float ___single_3_63_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			double ___double_0_64;
		};
		#pragma pack(pop, tp)
		struct
		{
			double ___double_0_64_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___double_1_65_OffsetPadding[8];
			double ___double_1_65;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___double_1_65_OffsetPadding_forAlignmentOnly[8];
			double ___double_1_65_forAlignmentOnly;
		};
	};
};

struct SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5 
{
	int8_t ___m_value_0;
};

struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value_0;
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

struct Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A 
{
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A ___register_0;
};

struct Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields
{
	int32_t ___s_count_1;
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___s_zero_2;
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___s_one_3;
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___s_allOnes_4;
};

struct Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 
{
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A ___register_0;
};

struct Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2_StaticFields
{
	int32_t ___s_count_1;
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___s_zero_2;
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___s_one_3;
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___s_allOnes_4;
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

struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	intptr_t ___value_0;
};

struct VectorSizeHelper_tF54ACCE947CB8A38047BEB642392A4E7345A157D 
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ____placeholder_0;
	uint8_t ____byte_1;
};

struct VectorSizeHelper_tAB183E4966E0B97A19A75D213EDAE51037A6BF3C 
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ____placeholder_0;
	uint8_t ____byte_1;
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

struct IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif


IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, uint64_t ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, void* ___dataPointer0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, int32_t ___index0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___other0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_Equals_mE275DCDE4DC3B6FB30AB80ACEAC8363207BA9BEC_gshared_inline (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_gshared_inline (uint64_t ___left0, uint64_t ___right1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_m8F20119DB8CF7117F2D6E4D165C4A843F7D3586C_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_m3EBF88D3E195BD2C4B0D1CCBD9F71E32233CA4F4_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_op_Equality_m50B11C67F1AC4D10224413FBF3AC098A8037A021_gshared_inline (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___left0, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___right1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_InitializeCount_m41FB8B7B182526C04FD387334B598146762AB198_gshared (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Il2CppFullySharedGenericStruct ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, void* ___dataPointer0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, int32_t ___index0, Il2CppFullySharedGenericStruct* il2cppRetVal, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_Equals_m1D6500596F9B825F39D474A32D7A6D5E14E22B8F_gshared_inline (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___other0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_m212191DE0383E512D8297CE138DB5C06BF1E6F4A_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_mB21C58D9FD6C9A89DF0D786C50F960E551B1FB8F_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E (RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ___handle0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7 (Type_t* ___left0, Type_t* ___right1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* __this, String_t* ___message0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D (const RuntimeMethod* method) ;
inline int32_t Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline (const RuntimeMethod* method)
{
	return ((  int32_t (*) (const RuntimeMethod*))Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_gshared_inline)(method);
}
inline void Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6 (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, uint64_t ___value0, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, uint64_t, const RuntimeMethod*))Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6_gshared)(__this, ___value0, method);
}
inline void Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, void*, int32_t, const RuntimeMethod*))Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B_gshared)(__this, ___dataPointer0, ___offset1, method);
}
inline void Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, void* ___dataPointer0, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, void*, const RuntimeMethod*))Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA_gshared)(__this, ___dataPointer0, method);
}
inline void Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606 (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*, const RuntimeMethod*))Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_gshared)(__this, ___existingRegister0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* SR_Format_mB99C6F1BE061EA1427A45176E0CAFB2A2C76D03F (String_t* ___resourceFormat0, RuntimeObject* ___p11, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425 (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* __this, String_t* ___message0, const RuntimeMethod* method) ;
inline uint64_t Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99 (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, int32_t ___index0, const RuntimeMethod* method)
{
	return ((  uint64_t (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, int32_t, const RuntimeMethod*))Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99_gshared)(__this, ___index0, method);
}
inline bool Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27 (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___other0, const RuntimeMethod* method)
{
	return ((  bool (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A, const RuntimeMethod*))Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27_gshared)(__this, ___other0, method);
}
inline bool Vector_1_Equals_mE275DCDE4DC3B6FB30AB80ACEAC8363207BA9BEC_inline (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	return ((  bool (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, RuntimeObject*, const RuntimeMethod*))Vector_1_Equals_mE275DCDE4DC3B6FB30AB80ACEAC8363207BA9BEC_gshared_inline)(__this, ___obj0, method);
}
inline bool Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline (uint64_t ___left0, uint64_t ___right1, const RuntimeMethod* method)
{
	return ((  bool (*) (uint64_t, uint64_t, const RuntimeMethod*))Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_gshared_inline)(___left0, ___right1, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678 (uint8_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344 (int32_t ___h10, int32_t ___h21, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF (int8_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200 (uint16_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1 (int16_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC (uint32_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295 (int32_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UInt64_GetHashCode_m65D9FD0102B6B01BF38D986F060F0BDBC29B4F92 (uint64_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Int64_GetHashCode_mDB050BE2AC244D92B14D1DF725AAD279CDC48496 (int64_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2 (float* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline (double* __this, const RuntimeMethod* method) ;
inline int32_t Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, const RuntimeMethod*))Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* CultureInfo_get_CurrentCulture_m43D1E4E50AB1F62ADC7C1884F28F918B53871522 (const RuntimeMethod* method) ;
inline String_t* Vector_1_ToString_m8F20119DB8CF7117F2D6E4D165C4A843F7D3586C (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method)
{
	return ((  String_t* (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, String_t*, RuntimeObject*, const RuntimeMethod*))Vector_1_ToString_m8F20119DB8CF7117F2D6E4D165C4A843F7D3586C_gshared)(__this, ___format0, ___formatProvider1, method);
}
inline String_t* Vector_1_ToString_m3EBF88D3E195BD2C4B0D1CCBD9F71E32233CA4F4 (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, const RuntimeMethod* method)
{
	return ((  String_t* (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*, const RuntimeMethod*))Vector_1_ToString_m3EBF88D3E195BD2C4B0D1CCBD9F71E32233CA4F4_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void StringBuilder__ctor_m1D99713357DE05DAFA296633639DB55F8C30587D (StringBuilder_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* NumberFormatInfo_GetInstance_m68D84692285114DC53C752EFC2A559319D117E71 (RuntimeObject* ___formatProvider0, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* NumberFormatInfo_get_NumberGroupSeparator_m0556B092AA471513B1EDC31C047712226D39BEB6_inline (NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1 (StringBuilder_t* __this, Il2CppChar ___value0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D (StringBuilder_t* __this, String_t* ___value0, const RuntimeMethod* method) ;
inline bool Vector_1_op_Equality_m50B11C67F1AC4D10224413FBF3AC098A8037A021_inline (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___left0, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___right1, const RuntimeMethod* method)
{
	return ((  bool (*) (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A, const RuntimeMethod*))Vector_1_op_Equality_m50B11C67F1AC4D10224413FBF3AC098A8037A021_gshared_inline)(___left0, ___right1, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint8_t ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int8_t ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint16_t ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int16_t ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR double ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline (const RuntimeMethod* method) ;
inline int32_t Vector_1_InitializeCount_m41FB8B7B182526C04FD387334B598146762AB198 (const RuntimeMethod* method)
{
	return ((  int32_t (*) (const RuntimeMethod*))Vector_1_InitializeCount_m41FB8B7B182526C04FD387334B598146762AB198_gshared)(method);
}
inline uint64_t Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_inline (const RuntimeMethod* method)
{
	return ((  uint64_t (*) (const RuntimeMethod*))Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_gshared_inline)(method);
}
inline uint64_t Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_inline (const RuntimeMethod* method)
{
	return ((  uint64_t (*) (const RuntimeMethod*))Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_gshared_inline)(method);
}
inline void Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2 (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Il2CppFullySharedGenericStruct ___value0, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, Il2CppFullySharedGenericStruct, const RuntimeMethod*))Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2_gshared)((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)__this, ___value0, method);
}
inline void Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001 (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, void* ___dataPointer0, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, void*, const RuntimeMethod*))Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001_gshared)(__this, ___dataPointer0, method);
}
inline void Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9 (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, void*, int32_t, const RuntimeMethod*))Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9_gshared)(__this, ___dataPointer0, ___offset1, method);
}
inline void Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674 (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*, const RuntimeMethod*))Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674_gshared)(__this, ___existingRegister0, method);
}
inline void Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, int32_t ___index0, Il2CppFullySharedGenericStruct* il2cppRetVal, const RuntimeMethod* method)
{
	((  void (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, int32_t, Il2CppFullySharedGenericStruct*, const RuntimeMethod*))Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C_gshared)((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)__this, ___index0, il2cppRetVal, method);
}
inline bool Vector_1_Equals_m1D6500596F9B825F39D474A32D7A6D5E14E22B8F_inline (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	return ((  bool (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, RuntimeObject*, const RuntimeMethod*))Vector_1_Equals_m1D6500596F9B825F39D474A32D7A6D5E14E22B8F_gshared_inline)(__this, ___obj0, method);
}
inline bool Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8 (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___other0, const RuntimeMethod* method)
{
	return ((  bool (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2, const RuntimeMethod*))Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8_gshared)(__this, ___other0, method);
}
inline int32_t Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, const RuntimeMethod*))Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF_gshared)(__this, method);
}
inline String_t* Vector_1_ToString_m212191DE0383E512D8297CE138DB5C06BF1E6F4A (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, const RuntimeMethod* method)
{
	return ((  String_t* (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, const RuntimeMethod*))Vector_1_ToString_m212191DE0383E512D8297CE138DB5C06BF1E6F4A_gshared)(__this, method);
}
inline String_t* Vector_1_ToString_mB21C58D9FD6C9A89DF0D786C50F960E551B1FB8F (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method)
{
	return ((  String_t* (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, String_t*, RuntimeObject*, const RuntimeMethod*))Vector_1_ToString_mB21C58D9FD6C9A89DF0D786C50F960E551B1FB8F_gshared)(__this, ___format0, ___formatProvider1, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t BitConverter_DoubleToInt64Bits_m45D911F884F3B09BF39C02044EDC9BDA8084C80B_inline (double ___value0, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_gshared (const RuntimeMethod* method) 
{
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_0 = ((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_count_1;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A Vector_1_get_Zero_m35BE87027071FC73527CA6999BD25BD1C9E1C9EF_gshared (const RuntimeMethod* method) 
{
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_0 = ((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_zero_2;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_InitializeCount_m41FB8B7B182526C04FD387334B598146762AB198_gshared (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	VectorSizeHelper_tF54ACCE947CB8A38047BEB642392A4E7345A157D V_0;
	memset((&V_0), 0, sizeof(V_0));
	uint8_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t G_B2_0 = 0;
	int32_t G_B1_0 = 0;
	int32_t G_B21_0 = 0;
	int32_t G_B4_0 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B6_0 = 0;
	int32_t G_B5_0 = 0;
	int32_t G_B8_0 = 0;
	int32_t G_B7_0 = 0;
	int32_t G_B10_0 = 0;
	int32_t G_B9_0 = 0;
	int32_t G_B12_0 = 0;
	int32_t G_B11_0 = 0;
	int32_t G_B14_0 = 0;
	int32_t G_B13_0 = 0;
	int32_t G_B16_0 = 0;
	int32_t G_B15_0 = 0;
	int32_t G_B18_0 = 0;
	int32_t G_B17_0 = 0;
	int32_t G_B20_0 = 0;
	int32_t G_B19_0 = 0;
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* L_0 = (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*)(&(&V_0)->____placeholder_0);
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_1 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&L_0->___register_0);
		uint8_t* L_2 = (uint8_t*)(&L_1->___byte_0_0);
		V_1 = (uint8_t*)((uintptr_t)L_2);
		uint8_t* L_3 = (uint8_t*)(&(&V_0)->____byte_1);
		uint8_t* L_4 = V_1;
		V_2 = (-1);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_5 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_6;
		L_6 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_5, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_7 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_8;
		L_8 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_7, NULL);
		bool L_9;
		L_9 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_6, L_8, NULL);
		G_B1_0 = ((int32_t)((int64_t)(intptr_t)((uint8_t*)((intptr_t)((uint8_t*)il2cpp_codegen_subtract((intptr_t)((uintptr_t)L_3), (intptr_t)L_4))/1))));
		if (!L_9)
		{
			G_B2_0 = ((int32_t)((int64_t)(intptr_t)((uint8_t*)((intptr_t)((uint8_t*)il2cpp_codegen_subtract((intptr_t)((uintptr_t)L_3), (intptr_t)L_4))/1))));
			goto IL_0045;
		}
	}
	{
		V_2 = 1;
		G_B21_0 = G_B1_0;
		goto IL_0176;
	}

IL_0045:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_12 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_13;
		L_13 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_12, NULL);
		bool L_14;
		L_14 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_11, L_13, NULL);
		G_B3_0 = G_B2_0;
		if (!L_14)
		{
			G_B4_0 = G_B2_0;
			goto IL_0067;
		}
	}
	{
		V_2 = 1;
		G_B21_0 = G_B3_0;
		goto IL_0176;
	}

IL_0067:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_15 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_16;
		L_16 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_15, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_17 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_18;
		L_18 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_17, NULL);
		bool L_19;
		L_19 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_16, L_18, NULL);
		G_B5_0 = G_B4_0;
		if (!L_19)
		{
			G_B6_0 = G_B4_0;
			goto IL_0089;
		}
	}
	{
		V_2 = 2;
		G_B21_0 = G_B5_0;
		goto IL_0176;
	}

IL_0089:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_20 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_21;
		L_21 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_20, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_22 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_23;
		L_23 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_22, NULL);
		bool L_24;
		L_24 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_21, L_23, NULL);
		G_B7_0 = G_B6_0;
		if (!L_24)
		{
			G_B8_0 = G_B6_0;
			goto IL_00ab;
		}
	}
	{
		V_2 = 2;
		G_B21_0 = G_B7_0;
		goto IL_0176;
	}

IL_00ab:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_25 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_26;
		L_26 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_25, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_27 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_28;
		L_28 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_27, NULL);
		bool L_29;
		L_29 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_26, L_28, NULL);
		G_B9_0 = G_B8_0;
		if (!L_29)
		{
			G_B10_0 = G_B8_0;
			goto IL_00cd;
		}
	}
	{
		V_2 = 4;
		G_B21_0 = G_B9_0;
		goto IL_0176;
	}

IL_00cd:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_32, NULL);
		bool L_34;
		L_34 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_31, L_33, NULL);
		G_B11_0 = G_B10_0;
		if (!L_34)
		{
			G_B12_0 = G_B10_0;
			goto IL_00ef;
		}
	}
	{
		V_2 = 4;
		G_B21_0 = G_B11_0;
		goto IL_0176;
	}

IL_00ef:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_37 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_38;
		L_38 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_37, NULL);
		bool L_39;
		L_39 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_36, L_38, NULL);
		G_B13_0 = G_B12_0;
		if (!L_39)
		{
			G_B14_0 = G_B12_0;
			goto IL_010e;
		}
	}
	{
		V_2 = 8;
		G_B21_0 = G_B13_0;
		goto IL_0176;
	}

IL_010e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_40 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_41;
		L_41 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_40, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		bool L_44;
		L_44 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_41, L_43, NULL);
		G_B15_0 = G_B14_0;
		if (!L_44)
		{
			G_B16_0 = G_B14_0;
			goto IL_012d;
		}
	}
	{
		V_2 = 8;
		G_B21_0 = G_B15_0;
		goto IL_0176;
	}

IL_012d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_45 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_46;
		L_46 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_45, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_47 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_48;
		L_48 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_47, NULL);
		bool L_49;
		L_49 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_46, L_48, NULL);
		G_B17_0 = G_B16_0;
		if (!L_49)
		{
			G_B18_0 = G_B16_0;
			goto IL_014c;
		}
	}
	{
		V_2 = 4;
		G_B21_0 = G_B17_0;
		goto IL_0176;
	}

IL_014c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_50 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_51;
		L_51 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_50, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_52 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_53;
		L_53 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_52, NULL);
		bool L_54;
		L_54 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_51, L_53, NULL);
		G_B19_0 = G_B18_0;
		if (!L_54)
		{
			G_B20_0 = G_B18_0;
			goto IL_016b;
		}
	}
	{
		V_2 = 8;
		G_B21_0 = G_B19_0;
		goto IL_0176;
	}

IL_016b:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_55 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_55);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_55, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_55, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_InitializeCount_m41FB8B7B182526C04FD387334B598146762AB198_RuntimeMethod_var)));
	}

IL_0176:
	{
		int32_t L_56 = V_2;
		return ((int32_t)(G_B21_0/L_56));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, uint64_t ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint8_t* V_0 = NULL;
	uint8_t* V_1 = NULL;
	int32_t V_2 = 0;
	int8_t* V_3 = NULL;
	int8_t* V_4 = NULL;
	int32_t V_5 = 0;
	uint16_t* V_6 = NULL;
	uint16_t* V_7 = NULL;
	int32_t V_8 = 0;
	int16_t* V_9 = NULL;
	int16_t* V_10 = NULL;
	int32_t V_11 = 0;
	uint32_t* V_12 = NULL;
	uint32_t* V_13 = NULL;
	int32_t V_14 = 0;
	int32_t* V_15 = NULL;
	int32_t* V_16 = NULL;
	int32_t V_17 = 0;
	uint64_t* V_18 = NULL;
	uint64_t* V_19 = NULL;
	int32_t V_20 = 0;
	int64_t* V_21 = NULL;
	int64_t* V_22 = NULL;
	int32_t V_23 = 0;
	float* V_24 = NULL;
	float* V_25 = NULL;
	int32_t V_26 = 0;
	double* V_27 = NULL;
	double* V_28 = NULL;
	int32_t V_29 = 0;
	{
		il2cpp_codegen_initobj(__this, sizeof(Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A));
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_0386;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_3, NULL);
		bool L_5;
		L_5 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_2, L_4, NULL);
		if (!L_5)
		{
			goto IL_005e;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_6 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_7 = (uint8_t*)(&L_6->___byte_0_0);
		V_1 = L_7;
		uint8_t* L_8 = V_1;
		V_0 = (uint8_t*)((uintptr_t)L_8);
		V_2 = 0;
		goto IL_0052;
	}

IL_003f:
	{
		uint8_t* L_9 = V_0;
		int32_t L_10 = V_2;
		uint64_t L_11 = ___value0;
		uint64_t L_12 = L_11;
		RuntimeObject* L_13 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_12);
		*((int8_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_9, L_10))) = (int8_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_13, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		int32_t L_14 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_14, 1));
	}

IL_0052:
	{
		int32_t L_15 = V_2;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_16;
		L_16 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_15) < ((int32_t)L_16)))
		{
			goto IL_003f;
		}
	}
	{
		V_1 = (uint8_t*)((uintptr_t)0);
		return;
	}

IL_005e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_17 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_18;
		L_18 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_17, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_19 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_20;
		L_20 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_19, NULL);
		bool L_21;
		L_21 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_18, L_20, NULL);
		if (!L_21)
		{
			goto IL_00b3;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_22 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_23 = (int8_t*)(&L_22->___sbyte_0_16);
		V_4 = L_23;
		int8_t* L_24 = V_4;
		V_3 = (int8_t*)((uintptr_t)L_24);
		V_5 = 0;
		goto IL_00a5;
	}

IL_008f:
	{
		int8_t* L_25 = V_3;
		int32_t L_26 = V_5;
		uint64_t L_27 = ___value0;
		uint64_t L_28 = L_27;
		RuntimeObject* L_29 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_28);
		*((int8_t*)((int8_t*)il2cpp_codegen_add((intptr_t)L_25, L_26))) = (int8_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_29, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		int32_t L_30 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_30, 1));
	}

IL_00a5:
	{
		int32_t L_31 = V_5;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_32;
		L_32 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_31) < ((int32_t)L_32)))
		{
			goto IL_008f;
		}
	}
	{
		V_4 = (int8_t*)((uintptr_t)0);
		return;
	}

IL_00b3:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_33 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_34;
		L_34 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_33, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		bool L_37;
		L_37 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_34, L_36, NULL);
		if (!L_37)
		{
			goto IL_010d;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_38 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_39 = (uint16_t*)(&L_38->___uint16_0_32);
		V_7 = L_39;
		uint16_t* L_40 = V_7;
		V_6 = (uint16_t*)((uintptr_t)L_40);
		V_8 = 0;
		goto IL_00ff;
	}

IL_00e5:
	{
		uint16_t* L_41 = V_6;
		int32_t L_42 = V_8;
		uint64_t L_43 = ___value0;
		uint64_t L_44 = L_43;
		RuntimeObject* L_45 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_44);
		*((int16_t*)((uint16_t*)il2cpp_codegen_add((intptr_t)L_41, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_42), 2))))) = (int16_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_45, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		int32_t L_46 = V_8;
		V_8 = ((int32_t)il2cpp_codegen_add(L_46, 1));
	}

IL_00ff:
	{
		int32_t L_47 = V_8;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_48;
		L_48 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_47) < ((int32_t)L_48)))
		{
			goto IL_00e5;
		}
	}
	{
		V_7 = (uint16_t*)((uintptr_t)0);
		return;
	}

IL_010d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_49 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_50;
		L_50 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_49, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_51 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_52;
		L_52 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_51, NULL);
		bool L_53;
		L_53 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_50, L_52, NULL);
		if (!L_53)
		{
			goto IL_0167;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_54 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_55 = (int16_t*)(&L_54->___int16_0_40);
		V_10 = L_55;
		int16_t* L_56 = V_10;
		V_9 = (int16_t*)((uintptr_t)L_56);
		V_11 = 0;
		goto IL_0159;
	}

IL_013f:
	{
		int16_t* L_57 = V_9;
		int32_t L_58 = V_11;
		uint64_t L_59 = ___value0;
		uint64_t L_60 = L_59;
		RuntimeObject* L_61 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_60);
		*((int16_t*)((int16_t*)il2cpp_codegen_add((intptr_t)L_57, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_58), 2))))) = (int16_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_61, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		int32_t L_62 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_62, 1));
	}

IL_0159:
	{
		int32_t L_63 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_64;
		L_64 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_63) < ((int32_t)L_64)))
		{
			goto IL_013f;
		}
	}
	{
		V_10 = (int16_t*)((uintptr_t)0);
		return;
	}

IL_0167:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_65 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_66;
		L_66 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_65, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_67 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_68;
		L_68 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_67, NULL);
		bool L_69;
		L_69 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_66, L_68, NULL);
		if (!L_69)
		{
			goto IL_01c1;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_70 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_71 = (uint32_t*)(&L_70->___uint32_0_48);
		V_13 = L_71;
		uint32_t* L_72 = V_13;
		V_12 = (uint32_t*)((uintptr_t)L_72);
		V_14 = 0;
		goto IL_01b3;
	}

IL_0199:
	{
		uint32_t* L_73 = V_12;
		int32_t L_74 = V_14;
		uint64_t L_75 = ___value0;
		uint64_t L_76 = L_75;
		RuntimeObject* L_77 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_76);
		*((int32_t*)((uint32_t*)il2cpp_codegen_add((intptr_t)L_73, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_74), 4))))) = (int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_77, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		int32_t L_78 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_add(L_78, 1));
	}

IL_01b3:
	{
		int32_t L_79 = V_14;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_80;
		L_80 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_79) < ((int32_t)L_80)))
		{
			goto IL_0199;
		}
	}
	{
		V_13 = (uint32_t*)((uintptr_t)0);
		return;
	}

IL_01c1:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_81 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_82;
		L_82 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_81, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_83 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_84;
		L_84 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_83, NULL);
		bool L_85;
		L_85 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_82, L_84, NULL);
		if (!L_85)
		{
			goto IL_021b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_86 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_87 = (int32_t*)(&L_86->___int32_0_52);
		V_16 = L_87;
		int32_t* L_88 = V_16;
		V_15 = (int32_t*)((uintptr_t)L_88);
		V_17 = 0;
		goto IL_020d;
	}

IL_01f3:
	{
		int32_t* L_89 = V_15;
		int32_t L_90 = V_17;
		uint64_t L_91 = ___value0;
		uint64_t L_92 = L_91;
		RuntimeObject* L_93 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_92);
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_93, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		int32_t L_94 = V_17;
		V_17 = ((int32_t)il2cpp_codegen_add(L_94, 1));
	}

IL_020d:
	{
		int32_t L_95 = V_17;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_96;
		L_96 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_95) < ((int32_t)L_96)))
		{
			goto IL_01f3;
		}
	}
	{
		V_16 = (int32_t*)((uintptr_t)0);
		return;
	}

IL_021b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_97 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_98;
		L_98 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_97, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_99 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_100;
		L_100 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_99, NULL);
		bool L_101;
		L_101 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_98, L_100, NULL);
		if (!L_101)
		{
			goto IL_0275;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_102 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_103 = (uint64_t*)(&L_102->___uint64_0_56);
		V_19 = L_103;
		uint64_t* L_104 = V_19;
		V_18 = (uint64_t*)((uintptr_t)L_104);
		V_20 = 0;
		goto IL_0267;
	}

IL_024d:
	{
		uint64_t* L_105 = V_18;
		int32_t L_106 = V_20;
		uint64_t L_107 = ___value0;
		uint64_t L_108 = L_107;
		RuntimeObject* L_109 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_108);
		*((int64_t*)((uint64_t*)il2cpp_codegen_add((intptr_t)L_105, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_106), 8))))) = (int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_109, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		int32_t L_110 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_110, 1));
	}

IL_0267:
	{
		int32_t L_111 = V_20;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_112;
		L_112 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_111) < ((int32_t)L_112)))
		{
			goto IL_024d;
		}
	}
	{
		V_19 = (uint64_t*)((uintptr_t)0);
		return;
	}

IL_0275:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_113 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_114;
		L_114 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_113, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_115 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_116;
		L_116 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_115, NULL);
		bool L_117;
		L_117 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_114, L_116, NULL);
		if (!L_117)
		{
			goto IL_02cf;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_118 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_119 = (int64_t*)(&L_118->___int64_0_58);
		V_22 = L_119;
		int64_t* L_120 = V_22;
		V_21 = (int64_t*)((uintptr_t)L_120);
		V_23 = 0;
		goto IL_02c1;
	}

IL_02a7:
	{
		int64_t* L_121 = V_21;
		int32_t L_122 = V_23;
		uint64_t L_123 = ___value0;
		uint64_t L_124 = L_123;
		RuntimeObject* L_125 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_124);
		*((int64_t*)((int64_t*)il2cpp_codegen_add((intptr_t)L_121, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_122), 8))))) = (int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_125, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		int32_t L_126 = V_23;
		V_23 = ((int32_t)il2cpp_codegen_add(L_126, 1));
	}

IL_02c1:
	{
		int32_t L_127 = V_23;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_128;
		L_128 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_127) < ((int32_t)L_128)))
		{
			goto IL_02a7;
		}
	}
	{
		V_22 = (int64_t*)((uintptr_t)0);
		return;
	}

IL_02cf:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_129 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_130;
		L_130 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_129, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_131 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_132;
		L_132 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_131, NULL);
		bool L_133;
		L_133 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_130, L_132, NULL);
		if (!L_133)
		{
			goto IL_0329;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_134 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_135 = (float*)(&L_134->___single_0_60);
		V_25 = L_135;
		float* L_136 = V_25;
		V_24 = (float*)((uintptr_t)L_136);
		V_26 = 0;
		goto IL_031b;
	}

IL_0301:
	{
		float* L_137 = V_24;
		int32_t L_138 = V_26;
		uint64_t L_139 = ___value0;
		uint64_t L_140 = L_139;
		RuntimeObject* L_141 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_140);
		*((float*)((float*)il2cpp_codegen_add((intptr_t)L_137, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_138), 4))))) = (float)((*(float*)((float*)(float*)UnBox(L_141, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		int32_t L_142 = V_26;
		V_26 = ((int32_t)il2cpp_codegen_add(L_142, 1));
	}

IL_031b:
	{
		int32_t L_143 = V_26;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_144;
		L_144 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_143) < ((int32_t)L_144)))
		{
			goto IL_0301;
		}
	}
	{
		V_25 = (float*)((uintptr_t)0);
		return;
	}

IL_0329:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_145 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_146;
		L_146 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_145, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_147 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_148;
		L_148 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_147, NULL);
		bool L_149;
		L_149 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_146, L_148, NULL);
		if (!L_149)
		{
			goto IL_0a55;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_150 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_151 = (double*)(&L_150->___double_0_64);
		V_28 = L_151;
		double* L_152 = V_28;
		V_27 = (double*)((uintptr_t)L_152);
		V_29 = 0;
		goto IL_0378;
	}

IL_035e:
	{
		double* L_153 = V_27;
		int32_t L_154 = V_29;
		uint64_t L_155 = ___value0;
		uint64_t L_156 = L_155;
		RuntimeObject* L_157 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_156);
		*((double*)((double*)il2cpp_codegen_add((intptr_t)L_153, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_154), 8))))) = (double)((*(double*)((double*)(double*)UnBox(L_157, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
		int32_t L_158 = V_29;
		V_29 = ((int32_t)il2cpp_codegen_add(L_158, 1));
	}

IL_0378:
	{
		int32_t L_159 = V_29;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_160;
		L_160 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_159) < ((int32_t)L_160)))
		{
			goto IL_035e;
		}
	}
	{
		V_28 = (double*)((uintptr_t)0);
		return;
	}

IL_0386:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_161 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_162;
		L_162 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_161, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_163 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_164;
		L_164 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_163, NULL);
		bool L_165;
		L_165 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_162, L_164, NULL);
		if (!L_165)
		{
			goto IL_0505;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_166 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_167 = ___value0;
		uint64_t L_168 = L_167;
		RuntimeObject* L_169 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_168);
		L_166->___byte_0_0 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_169, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_170 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_171 = ___value0;
		uint64_t L_172 = L_171;
		RuntimeObject* L_173 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_172);
		L_170->___byte_1_1 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_173, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_174 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_175 = ___value0;
		uint64_t L_176 = L_175;
		RuntimeObject* L_177 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_176);
		L_174->___byte_2_2 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_177, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_178 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_179 = ___value0;
		uint64_t L_180 = L_179;
		RuntimeObject* L_181 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_180);
		L_178->___byte_3_3 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_181, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_182 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_183 = ___value0;
		uint64_t L_184 = L_183;
		RuntimeObject* L_185 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_184);
		L_182->___byte_4_4 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_185, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_186 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_187 = ___value0;
		uint64_t L_188 = L_187;
		RuntimeObject* L_189 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_188);
		L_186->___byte_5_5 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_189, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_190 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_191 = ___value0;
		uint64_t L_192 = L_191;
		RuntimeObject* L_193 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_192);
		L_190->___byte_6_6 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_193, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_194 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_195 = ___value0;
		uint64_t L_196 = L_195;
		RuntimeObject* L_197 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_196);
		L_194->___byte_7_7 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_197, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_198 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_199 = ___value0;
		uint64_t L_200 = L_199;
		RuntimeObject* L_201 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_200);
		L_198->___byte_8_8 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_201, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_202 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_203 = ___value0;
		uint64_t L_204 = L_203;
		RuntimeObject* L_205 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_204);
		L_202->___byte_9_9 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_205, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_206 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_207 = ___value0;
		uint64_t L_208 = L_207;
		RuntimeObject* L_209 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_208);
		L_206->___byte_10_10 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_209, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_210 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_211 = ___value0;
		uint64_t L_212 = L_211;
		RuntimeObject* L_213 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_212);
		L_210->___byte_11_11 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_213, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_214 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_215 = ___value0;
		uint64_t L_216 = L_215;
		RuntimeObject* L_217 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_216);
		L_214->___byte_12_12 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_217, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_218 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_219 = ___value0;
		uint64_t L_220 = L_219;
		RuntimeObject* L_221 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_220);
		L_218->___byte_13_13 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_221, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_222 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_223 = ___value0;
		uint64_t L_224 = L_223;
		RuntimeObject* L_225 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_224);
		L_222->___byte_14_14 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_225, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_226 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_227 = ___value0;
		uint64_t L_228 = L_227;
		RuntimeObject* L_229 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_228);
		L_226->___byte_15_15 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_229, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		return;
	}

IL_0505:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_230 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_231;
		L_231 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_230, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_232 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_233;
		L_233 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_232, NULL);
		bool L_234;
		L_234 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_231, L_233, NULL);
		if (!L_234)
		{
			goto IL_0684;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_235 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_236 = ___value0;
		uint64_t L_237 = L_236;
		RuntimeObject* L_238 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_237);
		L_235->___sbyte_0_16 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_238, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_239 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_240 = ___value0;
		uint64_t L_241 = L_240;
		RuntimeObject* L_242 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_241);
		L_239->___sbyte_1_17 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_242, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_243 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_244 = ___value0;
		uint64_t L_245 = L_244;
		RuntimeObject* L_246 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_245);
		L_243->___sbyte_2_18 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_246, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_247 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_248 = ___value0;
		uint64_t L_249 = L_248;
		RuntimeObject* L_250 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_249);
		L_247->___sbyte_3_19 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_250, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_251 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_252 = ___value0;
		uint64_t L_253 = L_252;
		RuntimeObject* L_254 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_253);
		L_251->___sbyte_4_20 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_254, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_255 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_256 = ___value0;
		uint64_t L_257 = L_256;
		RuntimeObject* L_258 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_257);
		L_255->___sbyte_5_21 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_258, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_259 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_260 = ___value0;
		uint64_t L_261 = L_260;
		RuntimeObject* L_262 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_261);
		L_259->___sbyte_6_22 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_262, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_263 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_264 = ___value0;
		uint64_t L_265 = L_264;
		RuntimeObject* L_266 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_265);
		L_263->___sbyte_7_23 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_266, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_267 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_268 = ___value0;
		uint64_t L_269 = L_268;
		RuntimeObject* L_270 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_269);
		L_267->___sbyte_8_24 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_270, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_271 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_272 = ___value0;
		uint64_t L_273 = L_272;
		RuntimeObject* L_274 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_273);
		L_271->___sbyte_9_25 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_274, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_275 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_276 = ___value0;
		uint64_t L_277 = L_276;
		RuntimeObject* L_278 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_277);
		L_275->___sbyte_10_26 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_278, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_279 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_280 = ___value0;
		uint64_t L_281 = L_280;
		RuntimeObject* L_282 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_281);
		L_279->___sbyte_11_27 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_282, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_283 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_284 = ___value0;
		uint64_t L_285 = L_284;
		RuntimeObject* L_286 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_285);
		L_283->___sbyte_12_28 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_286, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_287 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_288 = ___value0;
		uint64_t L_289 = L_288;
		RuntimeObject* L_290 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_289);
		L_287->___sbyte_13_29 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_290, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_291 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_292 = ___value0;
		uint64_t L_293 = L_292;
		RuntimeObject* L_294 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_293);
		L_291->___sbyte_14_30 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_294, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_295 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_296 = ___value0;
		uint64_t L_297 = L_296;
		RuntimeObject* L_298 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_297);
		L_295->___sbyte_15_31 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_298, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		return;
	}

IL_0684:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_299 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_300;
		L_300 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_299, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_301 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_302;
		L_302 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_301, NULL);
		bool L_303;
		L_303 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_300, L_302, NULL);
		if (!L_303)
		{
			goto IL_0753;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_304 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_305 = ___value0;
		uint64_t L_306 = L_305;
		RuntimeObject* L_307 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_306);
		L_304->___uint16_0_32 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_307, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_308 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_309 = ___value0;
		uint64_t L_310 = L_309;
		RuntimeObject* L_311 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_310);
		L_308->___uint16_1_33 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_311, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_312 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_313 = ___value0;
		uint64_t L_314 = L_313;
		RuntimeObject* L_315 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_314);
		L_312->___uint16_2_34 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_315, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_316 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_317 = ___value0;
		uint64_t L_318 = L_317;
		RuntimeObject* L_319 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_318);
		L_316->___uint16_3_35 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_319, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_320 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_321 = ___value0;
		uint64_t L_322 = L_321;
		RuntimeObject* L_323 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_322);
		L_320->___uint16_4_36 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_323, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_324 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_325 = ___value0;
		uint64_t L_326 = L_325;
		RuntimeObject* L_327 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_326);
		L_324->___uint16_5_37 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_327, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_328 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_329 = ___value0;
		uint64_t L_330 = L_329;
		RuntimeObject* L_331 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_330);
		L_328->___uint16_6_38 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_331, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_332 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_333 = ___value0;
		uint64_t L_334 = L_333;
		RuntimeObject* L_335 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_334);
		L_332->___uint16_7_39 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_335, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		return;
	}

IL_0753:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_336 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_337;
		L_337 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_336, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_338 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_339;
		L_339 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_338, NULL);
		bool L_340;
		L_340 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_337, L_339, NULL);
		if (!L_340)
		{
			goto IL_0822;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_341 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_342 = ___value0;
		uint64_t L_343 = L_342;
		RuntimeObject* L_344 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_343);
		L_341->___int16_0_40 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_344, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_345 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_346 = ___value0;
		uint64_t L_347 = L_346;
		RuntimeObject* L_348 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_347);
		L_345->___int16_1_41 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_348, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_349 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_350 = ___value0;
		uint64_t L_351 = L_350;
		RuntimeObject* L_352 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_351);
		L_349->___int16_2_42 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_352, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_353 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_354 = ___value0;
		uint64_t L_355 = L_354;
		RuntimeObject* L_356 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_355);
		L_353->___int16_3_43 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_356, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_357 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_358 = ___value0;
		uint64_t L_359 = L_358;
		RuntimeObject* L_360 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_359);
		L_357->___int16_4_44 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_360, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_361 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_362 = ___value0;
		uint64_t L_363 = L_362;
		RuntimeObject* L_364 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_363);
		L_361->___int16_5_45 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_364, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_365 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_366 = ___value0;
		uint64_t L_367 = L_366;
		RuntimeObject* L_368 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_367);
		L_365->___int16_6_46 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_368, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_369 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_370 = ___value0;
		uint64_t L_371 = L_370;
		RuntimeObject* L_372 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_371);
		L_369->___int16_7_47 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_372, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		return;
	}

IL_0822:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_373 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_374;
		L_374 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_373, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_375 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_376;
		L_376 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_375, NULL);
		bool L_377;
		L_377 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_374, L_376, NULL);
		if (!L_377)
		{
			goto IL_0896;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_378 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_379 = ___value0;
		uint64_t L_380 = L_379;
		RuntimeObject* L_381 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_380);
		L_378->___uint32_0_48 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_381, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_382 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_383 = ___value0;
		uint64_t L_384 = L_383;
		RuntimeObject* L_385 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_384);
		L_382->___uint32_1_49 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_385, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_386 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_387 = ___value0;
		uint64_t L_388 = L_387;
		RuntimeObject* L_389 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_388);
		L_386->___uint32_2_50 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_389, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_390 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_391 = ___value0;
		uint64_t L_392 = L_391;
		RuntimeObject* L_393 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_392);
		L_390->___uint32_3_51 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_393, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		return;
	}

IL_0896:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_394 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_395;
		L_395 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_394, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_396 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_397;
		L_397 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_396, NULL);
		bool L_398;
		L_398 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_395, L_397, NULL);
		if (!L_398)
		{
			goto IL_090a;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_399 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_400 = ___value0;
		uint64_t L_401 = L_400;
		RuntimeObject* L_402 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_401);
		L_399->___int32_0_52 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_402, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_403 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_404 = ___value0;
		uint64_t L_405 = L_404;
		RuntimeObject* L_406 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_405);
		L_403->___int32_1_53 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_406, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_407 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_408 = ___value0;
		uint64_t L_409 = L_408;
		RuntimeObject* L_410 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_409);
		L_407->___int32_2_54 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_410, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_411 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_412 = ___value0;
		uint64_t L_413 = L_412;
		RuntimeObject* L_414 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_413);
		L_411->___int32_3_55 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_414, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		return;
	}

IL_090a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_415 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_416;
		L_416 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_415, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_417 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_418;
		L_418 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_417, NULL);
		bool L_419;
		L_419 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_416, L_418, NULL);
		if (!L_419)
		{
			goto IL_0952;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_420 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_421 = ___value0;
		uint64_t L_422 = L_421;
		RuntimeObject* L_423 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_422);
		L_420->___uint64_0_56 = ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_423, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_424 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_425 = ___value0;
		uint64_t L_426 = L_425;
		RuntimeObject* L_427 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_426);
		L_424->___uint64_1_57 = ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_427, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		return;
	}

IL_0952:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_428 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_429;
		L_429 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_428, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_430 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_431;
		L_431 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_430, NULL);
		bool L_432;
		L_432 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_429, L_431, NULL);
		if (!L_432)
		{
			goto IL_099a;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_433 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_434 = ___value0;
		uint64_t L_435 = L_434;
		RuntimeObject* L_436 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_435);
		L_433->___int64_0_58 = ((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_436, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_437 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_438 = ___value0;
		uint64_t L_439 = L_438;
		RuntimeObject* L_440 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_439);
		L_437->___int64_1_59 = ((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_440, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		return;
	}

IL_099a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_441 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_442;
		L_442 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_441, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_443 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_444;
		L_444 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_443, NULL);
		bool L_445;
		L_445 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_442, L_444, NULL);
		if (!L_445)
		{
			goto IL_0a0e;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_446 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_447 = ___value0;
		uint64_t L_448 = L_447;
		RuntimeObject* L_449 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_448);
		L_446->___single_0_60 = ((*(float*)((float*)(float*)UnBox(L_449, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_450 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_451 = ___value0;
		uint64_t L_452 = L_451;
		RuntimeObject* L_453 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_452);
		L_450->___single_1_61 = ((*(float*)((float*)(float*)UnBox(L_453, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_454 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_455 = ___value0;
		uint64_t L_456 = L_455;
		RuntimeObject* L_457 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_456);
		L_454->___single_2_62 = ((*(float*)((float*)(float*)UnBox(L_457, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_458 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_459 = ___value0;
		uint64_t L_460 = L_459;
		RuntimeObject* L_461 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_460);
		L_458->___single_3_63 = ((*(float*)((float*)(float*)UnBox(L_461, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		return;
	}

IL_0a0e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_462 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_463;
		L_463 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_462, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_464 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_465;
		L_465 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_464, NULL);
		bool L_466;
		L_466 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_463, L_465, NULL);
		if (!L_466)
		{
			goto IL_0a55;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_467 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_468 = ___value0;
		uint64_t L_469 = L_468;
		RuntimeObject* L_470 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_469);
		L_467->___double_0_64 = ((*(double*)((double*)(double*)UnBox(L_470, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_471 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_472 = ___value0;
		uint64_t L_473 = L_472;
		RuntimeObject* L_474 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_473);
		L_471->___double_1_65 = ((*(double*)((double*)(double*)UnBox(L_474, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
	}

IL_0a55:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6_AdjustorThunk (RuntimeObject* __this, uint64_t ___value0, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, void* ___dataPointer0, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___dataPointer0;
		Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B(__this, L_0, 0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		return;
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA_AdjustorThunk (RuntimeObject* __this, void* ___dataPointer0, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA(_thisAdjusted, ___dataPointer0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	uint8_t* V_0 = NULL;
	uint8_t* V_1 = NULL;
	uint8_t* V_2 = NULL;
	int32_t V_3 = 0;
	int8_t* V_4 = NULL;
	int8_t* V_5 = NULL;
	int8_t* V_6 = NULL;
	int32_t V_7 = 0;
	uint16_t* V_8 = NULL;
	uint16_t* V_9 = NULL;
	uint16_t* V_10 = NULL;
	int32_t V_11 = 0;
	int16_t* V_12 = NULL;
	int16_t* V_13 = NULL;
	int16_t* V_14 = NULL;
	int32_t V_15 = 0;
	uint32_t* V_16 = NULL;
	uint32_t* V_17 = NULL;
	uint32_t* V_18 = NULL;
	int32_t V_19 = 0;
	int32_t* V_20 = NULL;
	int32_t* V_21 = NULL;
	int32_t* V_22 = NULL;
	int32_t V_23 = 0;
	uint64_t* V_24 = NULL;
	uint64_t* V_25 = NULL;
	uint64_t* V_26 = NULL;
	int32_t V_27 = 0;
	int64_t* V_28 = NULL;
	int64_t* V_29 = NULL;
	int64_t* V_30 = NULL;
	int32_t V_31 = 0;
	float* V_32 = NULL;
	float* V_33 = NULL;
	float* V_34 = NULL;
	int32_t V_35 = 0;
	double* V_36 = NULL;
	double* V_37 = NULL;
	double* V_38 = NULL;
	int32_t V_39 = 0;
	{
		il2cpp_codegen_initobj(__this, sizeof(Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A));
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0053;
		}
	}
	{
		void* L_5 = ___dataPointer0;
		V_0 = (uint8_t*)L_5;
		uint8_t* L_6 = V_0;
		int32_t L_7 = ___offset1;
		V_0 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_6, L_7));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_8 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_9 = (uint8_t*)(&L_8->___byte_0_0);
		V_2 = L_9;
		uint8_t* L_10 = V_2;
		V_1 = (uint8_t*)((uintptr_t)L_10);
		V_3 = 0;
		goto IL_0047;
	}

IL_003b:
	{
		uint8_t* L_11 = V_1;
		int32_t L_12 = V_3;
		uint8_t* L_13 = V_0;
		int32_t L_14 = V_3;
		int32_t L_15 = *((uint8_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_13, L_14)));
		*((int8_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_11, L_12))) = (int8_t)L_15;
		int32_t L_16 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_16, 1));
	}

IL_0047:
	{
		int32_t L_17 = V_3;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_18;
		L_18 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_17) < ((int32_t)L_18)))
		{
			goto IL_003b;
		}
	}
	{
		V_2 = (uint8_t*)((uintptr_t)0);
		return;
	}

IL_0053:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_19 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_20;
		L_20 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_19, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_21 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_22;
		L_22 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_21, NULL);
		bool L_23;
		L_23 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_20, L_22, NULL);
		if (!L_23)
		{
			goto IL_00ae;
		}
	}
	{
		void* L_24 = ___dataPointer0;
		V_4 = (int8_t*)L_24;
		int8_t* L_25 = V_4;
		int32_t L_26 = ___offset1;
		V_4 = ((int8_t*)il2cpp_codegen_add((intptr_t)L_25, L_26));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_27 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_28 = (int8_t*)(&L_27->___sbyte_0_16);
		V_6 = L_28;
		int8_t* L_29 = V_6;
		V_5 = (int8_t*)((uintptr_t)L_29);
		V_7 = 0;
		goto IL_00a0;
	}

IL_008e:
	{
		int8_t* L_30 = V_5;
		int32_t L_31 = V_7;
		int8_t* L_32 = V_4;
		int32_t L_33 = V_7;
		int32_t L_34 = *((int8_t*)((int8_t*)il2cpp_codegen_add((intptr_t)L_32, L_33)));
		*((int8_t*)((int8_t*)il2cpp_codegen_add((intptr_t)L_30, L_31))) = (int8_t)L_34;
		int32_t L_35 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00a0:
	{
		int32_t L_36 = V_7;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_37;
		L_37 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_36) < ((int32_t)L_37)))
		{
			goto IL_008e;
		}
	}
	{
		V_6 = (int8_t*)((uintptr_t)0);
		return;
	}

IL_00ae:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_38 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_39;
		L_39 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_38, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_40 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_41;
		L_41 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_40, NULL);
		bool L_42;
		L_42 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_39, L_41, NULL);
		if (!L_42)
		{
			goto IL_0112;
		}
	}
	{
		void* L_43 = ___dataPointer0;
		V_8 = (uint16_t*)L_43;
		uint16_t* L_44 = V_8;
		int32_t L_45 = ___offset1;
		V_8 = ((uint16_t*)il2cpp_codegen_add((intptr_t)L_44, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_45), 2))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_46 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_47 = (uint16_t*)(&L_46->___uint16_0_32);
		V_10 = L_47;
		uint16_t* L_48 = V_10;
		V_9 = (uint16_t*)((uintptr_t)L_48);
		V_11 = 0;
		goto IL_0104;
	}

IL_00ec:
	{
		uint16_t* L_49 = V_9;
		int32_t L_50 = V_11;
		uint16_t* L_51 = V_8;
		int32_t L_52 = V_11;
		int32_t L_53 = *((uint16_t*)((uint16_t*)il2cpp_codegen_add((intptr_t)L_51, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_52), 2)))));
		*((int16_t*)((uint16_t*)il2cpp_codegen_add((intptr_t)L_49, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_50), 2))))) = (int16_t)L_53;
		int32_t L_54 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_54, 1));
	}

IL_0104:
	{
		int32_t L_55 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_56;
		L_56 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_55) < ((int32_t)L_56)))
		{
			goto IL_00ec;
		}
	}
	{
		V_10 = (uint16_t*)((uintptr_t)0);
		return;
	}

IL_0112:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_57 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_58;
		L_58 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_57, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_59 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_60;
		L_60 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_59, NULL);
		bool L_61;
		L_61 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_58, L_60, NULL);
		if (!L_61)
		{
			goto IL_0176;
		}
	}
	{
		void* L_62 = ___dataPointer0;
		V_12 = (int16_t*)L_62;
		int16_t* L_63 = V_12;
		int32_t L_64 = ___offset1;
		V_12 = ((int16_t*)il2cpp_codegen_add((intptr_t)L_63, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_64), 2))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_65 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_66 = (int16_t*)(&L_65->___int16_0_40);
		V_14 = L_66;
		int16_t* L_67 = V_14;
		V_13 = (int16_t*)((uintptr_t)L_67);
		V_15 = 0;
		goto IL_0168;
	}

IL_0150:
	{
		int16_t* L_68 = V_13;
		int32_t L_69 = V_15;
		int16_t* L_70 = V_12;
		int32_t L_71 = V_15;
		int32_t L_72 = *((int16_t*)((int16_t*)il2cpp_codegen_add((intptr_t)L_70, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_71), 2)))));
		*((int16_t*)((int16_t*)il2cpp_codegen_add((intptr_t)L_68, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_69), 2))))) = (int16_t)L_72;
		int32_t L_73 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_add(L_73, 1));
	}

IL_0168:
	{
		int32_t L_74 = V_15;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_75;
		L_75 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_74) < ((int32_t)L_75)))
		{
			goto IL_0150;
		}
	}
	{
		V_14 = (int16_t*)((uintptr_t)0);
		return;
	}

IL_0176:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_76 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_77;
		L_77 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_76, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_78 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_79;
		L_79 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_78, NULL);
		bool L_80;
		L_80 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_77, L_79, NULL);
		if (!L_80)
		{
			goto IL_01da;
		}
	}
	{
		void* L_81 = ___dataPointer0;
		V_16 = (uint32_t*)L_81;
		uint32_t* L_82 = V_16;
		int32_t L_83 = ___offset1;
		V_16 = ((uint32_t*)il2cpp_codegen_add((intptr_t)L_82, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_83), 4))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_84 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_85 = (uint32_t*)(&L_84->___uint32_0_48);
		V_18 = L_85;
		uint32_t* L_86 = V_18;
		V_17 = (uint32_t*)((uintptr_t)L_86);
		V_19 = 0;
		goto IL_01cc;
	}

IL_01b4:
	{
		uint32_t* L_87 = V_17;
		int32_t L_88 = V_19;
		uint32_t* L_89 = V_16;
		int32_t L_90 = V_19;
		int32_t L_91 = *((uint32_t*)((uint32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4)))));
		*((int32_t*)((uint32_t*)il2cpp_codegen_add((intptr_t)L_87, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_88), 4))))) = (int32_t)L_91;
		int32_t L_92 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_92, 1));
	}

IL_01cc:
	{
		int32_t L_93 = V_19;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_94;
		L_94 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_93) < ((int32_t)L_94)))
		{
			goto IL_01b4;
		}
	}
	{
		V_18 = (uint32_t*)((uintptr_t)0);
		return;
	}

IL_01da:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_95 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_96;
		L_96 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_95, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_97 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_98;
		L_98 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_97, NULL);
		bool L_99;
		L_99 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_96, L_98, NULL);
		if (!L_99)
		{
			goto IL_023e;
		}
	}
	{
		void* L_100 = ___dataPointer0;
		V_20 = (int32_t*)L_100;
		int32_t* L_101 = V_20;
		int32_t L_102 = ___offset1;
		V_20 = ((int32_t*)il2cpp_codegen_add((intptr_t)L_101, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_102), 4))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_103 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_104 = (int32_t*)(&L_103->___int32_0_52);
		V_22 = L_104;
		int32_t* L_105 = V_22;
		V_21 = (int32_t*)((uintptr_t)L_105);
		V_23 = 0;
		goto IL_0230;
	}

IL_0218:
	{
		int32_t* L_106 = V_21;
		int32_t L_107 = V_23;
		int32_t* L_108 = V_20;
		int32_t L_109 = V_23;
		int32_t L_110 = *((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_108, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_109), 4)))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_106, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_107), 4))))) = (int32_t)L_110;
		int32_t L_111 = V_23;
		V_23 = ((int32_t)il2cpp_codegen_add(L_111, 1));
	}

IL_0230:
	{
		int32_t L_112 = V_23;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_113;
		L_113 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_112) < ((int32_t)L_113)))
		{
			goto IL_0218;
		}
	}
	{
		V_22 = (int32_t*)((uintptr_t)0);
		return;
	}

IL_023e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_114 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_115;
		L_115 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_114, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_116 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_117;
		L_117 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_116, NULL);
		bool L_118;
		L_118 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_115, L_117, NULL);
		if (!L_118)
		{
			goto IL_02a2;
		}
	}
	{
		void* L_119 = ___dataPointer0;
		V_24 = (uint64_t*)L_119;
		uint64_t* L_120 = V_24;
		int32_t L_121 = ___offset1;
		V_24 = ((uint64_t*)il2cpp_codegen_add((intptr_t)L_120, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_121), 8))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_122 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_123 = (uint64_t*)(&L_122->___uint64_0_56);
		V_26 = L_123;
		uint64_t* L_124 = V_26;
		V_25 = (uint64_t*)((uintptr_t)L_124);
		V_27 = 0;
		goto IL_0294;
	}

IL_027c:
	{
		uint64_t* L_125 = V_25;
		int32_t L_126 = V_27;
		uint64_t* L_127 = V_24;
		int32_t L_128 = V_27;
		int64_t L_129 = *((int64_t*)((uint64_t*)il2cpp_codegen_add((intptr_t)L_127, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_128), 8)))));
		*((int64_t*)((uint64_t*)il2cpp_codegen_add((intptr_t)L_125, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_126), 8))))) = (int64_t)L_129;
		int32_t L_130 = V_27;
		V_27 = ((int32_t)il2cpp_codegen_add(L_130, 1));
	}

IL_0294:
	{
		int32_t L_131 = V_27;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_132;
		L_132 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_131) < ((int32_t)L_132)))
		{
			goto IL_027c;
		}
	}
	{
		V_26 = (uint64_t*)((uintptr_t)0);
		return;
	}

IL_02a2:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_133 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_134;
		L_134 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_133, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_135 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_136;
		L_136 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_135, NULL);
		bool L_137;
		L_137 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_134, L_136, NULL);
		if (!L_137)
		{
			goto IL_0306;
		}
	}
	{
		void* L_138 = ___dataPointer0;
		V_28 = (int64_t*)L_138;
		int64_t* L_139 = V_28;
		int32_t L_140 = ___offset1;
		V_28 = ((int64_t*)il2cpp_codegen_add((intptr_t)L_139, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_140), 8))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_141 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_142 = (int64_t*)(&L_141->___int64_0_58);
		V_30 = L_142;
		int64_t* L_143 = V_30;
		V_29 = (int64_t*)((uintptr_t)L_143);
		V_31 = 0;
		goto IL_02f8;
	}

IL_02e0:
	{
		int64_t* L_144 = V_29;
		int32_t L_145 = V_31;
		int64_t* L_146 = V_28;
		int32_t L_147 = V_31;
		int64_t L_148 = *((int64_t*)((int64_t*)il2cpp_codegen_add((intptr_t)L_146, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_147), 8)))));
		*((int64_t*)((int64_t*)il2cpp_codegen_add((intptr_t)L_144, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_145), 8))))) = (int64_t)L_148;
		int32_t L_149 = V_31;
		V_31 = ((int32_t)il2cpp_codegen_add(L_149, 1));
	}

IL_02f8:
	{
		int32_t L_150 = V_31;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_151;
		L_151 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_150) < ((int32_t)L_151)))
		{
			goto IL_02e0;
		}
	}
	{
		V_30 = (int64_t*)((uintptr_t)0);
		return;
	}

IL_0306:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_152 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_153;
		L_153 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_152, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_154 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_155;
		L_155 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_154, NULL);
		bool L_156;
		L_156 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_153, L_155, NULL);
		if (!L_156)
		{
			goto IL_036a;
		}
	}
	{
		void* L_157 = ___dataPointer0;
		V_32 = (float*)L_157;
		float* L_158 = V_32;
		int32_t L_159 = ___offset1;
		V_32 = ((float*)il2cpp_codegen_add((intptr_t)L_158, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_159), 4))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_160 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_161 = (float*)(&L_160->___single_0_60);
		V_34 = L_161;
		float* L_162 = V_34;
		V_33 = (float*)((uintptr_t)L_162);
		V_35 = 0;
		goto IL_035c;
	}

IL_0344:
	{
		float* L_163 = V_33;
		int32_t L_164 = V_35;
		float* L_165 = V_32;
		int32_t L_166 = V_35;
		float L_167 = *((float*)((float*)il2cpp_codegen_add((intptr_t)L_165, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_166), 4)))));
		*((float*)((float*)il2cpp_codegen_add((intptr_t)L_163, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_164), 4))))) = (float)L_167;
		int32_t L_168 = V_35;
		V_35 = ((int32_t)il2cpp_codegen_add(L_168, 1));
	}

IL_035c:
	{
		int32_t L_169 = V_35;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_170;
		L_170 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_169) < ((int32_t)L_170)))
		{
			goto IL_0344;
		}
	}
	{
		V_34 = (float*)((uintptr_t)0);
		return;
	}

IL_036a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_171 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_172;
		L_172 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_171, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_173 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_174;
		L_174 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_173, NULL);
		bool L_175;
		L_175 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_172, L_174, NULL);
		if (!L_175)
		{
			goto IL_03ce;
		}
	}
	{
		void* L_176 = ___dataPointer0;
		V_36 = (double*)L_176;
		double* L_177 = V_36;
		int32_t L_178 = ___offset1;
		V_36 = ((double*)il2cpp_codegen_add((intptr_t)L_177, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_178), 8))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_179 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_180 = (double*)(&L_179->___double_0_64);
		V_38 = L_180;
		double* L_181 = V_38;
		V_37 = (double*)((uintptr_t)L_181);
		V_39 = 0;
		goto IL_03c0;
	}

IL_03a8:
	{
		double* L_182 = V_37;
		int32_t L_183 = V_39;
		double* L_184 = V_36;
		int32_t L_185 = V_39;
		double L_186 = *((double*)((double*)il2cpp_codegen_add((intptr_t)L_184, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_185), 8)))));
		*((double*)((double*)il2cpp_codegen_add((intptr_t)L_182, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_183), 8))))) = (double)L_186;
		int32_t L_187 = V_39;
		V_39 = ((int32_t)il2cpp_codegen_add(L_187, 1));
	}

IL_03c0:
	{
		int32_t L_188 = V_39;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_189;
		L_189 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_188) < ((int32_t)L_189)))
		{
			goto IL_03a8;
		}
	}
	{
		V_38 = (double*)((uintptr_t)0);
		return;
	}

IL_03ce:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_190 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_190);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_190, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_190, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B_AdjustorThunk (RuntimeObject* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	Vector_1__ctor_mB3EB022FA5067096F41350560FA447FBA16BFF2B(_thisAdjusted, ___dataPointer0, ___offset1, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method) 
{
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_0 = ___existingRegister0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_1 = (*(Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)L_0);
		__this->___register_0 = L_1;
		return;
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_AdjustorThunk (RuntimeObject* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606(_thisAdjusted, ___existingRegister0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, int32_t ___index0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint8_t* V_0 = NULL;
	int8_t* V_1 = NULL;
	uint16_t* V_2 = NULL;
	int16_t* V_3 = NULL;
	uint32_t* V_4 = NULL;
	int32_t* V_5 = NULL;
	uint64_t* V_6 = NULL;
	int64_t* V_7 = NULL;
	float* V_8 = NULL;
	double* V_9 = NULL;
	{
		int32_t L_0 = ___index0;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_1;
		L_1 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_0) >= ((int32_t)L_1)))
		{
			goto IL_000c;
		}
	}
	{
		int32_t L_2 = ___index0;
		if ((((int32_t)L_2) >= ((int32_t)0)))
		{
			goto IL_0022;
		}
	}

IL_000c:
	{
		int32_t L_3 = ___index0;
		int32_t L_4 = L_3;
		RuntimeObject* L_5 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var)), &L_4);
		String_t* L_6;
		L_6 = SR_Format_mB99C6F1BE061EA1427A45176E0CAFB2A2C76D03F(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral491788442E76F5D7830F0DBFCF8EDD98854F636F)), L_5, NULL);
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_7 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		NullCheck(L_7);
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_7, L_6, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99_RuntimeMethod_var)));
	}

IL_0022:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_8 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_9;
		L_9 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_8, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		bool L_12;
		L_12 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_9, L_11, NULL);
		if (!L_12)
		{
			goto IL_0059;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_13 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_14 = (uint8_t*)(&L_13->___byte_0_0);
		V_0 = L_14;
		uint8_t* L_15 = V_0;
		int32_t L_16 = ___index0;
		int32_t L_17 = *((uint8_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_15), L_16)));
		uint8_t L_18 = ((uint8_t)L_17);
		RuntimeObject* L_19 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_18);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_19, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0059:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_20 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_21;
		L_21 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_20, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_22 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_23;
		L_23 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_22, NULL);
		bool L_24;
		L_24 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_21, L_23, NULL);
		if (!L_24)
		{
			goto IL_0090;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_25 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_26 = (int8_t*)(&L_25->___sbyte_0_16);
		V_1 = L_26;
		int8_t* L_27 = V_1;
		int32_t L_28 = ___index0;
		int32_t L_29 = *((int8_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_27), L_28)));
		int8_t L_30 = ((int8_t)L_29);
		RuntimeObject* L_31 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_30);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_31, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0090:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_32, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_34 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_35;
		L_35 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_34, NULL);
		bool L_36;
		L_36 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_33, L_35, NULL);
		if (!L_36)
		{
			goto IL_00ca;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_37 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_38 = (uint16_t*)(&L_37->___uint16_0_32);
		V_2 = L_38;
		uint16_t* L_39 = V_2;
		int32_t L_40 = ___index0;
		int32_t L_41 = *((uint16_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_39), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 2)))));
		uint16_t L_42 = ((uint16_t)L_41);
		RuntimeObject* L_43 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_42);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_43, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00ca:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_44, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_46 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_47;
		L_47 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_46, NULL);
		bool L_48;
		L_48 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_45, L_47, NULL);
		if (!L_48)
		{
			goto IL_0104;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_49 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_50 = (int16_t*)(&L_49->___int16_0_40);
		V_3 = L_50;
		int16_t* L_51 = V_3;
		int32_t L_52 = ___index0;
		int32_t L_53 = *((int16_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_51), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_52), 2)))));
		int16_t L_54 = ((int16_t)L_53);
		RuntimeObject* L_55 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_54);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0104:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0140;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_61 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_62 = (uint32_t*)(&L_61->___uint32_0_48);
		V_4 = L_62;
		uint32_t* L_63 = V_4;
		int32_t L_64 = ___index0;
		int32_t L_65 = *((uint32_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_63), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_64), 4)))));
		uint32_t L_66 = ((uint32_t)L_65);
		RuntimeObject* L_67 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_66);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_67, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0140:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_68 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_69;
		L_69 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_68, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_70 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_71;
		L_71 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_70, NULL);
		bool L_72;
		L_72 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_69, L_71, NULL);
		if (!L_72)
		{
			goto IL_017c;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_73 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_74 = (int32_t*)(&L_73->___int32_0_52);
		V_5 = L_74;
		int32_t* L_75 = V_5;
		int32_t L_76 = ___index0;
		int32_t L_77 = *((int32_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_75), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_76), 4)))));
		int32_t L_78 = L_77;
		RuntimeObject* L_79 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_78);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_79, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_017c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_80 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_81;
		L_81 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_80, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_82 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_83;
		L_83 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_82, NULL);
		bool L_84;
		L_84 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_81, L_83, NULL);
		if (!L_84)
		{
			goto IL_01b8;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_85 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_86 = (uint64_t*)(&L_85->___uint64_0_56);
		V_6 = L_86;
		uint64_t* L_87 = V_6;
		int32_t L_88 = ___index0;
		int64_t L_89 = *((int64_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_87), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_88), 8)))));
		uint64_t L_90 = ((uint64_t)L_89);
		RuntimeObject* L_91 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_90);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_91, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_01b8:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_92 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_93;
		L_93 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_92, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_94 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_95;
		L_95 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_94, NULL);
		bool L_96;
		L_96 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_93, L_95, NULL);
		if (!L_96)
		{
			goto IL_01f4;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_97 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_98 = (int64_t*)(&L_97->___int64_0_58);
		V_7 = L_98;
		int64_t* L_99 = V_7;
		int32_t L_100 = ___index0;
		int64_t L_101 = *((int64_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_99), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_100), 8)))));
		int64_t L_102 = L_101;
		RuntimeObject* L_103 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_102);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_103, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_01f4:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_104 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_105;
		L_105 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_104, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_106 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_107;
		L_107 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_106, NULL);
		bool L_108;
		L_108 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_105, L_107, NULL);
		if (!L_108)
		{
			goto IL_0230;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_109 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_110 = (float*)(&L_109->___single_0_60);
		V_8 = L_110;
		float* L_111 = V_8;
		int32_t L_112 = ___index0;
		float L_113 = *((float*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_111), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_112), 4)))));
		float L_114 = L_113;
		RuntimeObject* L_115 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_114);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_115, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0230:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_116 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_117;
		L_117 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_116, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_118 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_119;
		L_119 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_118, NULL);
		bool L_120;
		L_120 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_117, L_119, NULL);
		if (!L_120)
		{
			goto IL_026c;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_121 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_122 = (double*)(&L_121->___double_0_64);
		V_9 = L_122;
		double* L_123 = V_9;
		int32_t L_124 = ___index0;
		double L_125 = *((double*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_123), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_124), 8)))));
		double L_126 = L_125;
		RuntimeObject* L_127 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_126);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_127, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_026c:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_128 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_128);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_128, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_128, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  uint64_t Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99_AdjustorThunk (RuntimeObject* __this, int32_t ___index0, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	uint64_t _returnValue;
	_returnValue = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(_thisAdjusted, ___index0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_Equals_mE275DCDE4DC3B6FB30AB80ACEAC8363207BA9BEC_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = ___obj0;
		if (((RuntimeObject*)IsInstSealed((RuntimeObject*)L_0, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		RuntimeObject* L_1 = ___obj0;
		bool L_2;
		L_2 = Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27(__this, ((*(Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*)((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*)(Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*)UnBox(L_1, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7));
		return L_2;
	}
}
IL2CPP_EXTERN_C  bool Vector_1_Equals_mE275DCDE4DC3B6FB30AB80ACEAC8363207BA9BEC_AdjustorThunk (RuntimeObject* __this, RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	bool _returnValue;
	_returnValue = Vector_1_Equals_mE275DCDE4DC3B6FB30AB80ACEAC8363207BA9BEC_inline(_thisAdjusted, ___obj0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___other0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_0031;
		}
	}
	{
		V_0 = 0;
		goto IL_0027;
	}

IL_000b:
	{
		int32_t L_1 = V_0;
		uint64_t L_2;
		L_2 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_3 = V_0;
		uint64_t L_4;
		L_4 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___other0), L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_5;
		L_5 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_2, L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		if (L_5)
		{
			goto IL_0023;
		}
	}
	{
		return (bool)0;
	}

IL_0023:
	{
		int32_t L_6 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_6, 1));
	}

IL_0027:
	{
		int32_t L_7 = V_0;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_8;
		L_8 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_000b;
		}
	}
	{
		return (bool)1;
	}

IL_0031:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_9 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_10;
		L_10 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_9, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_11 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_12;
		L_12 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_11, NULL);
		bool L_13;
		L_13 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_10, L_12, NULL);
		if (!L_13)
		{
			goto IL_01f0;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_14 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_15 = (uint8_t)L_14->___byte_0_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_16 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_17 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_16.___register_0;
		uint8_t L_18 = (uint8_t)L_17.___byte_0_0;
		if ((!(((uint32_t)L_15) == ((uint32_t)L_18))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_19 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_20 = (uint8_t)L_19->___byte_1_1;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_21 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_22 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_21.___register_0;
		uint8_t L_23 = (uint8_t)L_22.___byte_1_1;
		if ((!(((uint32_t)L_20) == ((uint32_t)L_23))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_24 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_25 = (uint8_t)L_24->___byte_2_2;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_26 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_27 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_26.___register_0;
		uint8_t L_28 = (uint8_t)L_27.___byte_2_2;
		if ((!(((uint32_t)L_25) == ((uint32_t)L_28))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_29 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_30 = (uint8_t)L_29->___byte_3_3;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_31 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_32 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_31.___register_0;
		uint8_t L_33 = (uint8_t)L_32.___byte_3_3;
		if ((!(((uint32_t)L_30) == ((uint32_t)L_33))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_34 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_35 = (uint8_t)L_34->___byte_4_4;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_36 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_37 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_36.___register_0;
		uint8_t L_38 = (uint8_t)L_37.___byte_4_4;
		if ((!(((uint32_t)L_35) == ((uint32_t)L_38))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_39 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_40 = (uint8_t)L_39->___byte_5_5;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_41 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_42 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_41.___register_0;
		uint8_t L_43 = (uint8_t)L_42.___byte_5_5;
		if ((!(((uint32_t)L_40) == ((uint32_t)L_43))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_44 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_45 = (uint8_t)L_44->___byte_6_6;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_46 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_47 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_46.___register_0;
		uint8_t L_48 = (uint8_t)L_47.___byte_6_6;
		if ((!(((uint32_t)L_45) == ((uint32_t)L_48))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_49 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_50 = (uint8_t)L_49->___byte_7_7;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_51 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_52 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_51.___register_0;
		uint8_t L_53 = (uint8_t)L_52.___byte_7_7;
		if ((!(((uint32_t)L_50) == ((uint32_t)L_53))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_54 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_55 = (uint8_t)L_54->___byte_8_8;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_56 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_57 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_56.___register_0;
		uint8_t L_58 = (uint8_t)L_57.___byte_8_8;
		if ((!(((uint32_t)L_55) == ((uint32_t)L_58))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_59 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_60 = (uint8_t)L_59->___byte_9_9;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_61 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_62 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_61.___register_0;
		uint8_t L_63 = (uint8_t)L_62.___byte_9_9;
		if ((!(((uint32_t)L_60) == ((uint32_t)L_63))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_64 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_65 = (uint8_t)L_64->___byte_10_10;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_66 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_67 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_66.___register_0;
		uint8_t L_68 = (uint8_t)L_67.___byte_10_10;
		if ((!(((uint32_t)L_65) == ((uint32_t)L_68))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_69 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_70 = (uint8_t)L_69->___byte_11_11;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_71 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_72 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_71.___register_0;
		uint8_t L_73 = (uint8_t)L_72.___byte_11_11;
		if ((!(((uint32_t)L_70) == ((uint32_t)L_73))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_74 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_75 = (uint8_t)L_74->___byte_12_12;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_76 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_77 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_76.___register_0;
		uint8_t L_78 = (uint8_t)L_77.___byte_12_12;
		if ((!(((uint32_t)L_75) == ((uint32_t)L_78))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_79 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_80 = (uint8_t)L_79->___byte_13_13;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_81 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_82 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_81.___register_0;
		uint8_t L_83 = (uint8_t)L_82.___byte_13_13;
		if ((!(((uint32_t)L_80) == ((uint32_t)L_83))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_84 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_85 = (uint8_t)L_84->___byte_14_14;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_86 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_87 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_86.___register_0;
		uint8_t L_88 = (uint8_t)L_87.___byte_14_14;
		if ((!(((uint32_t)L_85) == ((uint32_t)L_88))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_89 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_90 = (uint8_t)L_89->___byte_15_15;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_91 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_92 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_91.___register_0;
		uint8_t L_93 = (uint8_t)L_92.___byte_15_15;
		return (bool)((((int32_t)L_90) == ((int32_t)L_93))? 1 : 0);
	}

IL_01ee:
	{
		return (bool)0;
	}

IL_01f0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_94 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_95;
		L_95 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_94, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_96 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_97;
		L_97 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_96, NULL);
		bool L_98;
		L_98 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_95, L_97, NULL);
		if (!L_98)
		{
			goto IL_03af;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_99 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_100 = (int8_t)L_99->___sbyte_0_16;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_101 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_102 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_101.___register_0;
		int8_t L_103 = (int8_t)L_102.___sbyte_0_16;
		if ((!(((uint32_t)L_100) == ((uint32_t)L_103))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_104 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_105 = (int8_t)L_104->___sbyte_1_17;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_106 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_107 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_106.___register_0;
		int8_t L_108 = (int8_t)L_107.___sbyte_1_17;
		if ((!(((uint32_t)L_105) == ((uint32_t)L_108))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_109 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_110 = (int8_t)L_109->___sbyte_2_18;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_111 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_112 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_111.___register_0;
		int8_t L_113 = (int8_t)L_112.___sbyte_2_18;
		if ((!(((uint32_t)L_110) == ((uint32_t)L_113))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_114 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_115 = (int8_t)L_114->___sbyte_3_19;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_116 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_117 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_116.___register_0;
		int8_t L_118 = (int8_t)L_117.___sbyte_3_19;
		if ((!(((uint32_t)L_115) == ((uint32_t)L_118))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_119 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_120 = (int8_t)L_119->___sbyte_4_20;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_121 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_122 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_121.___register_0;
		int8_t L_123 = (int8_t)L_122.___sbyte_4_20;
		if ((!(((uint32_t)L_120) == ((uint32_t)L_123))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_124 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_125 = (int8_t)L_124->___sbyte_5_21;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_126 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_127 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_126.___register_0;
		int8_t L_128 = (int8_t)L_127.___sbyte_5_21;
		if ((!(((uint32_t)L_125) == ((uint32_t)L_128))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_129 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_130 = (int8_t)L_129->___sbyte_6_22;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_131 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_132 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_131.___register_0;
		int8_t L_133 = (int8_t)L_132.___sbyte_6_22;
		if ((!(((uint32_t)L_130) == ((uint32_t)L_133))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_134 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_135 = (int8_t)L_134->___sbyte_7_23;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_136 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_137 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_136.___register_0;
		int8_t L_138 = (int8_t)L_137.___sbyte_7_23;
		if ((!(((uint32_t)L_135) == ((uint32_t)L_138))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_139 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_140 = (int8_t)L_139->___sbyte_8_24;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_141 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_142 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_141.___register_0;
		int8_t L_143 = (int8_t)L_142.___sbyte_8_24;
		if ((!(((uint32_t)L_140) == ((uint32_t)L_143))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_144 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_145 = (int8_t)L_144->___sbyte_9_25;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_146 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_147 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_146.___register_0;
		int8_t L_148 = (int8_t)L_147.___sbyte_9_25;
		if ((!(((uint32_t)L_145) == ((uint32_t)L_148))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_149 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_150 = (int8_t)L_149->___sbyte_10_26;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_151 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_152 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_151.___register_0;
		int8_t L_153 = (int8_t)L_152.___sbyte_10_26;
		if ((!(((uint32_t)L_150) == ((uint32_t)L_153))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_154 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_155 = (int8_t)L_154->___sbyte_11_27;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_156 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_157 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_156.___register_0;
		int8_t L_158 = (int8_t)L_157.___sbyte_11_27;
		if ((!(((uint32_t)L_155) == ((uint32_t)L_158))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_159 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_160 = (int8_t)L_159->___sbyte_12_28;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_161 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_162 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_161.___register_0;
		int8_t L_163 = (int8_t)L_162.___sbyte_12_28;
		if ((!(((uint32_t)L_160) == ((uint32_t)L_163))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_164 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_165 = (int8_t)L_164->___sbyte_13_29;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_166 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_167 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_166.___register_0;
		int8_t L_168 = (int8_t)L_167.___sbyte_13_29;
		if ((!(((uint32_t)L_165) == ((uint32_t)L_168))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_169 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_170 = (int8_t)L_169->___sbyte_14_30;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_171 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_172 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_171.___register_0;
		int8_t L_173 = (int8_t)L_172.___sbyte_14_30;
		if ((!(((uint32_t)L_170) == ((uint32_t)L_173))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_174 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_175 = (int8_t)L_174->___sbyte_15_31;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_176 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_177 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_176.___register_0;
		int8_t L_178 = (int8_t)L_177.___sbyte_15_31;
		return (bool)((((int32_t)L_175) == ((int32_t)L_178))? 1 : 0);
	}

IL_03ad:
	{
		return (bool)0;
	}

IL_03af:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_179 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_180;
		L_180 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_179, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_181 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_182;
		L_182 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_181, NULL);
		bool L_183;
		L_183 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_180, L_182, NULL);
		if (!L_183)
		{
			goto IL_0496;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_184 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_185 = (uint16_t)L_184->___uint16_0_32;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_186 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_187 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_186.___register_0;
		uint16_t L_188 = (uint16_t)L_187.___uint16_0_32;
		if ((!(((uint32_t)L_185) == ((uint32_t)L_188))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_189 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_190 = (uint16_t)L_189->___uint16_1_33;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_191 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_192 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_191.___register_0;
		uint16_t L_193 = (uint16_t)L_192.___uint16_1_33;
		if ((!(((uint32_t)L_190) == ((uint32_t)L_193))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_194 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_195 = (uint16_t)L_194->___uint16_2_34;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_196 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_197 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_196.___register_0;
		uint16_t L_198 = (uint16_t)L_197.___uint16_2_34;
		if ((!(((uint32_t)L_195) == ((uint32_t)L_198))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_199 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_200 = (uint16_t)L_199->___uint16_3_35;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_201 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_202 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_201.___register_0;
		uint16_t L_203 = (uint16_t)L_202.___uint16_3_35;
		if ((!(((uint32_t)L_200) == ((uint32_t)L_203))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_204 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_205 = (uint16_t)L_204->___uint16_4_36;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_206 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_207 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_206.___register_0;
		uint16_t L_208 = (uint16_t)L_207.___uint16_4_36;
		if ((!(((uint32_t)L_205) == ((uint32_t)L_208))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_209 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_210 = (uint16_t)L_209->___uint16_5_37;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_211 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_212 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_211.___register_0;
		uint16_t L_213 = (uint16_t)L_212.___uint16_5_37;
		if ((!(((uint32_t)L_210) == ((uint32_t)L_213))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_214 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_215 = (uint16_t)L_214->___uint16_6_38;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_216 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_217 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_216.___register_0;
		uint16_t L_218 = (uint16_t)L_217.___uint16_6_38;
		if ((!(((uint32_t)L_215) == ((uint32_t)L_218))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_219 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_220 = (uint16_t)L_219->___uint16_7_39;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_221 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_222 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_221.___register_0;
		uint16_t L_223 = (uint16_t)L_222.___uint16_7_39;
		return (bool)((((int32_t)L_220) == ((int32_t)L_223))? 1 : 0);
	}

IL_0494:
	{
		return (bool)0;
	}

IL_0496:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_224 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_225;
		L_225 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_224, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_226 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_227;
		L_227 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_226, NULL);
		bool L_228;
		L_228 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_225, L_227, NULL);
		if (!L_228)
		{
			goto IL_057d;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_229 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_230 = (int16_t)L_229->___int16_0_40;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_231 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_232 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_231.___register_0;
		int16_t L_233 = (int16_t)L_232.___int16_0_40;
		if ((!(((uint32_t)L_230) == ((uint32_t)L_233))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_234 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_235 = (int16_t)L_234->___int16_1_41;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_236 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_237 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_236.___register_0;
		int16_t L_238 = (int16_t)L_237.___int16_1_41;
		if ((!(((uint32_t)L_235) == ((uint32_t)L_238))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_239 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_240 = (int16_t)L_239->___int16_2_42;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_241 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_242 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_241.___register_0;
		int16_t L_243 = (int16_t)L_242.___int16_2_42;
		if ((!(((uint32_t)L_240) == ((uint32_t)L_243))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_244 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_245 = (int16_t)L_244->___int16_3_43;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_246 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_247 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_246.___register_0;
		int16_t L_248 = (int16_t)L_247.___int16_3_43;
		if ((!(((uint32_t)L_245) == ((uint32_t)L_248))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_249 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_250 = (int16_t)L_249->___int16_4_44;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_251 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_252 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_251.___register_0;
		int16_t L_253 = (int16_t)L_252.___int16_4_44;
		if ((!(((uint32_t)L_250) == ((uint32_t)L_253))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_254 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_255 = (int16_t)L_254->___int16_5_45;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_256 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_257 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_256.___register_0;
		int16_t L_258 = (int16_t)L_257.___int16_5_45;
		if ((!(((uint32_t)L_255) == ((uint32_t)L_258))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_259 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_260 = (int16_t)L_259->___int16_6_46;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_261 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_262 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_261.___register_0;
		int16_t L_263 = (int16_t)L_262.___int16_6_46;
		if ((!(((uint32_t)L_260) == ((uint32_t)L_263))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_264 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_265 = (int16_t)L_264->___int16_7_47;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_266 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_267 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_266.___register_0;
		int16_t L_268 = (int16_t)L_267.___int16_7_47;
		return (bool)((((int32_t)L_265) == ((int32_t)L_268))? 1 : 0);
	}

IL_057b:
	{
		return (bool)0;
	}

IL_057d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_269 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_270;
		L_270 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_269, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_271 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_272;
		L_272 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_271, NULL);
		bool L_273;
		L_273 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_270, L_272, NULL);
		if (!L_273)
		{
			goto IL_05fb;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_274 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_275 = (uint32_t)L_274->___uint32_0_48;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_276 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_277 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_276.___register_0;
		uint32_t L_278 = (uint32_t)L_277.___uint32_0_48;
		if ((!(((uint32_t)L_275) == ((uint32_t)L_278))))
		{
			goto IL_05f9;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_279 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_280 = (uint32_t)L_279->___uint32_1_49;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_281 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_282 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_281.___register_0;
		uint32_t L_283 = (uint32_t)L_282.___uint32_1_49;
		if ((!(((uint32_t)L_280) == ((uint32_t)L_283))))
		{
			goto IL_05f9;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_284 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_285 = (uint32_t)L_284->___uint32_2_50;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_286 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_287 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_286.___register_0;
		uint32_t L_288 = (uint32_t)L_287.___uint32_2_50;
		if ((!(((uint32_t)L_285) == ((uint32_t)L_288))))
		{
			goto IL_05f9;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_289 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_290 = (uint32_t)L_289->___uint32_3_51;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_291 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_292 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_291.___register_0;
		uint32_t L_293 = (uint32_t)L_292.___uint32_3_51;
		return (bool)((((int32_t)L_290) == ((int32_t)L_293))? 1 : 0);
	}

IL_05f9:
	{
		return (bool)0;
	}

IL_05fb:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_294 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_295;
		L_295 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_294, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_296 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_297;
		L_297 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_296, NULL);
		bool L_298;
		L_298 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_295, L_297, NULL);
		if (!L_298)
		{
			goto IL_0679;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_299 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_300 = (int32_t)L_299->___int32_0_52;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_301 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_302 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_301.___register_0;
		int32_t L_303 = (int32_t)L_302.___int32_0_52;
		if ((!(((uint32_t)L_300) == ((uint32_t)L_303))))
		{
			goto IL_0677;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_304 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_305 = (int32_t)L_304->___int32_1_53;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_306 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_307 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_306.___register_0;
		int32_t L_308 = (int32_t)L_307.___int32_1_53;
		if ((!(((uint32_t)L_305) == ((uint32_t)L_308))))
		{
			goto IL_0677;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_309 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_310 = (int32_t)L_309->___int32_2_54;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_311 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_312 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_311.___register_0;
		int32_t L_313 = (int32_t)L_312.___int32_2_54;
		if ((!(((uint32_t)L_310) == ((uint32_t)L_313))))
		{
			goto IL_0677;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_314 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_315 = (int32_t)L_314->___int32_3_55;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_316 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_317 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_316.___register_0;
		int32_t L_318 = (int32_t)L_317.___int32_3_55;
		return (bool)((((int32_t)L_315) == ((int32_t)L_318))? 1 : 0);
	}

IL_0677:
	{
		return (bool)0;
	}

IL_0679:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_319 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_320;
		L_320 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_319, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_321 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_322;
		L_322 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_321, NULL);
		bool L_323;
		L_323 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_320, L_322, NULL);
		if (!L_323)
		{
			goto IL_06c7;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_324 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_325 = (uint64_t)L_324->___uint64_0_56;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_326 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_327 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_326.___register_0;
		uint64_t L_328 = (uint64_t)L_327.___uint64_0_56;
		if ((!(((uint64_t)L_325) == ((uint64_t)L_328))))
		{
			goto IL_06c5;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_329 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_330 = (uint64_t)L_329->___uint64_1_57;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_331 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_332 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_331.___register_0;
		uint64_t L_333 = (uint64_t)L_332.___uint64_1_57;
		return (bool)((((int64_t)L_330) == ((int64_t)L_333))? 1 : 0);
	}

IL_06c5:
	{
		return (bool)0;
	}

IL_06c7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_334 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_335;
		L_335 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_334, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_336 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_337;
		L_337 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_336, NULL);
		bool L_338;
		L_338 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_335, L_337, NULL);
		if (!L_338)
		{
			goto IL_0715;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_339 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t L_340 = (int64_t)L_339->___int64_0_58;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_341 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_342 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_341.___register_0;
		int64_t L_343 = (int64_t)L_342.___int64_0_58;
		if ((!(((uint64_t)L_340) == ((uint64_t)L_343))))
		{
			goto IL_0713;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_344 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t L_345 = (int64_t)L_344->___int64_1_59;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_346 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_347 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_346.___register_0;
		int64_t L_348 = (int64_t)L_347.___int64_1_59;
		return (bool)((((int64_t)L_345) == ((int64_t)L_348))? 1 : 0);
	}

IL_0713:
	{
		return (bool)0;
	}

IL_0715:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_349 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_350;
		L_350 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_349, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_351 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_352;
		L_352 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_351, NULL);
		bool L_353;
		L_353 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_350, L_352, NULL);
		if (!L_353)
		{
			goto IL_0793;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_354 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_355 = (float)L_354->___single_0_60;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_356 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_357 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_356.___register_0;
		float L_358 = (float)L_357.___single_0_60;
		if ((!(((float)L_355) == ((float)L_358))))
		{
			goto IL_0791;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_359 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_360 = (float)L_359->___single_1_61;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_361 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_362 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_361.___register_0;
		float L_363 = (float)L_362.___single_1_61;
		if ((!(((float)L_360) == ((float)L_363))))
		{
			goto IL_0791;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_364 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_365 = (float)L_364->___single_2_62;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_366 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_367 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_366.___register_0;
		float L_368 = (float)L_367.___single_2_62;
		if ((!(((float)L_365) == ((float)L_368))))
		{
			goto IL_0791;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_369 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_370 = (float)L_369->___single_3_63;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_371 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_372 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_371.___register_0;
		float L_373 = (float)L_372.___single_3_63;
		return (bool)((((float)L_370) == ((float)L_373))? 1 : 0);
	}

IL_0791:
	{
		return (bool)0;
	}

IL_0793:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_374 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_375;
		L_375 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_374, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_376 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_377;
		L_377 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_376, NULL);
		bool L_378;
		L_378 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_375, L_377, NULL);
		if (!L_378)
		{
			goto IL_07e1;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_379 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double L_380 = (double)L_379->___double_0_64;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_381 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_382 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_381.___register_0;
		double L_383 = (double)L_382.___double_0_64;
		if ((!(((double)L_380) == ((double)L_383))))
		{
			goto IL_07df;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_384 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double L_385 = (double)L_384->___double_1_65;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_386 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_387 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_386.___register_0;
		double L_388 = (double)L_387.___double_1_65;
		return (bool)((((double)L_385) == ((double)L_388))? 1 : 0);
	}

IL_07df:
	{
		return (bool)0;
	}

IL_07e1:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_389 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_389);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_389, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_389, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  bool Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27_AdjustorThunk (RuntimeObject* __this, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___other0, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	bool _returnValue;
	_returnValue = Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27(_thisAdjusted, ___other0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	uint8_t V_2 = 0x0;
	int32_t V_3 = 0;
	int8_t V_4 = 0x0;
	int32_t V_5 = 0;
	uint16_t V_6 = 0;
	int32_t V_7 = 0;
	int16_t V_8 = 0;
	int32_t V_9 = 0;
	uint32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	uint64_t V_14 = 0;
	int32_t V_15 = 0;
	int64_t V_16 = 0;
	int32_t V_17 = 0;
	float V_18 = 0.0f;
	int32_t V_19 = 0;
	double V_20 = 0.0;
	{
		V_0 = 0;
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_034a;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_3, NULL);
		bool L_5;
		L_5 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_2, L_4, NULL);
		if (!L_5)
		{
			goto IL_0059;
		}
	}
	{
		V_1 = 0;
		goto IL_004f;
	}

IL_002b:
	{
		int32_t L_6 = V_0;
		int32_t L_7 = V_1;
		uint64_t L_8;
		L_8 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_7, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_9 = L_8;
		RuntimeObject* L_10 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_9);
		V_2 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_10, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		int32_t L_11;
		L_11 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678((&V_2), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_12;
		L_12 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_6, L_11, NULL);
		V_0 = L_12;
		int32_t L_13 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_13, 1));
	}

IL_004f:
	{
		int32_t L_14 = V_1;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_15;
		L_15 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_14) < ((int32_t)L_15)))
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_16 = V_0;
		return L_16;
	}

IL_0059:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_17 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_18;
		L_18 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_17, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_19 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_20;
		L_20 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_19, NULL);
		bool L_21;
		L_21 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_18, L_20, NULL);
		if (!L_21)
		{
			goto IL_00a7;
		}
	}
	{
		V_3 = 0;
		goto IL_009d;
	}

IL_0078:
	{
		int32_t L_22 = V_0;
		int32_t L_23 = V_3;
		uint64_t L_24;
		L_24 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_23, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_25 = L_24;
		RuntimeObject* L_26 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_25);
		V_4 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_26, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		int32_t L_27;
		L_27 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF((&V_4), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_28;
		L_28 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_22, L_27, NULL);
		V_0 = L_28;
		int32_t L_29 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_29, 1));
	}

IL_009d:
	{
		int32_t L_30 = V_3;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_31;
		L_31 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_30) < ((int32_t)L_31)))
		{
			goto IL_0078;
		}
	}
	{
		int32_t L_32 = V_0;
		return L_32;
	}

IL_00a7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_33 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_34;
		L_34 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_33, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		bool L_37;
		L_37 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_34, L_36, NULL);
		if (!L_37)
		{
			goto IL_00fa;
		}
	}
	{
		V_5 = 0;
		goto IL_00ef;
	}

IL_00c7:
	{
		int32_t L_38 = V_0;
		int32_t L_39 = V_5;
		uint64_t L_40;
		L_40 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_41 = L_40;
		RuntimeObject* L_42 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_41);
		V_6 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_42, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		int32_t L_43;
		L_43 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200((&V_6), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_44;
		L_44 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_38, L_43, NULL);
		V_0 = L_44;
		int32_t L_45 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_45, 1));
	}

IL_00ef:
	{
		int32_t L_46 = V_5;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_47;
		L_47 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_46) < ((int32_t)L_47)))
		{
			goto IL_00c7;
		}
	}
	{
		int32_t L_48 = V_0;
		return L_48;
	}

IL_00fa:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_49 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_50;
		L_50 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_49, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_51 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_52;
		L_52 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_51, NULL);
		bool L_53;
		L_53 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_50, L_52, NULL);
		if (!L_53)
		{
			goto IL_014d;
		}
	}
	{
		V_7 = 0;
		goto IL_0142;
	}

IL_011a:
	{
		int32_t L_54 = V_0;
		int32_t L_55 = V_7;
		uint64_t L_56;
		L_56 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_55, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_57 = L_56;
		RuntimeObject* L_58 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_57);
		V_8 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_58, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		int32_t L_59;
		L_59 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1((&V_8), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_60;
		L_60 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_54, L_59, NULL);
		V_0 = L_60;
		int32_t L_61 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_61, 1));
	}

IL_0142:
	{
		int32_t L_62 = V_7;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_63;
		L_63 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_62) < ((int32_t)L_63)))
		{
			goto IL_011a;
		}
	}
	{
		int32_t L_64 = V_0;
		return L_64;
	}

IL_014d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_65 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_66;
		L_66 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_65, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_67 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_68;
		L_68 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_67, NULL);
		bool L_69;
		L_69 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_66, L_68, NULL);
		if (!L_69)
		{
			goto IL_01a0;
		}
	}
	{
		V_9 = 0;
		goto IL_0195;
	}

IL_016d:
	{
		int32_t L_70 = V_0;
		int32_t L_71 = V_9;
		uint64_t L_72;
		L_72 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_71, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_73 = L_72;
		RuntimeObject* L_74 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_73);
		V_10 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_74, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		int32_t L_75;
		L_75 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC((&V_10), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_76;
		L_76 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_70, L_75, NULL);
		V_0 = L_76;
		int32_t L_77 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_77, 1));
	}

IL_0195:
	{
		int32_t L_78 = V_9;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_79;
		L_79 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_78) < ((int32_t)L_79)))
		{
			goto IL_016d;
		}
	}
	{
		int32_t L_80 = V_0;
		return L_80;
	}

IL_01a0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_81 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_82;
		L_82 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_81, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_83 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_84;
		L_84 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_83, NULL);
		bool L_85;
		L_85 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_82, L_84, NULL);
		if (!L_85)
		{
			goto IL_01f3;
		}
	}
	{
		V_11 = 0;
		goto IL_01e8;
	}

IL_01c0:
	{
		int32_t L_86 = V_0;
		int32_t L_87 = V_11;
		uint64_t L_88;
		L_88 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_87, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_89 = L_88;
		RuntimeObject* L_90 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_89);
		V_12 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_90, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		int32_t L_91;
		L_91 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&V_12), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_92;
		L_92 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_86, L_91, NULL);
		V_0 = L_92;
		int32_t L_93 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_93, 1));
	}

IL_01e8:
	{
		int32_t L_94 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_95;
		L_95 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_94) < ((int32_t)L_95)))
		{
			goto IL_01c0;
		}
	}
	{
		int32_t L_96 = V_0;
		return L_96;
	}

IL_01f3:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_97 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_98;
		L_98 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_97, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_99 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_100;
		L_100 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_99, NULL);
		bool L_101;
		L_101 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_98, L_100, NULL);
		if (!L_101)
		{
			goto IL_0246;
		}
	}
	{
		V_13 = 0;
		goto IL_023b;
	}

IL_0213:
	{
		int32_t L_102 = V_0;
		int32_t L_103 = V_13;
		uint64_t L_104;
		L_104 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_103, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_105 = L_104;
		RuntimeObject* L_106 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_105);
		V_14 = ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_106, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		int32_t L_107;
		L_107 = UInt64_GetHashCode_m65D9FD0102B6B01BF38D986F060F0BDBC29B4F92((&V_14), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_108;
		L_108 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_102, L_107, NULL);
		V_0 = L_108;
		int32_t L_109 = V_13;
		V_13 = ((int32_t)il2cpp_codegen_add(L_109, 1));
	}

IL_023b:
	{
		int32_t L_110 = V_13;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_111;
		L_111 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_110) < ((int32_t)L_111)))
		{
			goto IL_0213;
		}
	}
	{
		int32_t L_112 = V_0;
		return L_112;
	}

IL_0246:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_113 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_114;
		L_114 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_113, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_115 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_116;
		L_116 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_115, NULL);
		bool L_117;
		L_117 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_114, L_116, NULL);
		if (!L_117)
		{
			goto IL_0299;
		}
	}
	{
		V_15 = 0;
		goto IL_028e;
	}

IL_0266:
	{
		int32_t L_118 = V_0;
		int32_t L_119 = V_15;
		uint64_t L_120;
		L_120 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_119, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_121 = L_120;
		RuntimeObject* L_122 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_121);
		V_16 = ((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_122, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		int32_t L_123;
		L_123 = Int64_GetHashCode_mDB050BE2AC244D92B14D1DF725AAD279CDC48496((&V_16), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_124;
		L_124 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_118, L_123, NULL);
		V_0 = L_124;
		int32_t L_125 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_add(L_125, 1));
	}

IL_028e:
	{
		int32_t L_126 = V_15;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_127;
		L_127 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_126) < ((int32_t)L_127)))
		{
			goto IL_0266;
		}
	}
	{
		int32_t L_128 = V_0;
		return L_128;
	}

IL_0299:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_129 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_130;
		L_130 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_129, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_131 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_132;
		L_132 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_131, NULL);
		bool L_133;
		L_133 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_130, L_132, NULL);
		if (!L_133)
		{
			goto IL_02ec;
		}
	}
	{
		V_17 = 0;
		goto IL_02e1;
	}

IL_02b9:
	{
		int32_t L_134 = V_0;
		int32_t L_135 = V_17;
		uint64_t L_136;
		L_136 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_135, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_137 = L_136;
		RuntimeObject* L_138 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_137);
		V_18 = ((*(float*)((float*)(float*)UnBox(L_138, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		int32_t L_139;
		L_139 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2((&V_18), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_140;
		L_140 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_134, L_139, NULL);
		V_0 = L_140;
		int32_t L_141 = V_17;
		V_17 = ((int32_t)il2cpp_codegen_add(L_141, 1));
	}

IL_02e1:
	{
		int32_t L_142 = V_17;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_143;
		L_143 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_142) < ((int32_t)L_143)))
		{
			goto IL_02b9;
		}
	}
	{
		int32_t L_144 = V_0;
		return L_144;
	}

IL_02ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_145 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_146;
		L_146 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_145, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_147 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_148;
		L_148 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_147, NULL);
		bool L_149;
		L_149 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_146, L_148, NULL);
		if (!L_149)
		{
			goto IL_033f;
		}
	}
	{
		V_19 = 0;
		goto IL_0334;
	}

IL_030c:
	{
		int32_t L_150 = V_0;
		int32_t L_151 = V_19;
		uint64_t L_152;
		L_152 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_151, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_153 = L_152;
		RuntimeObject* L_154 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_153);
		V_20 = ((*(double*)((double*)(double*)UnBox(L_154, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
		int32_t L_155;
		L_155 = Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline((&V_20), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_156;
		L_156 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_150, L_155, NULL);
		V_0 = L_156;
		int32_t L_157 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_157, 1));
	}

IL_0334:
	{
		int32_t L_158 = V_19;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_159;
		L_159 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_158) < ((int32_t)L_159)))
		{
			goto IL_030c;
		}
	}
	{
		int32_t L_160 = V_0;
		return L_160;
	}

IL_033f:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_161 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_161);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_161, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_161, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A_RuntimeMethod_var)));
	}

IL_034a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_162 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_163;
		L_163 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_162, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_164 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_165;
		L_165 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_164, NULL);
		bool L_166;
		L_166 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_163, L_165, NULL);
		if (!L_166)
		{
			goto IL_04da;
		}
	}
	{
		int32_t L_167 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_168 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_169 = (uint8_t*)(&L_168->___byte_0_0);
		int32_t L_170;
		L_170 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_169, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_171;
		L_171 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_167, L_170, NULL);
		V_0 = L_171;
		int32_t L_172 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_173 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_174 = (uint8_t*)(&L_173->___byte_1_1);
		int32_t L_175;
		L_175 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_174, NULL);
		int32_t L_176;
		L_176 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_172, L_175, NULL);
		V_0 = L_176;
		int32_t L_177 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_178 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_179 = (uint8_t*)(&L_178->___byte_2_2);
		int32_t L_180;
		L_180 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_179, NULL);
		int32_t L_181;
		L_181 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_177, L_180, NULL);
		V_0 = L_181;
		int32_t L_182 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_183 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_184 = (uint8_t*)(&L_183->___byte_3_3);
		int32_t L_185;
		L_185 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_184, NULL);
		int32_t L_186;
		L_186 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_182, L_185, NULL);
		V_0 = L_186;
		int32_t L_187 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_188 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_189 = (uint8_t*)(&L_188->___byte_4_4);
		int32_t L_190;
		L_190 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_189, NULL);
		int32_t L_191;
		L_191 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_187, L_190, NULL);
		V_0 = L_191;
		int32_t L_192 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_193 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_194 = (uint8_t*)(&L_193->___byte_5_5);
		int32_t L_195;
		L_195 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_194, NULL);
		int32_t L_196;
		L_196 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_192, L_195, NULL);
		V_0 = L_196;
		int32_t L_197 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_198 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_199 = (uint8_t*)(&L_198->___byte_6_6);
		int32_t L_200;
		L_200 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_199, NULL);
		int32_t L_201;
		L_201 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_197, L_200, NULL);
		V_0 = L_201;
		int32_t L_202 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_203 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_204 = (uint8_t*)(&L_203->___byte_7_7);
		int32_t L_205;
		L_205 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_204, NULL);
		int32_t L_206;
		L_206 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_202, L_205, NULL);
		V_0 = L_206;
		int32_t L_207 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_208 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_209 = (uint8_t*)(&L_208->___byte_8_8);
		int32_t L_210;
		L_210 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_209, NULL);
		int32_t L_211;
		L_211 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_207, L_210, NULL);
		V_0 = L_211;
		int32_t L_212 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_213 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_214 = (uint8_t*)(&L_213->___byte_9_9);
		int32_t L_215;
		L_215 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_214, NULL);
		int32_t L_216;
		L_216 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_212, L_215, NULL);
		V_0 = L_216;
		int32_t L_217 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_218 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_219 = (uint8_t*)(&L_218->___byte_10_10);
		int32_t L_220;
		L_220 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_219, NULL);
		int32_t L_221;
		L_221 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_217, L_220, NULL);
		V_0 = L_221;
		int32_t L_222 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_223 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_224 = (uint8_t*)(&L_223->___byte_11_11);
		int32_t L_225;
		L_225 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_224, NULL);
		int32_t L_226;
		L_226 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_222, L_225, NULL);
		V_0 = L_226;
		int32_t L_227 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_228 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_229 = (uint8_t*)(&L_228->___byte_12_12);
		int32_t L_230;
		L_230 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_229, NULL);
		int32_t L_231;
		L_231 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_227, L_230, NULL);
		V_0 = L_231;
		int32_t L_232 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_233 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_234 = (uint8_t*)(&L_233->___byte_13_13);
		int32_t L_235;
		L_235 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_234, NULL);
		int32_t L_236;
		L_236 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_232, L_235, NULL);
		V_0 = L_236;
		int32_t L_237 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_238 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_239 = (uint8_t*)(&L_238->___byte_14_14);
		int32_t L_240;
		L_240 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_239, NULL);
		int32_t L_241;
		L_241 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_237, L_240, NULL);
		V_0 = L_241;
		int32_t L_242 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_243 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_244 = (uint8_t*)(&L_243->___byte_15_15);
		int32_t L_245;
		L_245 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_244, NULL);
		int32_t L_246;
		L_246 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_242, L_245, NULL);
		V_0 = L_246;
		int32_t L_247 = V_0;
		return L_247;
	}

IL_04da:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_248 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_249;
		L_249 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_248, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_250 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_251;
		L_251 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_250, NULL);
		bool L_252;
		L_252 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_249, L_251, NULL);
		if (!L_252)
		{
			goto IL_066a;
		}
	}
	{
		int32_t L_253 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_254 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_255 = (int8_t*)(&L_254->___sbyte_0_16);
		int32_t L_256;
		L_256 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_255, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_257;
		L_257 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_253, L_256, NULL);
		V_0 = L_257;
		int32_t L_258 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_259 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_260 = (int8_t*)(&L_259->___sbyte_1_17);
		int32_t L_261;
		L_261 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_260, NULL);
		int32_t L_262;
		L_262 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_258, L_261, NULL);
		V_0 = L_262;
		int32_t L_263 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_264 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_265 = (int8_t*)(&L_264->___sbyte_2_18);
		int32_t L_266;
		L_266 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_265, NULL);
		int32_t L_267;
		L_267 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_263, L_266, NULL);
		V_0 = L_267;
		int32_t L_268 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_269 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_270 = (int8_t*)(&L_269->___sbyte_3_19);
		int32_t L_271;
		L_271 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_270, NULL);
		int32_t L_272;
		L_272 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_268, L_271, NULL);
		V_0 = L_272;
		int32_t L_273 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_274 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_275 = (int8_t*)(&L_274->___sbyte_4_20);
		int32_t L_276;
		L_276 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_275, NULL);
		int32_t L_277;
		L_277 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_273, L_276, NULL);
		V_0 = L_277;
		int32_t L_278 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_279 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_280 = (int8_t*)(&L_279->___sbyte_5_21);
		int32_t L_281;
		L_281 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_280, NULL);
		int32_t L_282;
		L_282 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_278, L_281, NULL);
		V_0 = L_282;
		int32_t L_283 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_284 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_285 = (int8_t*)(&L_284->___sbyte_6_22);
		int32_t L_286;
		L_286 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_285, NULL);
		int32_t L_287;
		L_287 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_283, L_286, NULL);
		V_0 = L_287;
		int32_t L_288 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_289 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_290 = (int8_t*)(&L_289->___sbyte_7_23);
		int32_t L_291;
		L_291 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_290, NULL);
		int32_t L_292;
		L_292 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_288, L_291, NULL);
		V_0 = L_292;
		int32_t L_293 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_294 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_295 = (int8_t*)(&L_294->___sbyte_8_24);
		int32_t L_296;
		L_296 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_295, NULL);
		int32_t L_297;
		L_297 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_293, L_296, NULL);
		V_0 = L_297;
		int32_t L_298 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_299 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_300 = (int8_t*)(&L_299->___sbyte_9_25);
		int32_t L_301;
		L_301 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_300, NULL);
		int32_t L_302;
		L_302 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_298, L_301, NULL);
		V_0 = L_302;
		int32_t L_303 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_304 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_305 = (int8_t*)(&L_304->___sbyte_10_26);
		int32_t L_306;
		L_306 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_305, NULL);
		int32_t L_307;
		L_307 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_303, L_306, NULL);
		V_0 = L_307;
		int32_t L_308 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_309 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_310 = (int8_t*)(&L_309->___sbyte_11_27);
		int32_t L_311;
		L_311 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_310, NULL);
		int32_t L_312;
		L_312 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_308, L_311, NULL);
		V_0 = L_312;
		int32_t L_313 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_314 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_315 = (int8_t*)(&L_314->___sbyte_12_28);
		int32_t L_316;
		L_316 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_315, NULL);
		int32_t L_317;
		L_317 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_313, L_316, NULL);
		V_0 = L_317;
		int32_t L_318 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_319 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_320 = (int8_t*)(&L_319->___sbyte_13_29);
		int32_t L_321;
		L_321 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_320, NULL);
		int32_t L_322;
		L_322 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_318, L_321, NULL);
		V_0 = L_322;
		int32_t L_323 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_324 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_325 = (int8_t*)(&L_324->___sbyte_14_30);
		int32_t L_326;
		L_326 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_325, NULL);
		int32_t L_327;
		L_327 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_323, L_326, NULL);
		V_0 = L_327;
		int32_t L_328 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_329 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_330 = (int8_t*)(&L_329->___sbyte_15_31);
		int32_t L_331;
		L_331 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_330, NULL);
		int32_t L_332;
		L_332 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_328, L_331, NULL);
		V_0 = L_332;
		int32_t L_333 = V_0;
		return L_333;
	}

IL_066a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_334 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_335;
		L_335 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_334, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_336 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_337;
		L_337 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_336, NULL);
		bool L_338;
		L_338 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_335, L_337, NULL);
		if (!L_338)
		{
			goto IL_0742;
		}
	}
	{
		int32_t L_339 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_340 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_341 = (uint16_t*)(&L_340->___uint16_0_32);
		int32_t L_342;
		L_342 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_341, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_343;
		L_343 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_339, L_342, NULL);
		V_0 = L_343;
		int32_t L_344 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_345 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_346 = (uint16_t*)(&L_345->___uint16_1_33);
		int32_t L_347;
		L_347 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_346, NULL);
		int32_t L_348;
		L_348 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_344, L_347, NULL);
		V_0 = L_348;
		int32_t L_349 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_350 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_351 = (uint16_t*)(&L_350->___uint16_2_34);
		int32_t L_352;
		L_352 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_351, NULL);
		int32_t L_353;
		L_353 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_349, L_352, NULL);
		V_0 = L_353;
		int32_t L_354 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_355 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_356 = (uint16_t*)(&L_355->___uint16_3_35);
		int32_t L_357;
		L_357 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_356, NULL);
		int32_t L_358;
		L_358 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_354, L_357, NULL);
		V_0 = L_358;
		int32_t L_359 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_360 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_361 = (uint16_t*)(&L_360->___uint16_4_36);
		int32_t L_362;
		L_362 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_361, NULL);
		int32_t L_363;
		L_363 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_359, L_362, NULL);
		V_0 = L_363;
		int32_t L_364 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_365 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_366 = (uint16_t*)(&L_365->___uint16_5_37);
		int32_t L_367;
		L_367 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_366, NULL);
		int32_t L_368;
		L_368 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_364, L_367, NULL);
		V_0 = L_368;
		int32_t L_369 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_370 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_371 = (uint16_t*)(&L_370->___uint16_6_38);
		int32_t L_372;
		L_372 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_371, NULL);
		int32_t L_373;
		L_373 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_369, L_372, NULL);
		V_0 = L_373;
		int32_t L_374 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_375 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_376 = (uint16_t*)(&L_375->___uint16_7_39);
		int32_t L_377;
		L_377 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_376, NULL);
		int32_t L_378;
		L_378 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_374, L_377, NULL);
		V_0 = L_378;
		int32_t L_379 = V_0;
		return L_379;
	}

IL_0742:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_380 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_381;
		L_381 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_380, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_382 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_383;
		L_383 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_382, NULL);
		bool L_384;
		L_384 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_381, L_383, NULL);
		if (!L_384)
		{
			goto IL_081a;
		}
	}
	{
		int32_t L_385 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_386 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_387 = (int16_t*)(&L_386->___int16_0_40);
		int32_t L_388;
		L_388 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_387, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_389;
		L_389 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_385, L_388, NULL);
		V_0 = L_389;
		int32_t L_390 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_391 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_392 = (int16_t*)(&L_391->___int16_1_41);
		int32_t L_393;
		L_393 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_392, NULL);
		int32_t L_394;
		L_394 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_390, L_393, NULL);
		V_0 = L_394;
		int32_t L_395 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_396 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_397 = (int16_t*)(&L_396->___int16_2_42);
		int32_t L_398;
		L_398 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_397, NULL);
		int32_t L_399;
		L_399 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_395, L_398, NULL);
		V_0 = L_399;
		int32_t L_400 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_401 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_402 = (int16_t*)(&L_401->___int16_3_43);
		int32_t L_403;
		L_403 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_402, NULL);
		int32_t L_404;
		L_404 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_400, L_403, NULL);
		V_0 = L_404;
		int32_t L_405 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_406 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_407 = (int16_t*)(&L_406->___int16_4_44);
		int32_t L_408;
		L_408 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_407, NULL);
		int32_t L_409;
		L_409 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_405, L_408, NULL);
		V_0 = L_409;
		int32_t L_410 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_411 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_412 = (int16_t*)(&L_411->___int16_5_45);
		int32_t L_413;
		L_413 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_412, NULL);
		int32_t L_414;
		L_414 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_410, L_413, NULL);
		V_0 = L_414;
		int32_t L_415 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_416 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_417 = (int16_t*)(&L_416->___int16_6_46);
		int32_t L_418;
		L_418 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_417, NULL);
		int32_t L_419;
		L_419 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_415, L_418, NULL);
		V_0 = L_419;
		int32_t L_420 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_421 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_422 = (int16_t*)(&L_421->___int16_7_47);
		int32_t L_423;
		L_423 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_422, NULL);
		int32_t L_424;
		L_424 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_420, L_423, NULL);
		V_0 = L_424;
		int32_t L_425 = V_0;
		return L_425;
	}

IL_081a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_426 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_427;
		L_427 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_426, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_428 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_429;
		L_429 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_428, NULL);
		bool L_430;
		L_430 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_427, L_429, NULL);
		if (!L_430)
		{
			goto IL_0893;
		}
	}
	{
		int32_t L_431 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_432 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_433 = (uint32_t*)(&L_432->___uint32_0_48);
		int32_t L_434;
		L_434 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_433, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_435;
		L_435 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_431, L_434, NULL);
		V_0 = L_435;
		int32_t L_436 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_437 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_438 = (uint32_t*)(&L_437->___uint32_1_49);
		int32_t L_439;
		L_439 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_438, NULL);
		int32_t L_440;
		L_440 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_436, L_439, NULL);
		V_0 = L_440;
		int32_t L_441 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_442 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_443 = (uint32_t*)(&L_442->___uint32_2_50);
		int32_t L_444;
		L_444 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_443, NULL);
		int32_t L_445;
		L_445 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_441, L_444, NULL);
		V_0 = L_445;
		int32_t L_446 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_447 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_448 = (uint32_t*)(&L_447->___uint32_3_51);
		int32_t L_449;
		L_449 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_448, NULL);
		int32_t L_450;
		L_450 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_446, L_449, NULL);
		V_0 = L_450;
		int32_t L_451 = V_0;
		return L_451;
	}

IL_0893:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_452 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_453;
		L_453 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_452, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_454 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_455;
		L_455 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_454, NULL);
		bool L_456;
		L_456 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_453, L_455, NULL);
		if (!L_456)
		{
			goto IL_090c;
		}
	}
	{
		int32_t L_457 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_458 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_459 = (int32_t*)(&L_458->___int32_0_52);
		int32_t L_460;
		L_460 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_459, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_461;
		L_461 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_457, L_460, NULL);
		V_0 = L_461;
		int32_t L_462 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_463 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_464 = (int32_t*)(&L_463->___int32_1_53);
		int32_t L_465;
		L_465 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_464, NULL);
		int32_t L_466;
		L_466 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_462, L_465, NULL);
		V_0 = L_466;
		int32_t L_467 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_468 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_469 = (int32_t*)(&L_468->___int32_2_54);
		int32_t L_470;
		L_470 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_469, NULL);
		int32_t L_471;
		L_471 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_467, L_470, NULL);
		V_0 = L_471;
		int32_t L_472 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_473 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_474 = (int32_t*)(&L_473->___int32_3_55);
		int32_t L_475;
		L_475 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_474, NULL);
		int32_t L_476;
		L_476 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_472, L_475, NULL);
		V_0 = L_476;
		int32_t L_477 = V_0;
		return L_477;
	}

IL_090c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_478 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_479;
		L_479 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_478, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_480 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_481;
		L_481 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_480, NULL);
		bool L_482;
		L_482 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_479, L_481, NULL);
		if (!L_482)
		{
			goto IL_0957;
		}
	}
	{
		int32_t L_483 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_484 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_485 = (uint64_t*)(&L_484->___uint64_0_56);
		int32_t L_486;
		L_486 = UInt64_GetHashCode_m65D9FD0102B6B01BF38D986F060F0BDBC29B4F92(L_485, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_487;
		L_487 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_483, L_486, NULL);
		V_0 = L_487;
		int32_t L_488 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_489 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_490 = (uint64_t*)(&L_489->___uint64_1_57);
		int32_t L_491;
		L_491 = UInt64_GetHashCode_m65D9FD0102B6B01BF38D986F060F0BDBC29B4F92(L_490, NULL);
		int32_t L_492;
		L_492 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_488, L_491, NULL);
		V_0 = L_492;
		int32_t L_493 = V_0;
		return L_493;
	}

IL_0957:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_494 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_495;
		L_495 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_494, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_496 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_497;
		L_497 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_496, NULL);
		bool L_498;
		L_498 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_495, L_497, NULL);
		if (!L_498)
		{
			goto IL_09a2;
		}
	}
	{
		int32_t L_499 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_500 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_501 = (int64_t*)(&L_500->___int64_0_58);
		int32_t L_502;
		L_502 = Int64_GetHashCode_mDB050BE2AC244D92B14D1DF725AAD279CDC48496(L_501, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_503;
		L_503 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_499, L_502, NULL);
		V_0 = L_503;
		int32_t L_504 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_505 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_506 = (int64_t*)(&L_505->___int64_1_59);
		int32_t L_507;
		L_507 = Int64_GetHashCode_mDB050BE2AC244D92B14D1DF725AAD279CDC48496(L_506, NULL);
		int32_t L_508;
		L_508 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_504, L_507, NULL);
		V_0 = L_508;
		int32_t L_509 = V_0;
		return L_509;
	}

IL_09a2:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_510 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_511;
		L_511 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_510, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_512 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_513;
		L_513 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_512, NULL);
		bool L_514;
		L_514 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_511, L_513, NULL);
		if (!L_514)
		{
			goto IL_0a1b;
		}
	}
	{
		int32_t L_515 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_516 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_517 = (float*)(&L_516->___single_0_60);
		int32_t L_518;
		L_518 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_517, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_519;
		L_519 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_515, L_518, NULL);
		V_0 = L_519;
		int32_t L_520 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_521 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_522 = (float*)(&L_521->___single_1_61);
		int32_t L_523;
		L_523 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_522, NULL);
		int32_t L_524;
		L_524 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_520, L_523, NULL);
		V_0 = L_524;
		int32_t L_525 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_526 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_527 = (float*)(&L_526->___single_2_62);
		int32_t L_528;
		L_528 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_527, NULL);
		int32_t L_529;
		L_529 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_525, L_528, NULL);
		V_0 = L_529;
		int32_t L_530 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_531 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_532 = (float*)(&L_531->___single_3_63);
		int32_t L_533;
		L_533 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_532, NULL);
		int32_t L_534;
		L_534 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_530, L_533, NULL);
		V_0 = L_534;
		int32_t L_535 = V_0;
		return L_535;
	}

IL_0a1b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_536 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_537;
		L_537 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_536, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_538 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_539;
		L_539 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_538, NULL);
		bool L_540;
		L_540 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_537, L_539, NULL);
		if (!L_540)
		{
			goto IL_0a66;
		}
	}
	{
		int32_t L_541 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_542 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_543 = (double*)(&L_542->___double_0_64);
		int32_t L_544;
		L_544 = Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline(L_543, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_545;
		L_545 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_541, L_544, NULL);
		V_0 = L_545;
		int32_t L_546 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_547 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_548 = (double*)(&L_547->___double_1_65);
		int32_t L_549;
		L_549 = Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline(L_548, NULL);
		int32_t L_550;
		L_550 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_546, L_549, NULL);
		V_0 = L_550;
		int32_t L_551 = V_0;
		return L_551;
	}

IL_0a66:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_552 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_552);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_552, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_552, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  int32_t Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = Vector_1_GetHashCode_mEC951E56E2DC500CF877DFAD5542E0920B73B00A(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_m3EBF88D3E195BD2C4B0D1CCBD9F71E32233CA4F4_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral3DCC6243286938BE75C3FA773B9BA71160A2E869);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* L_0;
		L_0 = CultureInfo_get_CurrentCulture_m43D1E4E50AB1F62ADC7C1884F28F918B53871522(NULL);
		String_t* L_1;
		L_1 = Vector_1_ToString_m8F20119DB8CF7117F2D6E4D165C4A843F7D3586C(__this, _stringLiteral3DCC6243286938BE75C3FA773B9BA71160A2E869, (RuntimeObject*)L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		return L_1;
	}
}
IL2CPP_EXTERN_C  String_t* Vector_1_ToString_m3EBF88D3E195BD2C4B0D1CCBD9F71E32233CA4F4_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	String_t* _returnValue;
	_returnValue = Vector_1_ToString_m3EBF88D3E195BD2C4B0D1CCBD9F71E32233CA4F4(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_m8F20119DB8CF7117F2D6E4D165C4A843F7D3586C_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringBuilder_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t* V_0 = NULL;
	String_t* V_1 = NULL;
	int32_t V_2 = 0;
	{
		StringBuilder_t* L_0 = (StringBuilder_t*)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		StringBuilder__ctor_m1D99713357DE05DAFA296633639DB55F8C30587D(L_0, NULL);
		V_0 = L_0;
		RuntimeObject* L_1 = ___formatProvider1;
		NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* L_2;
		L_2 = NumberFormatInfo_GetInstance_m68D84692285114DC53C752EFC2A559319D117E71(L_1, NULL);
		NullCheck(L_2);
		String_t* L_3;
		L_3 = NumberFormatInfo_get_NumberGroupSeparator_m0556B092AA471513B1EDC31C047712226D39BEB6_inline(L_2, NULL);
		V_1 = L_3;
		StringBuilder_t* L_4 = V_0;
		NullCheck(L_4);
		StringBuilder_t* L_5;
		L_5 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_4, (Il2CppChar)((int32_t)60), NULL);
		V_2 = 0;
		goto IL_0053;
	}

IL_001f:
	{
		StringBuilder_t* L_6 = V_0;
		int32_t L_7 = V_2;
		uint64_t L_8;
		L_8 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, L_7, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_9 = L_8;
		RuntimeObject* L_10 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_9);
		String_t* L_11 = ___format0;
		RuntimeObject* L_12 = ___formatProvider1;
		String_t* L_13;
		L_13 = InterfaceFuncInvoker2< String_t*, String_t*, RuntimeObject* >::Invoke(0, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var, (RuntimeObject*)L_10, L_11, L_12);
		NullCheck(L_6);
		StringBuilder_t* L_14;
		L_14 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_6, L_13, NULL);
		StringBuilder_t* L_15 = V_0;
		String_t* L_16 = V_1;
		NullCheck(L_15);
		StringBuilder_t* L_17;
		L_17 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_15, L_16, NULL);
		StringBuilder_t* L_18 = V_0;
		NullCheck(L_18);
		StringBuilder_t* L_19;
		L_19 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_18, (Il2CppChar)((int32_t)32), NULL);
		int32_t L_20 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_20, 1));
	}

IL_0053:
	{
		int32_t L_21 = V_2;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_22;
		L_22 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_21) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_22, 1)))))
		{
			goto IL_001f;
		}
	}
	{
		StringBuilder_t* L_23 = V_0;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_24;
		L_24 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		uint64_t L_25;
		L_25 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99(__this, ((int32_t)il2cpp_codegen_subtract(L_24, 1)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		uint64_t L_26 = L_25;
		RuntimeObject* L_27 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_26);
		String_t* L_28 = ___format0;
		RuntimeObject* L_29 = ___formatProvider1;
		String_t* L_30;
		L_30 = InterfaceFuncInvoker2< String_t*, String_t*, RuntimeObject* >::Invoke(0, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var, (RuntimeObject*)L_27, L_28, L_29);
		NullCheck(L_23);
		StringBuilder_t* L_31;
		L_31 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_23, L_30, NULL);
		StringBuilder_t* L_32 = V_0;
		NullCheck(L_32);
		StringBuilder_t* L_33;
		L_33 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_32, (Il2CppChar)((int32_t)62), NULL);
		StringBuilder_t* L_34 = V_0;
		NullCheck((RuntimeObject*)L_34);
		String_t* L_35;
		L_35 = VirtualFuncInvoker0< String_t* >::Invoke(3, (RuntimeObject*)L_34);
		return L_35;
	}
}
IL2CPP_EXTERN_C  String_t* Vector_1_ToString_m8F20119DB8CF7117F2D6E4D165C4A843F7D3586C_AdjustorThunk (RuntimeObject* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method)
{
	Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*>(__this + _offset);
	String_t* _returnValue;
	_returnValue = Vector_1_ToString_m8F20119DB8CF7117F2D6E4D165C4A843F7D3586C(_thisAdjusted, ___format0, ___formatProvider1, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_op_Equality_m50B11C67F1AC4D10224413FBF3AC098A8037A021_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___left0, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___right1, const RuntimeMethod* method) 
{
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_0 = ___right1;
		bool L_1;
		L_1 = Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27((&___left0), L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7));
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_op_Inequality_mB9560FFED6504577A90DE401CCB66884F374DD49_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___left0, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___right1, const RuntimeMethod* method) 
{
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_0 = ___left0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_1 = ___right1;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_2;
		L_2 = Vector_1_op_Equality_m50B11C67F1AC4D10224413FBF3AC098A8037A021_inline(L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		return (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A Vector_1_op_Explicit_m71D830D002EEB80F466F971F5693D3364E7E78A7_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_0 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&(&___value0)->___register_0);
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_1;
		memset((&L_1), 0, sizeof(L_1));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_1), L_0, Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_RuntimeMethod_var);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_gshared (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___left0, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___right1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	uint8_t* V_0 = NULL;
	int32_t V_1 = 0;
	int8_t* V_2 = NULL;
	int32_t V_3 = 0;
	uint16_t* V_4 = NULL;
	int32_t V_5 = 0;
	int16_t* V_6 = NULL;
	int32_t V_7 = 0;
	uint32_t* V_8 = NULL;
	int32_t V_9 = 0;
	int32_t* V_10 = NULL;
	int32_t V_11 = 0;
	uint64_t* V_12 = NULL;
	int32_t V_13 = 0;
	int64_t* V_14 = NULL;
	int32_t V_15 = 0;
	float* V_16 = NULL;
	int32_t V_17 = 0;
	double* V_18 = NULL;
	int32_t V_19 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A V_20;
	memset((&V_20), 0, sizeof(V_20));
	uint8_t* G_B5_0 = NULL;
	uint8_t* G_B4_0 = NULL;
	int32_t G_B6_0 = 0;
	uint8_t* G_B6_1 = NULL;
	int8_t* G_B13_0 = NULL;
	int8_t* G_B12_0 = NULL;
	int32_t G_B14_0 = 0;
	int8_t* G_B14_1 = NULL;
	uint16_t* G_B21_0 = NULL;
	uint16_t* G_B20_0 = NULL;
	int32_t G_B22_0 = 0;
	uint16_t* G_B22_1 = NULL;
	int16_t* G_B29_0 = NULL;
	int16_t* G_B28_0 = NULL;
	int32_t G_B30_0 = 0;
	int16_t* G_B30_1 = NULL;
	uint32_t* G_B37_0 = NULL;
	uint32_t* G_B36_0 = NULL;
	uint32_t G_B38_0 = 0;
	uint32_t* G_B38_1 = NULL;
	int32_t* G_B45_0 = NULL;
	int32_t* G_B44_0 = NULL;
	int32_t G_B46_0 = 0;
	int32_t* G_B46_1 = NULL;
	uint64_t* G_B53_0 = NULL;
	uint64_t* G_B52_0 = NULL;
	uint64_t G_B54_0 = 0;
	uint64_t* G_B54_1 = NULL;
	int64_t* G_B61_0 = NULL;
	int64_t* G_B60_0 = NULL;
	int64_t G_B62_0 = 0;
	int64_t* G_B62_1 = NULL;
	float* G_B69_0 = NULL;
	float* G_B68_0 = NULL;
	float G_B70_0 = 0.0f;
	float* G_B70_1 = NULL;
	double* G_B77_0 = NULL;
	double* G_B76_0 = NULL;
	double G_B78_0 = 0.0;
	double* G_B78_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B85_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B84_0 = NULL;
	int32_t G_B86_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B86_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B88_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B87_0 = NULL;
	int32_t G_B89_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B89_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B91_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B90_0 = NULL;
	int32_t G_B92_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B92_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B94_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B93_0 = NULL;
	int32_t G_B95_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B95_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B97_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B96_0 = NULL;
	int32_t G_B98_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B98_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B100_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B99_0 = NULL;
	int32_t G_B101_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B101_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B103_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B102_0 = NULL;
	int32_t G_B104_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B104_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B106_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B105_0 = NULL;
	int32_t G_B107_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B107_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B109_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B108_0 = NULL;
	int32_t G_B110_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B110_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B112_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B111_0 = NULL;
	int32_t G_B113_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B113_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B115_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B114_0 = NULL;
	int32_t G_B116_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B116_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B118_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B117_0 = NULL;
	int32_t G_B119_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B119_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B121_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B120_0 = NULL;
	int32_t G_B122_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B122_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B124_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B123_0 = NULL;
	int32_t G_B125_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B125_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B127_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B126_0 = NULL;
	int32_t G_B128_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B128_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B130_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B129_0 = NULL;
	int32_t G_B131_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B131_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B135_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B134_0 = NULL;
	int32_t G_B136_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B136_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B138_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B137_0 = NULL;
	int32_t G_B139_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B139_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B141_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B140_0 = NULL;
	int32_t G_B142_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B142_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B144_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B143_0 = NULL;
	int32_t G_B145_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B145_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B147_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B146_0 = NULL;
	int32_t G_B148_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B148_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B150_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B149_0 = NULL;
	int32_t G_B151_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B151_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B153_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B152_0 = NULL;
	int32_t G_B154_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B154_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B156_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B155_0 = NULL;
	int32_t G_B157_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B157_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B159_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B158_0 = NULL;
	int32_t G_B160_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B160_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B162_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B161_0 = NULL;
	int32_t G_B163_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B163_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B165_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B164_0 = NULL;
	int32_t G_B166_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B166_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B168_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B167_0 = NULL;
	int32_t G_B169_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B169_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B171_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B170_0 = NULL;
	int32_t G_B172_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B172_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B174_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B173_0 = NULL;
	int32_t G_B175_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B175_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B177_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B176_0 = NULL;
	int32_t G_B178_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B178_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B180_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B179_0 = NULL;
	int32_t G_B181_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B181_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B185_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B184_0 = NULL;
	int32_t G_B186_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B186_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B188_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B187_0 = NULL;
	int32_t G_B189_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B189_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B191_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B190_0 = NULL;
	int32_t G_B192_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B192_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B194_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B193_0 = NULL;
	int32_t G_B195_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B195_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B197_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B196_0 = NULL;
	int32_t G_B198_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B198_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B200_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B199_0 = NULL;
	int32_t G_B201_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B201_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B203_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B202_0 = NULL;
	int32_t G_B204_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B204_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B206_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B205_0 = NULL;
	int32_t G_B207_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B207_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B211_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B210_0 = NULL;
	int32_t G_B212_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B212_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B214_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B213_0 = NULL;
	int32_t G_B215_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B215_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B217_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B216_0 = NULL;
	int32_t G_B218_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B218_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B220_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B219_0 = NULL;
	int32_t G_B221_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B221_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B223_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B222_0 = NULL;
	int32_t G_B224_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B224_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B226_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B225_0 = NULL;
	int32_t G_B227_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B227_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B229_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B228_0 = NULL;
	int32_t G_B230_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B230_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B232_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B231_0 = NULL;
	int32_t G_B233_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B233_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B237_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B236_0 = NULL;
	uint32_t G_B238_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B238_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B240_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B239_0 = NULL;
	uint32_t G_B241_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B241_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B243_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B242_0 = NULL;
	uint32_t G_B244_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B244_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B246_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B245_0 = NULL;
	uint32_t G_B247_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B247_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B251_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B250_0 = NULL;
	int32_t G_B252_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B252_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B254_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B253_0 = NULL;
	int32_t G_B255_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B255_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B257_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B256_0 = NULL;
	int32_t G_B258_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B258_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B260_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B259_0 = NULL;
	int32_t G_B261_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B261_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B265_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B264_0 = NULL;
	uint64_t G_B266_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B266_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B268_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B267_0 = NULL;
	uint64_t G_B269_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B269_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B273_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B272_0 = NULL;
	int64_t G_B274_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B274_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B276_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B275_0 = NULL;
	int64_t G_B277_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B277_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B281_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B280_0 = NULL;
	float G_B282_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B282_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B284_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B283_0 = NULL;
	float G_B285_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B285_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B287_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B286_0 = NULL;
	float G_B288_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B288_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B290_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B289_0 = NULL;
	float G_B291_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B291_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B295_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B294_0 = NULL;
	double G_B296_0 = 0.0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B296_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B298_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B297_0 = NULL;
	double G_B299_0 = 0.0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B299_1 = NULL;
	{
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_0447;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_3, NULL);
		bool L_5;
		L_5 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_2, L_4, NULL);
		if (!L_5)
		{
			goto IL_0068;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_6;
		L_6 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		int8_t* L_7 = (int8_t*) alloca(((uintptr_t)L_6));
		memset(L_7, 0, ((uintptr_t)L_6));
		V_0 = (uint8_t*)(L_7);
		V_1 = 0;
		goto IL_0059;
	}

IL_0032:
	{
		uint8_t* L_8 = V_0;
		int32_t L_9 = V_1;
		int32_t L_10 = V_1;
		uint64_t L_11;
		L_11 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_12 = V_1;
		uint64_t L_13;
		L_13 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_12, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_14;
		L_14 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_11, L_13, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B4_0 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_8, L_9));
		if (L_14)
		{
			G_B5_0 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_8, L_9));
			goto IL_004f;
		}
	}
	{
		G_B6_0 = 0;
		G_B6_1 = G_B4_0;
		goto IL_0054;
	}

IL_004f:
	{
		uint8_t L_15;
		L_15 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B6_0 = ((int32_t)(L_15));
		G_B6_1 = G_B5_0;
	}

IL_0054:
	{
		*((int8_t*)G_B6_1) = (int8_t)G_B6_0;
		int32_t L_16 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_16, 1));
	}

IL_0059:
	{
		int32_t L_17 = V_1;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_18;
		L_18 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_17) < ((int32_t)L_18)))
		{
			goto IL_0032;
		}
	}
	{
		uint8_t* L_19 = V_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_20;
		memset((&L_20), 0, sizeof(L_20));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_20), (void*)L_19, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_20;
	}

IL_0068:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_21 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_22;
		L_22 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_21, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_23 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_24;
		L_24 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_23, NULL);
		bool L_25;
		L_25 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_22, L_24, NULL);
		if (!L_25)
		{
			goto IL_00c6;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_26;
		L_26 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		int8_t* L_27 = (int8_t*) alloca(((uintptr_t)L_26));
		memset(L_27, 0, ((uintptr_t)L_26));
		V_2 = (L_27);
		V_3 = 0;
		goto IL_00b7;
	}

IL_0090:
	{
		int8_t* L_28 = V_2;
		int32_t L_29 = V_3;
		int32_t L_30 = V_3;
		uint64_t L_31;
		L_31 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_30, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_32 = V_3;
		uint64_t L_33;
		L_33 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_32, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_34;
		L_34 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_31, L_33, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B12_0 = ((int8_t*)il2cpp_codegen_add((intptr_t)L_28, L_29));
		if (L_34)
		{
			G_B13_0 = ((int8_t*)il2cpp_codegen_add((intptr_t)L_28, L_29));
			goto IL_00ad;
		}
	}
	{
		G_B14_0 = 0;
		G_B14_1 = G_B12_0;
		goto IL_00b2;
	}

IL_00ad:
	{
		int8_t L_35;
		L_35 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B14_0 = ((int32_t)(L_35));
		G_B14_1 = G_B13_0;
	}

IL_00b2:
	{
		*((int8_t*)G_B14_1) = (int8_t)G_B14_0;
		int32_t L_36 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_3;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_38;
		L_38 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_37) < ((int32_t)L_38)))
		{
			goto IL_0090;
		}
	}
	{
		int8_t* L_39 = V_2;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_40;
		memset((&L_40), 0, sizeof(L_40));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_40), (void*)L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_40;
	}

IL_00c6:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_41 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_42;
		L_42 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_41, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_43 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_44;
		L_44 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_43, NULL);
		bool L_45;
		L_45 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_42, L_44, NULL);
		if (!L_45)
		{
			goto IL_0133;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_46;
		L_46 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_46) * (uintptr_t)2 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_47 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_46), 2)));
		memset(L_47, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_46), 2)));
		V_4 = (uint16_t*)(L_47);
		V_5 = 0;
		goto IL_0122;
	}

IL_00f2:
	{
		uint16_t* L_48 = V_4;
		int32_t L_49 = V_5;
		int32_t L_50 = V_5;
		uint64_t L_51;
		L_51 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_50, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_52 = V_5;
		uint64_t L_53;
		L_53 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_52, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_54;
		L_54 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_51, L_53, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B20_0 = ((uint16_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 2))));
		if (L_54)
		{
			G_B21_0 = ((uint16_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 2))));
			goto IL_0116;
		}
	}
	{
		G_B22_0 = 0;
		G_B22_1 = G_B20_0;
		goto IL_011b;
	}

IL_0116:
	{
		uint16_t L_55;
		L_55 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B22_0 = ((int32_t)(L_55));
		G_B22_1 = G_B21_0;
	}

IL_011b:
	{
		*((int16_t*)G_B22_1) = (int16_t)G_B22_0;
		int32_t L_56 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_56, 1));
	}

IL_0122:
	{
		int32_t L_57 = V_5;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_58;
		L_58 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_57) < ((int32_t)L_58)))
		{
			goto IL_00f2;
		}
	}
	{
		uint16_t* L_59 = V_4;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_60;
		memset((&L_60), 0, sizeof(L_60));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_60), (void*)L_59, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_60;
	}

IL_0133:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_61 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_62;
		L_62 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_61, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		bool L_65;
		L_65 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_62, L_64, NULL);
		if (!L_65)
		{
			goto IL_01a0;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_66;
		L_66 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_66) * (uintptr_t)2 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_67 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_66), 2)));
		memset(L_67, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_66), 2)));
		V_6 = (int16_t*)(L_67);
		V_7 = 0;
		goto IL_018f;
	}

IL_015f:
	{
		int16_t* L_68 = V_6;
		int32_t L_69 = V_7;
		int32_t L_70 = V_7;
		uint64_t L_71;
		L_71 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_70, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_72 = V_7;
		uint64_t L_73;
		L_73 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_74;
		L_74 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_71, L_73, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B28_0 = ((int16_t*)il2cpp_codegen_add((intptr_t)L_68, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_69), 2))));
		if (L_74)
		{
			G_B29_0 = ((int16_t*)il2cpp_codegen_add((intptr_t)L_68, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_69), 2))));
			goto IL_0183;
		}
	}
	{
		G_B30_0 = 0;
		G_B30_1 = G_B28_0;
		goto IL_0188;
	}

IL_0183:
	{
		int16_t L_75;
		L_75 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B30_0 = ((int32_t)(L_75));
		G_B30_1 = G_B29_0;
	}

IL_0188:
	{
		*((int16_t*)G_B30_1) = (int16_t)G_B30_0;
		int32_t L_76 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_76, 1));
	}

IL_018f:
	{
		int32_t L_77 = V_7;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_78;
		L_78 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_77) < ((int32_t)L_78)))
		{
			goto IL_015f;
		}
	}
	{
		int16_t* L_79 = V_6;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_80;
		memset((&L_80), 0, sizeof(L_80));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_80), (void*)L_79, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_80;
	}

IL_01a0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_81 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_82;
		L_82 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_81, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_83 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_84;
		L_84 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_83, NULL);
		bool L_85;
		L_85 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_82, L_84, NULL);
		if (!L_85)
		{
			goto IL_020d;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_86;
		L_86 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_86) * (uintptr_t)4 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_87 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_86), 4)));
		memset(L_87, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_86), 4)));
		V_8 = (uint32_t*)(L_87);
		V_9 = 0;
		goto IL_01fc;
	}

IL_01cc:
	{
		uint32_t* L_88 = V_8;
		int32_t L_89 = V_9;
		int32_t L_90 = V_9;
		uint64_t L_91;
		L_91 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_90, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_92 = V_9;
		uint64_t L_93;
		L_93 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_92, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_94;
		L_94 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_91, L_93, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B36_0 = ((uint32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))));
		if (L_94)
		{
			G_B37_0 = ((uint32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))));
			goto IL_01f0;
		}
	}
	{
		G_B38_0 = ((uint32_t)(0));
		G_B38_1 = G_B36_0;
		goto IL_01f5;
	}

IL_01f0:
	{
		uint32_t L_95;
		L_95 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B38_0 = L_95;
		G_B38_1 = G_B37_0;
	}

IL_01f5:
	{
		*((int32_t*)G_B38_1) = (int32_t)G_B38_0;
		int32_t L_96 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_96, 1));
	}

IL_01fc:
	{
		int32_t L_97 = V_9;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_98;
		L_98 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_97) < ((int32_t)L_98)))
		{
			goto IL_01cc;
		}
	}
	{
		uint32_t* L_99 = V_8;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_100;
		memset((&L_100), 0, sizeof(L_100));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_100), (void*)L_99, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_100;
	}

IL_020d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_101 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_102;
		L_102 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_101, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_103 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_104;
		L_104 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_103, NULL);
		bool L_105;
		L_105 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_102, L_104, NULL);
		if (!L_105)
		{
			goto IL_027a;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_106;
		L_106 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_106) * (uintptr_t)4 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_107 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_106), 4)));
		memset(L_107, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_106), 4)));
		V_10 = (int32_t*)(L_107);
		V_11 = 0;
		goto IL_0269;
	}

IL_0239:
	{
		int32_t* L_108 = V_10;
		int32_t L_109 = V_11;
		int32_t L_110 = V_11;
		uint64_t L_111;
		L_111 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_110, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_112 = V_11;
		uint64_t L_113;
		L_113 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_112, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_114;
		L_114 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_111, L_113, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B44_0 = ((int32_t*)il2cpp_codegen_add((intptr_t)L_108, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_109), 4))));
		if (L_114)
		{
			G_B45_0 = ((int32_t*)il2cpp_codegen_add((intptr_t)L_108, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_109), 4))));
			goto IL_025d;
		}
	}
	{
		G_B46_0 = 0;
		G_B46_1 = G_B44_0;
		goto IL_0262;
	}

IL_025d:
	{
		int32_t L_115;
		L_115 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B46_0 = L_115;
		G_B46_1 = G_B45_0;
	}

IL_0262:
	{
		*((int32_t*)G_B46_1) = (int32_t)G_B46_0;
		int32_t L_116 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_116, 1));
	}

IL_0269:
	{
		int32_t L_117 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_118;
		L_118 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_117) < ((int32_t)L_118)))
		{
			goto IL_0239;
		}
	}
	{
		int32_t* L_119 = V_10;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_120;
		memset((&L_120), 0, sizeof(L_120));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_120), (void*)L_119, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_120;
	}

IL_027a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_121 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_122;
		L_122 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_121, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_123 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_124;
		L_124 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_123, NULL);
		bool L_125;
		L_125 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_122, L_124, NULL);
		if (!L_125)
		{
			goto IL_02e8;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_126;
		L_126 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_126) * (uintptr_t)8 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_127 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_126), 8)));
		memset(L_127, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_126), 8)));
		V_12 = (uint64_t*)(L_127);
		V_13 = 0;
		goto IL_02d7;
	}

IL_02a6:
	{
		uint64_t* L_128 = V_12;
		int32_t L_129 = V_13;
		int32_t L_130 = V_13;
		uint64_t L_131;
		L_131 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_130, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_132 = V_13;
		uint64_t L_133;
		L_133 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_132, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_134;
		L_134 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_131, L_133, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B52_0 = ((uint64_t*)il2cpp_codegen_add((intptr_t)L_128, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_129), 8))));
		if (L_134)
		{
			G_B53_0 = ((uint64_t*)il2cpp_codegen_add((intptr_t)L_128, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_129), 8))));
			goto IL_02cb;
		}
	}
	{
		G_B54_0 = ((uint64_t)(((int64_t)0)));
		G_B54_1 = G_B52_0;
		goto IL_02d0;
	}

IL_02cb:
	{
		uint64_t L_135;
		L_135 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		G_B54_0 = L_135;
		G_B54_1 = G_B53_0;
	}

IL_02d0:
	{
		*((int64_t*)G_B54_1) = (int64_t)G_B54_0;
		int32_t L_136 = V_13;
		V_13 = ((int32_t)il2cpp_codegen_add(L_136, 1));
	}

IL_02d7:
	{
		int32_t L_137 = V_13;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_138;
		L_138 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_137) < ((int32_t)L_138)))
		{
			goto IL_02a6;
		}
	}
	{
		uint64_t* L_139 = V_12;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_140;
		memset((&L_140), 0, sizeof(L_140));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_140), (void*)L_139, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_140;
	}

IL_02e8:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_141 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_142;
		L_142 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_141, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_143 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_144;
		L_144 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_143, NULL);
		bool L_145;
		L_145 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_142, L_144, NULL);
		if (!L_145)
		{
			goto IL_0356;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_146;
		L_146 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_146) * (uintptr_t)8 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_147 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_146), 8)));
		memset(L_147, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_146), 8)));
		V_14 = (int64_t*)(L_147);
		V_15 = 0;
		goto IL_0345;
	}

IL_0314:
	{
		int64_t* L_148 = V_14;
		int32_t L_149 = V_15;
		int32_t L_150 = V_15;
		uint64_t L_151;
		L_151 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_150, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_152 = V_15;
		uint64_t L_153;
		L_153 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_152, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_154;
		L_154 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_151, L_153, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B60_0 = ((int64_t*)il2cpp_codegen_add((intptr_t)L_148, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_149), 8))));
		if (L_154)
		{
			G_B61_0 = ((int64_t*)il2cpp_codegen_add((intptr_t)L_148, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_149), 8))));
			goto IL_0339;
		}
	}
	{
		G_B62_0 = ((int64_t)0);
		G_B62_1 = G_B60_0;
		goto IL_033e;
	}

IL_0339:
	{
		int64_t L_155;
		L_155 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		G_B62_0 = L_155;
		G_B62_1 = G_B61_0;
	}

IL_033e:
	{
		*((int64_t*)G_B62_1) = (int64_t)G_B62_0;
		int32_t L_156 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_add(L_156, 1));
	}

IL_0345:
	{
		int32_t L_157 = V_15;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_158;
		L_158 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_157) < ((int32_t)L_158)))
		{
			goto IL_0314;
		}
	}
	{
		int64_t* L_159 = V_14;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_160;
		memset((&L_160), 0, sizeof(L_160));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_160), (void*)L_159, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_160;
	}

IL_0356:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_161 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_162;
		L_162 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_161, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_163 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_164;
		L_164 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_163, NULL);
		bool L_165;
		L_165 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_162, L_164, NULL);
		if (!L_165)
		{
			goto IL_03c7;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_166;
		L_166 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_166) * (uintptr_t)4 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_167 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_166), 4)));
		memset(L_167, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_166), 4)));
		V_16 = (float*)(L_167);
		V_17 = 0;
		goto IL_03b6;
	}

IL_0382:
	{
		float* L_168 = V_16;
		int32_t L_169 = V_17;
		int32_t L_170 = V_17;
		uint64_t L_171;
		L_171 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_170, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_172 = V_17;
		uint64_t L_173;
		L_173 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_172, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_174;
		L_174 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_171, L_173, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B68_0 = ((float*)il2cpp_codegen_add((intptr_t)L_168, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_169), 4))));
		if (L_174)
		{
			G_B69_0 = ((float*)il2cpp_codegen_add((intptr_t)L_168, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_169), 4))));
			goto IL_03aa;
		}
	}
	{
		G_B70_0 = (0.0f);
		G_B70_1 = G_B68_0;
		goto IL_03af;
	}

IL_03aa:
	{
		float L_175;
		L_175 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B70_0 = L_175;
		G_B70_1 = G_B69_0;
	}

IL_03af:
	{
		*((float*)G_B70_1) = (float)G_B70_0;
		int32_t L_176 = V_17;
		V_17 = ((int32_t)il2cpp_codegen_add(L_176, 1));
	}

IL_03b6:
	{
		int32_t L_177 = V_17;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_178;
		L_178 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_177) < ((int32_t)L_178)))
		{
			goto IL_0382;
		}
	}
	{
		float* L_179 = V_16;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_180;
		memset((&L_180), 0, sizeof(L_180));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_180), (void*)L_179, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_180;
	}

IL_03c7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_181 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_182;
		L_182 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_181, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_183 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_184;
		L_184 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_183, NULL);
		bool L_185;
		L_185 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_182, L_184, NULL);
		if (!L_185)
		{
			goto IL_043c;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_186;
		L_186 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_186) * (uintptr_t)8 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var);
		int8_t* L_187 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_186), 8)));
		memset(L_187, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_186), 8)));
		V_18 = (double*)(L_187);
		V_19 = 0;
		goto IL_042b;
	}

IL_03f3:
	{
		double* L_188 = V_18;
		int32_t L_189 = V_19;
		int32_t L_190 = V_19;
		uint64_t L_191;
		L_191 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___left0), L_190, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_192 = V_19;
		uint64_t L_193;
		L_193 = Vector_1_get_Item_m685EA4A01E8AF51DC7B5F78DE0583F8FD4997C99((&___right1), L_192, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_194;
		L_194 = Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_inline(L_191, L_193, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		G_B76_0 = ((double*)il2cpp_codegen_add((intptr_t)L_188, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_189), 8))));
		if (L_194)
		{
			G_B77_0 = ((double*)il2cpp_codegen_add((intptr_t)L_188, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_189), 8))));
			goto IL_041f;
		}
	}
	{
		G_B78_0 = (0.0);
		G_B78_1 = G_B76_0;
		goto IL_0424;
	}

IL_041f:
	{
		double L_195;
		L_195 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		G_B78_0 = L_195;
		G_B78_1 = G_B77_0;
	}

IL_0424:
	{
		*((double*)G_B78_1) = (double)G_B78_0;
		int32_t L_196 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_196, 1));
	}

IL_042b:
	{
		int32_t L_197 = V_19;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_198;
		L_198 = Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_197) < ((int32_t)L_198)))
		{
			goto IL_03f3;
		}
	}
	{
		double* L_199 = V_18;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_200;
		memset((&L_200), 0, sizeof(L_200));
		Vector_1__ctor_mBEC18AF78DE340D929AD22019717DE9ED57A4CCA((&L_200), (void*)L_199, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_200;
	}

IL_043c:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_201 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_201);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_201, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_201, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var)));
	}

IL_0447:
	{
		il2cpp_codegen_initobj((&V_20), sizeof(Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A));
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_202 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_203;
		L_203 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_202, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_204 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_205;
		L_205 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_204, NULL);
		bool L_206;
		L_206 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_203, L_205, NULL);
		if (!L_206)
		{
			goto IL_06e5;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_207 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_208 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_207.___register_0;
		uint8_t L_209 = (uint8_t)L_208.___byte_0_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_210 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_211 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_210.___register_0;
		uint8_t L_212 = (uint8_t)L_211.___byte_0_0;
		G_B84_0 = (&V_20);
		if ((((int32_t)L_209) == ((int32_t)L_212)))
		{
			G_B85_0 = (&V_20);
			goto IL_048a;
		}
	}
	{
		G_B86_0 = 0;
		G_B86_1 = G_B84_0;
		goto IL_048f;
	}

IL_048a:
	{
		uint8_t L_213;
		L_213 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B86_0 = ((int32_t)(L_213));
		G_B86_1 = G_B85_0;
	}

IL_048f:
	{
		G_B86_1->___byte_0_0 = (uint8_t)G_B86_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_214 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_215 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_214.___register_0;
		uint8_t L_216 = (uint8_t)L_215.___byte_1_1;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_217 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_218 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_217.___register_0;
		uint8_t L_219 = (uint8_t)L_218.___byte_1_1;
		G_B87_0 = (&V_20);
		if ((((int32_t)L_216) == ((int32_t)L_219)))
		{
			G_B88_0 = (&V_20);
			goto IL_04b1;
		}
	}
	{
		G_B89_0 = 0;
		G_B89_1 = G_B87_0;
		goto IL_04b6;
	}

IL_04b1:
	{
		uint8_t L_220;
		L_220 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B89_0 = ((int32_t)(L_220));
		G_B89_1 = G_B88_0;
	}

IL_04b6:
	{
		G_B89_1->___byte_1_1 = (uint8_t)G_B89_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_221 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_222 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_221.___register_0;
		uint8_t L_223 = (uint8_t)L_222.___byte_2_2;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_224 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_225 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_224.___register_0;
		uint8_t L_226 = (uint8_t)L_225.___byte_2_2;
		G_B90_0 = (&V_20);
		if ((((int32_t)L_223) == ((int32_t)L_226)))
		{
			G_B91_0 = (&V_20);
			goto IL_04d8;
		}
	}
	{
		G_B92_0 = 0;
		G_B92_1 = G_B90_0;
		goto IL_04dd;
	}

IL_04d8:
	{
		uint8_t L_227;
		L_227 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B92_0 = ((int32_t)(L_227));
		G_B92_1 = G_B91_0;
	}

IL_04dd:
	{
		G_B92_1->___byte_2_2 = (uint8_t)G_B92_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_228 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_229 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_228.___register_0;
		uint8_t L_230 = (uint8_t)L_229.___byte_3_3;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_231 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_232 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_231.___register_0;
		uint8_t L_233 = (uint8_t)L_232.___byte_3_3;
		G_B93_0 = (&V_20);
		if ((((int32_t)L_230) == ((int32_t)L_233)))
		{
			G_B94_0 = (&V_20);
			goto IL_04ff;
		}
	}
	{
		G_B95_0 = 0;
		G_B95_1 = G_B93_0;
		goto IL_0504;
	}

IL_04ff:
	{
		uint8_t L_234;
		L_234 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B95_0 = ((int32_t)(L_234));
		G_B95_1 = G_B94_0;
	}

IL_0504:
	{
		G_B95_1->___byte_3_3 = (uint8_t)G_B95_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_235 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_236 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_235.___register_0;
		uint8_t L_237 = (uint8_t)L_236.___byte_4_4;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_238 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_239 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_238.___register_0;
		uint8_t L_240 = (uint8_t)L_239.___byte_4_4;
		G_B96_0 = (&V_20);
		if ((((int32_t)L_237) == ((int32_t)L_240)))
		{
			G_B97_0 = (&V_20);
			goto IL_0526;
		}
	}
	{
		G_B98_0 = 0;
		G_B98_1 = G_B96_0;
		goto IL_052b;
	}

IL_0526:
	{
		uint8_t L_241;
		L_241 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B98_0 = ((int32_t)(L_241));
		G_B98_1 = G_B97_0;
	}

IL_052b:
	{
		G_B98_1->___byte_4_4 = (uint8_t)G_B98_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_242 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_243 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_242.___register_0;
		uint8_t L_244 = (uint8_t)L_243.___byte_5_5;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_245 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_246 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_245.___register_0;
		uint8_t L_247 = (uint8_t)L_246.___byte_5_5;
		G_B99_0 = (&V_20);
		if ((((int32_t)L_244) == ((int32_t)L_247)))
		{
			G_B100_0 = (&V_20);
			goto IL_054d;
		}
	}
	{
		G_B101_0 = 0;
		G_B101_1 = G_B99_0;
		goto IL_0552;
	}

IL_054d:
	{
		uint8_t L_248;
		L_248 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B101_0 = ((int32_t)(L_248));
		G_B101_1 = G_B100_0;
	}

IL_0552:
	{
		G_B101_1->___byte_5_5 = (uint8_t)G_B101_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_249 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_250 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_249.___register_0;
		uint8_t L_251 = (uint8_t)L_250.___byte_6_6;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_252 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_253 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_252.___register_0;
		uint8_t L_254 = (uint8_t)L_253.___byte_6_6;
		G_B102_0 = (&V_20);
		if ((((int32_t)L_251) == ((int32_t)L_254)))
		{
			G_B103_0 = (&V_20);
			goto IL_0574;
		}
	}
	{
		G_B104_0 = 0;
		G_B104_1 = G_B102_0;
		goto IL_0579;
	}

IL_0574:
	{
		uint8_t L_255;
		L_255 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B104_0 = ((int32_t)(L_255));
		G_B104_1 = G_B103_0;
	}

IL_0579:
	{
		G_B104_1->___byte_6_6 = (uint8_t)G_B104_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_256 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_257 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_256.___register_0;
		uint8_t L_258 = (uint8_t)L_257.___byte_7_7;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_259 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_260 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_259.___register_0;
		uint8_t L_261 = (uint8_t)L_260.___byte_7_7;
		G_B105_0 = (&V_20);
		if ((((int32_t)L_258) == ((int32_t)L_261)))
		{
			G_B106_0 = (&V_20);
			goto IL_059b;
		}
	}
	{
		G_B107_0 = 0;
		G_B107_1 = G_B105_0;
		goto IL_05a0;
	}

IL_059b:
	{
		uint8_t L_262;
		L_262 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B107_0 = ((int32_t)(L_262));
		G_B107_1 = G_B106_0;
	}

IL_05a0:
	{
		G_B107_1->___byte_7_7 = (uint8_t)G_B107_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_263 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_264 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_263.___register_0;
		uint8_t L_265 = (uint8_t)L_264.___byte_8_8;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_266 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_267 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_266.___register_0;
		uint8_t L_268 = (uint8_t)L_267.___byte_8_8;
		G_B108_0 = (&V_20);
		if ((((int32_t)L_265) == ((int32_t)L_268)))
		{
			G_B109_0 = (&V_20);
			goto IL_05c2;
		}
	}
	{
		G_B110_0 = 0;
		G_B110_1 = G_B108_0;
		goto IL_05c7;
	}

IL_05c2:
	{
		uint8_t L_269;
		L_269 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B110_0 = ((int32_t)(L_269));
		G_B110_1 = G_B109_0;
	}

IL_05c7:
	{
		G_B110_1->___byte_8_8 = (uint8_t)G_B110_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_270 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_271 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_270.___register_0;
		uint8_t L_272 = (uint8_t)L_271.___byte_9_9;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_273 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_274 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_273.___register_0;
		uint8_t L_275 = (uint8_t)L_274.___byte_9_9;
		G_B111_0 = (&V_20);
		if ((((int32_t)L_272) == ((int32_t)L_275)))
		{
			G_B112_0 = (&V_20);
			goto IL_05e9;
		}
	}
	{
		G_B113_0 = 0;
		G_B113_1 = G_B111_0;
		goto IL_05ee;
	}

IL_05e9:
	{
		uint8_t L_276;
		L_276 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B113_0 = ((int32_t)(L_276));
		G_B113_1 = G_B112_0;
	}

IL_05ee:
	{
		G_B113_1->___byte_9_9 = (uint8_t)G_B113_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_277 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_278 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_277.___register_0;
		uint8_t L_279 = (uint8_t)L_278.___byte_10_10;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_280 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_281 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_280.___register_0;
		uint8_t L_282 = (uint8_t)L_281.___byte_10_10;
		G_B114_0 = (&V_20);
		if ((((int32_t)L_279) == ((int32_t)L_282)))
		{
			G_B115_0 = (&V_20);
			goto IL_0610;
		}
	}
	{
		G_B116_0 = 0;
		G_B116_1 = G_B114_0;
		goto IL_0615;
	}

IL_0610:
	{
		uint8_t L_283;
		L_283 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B116_0 = ((int32_t)(L_283));
		G_B116_1 = G_B115_0;
	}

IL_0615:
	{
		G_B116_1->___byte_10_10 = (uint8_t)G_B116_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_284 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_285 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_284.___register_0;
		uint8_t L_286 = (uint8_t)L_285.___byte_11_11;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_287 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_288 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_287.___register_0;
		uint8_t L_289 = (uint8_t)L_288.___byte_11_11;
		G_B117_0 = (&V_20);
		if ((((int32_t)L_286) == ((int32_t)L_289)))
		{
			G_B118_0 = (&V_20);
			goto IL_0637;
		}
	}
	{
		G_B119_0 = 0;
		G_B119_1 = G_B117_0;
		goto IL_063c;
	}

IL_0637:
	{
		uint8_t L_290;
		L_290 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B119_0 = ((int32_t)(L_290));
		G_B119_1 = G_B118_0;
	}

IL_063c:
	{
		G_B119_1->___byte_11_11 = (uint8_t)G_B119_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_291 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_292 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_291.___register_0;
		uint8_t L_293 = (uint8_t)L_292.___byte_12_12;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_294 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_295 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_294.___register_0;
		uint8_t L_296 = (uint8_t)L_295.___byte_12_12;
		G_B120_0 = (&V_20);
		if ((((int32_t)L_293) == ((int32_t)L_296)))
		{
			G_B121_0 = (&V_20);
			goto IL_065e;
		}
	}
	{
		G_B122_0 = 0;
		G_B122_1 = G_B120_0;
		goto IL_0663;
	}

IL_065e:
	{
		uint8_t L_297;
		L_297 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B122_0 = ((int32_t)(L_297));
		G_B122_1 = G_B121_0;
	}

IL_0663:
	{
		G_B122_1->___byte_12_12 = (uint8_t)G_B122_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_298 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_299 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_298.___register_0;
		uint8_t L_300 = (uint8_t)L_299.___byte_13_13;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_301 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_302 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_301.___register_0;
		uint8_t L_303 = (uint8_t)L_302.___byte_13_13;
		G_B123_0 = (&V_20);
		if ((((int32_t)L_300) == ((int32_t)L_303)))
		{
			G_B124_0 = (&V_20);
			goto IL_0685;
		}
	}
	{
		G_B125_0 = 0;
		G_B125_1 = G_B123_0;
		goto IL_068a;
	}

IL_0685:
	{
		uint8_t L_304;
		L_304 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B125_0 = ((int32_t)(L_304));
		G_B125_1 = G_B124_0;
	}

IL_068a:
	{
		G_B125_1->___byte_13_13 = (uint8_t)G_B125_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_305 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_306 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_305.___register_0;
		uint8_t L_307 = (uint8_t)L_306.___byte_14_14;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_308 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_309 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_308.___register_0;
		uint8_t L_310 = (uint8_t)L_309.___byte_14_14;
		G_B126_0 = (&V_20);
		if ((((int32_t)L_307) == ((int32_t)L_310)))
		{
			G_B127_0 = (&V_20);
			goto IL_06ac;
		}
	}
	{
		G_B128_0 = 0;
		G_B128_1 = G_B126_0;
		goto IL_06b1;
	}

IL_06ac:
	{
		uint8_t L_311;
		L_311 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B128_0 = ((int32_t)(L_311));
		G_B128_1 = G_B127_0;
	}

IL_06b1:
	{
		G_B128_1->___byte_14_14 = (uint8_t)G_B128_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_312 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_313 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_312.___register_0;
		uint8_t L_314 = (uint8_t)L_313.___byte_15_15;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_315 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_316 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_315.___register_0;
		uint8_t L_317 = (uint8_t)L_316.___byte_15_15;
		G_B129_0 = (&V_20);
		if ((((int32_t)L_314) == ((int32_t)L_317)))
		{
			G_B130_0 = (&V_20);
			goto IL_06d3;
		}
	}
	{
		G_B131_0 = 0;
		G_B131_1 = G_B129_0;
		goto IL_06d8;
	}

IL_06d3:
	{
		uint8_t L_318;
		L_318 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B131_0 = ((int32_t)(L_318));
		G_B131_1 = G_B130_0;
	}

IL_06d8:
	{
		G_B131_1->___byte_15_15 = (uint8_t)G_B131_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_319;
		memset((&L_319), 0, sizeof(L_319));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_319), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_319;
	}

IL_06e5:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_320 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_321;
		L_321 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_320, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_322 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_323;
		L_323 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_322, NULL);
		bool L_324;
		L_324 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_321, L_323, NULL);
		if (!L_324)
		{
			goto IL_097b;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_325 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_326 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_325.___register_0;
		int8_t L_327 = (int8_t)L_326.___sbyte_0_16;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_328 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_329 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_328.___register_0;
		int8_t L_330 = (int8_t)L_329.___sbyte_0_16;
		G_B134_0 = (&V_20);
		if ((((int32_t)L_327) == ((int32_t)L_330)))
		{
			G_B135_0 = (&V_20);
			goto IL_0720;
		}
	}
	{
		G_B136_0 = 0;
		G_B136_1 = G_B134_0;
		goto IL_0725;
	}

IL_0720:
	{
		int8_t L_331;
		L_331 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B136_0 = ((int32_t)(L_331));
		G_B136_1 = G_B135_0;
	}

IL_0725:
	{
		G_B136_1->___sbyte_0_16 = (int8_t)G_B136_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_332 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_333 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_332.___register_0;
		int8_t L_334 = (int8_t)L_333.___sbyte_1_17;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_335 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_336 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_335.___register_0;
		int8_t L_337 = (int8_t)L_336.___sbyte_1_17;
		G_B137_0 = (&V_20);
		if ((((int32_t)L_334) == ((int32_t)L_337)))
		{
			G_B138_0 = (&V_20);
			goto IL_0747;
		}
	}
	{
		G_B139_0 = 0;
		G_B139_1 = G_B137_0;
		goto IL_074c;
	}

IL_0747:
	{
		int8_t L_338;
		L_338 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B139_0 = ((int32_t)(L_338));
		G_B139_1 = G_B138_0;
	}

IL_074c:
	{
		G_B139_1->___sbyte_1_17 = (int8_t)G_B139_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_339 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_340 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_339.___register_0;
		int8_t L_341 = (int8_t)L_340.___sbyte_2_18;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_342 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_343 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_342.___register_0;
		int8_t L_344 = (int8_t)L_343.___sbyte_2_18;
		G_B140_0 = (&V_20);
		if ((((int32_t)L_341) == ((int32_t)L_344)))
		{
			G_B141_0 = (&V_20);
			goto IL_076e;
		}
	}
	{
		G_B142_0 = 0;
		G_B142_1 = G_B140_0;
		goto IL_0773;
	}

IL_076e:
	{
		int8_t L_345;
		L_345 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B142_0 = ((int32_t)(L_345));
		G_B142_1 = G_B141_0;
	}

IL_0773:
	{
		G_B142_1->___sbyte_2_18 = (int8_t)G_B142_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_346 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_347 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_346.___register_0;
		int8_t L_348 = (int8_t)L_347.___sbyte_3_19;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_349 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_350 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_349.___register_0;
		int8_t L_351 = (int8_t)L_350.___sbyte_3_19;
		G_B143_0 = (&V_20);
		if ((((int32_t)L_348) == ((int32_t)L_351)))
		{
			G_B144_0 = (&V_20);
			goto IL_0795;
		}
	}
	{
		G_B145_0 = 0;
		G_B145_1 = G_B143_0;
		goto IL_079a;
	}

IL_0795:
	{
		int8_t L_352;
		L_352 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B145_0 = ((int32_t)(L_352));
		G_B145_1 = G_B144_0;
	}

IL_079a:
	{
		G_B145_1->___sbyte_3_19 = (int8_t)G_B145_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_353 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_354 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_353.___register_0;
		int8_t L_355 = (int8_t)L_354.___sbyte_4_20;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_356 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_357 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_356.___register_0;
		int8_t L_358 = (int8_t)L_357.___sbyte_4_20;
		G_B146_0 = (&V_20);
		if ((((int32_t)L_355) == ((int32_t)L_358)))
		{
			G_B147_0 = (&V_20);
			goto IL_07bc;
		}
	}
	{
		G_B148_0 = 0;
		G_B148_1 = G_B146_0;
		goto IL_07c1;
	}

IL_07bc:
	{
		int8_t L_359;
		L_359 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B148_0 = ((int32_t)(L_359));
		G_B148_1 = G_B147_0;
	}

IL_07c1:
	{
		G_B148_1->___sbyte_4_20 = (int8_t)G_B148_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_360 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_361 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_360.___register_0;
		int8_t L_362 = (int8_t)L_361.___sbyte_5_21;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_363 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_364 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_363.___register_0;
		int8_t L_365 = (int8_t)L_364.___sbyte_5_21;
		G_B149_0 = (&V_20);
		if ((((int32_t)L_362) == ((int32_t)L_365)))
		{
			G_B150_0 = (&V_20);
			goto IL_07e3;
		}
	}
	{
		G_B151_0 = 0;
		G_B151_1 = G_B149_0;
		goto IL_07e8;
	}

IL_07e3:
	{
		int8_t L_366;
		L_366 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B151_0 = ((int32_t)(L_366));
		G_B151_1 = G_B150_0;
	}

IL_07e8:
	{
		G_B151_1->___sbyte_5_21 = (int8_t)G_B151_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_367 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_368 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_367.___register_0;
		int8_t L_369 = (int8_t)L_368.___sbyte_6_22;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_370 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_371 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_370.___register_0;
		int8_t L_372 = (int8_t)L_371.___sbyte_6_22;
		G_B152_0 = (&V_20);
		if ((((int32_t)L_369) == ((int32_t)L_372)))
		{
			G_B153_0 = (&V_20);
			goto IL_080a;
		}
	}
	{
		G_B154_0 = 0;
		G_B154_1 = G_B152_0;
		goto IL_080f;
	}

IL_080a:
	{
		int8_t L_373;
		L_373 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B154_0 = ((int32_t)(L_373));
		G_B154_1 = G_B153_0;
	}

IL_080f:
	{
		G_B154_1->___sbyte_6_22 = (int8_t)G_B154_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_374 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_375 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_374.___register_0;
		int8_t L_376 = (int8_t)L_375.___sbyte_7_23;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_377 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_378 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_377.___register_0;
		int8_t L_379 = (int8_t)L_378.___sbyte_7_23;
		G_B155_0 = (&V_20);
		if ((((int32_t)L_376) == ((int32_t)L_379)))
		{
			G_B156_0 = (&V_20);
			goto IL_0831;
		}
	}
	{
		G_B157_0 = 0;
		G_B157_1 = G_B155_0;
		goto IL_0836;
	}

IL_0831:
	{
		int8_t L_380;
		L_380 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B157_0 = ((int32_t)(L_380));
		G_B157_1 = G_B156_0;
	}

IL_0836:
	{
		G_B157_1->___sbyte_7_23 = (int8_t)G_B157_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_381 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_382 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_381.___register_0;
		int8_t L_383 = (int8_t)L_382.___sbyte_8_24;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_384 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_385 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_384.___register_0;
		int8_t L_386 = (int8_t)L_385.___sbyte_8_24;
		G_B158_0 = (&V_20);
		if ((((int32_t)L_383) == ((int32_t)L_386)))
		{
			G_B159_0 = (&V_20);
			goto IL_0858;
		}
	}
	{
		G_B160_0 = 0;
		G_B160_1 = G_B158_0;
		goto IL_085d;
	}

IL_0858:
	{
		int8_t L_387;
		L_387 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B160_0 = ((int32_t)(L_387));
		G_B160_1 = G_B159_0;
	}

IL_085d:
	{
		G_B160_1->___sbyte_8_24 = (int8_t)G_B160_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_388 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_389 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_388.___register_0;
		int8_t L_390 = (int8_t)L_389.___sbyte_9_25;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_391 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_392 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_391.___register_0;
		int8_t L_393 = (int8_t)L_392.___sbyte_9_25;
		G_B161_0 = (&V_20);
		if ((((int32_t)L_390) == ((int32_t)L_393)))
		{
			G_B162_0 = (&V_20);
			goto IL_087f;
		}
	}
	{
		G_B163_0 = 0;
		G_B163_1 = G_B161_0;
		goto IL_0884;
	}

IL_087f:
	{
		int8_t L_394;
		L_394 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B163_0 = ((int32_t)(L_394));
		G_B163_1 = G_B162_0;
	}

IL_0884:
	{
		G_B163_1->___sbyte_9_25 = (int8_t)G_B163_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_395 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_396 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_395.___register_0;
		int8_t L_397 = (int8_t)L_396.___sbyte_10_26;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_398 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_399 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_398.___register_0;
		int8_t L_400 = (int8_t)L_399.___sbyte_10_26;
		G_B164_0 = (&V_20);
		if ((((int32_t)L_397) == ((int32_t)L_400)))
		{
			G_B165_0 = (&V_20);
			goto IL_08a6;
		}
	}
	{
		G_B166_0 = 0;
		G_B166_1 = G_B164_0;
		goto IL_08ab;
	}

IL_08a6:
	{
		int8_t L_401;
		L_401 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B166_0 = ((int32_t)(L_401));
		G_B166_1 = G_B165_0;
	}

IL_08ab:
	{
		G_B166_1->___sbyte_10_26 = (int8_t)G_B166_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_402 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_403 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_402.___register_0;
		int8_t L_404 = (int8_t)L_403.___sbyte_11_27;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_405 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_406 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_405.___register_0;
		int8_t L_407 = (int8_t)L_406.___sbyte_11_27;
		G_B167_0 = (&V_20);
		if ((((int32_t)L_404) == ((int32_t)L_407)))
		{
			G_B168_0 = (&V_20);
			goto IL_08cd;
		}
	}
	{
		G_B169_0 = 0;
		G_B169_1 = G_B167_0;
		goto IL_08d2;
	}

IL_08cd:
	{
		int8_t L_408;
		L_408 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B169_0 = ((int32_t)(L_408));
		G_B169_1 = G_B168_0;
	}

IL_08d2:
	{
		G_B169_1->___sbyte_11_27 = (int8_t)G_B169_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_409 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_410 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_409.___register_0;
		int8_t L_411 = (int8_t)L_410.___sbyte_12_28;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_412 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_413 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_412.___register_0;
		int8_t L_414 = (int8_t)L_413.___sbyte_12_28;
		G_B170_0 = (&V_20);
		if ((((int32_t)L_411) == ((int32_t)L_414)))
		{
			G_B171_0 = (&V_20);
			goto IL_08f4;
		}
	}
	{
		G_B172_0 = 0;
		G_B172_1 = G_B170_0;
		goto IL_08f9;
	}

IL_08f4:
	{
		int8_t L_415;
		L_415 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B172_0 = ((int32_t)(L_415));
		G_B172_1 = G_B171_0;
	}

IL_08f9:
	{
		G_B172_1->___sbyte_12_28 = (int8_t)G_B172_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_416 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_417 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_416.___register_0;
		int8_t L_418 = (int8_t)L_417.___sbyte_13_29;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_419 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_420 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_419.___register_0;
		int8_t L_421 = (int8_t)L_420.___sbyte_13_29;
		G_B173_0 = (&V_20);
		if ((((int32_t)L_418) == ((int32_t)L_421)))
		{
			G_B174_0 = (&V_20);
			goto IL_091b;
		}
	}
	{
		G_B175_0 = 0;
		G_B175_1 = G_B173_0;
		goto IL_0920;
	}

IL_091b:
	{
		int8_t L_422;
		L_422 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B175_0 = ((int32_t)(L_422));
		G_B175_1 = G_B174_0;
	}

IL_0920:
	{
		G_B175_1->___sbyte_13_29 = (int8_t)G_B175_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_423 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_424 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_423.___register_0;
		int8_t L_425 = (int8_t)L_424.___sbyte_14_30;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_426 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_427 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_426.___register_0;
		int8_t L_428 = (int8_t)L_427.___sbyte_14_30;
		G_B176_0 = (&V_20);
		if ((((int32_t)L_425) == ((int32_t)L_428)))
		{
			G_B177_0 = (&V_20);
			goto IL_0942;
		}
	}
	{
		G_B178_0 = 0;
		G_B178_1 = G_B176_0;
		goto IL_0947;
	}

IL_0942:
	{
		int8_t L_429;
		L_429 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B178_0 = ((int32_t)(L_429));
		G_B178_1 = G_B177_0;
	}

IL_0947:
	{
		G_B178_1->___sbyte_14_30 = (int8_t)G_B178_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_430 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_431 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_430.___register_0;
		int8_t L_432 = (int8_t)L_431.___sbyte_15_31;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_433 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_434 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_433.___register_0;
		int8_t L_435 = (int8_t)L_434.___sbyte_15_31;
		G_B179_0 = (&V_20);
		if ((((int32_t)L_432) == ((int32_t)L_435)))
		{
			G_B180_0 = (&V_20);
			goto IL_0969;
		}
	}
	{
		G_B181_0 = 0;
		G_B181_1 = G_B179_0;
		goto IL_096e;
	}

IL_0969:
	{
		int8_t L_436;
		L_436 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B181_0 = ((int32_t)(L_436));
		G_B181_1 = G_B180_0;
	}

IL_096e:
	{
		G_B181_1->___sbyte_15_31 = (int8_t)G_B181_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_437;
		memset((&L_437), 0, sizeof(L_437));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_437), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_437;
	}

IL_097b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_438 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_439;
		L_439 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_438, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_440 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_441;
		L_441 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_440, NULL);
		bool L_442;
		L_442 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_439, L_441, NULL);
		if (!L_442)
		{
			goto IL_0ad9;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_443 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_444 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_443.___register_0;
		uint16_t L_445 = (uint16_t)L_444.___uint16_0_32;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_446 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_447 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_446.___register_0;
		uint16_t L_448 = (uint16_t)L_447.___uint16_0_32;
		G_B184_0 = (&V_20);
		if ((((int32_t)L_445) == ((int32_t)L_448)))
		{
			G_B185_0 = (&V_20);
			goto IL_09b6;
		}
	}
	{
		G_B186_0 = 0;
		G_B186_1 = G_B184_0;
		goto IL_09bb;
	}

IL_09b6:
	{
		uint16_t L_449;
		L_449 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B186_0 = ((int32_t)(L_449));
		G_B186_1 = G_B185_0;
	}

IL_09bb:
	{
		G_B186_1->___uint16_0_32 = (uint16_t)G_B186_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_450 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_451 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_450.___register_0;
		uint16_t L_452 = (uint16_t)L_451.___uint16_1_33;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_453 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_454 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_453.___register_0;
		uint16_t L_455 = (uint16_t)L_454.___uint16_1_33;
		G_B187_0 = (&V_20);
		if ((((int32_t)L_452) == ((int32_t)L_455)))
		{
			G_B188_0 = (&V_20);
			goto IL_09dd;
		}
	}
	{
		G_B189_0 = 0;
		G_B189_1 = G_B187_0;
		goto IL_09e2;
	}

IL_09dd:
	{
		uint16_t L_456;
		L_456 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B189_0 = ((int32_t)(L_456));
		G_B189_1 = G_B188_0;
	}

IL_09e2:
	{
		G_B189_1->___uint16_1_33 = (uint16_t)G_B189_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_457 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_458 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_457.___register_0;
		uint16_t L_459 = (uint16_t)L_458.___uint16_2_34;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_460 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_461 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_460.___register_0;
		uint16_t L_462 = (uint16_t)L_461.___uint16_2_34;
		G_B190_0 = (&V_20);
		if ((((int32_t)L_459) == ((int32_t)L_462)))
		{
			G_B191_0 = (&V_20);
			goto IL_0a04;
		}
	}
	{
		G_B192_0 = 0;
		G_B192_1 = G_B190_0;
		goto IL_0a09;
	}

IL_0a04:
	{
		uint16_t L_463;
		L_463 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B192_0 = ((int32_t)(L_463));
		G_B192_1 = G_B191_0;
	}

IL_0a09:
	{
		G_B192_1->___uint16_2_34 = (uint16_t)G_B192_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_464 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_465 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_464.___register_0;
		uint16_t L_466 = (uint16_t)L_465.___uint16_3_35;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_467 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_468 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_467.___register_0;
		uint16_t L_469 = (uint16_t)L_468.___uint16_3_35;
		G_B193_0 = (&V_20);
		if ((((int32_t)L_466) == ((int32_t)L_469)))
		{
			G_B194_0 = (&V_20);
			goto IL_0a2b;
		}
	}
	{
		G_B195_0 = 0;
		G_B195_1 = G_B193_0;
		goto IL_0a30;
	}

IL_0a2b:
	{
		uint16_t L_470;
		L_470 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B195_0 = ((int32_t)(L_470));
		G_B195_1 = G_B194_0;
	}

IL_0a30:
	{
		G_B195_1->___uint16_3_35 = (uint16_t)G_B195_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_471 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_472 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_471.___register_0;
		uint16_t L_473 = (uint16_t)L_472.___uint16_4_36;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_474 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_475 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_474.___register_0;
		uint16_t L_476 = (uint16_t)L_475.___uint16_4_36;
		G_B196_0 = (&V_20);
		if ((((int32_t)L_473) == ((int32_t)L_476)))
		{
			G_B197_0 = (&V_20);
			goto IL_0a52;
		}
	}
	{
		G_B198_0 = 0;
		G_B198_1 = G_B196_0;
		goto IL_0a57;
	}

IL_0a52:
	{
		uint16_t L_477;
		L_477 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B198_0 = ((int32_t)(L_477));
		G_B198_1 = G_B197_0;
	}

IL_0a57:
	{
		G_B198_1->___uint16_4_36 = (uint16_t)G_B198_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_478 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_479 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_478.___register_0;
		uint16_t L_480 = (uint16_t)L_479.___uint16_5_37;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_481 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_482 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_481.___register_0;
		uint16_t L_483 = (uint16_t)L_482.___uint16_5_37;
		G_B199_0 = (&V_20);
		if ((((int32_t)L_480) == ((int32_t)L_483)))
		{
			G_B200_0 = (&V_20);
			goto IL_0a79;
		}
	}
	{
		G_B201_0 = 0;
		G_B201_1 = G_B199_0;
		goto IL_0a7e;
	}

IL_0a79:
	{
		uint16_t L_484;
		L_484 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B201_0 = ((int32_t)(L_484));
		G_B201_1 = G_B200_0;
	}

IL_0a7e:
	{
		G_B201_1->___uint16_5_37 = (uint16_t)G_B201_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_485 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_486 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_485.___register_0;
		uint16_t L_487 = (uint16_t)L_486.___uint16_6_38;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_488 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_489 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_488.___register_0;
		uint16_t L_490 = (uint16_t)L_489.___uint16_6_38;
		G_B202_0 = (&V_20);
		if ((((int32_t)L_487) == ((int32_t)L_490)))
		{
			G_B203_0 = (&V_20);
			goto IL_0aa0;
		}
	}
	{
		G_B204_0 = 0;
		G_B204_1 = G_B202_0;
		goto IL_0aa5;
	}

IL_0aa0:
	{
		uint16_t L_491;
		L_491 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B204_0 = ((int32_t)(L_491));
		G_B204_1 = G_B203_0;
	}

IL_0aa5:
	{
		G_B204_1->___uint16_6_38 = (uint16_t)G_B204_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_492 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_493 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_492.___register_0;
		uint16_t L_494 = (uint16_t)L_493.___uint16_7_39;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_495 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_496 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_495.___register_0;
		uint16_t L_497 = (uint16_t)L_496.___uint16_7_39;
		G_B205_0 = (&V_20);
		if ((((int32_t)L_494) == ((int32_t)L_497)))
		{
			G_B206_0 = (&V_20);
			goto IL_0ac7;
		}
	}
	{
		G_B207_0 = 0;
		G_B207_1 = G_B205_0;
		goto IL_0acc;
	}

IL_0ac7:
	{
		uint16_t L_498;
		L_498 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B207_0 = ((int32_t)(L_498));
		G_B207_1 = G_B206_0;
	}

IL_0acc:
	{
		G_B207_1->___uint16_7_39 = (uint16_t)G_B207_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_499;
		memset((&L_499), 0, sizeof(L_499));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_499), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_499;
	}

IL_0ad9:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_500 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_501;
		L_501 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_500, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_502 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_503;
		L_503 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_502, NULL);
		bool L_504;
		L_504 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_501, L_503, NULL);
		if (!L_504)
		{
			goto IL_0c37;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_505 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_506 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_505.___register_0;
		int16_t L_507 = (int16_t)L_506.___int16_0_40;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_508 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_509 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_508.___register_0;
		int16_t L_510 = (int16_t)L_509.___int16_0_40;
		G_B210_0 = (&V_20);
		if ((((int32_t)L_507) == ((int32_t)L_510)))
		{
			G_B211_0 = (&V_20);
			goto IL_0b14;
		}
	}
	{
		G_B212_0 = 0;
		G_B212_1 = G_B210_0;
		goto IL_0b19;
	}

IL_0b14:
	{
		int16_t L_511;
		L_511 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B212_0 = ((int32_t)(L_511));
		G_B212_1 = G_B211_0;
	}

IL_0b19:
	{
		G_B212_1->___int16_0_40 = (int16_t)G_B212_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_512 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_513 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_512.___register_0;
		int16_t L_514 = (int16_t)L_513.___int16_1_41;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_515 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_516 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_515.___register_0;
		int16_t L_517 = (int16_t)L_516.___int16_1_41;
		G_B213_0 = (&V_20);
		if ((((int32_t)L_514) == ((int32_t)L_517)))
		{
			G_B214_0 = (&V_20);
			goto IL_0b3b;
		}
	}
	{
		G_B215_0 = 0;
		G_B215_1 = G_B213_0;
		goto IL_0b40;
	}

IL_0b3b:
	{
		int16_t L_518;
		L_518 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B215_0 = ((int32_t)(L_518));
		G_B215_1 = G_B214_0;
	}

IL_0b40:
	{
		G_B215_1->___int16_1_41 = (int16_t)G_B215_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_519 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_520 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_519.___register_0;
		int16_t L_521 = (int16_t)L_520.___int16_2_42;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_522 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_523 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_522.___register_0;
		int16_t L_524 = (int16_t)L_523.___int16_2_42;
		G_B216_0 = (&V_20);
		if ((((int32_t)L_521) == ((int32_t)L_524)))
		{
			G_B217_0 = (&V_20);
			goto IL_0b62;
		}
	}
	{
		G_B218_0 = 0;
		G_B218_1 = G_B216_0;
		goto IL_0b67;
	}

IL_0b62:
	{
		int16_t L_525;
		L_525 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B218_0 = ((int32_t)(L_525));
		G_B218_1 = G_B217_0;
	}

IL_0b67:
	{
		G_B218_1->___int16_2_42 = (int16_t)G_B218_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_526 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_527 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_526.___register_0;
		int16_t L_528 = (int16_t)L_527.___int16_3_43;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_529 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_530 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_529.___register_0;
		int16_t L_531 = (int16_t)L_530.___int16_3_43;
		G_B219_0 = (&V_20);
		if ((((int32_t)L_528) == ((int32_t)L_531)))
		{
			G_B220_0 = (&V_20);
			goto IL_0b89;
		}
	}
	{
		G_B221_0 = 0;
		G_B221_1 = G_B219_0;
		goto IL_0b8e;
	}

IL_0b89:
	{
		int16_t L_532;
		L_532 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B221_0 = ((int32_t)(L_532));
		G_B221_1 = G_B220_0;
	}

IL_0b8e:
	{
		G_B221_1->___int16_3_43 = (int16_t)G_B221_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_533 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_534 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_533.___register_0;
		int16_t L_535 = (int16_t)L_534.___int16_4_44;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_536 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_537 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_536.___register_0;
		int16_t L_538 = (int16_t)L_537.___int16_4_44;
		G_B222_0 = (&V_20);
		if ((((int32_t)L_535) == ((int32_t)L_538)))
		{
			G_B223_0 = (&V_20);
			goto IL_0bb0;
		}
	}
	{
		G_B224_0 = 0;
		G_B224_1 = G_B222_0;
		goto IL_0bb5;
	}

IL_0bb0:
	{
		int16_t L_539;
		L_539 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B224_0 = ((int32_t)(L_539));
		G_B224_1 = G_B223_0;
	}

IL_0bb5:
	{
		G_B224_1->___int16_4_44 = (int16_t)G_B224_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_540 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_541 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_540.___register_0;
		int16_t L_542 = (int16_t)L_541.___int16_5_45;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_543 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_544 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_543.___register_0;
		int16_t L_545 = (int16_t)L_544.___int16_5_45;
		G_B225_0 = (&V_20);
		if ((((int32_t)L_542) == ((int32_t)L_545)))
		{
			G_B226_0 = (&V_20);
			goto IL_0bd7;
		}
	}
	{
		G_B227_0 = 0;
		G_B227_1 = G_B225_0;
		goto IL_0bdc;
	}

IL_0bd7:
	{
		int16_t L_546;
		L_546 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B227_0 = ((int32_t)(L_546));
		G_B227_1 = G_B226_0;
	}

IL_0bdc:
	{
		G_B227_1->___int16_5_45 = (int16_t)G_B227_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_547 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_548 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_547.___register_0;
		int16_t L_549 = (int16_t)L_548.___int16_6_46;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_550 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_551 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_550.___register_0;
		int16_t L_552 = (int16_t)L_551.___int16_6_46;
		G_B228_0 = (&V_20);
		if ((((int32_t)L_549) == ((int32_t)L_552)))
		{
			G_B229_0 = (&V_20);
			goto IL_0bfe;
		}
	}
	{
		G_B230_0 = 0;
		G_B230_1 = G_B228_0;
		goto IL_0c03;
	}

IL_0bfe:
	{
		int16_t L_553;
		L_553 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B230_0 = ((int32_t)(L_553));
		G_B230_1 = G_B229_0;
	}

IL_0c03:
	{
		G_B230_1->___int16_6_46 = (int16_t)G_B230_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_554 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_555 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_554.___register_0;
		int16_t L_556 = (int16_t)L_555.___int16_7_47;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_557 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_558 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_557.___register_0;
		int16_t L_559 = (int16_t)L_558.___int16_7_47;
		G_B231_0 = (&V_20);
		if ((((int32_t)L_556) == ((int32_t)L_559)))
		{
			G_B232_0 = (&V_20);
			goto IL_0c25;
		}
	}
	{
		G_B233_0 = 0;
		G_B233_1 = G_B231_0;
		goto IL_0c2a;
	}

IL_0c25:
	{
		int16_t L_560;
		L_560 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B233_0 = ((int32_t)(L_560));
		G_B233_1 = G_B232_0;
	}

IL_0c2a:
	{
		G_B233_1->___int16_7_47 = (int16_t)G_B233_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_561;
		memset((&L_561), 0, sizeof(L_561));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_561), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_561;
	}

IL_0c37:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_562 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_563;
		L_563 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_562, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_564 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_565;
		L_565 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_564, NULL);
		bool L_566;
		L_566 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_563, L_565, NULL);
		if (!L_566)
		{
			goto IL_0cf9;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_567 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_568 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_567.___register_0;
		uint32_t L_569 = (uint32_t)L_568.___uint32_0_48;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_570 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_571 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_570.___register_0;
		uint32_t L_572 = (uint32_t)L_571.___uint32_0_48;
		G_B236_0 = (&V_20);
		if ((((int32_t)L_569) == ((int32_t)L_572)))
		{
			G_B237_0 = (&V_20);
			goto IL_0c72;
		}
	}
	{
		G_B238_0 = ((uint32_t)(0));
		G_B238_1 = G_B236_0;
		goto IL_0c77;
	}

IL_0c72:
	{
		uint32_t L_573;
		L_573 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B238_0 = L_573;
		G_B238_1 = G_B237_0;
	}

IL_0c77:
	{
		G_B238_1->___uint32_0_48 = G_B238_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_574 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_575 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_574.___register_0;
		uint32_t L_576 = (uint32_t)L_575.___uint32_1_49;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_577 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_578 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_577.___register_0;
		uint32_t L_579 = (uint32_t)L_578.___uint32_1_49;
		G_B239_0 = (&V_20);
		if ((((int32_t)L_576) == ((int32_t)L_579)))
		{
			G_B240_0 = (&V_20);
			goto IL_0c99;
		}
	}
	{
		G_B241_0 = ((uint32_t)(0));
		G_B241_1 = G_B239_0;
		goto IL_0c9e;
	}

IL_0c99:
	{
		uint32_t L_580;
		L_580 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B241_0 = L_580;
		G_B241_1 = G_B240_0;
	}

IL_0c9e:
	{
		G_B241_1->___uint32_1_49 = G_B241_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_581 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_582 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_581.___register_0;
		uint32_t L_583 = (uint32_t)L_582.___uint32_2_50;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_584 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_585 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_584.___register_0;
		uint32_t L_586 = (uint32_t)L_585.___uint32_2_50;
		G_B242_0 = (&V_20);
		if ((((int32_t)L_583) == ((int32_t)L_586)))
		{
			G_B243_0 = (&V_20);
			goto IL_0cc0;
		}
	}
	{
		G_B244_0 = ((uint32_t)(0));
		G_B244_1 = G_B242_0;
		goto IL_0cc5;
	}

IL_0cc0:
	{
		uint32_t L_587;
		L_587 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B244_0 = L_587;
		G_B244_1 = G_B243_0;
	}

IL_0cc5:
	{
		G_B244_1->___uint32_2_50 = G_B244_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_588 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_589 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_588.___register_0;
		uint32_t L_590 = (uint32_t)L_589.___uint32_3_51;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_591 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_592 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_591.___register_0;
		uint32_t L_593 = (uint32_t)L_592.___uint32_3_51;
		G_B245_0 = (&V_20);
		if ((((int32_t)L_590) == ((int32_t)L_593)))
		{
			G_B246_0 = (&V_20);
			goto IL_0ce7;
		}
	}
	{
		G_B247_0 = ((uint32_t)(0));
		G_B247_1 = G_B245_0;
		goto IL_0cec;
	}

IL_0ce7:
	{
		uint32_t L_594;
		L_594 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B247_0 = L_594;
		G_B247_1 = G_B246_0;
	}

IL_0cec:
	{
		G_B247_1->___uint32_3_51 = G_B247_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_595;
		memset((&L_595), 0, sizeof(L_595));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_595), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_595;
	}

IL_0cf9:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_596 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_597;
		L_597 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_596, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_598 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_599;
		L_599 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_598, NULL);
		bool L_600;
		L_600 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_597, L_599, NULL);
		if (!L_600)
		{
			goto IL_0dbb;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_601 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_602 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_601.___register_0;
		int32_t L_603 = (int32_t)L_602.___int32_0_52;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_604 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_605 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_604.___register_0;
		int32_t L_606 = (int32_t)L_605.___int32_0_52;
		G_B250_0 = (&V_20);
		if ((((int32_t)L_603) == ((int32_t)L_606)))
		{
			G_B251_0 = (&V_20);
			goto IL_0d34;
		}
	}
	{
		G_B252_0 = 0;
		G_B252_1 = G_B250_0;
		goto IL_0d39;
	}

IL_0d34:
	{
		int32_t L_607;
		L_607 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B252_0 = L_607;
		G_B252_1 = G_B251_0;
	}

IL_0d39:
	{
		G_B252_1->___int32_0_52 = G_B252_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_608 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_609 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_608.___register_0;
		int32_t L_610 = (int32_t)L_609.___int32_1_53;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_611 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_612 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_611.___register_0;
		int32_t L_613 = (int32_t)L_612.___int32_1_53;
		G_B253_0 = (&V_20);
		if ((((int32_t)L_610) == ((int32_t)L_613)))
		{
			G_B254_0 = (&V_20);
			goto IL_0d5b;
		}
	}
	{
		G_B255_0 = 0;
		G_B255_1 = G_B253_0;
		goto IL_0d60;
	}

IL_0d5b:
	{
		int32_t L_614;
		L_614 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B255_0 = L_614;
		G_B255_1 = G_B254_0;
	}

IL_0d60:
	{
		G_B255_1->___int32_1_53 = G_B255_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_615 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_616 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_615.___register_0;
		int32_t L_617 = (int32_t)L_616.___int32_2_54;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_618 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_619 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_618.___register_0;
		int32_t L_620 = (int32_t)L_619.___int32_2_54;
		G_B256_0 = (&V_20);
		if ((((int32_t)L_617) == ((int32_t)L_620)))
		{
			G_B257_0 = (&V_20);
			goto IL_0d82;
		}
	}
	{
		G_B258_0 = 0;
		G_B258_1 = G_B256_0;
		goto IL_0d87;
	}

IL_0d82:
	{
		int32_t L_621;
		L_621 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B258_0 = L_621;
		G_B258_1 = G_B257_0;
	}

IL_0d87:
	{
		G_B258_1->___int32_2_54 = G_B258_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_622 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_623 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_622.___register_0;
		int32_t L_624 = (int32_t)L_623.___int32_3_55;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_625 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_626 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_625.___register_0;
		int32_t L_627 = (int32_t)L_626.___int32_3_55;
		G_B259_0 = (&V_20);
		if ((((int32_t)L_624) == ((int32_t)L_627)))
		{
			G_B260_0 = (&V_20);
			goto IL_0da9;
		}
	}
	{
		G_B261_0 = 0;
		G_B261_1 = G_B259_0;
		goto IL_0dae;
	}

IL_0da9:
	{
		int32_t L_628;
		L_628 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B261_0 = L_628;
		G_B261_1 = G_B260_0;
	}

IL_0dae:
	{
		G_B261_1->___int32_3_55 = G_B261_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_629;
		memset((&L_629), 0, sizeof(L_629));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_629), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_629;
	}

IL_0dbb:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_630 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_631;
		L_631 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_630, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_632 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_633;
		L_633 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_632, NULL);
		bool L_634;
		L_634 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_631, L_633, NULL);
		if (!L_634)
		{
			goto IL_0e2e;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_635 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_636 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_635.___register_0;
		uint64_t L_637 = (uint64_t)L_636.___uint64_0_56;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_638 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_639 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_638.___register_0;
		uint64_t L_640 = (uint64_t)L_639.___uint64_0_56;
		G_B264_0 = (&V_20);
		if ((((int64_t)L_637) == ((int64_t)L_640)))
		{
			G_B265_0 = (&V_20);
			goto IL_0df4;
		}
	}
	{
		G_B266_0 = ((uint64_t)(((int64_t)0)));
		G_B266_1 = G_B264_0;
		goto IL_0df9;
	}

IL_0df4:
	{
		uint64_t L_641;
		L_641 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		G_B266_0 = L_641;
		G_B266_1 = G_B265_0;
	}

IL_0df9:
	{
		G_B266_1->___uint64_0_56 = G_B266_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_642 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_643 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_642.___register_0;
		uint64_t L_644 = (uint64_t)L_643.___uint64_1_57;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_645 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_646 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_645.___register_0;
		uint64_t L_647 = (uint64_t)L_646.___uint64_1_57;
		G_B267_0 = (&V_20);
		if ((((int64_t)L_644) == ((int64_t)L_647)))
		{
			G_B268_0 = (&V_20);
			goto IL_0e1c;
		}
	}
	{
		G_B269_0 = ((uint64_t)(((int64_t)0)));
		G_B269_1 = G_B267_0;
		goto IL_0e21;
	}

IL_0e1c:
	{
		uint64_t L_648;
		L_648 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		G_B269_0 = L_648;
		G_B269_1 = G_B268_0;
	}

IL_0e21:
	{
		G_B269_1->___uint64_1_57 = G_B269_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_649;
		memset((&L_649), 0, sizeof(L_649));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_649), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_649;
	}

IL_0e2e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_650 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_651;
		L_651 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_650, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_652 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_653;
		L_653 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_652, NULL);
		bool L_654;
		L_654 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_651, L_653, NULL);
		if (!L_654)
		{
			goto IL_0ea1;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_655 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_656 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_655.___register_0;
		int64_t L_657 = (int64_t)L_656.___int64_0_58;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_658 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_659 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_658.___register_0;
		int64_t L_660 = (int64_t)L_659.___int64_0_58;
		G_B272_0 = (&V_20);
		if ((((int64_t)L_657) == ((int64_t)L_660)))
		{
			G_B273_0 = (&V_20);
			goto IL_0e67;
		}
	}
	{
		G_B274_0 = ((int64_t)0);
		G_B274_1 = G_B272_0;
		goto IL_0e6c;
	}

IL_0e67:
	{
		int64_t L_661;
		L_661 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		G_B274_0 = L_661;
		G_B274_1 = G_B273_0;
	}

IL_0e6c:
	{
		G_B274_1->___int64_0_58 = G_B274_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_662 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_663 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_662.___register_0;
		int64_t L_664 = (int64_t)L_663.___int64_1_59;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_665 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_666 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_665.___register_0;
		int64_t L_667 = (int64_t)L_666.___int64_1_59;
		G_B275_0 = (&V_20);
		if ((((int64_t)L_664) == ((int64_t)L_667)))
		{
			G_B276_0 = (&V_20);
			goto IL_0e8f;
		}
	}
	{
		G_B277_0 = ((int64_t)0);
		G_B277_1 = G_B275_0;
		goto IL_0e94;
	}

IL_0e8f:
	{
		int64_t L_668;
		L_668 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		G_B277_0 = L_668;
		G_B277_1 = G_B276_0;
	}

IL_0e94:
	{
		G_B277_1->___int64_1_59 = G_B277_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_669;
		memset((&L_669), 0, sizeof(L_669));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_669), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_669;
	}

IL_0ea1:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_670 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_671;
		L_671 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_670, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_672 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_673;
		L_673 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_672, NULL);
		bool L_674;
		L_674 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_671, L_673, NULL);
		if (!L_674)
		{
			goto IL_0f73;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_675 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_676 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_675.___register_0;
		float L_677 = (float)L_676.___single_0_60;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_678 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_679 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_678.___register_0;
		float L_680 = (float)L_679.___single_0_60;
		G_B280_0 = (&V_20);
		if ((((float)L_677) == ((float)L_680)))
		{
			G_B281_0 = (&V_20);
			goto IL_0ee0;
		}
	}
	{
		G_B282_0 = (0.0f);
		G_B282_1 = G_B280_0;
		goto IL_0ee5;
	}

IL_0ee0:
	{
		float L_681;
		L_681 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B282_0 = L_681;
		G_B282_1 = G_B281_0;
	}

IL_0ee5:
	{
		G_B282_1->___single_0_60 = G_B282_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_682 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_683 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_682.___register_0;
		float L_684 = (float)L_683.___single_1_61;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_685 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_686 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_685.___register_0;
		float L_687 = (float)L_686.___single_1_61;
		G_B283_0 = (&V_20);
		if ((((float)L_684) == ((float)L_687)))
		{
			G_B284_0 = (&V_20);
			goto IL_0f0b;
		}
	}
	{
		G_B285_0 = (0.0f);
		G_B285_1 = G_B283_0;
		goto IL_0f10;
	}

IL_0f0b:
	{
		float L_688;
		L_688 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B285_0 = L_688;
		G_B285_1 = G_B284_0;
	}

IL_0f10:
	{
		G_B285_1->___single_1_61 = G_B285_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_689 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_690 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_689.___register_0;
		float L_691 = (float)L_690.___single_2_62;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_692 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_693 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_692.___register_0;
		float L_694 = (float)L_693.___single_2_62;
		G_B286_0 = (&V_20);
		if ((((float)L_691) == ((float)L_694)))
		{
			G_B287_0 = (&V_20);
			goto IL_0f36;
		}
	}
	{
		G_B288_0 = (0.0f);
		G_B288_1 = G_B286_0;
		goto IL_0f3b;
	}

IL_0f36:
	{
		float L_695;
		L_695 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B288_0 = L_695;
		G_B288_1 = G_B287_0;
	}

IL_0f3b:
	{
		G_B288_1->___single_2_62 = G_B288_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_696 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_697 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_696.___register_0;
		float L_698 = (float)L_697.___single_3_63;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_699 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_700 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_699.___register_0;
		float L_701 = (float)L_700.___single_3_63;
		G_B289_0 = (&V_20);
		if ((((float)L_698) == ((float)L_701)))
		{
			G_B290_0 = (&V_20);
			goto IL_0f61;
		}
	}
	{
		G_B291_0 = (0.0f);
		G_B291_1 = G_B289_0;
		goto IL_0f66;
	}

IL_0f61:
	{
		float L_702;
		L_702 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B291_0 = L_702;
		G_B291_1 = G_B290_0;
	}

IL_0f66:
	{
		G_B291_1->___single_3_63 = G_B291_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_703;
		memset((&L_703), 0, sizeof(L_703));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_703), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_703;
	}

IL_0f73:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_704 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_705;
		L_705 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_704, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_706 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_707;
		L_707 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_706, NULL);
		bool L_708;
		L_708 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_705, L_707, NULL);
		if (!L_708)
		{
			goto IL_0ff4;
		}
	}
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_709 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_710 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_709.___register_0;
		double L_711 = (double)L_710.___double_0_64;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_712 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_713 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_712.___register_0;
		double L_714 = (double)L_713.___double_0_64;
		G_B294_0 = (&V_20);
		if ((((double)L_711) == ((double)L_714)))
		{
			G_B295_0 = (&V_20);
			goto IL_0fb3;
		}
	}
	{
		G_B296_0 = (0.0);
		G_B296_1 = G_B294_0;
		goto IL_0fb8;
	}

IL_0fb3:
	{
		double L_715;
		L_715 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		G_B296_0 = L_715;
		G_B296_1 = G_B295_0;
	}

IL_0fb8:
	{
		G_B296_1->___double_0_64 = G_B296_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_716 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_717 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_716.___register_0;
		double L_718 = (double)L_717.___double_1_65;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_719 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_720 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_719.___register_0;
		double L_721 = (double)L_720.___double_1_65;
		G_B297_0 = (&V_20);
		if ((((double)L_718) == ((double)L_721)))
		{
			G_B298_0 = (&V_20);
			goto IL_0fe2;
		}
	}
	{
		G_B299_0 = (0.0);
		G_B299_1 = G_B297_0;
		goto IL_0fe7;
	}

IL_0fe2:
	{
		double L_722;
		L_722 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		G_B299_0 = L_722;
		G_B299_1 = G_B298_0;
	}

IL_0fe7:
	{
		G_B299_1->___double_1_65 = G_B299_0;
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_723;
		memset((&L_723), 0, sizeof(L_723));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_723), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_723;
	}

IL_0ff4:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_724 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_724);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_724, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_724, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_Equals_m418B4B94BDF33C772FB602A771DB37FEFCA66835_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_gshared (uint64_t ___left0, uint64_t ___right1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0034;
		}
	}
	{
		uint64_t L_5 = ___left0;
		uint64_t L_6 = L_5;
		RuntimeObject* L_7 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_6);
		uint64_t L_8 = ___right1;
		uint64_t L_9 = L_8;
		RuntimeObject* L_10 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_9);
		return (bool)((((int32_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_7, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_10, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0034:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_11 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_12;
		L_12 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_11, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_13 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_14;
		L_14 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_13, NULL);
		bool L_15;
		L_15 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_12, L_14, NULL);
		if (!L_15)
		{
			goto IL_0068;
		}
	}
	{
		uint64_t L_16 = ___left0;
		uint64_t L_17 = L_16;
		RuntimeObject* L_18 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_17);
		uint64_t L_19 = ___right1;
		uint64_t L_20 = L_19;
		RuntimeObject* L_21 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_20);
		return (bool)((((int32_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_18, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_21, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0068:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_22 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_23;
		L_23 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_22, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_24 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_25;
		L_25 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_24, NULL);
		bool L_26;
		L_26 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_23, L_25, NULL);
		if (!L_26)
		{
			goto IL_009c;
		}
	}
	{
		uint64_t L_27 = ___left0;
		uint64_t L_28 = L_27;
		RuntimeObject* L_29 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_28);
		uint64_t L_30 = ___right1;
		uint64_t L_31 = L_30;
		RuntimeObject* L_32 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_31);
		return (bool)((((int32_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_29, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_32, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_009c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_33 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_34;
		L_34 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_33, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		bool L_37;
		L_37 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_34, L_36, NULL);
		if (!L_37)
		{
			goto IL_00d0;
		}
	}
	{
		uint64_t L_38 = ___left0;
		uint64_t L_39 = L_38;
		RuntimeObject* L_40 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_39);
		uint64_t L_41 = ___right1;
		uint64_t L_42 = L_41;
		RuntimeObject* L_43 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_42);
		return (bool)((((int32_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_40, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_43, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_00d0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_44, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_46 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_47;
		L_47 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_46, NULL);
		bool L_48;
		L_48 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_45, L_47, NULL);
		if (!L_48)
		{
			goto IL_0104;
		}
	}
	{
		uint64_t L_49 = ___left0;
		uint64_t L_50 = L_49;
		RuntimeObject* L_51 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_50);
		uint64_t L_52 = ___right1;
		uint64_t L_53 = L_52;
		RuntimeObject* L_54 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_53);
		return (bool)((((int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_51, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_54, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0104:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_55 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_56;
		L_56 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_55, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_57 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_58;
		L_58 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_57, NULL);
		bool L_59;
		L_59 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_56, L_58, NULL);
		if (!L_59)
		{
			goto IL_0138;
		}
	}
	{
		uint64_t L_60 = ___left0;
		uint64_t L_61 = L_60;
		RuntimeObject* L_62 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_61);
		uint64_t L_63 = ___right1;
		uint64_t L_64 = L_63;
		RuntimeObject* L_65 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_64);
		return (bool)((((int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_62, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_65, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0138:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_66 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_67;
		L_67 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_66, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_68 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_69;
		L_69 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_68, NULL);
		bool L_70;
		L_70 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_67, L_69, NULL);
		if (!L_70)
		{
			goto IL_016c;
		}
	}
	{
		uint64_t L_71 = ___left0;
		uint64_t L_72 = L_71;
		RuntimeObject* L_73 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_72);
		uint64_t L_74 = ___right1;
		uint64_t L_75 = L_74;
		RuntimeObject* L_76 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_75);
		return (bool)((((int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_73, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))))) == ((int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_76, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_016c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_77 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_78;
		L_78 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_77, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_79 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_80;
		L_80 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_79, NULL);
		bool L_81;
		L_81 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_78, L_80, NULL);
		if (!L_81)
		{
			goto IL_01a0;
		}
	}
	{
		uint64_t L_82 = ___left0;
		uint64_t L_83 = L_82;
		RuntimeObject* L_84 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_83);
		uint64_t L_85 = ___right1;
		uint64_t L_86 = L_85;
		RuntimeObject* L_87 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_86);
		return (bool)((((int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_84, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))))) == ((int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_87, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_01a0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_88 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_89;
		L_89 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_88, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_90 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_91;
		L_91 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_90, NULL);
		bool L_92;
		L_92 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_89, L_91, NULL);
		if (!L_92)
		{
			goto IL_01d4;
		}
	}
	{
		uint64_t L_93 = ___left0;
		uint64_t L_94 = L_93;
		RuntimeObject* L_95 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_94);
		uint64_t L_96 = ___right1;
		uint64_t L_97 = L_96;
		RuntimeObject* L_98 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_97);
		return (bool)((((float)((*(float*)((float*)(float*)UnBox(L_95, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))))) == ((float)((*(float*)((float*)(float*)UnBox(L_98, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_01d4:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_99 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_100;
		L_100 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_99, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_101 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_102;
		L_102 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_101, NULL);
		bool L_103;
		L_103 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_100, L_102, NULL);
		if (!L_103)
		{
			goto IL_0208;
		}
	}
	{
		uint64_t L_104 = ___left0;
		uint64_t L_105 = L_104;
		RuntimeObject* L_106 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_105);
		uint64_t L_107 = ___right1;
		uint64_t L_108 = L_107;
		RuntimeObject* L_109 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_108);
		return (bool)((((double)((*(double*)((double*)(double*)UnBox(L_106, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))))) == ((double)((*(double*)((double*)(double*)UnBox(L_109, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0208:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_110 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_110);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_110, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_110, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_gshared (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0027;
		}
	}
	{
		uint8_t L_5 = ((uint8_t)1);
		RuntimeObject* L_6 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_5);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_6, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0027:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_7 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_8;
		L_8 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_7, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_9 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_10;
		L_10 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_9, NULL);
		bool L_11;
		L_11 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_8, L_10, NULL);
		if (!L_11)
		{
			goto IL_004e;
		}
	}
	{
		int8_t L_12 = ((int8_t)1);
		RuntimeObject* L_13 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_12);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_13, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_004e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_14 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_15;
		L_15 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_14, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		bool L_18;
		L_18 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_15, L_17, NULL);
		if (!L_18)
		{
			goto IL_0075;
		}
	}
	{
		uint16_t L_19 = ((uint16_t)1);
		RuntimeObject* L_20 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_19);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_20, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0075:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_21 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_22;
		L_22 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_21, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_23 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_24;
		L_24 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_23, NULL);
		bool L_25;
		L_25 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_22, L_24, NULL);
		if (!L_25)
		{
			goto IL_009c;
		}
	}
	{
		int16_t L_26 = ((int16_t)1);
		RuntimeObject* L_27 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_26);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_27, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_009c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_28 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_29;
		L_29 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_28, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_30, NULL);
		bool L_32;
		L_32 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_29, L_31, NULL);
		if (!L_32)
		{
			goto IL_00c3;
		}
	}
	{
		uint32_t L_33 = ((uint32_t)1);
		RuntimeObject* L_34 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_33);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_34, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00c3:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_37 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_38;
		L_38 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_37, NULL);
		bool L_39;
		L_39 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_36, L_38, NULL);
		if (!L_39)
		{
			goto IL_00ea;
		}
	}
	{
		int32_t L_40 = 1;
		RuntimeObject* L_41 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_40);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_41, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00ea:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_44, NULL);
		bool L_46;
		L_46 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_43, L_45, NULL);
		if (!L_46)
		{
			goto IL_0112;
		}
	}
	{
		uint64_t L_47 = ((uint64_t)((int64_t)1));
		RuntimeObject* L_48 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_47);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_48, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0112:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_49 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_50;
		L_50 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_49, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_51 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_52;
		L_52 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_51, NULL);
		bool L_53;
		L_53 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_50, L_52, NULL);
		if (!L_53)
		{
			goto IL_013a;
		}
	}
	{
		int64_t L_54 = ((int64_t)1);
		RuntimeObject* L_55 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_54);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_013a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0165;
		}
	}
	{
		float L_61 = (1.0f);
		RuntimeObject* L_62 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_61);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_62, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0165:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_65 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_66;
		L_66 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_65, NULL);
		bool L_67;
		L_67 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_64, L_66, NULL);
		if (!L_67)
		{
			goto IL_0194;
		}
	}
	{
		double L_68 = (1.0);
		RuntimeObject* L_69 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_68);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_69, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0194:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_70 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_70);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_70, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_70, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_gshared (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_002b;
		}
	}
	{
		uint8_t L_5;
		L_5 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		uint8_t L_6 = L_5;
		RuntimeObject* L_7 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_6);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_7, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_002b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_8 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_9;
		L_9 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_8, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		bool L_12;
		L_12 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_9, L_11, NULL);
		if (!L_12)
		{
			goto IL_0056;
		}
	}
	{
		int8_t L_13;
		L_13 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		int8_t L_14 = L_13;
		RuntimeObject* L_15 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_14);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_15, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0056:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_18 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_19;
		L_19 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_18, NULL);
		bool L_20;
		L_20 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_17, L_19, NULL);
		if (!L_20)
		{
			goto IL_0081;
		}
	}
	{
		uint16_t L_21;
		L_21 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		uint16_t L_22 = L_21;
		RuntimeObject* L_23 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_22);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_23, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0081:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_24 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_25;
		L_25 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_24, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_26 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_27;
		L_27 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_26, NULL);
		bool L_28;
		L_28 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_25, L_27, NULL);
		if (!L_28)
		{
			goto IL_00ac;
		}
	}
	{
		int16_t L_29;
		L_29 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		int16_t L_30 = L_29;
		RuntimeObject* L_31 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_30);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_31, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00ac:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_32, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_34 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_35;
		L_35 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_34, NULL);
		bool L_36;
		L_36 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_33, L_35, NULL);
		if (!L_36)
		{
			goto IL_00d7;
		}
	}
	{
		uint32_t L_37;
		L_37 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		uint32_t L_38 = L_37;
		RuntimeObject* L_39 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_38);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_39, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00d7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_40 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_41;
		L_41 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_40, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		bool L_44;
		L_44 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_41, L_43, NULL);
		if (!L_44)
		{
			goto IL_0102;
		}
	}
	{
		int32_t L_45;
		L_45 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		int32_t L_46 = L_45;
		RuntimeObject* L_47 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_46);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_47, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0102:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_48 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_49;
		L_49 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_48, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_50 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_51;
		L_51 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_50, NULL);
		bool L_52;
		L_52 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_49, L_51, NULL);
		if (!L_52)
		{
			goto IL_012d;
		}
	}
	{
		uint64_t L_53;
		L_53 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		uint64_t L_54 = L_53;
		RuntimeObject* L_55 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_54);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_012d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0158;
		}
	}
	{
		int64_t L_61;
		L_61 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		int64_t L_62 = L_61;
		RuntimeObject* L_63 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_62);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_63, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0158:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_64 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_65;
		L_65 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_64, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_66 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_67;
		L_67 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_66, NULL);
		bool L_68;
		L_68 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_65, L_67, NULL);
		if (!L_68)
		{
			goto IL_0183;
		}
	}
	{
		float L_69;
		L_69 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		float L_70 = L_69;
		RuntimeObject* L_71 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_70);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_71, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0183:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_72 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_73;
		L_73 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_72, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_74 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_75;
		L_75 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_74, NULL);
		bool L_76;
		L_76 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_73, L_75, NULL);
		if (!L_76)
		{
			goto IL_01ae;
		}
	}
	{
		double L_77;
		L_77 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		double L_78 = L_77;
		RuntimeObject* L_79 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_78);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_79, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_01ae:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_80 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_80);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_80, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_80, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__cctor_m9BB6551839C29960B0DC7ADECA8CF28B0E9D63C9_gshared (const RuntimeMethod* method) 
{
	{
		int32_t L_0;
		L_0 = Vector_1_InitializeCount_m41FB8B7B182526C04FD387334B598146762AB198(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 14));
		((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_count_1 = L_0;
		il2cpp_codegen_initobj((&((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_zero_2), sizeof(Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A));
		uint64_t L_1;
		L_1 = Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_2;
		memset((&L_2), 0, sizeof(L_2));
		Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6((&L_2), L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_one_3 = L_2;
		uint64_t L_3;
		L_3 = Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector_1__ctor_m1B5D6A9264B4450B3C14BD8FF9430354A337F2D6((&L_4), L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_allOnes_4 = L_4;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_get_Count_m8A0844ECBEB3B5C81BDDA7FB1C71E09EBB4D1E11_gshared (const RuntimeMethod* method) 
{
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_0 = ((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_count_1;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 Vector_1_get_Zero_m2559697B8F90E2E151CF0D8AAAD342C9B85F40BF_gshared (const RuntimeMethod* method) 
{
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_0 = ((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_zero_2;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_InitializeCount_mE82AC635FE85862D388CE15B6CC68AE715A77543_gshared (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	VectorSizeHelper_tAB183E4966E0B97A19A75D213EDAE51037A6BF3C V_0;
	memset((&V_0), 0, sizeof(V_0));
	uint8_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t G_B2_0 = 0;
	int32_t G_B1_0 = 0;
	int32_t G_B21_0 = 0;
	int32_t G_B4_0 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B6_0 = 0;
	int32_t G_B5_0 = 0;
	int32_t G_B8_0 = 0;
	int32_t G_B7_0 = 0;
	int32_t G_B10_0 = 0;
	int32_t G_B9_0 = 0;
	int32_t G_B12_0 = 0;
	int32_t G_B11_0 = 0;
	int32_t G_B14_0 = 0;
	int32_t G_B13_0 = 0;
	int32_t G_B16_0 = 0;
	int32_t G_B15_0 = 0;
	int32_t G_B18_0 = 0;
	int32_t G_B17_0 = 0;
	int32_t G_B20_0 = 0;
	int32_t G_B19_0 = 0;
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* L_0 = (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)(&(&V_0)->____placeholder_0);
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_1 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&L_0->___register_0);
		uint8_t* L_2 = (uint8_t*)(&L_1->___byte_0_0);
		V_1 = (uint8_t*)((uintptr_t)L_2);
		uint8_t* L_3 = (uint8_t*)(&(&V_0)->____byte_1);
		uint8_t* L_4 = V_1;
		V_2 = (-1);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_5 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_6;
		L_6 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_5, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_7 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_8;
		L_8 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_7, NULL);
		bool L_9;
		L_9 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_6, L_8, NULL);
		G_B1_0 = ((int32_t)((int64_t)(intptr_t)((uint8_t*)((intptr_t)((uint8_t*)il2cpp_codegen_subtract((intptr_t)((uintptr_t)L_3), (intptr_t)L_4))/1))));
		if (!L_9)
		{
			G_B2_0 = ((int32_t)((int64_t)(intptr_t)((uint8_t*)((intptr_t)((uint8_t*)il2cpp_codegen_subtract((intptr_t)((uintptr_t)L_3), (intptr_t)L_4))/1))));
			goto IL_0045;
		}
	}
	{
		V_2 = 1;
		G_B21_0 = G_B1_0;
		goto IL_0176;
	}

IL_0045:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_12 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_13;
		L_13 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_12, NULL);
		bool L_14;
		L_14 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_11, L_13, NULL);
		G_B3_0 = G_B2_0;
		if (!L_14)
		{
			G_B4_0 = G_B2_0;
			goto IL_0067;
		}
	}
	{
		V_2 = 1;
		G_B21_0 = G_B3_0;
		goto IL_0176;
	}

IL_0067:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_15 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_16;
		L_16 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_15, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_17 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_18;
		L_18 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_17, NULL);
		bool L_19;
		L_19 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_16, L_18, NULL);
		G_B5_0 = G_B4_0;
		if (!L_19)
		{
			G_B6_0 = G_B4_0;
			goto IL_0089;
		}
	}
	{
		V_2 = 2;
		G_B21_0 = G_B5_0;
		goto IL_0176;
	}

IL_0089:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_20 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_21;
		L_21 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_20, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_22 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_23;
		L_23 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_22, NULL);
		bool L_24;
		L_24 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_21, L_23, NULL);
		G_B7_0 = G_B6_0;
		if (!L_24)
		{
			G_B8_0 = G_B6_0;
			goto IL_00ab;
		}
	}
	{
		V_2 = 2;
		G_B21_0 = G_B7_0;
		goto IL_0176;
	}

IL_00ab:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_25 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_26;
		L_26 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_25, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_27 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_28;
		L_28 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_27, NULL);
		bool L_29;
		L_29 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_26, L_28, NULL);
		G_B9_0 = G_B8_0;
		if (!L_29)
		{
			G_B10_0 = G_B8_0;
			goto IL_00cd;
		}
	}
	{
		V_2 = 4;
		G_B21_0 = G_B9_0;
		goto IL_0176;
	}

IL_00cd:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_32, NULL);
		bool L_34;
		L_34 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_31, L_33, NULL);
		G_B11_0 = G_B10_0;
		if (!L_34)
		{
			G_B12_0 = G_B10_0;
			goto IL_00ef;
		}
	}
	{
		V_2 = 4;
		G_B21_0 = G_B11_0;
		goto IL_0176;
	}

IL_00ef:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_37 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_38;
		L_38 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_37, NULL);
		bool L_39;
		L_39 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_36, L_38, NULL);
		G_B13_0 = G_B12_0;
		if (!L_39)
		{
			G_B14_0 = G_B12_0;
			goto IL_010e;
		}
	}
	{
		V_2 = 8;
		G_B21_0 = G_B13_0;
		goto IL_0176;
	}

IL_010e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_40 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_41;
		L_41 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_40, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		bool L_44;
		L_44 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_41, L_43, NULL);
		G_B15_0 = G_B14_0;
		if (!L_44)
		{
			G_B16_0 = G_B14_0;
			goto IL_012d;
		}
	}
	{
		V_2 = 8;
		G_B21_0 = G_B15_0;
		goto IL_0176;
	}

IL_012d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_45 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_46;
		L_46 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_45, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_47 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_48;
		L_48 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_47, NULL);
		bool L_49;
		L_49 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_46, L_48, NULL);
		G_B17_0 = G_B16_0;
		if (!L_49)
		{
			G_B18_0 = G_B16_0;
			goto IL_014c;
		}
	}
	{
		V_2 = 4;
		G_B21_0 = G_B17_0;
		goto IL_0176;
	}

IL_014c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_50 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_51;
		L_51 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_50, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_52 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_53;
		L_53 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_52, NULL);
		bool L_54;
		L_54 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_51, L_53, NULL);
		G_B19_0 = G_B18_0;
		if (!L_54)
		{
			G_B20_0 = G_B18_0;
			goto IL_016b;
		}
	}
	{
		V_2 = 8;
		G_B21_0 = G_B19_0;
		goto IL_0176;
	}

IL_016b:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_55 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_55);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_55, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_55, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_InitializeCount_mE82AC635FE85862D388CE15B6CC68AE715A77543_RuntimeMethod_var)));
	}

IL_0176:
	{
		int32_t L_56 = V_2;
		return ((int32_t)(G_B21_0/L_56));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Il2CppFullySharedGenericStruct ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	const Il2CppFullySharedGenericStruct L_11 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_26 = L_11;
	const Il2CppFullySharedGenericStruct L_41 = L_11;
	const Il2CppFullySharedGenericStruct L_56 = L_11;
	const Il2CppFullySharedGenericStruct L_71 = L_11;
	const Il2CppFullySharedGenericStruct L_86 = L_11;
	const Il2CppFullySharedGenericStruct L_101 = L_11;
	const Il2CppFullySharedGenericStruct L_116 = L_11;
	const Il2CppFullySharedGenericStruct L_131 = L_11;
	const Il2CppFullySharedGenericStruct L_146 = L_11;
	const Il2CppFullySharedGenericStruct L_157 = L_11;
	const Il2CppFullySharedGenericStruct L_210 = L_11;
	const Il2CppFullySharedGenericStruct L_263 = L_11;
	const Il2CppFullySharedGenericStruct L_292 = L_11;
	const Il2CppFullySharedGenericStruct L_321 = L_11;
	const Il2CppFullySharedGenericStruct L_338 = L_11;
	const Il2CppFullySharedGenericStruct L_355 = L_11;
	const Il2CppFullySharedGenericStruct L_366 = L_11;
	const Il2CppFullySharedGenericStruct L_377 = L_11;
	const Il2CppFullySharedGenericStruct L_394 = L_11;
	const Il2CppFullySharedGenericStruct L_160 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_213 = L_160;
	const Il2CppFullySharedGenericStruct L_266 = L_160;
	const Il2CppFullySharedGenericStruct L_295 = L_160;
	const Il2CppFullySharedGenericStruct L_324 = L_160;
	const Il2CppFullySharedGenericStruct L_341 = L_160;
	const Il2CppFullySharedGenericStruct L_358 = L_160;
	const Il2CppFullySharedGenericStruct L_369 = L_160;
	const Il2CppFullySharedGenericStruct L_380 = L_160;
	const Il2CppFullySharedGenericStruct L_397 = L_160;
	const Il2CppFullySharedGenericStruct L_163 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_216 = L_163;
	const Il2CppFullySharedGenericStruct L_269 = L_163;
	const Il2CppFullySharedGenericStruct L_298 = L_163;
	const Il2CppFullySharedGenericStruct L_327 = L_163;
	const Il2CppFullySharedGenericStruct L_344 = L_163;
	const Il2CppFullySharedGenericStruct L_383 = L_163;
	const Il2CppFullySharedGenericStruct L_166 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_219 = L_166;
	const Il2CppFullySharedGenericStruct L_272 = L_166;
	const Il2CppFullySharedGenericStruct L_301 = L_166;
	const Il2CppFullySharedGenericStruct L_330 = L_166;
	const Il2CppFullySharedGenericStruct L_347 = L_166;
	const Il2CppFullySharedGenericStruct L_386 = L_166;
	const Il2CppFullySharedGenericStruct L_169 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_222 = L_169;
	const Il2CppFullySharedGenericStruct L_275 = L_169;
	const Il2CppFullySharedGenericStruct L_304 = L_169;
	const Il2CppFullySharedGenericStruct L_172 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_225 = L_172;
	const Il2CppFullySharedGenericStruct L_278 = L_172;
	const Il2CppFullySharedGenericStruct L_307 = L_172;
	const Il2CppFullySharedGenericStruct L_175 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_228 = L_175;
	const Il2CppFullySharedGenericStruct L_281 = L_175;
	const Il2CppFullySharedGenericStruct L_310 = L_175;
	const Il2CppFullySharedGenericStruct L_178 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_231 = L_178;
	const Il2CppFullySharedGenericStruct L_284 = L_178;
	const Il2CppFullySharedGenericStruct L_313 = L_178;
	const Il2CppFullySharedGenericStruct L_181 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_234 = L_181;
	const Il2CppFullySharedGenericStruct L_184 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_237 = L_184;
	const Il2CppFullySharedGenericStruct L_187 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_240 = L_187;
	const Il2CppFullySharedGenericStruct L_190 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_243 = L_190;
	const Il2CppFullySharedGenericStruct L_193 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_246 = L_193;
	const Il2CppFullySharedGenericStruct L_196 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_249 = L_196;
	const Il2CppFullySharedGenericStruct L_199 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_252 = L_199;
	const Il2CppFullySharedGenericStruct L_202 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_255 = L_202;
	uint8_t* V_0 = NULL;
	uint8_t* V_1 = NULL;
	int32_t V_2 = 0;
	int8_t* V_3 = NULL;
	int8_t* V_4 = NULL;
	int32_t V_5 = 0;
	uint16_t* V_6 = NULL;
	uint16_t* V_7 = NULL;
	int32_t V_8 = 0;
	int16_t* V_9 = NULL;
	int16_t* V_10 = NULL;
	int32_t V_11 = 0;
	uint32_t* V_12 = NULL;
	uint32_t* V_13 = NULL;
	int32_t V_14 = 0;
	int32_t* V_15 = NULL;
	int32_t* V_16 = NULL;
	int32_t V_17 = 0;
	uint64_t* V_18 = NULL;
	uint64_t* V_19 = NULL;
	int32_t V_20 = 0;
	int64_t* V_21 = NULL;
	int64_t* V_22 = NULL;
	int32_t V_23 = 0;
	float* V_24 = NULL;
	float* V_25 = NULL;
	int32_t V_26 = 0;
	double* V_27 = NULL;
	double* V_28 = NULL;
	int32_t V_29 = 0;
	{
		il2cpp_codegen_initobj(__this, sizeof(Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2));
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_0386;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_3, NULL);
		bool L_5;
		L_5 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_2, L_4, NULL);
		if (!L_5)
		{
			goto IL_005e;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_6 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_7 = (uint8_t*)(&L_6->___byte_0_0);
		V_1 = L_7;
		uint8_t* L_8 = V_1;
		V_0 = (uint8_t*)((uintptr_t)L_8);
		V_2 = 0;
		goto IL_0052;
	}

IL_003f:
	{
		uint8_t* L_9 = V_0;
		int32_t L_10 = V_2;
		il2cpp_codegen_memcpy(L_11, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_12 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_11);
		*((int8_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_9, L_10))) = (int8_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_12, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		int32_t L_13 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_13, 1));
	}

IL_0052:
	{
		int32_t L_14 = V_2;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_15;
		L_15 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_14) < ((int32_t)L_15)))
		{
			goto IL_003f;
		}
	}
	{
		V_1 = (uint8_t*)((uintptr_t)0);
		return;
	}

IL_005e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_18 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_19;
		L_19 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_18, NULL);
		bool L_20;
		L_20 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_17, L_19, NULL);
		if (!L_20)
		{
			goto IL_00b3;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_21 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_22 = (int8_t*)(&L_21->___sbyte_0_16);
		V_4 = L_22;
		int8_t* L_23 = V_4;
		V_3 = (int8_t*)((uintptr_t)L_23);
		V_5 = 0;
		goto IL_00a5;
	}

IL_008f:
	{
		int8_t* L_24 = V_3;
		int32_t L_25 = V_5;
		il2cpp_codegen_memcpy(L_26, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_27 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_26);
		*((int8_t*)((int8_t*)il2cpp_codegen_add((intptr_t)L_24, L_25))) = (int8_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_27, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		int32_t L_28 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_28, 1));
	}

IL_00a5:
	{
		int32_t L_29 = V_5;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_30;
		L_30 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_29) < ((int32_t)L_30)))
		{
			goto IL_008f;
		}
	}
	{
		V_4 = (int8_t*)((uintptr_t)0);
		return;
	}

IL_00b3:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_31 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_32;
		L_32 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_31, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_33 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_34;
		L_34 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_33, NULL);
		bool L_35;
		L_35 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_32, L_34, NULL);
		if (!L_35)
		{
			goto IL_010d;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_36 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_37 = (uint16_t*)(&L_36->___uint16_0_32);
		V_7 = L_37;
		uint16_t* L_38 = V_7;
		V_6 = (uint16_t*)((uintptr_t)L_38);
		V_8 = 0;
		goto IL_00ff;
	}

IL_00e5:
	{
		uint16_t* L_39 = V_6;
		int32_t L_40 = V_8;
		il2cpp_codegen_memcpy(L_41, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_42 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_41);
		*((int16_t*)((uint16_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 2))))) = (int16_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_42, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		int32_t L_43 = V_8;
		V_8 = ((int32_t)il2cpp_codegen_add(L_43, 1));
	}

IL_00ff:
	{
		int32_t L_44 = V_8;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_45;
		L_45 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_44) < ((int32_t)L_45)))
		{
			goto IL_00e5;
		}
	}
	{
		V_7 = (uint16_t*)((uintptr_t)0);
		return;
	}

IL_010d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_46 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_47;
		L_47 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_46, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_48 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_49;
		L_49 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_48, NULL);
		bool L_50;
		L_50 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_47, L_49, NULL);
		if (!L_50)
		{
			goto IL_0167;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_51 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_52 = (int16_t*)(&L_51->___int16_0_40);
		V_10 = L_52;
		int16_t* L_53 = V_10;
		V_9 = (int16_t*)((uintptr_t)L_53);
		V_11 = 0;
		goto IL_0159;
	}

IL_013f:
	{
		int16_t* L_54 = V_9;
		int32_t L_55 = V_11;
		il2cpp_codegen_memcpy(L_56, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_57 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_56);
		*((int16_t*)((int16_t*)il2cpp_codegen_add((intptr_t)L_54, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_55), 2))))) = (int16_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_57, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		int32_t L_58 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_58, 1));
	}

IL_0159:
	{
		int32_t L_59 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_60;
		L_60 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_59) < ((int32_t)L_60)))
		{
			goto IL_013f;
		}
	}
	{
		V_10 = (int16_t*)((uintptr_t)0);
		return;
	}

IL_0167:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_61 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_62;
		L_62 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_61, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		bool L_65;
		L_65 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_62, L_64, NULL);
		if (!L_65)
		{
			goto IL_01c1;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_66 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_67 = (uint32_t*)(&L_66->___uint32_0_48);
		V_13 = L_67;
		uint32_t* L_68 = V_13;
		V_12 = (uint32_t*)((uintptr_t)L_68);
		V_14 = 0;
		goto IL_01b3;
	}

IL_0199:
	{
		uint32_t* L_69 = V_12;
		int32_t L_70 = V_14;
		il2cpp_codegen_memcpy(L_71, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_72 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_71);
		*((int32_t*)((uint32_t*)il2cpp_codegen_add((intptr_t)L_69, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_70), 4))))) = (int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_72, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		int32_t L_73 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_add(L_73, 1));
	}

IL_01b3:
	{
		int32_t L_74 = V_14;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_75;
		L_75 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_74) < ((int32_t)L_75)))
		{
			goto IL_0199;
		}
	}
	{
		V_13 = (uint32_t*)((uintptr_t)0);
		return;
	}

IL_01c1:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_76 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_77;
		L_77 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_76, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_78 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_79;
		L_79 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_78, NULL);
		bool L_80;
		L_80 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_77, L_79, NULL);
		if (!L_80)
		{
			goto IL_021b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_81 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_82 = (int32_t*)(&L_81->___int32_0_52);
		V_16 = L_82;
		int32_t* L_83 = V_16;
		V_15 = (int32_t*)((uintptr_t)L_83);
		V_17 = 0;
		goto IL_020d;
	}

IL_01f3:
	{
		int32_t* L_84 = V_15;
		int32_t L_85 = V_17;
		il2cpp_codegen_memcpy(L_86, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_87 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_86);
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_87, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		int32_t L_88 = V_17;
		V_17 = ((int32_t)il2cpp_codegen_add(L_88, 1));
	}

IL_020d:
	{
		int32_t L_89 = V_17;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_90;
		L_90 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_89) < ((int32_t)L_90)))
		{
			goto IL_01f3;
		}
	}
	{
		V_16 = (int32_t*)((uintptr_t)0);
		return;
	}

IL_021b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_91 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_92;
		L_92 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_91, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_93 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_94;
		L_94 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_93, NULL);
		bool L_95;
		L_95 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_92, L_94, NULL);
		if (!L_95)
		{
			goto IL_0275;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_96 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_97 = (uint64_t*)(&L_96->___uint64_0_56);
		V_19 = L_97;
		uint64_t* L_98 = V_19;
		V_18 = (uint64_t*)((uintptr_t)L_98);
		V_20 = 0;
		goto IL_0267;
	}

IL_024d:
	{
		uint64_t* L_99 = V_18;
		int32_t L_100 = V_20;
		il2cpp_codegen_memcpy(L_101, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_102 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_101);
		*((int64_t*)((uint64_t*)il2cpp_codegen_add((intptr_t)L_99, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_100), 8))))) = (int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_102, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		int32_t L_103 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_103, 1));
	}

IL_0267:
	{
		int32_t L_104 = V_20;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_105;
		L_105 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_104) < ((int32_t)L_105)))
		{
			goto IL_024d;
		}
	}
	{
		V_19 = (uint64_t*)((uintptr_t)0);
		return;
	}

IL_0275:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_106 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_107;
		L_107 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_106, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_108 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_109;
		L_109 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_108, NULL);
		bool L_110;
		L_110 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_107, L_109, NULL);
		if (!L_110)
		{
			goto IL_02cf;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_111 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_112 = (int64_t*)(&L_111->___int64_0_58);
		V_22 = L_112;
		int64_t* L_113 = V_22;
		V_21 = (int64_t*)((uintptr_t)L_113);
		V_23 = 0;
		goto IL_02c1;
	}

IL_02a7:
	{
		int64_t* L_114 = V_21;
		int32_t L_115 = V_23;
		il2cpp_codegen_memcpy(L_116, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_117 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_116);
		*((int64_t*)((int64_t*)il2cpp_codegen_add((intptr_t)L_114, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_115), 8))))) = (int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_117, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		int32_t L_118 = V_23;
		V_23 = ((int32_t)il2cpp_codegen_add(L_118, 1));
	}

IL_02c1:
	{
		int32_t L_119 = V_23;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_120;
		L_120 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_119) < ((int32_t)L_120)))
		{
			goto IL_02a7;
		}
	}
	{
		V_22 = (int64_t*)((uintptr_t)0);
		return;
	}

IL_02cf:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_121 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_122;
		L_122 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_121, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_123 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_124;
		L_124 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_123, NULL);
		bool L_125;
		L_125 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_122, L_124, NULL);
		if (!L_125)
		{
			goto IL_0329;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_126 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_127 = (float*)(&L_126->___single_0_60);
		V_25 = L_127;
		float* L_128 = V_25;
		V_24 = (float*)((uintptr_t)L_128);
		V_26 = 0;
		goto IL_031b;
	}

IL_0301:
	{
		float* L_129 = V_24;
		int32_t L_130 = V_26;
		il2cpp_codegen_memcpy(L_131, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_132 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_131);
		*((float*)((float*)il2cpp_codegen_add((intptr_t)L_129, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_130), 4))))) = (float)((*(float*)((float*)(float*)UnBox(L_132, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		int32_t L_133 = V_26;
		V_26 = ((int32_t)il2cpp_codegen_add(L_133, 1));
	}

IL_031b:
	{
		int32_t L_134 = V_26;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_135;
		L_135 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_134) < ((int32_t)L_135)))
		{
			goto IL_0301;
		}
	}
	{
		V_25 = (float*)((uintptr_t)0);
		return;
	}

IL_0329:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_136 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_137;
		L_137 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_136, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_138 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_139;
		L_139 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_138, NULL);
		bool L_140;
		L_140 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_137, L_139, NULL);
		if (!L_140)
		{
			goto IL_0a55;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_141 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_142 = (double*)(&L_141->___double_0_64);
		V_28 = L_142;
		double* L_143 = V_28;
		V_27 = (double*)((uintptr_t)L_143);
		V_29 = 0;
		goto IL_0378;
	}

IL_035e:
	{
		double* L_144 = V_27;
		int32_t L_145 = V_29;
		il2cpp_codegen_memcpy(L_146, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_147 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_146);
		*((double*)((double*)il2cpp_codegen_add((intptr_t)L_144, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_145), 8))))) = (double)((*(double*)((double*)(double*)UnBox(L_147, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
		int32_t L_148 = V_29;
		V_29 = ((int32_t)il2cpp_codegen_add(L_148, 1));
	}

IL_0378:
	{
		int32_t L_149 = V_29;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_150;
		L_150 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_149) < ((int32_t)L_150)))
		{
			goto IL_035e;
		}
	}
	{
		V_28 = (double*)((uintptr_t)0);
		return;
	}

IL_0386:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_151 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_152;
		L_152 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_151, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_153 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_154;
		L_154 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_153, NULL);
		bool L_155;
		L_155 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_152, L_154, NULL);
		if (!L_155)
		{
			goto IL_0505;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_156 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_157, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_158 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_157);
		L_156->___byte_0_0 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_158, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_159 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_160, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_161 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_160);
		L_159->___byte_1_1 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_161, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_162 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_163, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_164 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_163);
		L_162->___byte_2_2 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_164, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_165 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_166, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_167 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_166);
		L_165->___byte_3_3 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_167, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_168 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_169, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_170 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_169);
		L_168->___byte_4_4 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_170, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_171 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_172, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_173 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_172);
		L_171->___byte_5_5 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_173, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_174 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_175, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_176 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_175);
		L_174->___byte_6_6 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_176, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_177 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_178, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_179 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_178);
		L_177->___byte_7_7 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_179, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_180 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_181, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_182 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_181);
		L_180->___byte_8_8 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_182, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_183 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_184, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_185 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_184);
		L_183->___byte_9_9 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_185, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_186 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_187, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_188 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_187);
		L_186->___byte_10_10 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_188, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_189 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_190, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_191 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_190);
		L_189->___byte_11_11 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_191, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_192 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_193, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_194 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_193);
		L_192->___byte_12_12 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_194, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_195 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_196, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_197 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_196);
		L_195->___byte_13_13 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_197, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_198 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_199, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_200 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_199);
		L_198->___byte_14_14 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_200, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_201 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_202, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_203 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_202);
		L_201->___byte_15_15 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_203, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		return;
	}

IL_0505:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_204 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_205;
		L_205 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_204, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_206 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_207;
		L_207 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_206, NULL);
		bool L_208;
		L_208 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_205, L_207, NULL);
		if (!L_208)
		{
			goto IL_0684;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_209 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_210, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_211 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_210);
		L_209->___sbyte_0_16 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_211, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_212 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_213, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_214 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_213);
		L_212->___sbyte_1_17 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_214, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_215 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_216, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_217 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_216);
		L_215->___sbyte_2_18 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_217, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_218 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_219, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_220 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_219);
		L_218->___sbyte_3_19 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_220, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_221 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_222, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_223 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_222);
		L_221->___sbyte_4_20 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_223, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_224 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_225, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_226 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_225);
		L_224->___sbyte_5_21 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_226, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_227 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_228, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_229 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_228);
		L_227->___sbyte_6_22 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_229, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_230 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_231, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_232 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_231);
		L_230->___sbyte_7_23 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_232, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_233 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_234, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_235 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_234);
		L_233->___sbyte_8_24 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_235, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_236 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_237, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_238 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_237);
		L_236->___sbyte_9_25 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_238, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_239 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_240, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_241 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_240);
		L_239->___sbyte_10_26 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_241, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_242 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_243, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_244 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_243);
		L_242->___sbyte_11_27 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_244, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_245 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_246, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_247 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_246);
		L_245->___sbyte_12_28 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_247, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_248 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_249, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_250 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_249);
		L_248->___sbyte_13_29 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_250, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_251 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_252, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_253 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_252);
		L_251->___sbyte_14_30 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_253, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_254 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_255, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_256 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_255);
		L_254->___sbyte_15_31 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_256, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		return;
	}

IL_0684:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_257 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_258;
		L_258 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_257, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_259 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_260;
		L_260 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_259, NULL);
		bool L_261;
		L_261 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_258, L_260, NULL);
		if (!L_261)
		{
			goto IL_0753;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_262 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_263, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_264 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_263);
		L_262->___uint16_0_32 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_264, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_265 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_266, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_267 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_266);
		L_265->___uint16_1_33 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_267, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_268 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_269, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_270 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_269);
		L_268->___uint16_2_34 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_270, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_271 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_272, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_273 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_272);
		L_271->___uint16_3_35 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_273, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_274 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_275, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_276 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_275);
		L_274->___uint16_4_36 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_276, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_277 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_278, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_279 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_278);
		L_277->___uint16_5_37 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_279, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_280 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_281, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_282 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_281);
		L_280->___uint16_6_38 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_282, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_283 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_284, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_285 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_284);
		L_283->___uint16_7_39 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_285, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		return;
	}

IL_0753:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_286 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_287;
		L_287 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_286, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_288 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_289;
		L_289 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_288, NULL);
		bool L_290;
		L_290 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_287, L_289, NULL);
		if (!L_290)
		{
			goto IL_0822;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_291 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_292, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_293 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_292);
		L_291->___int16_0_40 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_293, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_294 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_295, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_296 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_295);
		L_294->___int16_1_41 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_296, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_297 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_298, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_299 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_298);
		L_297->___int16_2_42 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_299, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_300 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_301, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_302 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_301);
		L_300->___int16_3_43 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_302, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_303 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_304, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_305 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_304);
		L_303->___int16_4_44 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_305, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_306 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_307, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_308 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_307);
		L_306->___int16_5_45 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_308, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_309 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_310, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_311 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_310);
		L_309->___int16_6_46 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_311, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_312 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_313, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_314 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_313);
		L_312->___int16_7_47 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_314, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		return;
	}

IL_0822:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_315 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_316;
		L_316 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_315, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_317 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_318;
		L_318 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_317, NULL);
		bool L_319;
		L_319 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_316, L_318, NULL);
		if (!L_319)
		{
			goto IL_0896;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_320 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_321, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_322 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_321);
		L_320->___uint32_0_48 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_322, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_323 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_324, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_325 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_324);
		L_323->___uint32_1_49 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_325, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_326 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_327, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_328 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_327);
		L_326->___uint32_2_50 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_328, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_329 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_330, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_331 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_330);
		L_329->___uint32_3_51 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_331, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		return;
	}

IL_0896:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_332 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_333;
		L_333 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_332, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_334 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_335;
		L_335 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_334, NULL);
		bool L_336;
		L_336 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_333, L_335, NULL);
		if (!L_336)
		{
			goto IL_090a;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_337 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_338, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_339 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_338);
		L_337->___int32_0_52 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_339, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_340 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_341, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_342 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_341);
		L_340->___int32_1_53 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_342, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_343 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_344, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_345 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_344);
		L_343->___int32_2_54 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_345, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_346 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_347, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_348 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_347);
		L_346->___int32_3_55 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_348, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		return;
	}

IL_090a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_349 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_350;
		L_350 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_349, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_351 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_352;
		L_352 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_351, NULL);
		bool L_353;
		L_353 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_350, L_352, NULL);
		if (!L_353)
		{
			goto IL_0952;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_354 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_355, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_356 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_355);
		L_354->___uint64_0_56 = ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_356, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_357 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_358, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_359 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_358);
		L_357->___uint64_1_57 = ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_359, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		return;
	}

IL_0952:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_360 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_361;
		L_361 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_360, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_362 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_363;
		L_363 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_362, NULL);
		bool L_364;
		L_364 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_361, L_363, NULL);
		if (!L_364)
		{
			goto IL_099a;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_365 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_366, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_367 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_366);
		L_365->___int64_0_58 = ((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_367, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_368 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_369, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_370 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_369);
		L_368->___int64_1_59 = ((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_370, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		return;
	}

IL_099a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_371 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_372;
		L_372 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_371, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_373 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_374;
		L_374 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_373, NULL);
		bool L_375;
		L_375 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_372, L_374, NULL);
		if (!L_375)
		{
			goto IL_0a0e;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_376 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_377, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_378 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_377);
		L_376->___single_0_60 = ((*(float*)((float*)(float*)UnBox(L_378, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_379 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_380, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_381 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_380);
		L_379->___single_1_61 = ((*(float*)((float*)(float*)UnBox(L_381, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_382 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_383, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_384 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_383);
		L_382->___single_2_62 = ((*(float*)((float*)(float*)UnBox(L_384, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_385 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_386, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_387 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_386);
		L_385->___single_3_63 = ((*(float*)((float*)(float*)UnBox(L_387, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		return;
	}

IL_0a0e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_388 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_389;
		L_389 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_388, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_390 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_391;
		L_391 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_390, NULL);
		bool L_392;
		L_392 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_389, L_391, NULL);
		if (!L_392)
		{
			goto IL_0a55;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_393 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_394, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_395 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_394);
		L_393->___double_0_64 = ((*(double*)((double*)(double*)UnBox(L_395, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_396 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		il2cpp_codegen_memcpy(L_397, ___value0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_398 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_397);
		L_396->___double_1_65 = ((*(double*)((double*)(double*)UnBox(L_398, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
	}

IL_0a55:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2_AdjustorThunk (RuntimeObject* __this, Il2CppFullySharedGenericStruct ___value0, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2(_thisAdjusted, ___value0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, void* ___dataPointer0, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___dataPointer0;
		((  void (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, void*, int32_t, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6)))(__this, L_0, 0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		return;
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001_AdjustorThunk (RuntimeObject* __this, void* ___dataPointer0, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001(_thisAdjusted, ___dataPointer0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	uint8_t* V_0 = NULL;
	uint8_t* V_1 = NULL;
	uint8_t* V_2 = NULL;
	int32_t V_3 = 0;
	int8_t* V_4 = NULL;
	int8_t* V_5 = NULL;
	int8_t* V_6 = NULL;
	int32_t V_7 = 0;
	uint16_t* V_8 = NULL;
	uint16_t* V_9 = NULL;
	uint16_t* V_10 = NULL;
	int32_t V_11 = 0;
	int16_t* V_12 = NULL;
	int16_t* V_13 = NULL;
	int16_t* V_14 = NULL;
	int32_t V_15 = 0;
	uint32_t* V_16 = NULL;
	uint32_t* V_17 = NULL;
	uint32_t* V_18 = NULL;
	int32_t V_19 = 0;
	int32_t* V_20 = NULL;
	int32_t* V_21 = NULL;
	int32_t* V_22 = NULL;
	int32_t V_23 = 0;
	uint64_t* V_24 = NULL;
	uint64_t* V_25 = NULL;
	uint64_t* V_26 = NULL;
	int32_t V_27 = 0;
	int64_t* V_28 = NULL;
	int64_t* V_29 = NULL;
	int64_t* V_30 = NULL;
	int32_t V_31 = 0;
	float* V_32 = NULL;
	float* V_33 = NULL;
	float* V_34 = NULL;
	int32_t V_35 = 0;
	double* V_36 = NULL;
	double* V_37 = NULL;
	double* V_38 = NULL;
	int32_t V_39 = 0;
	{
		il2cpp_codegen_initobj(__this, sizeof(Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2));
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0053;
		}
	}
	{
		void* L_5 = ___dataPointer0;
		V_0 = (uint8_t*)L_5;
		uint8_t* L_6 = V_0;
		int32_t L_7 = ___offset1;
		V_0 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_6, L_7));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_8 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_9 = (uint8_t*)(&L_8->___byte_0_0);
		V_2 = L_9;
		uint8_t* L_10 = V_2;
		V_1 = (uint8_t*)((uintptr_t)L_10);
		V_3 = 0;
		goto IL_0047;
	}

IL_003b:
	{
		uint8_t* L_11 = V_1;
		int32_t L_12 = V_3;
		uint8_t* L_13 = V_0;
		int32_t L_14 = V_3;
		int32_t L_15 = *((uint8_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_13, L_14)));
		*((int8_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_11, L_12))) = (int8_t)L_15;
		int32_t L_16 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_16, 1));
	}

IL_0047:
	{
		int32_t L_17 = V_3;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_18;
		L_18 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_17) < ((int32_t)L_18)))
		{
			goto IL_003b;
		}
	}
	{
		V_2 = (uint8_t*)((uintptr_t)0);
		return;
	}

IL_0053:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_19 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_20;
		L_20 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_19, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_21 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_22;
		L_22 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_21, NULL);
		bool L_23;
		L_23 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_20, L_22, NULL);
		if (!L_23)
		{
			goto IL_00ae;
		}
	}
	{
		void* L_24 = ___dataPointer0;
		V_4 = (int8_t*)L_24;
		int8_t* L_25 = V_4;
		int32_t L_26 = ___offset1;
		V_4 = ((int8_t*)il2cpp_codegen_add((intptr_t)L_25, L_26));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_27 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_28 = (int8_t*)(&L_27->___sbyte_0_16);
		V_6 = L_28;
		int8_t* L_29 = V_6;
		V_5 = (int8_t*)((uintptr_t)L_29);
		V_7 = 0;
		goto IL_00a0;
	}

IL_008e:
	{
		int8_t* L_30 = V_5;
		int32_t L_31 = V_7;
		int8_t* L_32 = V_4;
		int32_t L_33 = V_7;
		int32_t L_34 = *((int8_t*)((int8_t*)il2cpp_codegen_add((intptr_t)L_32, L_33)));
		*((int8_t*)((int8_t*)il2cpp_codegen_add((intptr_t)L_30, L_31))) = (int8_t)L_34;
		int32_t L_35 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00a0:
	{
		int32_t L_36 = V_7;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_37;
		L_37 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_36) < ((int32_t)L_37)))
		{
			goto IL_008e;
		}
	}
	{
		V_6 = (int8_t*)((uintptr_t)0);
		return;
	}

IL_00ae:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_38 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_39;
		L_39 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_38, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_40 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_41;
		L_41 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_40, NULL);
		bool L_42;
		L_42 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_39, L_41, NULL);
		if (!L_42)
		{
			goto IL_0112;
		}
	}
	{
		void* L_43 = ___dataPointer0;
		V_8 = (uint16_t*)L_43;
		uint16_t* L_44 = V_8;
		int32_t L_45 = ___offset1;
		V_8 = ((uint16_t*)il2cpp_codegen_add((intptr_t)L_44, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_45), 2))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_46 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_47 = (uint16_t*)(&L_46->___uint16_0_32);
		V_10 = L_47;
		uint16_t* L_48 = V_10;
		V_9 = (uint16_t*)((uintptr_t)L_48);
		V_11 = 0;
		goto IL_0104;
	}

IL_00ec:
	{
		uint16_t* L_49 = V_9;
		int32_t L_50 = V_11;
		uint16_t* L_51 = V_8;
		int32_t L_52 = V_11;
		int32_t L_53 = *((uint16_t*)((uint16_t*)il2cpp_codegen_add((intptr_t)L_51, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_52), 2)))));
		*((int16_t*)((uint16_t*)il2cpp_codegen_add((intptr_t)L_49, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_50), 2))))) = (int16_t)L_53;
		int32_t L_54 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_54, 1));
	}

IL_0104:
	{
		int32_t L_55 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_56;
		L_56 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_55) < ((int32_t)L_56)))
		{
			goto IL_00ec;
		}
	}
	{
		V_10 = (uint16_t*)((uintptr_t)0);
		return;
	}

IL_0112:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_57 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_58;
		L_58 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_57, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_59 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_60;
		L_60 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_59, NULL);
		bool L_61;
		L_61 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_58, L_60, NULL);
		if (!L_61)
		{
			goto IL_0176;
		}
	}
	{
		void* L_62 = ___dataPointer0;
		V_12 = (int16_t*)L_62;
		int16_t* L_63 = V_12;
		int32_t L_64 = ___offset1;
		V_12 = ((int16_t*)il2cpp_codegen_add((intptr_t)L_63, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_64), 2))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_65 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_66 = (int16_t*)(&L_65->___int16_0_40);
		V_14 = L_66;
		int16_t* L_67 = V_14;
		V_13 = (int16_t*)((uintptr_t)L_67);
		V_15 = 0;
		goto IL_0168;
	}

IL_0150:
	{
		int16_t* L_68 = V_13;
		int32_t L_69 = V_15;
		int16_t* L_70 = V_12;
		int32_t L_71 = V_15;
		int32_t L_72 = *((int16_t*)((int16_t*)il2cpp_codegen_add((intptr_t)L_70, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_71), 2)))));
		*((int16_t*)((int16_t*)il2cpp_codegen_add((intptr_t)L_68, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_69), 2))))) = (int16_t)L_72;
		int32_t L_73 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_add(L_73, 1));
	}

IL_0168:
	{
		int32_t L_74 = V_15;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_75;
		L_75 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_74) < ((int32_t)L_75)))
		{
			goto IL_0150;
		}
	}
	{
		V_14 = (int16_t*)((uintptr_t)0);
		return;
	}

IL_0176:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_76 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_77;
		L_77 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_76, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_78 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_79;
		L_79 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_78, NULL);
		bool L_80;
		L_80 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_77, L_79, NULL);
		if (!L_80)
		{
			goto IL_01da;
		}
	}
	{
		void* L_81 = ___dataPointer0;
		V_16 = (uint32_t*)L_81;
		uint32_t* L_82 = V_16;
		int32_t L_83 = ___offset1;
		V_16 = ((uint32_t*)il2cpp_codegen_add((intptr_t)L_82, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_83), 4))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_84 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_85 = (uint32_t*)(&L_84->___uint32_0_48);
		V_18 = L_85;
		uint32_t* L_86 = V_18;
		V_17 = (uint32_t*)((uintptr_t)L_86);
		V_19 = 0;
		goto IL_01cc;
	}

IL_01b4:
	{
		uint32_t* L_87 = V_17;
		int32_t L_88 = V_19;
		uint32_t* L_89 = V_16;
		int32_t L_90 = V_19;
		int32_t L_91 = *((uint32_t*)((uint32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4)))));
		*((int32_t*)((uint32_t*)il2cpp_codegen_add((intptr_t)L_87, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_88), 4))))) = (int32_t)L_91;
		int32_t L_92 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_92, 1));
	}

IL_01cc:
	{
		int32_t L_93 = V_19;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_94;
		L_94 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_93) < ((int32_t)L_94)))
		{
			goto IL_01b4;
		}
	}
	{
		V_18 = (uint32_t*)((uintptr_t)0);
		return;
	}

IL_01da:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_95 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_96;
		L_96 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_95, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_97 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_98;
		L_98 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_97, NULL);
		bool L_99;
		L_99 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_96, L_98, NULL);
		if (!L_99)
		{
			goto IL_023e;
		}
	}
	{
		void* L_100 = ___dataPointer0;
		V_20 = (int32_t*)L_100;
		int32_t* L_101 = V_20;
		int32_t L_102 = ___offset1;
		V_20 = ((int32_t*)il2cpp_codegen_add((intptr_t)L_101, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_102), 4))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_103 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_104 = (int32_t*)(&L_103->___int32_0_52);
		V_22 = L_104;
		int32_t* L_105 = V_22;
		V_21 = (int32_t*)((uintptr_t)L_105);
		V_23 = 0;
		goto IL_0230;
	}

IL_0218:
	{
		int32_t* L_106 = V_21;
		int32_t L_107 = V_23;
		int32_t* L_108 = V_20;
		int32_t L_109 = V_23;
		int32_t L_110 = *((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_108, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_109), 4)))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_106, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_107), 4))))) = (int32_t)L_110;
		int32_t L_111 = V_23;
		V_23 = ((int32_t)il2cpp_codegen_add(L_111, 1));
	}

IL_0230:
	{
		int32_t L_112 = V_23;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_113;
		L_113 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_112) < ((int32_t)L_113)))
		{
			goto IL_0218;
		}
	}
	{
		V_22 = (int32_t*)((uintptr_t)0);
		return;
	}

IL_023e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_114 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_115;
		L_115 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_114, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_116 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_117;
		L_117 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_116, NULL);
		bool L_118;
		L_118 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_115, L_117, NULL);
		if (!L_118)
		{
			goto IL_02a2;
		}
	}
	{
		void* L_119 = ___dataPointer0;
		V_24 = (uint64_t*)L_119;
		uint64_t* L_120 = V_24;
		int32_t L_121 = ___offset1;
		V_24 = ((uint64_t*)il2cpp_codegen_add((intptr_t)L_120, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_121), 8))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_122 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_123 = (uint64_t*)(&L_122->___uint64_0_56);
		V_26 = L_123;
		uint64_t* L_124 = V_26;
		V_25 = (uint64_t*)((uintptr_t)L_124);
		V_27 = 0;
		goto IL_0294;
	}

IL_027c:
	{
		uint64_t* L_125 = V_25;
		int32_t L_126 = V_27;
		uint64_t* L_127 = V_24;
		int32_t L_128 = V_27;
		int64_t L_129 = *((int64_t*)((uint64_t*)il2cpp_codegen_add((intptr_t)L_127, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_128), 8)))));
		*((int64_t*)((uint64_t*)il2cpp_codegen_add((intptr_t)L_125, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_126), 8))))) = (int64_t)L_129;
		int32_t L_130 = V_27;
		V_27 = ((int32_t)il2cpp_codegen_add(L_130, 1));
	}

IL_0294:
	{
		int32_t L_131 = V_27;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_132;
		L_132 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_131) < ((int32_t)L_132)))
		{
			goto IL_027c;
		}
	}
	{
		V_26 = (uint64_t*)((uintptr_t)0);
		return;
	}

IL_02a2:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_133 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_134;
		L_134 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_133, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_135 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_136;
		L_136 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_135, NULL);
		bool L_137;
		L_137 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_134, L_136, NULL);
		if (!L_137)
		{
			goto IL_0306;
		}
	}
	{
		void* L_138 = ___dataPointer0;
		V_28 = (int64_t*)L_138;
		int64_t* L_139 = V_28;
		int32_t L_140 = ___offset1;
		V_28 = ((int64_t*)il2cpp_codegen_add((intptr_t)L_139, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_140), 8))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_141 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_142 = (int64_t*)(&L_141->___int64_0_58);
		V_30 = L_142;
		int64_t* L_143 = V_30;
		V_29 = (int64_t*)((uintptr_t)L_143);
		V_31 = 0;
		goto IL_02f8;
	}

IL_02e0:
	{
		int64_t* L_144 = V_29;
		int32_t L_145 = V_31;
		int64_t* L_146 = V_28;
		int32_t L_147 = V_31;
		int64_t L_148 = *((int64_t*)((int64_t*)il2cpp_codegen_add((intptr_t)L_146, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_147), 8)))));
		*((int64_t*)((int64_t*)il2cpp_codegen_add((intptr_t)L_144, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_145), 8))))) = (int64_t)L_148;
		int32_t L_149 = V_31;
		V_31 = ((int32_t)il2cpp_codegen_add(L_149, 1));
	}

IL_02f8:
	{
		int32_t L_150 = V_31;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_151;
		L_151 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_150) < ((int32_t)L_151)))
		{
			goto IL_02e0;
		}
	}
	{
		V_30 = (int64_t*)((uintptr_t)0);
		return;
	}

IL_0306:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_152 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_153;
		L_153 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_152, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_154 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_155;
		L_155 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_154, NULL);
		bool L_156;
		L_156 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_153, L_155, NULL);
		if (!L_156)
		{
			goto IL_036a;
		}
	}
	{
		void* L_157 = ___dataPointer0;
		V_32 = (float*)L_157;
		float* L_158 = V_32;
		int32_t L_159 = ___offset1;
		V_32 = ((float*)il2cpp_codegen_add((intptr_t)L_158, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_159), 4))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_160 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_161 = (float*)(&L_160->___single_0_60);
		V_34 = L_161;
		float* L_162 = V_34;
		V_33 = (float*)((uintptr_t)L_162);
		V_35 = 0;
		goto IL_035c;
	}

IL_0344:
	{
		float* L_163 = V_33;
		int32_t L_164 = V_35;
		float* L_165 = V_32;
		int32_t L_166 = V_35;
		float L_167 = *((float*)((float*)il2cpp_codegen_add((intptr_t)L_165, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_166), 4)))));
		*((float*)((float*)il2cpp_codegen_add((intptr_t)L_163, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_164), 4))))) = (float)L_167;
		int32_t L_168 = V_35;
		V_35 = ((int32_t)il2cpp_codegen_add(L_168, 1));
	}

IL_035c:
	{
		int32_t L_169 = V_35;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_170;
		L_170 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_169) < ((int32_t)L_170)))
		{
			goto IL_0344;
		}
	}
	{
		V_34 = (float*)((uintptr_t)0);
		return;
	}

IL_036a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_171 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_172;
		L_172 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_171, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_173 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_174;
		L_174 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_173, NULL);
		bool L_175;
		L_175 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_172, L_174, NULL);
		if (!L_175)
		{
			goto IL_03ce;
		}
	}
	{
		void* L_176 = ___dataPointer0;
		V_36 = (double*)L_176;
		double* L_177 = V_36;
		int32_t L_178 = ___offset1;
		V_36 = ((double*)il2cpp_codegen_add((intptr_t)L_177, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_178), 8))));
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_179 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_180 = (double*)(&L_179->___double_0_64);
		V_38 = L_180;
		double* L_181 = V_38;
		V_37 = (double*)((uintptr_t)L_181);
		V_39 = 0;
		goto IL_03c0;
	}

IL_03a8:
	{
		double* L_182 = V_37;
		int32_t L_183 = V_39;
		double* L_184 = V_36;
		int32_t L_185 = V_39;
		double L_186 = *((double*)((double*)il2cpp_codegen_add((intptr_t)L_184, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_185), 8)))));
		*((double*)((double*)il2cpp_codegen_add((intptr_t)L_182, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_183), 8))))) = (double)L_186;
		int32_t L_187 = V_39;
		V_39 = ((int32_t)il2cpp_codegen_add(L_187, 1));
	}

IL_03c0:
	{
		int32_t L_188 = V_39;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_189;
		L_189 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_188) < ((int32_t)L_189)))
		{
			goto IL_03a8;
		}
	}
	{
		V_38 = (double*)((uintptr_t)0);
		return;
	}

IL_03ce:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_190 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_190);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_190, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_190, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9_AdjustorThunk (RuntimeObject* __this, void* ___dataPointer0, int32_t ___offset1, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	Vector_1__ctor_mAD567DC632B01A95C6F418F1C6265F295D1EB0A9(_thisAdjusted, ___dataPointer0, ___offset1, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method) 
{
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_0 = ___existingRegister0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_1 = (*(Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)L_0);
		__this->___register_0 = L_1;
		return;
	}
}
IL2CPP_EXTERN_C  void Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674_AdjustorThunk (RuntimeObject* __this, Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* ___existingRegister0, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674(_thisAdjusted, ___existingRegister0, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, int32_t ___index0, Il2CppFullySharedGenericStruct* il2cppRetVal, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	uint8_t* V_0 = NULL;
	int8_t* V_1 = NULL;
	uint16_t* V_2 = NULL;
	int16_t* V_3 = NULL;
	uint32_t* V_4 = NULL;
	int32_t* V_5 = NULL;
	uint64_t* V_6 = NULL;
	int64_t* V_7 = NULL;
	float* V_8 = NULL;
	double* V_9 = NULL;
	{
		int32_t L_0 = ___index0;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_1;
		L_1 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_0) >= ((int32_t)L_1)))
		{
			goto IL_000c;
		}
	}
	{
		int32_t L_2 = ___index0;
		if ((((int32_t)L_2) >= ((int32_t)0)))
		{
			goto IL_0022;
		}
	}

IL_000c:
	{
		int32_t L_3 = ___index0;
		int32_t L_4 = L_3;
		RuntimeObject* L_5 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var)), &L_4);
		String_t* L_6;
		L_6 = SR_Format_mB99C6F1BE061EA1427A45176E0CAFB2A2C76D03F(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral491788442E76F5D7830F0DBFCF8EDD98854F636F)), L_5, NULL);
		IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82* L_7 = (IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&IndexOutOfRangeException_t7ECB35264FB6CA8FAA516BD958F4B2ADC78E8A82_il2cpp_TypeInfo_var)));
		NullCheck(L_7);
		IndexOutOfRangeException__ctor_mFD06819F05B815BE2D6E826D4E04F4C449D0A425(L_7, L_6, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C_RuntimeMethod_var)));
	}

IL_0022:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_8 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_9;
		L_9 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_8, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		bool L_12;
		L_12 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_9, L_11, NULL);
		if (!L_12)
		{
			goto IL_0059;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_13 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_14 = (uint8_t*)(&L_13->___byte_0_0);
		V_0 = L_14;
		uint8_t* L_15 = V_0;
		int32_t L_16 = ___index0;
		int32_t L_17 = *((uint8_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_15), L_16)));
		uint8_t L_18 = ((uint8_t)L_17);
		RuntimeObject* L_19 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_18);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_19, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0059:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_20 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_21;
		L_21 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_20, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_22 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_23;
		L_23 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_22, NULL);
		bool L_24;
		L_24 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_21, L_23, NULL);
		if (!L_24)
		{
			goto IL_0090;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_25 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_26 = (int8_t*)(&L_25->___sbyte_0_16);
		V_1 = L_26;
		int8_t* L_27 = V_1;
		int32_t L_28 = ___index0;
		int32_t L_29 = *((int8_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_27), L_28)));
		int8_t L_30 = ((int8_t)L_29);
		RuntimeObject* L_31 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_30);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_31, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0090:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_32, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_34 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_35;
		L_35 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_34, NULL);
		bool L_36;
		L_36 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_33, L_35, NULL);
		if (!L_36)
		{
			goto IL_00ca;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_37 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_38 = (uint16_t*)(&L_37->___uint16_0_32);
		V_2 = L_38;
		uint16_t* L_39 = V_2;
		int32_t L_40 = ___index0;
		int32_t L_41 = *((uint16_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_39), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 2)))));
		uint16_t L_42 = ((uint16_t)L_41);
		RuntimeObject* L_43 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_42);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_43, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_00ca:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_44, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_46 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_47;
		L_47 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_46, NULL);
		bool L_48;
		L_48 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_45, L_47, NULL);
		if (!L_48)
		{
			goto IL_0104;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_49 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_50 = (int16_t*)(&L_49->___int16_0_40);
		V_3 = L_50;
		int16_t* L_51 = V_3;
		int32_t L_52 = ___index0;
		int32_t L_53 = *((int16_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_51), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_52), 2)))));
		int16_t L_54 = ((int16_t)L_53);
		RuntimeObject* L_55 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_54);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0104:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0140;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_61 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_62 = (uint32_t*)(&L_61->___uint32_0_48);
		V_4 = L_62;
		uint32_t* L_63 = V_4;
		int32_t L_64 = ___index0;
		int32_t L_65 = *((uint32_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_63), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_64), 4)))));
		uint32_t L_66 = ((uint32_t)L_65);
		RuntimeObject* L_67 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_66);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_67, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0140:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_68 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_69;
		L_69 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_68, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_70 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_71;
		L_71 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_70, NULL);
		bool L_72;
		L_72 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_69, L_71, NULL);
		if (!L_72)
		{
			goto IL_017c;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_73 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_74 = (int32_t*)(&L_73->___int32_0_52);
		V_5 = L_74;
		int32_t* L_75 = V_5;
		int32_t L_76 = ___index0;
		int32_t L_77 = *((int32_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_75), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_76), 4)))));
		int32_t L_78 = L_77;
		RuntimeObject* L_79 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_78);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_79, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_017c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_80 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_81;
		L_81 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_80, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_82 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_83;
		L_83 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_82, NULL);
		bool L_84;
		L_84 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_81, L_83, NULL);
		if (!L_84)
		{
			goto IL_01b8;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_85 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_86 = (uint64_t*)(&L_85->___uint64_0_56);
		V_6 = L_86;
		uint64_t* L_87 = V_6;
		int32_t L_88 = ___index0;
		int64_t L_89 = *((int64_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_87), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_88), 8)))));
		uint64_t L_90 = ((uint64_t)L_89);
		RuntimeObject* L_91 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_90);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_91, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_01b8:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_92 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_93;
		L_93 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_92, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_94 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_95;
		L_95 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_94, NULL);
		bool L_96;
		L_96 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_93, L_95, NULL);
		if (!L_96)
		{
			goto IL_01f4;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_97 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_98 = (int64_t*)(&L_97->___int64_0_58);
		V_7 = L_98;
		int64_t* L_99 = V_7;
		int32_t L_100 = ___index0;
		int64_t L_101 = *((int64_t*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_99), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_100), 8)))));
		int64_t L_102 = L_101;
		RuntimeObject* L_103 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_102);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_103, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_01f4:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_104 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_105;
		L_105 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_104, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_106 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_107;
		L_107 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_106, NULL);
		bool L_108;
		L_108 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_105, L_107, NULL);
		if (!L_108)
		{
			goto IL_0230;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_109 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_110 = (float*)(&L_109->___single_0_60);
		V_8 = L_110;
		float* L_111 = V_8;
		int32_t L_112 = ___index0;
		float L_113 = *((float*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_111), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_112), 4)))));
		float L_114 = L_113;
		RuntimeObject* L_115 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_114);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_115, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0230:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_116 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_117;
		L_117 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_116, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_118 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_119;
		L_119 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_118, NULL);
		bool L_120;
		L_120 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_117, L_119, NULL);
		if (!L_120)
		{
			goto IL_026c;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_121 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_122 = (double*)(&L_121->___double_0_64);
		V_9 = L_122;
		double* L_123 = V_9;
		int32_t L_124 = ___index0;
		double L_125 = *((double*)((intptr_t)il2cpp_codegen_add((intptr_t)((uintptr_t)L_123), ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_124), 8)))));
		double L_126 = L_125;
		RuntimeObject* L_127 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_126);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_127, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_026c:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_128 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_128);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_128, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_128, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  void Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C_AdjustorThunk (RuntimeObject* __this, int32_t ___index0, Il2CppFullySharedGenericStruct* il2cppRetVal, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	Vector_1_get_Item_m301D7183D2063DC97710DCD2CEF970E7A67EB21C(_thisAdjusted, ___index0, il2cppRetVal, method);
	return;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_Equals_m1D6500596F9B825F39D474A32D7A6D5E14E22B8F_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = ___obj0;
		if (((RuntimeObject*)IsInstSealed((RuntimeObject*)L_0, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		RuntimeObject* L_1 = ___obj0;
		bool L_2;
		L_2 = ((  bool (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7)))(__this, ((*(Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)(Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)UnBox(L_1, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7));
		return L_2;
	}
}
IL2CPP_EXTERN_C  bool Vector_1_Equals_m1D6500596F9B825F39D474A32D7A6D5E14E22B8F_AdjustorThunk (RuntimeObject* __this, RuntimeObject* ___obj0, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	bool _returnValue;
	_returnValue = Vector_1_Equals_m1D6500596F9B825F39D474A32D7A6D5E14E22B8F_inline(_thisAdjusted, ___obj0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___other0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	const Il2CppFullySharedGenericStruct L_2 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_4 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	int32_t V_0 = 0;
	{
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_0031;
		}
	}
	{
		V_0 = 0;
		goto IL_0027;
	}

IL_000b:
	{
		int32_t L_1 = V_0;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_1, (Il2CppFullySharedGenericStruct*)L_2);
		int32_t L_3 = V_0;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___other0), L_3, (Il2CppFullySharedGenericStruct*)L_4);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_5;
		L_5 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_2, L_4);
		if (L_5)
		{
			goto IL_0023;
		}
	}
	{
		return (bool)0;
	}

IL_0023:
	{
		int32_t L_6 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_6, 1));
	}

IL_0027:
	{
		int32_t L_7 = V_0;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_8;
		L_8 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_7) < ((int32_t)L_8)))
		{
			goto IL_000b;
		}
	}
	{
		return (bool)1;
	}

IL_0031:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_9 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_10;
		L_10 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_9, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_11 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_12;
		L_12 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_11, NULL);
		bool L_13;
		L_13 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_10, L_12, NULL);
		if (!L_13)
		{
			goto IL_01f0;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_14 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_15 = (uint8_t)L_14->___byte_0_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_16 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_17 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_16.___register_0;
		uint8_t L_18 = (uint8_t)L_17.___byte_0_0;
		if ((!(((uint32_t)L_15) == ((uint32_t)L_18))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_19 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_20 = (uint8_t)L_19->___byte_1_1;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_21 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_22 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_21.___register_0;
		uint8_t L_23 = (uint8_t)L_22.___byte_1_1;
		if ((!(((uint32_t)L_20) == ((uint32_t)L_23))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_24 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_25 = (uint8_t)L_24->___byte_2_2;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_26 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_27 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_26.___register_0;
		uint8_t L_28 = (uint8_t)L_27.___byte_2_2;
		if ((!(((uint32_t)L_25) == ((uint32_t)L_28))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_29 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_30 = (uint8_t)L_29->___byte_3_3;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_31 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_32 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_31.___register_0;
		uint8_t L_33 = (uint8_t)L_32.___byte_3_3;
		if ((!(((uint32_t)L_30) == ((uint32_t)L_33))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_34 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_35 = (uint8_t)L_34->___byte_4_4;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_36 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_37 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_36.___register_0;
		uint8_t L_38 = (uint8_t)L_37.___byte_4_4;
		if ((!(((uint32_t)L_35) == ((uint32_t)L_38))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_39 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_40 = (uint8_t)L_39->___byte_5_5;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_41 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_42 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_41.___register_0;
		uint8_t L_43 = (uint8_t)L_42.___byte_5_5;
		if ((!(((uint32_t)L_40) == ((uint32_t)L_43))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_44 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_45 = (uint8_t)L_44->___byte_6_6;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_46 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_47 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_46.___register_0;
		uint8_t L_48 = (uint8_t)L_47.___byte_6_6;
		if ((!(((uint32_t)L_45) == ((uint32_t)L_48))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_49 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_50 = (uint8_t)L_49->___byte_7_7;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_51 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_52 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_51.___register_0;
		uint8_t L_53 = (uint8_t)L_52.___byte_7_7;
		if ((!(((uint32_t)L_50) == ((uint32_t)L_53))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_54 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_55 = (uint8_t)L_54->___byte_8_8;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_56 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_57 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_56.___register_0;
		uint8_t L_58 = (uint8_t)L_57.___byte_8_8;
		if ((!(((uint32_t)L_55) == ((uint32_t)L_58))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_59 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_60 = (uint8_t)L_59->___byte_9_9;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_61 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_62 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_61.___register_0;
		uint8_t L_63 = (uint8_t)L_62.___byte_9_9;
		if ((!(((uint32_t)L_60) == ((uint32_t)L_63))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_64 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_65 = (uint8_t)L_64->___byte_10_10;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_66 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_67 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_66.___register_0;
		uint8_t L_68 = (uint8_t)L_67.___byte_10_10;
		if ((!(((uint32_t)L_65) == ((uint32_t)L_68))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_69 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_70 = (uint8_t)L_69->___byte_11_11;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_71 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_72 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_71.___register_0;
		uint8_t L_73 = (uint8_t)L_72.___byte_11_11;
		if ((!(((uint32_t)L_70) == ((uint32_t)L_73))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_74 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_75 = (uint8_t)L_74->___byte_12_12;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_76 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_77 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_76.___register_0;
		uint8_t L_78 = (uint8_t)L_77.___byte_12_12;
		if ((!(((uint32_t)L_75) == ((uint32_t)L_78))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_79 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_80 = (uint8_t)L_79->___byte_13_13;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_81 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_82 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_81.___register_0;
		uint8_t L_83 = (uint8_t)L_82.___byte_13_13;
		if ((!(((uint32_t)L_80) == ((uint32_t)L_83))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_84 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_85 = (uint8_t)L_84->___byte_14_14;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_86 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_87 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_86.___register_0;
		uint8_t L_88 = (uint8_t)L_87.___byte_14_14;
		if ((!(((uint32_t)L_85) == ((uint32_t)L_88))))
		{
			goto IL_01ee;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_89 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t L_90 = (uint8_t)L_89->___byte_15_15;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_91 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_92 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_91.___register_0;
		uint8_t L_93 = (uint8_t)L_92.___byte_15_15;
		return (bool)((((int32_t)L_90) == ((int32_t)L_93))? 1 : 0);
	}

IL_01ee:
	{
		return (bool)0;
	}

IL_01f0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_94 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_95;
		L_95 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_94, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_96 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_97;
		L_97 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_96, NULL);
		bool L_98;
		L_98 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_95, L_97, NULL);
		if (!L_98)
		{
			goto IL_03af;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_99 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_100 = (int8_t)L_99->___sbyte_0_16;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_101 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_102 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_101.___register_0;
		int8_t L_103 = (int8_t)L_102.___sbyte_0_16;
		if ((!(((uint32_t)L_100) == ((uint32_t)L_103))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_104 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_105 = (int8_t)L_104->___sbyte_1_17;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_106 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_107 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_106.___register_0;
		int8_t L_108 = (int8_t)L_107.___sbyte_1_17;
		if ((!(((uint32_t)L_105) == ((uint32_t)L_108))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_109 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_110 = (int8_t)L_109->___sbyte_2_18;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_111 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_112 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_111.___register_0;
		int8_t L_113 = (int8_t)L_112.___sbyte_2_18;
		if ((!(((uint32_t)L_110) == ((uint32_t)L_113))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_114 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_115 = (int8_t)L_114->___sbyte_3_19;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_116 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_117 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_116.___register_0;
		int8_t L_118 = (int8_t)L_117.___sbyte_3_19;
		if ((!(((uint32_t)L_115) == ((uint32_t)L_118))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_119 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_120 = (int8_t)L_119->___sbyte_4_20;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_121 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_122 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_121.___register_0;
		int8_t L_123 = (int8_t)L_122.___sbyte_4_20;
		if ((!(((uint32_t)L_120) == ((uint32_t)L_123))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_124 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_125 = (int8_t)L_124->___sbyte_5_21;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_126 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_127 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_126.___register_0;
		int8_t L_128 = (int8_t)L_127.___sbyte_5_21;
		if ((!(((uint32_t)L_125) == ((uint32_t)L_128))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_129 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_130 = (int8_t)L_129->___sbyte_6_22;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_131 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_132 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_131.___register_0;
		int8_t L_133 = (int8_t)L_132.___sbyte_6_22;
		if ((!(((uint32_t)L_130) == ((uint32_t)L_133))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_134 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_135 = (int8_t)L_134->___sbyte_7_23;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_136 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_137 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_136.___register_0;
		int8_t L_138 = (int8_t)L_137.___sbyte_7_23;
		if ((!(((uint32_t)L_135) == ((uint32_t)L_138))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_139 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_140 = (int8_t)L_139->___sbyte_8_24;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_141 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_142 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_141.___register_0;
		int8_t L_143 = (int8_t)L_142.___sbyte_8_24;
		if ((!(((uint32_t)L_140) == ((uint32_t)L_143))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_144 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_145 = (int8_t)L_144->___sbyte_9_25;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_146 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_147 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_146.___register_0;
		int8_t L_148 = (int8_t)L_147.___sbyte_9_25;
		if ((!(((uint32_t)L_145) == ((uint32_t)L_148))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_149 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_150 = (int8_t)L_149->___sbyte_10_26;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_151 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_152 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_151.___register_0;
		int8_t L_153 = (int8_t)L_152.___sbyte_10_26;
		if ((!(((uint32_t)L_150) == ((uint32_t)L_153))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_154 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_155 = (int8_t)L_154->___sbyte_11_27;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_156 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_157 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_156.___register_0;
		int8_t L_158 = (int8_t)L_157.___sbyte_11_27;
		if ((!(((uint32_t)L_155) == ((uint32_t)L_158))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_159 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_160 = (int8_t)L_159->___sbyte_12_28;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_161 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_162 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_161.___register_0;
		int8_t L_163 = (int8_t)L_162.___sbyte_12_28;
		if ((!(((uint32_t)L_160) == ((uint32_t)L_163))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_164 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_165 = (int8_t)L_164->___sbyte_13_29;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_166 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_167 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_166.___register_0;
		int8_t L_168 = (int8_t)L_167.___sbyte_13_29;
		if ((!(((uint32_t)L_165) == ((uint32_t)L_168))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_169 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_170 = (int8_t)L_169->___sbyte_14_30;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_171 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_172 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_171.___register_0;
		int8_t L_173 = (int8_t)L_172.___sbyte_14_30;
		if ((!(((uint32_t)L_170) == ((uint32_t)L_173))))
		{
			goto IL_03ad;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_174 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t L_175 = (int8_t)L_174->___sbyte_15_31;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_176 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_177 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_176.___register_0;
		int8_t L_178 = (int8_t)L_177.___sbyte_15_31;
		return (bool)((((int32_t)L_175) == ((int32_t)L_178))? 1 : 0);
	}

IL_03ad:
	{
		return (bool)0;
	}

IL_03af:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_179 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_180;
		L_180 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_179, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_181 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_182;
		L_182 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_181, NULL);
		bool L_183;
		L_183 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_180, L_182, NULL);
		if (!L_183)
		{
			goto IL_0496;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_184 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_185 = (uint16_t)L_184->___uint16_0_32;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_186 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_187 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_186.___register_0;
		uint16_t L_188 = (uint16_t)L_187.___uint16_0_32;
		if ((!(((uint32_t)L_185) == ((uint32_t)L_188))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_189 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_190 = (uint16_t)L_189->___uint16_1_33;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_191 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_192 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_191.___register_0;
		uint16_t L_193 = (uint16_t)L_192.___uint16_1_33;
		if ((!(((uint32_t)L_190) == ((uint32_t)L_193))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_194 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_195 = (uint16_t)L_194->___uint16_2_34;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_196 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_197 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_196.___register_0;
		uint16_t L_198 = (uint16_t)L_197.___uint16_2_34;
		if ((!(((uint32_t)L_195) == ((uint32_t)L_198))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_199 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_200 = (uint16_t)L_199->___uint16_3_35;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_201 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_202 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_201.___register_0;
		uint16_t L_203 = (uint16_t)L_202.___uint16_3_35;
		if ((!(((uint32_t)L_200) == ((uint32_t)L_203))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_204 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_205 = (uint16_t)L_204->___uint16_4_36;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_206 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_207 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_206.___register_0;
		uint16_t L_208 = (uint16_t)L_207.___uint16_4_36;
		if ((!(((uint32_t)L_205) == ((uint32_t)L_208))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_209 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_210 = (uint16_t)L_209->___uint16_5_37;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_211 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_212 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_211.___register_0;
		uint16_t L_213 = (uint16_t)L_212.___uint16_5_37;
		if ((!(((uint32_t)L_210) == ((uint32_t)L_213))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_214 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_215 = (uint16_t)L_214->___uint16_6_38;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_216 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_217 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_216.___register_0;
		uint16_t L_218 = (uint16_t)L_217.___uint16_6_38;
		if ((!(((uint32_t)L_215) == ((uint32_t)L_218))))
		{
			goto IL_0494;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_219 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t L_220 = (uint16_t)L_219->___uint16_7_39;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_221 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_222 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_221.___register_0;
		uint16_t L_223 = (uint16_t)L_222.___uint16_7_39;
		return (bool)((((int32_t)L_220) == ((int32_t)L_223))? 1 : 0);
	}

IL_0494:
	{
		return (bool)0;
	}

IL_0496:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_224 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_225;
		L_225 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_224, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_226 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_227;
		L_227 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_226, NULL);
		bool L_228;
		L_228 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_225, L_227, NULL);
		if (!L_228)
		{
			goto IL_057d;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_229 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_230 = (int16_t)L_229->___int16_0_40;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_231 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_232 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_231.___register_0;
		int16_t L_233 = (int16_t)L_232.___int16_0_40;
		if ((!(((uint32_t)L_230) == ((uint32_t)L_233))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_234 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_235 = (int16_t)L_234->___int16_1_41;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_236 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_237 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_236.___register_0;
		int16_t L_238 = (int16_t)L_237.___int16_1_41;
		if ((!(((uint32_t)L_235) == ((uint32_t)L_238))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_239 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_240 = (int16_t)L_239->___int16_2_42;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_241 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_242 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_241.___register_0;
		int16_t L_243 = (int16_t)L_242.___int16_2_42;
		if ((!(((uint32_t)L_240) == ((uint32_t)L_243))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_244 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_245 = (int16_t)L_244->___int16_3_43;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_246 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_247 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_246.___register_0;
		int16_t L_248 = (int16_t)L_247.___int16_3_43;
		if ((!(((uint32_t)L_245) == ((uint32_t)L_248))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_249 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_250 = (int16_t)L_249->___int16_4_44;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_251 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_252 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_251.___register_0;
		int16_t L_253 = (int16_t)L_252.___int16_4_44;
		if ((!(((uint32_t)L_250) == ((uint32_t)L_253))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_254 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_255 = (int16_t)L_254->___int16_5_45;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_256 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_257 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_256.___register_0;
		int16_t L_258 = (int16_t)L_257.___int16_5_45;
		if ((!(((uint32_t)L_255) == ((uint32_t)L_258))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_259 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_260 = (int16_t)L_259->___int16_6_46;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_261 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_262 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_261.___register_0;
		int16_t L_263 = (int16_t)L_262.___int16_6_46;
		if ((!(((uint32_t)L_260) == ((uint32_t)L_263))))
		{
			goto IL_057b;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_264 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t L_265 = (int16_t)L_264->___int16_7_47;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_266 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_267 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_266.___register_0;
		int16_t L_268 = (int16_t)L_267.___int16_7_47;
		return (bool)((((int32_t)L_265) == ((int32_t)L_268))? 1 : 0);
	}

IL_057b:
	{
		return (bool)0;
	}

IL_057d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_269 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_270;
		L_270 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_269, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_271 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_272;
		L_272 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_271, NULL);
		bool L_273;
		L_273 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_270, L_272, NULL);
		if (!L_273)
		{
			goto IL_05fb;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_274 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_275 = (uint32_t)L_274->___uint32_0_48;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_276 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_277 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_276.___register_0;
		uint32_t L_278 = (uint32_t)L_277.___uint32_0_48;
		if ((!(((uint32_t)L_275) == ((uint32_t)L_278))))
		{
			goto IL_05f9;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_279 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_280 = (uint32_t)L_279->___uint32_1_49;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_281 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_282 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_281.___register_0;
		uint32_t L_283 = (uint32_t)L_282.___uint32_1_49;
		if ((!(((uint32_t)L_280) == ((uint32_t)L_283))))
		{
			goto IL_05f9;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_284 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_285 = (uint32_t)L_284->___uint32_2_50;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_286 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_287 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_286.___register_0;
		uint32_t L_288 = (uint32_t)L_287.___uint32_2_50;
		if ((!(((uint32_t)L_285) == ((uint32_t)L_288))))
		{
			goto IL_05f9;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_289 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t L_290 = (uint32_t)L_289->___uint32_3_51;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_291 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_292 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_291.___register_0;
		uint32_t L_293 = (uint32_t)L_292.___uint32_3_51;
		return (bool)((((int32_t)L_290) == ((int32_t)L_293))? 1 : 0);
	}

IL_05f9:
	{
		return (bool)0;
	}

IL_05fb:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_294 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_295;
		L_295 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_294, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_296 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_297;
		L_297 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_296, NULL);
		bool L_298;
		L_298 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_295, L_297, NULL);
		if (!L_298)
		{
			goto IL_0679;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_299 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_300 = (int32_t)L_299->___int32_0_52;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_301 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_302 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_301.___register_0;
		int32_t L_303 = (int32_t)L_302.___int32_0_52;
		if ((!(((uint32_t)L_300) == ((uint32_t)L_303))))
		{
			goto IL_0677;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_304 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_305 = (int32_t)L_304->___int32_1_53;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_306 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_307 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_306.___register_0;
		int32_t L_308 = (int32_t)L_307.___int32_1_53;
		if ((!(((uint32_t)L_305) == ((uint32_t)L_308))))
		{
			goto IL_0677;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_309 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_310 = (int32_t)L_309->___int32_2_54;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_311 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_312 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_311.___register_0;
		int32_t L_313 = (int32_t)L_312.___int32_2_54;
		if ((!(((uint32_t)L_310) == ((uint32_t)L_313))))
		{
			goto IL_0677;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_314 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t L_315 = (int32_t)L_314->___int32_3_55;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_316 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_317 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_316.___register_0;
		int32_t L_318 = (int32_t)L_317.___int32_3_55;
		return (bool)((((int32_t)L_315) == ((int32_t)L_318))? 1 : 0);
	}

IL_0677:
	{
		return (bool)0;
	}

IL_0679:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_319 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_320;
		L_320 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_319, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_321 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_322;
		L_322 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_321, NULL);
		bool L_323;
		L_323 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_320, L_322, NULL);
		if (!L_323)
		{
			goto IL_06c7;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_324 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_325 = (uint64_t)L_324->___uint64_0_56;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_326 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_327 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_326.___register_0;
		uint64_t L_328 = (uint64_t)L_327.___uint64_0_56;
		if ((!(((uint64_t)L_325) == ((uint64_t)L_328))))
		{
			goto IL_06c5;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_329 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t L_330 = (uint64_t)L_329->___uint64_1_57;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_331 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_332 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_331.___register_0;
		uint64_t L_333 = (uint64_t)L_332.___uint64_1_57;
		return (bool)((((int64_t)L_330) == ((int64_t)L_333))? 1 : 0);
	}

IL_06c5:
	{
		return (bool)0;
	}

IL_06c7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_334 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_335;
		L_335 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_334, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_336 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_337;
		L_337 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_336, NULL);
		bool L_338;
		L_338 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_335, L_337, NULL);
		if (!L_338)
		{
			goto IL_0715;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_339 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t L_340 = (int64_t)L_339->___int64_0_58;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_341 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_342 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_341.___register_0;
		int64_t L_343 = (int64_t)L_342.___int64_0_58;
		if ((!(((uint64_t)L_340) == ((uint64_t)L_343))))
		{
			goto IL_0713;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_344 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t L_345 = (int64_t)L_344->___int64_1_59;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_346 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_347 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_346.___register_0;
		int64_t L_348 = (int64_t)L_347.___int64_1_59;
		return (bool)((((int64_t)L_345) == ((int64_t)L_348))? 1 : 0);
	}

IL_0713:
	{
		return (bool)0;
	}

IL_0715:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_349 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_350;
		L_350 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_349, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_351 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_352;
		L_352 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_351, NULL);
		bool L_353;
		L_353 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_350, L_352, NULL);
		if (!L_353)
		{
			goto IL_0793;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_354 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_355 = (float)L_354->___single_0_60;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_356 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_357 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_356.___register_0;
		float L_358 = (float)L_357.___single_0_60;
		if ((!(((float)L_355) == ((float)L_358))))
		{
			goto IL_0791;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_359 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_360 = (float)L_359->___single_1_61;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_361 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_362 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_361.___register_0;
		float L_363 = (float)L_362.___single_1_61;
		if ((!(((float)L_360) == ((float)L_363))))
		{
			goto IL_0791;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_364 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_365 = (float)L_364->___single_2_62;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_366 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_367 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_366.___register_0;
		float L_368 = (float)L_367.___single_2_62;
		if ((!(((float)L_365) == ((float)L_368))))
		{
			goto IL_0791;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_369 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float L_370 = (float)L_369->___single_3_63;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_371 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_372 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_371.___register_0;
		float L_373 = (float)L_372.___single_3_63;
		return (bool)((((float)L_370) == ((float)L_373))? 1 : 0);
	}

IL_0791:
	{
		return (bool)0;
	}

IL_0793:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_374 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_375;
		L_375 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_374, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_376 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_377;
		L_377 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_376, NULL);
		bool L_378;
		L_378 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_375, L_377, NULL);
		if (!L_378)
		{
			goto IL_07e1;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_379 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double L_380 = (double)L_379->___double_0_64;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_381 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_382 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_381.___register_0;
		double L_383 = (double)L_382.___double_0_64;
		if ((!(((double)L_380) == ((double)L_383))))
		{
			goto IL_07df;
		}
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_384 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double L_385 = (double)L_384->___double_1_65;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_386 = ___other0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_387 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_386.___register_0;
		double L_388 = (double)L_387.___double_1_65;
		return (bool)((((double)L_385) == ((double)L_388))? 1 : 0);
	}

IL_07df:
	{
		return (bool)0;
	}

IL_07e1:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_389 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_389);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_389, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_389, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  bool Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8_AdjustorThunk (RuntimeObject* __this, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___other0, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	bool _returnValue;
	_returnValue = Vector_1_Equals_mBC248D1BFF0E4CEA6585C0F10707B1843A4502E8(_thisAdjusted, ___other0, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	const Il2CppFullySharedGenericStruct L_8 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_23 = L_8;
	const Il2CppFullySharedGenericStruct L_38 = L_8;
	const Il2CppFullySharedGenericStruct L_53 = L_8;
	const Il2CppFullySharedGenericStruct L_68 = L_8;
	const Il2CppFullySharedGenericStruct L_83 = L_8;
	const Il2CppFullySharedGenericStruct L_98 = L_8;
	const Il2CppFullySharedGenericStruct L_113 = L_8;
	const Il2CppFullySharedGenericStruct L_128 = L_8;
	const Il2CppFullySharedGenericStruct L_143 = L_8;
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	uint8_t V_2 = 0x0;
	int32_t V_3 = 0;
	int8_t V_4 = 0x0;
	int32_t V_5 = 0;
	uint16_t V_6 = 0;
	int32_t V_7 = 0;
	int16_t V_8 = 0;
	int32_t V_9 = 0;
	uint32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	uint64_t V_14 = 0;
	int32_t V_15 = 0;
	int64_t V_16 = 0;
	int32_t V_17 = 0;
	float V_18 = 0.0f;
	int32_t V_19 = 0;
	double V_20 = 0.0;
	{
		V_0 = 0;
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_034a;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_3, NULL);
		bool L_5;
		L_5 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_2, L_4, NULL);
		if (!L_5)
		{
			goto IL_0059;
		}
	}
	{
		V_1 = 0;
		goto IL_004f;
	}

IL_002b:
	{
		int32_t L_6 = V_0;
		int32_t L_7 = V_1;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_7, (Il2CppFullySharedGenericStruct*)L_8);
		RuntimeObject* L_9 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_8);
		V_2 = ((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_9, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))));
		int32_t L_10;
		L_10 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678((&V_2), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_11;
		L_11 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_6, L_10, NULL);
		V_0 = L_11;
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_004f:
	{
		int32_t L_13 = V_1;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_14;
		L_14 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_13) < ((int32_t)L_14)))
		{
			goto IL_002b;
		}
	}
	{
		int32_t L_15 = V_0;
		return L_15;
	}

IL_0059:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_18 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_19;
		L_19 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_18, NULL);
		bool L_20;
		L_20 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_17, L_19, NULL);
		if (!L_20)
		{
			goto IL_00a7;
		}
	}
	{
		V_3 = 0;
		goto IL_009d;
	}

IL_0078:
	{
		int32_t L_21 = V_0;
		int32_t L_22 = V_3;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_22, (Il2CppFullySharedGenericStruct*)L_23);
		RuntimeObject* L_24 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_23);
		V_4 = ((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_24, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))));
		int32_t L_25;
		L_25 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF((&V_4), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_26;
		L_26 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_21, L_25, NULL);
		V_0 = L_26;
		int32_t L_27 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_27, 1));
	}

IL_009d:
	{
		int32_t L_28 = V_3;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_29;
		L_29 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_28) < ((int32_t)L_29)))
		{
			goto IL_0078;
		}
	}
	{
		int32_t L_30 = V_0;
		return L_30;
	}

IL_00a7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_31 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_32;
		L_32 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_31, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_33 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_34;
		L_34 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_33, NULL);
		bool L_35;
		L_35 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_32, L_34, NULL);
		if (!L_35)
		{
			goto IL_00fa;
		}
	}
	{
		V_5 = 0;
		goto IL_00ef;
	}

IL_00c7:
	{
		int32_t L_36 = V_0;
		int32_t L_37 = V_5;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_37, (Il2CppFullySharedGenericStruct*)L_38);
		RuntimeObject* L_39 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_38);
		V_6 = ((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_39, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))));
		int32_t L_40;
		L_40 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200((&V_6), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_41;
		L_41 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_36, L_40, NULL);
		V_0 = L_41;
		int32_t L_42 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_42, 1));
	}

IL_00ef:
	{
		int32_t L_43 = V_5;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_44;
		L_44 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_43) < ((int32_t)L_44)))
		{
			goto IL_00c7;
		}
	}
	{
		int32_t L_45 = V_0;
		return L_45;
	}

IL_00fa:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_46 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_47;
		L_47 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_46, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_48 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_49;
		L_49 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_48, NULL);
		bool L_50;
		L_50 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_47, L_49, NULL);
		if (!L_50)
		{
			goto IL_014d;
		}
	}
	{
		V_7 = 0;
		goto IL_0142;
	}

IL_011a:
	{
		int32_t L_51 = V_0;
		int32_t L_52 = V_7;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_52, (Il2CppFullySharedGenericStruct*)L_53);
		RuntimeObject* L_54 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_53);
		V_8 = ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_54, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
		int32_t L_55;
		L_55 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1((&V_8), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_56;
		L_56 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_51, L_55, NULL);
		V_0 = L_56;
		int32_t L_57 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_57, 1));
	}

IL_0142:
	{
		int32_t L_58 = V_7;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_59;
		L_59 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_58) < ((int32_t)L_59)))
		{
			goto IL_011a;
		}
	}
	{
		int32_t L_60 = V_0;
		return L_60;
	}

IL_014d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_61 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_62;
		L_62 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_61, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		bool L_65;
		L_65 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_62, L_64, NULL);
		if (!L_65)
		{
			goto IL_01a0;
		}
	}
	{
		V_9 = 0;
		goto IL_0195;
	}

IL_016d:
	{
		int32_t L_66 = V_0;
		int32_t L_67 = V_9;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_67, (Il2CppFullySharedGenericStruct*)L_68);
		RuntimeObject* L_69 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_68);
		V_10 = ((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_69, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))));
		int32_t L_70;
		L_70 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC((&V_10), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_71;
		L_71 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_66, L_70, NULL);
		V_0 = L_71;
		int32_t L_72 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_72, 1));
	}

IL_0195:
	{
		int32_t L_73 = V_9;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_74;
		L_74 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_73) < ((int32_t)L_74)))
		{
			goto IL_016d;
		}
	}
	{
		int32_t L_75 = V_0;
		return L_75;
	}

IL_01a0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_76 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_77;
		L_77 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_76, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_78 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_79;
		L_79 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_78, NULL);
		bool L_80;
		L_80 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_77, L_79, NULL);
		if (!L_80)
		{
			goto IL_01f3;
		}
	}
	{
		V_11 = 0;
		goto IL_01e8;
	}

IL_01c0:
	{
		int32_t L_81 = V_0;
		int32_t L_82 = V_11;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_82, (Il2CppFullySharedGenericStruct*)L_83);
		RuntimeObject* L_84 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_83);
		V_12 = ((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_84, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))));
		int32_t L_85;
		L_85 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&V_12), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_86;
		L_86 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_81, L_85, NULL);
		V_0 = L_86;
		int32_t L_87 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_87, 1));
	}

IL_01e8:
	{
		int32_t L_88 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_89;
		L_89 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_88) < ((int32_t)L_89)))
		{
			goto IL_01c0;
		}
	}
	{
		int32_t L_90 = V_0;
		return L_90;
	}

IL_01f3:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_91 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_92;
		L_92 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_91, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_93 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_94;
		L_94 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_93, NULL);
		bool L_95;
		L_95 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_92, L_94, NULL);
		if (!L_95)
		{
			goto IL_0246;
		}
	}
	{
		V_13 = 0;
		goto IL_023b;
	}

IL_0213:
	{
		int32_t L_96 = V_0;
		int32_t L_97 = V_13;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_97, (Il2CppFullySharedGenericStruct*)L_98);
		RuntimeObject* L_99 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_98);
		V_14 = ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_99, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))));
		int32_t L_100;
		L_100 = UInt64_GetHashCode_m65D9FD0102B6B01BF38D986F060F0BDBC29B4F92((&V_14), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_101;
		L_101 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_96, L_100, NULL);
		V_0 = L_101;
		int32_t L_102 = V_13;
		V_13 = ((int32_t)il2cpp_codegen_add(L_102, 1));
	}

IL_023b:
	{
		int32_t L_103 = V_13;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_104;
		L_104 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_103) < ((int32_t)L_104)))
		{
			goto IL_0213;
		}
	}
	{
		int32_t L_105 = V_0;
		return L_105;
	}

IL_0246:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_106 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_107;
		L_107 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_106, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_108 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_109;
		L_109 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_108, NULL);
		bool L_110;
		L_110 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_107, L_109, NULL);
		if (!L_110)
		{
			goto IL_0299;
		}
	}
	{
		V_15 = 0;
		goto IL_028e;
	}

IL_0266:
	{
		int32_t L_111 = V_0;
		int32_t L_112 = V_15;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_112, (Il2CppFullySharedGenericStruct*)L_113);
		RuntimeObject* L_114 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_113);
		V_16 = ((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_114, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))));
		int32_t L_115;
		L_115 = Int64_GetHashCode_mDB050BE2AC244D92B14D1DF725AAD279CDC48496((&V_16), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_116;
		L_116 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_111, L_115, NULL);
		V_0 = L_116;
		int32_t L_117 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_add(L_117, 1));
	}

IL_028e:
	{
		int32_t L_118 = V_15;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_119;
		L_119 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_118) < ((int32_t)L_119)))
		{
			goto IL_0266;
		}
	}
	{
		int32_t L_120 = V_0;
		return L_120;
	}

IL_0299:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_121 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_122;
		L_122 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_121, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_123 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_124;
		L_124 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_123, NULL);
		bool L_125;
		L_125 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_122, L_124, NULL);
		if (!L_125)
		{
			goto IL_02ec;
		}
	}
	{
		V_17 = 0;
		goto IL_02e1;
	}

IL_02b9:
	{
		int32_t L_126 = V_0;
		int32_t L_127 = V_17;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_127, (Il2CppFullySharedGenericStruct*)L_128);
		RuntimeObject* L_129 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_128);
		V_18 = ((*(float*)((float*)(float*)UnBox(L_129, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))));
		int32_t L_130;
		L_130 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2((&V_18), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_131;
		L_131 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_126, L_130, NULL);
		V_0 = L_131;
		int32_t L_132 = V_17;
		V_17 = ((int32_t)il2cpp_codegen_add(L_132, 1));
	}

IL_02e1:
	{
		int32_t L_133 = V_17;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_134;
		L_134 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_133) < ((int32_t)L_134)))
		{
			goto IL_02b9;
		}
	}
	{
		int32_t L_135 = V_0;
		return L_135;
	}

IL_02ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_136 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_137;
		L_137 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_136, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_138 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_139;
		L_139 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_138, NULL);
		bool L_140;
		L_140 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_137, L_139, NULL);
		if (!L_140)
		{
			goto IL_033f;
		}
	}
	{
		V_19 = 0;
		goto IL_0334;
	}

IL_030c:
	{
		int32_t L_141 = V_0;
		int32_t L_142 = V_19;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_142, (Il2CppFullySharedGenericStruct*)L_143);
		RuntimeObject* L_144 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_143);
		V_20 = ((*(double*)((double*)(double*)UnBox(L_144, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))));
		int32_t L_145;
		L_145 = Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline((&V_20), NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_146;
		L_146 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_141, L_145, NULL);
		V_0 = L_146;
		int32_t L_147 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_147, 1));
	}

IL_0334:
	{
		int32_t L_148 = V_19;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_149;
		L_149 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_148) < ((int32_t)L_149)))
		{
			goto IL_030c;
		}
	}
	{
		int32_t L_150 = V_0;
		return L_150;
	}

IL_033f:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_151 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_151);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_151, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_151, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF_RuntimeMethod_var)));
	}

IL_034a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_152 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_153;
		L_153 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_152, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_154 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_155;
		L_155 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_154, NULL);
		bool L_156;
		L_156 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_153, L_155, NULL);
		if (!L_156)
		{
			goto IL_04da;
		}
	}
	{
		int32_t L_157 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_158 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_159 = (uint8_t*)(&L_158->___byte_0_0);
		int32_t L_160;
		L_160 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_159, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_161;
		L_161 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_157, L_160, NULL);
		V_0 = L_161;
		int32_t L_162 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_163 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_164 = (uint8_t*)(&L_163->___byte_1_1);
		int32_t L_165;
		L_165 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_164, NULL);
		int32_t L_166;
		L_166 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_162, L_165, NULL);
		V_0 = L_166;
		int32_t L_167 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_168 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_169 = (uint8_t*)(&L_168->___byte_2_2);
		int32_t L_170;
		L_170 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_169, NULL);
		int32_t L_171;
		L_171 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_167, L_170, NULL);
		V_0 = L_171;
		int32_t L_172 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_173 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_174 = (uint8_t*)(&L_173->___byte_3_3);
		int32_t L_175;
		L_175 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_174, NULL);
		int32_t L_176;
		L_176 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_172, L_175, NULL);
		V_0 = L_176;
		int32_t L_177 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_178 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_179 = (uint8_t*)(&L_178->___byte_4_4);
		int32_t L_180;
		L_180 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_179, NULL);
		int32_t L_181;
		L_181 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_177, L_180, NULL);
		V_0 = L_181;
		int32_t L_182 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_183 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_184 = (uint8_t*)(&L_183->___byte_5_5);
		int32_t L_185;
		L_185 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_184, NULL);
		int32_t L_186;
		L_186 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_182, L_185, NULL);
		V_0 = L_186;
		int32_t L_187 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_188 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_189 = (uint8_t*)(&L_188->___byte_6_6);
		int32_t L_190;
		L_190 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_189, NULL);
		int32_t L_191;
		L_191 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_187, L_190, NULL);
		V_0 = L_191;
		int32_t L_192 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_193 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_194 = (uint8_t*)(&L_193->___byte_7_7);
		int32_t L_195;
		L_195 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_194, NULL);
		int32_t L_196;
		L_196 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_192, L_195, NULL);
		V_0 = L_196;
		int32_t L_197 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_198 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_199 = (uint8_t*)(&L_198->___byte_8_8);
		int32_t L_200;
		L_200 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_199, NULL);
		int32_t L_201;
		L_201 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_197, L_200, NULL);
		V_0 = L_201;
		int32_t L_202 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_203 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_204 = (uint8_t*)(&L_203->___byte_9_9);
		int32_t L_205;
		L_205 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_204, NULL);
		int32_t L_206;
		L_206 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_202, L_205, NULL);
		V_0 = L_206;
		int32_t L_207 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_208 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_209 = (uint8_t*)(&L_208->___byte_10_10);
		int32_t L_210;
		L_210 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_209, NULL);
		int32_t L_211;
		L_211 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_207, L_210, NULL);
		V_0 = L_211;
		int32_t L_212 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_213 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_214 = (uint8_t*)(&L_213->___byte_11_11);
		int32_t L_215;
		L_215 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_214, NULL);
		int32_t L_216;
		L_216 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_212, L_215, NULL);
		V_0 = L_216;
		int32_t L_217 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_218 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_219 = (uint8_t*)(&L_218->___byte_12_12);
		int32_t L_220;
		L_220 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_219, NULL);
		int32_t L_221;
		L_221 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_217, L_220, NULL);
		V_0 = L_221;
		int32_t L_222 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_223 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_224 = (uint8_t*)(&L_223->___byte_13_13);
		int32_t L_225;
		L_225 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_224, NULL);
		int32_t L_226;
		L_226 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_222, L_225, NULL);
		V_0 = L_226;
		int32_t L_227 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_228 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_229 = (uint8_t*)(&L_228->___byte_14_14);
		int32_t L_230;
		L_230 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_229, NULL);
		int32_t L_231;
		L_231 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_227, L_230, NULL);
		V_0 = L_231;
		int32_t L_232 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_233 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint8_t* L_234 = (uint8_t*)(&L_233->___byte_15_15);
		int32_t L_235;
		L_235 = Byte_GetHashCode_mB42A844E310593D124CE92EBA90F3755C9B10678(L_234, NULL);
		int32_t L_236;
		L_236 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_232, L_235, NULL);
		V_0 = L_236;
		int32_t L_237 = V_0;
		return L_237;
	}

IL_04da:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_238 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_239;
		L_239 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_238, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_240 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_241;
		L_241 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_240, NULL);
		bool L_242;
		L_242 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_239, L_241, NULL);
		if (!L_242)
		{
			goto IL_066a;
		}
	}
	{
		int32_t L_243 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_244 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_245 = (int8_t*)(&L_244->___sbyte_0_16);
		int32_t L_246;
		L_246 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_245, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_247;
		L_247 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_243, L_246, NULL);
		V_0 = L_247;
		int32_t L_248 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_249 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_250 = (int8_t*)(&L_249->___sbyte_1_17);
		int32_t L_251;
		L_251 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_250, NULL);
		int32_t L_252;
		L_252 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_248, L_251, NULL);
		V_0 = L_252;
		int32_t L_253 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_254 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_255 = (int8_t*)(&L_254->___sbyte_2_18);
		int32_t L_256;
		L_256 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_255, NULL);
		int32_t L_257;
		L_257 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_253, L_256, NULL);
		V_0 = L_257;
		int32_t L_258 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_259 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_260 = (int8_t*)(&L_259->___sbyte_3_19);
		int32_t L_261;
		L_261 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_260, NULL);
		int32_t L_262;
		L_262 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_258, L_261, NULL);
		V_0 = L_262;
		int32_t L_263 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_264 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_265 = (int8_t*)(&L_264->___sbyte_4_20);
		int32_t L_266;
		L_266 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_265, NULL);
		int32_t L_267;
		L_267 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_263, L_266, NULL);
		V_0 = L_267;
		int32_t L_268 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_269 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_270 = (int8_t*)(&L_269->___sbyte_5_21);
		int32_t L_271;
		L_271 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_270, NULL);
		int32_t L_272;
		L_272 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_268, L_271, NULL);
		V_0 = L_272;
		int32_t L_273 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_274 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_275 = (int8_t*)(&L_274->___sbyte_6_22);
		int32_t L_276;
		L_276 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_275, NULL);
		int32_t L_277;
		L_277 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_273, L_276, NULL);
		V_0 = L_277;
		int32_t L_278 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_279 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_280 = (int8_t*)(&L_279->___sbyte_7_23);
		int32_t L_281;
		L_281 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_280, NULL);
		int32_t L_282;
		L_282 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_278, L_281, NULL);
		V_0 = L_282;
		int32_t L_283 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_284 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_285 = (int8_t*)(&L_284->___sbyte_8_24);
		int32_t L_286;
		L_286 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_285, NULL);
		int32_t L_287;
		L_287 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_283, L_286, NULL);
		V_0 = L_287;
		int32_t L_288 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_289 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_290 = (int8_t*)(&L_289->___sbyte_9_25);
		int32_t L_291;
		L_291 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_290, NULL);
		int32_t L_292;
		L_292 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_288, L_291, NULL);
		V_0 = L_292;
		int32_t L_293 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_294 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_295 = (int8_t*)(&L_294->___sbyte_10_26);
		int32_t L_296;
		L_296 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_295, NULL);
		int32_t L_297;
		L_297 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_293, L_296, NULL);
		V_0 = L_297;
		int32_t L_298 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_299 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_300 = (int8_t*)(&L_299->___sbyte_11_27);
		int32_t L_301;
		L_301 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_300, NULL);
		int32_t L_302;
		L_302 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_298, L_301, NULL);
		V_0 = L_302;
		int32_t L_303 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_304 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_305 = (int8_t*)(&L_304->___sbyte_12_28);
		int32_t L_306;
		L_306 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_305, NULL);
		int32_t L_307;
		L_307 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_303, L_306, NULL);
		V_0 = L_307;
		int32_t L_308 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_309 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_310 = (int8_t*)(&L_309->___sbyte_13_29);
		int32_t L_311;
		L_311 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_310, NULL);
		int32_t L_312;
		L_312 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_308, L_311, NULL);
		V_0 = L_312;
		int32_t L_313 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_314 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_315 = (int8_t*)(&L_314->___sbyte_14_30);
		int32_t L_316;
		L_316 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_315, NULL);
		int32_t L_317;
		L_317 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_313, L_316, NULL);
		V_0 = L_317;
		int32_t L_318 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_319 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int8_t* L_320 = (int8_t*)(&L_319->___sbyte_15_31);
		int32_t L_321;
		L_321 = SByte_GetHashCode_mE61E9B0D1D93EF3E4E2B6282FF940FFA2E471FFF(L_320, NULL);
		int32_t L_322;
		L_322 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_318, L_321, NULL);
		V_0 = L_322;
		int32_t L_323 = V_0;
		return L_323;
	}

IL_066a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_324 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_325;
		L_325 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_324, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_326 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_327;
		L_327 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_326, NULL);
		bool L_328;
		L_328 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_325, L_327, NULL);
		if (!L_328)
		{
			goto IL_0742;
		}
	}
	{
		int32_t L_329 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_330 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_331 = (uint16_t*)(&L_330->___uint16_0_32);
		int32_t L_332;
		L_332 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_331, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_333;
		L_333 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_329, L_332, NULL);
		V_0 = L_333;
		int32_t L_334 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_335 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_336 = (uint16_t*)(&L_335->___uint16_1_33);
		int32_t L_337;
		L_337 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_336, NULL);
		int32_t L_338;
		L_338 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_334, L_337, NULL);
		V_0 = L_338;
		int32_t L_339 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_340 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_341 = (uint16_t*)(&L_340->___uint16_2_34);
		int32_t L_342;
		L_342 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_341, NULL);
		int32_t L_343;
		L_343 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_339, L_342, NULL);
		V_0 = L_343;
		int32_t L_344 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_345 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_346 = (uint16_t*)(&L_345->___uint16_3_35);
		int32_t L_347;
		L_347 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_346, NULL);
		int32_t L_348;
		L_348 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_344, L_347, NULL);
		V_0 = L_348;
		int32_t L_349 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_350 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_351 = (uint16_t*)(&L_350->___uint16_4_36);
		int32_t L_352;
		L_352 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_351, NULL);
		int32_t L_353;
		L_353 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_349, L_352, NULL);
		V_0 = L_353;
		int32_t L_354 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_355 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_356 = (uint16_t*)(&L_355->___uint16_5_37);
		int32_t L_357;
		L_357 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_356, NULL);
		int32_t L_358;
		L_358 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_354, L_357, NULL);
		V_0 = L_358;
		int32_t L_359 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_360 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_361 = (uint16_t*)(&L_360->___uint16_6_38);
		int32_t L_362;
		L_362 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_361, NULL);
		int32_t L_363;
		L_363 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_359, L_362, NULL);
		V_0 = L_363;
		int32_t L_364 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_365 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint16_t* L_366 = (uint16_t*)(&L_365->___uint16_7_39);
		int32_t L_367;
		L_367 = UInt16_GetHashCode_m534E5103D0DA9C6FCED4F2F007993D3E38165200(L_366, NULL);
		int32_t L_368;
		L_368 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_364, L_367, NULL);
		V_0 = L_368;
		int32_t L_369 = V_0;
		return L_369;
	}

IL_0742:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_370 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_371;
		L_371 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_370, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_372 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_373;
		L_373 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_372, NULL);
		bool L_374;
		L_374 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_371, L_373, NULL);
		if (!L_374)
		{
			goto IL_081a;
		}
	}
	{
		int32_t L_375 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_376 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_377 = (int16_t*)(&L_376->___int16_0_40);
		int32_t L_378;
		L_378 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_377, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_379;
		L_379 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_375, L_378, NULL);
		V_0 = L_379;
		int32_t L_380 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_381 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_382 = (int16_t*)(&L_381->___int16_1_41);
		int32_t L_383;
		L_383 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_382, NULL);
		int32_t L_384;
		L_384 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_380, L_383, NULL);
		V_0 = L_384;
		int32_t L_385 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_386 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_387 = (int16_t*)(&L_386->___int16_2_42);
		int32_t L_388;
		L_388 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_387, NULL);
		int32_t L_389;
		L_389 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_385, L_388, NULL);
		V_0 = L_389;
		int32_t L_390 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_391 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_392 = (int16_t*)(&L_391->___int16_3_43);
		int32_t L_393;
		L_393 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_392, NULL);
		int32_t L_394;
		L_394 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_390, L_393, NULL);
		V_0 = L_394;
		int32_t L_395 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_396 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_397 = (int16_t*)(&L_396->___int16_4_44);
		int32_t L_398;
		L_398 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_397, NULL);
		int32_t L_399;
		L_399 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_395, L_398, NULL);
		V_0 = L_399;
		int32_t L_400 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_401 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_402 = (int16_t*)(&L_401->___int16_5_45);
		int32_t L_403;
		L_403 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_402, NULL);
		int32_t L_404;
		L_404 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_400, L_403, NULL);
		V_0 = L_404;
		int32_t L_405 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_406 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_407 = (int16_t*)(&L_406->___int16_6_46);
		int32_t L_408;
		L_408 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_407, NULL);
		int32_t L_409;
		L_409 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_405, L_408, NULL);
		V_0 = L_409;
		int32_t L_410 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_411 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int16_t* L_412 = (int16_t*)(&L_411->___int16_7_47);
		int32_t L_413;
		L_413 = Int16_GetHashCode_mCD0A167AC8E6ACC2235F12E00C0F9BDC6ED3B6E1(L_412, NULL);
		int32_t L_414;
		L_414 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_410, L_413, NULL);
		V_0 = L_414;
		int32_t L_415 = V_0;
		return L_415;
	}

IL_081a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_416 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_417;
		L_417 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_416, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_418 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_419;
		L_419 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_418, NULL);
		bool L_420;
		L_420 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_417, L_419, NULL);
		if (!L_420)
		{
			goto IL_0893;
		}
	}
	{
		int32_t L_421 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_422 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_423 = (uint32_t*)(&L_422->___uint32_0_48);
		int32_t L_424;
		L_424 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_423, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_425;
		L_425 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_421, L_424, NULL);
		V_0 = L_425;
		int32_t L_426 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_427 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_428 = (uint32_t*)(&L_427->___uint32_1_49);
		int32_t L_429;
		L_429 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_428, NULL);
		int32_t L_430;
		L_430 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_426, L_429, NULL);
		V_0 = L_430;
		int32_t L_431 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_432 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_433 = (uint32_t*)(&L_432->___uint32_2_50);
		int32_t L_434;
		L_434 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_433, NULL);
		int32_t L_435;
		L_435 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_431, L_434, NULL);
		V_0 = L_435;
		int32_t L_436 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_437 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint32_t* L_438 = (uint32_t*)(&L_437->___uint32_3_51);
		int32_t L_439;
		L_439 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_438, NULL);
		int32_t L_440;
		L_440 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_436, L_439, NULL);
		V_0 = L_440;
		int32_t L_441 = V_0;
		return L_441;
	}

IL_0893:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_442 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_443;
		L_443 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_442, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_444 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_445;
		L_445 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_444, NULL);
		bool L_446;
		L_446 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_443, L_445, NULL);
		if (!L_446)
		{
			goto IL_090c;
		}
	}
	{
		int32_t L_447 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_448 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_449 = (int32_t*)(&L_448->___int32_0_52);
		int32_t L_450;
		L_450 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_449, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_451;
		L_451 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_447, L_450, NULL);
		V_0 = L_451;
		int32_t L_452 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_453 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_454 = (int32_t*)(&L_453->___int32_1_53);
		int32_t L_455;
		L_455 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_454, NULL);
		int32_t L_456;
		L_456 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_452, L_455, NULL);
		V_0 = L_456;
		int32_t L_457 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_458 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_459 = (int32_t*)(&L_458->___int32_2_54);
		int32_t L_460;
		L_460 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_459, NULL);
		int32_t L_461;
		L_461 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_457, L_460, NULL);
		V_0 = L_461;
		int32_t L_462 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_463 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int32_t* L_464 = (int32_t*)(&L_463->___int32_3_55);
		int32_t L_465;
		L_465 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_464, NULL);
		int32_t L_466;
		L_466 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_462, L_465, NULL);
		V_0 = L_466;
		int32_t L_467 = V_0;
		return L_467;
	}

IL_090c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_468 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_469;
		L_469 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_468, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_470 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_471;
		L_471 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_470, NULL);
		bool L_472;
		L_472 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_469, L_471, NULL);
		if (!L_472)
		{
			goto IL_0957;
		}
	}
	{
		int32_t L_473 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_474 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_475 = (uint64_t*)(&L_474->___uint64_0_56);
		int32_t L_476;
		L_476 = UInt64_GetHashCode_m65D9FD0102B6B01BF38D986F060F0BDBC29B4F92(L_475, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_477;
		L_477 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_473, L_476, NULL);
		V_0 = L_477;
		int32_t L_478 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_479 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		uint64_t* L_480 = (uint64_t*)(&L_479->___uint64_1_57);
		int32_t L_481;
		L_481 = UInt64_GetHashCode_m65D9FD0102B6B01BF38D986F060F0BDBC29B4F92(L_480, NULL);
		int32_t L_482;
		L_482 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_478, L_481, NULL);
		V_0 = L_482;
		int32_t L_483 = V_0;
		return L_483;
	}

IL_0957:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_484 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_485;
		L_485 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_484, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_486 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_487;
		L_487 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_486, NULL);
		bool L_488;
		L_488 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_485, L_487, NULL);
		if (!L_488)
		{
			goto IL_09a2;
		}
	}
	{
		int32_t L_489 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_490 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_491 = (int64_t*)(&L_490->___int64_0_58);
		int32_t L_492;
		L_492 = Int64_GetHashCode_mDB050BE2AC244D92B14D1DF725AAD279CDC48496(L_491, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_493;
		L_493 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_489, L_492, NULL);
		V_0 = L_493;
		int32_t L_494 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_495 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		int64_t* L_496 = (int64_t*)(&L_495->___int64_1_59);
		int32_t L_497;
		L_497 = Int64_GetHashCode_mDB050BE2AC244D92B14D1DF725AAD279CDC48496(L_496, NULL);
		int32_t L_498;
		L_498 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_494, L_497, NULL);
		V_0 = L_498;
		int32_t L_499 = V_0;
		return L_499;
	}

IL_09a2:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_500 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_501;
		L_501 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_500, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_502 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_503;
		L_503 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_502, NULL);
		bool L_504;
		L_504 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_501, L_503, NULL);
		if (!L_504)
		{
			goto IL_0a1b;
		}
	}
	{
		int32_t L_505 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_506 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_507 = (float*)(&L_506->___single_0_60);
		int32_t L_508;
		L_508 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_507, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_509;
		L_509 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_505, L_508, NULL);
		V_0 = L_509;
		int32_t L_510 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_511 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_512 = (float*)(&L_511->___single_1_61);
		int32_t L_513;
		L_513 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_512, NULL);
		int32_t L_514;
		L_514 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_510, L_513, NULL);
		V_0 = L_514;
		int32_t L_515 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_516 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_517 = (float*)(&L_516->___single_2_62);
		int32_t L_518;
		L_518 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_517, NULL);
		int32_t L_519;
		L_519 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_515, L_518, NULL);
		V_0 = L_519;
		int32_t L_520 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_521 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		float* L_522 = (float*)(&L_521->___single_3_63);
		int32_t L_523;
		L_523 = Single_GetHashCode_mC3F1E099D1CF165C2D71FBCC5EF6A6792F9021D2(L_522, NULL);
		int32_t L_524;
		L_524 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_520, L_523, NULL);
		V_0 = L_524;
		int32_t L_525 = V_0;
		return L_525;
	}

IL_0a1b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_526 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_527;
		L_527 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_526, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_528 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_529;
		L_529 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_528, NULL);
		bool L_530;
		L_530 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_527, L_529, NULL);
		if (!L_530)
		{
			goto IL_0a66;
		}
	}
	{
		int32_t L_531 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_532 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_533 = (double*)(&L_532->___double_0_64);
		int32_t L_534;
		L_534 = Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline(L_533, NULL);
		il2cpp_codegen_runtime_class_init_inline(HashHelpers_t285C6E63B4A4E8D837BDBC63DE4E2D23C85467D4_il2cpp_TypeInfo_var);
		int32_t L_535;
		L_535 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_531, L_534, NULL);
		V_0 = L_535;
		int32_t L_536 = V_0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_537 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&__this->___register_0);
		double* L_538 = (double*)(&L_537->___double_1_65);
		int32_t L_539;
		L_539 = Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline(L_538, NULL);
		int32_t L_540;
		L_540 = HashHelpers_Combine_m556169DF218720DCB13E0712A886E9029C838344(L_536, L_539, NULL);
		V_0 = L_540;
		int32_t L_541 = V_0;
		return L_541;
	}

IL_0a66:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_542 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_542);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_542, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_542, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C  int32_t Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = Vector_1_GetHashCode_m3ACEDE87318824BACAD7E8CB760798D98D37C4FF(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_m212191DE0383E512D8297CE138DB5C06BF1E6F4A_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral3DCC6243286938BE75C3FA773B9BA71160A2E869);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* L_0;
		L_0 = CultureInfo_get_CurrentCulture_m43D1E4E50AB1F62ADC7C1884F28F918B53871522(NULL);
		String_t* L_1;
		L_1 = ((  String_t* (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, String_t*, RuntimeObject*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10)))(__this, _stringLiteral3DCC6243286938BE75C3FA773B9BA71160A2E869, (RuntimeObject*)L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		return L_1;
	}
}
IL2CPP_EXTERN_C  String_t* Vector_1_ToString_m212191DE0383E512D8297CE138DB5C06BF1E6F4A_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	String_t* _returnValue;
	_returnValue = Vector_1_ToString_m212191DE0383E512D8297CE138DB5C06BF1E6F4A(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Vector_1_ToString_mB21C58D9FD6C9A89DF0D786C50F960E551B1FB8F_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringBuilder_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	const Il2CppFullySharedGenericStruct L_8 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_24 = L_8;
	StringBuilder_t* V_0 = NULL;
	String_t* V_1 = NULL;
	int32_t V_2 = 0;
	{
		StringBuilder_t* L_0 = (StringBuilder_t*)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		StringBuilder__ctor_m1D99713357DE05DAFA296633639DB55F8C30587D(L_0, NULL);
		V_0 = L_0;
		RuntimeObject* L_1 = ___formatProvider1;
		NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* L_2;
		L_2 = NumberFormatInfo_GetInstance_m68D84692285114DC53C752EFC2A559319D117E71(L_1, NULL);
		NullCheck(L_2);
		String_t* L_3;
		L_3 = NumberFormatInfo_get_NumberGroupSeparator_m0556B092AA471513B1EDC31C047712226D39BEB6_inline(L_2, NULL);
		V_1 = L_3;
		StringBuilder_t* L_4 = V_0;
		NullCheck(L_4);
		StringBuilder_t* L_5;
		L_5 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_4, (Il2CppChar)((int32_t)60), NULL);
		V_2 = 0;
		goto IL_0053;
	}

IL_001f:
	{
		StringBuilder_t* L_6 = V_0;
		int32_t L_7 = V_2;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, L_7, (Il2CppFullySharedGenericStruct*)L_8);
		RuntimeObject* L_9 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_8);
		String_t* L_10 = ___format0;
		RuntimeObject* L_11 = ___formatProvider1;
		NullCheck(((RuntimeObject*)Castclass((RuntimeObject*)L_9, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var)));
		String_t* L_12;
		L_12 = InterfaceFuncInvoker2< String_t*, String_t*, RuntimeObject* >::Invoke(0, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var, ((RuntimeObject*)Castclass((RuntimeObject*)L_9, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var)), L_10, L_11);
		NullCheck(L_6);
		StringBuilder_t* L_13;
		L_13 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_6, L_12, NULL);
		StringBuilder_t* L_14 = V_0;
		String_t* L_15 = V_1;
		NullCheck(L_14);
		StringBuilder_t* L_16;
		L_16 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_14, L_15, NULL);
		StringBuilder_t* L_17 = V_0;
		NullCheck(L_17);
		StringBuilder_t* L_18;
		L_18 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_17, (Il2CppChar)((int32_t)32), NULL);
		int32_t L_19 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_19, 1));
	}

IL_0053:
	{
		int32_t L_20 = V_2;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_21;
		L_21 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_20) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_21, 1)))))
		{
			goto IL_001f;
		}
	}
	{
		StringBuilder_t* L_22 = V_0;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_23;
		L_23 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), __this, ((int32_t)il2cpp_codegen_subtract(L_23, 1)), (Il2CppFullySharedGenericStruct*)L_24);
		RuntimeObject* L_25 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_24);
		String_t* L_26 = ___format0;
		RuntimeObject* L_27 = ___formatProvider1;
		NullCheck(((RuntimeObject*)Castclass((RuntimeObject*)L_25, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var)));
		String_t* L_28;
		L_28 = InterfaceFuncInvoker2< String_t*, String_t*, RuntimeObject* >::Invoke(0, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var, ((RuntimeObject*)Castclass((RuntimeObject*)L_25, IFormattable_t235A539BD9771E1E118DB99384BA8385D2F971CA_il2cpp_TypeInfo_var)), L_26, L_27);
		NullCheck(L_22);
		StringBuilder_t* L_29;
		L_29 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_22, L_28, NULL);
		StringBuilder_t* L_30 = V_0;
		NullCheck(L_30);
		StringBuilder_t* L_31;
		L_31 = StringBuilder_Append_m71228B30F05724CD2CD96D9611DCD61BFB96A6E1(L_30, (Il2CppChar)((int32_t)62), NULL);
		StringBuilder_t* L_32 = V_0;
		NullCheck((RuntimeObject*)L_32);
		String_t* L_33;
		L_33 = VirtualFuncInvoker0< String_t* >::Invoke(3, (RuntimeObject*)L_32);
		return L_33;
	}
}
IL2CPP_EXTERN_C  String_t* Vector_1_ToString_mB21C58D9FD6C9A89DF0D786C50F960E551B1FB8F_AdjustorThunk (RuntimeObject* __this, String_t* ___format0, RuntimeObject* ___formatProvider1, const RuntimeMethod* method)
{
	Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*>(__this + _offset);
	String_t* _returnValue;
	_returnValue = Vector_1_ToString_mB21C58D9FD6C9A89DF0D786C50F960E551B1FB8F(_thisAdjusted, ___format0, ___formatProvider1, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_op_Equality_m3E0BDCC9D309333131687C57CEE95AD12E693237_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___left0, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___right1, const RuntimeMethod* method) 
{
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_0 = ___right1;
		bool L_1;
		L_1 = ((  bool (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7)))((&___left0), L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7));
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_op_Inequality_m7EC5A53F602B5DB33BF4481B00A8446D2DD82929_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___left0, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___right1, const RuntimeMethod* method) 
{
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_0 = ___left0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_1 = ___right1;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_2;
		L_2 = ((  bool (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11)))(L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		return (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A Vector_1_op_Explicit_mE3B96040F0AA7DA45CAE43E7B77F0FDD98CD8017_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* L_0 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A*)(&(&___value0)->___register_0);
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_1;
		memset((&L_1), 0, sizeof(L_1));
		Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606((&L_1), L_0, Vector_1__ctor_mEA86543744A54FCE590FDBF012FAE9037A5F1606_RuntimeMethod_var);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_gshared (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___left0, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 ___right1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	const Il2CppFullySharedGenericStruct L_11 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_31 = L_11;
	const Il2CppFullySharedGenericStruct L_51 = L_11;
	const Il2CppFullySharedGenericStruct L_71 = L_11;
	const Il2CppFullySharedGenericStruct L_91 = L_11;
	const Il2CppFullySharedGenericStruct L_111 = L_11;
	const Il2CppFullySharedGenericStruct L_131 = L_11;
	const Il2CppFullySharedGenericStruct L_151 = L_11;
	const Il2CppFullySharedGenericStruct L_171 = L_11;
	const Il2CppFullySharedGenericStruct L_191 = L_11;
	const Il2CppFullySharedGenericStruct L_13 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_33 = L_13;
	const Il2CppFullySharedGenericStruct L_53 = L_13;
	const Il2CppFullySharedGenericStruct L_73 = L_13;
	const Il2CppFullySharedGenericStruct L_93 = L_13;
	const Il2CppFullySharedGenericStruct L_113 = L_13;
	const Il2CppFullySharedGenericStruct L_133 = L_13;
	const Il2CppFullySharedGenericStruct L_153 = L_13;
	const Il2CppFullySharedGenericStruct L_173 = L_13;
	const Il2CppFullySharedGenericStruct L_193 = L_13;
	uint8_t* V_0 = NULL;
	int32_t V_1 = 0;
	int8_t* V_2 = NULL;
	int32_t V_3 = 0;
	uint16_t* V_4 = NULL;
	int32_t V_5 = 0;
	int16_t* V_6 = NULL;
	int32_t V_7 = 0;
	uint32_t* V_8 = NULL;
	int32_t V_9 = 0;
	int32_t* V_10 = NULL;
	int32_t V_11 = 0;
	uint64_t* V_12 = NULL;
	int32_t V_13 = 0;
	int64_t* V_14 = NULL;
	int32_t V_15 = 0;
	float* V_16 = NULL;
	int32_t V_17 = 0;
	double* V_18 = NULL;
	int32_t V_19 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A V_20;
	memset((&V_20), 0, sizeof(V_20));
	uint8_t* G_B5_0 = NULL;
	uint8_t* G_B4_0 = NULL;
	int32_t G_B6_0 = 0;
	uint8_t* G_B6_1 = NULL;
	int8_t* G_B13_0 = NULL;
	int8_t* G_B12_0 = NULL;
	int32_t G_B14_0 = 0;
	int8_t* G_B14_1 = NULL;
	uint16_t* G_B21_0 = NULL;
	uint16_t* G_B20_0 = NULL;
	int32_t G_B22_0 = 0;
	uint16_t* G_B22_1 = NULL;
	int16_t* G_B29_0 = NULL;
	int16_t* G_B28_0 = NULL;
	int32_t G_B30_0 = 0;
	int16_t* G_B30_1 = NULL;
	uint32_t* G_B37_0 = NULL;
	uint32_t* G_B36_0 = NULL;
	uint32_t G_B38_0 = 0;
	uint32_t* G_B38_1 = NULL;
	int32_t* G_B45_0 = NULL;
	int32_t* G_B44_0 = NULL;
	int32_t G_B46_0 = 0;
	int32_t* G_B46_1 = NULL;
	uint64_t* G_B53_0 = NULL;
	uint64_t* G_B52_0 = NULL;
	uint64_t G_B54_0 = 0;
	uint64_t* G_B54_1 = NULL;
	int64_t* G_B61_0 = NULL;
	int64_t* G_B60_0 = NULL;
	int64_t G_B62_0 = 0;
	int64_t* G_B62_1 = NULL;
	float* G_B69_0 = NULL;
	float* G_B68_0 = NULL;
	float G_B70_0 = 0.0f;
	float* G_B70_1 = NULL;
	double* G_B77_0 = NULL;
	double* G_B76_0 = NULL;
	double G_B78_0 = 0.0;
	double* G_B78_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B85_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B84_0 = NULL;
	int32_t G_B86_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B86_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B88_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B87_0 = NULL;
	int32_t G_B89_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B89_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B91_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B90_0 = NULL;
	int32_t G_B92_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B92_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B94_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B93_0 = NULL;
	int32_t G_B95_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B95_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B97_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B96_0 = NULL;
	int32_t G_B98_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B98_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B100_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B99_0 = NULL;
	int32_t G_B101_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B101_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B103_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B102_0 = NULL;
	int32_t G_B104_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B104_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B106_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B105_0 = NULL;
	int32_t G_B107_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B107_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B109_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B108_0 = NULL;
	int32_t G_B110_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B110_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B112_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B111_0 = NULL;
	int32_t G_B113_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B113_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B115_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B114_0 = NULL;
	int32_t G_B116_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B116_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B118_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B117_0 = NULL;
	int32_t G_B119_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B119_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B121_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B120_0 = NULL;
	int32_t G_B122_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B122_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B124_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B123_0 = NULL;
	int32_t G_B125_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B125_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B127_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B126_0 = NULL;
	int32_t G_B128_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B128_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B130_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B129_0 = NULL;
	int32_t G_B131_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B131_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B135_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B134_0 = NULL;
	int32_t G_B136_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B136_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B138_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B137_0 = NULL;
	int32_t G_B139_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B139_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B141_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B140_0 = NULL;
	int32_t G_B142_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B142_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B144_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B143_0 = NULL;
	int32_t G_B145_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B145_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B147_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B146_0 = NULL;
	int32_t G_B148_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B148_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B150_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B149_0 = NULL;
	int32_t G_B151_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B151_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B153_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B152_0 = NULL;
	int32_t G_B154_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B154_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B156_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B155_0 = NULL;
	int32_t G_B157_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B157_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B159_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B158_0 = NULL;
	int32_t G_B160_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B160_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B162_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B161_0 = NULL;
	int32_t G_B163_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B163_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B165_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B164_0 = NULL;
	int32_t G_B166_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B166_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B168_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B167_0 = NULL;
	int32_t G_B169_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B169_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B171_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B170_0 = NULL;
	int32_t G_B172_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B172_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B174_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B173_0 = NULL;
	int32_t G_B175_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B175_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B177_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B176_0 = NULL;
	int32_t G_B178_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B178_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B180_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B179_0 = NULL;
	int32_t G_B181_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B181_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B185_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B184_0 = NULL;
	int32_t G_B186_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B186_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B188_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B187_0 = NULL;
	int32_t G_B189_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B189_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B191_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B190_0 = NULL;
	int32_t G_B192_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B192_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B194_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B193_0 = NULL;
	int32_t G_B195_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B195_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B197_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B196_0 = NULL;
	int32_t G_B198_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B198_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B200_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B199_0 = NULL;
	int32_t G_B201_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B201_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B203_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B202_0 = NULL;
	int32_t G_B204_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B204_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B206_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B205_0 = NULL;
	int32_t G_B207_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B207_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B211_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B210_0 = NULL;
	int32_t G_B212_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B212_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B214_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B213_0 = NULL;
	int32_t G_B215_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B215_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B217_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B216_0 = NULL;
	int32_t G_B218_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B218_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B220_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B219_0 = NULL;
	int32_t G_B221_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B221_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B223_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B222_0 = NULL;
	int32_t G_B224_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B224_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B226_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B225_0 = NULL;
	int32_t G_B227_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B227_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B229_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B228_0 = NULL;
	int32_t G_B230_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B230_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B232_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B231_0 = NULL;
	int32_t G_B233_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B233_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B237_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B236_0 = NULL;
	uint32_t G_B238_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B238_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B240_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B239_0 = NULL;
	uint32_t G_B241_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B241_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B243_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B242_0 = NULL;
	uint32_t G_B244_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B244_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B246_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B245_0 = NULL;
	uint32_t G_B247_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B247_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B251_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B250_0 = NULL;
	int32_t G_B252_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B252_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B254_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B253_0 = NULL;
	int32_t G_B255_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B255_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B257_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B256_0 = NULL;
	int32_t G_B258_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B258_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B260_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B259_0 = NULL;
	int32_t G_B261_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B261_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B265_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B264_0 = NULL;
	uint64_t G_B266_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B266_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B268_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B267_0 = NULL;
	uint64_t G_B269_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B269_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B273_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B272_0 = NULL;
	int64_t G_B274_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B274_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B276_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B275_0 = NULL;
	int64_t G_B277_0 = 0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B277_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B281_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B280_0 = NULL;
	float G_B282_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B282_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B284_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B283_0 = NULL;
	float G_B285_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B285_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B287_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B286_0 = NULL;
	float G_B288_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B288_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B290_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B289_0 = NULL;
	float G_B291_0 = 0.0f;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B291_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B295_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B294_0 = NULL;
	double G_B296_0 = 0.0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B296_1 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B298_0 = NULL;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B297_0 = NULL;
	double G_B299_0 = 0.0;
	Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A* G_B299_1 = NULL;
	{
		bool L_0;
		L_0 = Vector_get_IsHardwareAccelerated_m4165001054E20A7304F843AE29C33C47D814185D(NULL);
		if (!L_0)
		{
			goto IL_0447;
		}
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_3, NULL);
		bool L_5;
		L_5 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_2, L_4, NULL);
		if (!L_5)
		{
			goto IL_0068;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_6;
		L_6 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		int8_t* L_7 = (int8_t*) alloca(((uintptr_t)L_6));
		memset(L_7, 0, ((uintptr_t)L_6));
		V_0 = (uint8_t*)(L_7);
		V_1 = 0;
		goto IL_0059;
	}

IL_0032:
	{
		uint8_t* L_8 = V_0;
		int32_t L_9 = V_1;
		int32_t L_10 = V_1;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_10, (Il2CppFullySharedGenericStruct*)L_11);
		int32_t L_12 = V_1;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_12, (Il2CppFullySharedGenericStruct*)L_13);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_14;
		L_14 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_11, L_13);
		G_B4_0 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_8, L_9));
		if (L_14)
		{
			G_B5_0 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_8, L_9));
			goto IL_004f;
		}
	}
	{
		G_B6_0 = 0;
		G_B6_1 = G_B4_0;
		goto IL_0054;
	}

IL_004f:
	{
		uint8_t L_15;
		L_15 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B6_0 = ((int32_t)(L_15));
		G_B6_1 = G_B5_0;
	}

IL_0054:
	{
		*((int8_t*)G_B6_1) = (int8_t)G_B6_0;
		int32_t L_16 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_16, 1));
	}

IL_0059:
	{
		int32_t L_17 = V_1;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_18;
		L_18 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_17) < ((int32_t)L_18)))
		{
			goto IL_0032;
		}
	}
	{
		uint8_t* L_19 = V_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_20), (void*)L_19, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_20;
	}

IL_0068:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_21 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_22;
		L_22 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_21, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_23 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_24;
		L_24 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_23, NULL);
		bool L_25;
		L_25 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_22, L_24, NULL);
		if (!L_25)
		{
			goto IL_00c6;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_26;
		L_26 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		int8_t* L_27 = (int8_t*) alloca(((uintptr_t)L_26));
		memset(L_27, 0, ((uintptr_t)L_26));
		V_2 = (L_27);
		V_3 = 0;
		goto IL_00b7;
	}

IL_0090:
	{
		int8_t* L_28 = V_2;
		int32_t L_29 = V_3;
		int32_t L_30 = V_3;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_30, (Il2CppFullySharedGenericStruct*)L_31);
		int32_t L_32 = V_3;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_32, (Il2CppFullySharedGenericStruct*)L_33);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_34;
		L_34 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_31, L_33);
		G_B12_0 = ((int8_t*)il2cpp_codegen_add((intptr_t)L_28, L_29));
		if (L_34)
		{
			G_B13_0 = ((int8_t*)il2cpp_codegen_add((intptr_t)L_28, L_29));
			goto IL_00ad;
		}
	}
	{
		G_B14_0 = 0;
		G_B14_1 = G_B12_0;
		goto IL_00b2;
	}

IL_00ad:
	{
		int8_t L_35;
		L_35 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B14_0 = ((int32_t)(L_35));
		G_B14_1 = G_B13_0;
	}

IL_00b2:
	{
		*((int8_t*)G_B14_1) = (int8_t)G_B14_0;
		int32_t L_36 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_3;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_38;
		L_38 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_37) < ((int32_t)L_38)))
		{
			goto IL_0090;
		}
	}
	{
		int8_t* L_39 = V_2;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_40;
		memset((&L_40), 0, sizeof(L_40));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_40), (void*)L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_40;
	}

IL_00c6:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_41 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_42;
		L_42 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_41, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_43 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_44;
		L_44 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_43, NULL);
		bool L_45;
		L_45 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_42, L_44, NULL);
		if (!L_45)
		{
			goto IL_0133;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_46;
		L_46 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_46) * (uintptr_t)2 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_47 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_46), 2)));
		memset(L_47, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_46), 2)));
		V_4 = (uint16_t*)(L_47);
		V_5 = 0;
		goto IL_0122;
	}

IL_00f2:
	{
		uint16_t* L_48 = V_4;
		int32_t L_49 = V_5;
		int32_t L_50 = V_5;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_50, (Il2CppFullySharedGenericStruct*)L_51);
		int32_t L_52 = V_5;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_52, (Il2CppFullySharedGenericStruct*)L_53);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_54;
		L_54 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_51, L_53);
		G_B20_0 = ((uint16_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 2))));
		if (L_54)
		{
			G_B21_0 = ((uint16_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 2))));
			goto IL_0116;
		}
	}
	{
		G_B22_0 = 0;
		G_B22_1 = G_B20_0;
		goto IL_011b;
	}

IL_0116:
	{
		uint16_t L_55;
		L_55 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B22_0 = ((int32_t)(L_55));
		G_B22_1 = G_B21_0;
	}

IL_011b:
	{
		*((int16_t*)G_B22_1) = (int16_t)G_B22_0;
		int32_t L_56 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_56, 1));
	}

IL_0122:
	{
		int32_t L_57 = V_5;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_58;
		L_58 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_57) < ((int32_t)L_58)))
		{
			goto IL_00f2;
		}
	}
	{
		uint16_t* L_59 = V_4;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_60;
		memset((&L_60), 0, sizeof(L_60));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_60), (void*)L_59, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_60;
	}

IL_0133:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_61 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_62;
		L_62 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_61, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		bool L_65;
		L_65 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_62, L_64, NULL);
		if (!L_65)
		{
			goto IL_01a0;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_66;
		L_66 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_66) * (uintptr_t)2 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_67 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_66), 2)));
		memset(L_67, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_66), 2)));
		V_6 = (int16_t*)(L_67);
		V_7 = 0;
		goto IL_018f;
	}

IL_015f:
	{
		int16_t* L_68 = V_6;
		int32_t L_69 = V_7;
		int32_t L_70 = V_7;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_70, (Il2CppFullySharedGenericStruct*)L_71);
		int32_t L_72 = V_7;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_72, (Il2CppFullySharedGenericStruct*)L_73);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_74;
		L_74 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_71, L_73);
		G_B28_0 = ((int16_t*)il2cpp_codegen_add((intptr_t)L_68, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_69), 2))));
		if (L_74)
		{
			G_B29_0 = ((int16_t*)il2cpp_codegen_add((intptr_t)L_68, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_69), 2))));
			goto IL_0183;
		}
	}
	{
		G_B30_0 = 0;
		G_B30_1 = G_B28_0;
		goto IL_0188;
	}

IL_0183:
	{
		int16_t L_75;
		L_75 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B30_0 = ((int32_t)(L_75));
		G_B30_1 = G_B29_0;
	}

IL_0188:
	{
		*((int16_t*)G_B30_1) = (int16_t)G_B30_0;
		int32_t L_76 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_76, 1));
	}

IL_018f:
	{
		int32_t L_77 = V_7;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_78;
		L_78 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_77) < ((int32_t)L_78)))
		{
			goto IL_015f;
		}
	}
	{
		int16_t* L_79 = V_6;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_80;
		memset((&L_80), 0, sizeof(L_80));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_80), (void*)L_79, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_80;
	}

IL_01a0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_81 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_82;
		L_82 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_81, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_83 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_84;
		L_84 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_83, NULL);
		bool L_85;
		L_85 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_82, L_84, NULL);
		if (!L_85)
		{
			goto IL_020d;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_86;
		L_86 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_86) * (uintptr_t)4 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_87 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_86), 4)));
		memset(L_87, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_86), 4)));
		V_8 = (uint32_t*)(L_87);
		V_9 = 0;
		goto IL_01fc;
	}

IL_01cc:
	{
		uint32_t* L_88 = V_8;
		int32_t L_89 = V_9;
		int32_t L_90 = V_9;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_90, (Il2CppFullySharedGenericStruct*)L_91);
		int32_t L_92 = V_9;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_92, (Il2CppFullySharedGenericStruct*)L_93);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_94;
		L_94 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_91, L_93);
		G_B36_0 = ((uint32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))));
		if (L_94)
		{
			G_B37_0 = ((uint32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))));
			goto IL_01f0;
		}
	}
	{
		G_B38_0 = ((uint32_t)(0));
		G_B38_1 = G_B36_0;
		goto IL_01f5;
	}

IL_01f0:
	{
		uint32_t L_95;
		L_95 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B38_0 = L_95;
		G_B38_1 = G_B37_0;
	}

IL_01f5:
	{
		*((int32_t*)G_B38_1) = (int32_t)G_B38_0;
		int32_t L_96 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_96, 1));
	}

IL_01fc:
	{
		int32_t L_97 = V_9;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_98;
		L_98 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_97) < ((int32_t)L_98)))
		{
			goto IL_01cc;
		}
	}
	{
		uint32_t* L_99 = V_8;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_100;
		memset((&L_100), 0, sizeof(L_100));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_100), (void*)L_99, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_100;
	}

IL_020d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_101 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_102;
		L_102 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_101, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_103 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_104;
		L_104 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_103, NULL);
		bool L_105;
		L_105 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_102, L_104, NULL);
		if (!L_105)
		{
			goto IL_027a;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_106;
		L_106 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_106) * (uintptr_t)4 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_107 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_106), 4)));
		memset(L_107, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_106), 4)));
		V_10 = (int32_t*)(L_107);
		V_11 = 0;
		goto IL_0269;
	}

IL_0239:
	{
		int32_t* L_108 = V_10;
		int32_t L_109 = V_11;
		int32_t L_110 = V_11;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_110, (Il2CppFullySharedGenericStruct*)L_111);
		int32_t L_112 = V_11;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_112, (Il2CppFullySharedGenericStruct*)L_113);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_114;
		L_114 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_111, L_113);
		G_B44_0 = ((int32_t*)il2cpp_codegen_add((intptr_t)L_108, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_109), 4))));
		if (L_114)
		{
			G_B45_0 = ((int32_t*)il2cpp_codegen_add((intptr_t)L_108, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_109), 4))));
			goto IL_025d;
		}
	}
	{
		G_B46_0 = 0;
		G_B46_1 = G_B44_0;
		goto IL_0262;
	}

IL_025d:
	{
		int32_t L_115;
		L_115 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B46_0 = L_115;
		G_B46_1 = G_B45_0;
	}

IL_0262:
	{
		*((int32_t*)G_B46_1) = (int32_t)G_B46_0;
		int32_t L_116 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_116, 1));
	}

IL_0269:
	{
		int32_t L_117 = V_11;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_118;
		L_118 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_117) < ((int32_t)L_118)))
		{
			goto IL_0239;
		}
	}
	{
		int32_t* L_119 = V_10;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_120;
		memset((&L_120), 0, sizeof(L_120));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_120), (void*)L_119, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_120;
	}

IL_027a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_121 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_122;
		L_122 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_121, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_123 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_124;
		L_124 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_123, NULL);
		bool L_125;
		L_125 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_122, L_124, NULL);
		if (!L_125)
		{
			goto IL_02e8;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_126;
		L_126 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_126) * (uintptr_t)8 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_127 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_126), 8)));
		memset(L_127, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_126), 8)));
		V_12 = (uint64_t*)(L_127);
		V_13 = 0;
		goto IL_02d7;
	}

IL_02a6:
	{
		uint64_t* L_128 = V_12;
		int32_t L_129 = V_13;
		int32_t L_130 = V_13;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_130, (Il2CppFullySharedGenericStruct*)L_131);
		int32_t L_132 = V_13;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_132, (Il2CppFullySharedGenericStruct*)L_133);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_134;
		L_134 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_131, L_133);
		G_B52_0 = ((uint64_t*)il2cpp_codegen_add((intptr_t)L_128, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_129), 8))));
		if (L_134)
		{
			G_B53_0 = ((uint64_t*)il2cpp_codegen_add((intptr_t)L_128, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_129), 8))));
			goto IL_02cb;
		}
	}
	{
		G_B54_0 = ((uint64_t)(((int64_t)0)));
		G_B54_1 = G_B52_0;
		goto IL_02d0;
	}

IL_02cb:
	{
		uint64_t L_135;
		L_135 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		G_B54_0 = L_135;
		G_B54_1 = G_B53_0;
	}

IL_02d0:
	{
		*((int64_t*)G_B54_1) = (int64_t)G_B54_0;
		int32_t L_136 = V_13;
		V_13 = ((int32_t)il2cpp_codegen_add(L_136, 1));
	}

IL_02d7:
	{
		int32_t L_137 = V_13;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_138;
		L_138 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_137) < ((int32_t)L_138)))
		{
			goto IL_02a6;
		}
	}
	{
		uint64_t* L_139 = V_12;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_140;
		memset((&L_140), 0, sizeof(L_140));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_140), (void*)L_139, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_140;
	}

IL_02e8:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_141 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_142;
		L_142 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_141, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_143 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_144;
		L_144 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_143, NULL);
		bool L_145;
		L_145 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_142, L_144, NULL);
		if (!L_145)
		{
			goto IL_0356;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_146;
		L_146 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_146) * (uintptr_t)8 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_147 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_146), 8)));
		memset(L_147, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_146), 8)));
		V_14 = (int64_t*)(L_147);
		V_15 = 0;
		goto IL_0345;
	}

IL_0314:
	{
		int64_t* L_148 = V_14;
		int32_t L_149 = V_15;
		int32_t L_150 = V_15;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_150, (Il2CppFullySharedGenericStruct*)L_151);
		int32_t L_152 = V_15;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_152, (Il2CppFullySharedGenericStruct*)L_153);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_154;
		L_154 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_151, L_153);
		G_B60_0 = ((int64_t*)il2cpp_codegen_add((intptr_t)L_148, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_149), 8))));
		if (L_154)
		{
			G_B61_0 = ((int64_t*)il2cpp_codegen_add((intptr_t)L_148, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_149), 8))));
			goto IL_0339;
		}
	}
	{
		G_B62_0 = ((int64_t)0);
		G_B62_1 = G_B60_0;
		goto IL_033e;
	}

IL_0339:
	{
		int64_t L_155;
		L_155 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		G_B62_0 = L_155;
		G_B62_1 = G_B61_0;
	}

IL_033e:
	{
		*((int64_t*)G_B62_1) = (int64_t)G_B62_0;
		int32_t L_156 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_add(L_156, 1));
	}

IL_0345:
	{
		int32_t L_157 = V_15;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_158;
		L_158 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_157) < ((int32_t)L_158)))
		{
			goto IL_0314;
		}
	}
	{
		int64_t* L_159 = V_14;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_160;
		memset((&L_160), 0, sizeof(L_160));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_160), (void*)L_159, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_160;
	}

IL_0356:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_161 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_162;
		L_162 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_161, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_163 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_164;
		L_164 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_163, NULL);
		bool L_165;
		L_165 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_162, L_164, NULL);
		if (!L_165)
		{
			goto IL_03c7;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_166;
		L_166 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_166) * (uintptr_t)4 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_167 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_166), 4)));
		memset(L_167, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_166), 4)));
		V_16 = (float*)(L_167);
		V_17 = 0;
		goto IL_03b6;
	}

IL_0382:
	{
		float* L_168 = V_16;
		int32_t L_169 = V_17;
		int32_t L_170 = V_17;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_170, (Il2CppFullySharedGenericStruct*)L_171);
		int32_t L_172 = V_17;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_172, (Il2CppFullySharedGenericStruct*)L_173);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_174;
		L_174 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_171, L_173);
		G_B68_0 = ((float*)il2cpp_codegen_add((intptr_t)L_168, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_169), 4))));
		if (L_174)
		{
			G_B69_0 = ((float*)il2cpp_codegen_add((intptr_t)L_168, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_169), 4))));
			goto IL_03aa;
		}
	}
	{
		G_B70_0 = (0.0f);
		G_B70_1 = G_B68_0;
		goto IL_03af;
	}

IL_03aa:
	{
		float L_175;
		L_175 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B70_0 = L_175;
		G_B70_1 = G_B69_0;
	}

IL_03af:
	{
		*((float*)G_B70_1) = (float)G_B70_0;
		int32_t L_176 = V_17;
		V_17 = ((int32_t)il2cpp_codegen_add(L_176, 1));
	}

IL_03b6:
	{
		int32_t L_177 = V_17;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_178;
		L_178 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_177) < ((int32_t)L_178)))
		{
			goto IL_0382;
		}
	}
	{
		float* L_179 = V_16;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_180;
		memset((&L_180), 0, sizeof(L_180));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_180), (void*)L_179, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_180;
	}

IL_03c7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_181 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_182;
		L_182 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_181, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_183 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_184;
		L_184 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_183, NULL);
		bool L_185;
		L_185 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_182, L_184, NULL);
		if (!L_185)
		{
			goto IL_043c;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_186;
		L_186 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((uintptr_t)((uintptr_t)L_186) * (uintptr_t)8 > (uintptr_t)kIl2CppUIntPtrMax)
			IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var);
		int8_t* L_187 = (int8_t*) alloca(((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_186), 8)));
		memset(L_187, 0, ((intptr_t)il2cpp_codegen_multiply((intptr_t)((uintptr_t)L_186), 8)));
		V_18 = (double*)(L_187);
		V_19 = 0;
		goto IL_042b;
	}

IL_03f3:
	{
		double* L_188 = V_18;
		int32_t L_189 = V_19;
		int32_t L_190 = V_19;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___left0), L_190, (Il2CppFullySharedGenericStruct*)L_191);
		int32_t L_192 = V_19;
		InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), (&___right1), L_192, (Il2CppFullySharedGenericStruct*)L_193);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		bool L_194;
		L_194 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), NULL, L_191, L_193);
		G_B76_0 = ((double*)il2cpp_codegen_add((intptr_t)L_188, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_189), 8))));
		if (L_194)
		{
			G_B77_0 = ((double*)il2cpp_codegen_add((intptr_t)L_188, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_189), 8))));
			goto IL_041f;
		}
	}
	{
		G_B78_0 = (0.0);
		G_B78_1 = G_B76_0;
		goto IL_0424;
	}

IL_041f:
	{
		double L_195;
		L_195 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		G_B78_0 = L_195;
		G_B78_1 = G_B77_0;
	}

IL_0424:
	{
		*((double*)G_B78_1) = (double)G_B78_0;
		int32_t L_196 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_196, 1));
	}

IL_042b:
	{
		int32_t L_197 = V_19;
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_198;
		L_198 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		if ((((int32_t)L_197) < ((int32_t)L_198)))
		{
			goto IL_03f3;
		}
	}
	{
		double* L_199 = V_18;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_200;
		memset((&L_200), 0, sizeof(L_200));
		Vector_1__ctor_mD3ECCFAE19D970AAEFCC15057E4B90EEA62EB001((&L_200), (void*)L_199, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return L_200;
	}

IL_043c:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_201 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_201);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_201, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_201, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var)));
	}

IL_0447:
	{
		il2cpp_codegen_initobj((&V_20), sizeof(Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A));
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_202 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_203;
		L_203 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_202, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_204 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_205;
		L_205 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_204, NULL);
		bool L_206;
		L_206 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_203, L_205, NULL);
		if (!L_206)
		{
			goto IL_06e5;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_207 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_208 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_207.___register_0;
		uint8_t L_209 = (uint8_t)L_208.___byte_0_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_210 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_211 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_210.___register_0;
		uint8_t L_212 = (uint8_t)L_211.___byte_0_0;
		G_B84_0 = (&V_20);
		if ((((int32_t)L_209) == ((int32_t)L_212)))
		{
			G_B85_0 = (&V_20);
			goto IL_048a;
		}
	}
	{
		G_B86_0 = 0;
		G_B86_1 = G_B84_0;
		goto IL_048f;
	}

IL_048a:
	{
		uint8_t L_213;
		L_213 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B86_0 = ((int32_t)(L_213));
		G_B86_1 = G_B85_0;
	}

IL_048f:
	{
		G_B86_1->___byte_0_0 = (uint8_t)G_B86_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_214 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_215 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_214.___register_0;
		uint8_t L_216 = (uint8_t)L_215.___byte_1_1;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_217 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_218 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_217.___register_0;
		uint8_t L_219 = (uint8_t)L_218.___byte_1_1;
		G_B87_0 = (&V_20);
		if ((((int32_t)L_216) == ((int32_t)L_219)))
		{
			G_B88_0 = (&V_20);
			goto IL_04b1;
		}
	}
	{
		G_B89_0 = 0;
		G_B89_1 = G_B87_0;
		goto IL_04b6;
	}

IL_04b1:
	{
		uint8_t L_220;
		L_220 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B89_0 = ((int32_t)(L_220));
		G_B89_1 = G_B88_0;
	}

IL_04b6:
	{
		G_B89_1->___byte_1_1 = (uint8_t)G_B89_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_221 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_222 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_221.___register_0;
		uint8_t L_223 = (uint8_t)L_222.___byte_2_2;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_224 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_225 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_224.___register_0;
		uint8_t L_226 = (uint8_t)L_225.___byte_2_2;
		G_B90_0 = (&V_20);
		if ((((int32_t)L_223) == ((int32_t)L_226)))
		{
			G_B91_0 = (&V_20);
			goto IL_04d8;
		}
	}
	{
		G_B92_0 = 0;
		G_B92_1 = G_B90_0;
		goto IL_04dd;
	}

IL_04d8:
	{
		uint8_t L_227;
		L_227 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B92_0 = ((int32_t)(L_227));
		G_B92_1 = G_B91_0;
	}

IL_04dd:
	{
		G_B92_1->___byte_2_2 = (uint8_t)G_B92_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_228 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_229 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_228.___register_0;
		uint8_t L_230 = (uint8_t)L_229.___byte_3_3;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_231 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_232 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_231.___register_0;
		uint8_t L_233 = (uint8_t)L_232.___byte_3_3;
		G_B93_0 = (&V_20);
		if ((((int32_t)L_230) == ((int32_t)L_233)))
		{
			G_B94_0 = (&V_20);
			goto IL_04ff;
		}
	}
	{
		G_B95_0 = 0;
		G_B95_1 = G_B93_0;
		goto IL_0504;
	}

IL_04ff:
	{
		uint8_t L_234;
		L_234 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B95_0 = ((int32_t)(L_234));
		G_B95_1 = G_B94_0;
	}

IL_0504:
	{
		G_B95_1->___byte_3_3 = (uint8_t)G_B95_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_235 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_236 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_235.___register_0;
		uint8_t L_237 = (uint8_t)L_236.___byte_4_4;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_238 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_239 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_238.___register_0;
		uint8_t L_240 = (uint8_t)L_239.___byte_4_4;
		G_B96_0 = (&V_20);
		if ((((int32_t)L_237) == ((int32_t)L_240)))
		{
			G_B97_0 = (&V_20);
			goto IL_0526;
		}
	}
	{
		G_B98_0 = 0;
		G_B98_1 = G_B96_0;
		goto IL_052b;
	}

IL_0526:
	{
		uint8_t L_241;
		L_241 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B98_0 = ((int32_t)(L_241));
		G_B98_1 = G_B97_0;
	}

IL_052b:
	{
		G_B98_1->___byte_4_4 = (uint8_t)G_B98_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_242 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_243 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_242.___register_0;
		uint8_t L_244 = (uint8_t)L_243.___byte_5_5;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_245 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_246 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_245.___register_0;
		uint8_t L_247 = (uint8_t)L_246.___byte_5_5;
		G_B99_0 = (&V_20);
		if ((((int32_t)L_244) == ((int32_t)L_247)))
		{
			G_B100_0 = (&V_20);
			goto IL_054d;
		}
	}
	{
		G_B101_0 = 0;
		G_B101_1 = G_B99_0;
		goto IL_0552;
	}

IL_054d:
	{
		uint8_t L_248;
		L_248 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B101_0 = ((int32_t)(L_248));
		G_B101_1 = G_B100_0;
	}

IL_0552:
	{
		G_B101_1->___byte_5_5 = (uint8_t)G_B101_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_249 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_250 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_249.___register_0;
		uint8_t L_251 = (uint8_t)L_250.___byte_6_6;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_252 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_253 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_252.___register_0;
		uint8_t L_254 = (uint8_t)L_253.___byte_6_6;
		G_B102_0 = (&V_20);
		if ((((int32_t)L_251) == ((int32_t)L_254)))
		{
			G_B103_0 = (&V_20);
			goto IL_0574;
		}
	}
	{
		G_B104_0 = 0;
		G_B104_1 = G_B102_0;
		goto IL_0579;
	}

IL_0574:
	{
		uint8_t L_255;
		L_255 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B104_0 = ((int32_t)(L_255));
		G_B104_1 = G_B103_0;
	}

IL_0579:
	{
		G_B104_1->___byte_6_6 = (uint8_t)G_B104_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_256 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_257 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_256.___register_0;
		uint8_t L_258 = (uint8_t)L_257.___byte_7_7;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_259 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_260 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_259.___register_0;
		uint8_t L_261 = (uint8_t)L_260.___byte_7_7;
		G_B105_0 = (&V_20);
		if ((((int32_t)L_258) == ((int32_t)L_261)))
		{
			G_B106_0 = (&V_20);
			goto IL_059b;
		}
	}
	{
		G_B107_0 = 0;
		G_B107_1 = G_B105_0;
		goto IL_05a0;
	}

IL_059b:
	{
		uint8_t L_262;
		L_262 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B107_0 = ((int32_t)(L_262));
		G_B107_1 = G_B106_0;
	}

IL_05a0:
	{
		G_B107_1->___byte_7_7 = (uint8_t)G_B107_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_263 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_264 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_263.___register_0;
		uint8_t L_265 = (uint8_t)L_264.___byte_8_8;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_266 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_267 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_266.___register_0;
		uint8_t L_268 = (uint8_t)L_267.___byte_8_8;
		G_B108_0 = (&V_20);
		if ((((int32_t)L_265) == ((int32_t)L_268)))
		{
			G_B109_0 = (&V_20);
			goto IL_05c2;
		}
	}
	{
		G_B110_0 = 0;
		G_B110_1 = G_B108_0;
		goto IL_05c7;
	}

IL_05c2:
	{
		uint8_t L_269;
		L_269 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B110_0 = ((int32_t)(L_269));
		G_B110_1 = G_B109_0;
	}

IL_05c7:
	{
		G_B110_1->___byte_8_8 = (uint8_t)G_B110_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_270 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_271 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_270.___register_0;
		uint8_t L_272 = (uint8_t)L_271.___byte_9_9;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_273 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_274 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_273.___register_0;
		uint8_t L_275 = (uint8_t)L_274.___byte_9_9;
		G_B111_0 = (&V_20);
		if ((((int32_t)L_272) == ((int32_t)L_275)))
		{
			G_B112_0 = (&V_20);
			goto IL_05e9;
		}
	}
	{
		G_B113_0 = 0;
		G_B113_1 = G_B111_0;
		goto IL_05ee;
	}

IL_05e9:
	{
		uint8_t L_276;
		L_276 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B113_0 = ((int32_t)(L_276));
		G_B113_1 = G_B112_0;
	}

IL_05ee:
	{
		G_B113_1->___byte_9_9 = (uint8_t)G_B113_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_277 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_278 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_277.___register_0;
		uint8_t L_279 = (uint8_t)L_278.___byte_10_10;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_280 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_281 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_280.___register_0;
		uint8_t L_282 = (uint8_t)L_281.___byte_10_10;
		G_B114_0 = (&V_20);
		if ((((int32_t)L_279) == ((int32_t)L_282)))
		{
			G_B115_0 = (&V_20);
			goto IL_0610;
		}
	}
	{
		G_B116_0 = 0;
		G_B116_1 = G_B114_0;
		goto IL_0615;
	}

IL_0610:
	{
		uint8_t L_283;
		L_283 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B116_0 = ((int32_t)(L_283));
		G_B116_1 = G_B115_0;
	}

IL_0615:
	{
		G_B116_1->___byte_10_10 = (uint8_t)G_B116_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_284 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_285 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_284.___register_0;
		uint8_t L_286 = (uint8_t)L_285.___byte_11_11;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_287 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_288 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_287.___register_0;
		uint8_t L_289 = (uint8_t)L_288.___byte_11_11;
		G_B117_0 = (&V_20);
		if ((((int32_t)L_286) == ((int32_t)L_289)))
		{
			G_B118_0 = (&V_20);
			goto IL_0637;
		}
	}
	{
		G_B119_0 = 0;
		G_B119_1 = G_B117_0;
		goto IL_063c;
	}

IL_0637:
	{
		uint8_t L_290;
		L_290 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B119_0 = ((int32_t)(L_290));
		G_B119_1 = G_B118_0;
	}

IL_063c:
	{
		G_B119_1->___byte_11_11 = (uint8_t)G_B119_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_291 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_292 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_291.___register_0;
		uint8_t L_293 = (uint8_t)L_292.___byte_12_12;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_294 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_295 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_294.___register_0;
		uint8_t L_296 = (uint8_t)L_295.___byte_12_12;
		G_B120_0 = (&V_20);
		if ((((int32_t)L_293) == ((int32_t)L_296)))
		{
			G_B121_0 = (&V_20);
			goto IL_065e;
		}
	}
	{
		G_B122_0 = 0;
		G_B122_1 = G_B120_0;
		goto IL_0663;
	}

IL_065e:
	{
		uint8_t L_297;
		L_297 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B122_0 = ((int32_t)(L_297));
		G_B122_1 = G_B121_0;
	}

IL_0663:
	{
		G_B122_1->___byte_12_12 = (uint8_t)G_B122_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_298 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_299 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_298.___register_0;
		uint8_t L_300 = (uint8_t)L_299.___byte_13_13;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_301 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_302 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_301.___register_0;
		uint8_t L_303 = (uint8_t)L_302.___byte_13_13;
		G_B123_0 = (&V_20);
		if ((((int32_t)L_300) == ((int32_t)L_303)))
		{
			G_B124_0 = (&V_20);
			goto IL_0685;
		}
	}
	{
		G_B125_0 = 0;
		G_B125_1 = G_B123_0;
		goto IL_068a;
	}

IL_0685:
	{
		uint8_t L_304;
		L_304 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B125_0 = ((int32_t)(L_304));
		G_B125_1 = G_B124_0;
	}

IL_068a:
	{
		G_B125_1->___byte_13_13 = (uint8_t)G_B125_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_305 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_306 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_305.___register_0;
		uint8_t L_307 = (uint8_t)L_306.___byte_14_14;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_308 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_309 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_308.___register_0;
		uint8_t L_310 = (uint8_t)L_309.___byte_14_14;
		G_B126_0 = (&V_20);
		if ((((int32_t)L_307) == ((int32_t)L_310)))
		{
			G_B127_0 = (&V_20);
			goto IL_06ac;
		}
	}
	{
		G_B128_0 = 0;
		G_B128_1 = G_B126_0;
		goto IL_06b1;
	}

IL_06ac:
	{
		uint8_t L_311;
		L_311 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B128_0 = ((int32_t)(L_311));
		G_B128_1 = G_B127_0;
	}

IL_06b1:
	{
		G_B128_1->___byte_14_14 = (uint8_t)G_B128_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_312 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_313 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_312.___register_0;
		uint8_t L_314 = (uint8_t)L_313.___byte_15_15;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_315 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_316 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_315.___register_0;
		uint8_t L_317 = (uint8_t)L_316.___byte_15_15;
		G_B129_0 = (&V_20);
		if ((((int32_t)L_314) == ((int32_t)L_317)))
		{
			G_B130_0 = (&V_20);
			goto IL_06d3;
		}
	}
	{
		G_B131_0 = 0;
		G_B131_1 = G_B129_0;
		goto IL_06d8;
	}

IL_06d3:
	{
		uint8_t L_318;
		L_318 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		G_B131_0 = ((int32_t)(L_318));
		G_B131_1 = G_B130_0;
	}

IL_06d8:
	{
		G_B131_1->___byte_15_15 = (uint8_t)G_B131_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_319;
		memset((&L_319), 0, sizeof(L_319));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_319), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_319;
	}

IL_06e5:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_320 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_321;
		L_321 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_320, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_322 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_323;
		L_323 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_322, NULL);
		bool L_324;
		L_324 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_321, L_323, NULL);
		if (!L_324)
		{
			goto IL_097b;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_325 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_326 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_325.___register_0;
		int8_t L_327 = (int8_t)L_326.___sbyte_0_16;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_328 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_329 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_328.___register_0;
		int8_t L_330 = (int8_t)L_329.___sbyte_0_16;
		G_B134_0 = (&V_20);
		if ((((int32_t)L_327) == ((int32_t)L_330)))
		{
			G_B135_0 = (&V_20);
			goto IL_0720;
		}
	}
	{
		G_B136_0 = 0;
		G_B136_1 = G_B134_0;
		goto IL_0725;
	}

IL_0720:
	{
		int8_t L_331;
		L_331 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B136_0 = ((int32_t)(L_331));
		G_B136_1 = G_B135_0;
	}

IL_0725:
	{
		G_B136_1->___sbyte_0_16 = (int8_t)G_B136_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_332 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_333 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_332.___register_0;
		int8_t L_334 = (int8_t)L_333.___sbyte_1_17;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_335 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_336 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_335.___register_0;
		int8_t L_337 = (int8_t)L_336.___sbyte_1_17;
		G_B137_0 = (&V_20);
		if ((((int32_t)L_334) == ((int32_t)L_337)))
		{
			G_B138_0 = (&V_20);
			goto IL_0747;
		}
	}
	{
		G_B139_0 = 0;
		G_B139_1 = G_B137_0;
		goto IL_074c;
	}

IL_0747:
	{
		int8_t L_338;
		L_338 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B139_0 = ((int32_t)(L_338));
		G_B139_1 = G_B138_0;
	}

IL_074c:
	{
		G_B139_1->___sbyte_1_17 = (int8_t)G_B139_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_339 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_340 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_339.___register_0;
		int8_t L_341 = (int8_t)L_340.___sbyte_2_18;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_342 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_343 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_342.___register_0;
		int8_t L_344 = (int8_t)L_343.___sbyte_2_18;
		G_B140_0 = (&V_20);
		if ((((int32_t)L_341) == ((int32_t)L_344)))
		{
			G_B141_0 = (&V_20);
			goto IL_076e;
		}
	}
	{
		G_B142_0 = 0;
		G_B142_1 = G_B140_0;
		goto IL_0773;
	}

IL_076e:
	{
		int8_t L_345;
		L_345 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B142_0 = ((int32_t)(L_345));
		G_B142_1 = G_B141_0;
	}

IL_0773:
	{
		G_B142_1->___sbyte_2_18 = (int8_t)G_B142_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_346 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_347 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_346.___register_0;
		int8_t L_348 = (int8_t)L_347.___sbyte_3_19;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_349 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_350 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_349.___register_0;
		int8_t L_351 = (int8_t)L_350.___sbyte_3_19;
		G_B143_0 = (&V_20);
		if ((((int32_t)L_348) == ((int32_t)L_351)))
		{
			G_B144_0 = (&V_20);
			goto IL_0795;
		}
	}
	{
		G_B145_0 = 0;
		G_B145_1 = G_B143_0;
		goto IL_079a;
	}

IL_0795:
	{
		int8_t L_352;
		L_352 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B145_0 = ((int32_t)(L_352));
		G_B145_1 = G_B144_0;
	}

IL_079a:
	{
		G_B145_1->___sbyte_3_19 = (int8_t)G_B145_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_353 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_354 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_353.___register_0;
		int8_t L_355 = (int8_t)L_354.___sbyte_4_20;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_356 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_357 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_356.___register_0;
		int8_t L_358 = (int8_t)L_357.___sbyte_4_20;
		G_B146_0 = (&V_20);
		if ((((int32_t)L_355) == ((int32_t)L_358)))
		{
			G_B147_0 = (&V_20);
			goto IL_07bc;
		}
	}
	{
		G_B148_0 = 0;
		G_B148_1 = G_B146_0;
		goto IL_07c1;
	}

IL_07bc:
	{
		int8_t L_359;
		L_359 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B148_0 = ((int32_t)(L_359));
		G_B148_1 = G_B147_0;
	}

IL_07c1:
	{
		G_B148_1->___sbyte_4_20 = (int8_t)G_B148_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_360 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_361 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_360.___register_0;
		int8_t L_362 = (int8_t)L_361.___sbyte_5_21;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_363 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_364 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_363.___register_0;
		int8_t L_365 = (int8_t)L_364.___sbyte_5_21;
		G_B149_0 = (&V_20);
		if ((((int32_t)L_362) == ((int32_t)L_365)))
		{
			G_B150_0 = (&V_20);
			goto IL_07e3;
		}
	}
	{
		G_B151_0 = 0;
		G_B151_1 = G_B149_0;
		goto IL_07e8;
	}

IL_07e3:
	{
		int8_t L_366;
		L_366 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B151_0 = ((int32_t)(L_366));
		G_B151_1 = G_B150_0;
	}

IL_07e8:
	{
		G_B151_1->___sbyte_5_21 = (int8_t)G_B151_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_367 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_368 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_367.___register_0;
		int8_t L_369 = (int8_t)L_368.___sbyte_6_22;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_370 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_371 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_370.___register_0;
		int8_t L_372 = (int8_t)L_371.___sbyte_6_22;
		G_B152_0 = (&V_20);
		if ((((int32_t)L_369) == ((int32_t)L_372)))
		{
			G_B153_0 = (&V_20);
			goto IL_080a;
		}
	}
	{
		G_B154_0 = 0;
		G_B154_1 = G_B152_0;
		goto IL_080f;
	}

IL_080a:
	{
		int8_t L_373;
		L_373 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B154_0 = ((int32_t)(L_373));
		G_B154_1 = G_B153_0;
	}

IL_080f:
	{
		G_B154_1->___sbyte_6_22 = (int8_t)G_B154_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_374 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_375 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_374.___register_0;
		int8_t L_376 = (int8_t)L_375.___sbyte_7_23;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_377 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_378 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_377.___register_0;
		int8_t L_379 = (int8_t)L_378.___sbyte_7_23;
		G_B155_0 = (&V_20);
		if ((((int32_t)L_376) == ((int32_t)L_379)))
		{
			G_B156_0 = (&V_20);
			goto IL_0831;
		}
	}
	{
		G_B157_0 = 0;
		G_B157_1 = G_B155_0;
		goto IL_0836;
	}

IL_0831:
	{
		int8_t L_380;
		L_380 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B157_0 = ((int32_t)(L_380));
		G_B157_1 = G_B156_0;
	}

IL_0836:
	{
		G_B157_1->___sbyte_7_23 = (int8_t)G_B157_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_381 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_382 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_381.___register_0;
		int8_t L_383 = (int8_t)L_382.___sbyte_8_24;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_384 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_385 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_384.___register_0;
		int8_t L_386 = (int8_t)L_385.___sbyte_8_24;
		G_B158_0 = (&V_20);
		if ((((int32_t)L_383) == ((int32_t)L_386)))
		{
			G_B159_0 = (&V_20);
			goto IL_0858;
		}
	}
	{
		G_B160_0 = 0;
		G_B160_1 = G_B158_0;
		goto IL_085d;
	}

IL_0858:
	{
		int8_t L_387;
		L_387 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B160_0 = ((int32_t)(L_387));
		G_B160_1 = G_B159_0;
	}

IL_085d:
	{
		G_B160_1->___sbyte_8_24 = (int8_t)G_B160_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_388 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_389 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_388.___register_0;
		int8_t L_390 = (int8_t)L_389.___sbyte_9_25;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_391 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_392 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_391.___register_0;
		int8_t L_393 = (int8_t)L_392.___sbyte_9_25;
		G_B161_0 = (&V_20);
		if ((((int32_t)L_390) == ((int32_t)L_393)))
		{
			G_B162_0 = (&V_20);
			goto IL_087f;
		}
	}
	{
		G_B163_0 = 0;
		G_B163_1 = G_B161_0;
		goto IL_0884;
	}

IL_087f:
	{
		int8_t L_394;
		L_394 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B163_0 = ((int32_t)(L_394));
		G_B163_1 = G_B162_0;
	}

IL_0884:
	{
		G_B163_1->___sbyte_9_25 = (int8_t)G_B163_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_395 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_396 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_395.___register_0;
		int8_t L_397 = (int8_t)L_396.___sbyte_10_26;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_398 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_399 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_398.___register_0;
		int8_t L_400 = (int8_t)L_399.___sbyte_10_26;
		G_B164_0 = (&V_20);
		if ((((int32_t)L_397) == ((int32_t)L_400)))
		{
			G_B165_0 = (&V_20);
			goto IL_08a6;
		}
	}
	{
		G_B166_0 = 0;
		G_B166_1 = G_B164_0;
		goto IL_08ab;
	}

IL_08a6:
	{
		int8_t L_401;
		L_401 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B166_0 = ((int32_t)(L_401));
		G_B166_1 = G_B165_0;
	}

IL_08ab:
	{
		G_B166_1->___sbyte_10_26 = (int8_t)G_B166_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_402 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_403 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_402.___register_0;
		int8_t L_404 = (int8_t)L_403.___sbyte_11_27;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_405 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_406 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_405.___register_0;
		int8_t L_407 = (int8_t)L_406.___sbyte_11_27;
		G_B167_0 = (&V_20);
		if ((((int32_t)L_404) == ((int32_t)L_407)))
		{
			G_B168_0 = (&V_20);
			goto IL_08cd;
		}
	}
	{
		G_B169_0 = 0;
		G_B169_1 = G_B167_0;
		goto IL_08d2;
	}

IL_08cd:
	{
		int8_t L_408;
		L_408 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B169_0 = ((int32_t)(L_408));
		G_B169_1 = G_B168_0;
	}

IL_08d2:
	{
		G_B169_1->___sbyte_11_27 = (int8_t)G_B169_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_409 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_410 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_409.___register_0;
		int8_t L_411 = (int8_t)L_410.___sbyte_12_28;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_412 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_413 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_412.___register_0;
		int8_t L_414 = (int8_t)L_413.___sbyte_12_28;
		G_B170_0 = (&V_20);
		if ((((int32_t)L_411) == ((int32_t)L_414)))
		{
			G_B171_0 = (&V_20);
			goto IL_08f4;
		}
	}
	{
		G_B172_0 = 0;
		G_B172_1 = G_B170_0;
		goto IL_08f9;
	}

IL_08f4:
	{
		int8_t L_415;
		L_415 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B172_0 = ((int32_t)(L_415));
		G_B172_1 = G_B171_0;
	}

IL_08f9:
	{
		G_B172_1->___sbyte_12_28 = (int8_t)G_B172_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_416 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_417 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_416.___register_0;
		int8_t L_418 = (int8_t)L_417.___sbyte_13_29;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_419 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_420 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_419.___register_0;
		int8_t L_421 = (int8_t)L_420.___sbyte_13_29;
		G_B173_0 = (&V_20);
		if ((((int32_t)L_418) == ((int32_t)L_421)))
		{
			G_B174_0 = (&V_20);
			goto IL_091b;
		}
	}
	{
		G_B175_0 = 0;
		G_B175_1 = G_B173_0;
		goto IL_0920;
	}

IL_091b:
	{
		int8_t L_422;
		L_422 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B175_0 = ((int32_t)(L_422));
		G_B175_1 = G_B174_0;
	}

IL_0920:
	{
		G_B175_1->___sbyte_13_29 = (int8_t)G_B175_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_423 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_424 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_423.___register_0;
		int8_t L_425 = (int8_t)L_424.___sbyte_14_30;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_426 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_427 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_426.___register_0;
		int8_t L_428 = (int8_t)L_427.___sbyte_14_30;
		G_B176_0 = (&V_20);
		if ((((int32_t)L_425) == ((int32_t)L_428)))
		{
			G_B177_0 = (&V_20);
			goto IL_0942;
		}
	}
	{
		G_B178_0 = 0;
		G_B178_1 = G_B176_0;
		goto IL_0947;
	}

IL_0942:
	{
		int8_t L_429;
		L_429 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B178_0 = ((int32_t)(L_429));
		G_B178_1 = G_B177_0;
	}

IL_0947:
	{
		G_B178_1->___sbyte_14_30 = (int8_t)G_B178_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_430 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_431 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_430.___register_0;
		int8_t L_432 = (int8_t)L_431.___sbyte_15_31;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_433 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_434 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_433.___register_0;
		int8_t L_435 = (int8_t)L_434.___sbyte_15_31;
		G_B179_0 = (&V_20);
		if ((((int32_t)L_432) == ((int32_t)L_435)))
		{
			G_B180_0 = (&V_20);
			goto IL_0969;
		}
	}
	{
		G_B181_0 = 0;
		G_B181_1 = G_B179_0;
		goto IL_096e;
	}

IL_0969:
	{
		int8_t L_436;
		L_436 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		G_B181_0 = ((int32_t)(L_436));
		G_B181_1 = G_B180_0;
	}

IL_096e:
	{
		G_B181_1->___sbyte_15_31 = (int8_t)G_B181_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_437;
		memset((&L_437), 0, sizeof(L_437));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_437), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_437;
	}

IL_097b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_438 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_439;
		L_439 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_438, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_440 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_441;
		L_441 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_440, NULL);
		bool L_442;
		L_442 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_439, L_441, NULL);
		if (!L_442)
		{
			goto IL_0ad9;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_443 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_444 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_443.___register_0;
		uint16_t L_445 = (uint16_t)L_444.___uint16_0_32;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_446 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_447 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_446.___register_0;
		uint16_t L_448 = (uint16_t)L_447.___uint16_0_32;
		G_B184_0 = (&V_20);
		if ((((int32_t)L_445) == ((int32_t)L_448)))
		{
			G_B185_0 = (&V_20);
			goto IL_09b6;
		}
	}
	{
		G_B186_0 = 0;
		G_B186_1 = G_B184_0;
		goto IL_09bb;
	}

IL_09b6:
	{
		uint16_t L_449;
		L_449 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B186_0 = ((int32_t)(L_449));
		G_B186_1 = G_B185_0;
	}

IL_09bb:
	{
		G_B186_1->___uint16_0_32 = (uint16_t)G_B186_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_450 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_451 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_450.___register_0;
		uint16_t L_452 = (uint16_t)L_451.___uint16_1_33;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_453 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_454 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_453.___register_0;
		uint16_t L_455 = (uint16_t)L_454.___uint16_1_33;
		G_B187_0 = (&V_20);
		if ((((int32_t)L_452) == ((int32_t)L_455)))
		{
			G_B188_0 = (&V_20);
			goto IL_09dd;
		}
	}
	{
		G_B189_0 = 0;
		G_B189_1 = G_B187_0;
		goto IL_09e2;
	}

IL_09dd:
	{
		uint16_t L_456;
		L_456 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B189_0 = ((int32_t)(L_456));
		G_B189_1 = G_B188_0;
	}

IL_09e2:
	{
		G_B189_1->___uint16_1_33 = (uint16_t)G_B189_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_457 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_458 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_457.___register_0;
		uint16_t L_459 = (uint16_t)L_458.___uint16_2_34;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_460 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_461 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_460.___register_0;
		uint16_t L_462 = (uint16_t)L_461.___uint16_2_34;
		G_B190_0 = (&V_20);
		if ((((int32_t)L_459) == ((int32_t)L_462)))
		{
			G_B191_0 = (&V_20);
			goto IL_0a04;
		}
	}
	{
		G_B192_0 = 0;
		G_B192_1 = G_B190_0;
		goto IL_0a09;
	}

IL_0a04:
	{
		uint16_t L_463;
		L_463 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B192_0 = ((int32_t)(L_463));
		G_B192_1 = G_B191_0;
	}

IL_0a09:
	{
		G_B192_1->___uint16_2_34 = (uint16_t)G_B192_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_464 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_465 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_464.___register_0;
		uint16_t L_466 = (uint16_t)L_465.___uint16_3_35;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_467 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_468 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_467.___register_0;
		uint16_t L_469 = (uint16_t)L_468.___uint16_3_35;
		G_B193_0 = (&V_20);
		if ((((int32_t)L_466) == ((int32_t)L_469)))
		{
			G_B194_0 = (&V_20);
			goto IL_0a2b;
		}
	}
	{
		G_B195_0 = 0;
		G_B195_1 = G_B193_0;
		goto IL_0a30;
	}

IL_0a2b:
	{
		uint16_t L_470;
		L_470 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B195_0 = ((int32_t)(L_470));
		G_B195_1 = G_B194_0;
	}

IL_0a30:
	{
		G_B195_1->___uint16_3_35 = (uint16_t)G_B195_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_471 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_472 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_471.___register_0;
		uint16_t L_473 = (uint16_t)L_472.___uint16_4_36;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_474 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_475 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_474.___register_0;
		uint16_t L_476 = (uint16_t)L_475.___uint16_4_36;
		G_B196_0 = (&V_20);
		if ((((int32_t)L_473) == ((int32_t)L_476)))
		{
			G_B197_0 = (&V_20);
			goto IL_0a52;
		}
	}
	{
		G_B198_0 = 0;
		G_B198_1 = G_B196_0;
		goto IL_0a57;
	}

IL_0a52:
	{
		uint16_t L_477;
		L_477 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B198_0 = ((int32_t)(L_477));
		G_B198_1 = G_B197_0;
	}

IL_0a57:
	{
		G_B198_1->___uint16_4_36 = (uint16_t)G_B198_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_478 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_479 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_478.___register_0;
		uint16_t L_480 = (uint16_t)L_479.___uint16_5_37;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_481 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_482 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_481.___register_0;
		uint16_t L_483 = (uint16_t)L_482.___uint16_5_37;
		G_B199_0 = (&V_20);
		if ((((int32_t)L_480) == ((int32_t)L_483)))
		{
			G_B200_0 = (&V_20);
			goto IL_0a79;
		}
	}
	{
		G_B201_0 = 0;
		G_B201_1 = G_B199_0;
		goto IL_0a7e;
	}

IL_0a79:
	{
		uint16_t L_484;
		L_484 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B201_0 = ((int32_t)(L_484));
		G_B201_1 = G_B200_0;
	}

IL_0a7e:
	{
		G_B201_1->___uint16_5_37 = (uint16_t)G_B201_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_485 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_486 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_485.___register_0;
		uint16_t L_487 = (uint16_t)L_486.___uint16_6_38;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_488 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_489 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_488.___register_0;
		uint16_t L_490 = (uint16_t)L_489.___uint16_6_38;
		G_B202_0 = (&V_20);
		if ((((int32_t)L_487) == ((int32_t)L_490)))
		{
			G_B203_0 = (&V_20);
			goto IL_0aa0;
		}
	}
	{
		G_B204_0 = 0;
		G_B204_1 = G_B202_0;
		goto IL_0aa5;
	}

IL_0aa0:
	{
		uint16_t L_491;
		L_491 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B204_0 = ((int32_t)(L_491));
		G_B204_1 = G_B203_0;
	}

IL_0aa5:
	{
		G_B204_1->___uint16_6_38 = (uint16_t)G_B204_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_492 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_493 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_492.___register_0;
		uint16_t L_494 = (uint16_t)L_493.___uint16_7_39;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_495 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_496 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_495.___register_0;
		uint16_t L_497 = (uint16_t)L_496.___uint16_7_39;
		G_B205_0 = (&V_20);
		if ((((int32_t)L_494) == ((int32_t)L_497)))
		{
			G_B206_0 = (&V_20);
			goto IL_0ac7;
		}
	}
	{
		G_B207_0 = 0;
		G_B207_1 = G_B205_0;
		goto IL_0acc;
	}

IL_0ac7:
	{
		uint16_t L_498;
		L_498 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		G_B207_0 = ((int32_t)(L_498));
		G_B207_1 = G_B206_0;
	}

IL_0acc:
	{
		G_B207_1->___uint16_7_39 = (uint16_t)G_B207_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_499;
		memset((&L_499), 0, sizeof(L_499));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_499), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_499;
	}

IL_0ad9:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_500 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_501;
		L_501 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_500, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_502 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_503;
		L_503 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_502, NULL);
		bool L_504;
		L_504 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_501, L_503, NULL);
		if (!L_504)
		{
			goto IL_0c37;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_505 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_506 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_505.___register_0;
		int16_t L_507 = (int16_t)L_506.___int16_0_40;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_508 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_509 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_508.___register_0;
		int16_t L_510 = (int16_t)L_509.___int16_0_40;
		G_B210_0 = (&V_20);
		if ((((int32_t)L_507) == ((int32_t)L_510)))
		{
			G_B211_0 = (&V_20);
			goto IL_0b14;
		}
	}
	{
		G_B212_0 = 0;
		G_B212_1 = G_B210_0;
		goto IL_0b19;
	}

IL_0b14:
	{
		int16_t L_511;
		L_511 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B212_0 = ((int32_t)(L_511));
		G_B212_1 = G_B211_0;
	}

IL_0b19:
	{
		G_B212_1->___int16_0_40 = (int16_t)G_B212_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_512 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_513 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_512.___register_0;
		int16_t L_514 = (int16_t)L_513.___int16_1_41;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_515 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_516 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_515.___register_0;
		int16_t L_517 = (int16_t)L_516.___int16_1_41;
		G_B213_0 = (&V_20);
		if ((((int32_t)L_514) == ((int32_t)L_517)))
		{
			G_B214_0 = (&V_20);
			goto IL_0b3b;
		}
	}
	{
		G_B215_0 = 0;
		G_B215_1 = G_B213_0;
		goto IL_0b40;
	}

IL_0b3b:
	{
		int16_t L_518;
		L_518 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B215_0 = ((int32_t)(L_518));
		G_B215_1 = G_B214_0;
	}

IL_0b40:
	{
		G_B215_1->___int16_1_41 = (int16_t)G_B215_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_519 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_520 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_519.___register_0;
		int16_t L_521 = (int16_t)L_520.___int16_2_42;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_522 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_523 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_522.___register_0;
		int16_t L_524 = (int16_t)L_523.___int16_2_42;
		G_B216_0 = (&V_20);
		if ((((int32_t)L_521) == ((int32_t)L_524)))
		{
			G_B217_0 = (&V_20);
			goto IL_0b62;
		}
	}
	{
		G_B218_0 = 0;
		G_B218_1 = G_B216_0;
		goto IL_0b67;
	}

IL_0b62:
	{
		int16_t L_525;
		L_525 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B218_0 = ((int32_t)(L_525));
		G_B218_1 = G_B217_0;
	}

IL_0b67:
	{
		G_B218_1->___int16_2_42 = (int16_t)G_B218_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_526 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_527 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_526.___register_0;
		int16_t L_528 = (int16_t)L_527.___int16_3_43;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_529 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_530 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_529.___register_0;
		int16_t L_531 = (int16_t)L_530.___int16_3_43;
		G_B219_0 = (&V_20);
		if ((((int32_t)L_528) == ((int32_t)L_531)))
		{
			G_B220_0 = (&V_20);
			goto IL_0b89;
		}
	}
	{
		G_B221_0 = 0;
		G_B221_1 = G_B219_0;
		goto IL_0b8e;
	}

IL_0b89:
	{
		int16_t L_532;
		L_532 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B221_0 = ((int32_t)(L_532));
		G_B221_1 = G_B220_0;
	}

IL_0b8e:
	{
		G_B221_1->___int16_3_43 = (int16_t)G_B221_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_533 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_534 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_533.___register_0;
		int16_t L_535 = (int16_t)L_534.___int16_4_44;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_536 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_537 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_536.___register_0;
		int16_t L_538 = (int16_t)L_537.___int16_4_44;
		G_B222_0 = (&V_20);
		if ((((int32_t)L_535) == ((int32_t)L_538)))
		{
			G_B223_0 = (&V_20);
			goto IL_0bb0;
		}
	}
	{
		G_B224_0 = 0;
		G_B224_1 = G_B222_0;
		goto IL_0bb5;
	}

IL_0bb0:
	{
		int16_t L_539;
		L_539 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B224_0 = ((int32_t)(L_539));
		G_B224_1 = G_B223_0;
	}

IL_0bb5:
	{
		G_B224_1->___int16_4_44 = (int16_t)G_B224_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_540 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_541 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_540.___register_0;
		int16_t L_542 = (int16_t)L_541.___int16_5_45;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_543 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_544 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_543.___register_0;
		int16_t L_545 = (int16_t)L_544.___int16_5_45;
		G_B225_0 = (&V_20);
		if ((((int32_t)L_542) == ((int32_t)L_545)))
		{
			G_B226_0 = (&V_20);
			goto IL_0bd7;
		}
	}
	{
		G_B227_0 = 0;
		G_B227_1 = G_B225_0;
		goto IL_0bdc;
	}

IL_0bd7:
	{
		int16_t L_546;
		L_546 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B227_0 = ((int32_t)(L_546));
		G_B227_1 = G_B226_0;
	}

IL_0bdc:
	{
		G_B227_1->___int16_5_45 = (int16_t)G_B227_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_547 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_548 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_547.___register_0;
		int16_t L_549 = (int16_t)L_548.___int16_6_46;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_550 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_551 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_550.___register_0;
		int16_t L_552 = (int16_t)L_551.___int16_6_46;
		G_B228_0 = (&V_20);
		if ((((int32_t)L_549) == ((int32_t)L_552)))
		{
			G_B229_0 = (&V_20);
			goto IL_0bfe;
		}
	}
	{
		G_B230_0 = 0;
		G_B230_1 = G_B228_0;
		goto IL_0c03;
	}

IL_0bfe:
	{
		int16_t L_553;
		L_553 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B230_0 = ((int32_t)(L_553));
		G_B230_1 = G_B229_0;
	}

IL_0c03:
	{
		G_B230_1->___int16_6_46 = (int16_t)G_B230_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_554 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_555 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_554.___register_0;
		int16_t L_556 = (int16_t)L_555.___int16_7_47;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_557 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_558 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_557.___register_0;
		int16_t L_559 = (int16_t)L_558.___int16_7_47;
		G_B231_0 = (&V_20);
		if ((((int32_t)L_556) == ((int32_t)L_559)))
		{
			G_B232_0 = (&V_20);
			goto IL_0c25;
		}
	}
	{
		G_B233_0 = 0;
		G_B233_1 = G_B231_0;
		goto IL_0c2a;
	}

IL_0c25:
	{
		int16_t L_560;
		L_560 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		G_B233_0 = ((int32_t)(L_560));
		G_B233_1 = G_B232_0;
	}

IL_0c2a:
	{
		G_B233_1->___int16_7_47 = (int16_t)G_B233_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_561;
		memset((&L_561), 0, sizeof(L_561));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_561), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_561;
	}

IL_0c37:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_562 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_563;
		L_563 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_562, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_564 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_565;
		L_565 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_564, NULL);
		bool L_566;
		L_566 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_563, L_565, NULL);
		if (!L_566)
		{
			goto IL_0cf9;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_567 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_568 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_567.___register_0;
		uint32_t L_569 = (uint32_t)L_568.___uint32_0_48;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_570 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_571 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_570.___register_0;
		uint32_t L_572 = (uint32_t)L_571.___uint32_0_48;
		G_B236_0 = (&V_20);
		if ((((int32_t)L_569) == ((int32_t)L_572)))
		{
			G_B237_0 = (&V_20);
			goto IL_0c72;
		}
	}
	{
		G_B238_0 = ((uint32_t)(0));
		G_B238_1 = G_B236_0;
		goto IL_0c77;
	}

IL_0c72:
	{
		uint32_t L_573;
		L_573 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B238_0 = L_573;
		G_B238_1 = G_B237_0;
	}

IL_0c77:
	{
		G_B238_1->___uint32_0_48 = G_B238_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_574 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_575 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_574.___register_0;
		uint32_t L_576 = (uint32_t)L_575.___uint32_1_49;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_577 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_578 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_577.___register_0;
		uint32_t L_579 = (uint32_t)L_578.___uint32_1_49;
		G_B239_0 = (&V_20);
		if ((((int32_t)L_576) == ((int32_t)L_579)))
		{
			G_B240_0 = (&V_20);
			goto IL_0c99;
		}
	}
	{
		G_B241_0 = ((uint32_t)(0));
		G_B241_1 = G_B239_0;
		goto IL_0c9e;
	}

IL_0c99:
	{
		uint32_t L_580;
		L_580 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B241_0 = L_580;
		G_B241_1 = G_B240_0;
	}

IL_0c9e:
	{
		G_B241_1->___uint32_1_49 = G_B241_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_581 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_582 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_581.___register_0;
		uint32_t L_583 = (uint32_t)L_582.___uint32_2_50;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_584 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_585 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_584.___register_0;
		uint32_t L_586 = (uint32_t)L_585.___uint32_2_50;
		G_B242_0 = (&V_20);
		if ((((int32_t)L_583) == ((int32_t)L_586)))
		{
			G_B243_0 = (&V_20);
			goto IL_0cc0;
		}
	}
	{
		G_B244_0 = ((uint32_t)(0));
		G_B244_1 = G_B242_0;
		goto IL_0cc5;
	}

IL_0cc0:
	{
		uint32_t L_587;
		L_587 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B244_0 = L_587;
		G_B244_1 = G_B243_0;
	}

IL_0cc5:
	{
		G_B244_1->___uint32_2_50 = G_B244_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_588 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_589 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_588.___register_0;
		uint32_t L_590 = (uint32_t)L_589.___uint32_3_51;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_591 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_592 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_591.___register_0;
		uint32_t L_593 = (uint32_t)L_592.___uint32_3_51;
		G_B245_0 = (&V_20);
		if ((((int32_t)L_590) == ((int32_t)L_593)))
		{
			G_B246_0 = (&V_20);
			goto IL_0ce7;
		}
	}
	{
		G_B247_0 = ((uint32_t)(0));
		G_B247_1 = G_B245_0;
		goto IL_0cec;
	}

IL_0ce7:
	{
		uint32_t L_594;
		L_594 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		G_B247_0 = L_594;
		G_B247_1 = G_B246_0;
	}

IL_0cec:
	{
		G_B247_1->___uint32_3_51 = G_B247_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_595;
		memset((&L_595), 0, sizeof(L_595));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_595), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_595;
	}

IL_0cf9:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_596 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_597;
		L_597 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_596, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_598 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_599;
		L_599 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_598, NULL);
		bool L_600;
		L_600 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_597, L_599, NULL);
		if (!L_600)
		{
			goto IL_0dbb;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_601 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_602 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_601.___register_0;
		int32_t L_603 = (int32_t)L_602.___int32_0_52;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_604 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_605 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_604.___register_0;
		int32_t L_606 = (int32_t)L_605.___int32_0_52;
		G_B250_0 = (&V_20);
		if ((((int32_t)L_603) == ((int32_t)L_606)))
		{
			G_B251_0 = (&V_20);
			goto IL_0d34;
		}
	}
	{
		G_B252_0 = 0;
		G_B252_1 = G_B250_0;
		goto IL_0d39;
	}

IL_0d34:
	{
		int32_t L_607;
		L_607 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B252_0 = L_607;
		G_B252_1 = G_B251_0;
	}

IL_0d39:
	{
		G_B252_1->___int32_0_52 = G_B252_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_608 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_609 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_608.___register_0;
		int32_t L_610 = (int32_t)L_609.___int32_1_53;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_611 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_612 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_611.___register_0;
		int32_t L_613 = (int32_t)L_612.___int32_1_53;
		G_B253_0 = (&V_20);
		if ((((int32_t)L_610) == ((int32_t)L_613)))
		{
			G_B254_0 = (&V_20);
			goto IL_0d5b;
		}
	}
	{
		G_B255_0 = 0;
		G_B255_1 = G_B253_0;
		goto IL_0d60;
	}

IL_0d5b:
	{
		int32_t L_614;
		L_614 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B255_0 = L_614;
		G_B255_1 = G_B254_0;
	}

IL_0d60:
	{
		G_B255_1->___int32_1_53 = G_B255_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_615 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_616 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_615.___register_0;
		int32_t L_617 = (int32_t)L_616.___int32_2_54;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_618 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_619 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_618.___register_0;
		int32_t L_620 = (int32_t)L_619.___int32_2_54;
		G_B256_0 = (&V_20);
		if ((((int32_t)L_617) == ((int32_t)L_620)))
		{
			G_B257_0 = (&V_20);
			goto IL_0d82;
		}
	}
	{
		G_B258_0 = 0;
		G_B258_1 = G_B256_0;
		goto IL_0d87;
	}

IL_0d82:
	{
		int32_t L_621;
		L_621 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B258_0 = L_621;
		G_B258_1 = G_B257_0;
	}

IL_0d87:
	{
		G_B258_1->___int32_2_54 = G_B258_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_622 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_623 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_622.___register_0;
		int32_t L_624 = (int32_t)L_623.___int32_3_55;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_625 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_626 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_625.___register_0;
		int32_t L_627 = (int32_t)L_626.___int32_3_55;
		G_B259_0 = (&V_20);
		if ((((int32_t)L_624) == ((int32_t)L_627)))
		{
			G_B260_0 = (&V_20);
			goto IL_0da9;
		}
	}
	{
		G_B261_0 = 0;
		G_B261_1 = G_B259_0;
		goto IL_0dae;
	}

IL_0da9:
	{
		int32_t L_628;
		L_628 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		G_B261_0 = L_628;
		G_B261_1 = G_B260_0;
	}

IL_0dae:
	{
		G_B261_1->___int32_3_55 = G_B261_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_629;
		memset((&L_629), 0, sizeof(L_629));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_629), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_629;
	}

IL_0dbb:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_630 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_631;
		L_631 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_630, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_632 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_633;
		L_633 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_632, NULL);
		bool L_634;
		L_634 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_631, L_633, NULL);
		if (!L_634)
		{
			goto IL_0e2e;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_635 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_636 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_635.___register_0;
		uint64_t L_637 = (uint64_t)L_636.___uint64_0_56;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_638 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_639 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_638.___register_0;
		uint64_t L_640 = (uint64_t)L_639.___uint64_0_56;
		G_B264_0 = (&V_20);
		if ((((int64_t)L_637) == ((int64_t)L_640)))
		{
			G_B265_0 = (&V_20);
			goto IL_0df4;
		}
	}
	{
		G_B266_0 = ((uint64_t)(((int64_t)0)));
		G_B266_1 = G_B264_0;
		goto IL_0df9;
	}

IL_0df4:
	{
		uint64_t L_641;
		L_641 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		G_B266_0 = L_641;
		G_B266_1 = G_B265_0;
	}

IL_0df9:
	{
		G_B266_1->___uint64_0_56 = G_B266_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_642 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_643 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_642.___register_0;
		uint64_t L_644 = (uint64_t)L_643.___uint64_1_57;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_645 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_646 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_645.___register_0;
		uint64_t L_647 = (uint64_t)L_646.___uint64_1_57;
		G_B267_0 = (&V_20);
		if ((((int64_t)L_644) == ((int64_t)L_647)))
		{
			G_B268_0 = (&V_20);
			goto IL_0e1c;
		}
	}
	{
		G_B269_0 = ((uint64_t)(((int64_t)0)));
		G_B269_1 = G_B267_0;
		goto IL_0e21;
	}

IL_0e1c:
	{
		uint64_t L_648;
		L_648 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		G_B269_0 = L_648;
		G_B269_1 = G_B268_0;
	}

IL_0e21:
	{
		G_B269_1->___uint64_1_57 = G_B269_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_649;
		memset((&L_649), 0, sizeof(L_649));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_649), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_649;
	}

IL_0e2e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_650 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_651;
		L_651 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_650, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_652 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_653;
		L_653 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_652, NULL);
		bool L_654;
		L_654 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_651, L_653, NULL);
		if (!L_654)
		{
			goto IL_0ea1;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_655 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_656 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_655.___register_0;
		int64_t L_657 = (int64_t)L_656.___int64_0_58;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_658 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_659 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_658.___register_0;
		int64_t L_660 = (int64_t)L_659.___int64_0_58;
		G_B272_0 = (&V_20);
		if ((((int64_t)L_657) == ((int64_t)L_660)))
		{
			G_B273_0 = (&V_20);
			goto IL_0e67;
		}
	}
	{
		G_B274_0 = ((int64_t)0);
		G_B274_1 = G_B272_0;
		goto IL_0e6c;
	}

IL_0e67:
	{
		int64_t L_661;
		L_661 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		G_B274_0 = L_661;
		G_B274_1 = G_B273_0;
	}

IL_0e6c:
	{
		G_B274_1->___int64_0_58 = G_B274_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_662 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_663 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_662.___register_0;
		int64_t L_664 = (int64_t)L_663.___int64_1_59;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_665 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_666 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_665.___register_0;
		int64_t L_667 = (int64_t)L_666.___int64_1_59;
		G_B275_0 = (&V_20);
		if ((((int64_t)L_664) == ((int64_t)L_667)))
		{
			G_B276_0 = (&V_20);
			goto IL_0e8f;
		}
	}
	{
		G_B277_0 = ((int64_t)0);
		G_B277_1 = G_B275_0;
		goto IL_0e94;
	}

IL_0e8f:
	{
		int64_t L_668;
		L_668 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		G_B277_0 = L_668;
		G_B277_1 = G_B276_0;
	}

IL_0e94:
	{
		G_B277_1->___int64_1_59 = G_B277_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_669;
		memset((&L_669), 0, sizeof(L_669));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_669), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_669;
	}

IL_0ea1:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_670 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_671;
		L_671 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_670, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_672 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_673;
		L_673 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_672, NULL);
		bool L_674;
		L_674 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_671, L_673, NULL);
		if (!L_674)
		{
			goto IL_0f73;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_675 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_676 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_675.___register_0;
		float L_677 = (float)L_676.___single_0_60;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_678 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_679 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_678.___register_0;
		float L_680 = (float)L_679.___single_0_60;
		G_B280_0 = (&V_20);
		if ((((float)L_677) == ((float)L_680)))
		{
			G_B281_0 = (&V_20);
			goto IL_0ee0;
		}
	}
	{
		G_B282_0 = (0.0f);
		G_B282_1 = G_B280_0;
		goto IL_0ee5;
	}

IL_0ee0:
	{
		float L_681;
		L_681 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B282_0 = L_681;
		G_B282_1 = G_B281_0;
	}

IL_0ee5:
	{
		G_B282_1->___single_0_60 = G_B282_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_682 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_683 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_682.___register_0;
		float L_684 = (float)L_683.___single_1_61;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_685 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_686 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_685.___register_0;
		float L_687 = (float)L_686.___single_1_61;
		G_B283_0 = (&V_20);
		if ((((float)L_684) == ((float)L_687)))
		{
			G_B284_0 = (&V_20);
			goto IL_0f0b;
		}
	}
	{
		G_B285_0 = (0.0f);
		G_B285_1 = G_B283_0;
		goto IL_0f10;
	}

IL_0f0b:
	{
		float L_688;
		L_688 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B285_0 = L_688;
		G_B285_1 = G_B284_0;
	}

IL_0f10:
	{
		G_B285_1->___single_1_61 = G_B285_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_689 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_690 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_689.___register_0;
		float L_691 = (float)L_690.___single_2_62;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_692 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_693 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_692.___register_0;
		float L_694 = (float)L_693.___single_2_62;
		G_B286_0 = (&V_20);
		if ((((float)L_691) == ((float)L_694)))
		{
			G_B287_0 = (&V_20);
			goto IL_0f36;
		}
	}
	{
		G_B288_0 = (0.0f);
		G_B288_1 = G_B286_0;
		goto IL_0f3b;
	}

IL_0f36:
	{
		float L_695;
		L_695 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B288_0 = L_695;
		G_B288_1 = G_B287_0;
	}

IL_0f3b:
	{
		G_B288_1->___single_2_62 = G_B288_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_696 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_697 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_696.___register_0;
		float L_698 = (float)L_697.___single_3_63;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_699 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_700 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_699.___register_0;
		float L_701 = (float)L_700.___single_3_63;
		G_B289_0 = (&V_20);
		if ((((float)L_698) == ((float)L_701)))
		{
			G_B290_0 = (&V_20);
			goto IL_0f61;
		}
	}
	{
		G_B291_0 = (0.0f);
		G_B291_1 = G_B289_0;
		goto IL_0f66;
	}

IL_0f61:
	{
		float L_702;
		L_702 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		G_B291_0 = L_702;
		G_B291_1 = G_B290_0;
	}

IL_0f66:
	{
		G_B291_1->___single_3_63 = G_B291_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_703;
		memset((&L_703), 0, sizeof(L_703));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_703), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_703;
	}

IL_0f73:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_704 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_705;
		L_705 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_704, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_706 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_707;
		L_707 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_706, NULL);
		bool L_708;
		L_708 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_705, L_707, NULL);
		if (!L_708)
		{
			goto IL_0ff4;
		}
	}
	{
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_709 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_710 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_709.___register_0;
		double L_711 = (double)L_710.___double_0_64;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_712 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_713 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_712.___register_0;
		double L_714 = (double)L_713.___double_0_64;
		G_B294_0 = (&V_20);
		if ((((double)L_711) == ((double)L_714)))
		{
			G_B295_0 = (&V_20);
			goto IL_0fb3;
		}
	}
	{
		G_B296_0 = (0.0);
		G_B296_1 = G_B294_0;
		goto IL_0fb8;
	}

IL_0fb3:
	{
		double L_715;
		L_715 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		G_B296_0 = L_715;
		G_B296_1 = G_B295_0;
	}

IL_0fb8:
	{
		G_B296_1->___double_0_64 = G_B296_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_716 = ___left0;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_717 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_716.___register_0;
		double L_718 = (double)L_717.___double_1_65;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_719 = ___right1;
		Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A L_720 = (Register_t483055A1DB8634BA3FBF01BB15D4E94E186A2E7A)L_719.___register_0;
		double L_721 = (double)L_720.___double_1_65;
		G_B297_0 = (&V_20);
		if ((((double)L_718) == ((double)L_721)))
		{
			G_B298_0 = (&V_20);
			goto IL_0fe2;
		}
	}
	{
		G_B299_0 = (0.0);
		G_B299_1 = G_B297_0;
		goto IL_0fe7;
	}

IL_0fe2:
	{
		double L_722;
		L_722 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		G_B299_0 = L_722;
		G_B299_1 = G_B298_0;
	}

IL_0fe7:
	{
		G_B299_1->___double_1_65 = G_B299_0;
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_723;
		memset((&L_723), 0, sizeof(L_723));
		Vector_1__ctor_mF674294C34FEB07FB44E694358BDA181F564B674((&L_723), (&V_20), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		return L_723;
	}

IL_0ff4:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_724 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_724);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_724, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_724, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_Equals_mC3493AA0A6333EAD0360159344FE71330AB7BB8B_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Vector_1_ScalarEquals_mFF6DBE46F1E8F7B060FBFB3F1C003C55494F4EA8_gshared (Il2CppFullySharedGenericStruct ___left0, Il2CppFullySharedGenericStruct ___right1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	const Il2CppFullySharedGenericStruct L_5 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_14 = L_5;
	const Il2CppFullySharedGenericStruct L_23 = L_5;
	const Il2CppFullySharedGenericStruct L_32 = L_5;
	const Il2CppFullySharedGenericStruct L_41 = L_5;
	const Il2CppFullySharedGenericStruct L_50 = L_5;
	const Il2CppFullySharedGenericStruct L_59 = L_5;
	const Il2CppFullySharedGenericStruct L_68 = L_5;
	const Il2CppFullySharedGenericStruct L_77 = L_5;
	const Il2CppFullySharedGenericStruct L_86 = L_5;
	const Il2CppFullySharedGenericStruct L_7 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_16 = L_7;
	const Il2CppFullySharedGenericStruct L_25 = L_7;
	const Il2CppFullySharedGenericStruct L_34 = L_7;
	const Il2CppFullySharedGenericStruct L_43 = L_7;
	const Il2CppFullySharedGenericStruct L_52 = L_7;
	const Il2CppFullySharedGenericStruct L_61 = L_7;
	const Il2CppFullySharedGenericStruct L_70 = L_7;
	const Il2CppFullySharedGenericStruct L_79 = L_7;
	const Il2CppFullySharedGenericStruct L_88 = L_7;
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0034;
		}
	}
	{
		il2cpp_codegen_memcpy(L_5, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_5);
		il2cpp_codegen_memcpy(L_7, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_8 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_7);
		return (bool)((((int32_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_6, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_8, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0034:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_9 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_10;
		L_10 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_9, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_11 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_12;
		L_12 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_11, NULL);
		bool L_13;
		L_13 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_10, L_12, NULL);
		if (!L_13)
		{
			goto IL_0068;
		}
	}
	{
		il2cpp_codegen_memcpy(L_14, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_15 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_14);
		il2cpp_codegen_memcpy(L_16, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_17 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_16);
		return (bool)((((int32_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_15, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_17, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0068:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_18 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_19;
		L_19 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_18, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_20 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_21;
		L_21 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_20, NULL);
		bool L_22;
		L_22 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_19, L_21, NULL);
		if (!L_22)
		{
			goto IL_009c;
		}
	}
	{
		il2cpp_codegen_memcpy(L_23, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_24 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_23);
		il2cpp_codegen_memcpy(L_25, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_26 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_25);
		return (bool)((((int32_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_24, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_26, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_009c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_27 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_28;
		L_28 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_27, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_29 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_30;
		L_30 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_29, NULL);
		bool L_31;
		L_31 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_28, L_30, NULL);
		if (!L_31)
		{
			goto IL_00d0;
		}
	}
	{
		il2cpp_codegen_memcpy(L_32, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_33 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_32);
		il2cpp_codegen_memcpy(L_34, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_35 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_34);
		return (bool)((((int32_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_33, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_35, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_00d0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_36 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_37;
		L_37 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_36, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_38 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_39;
		L_39 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_38, NULL);
		bool L_40;
		L_40 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_37, L_39, NULL);
		if (!L_40)
		{
			goto IL_0104;
		}
	}
	{
		il2cpp_codegen_memcpy(L_41, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_42 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_41);
		il2cpp_codegen_memcpy(L_43, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_44 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_43);
		return (bool)((((int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_42, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_44, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0104:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_45 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_46;
		L_46 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_45, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_47 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_48;
		L_48 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_47, NULL);
		bool L_49;
		L_49 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_46, L_48, NULL);
		if (!L_49)
		{
			goto IL_0138;
		}
	}
	{
		il2cpp_codegen_memcpy(L_50, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_51 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_50);
		il2cpp_codegen_memcpy(L_52, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_53 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_52);
		return (bool)((((int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_51, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_53, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0138:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_54 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_55;
		L_55 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_54, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		bool L_58;
		L_58 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_55, L_57, NULL);
		if (!L_58)
		{
			goto IL_016c;
		}
	}
	{
		il2cpp_codegen_memcpy(L_59, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_60 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_59);
		il2cpp_codegen_memcpy(L_61, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_62 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_61);
		return (bool)((((int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_60, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))))) == ((int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_62, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_016c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_65 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_66;
		L_66 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_65, NULL);
		bool L_67;
		L_67 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_64, L_66, NULL);
		if (!L_67)
		{
			goto IL_01a0;
		}
	}
	{
		il2cpp_codegen_memcpy(L_68, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_69 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_68);
		il2cpp_codegen_memcpy(L_70, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_71 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_70);
		return (bool)((((int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_69, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))))) == ((int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_71, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_01a0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_72 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_73;
		L_73 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_72, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_74 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_75;
		L_75 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_74, NULL);
		bool L_76;
		L_76 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_73, L_75, NULL);
		if (!L_76)
		{
			goto IL_01d4;
		}
	}
	{
		il2cpp_codegen_memcpy(L_77, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_78 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_77);
		il2cpp_codegen_memcpy(L_79, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_80 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_79);
		return (bool)((((float)((*(float*)((float*)(float*)UnBox(L_78, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))))) == ((float)((*(float*)((float*)(float*)UnBox(L_80, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_01d4:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_81 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_82;
		L_82 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_81, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_83 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_84;
		L_84 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_83, NULL);
		bool L_85;
		L_85 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_82, L_84, NULL);
		if (!L_85)
		{
			goto IL_0208;
		}
	}
	{
		il2cpp_codegen_memcpy(L_86, ___left0, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_87 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_86);
		il2cpp_codegen_memcpy(L_88, ___right1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		RuntimeObject* L_89 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), L_88);
		return (bool)((((double)((*(double*)((double*)(double*)UnBox(L_87, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))))) == ((double)((*(double*)((double*)(double*)UnBox(L_89, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0208:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_90 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_90);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_90, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_90, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_ScalarEquals_mFF6DBE46F1E8F7B060FBFB3F1C003C55494F4EA8_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1_GetOneValue_m5547048AF495EEF927EF7BD8647DAAD6D237CB3A_gshared (Il2CppFullySharedGenericStruct* il2cppRetVal, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0027;
		}
	}
	{
		uint8_t L_5 = ((uint8_t)1);
		RuntimeObject* L_6 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_5);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_6, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0027:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_7 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_8;
		L_8 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_7, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_9 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_10;
		L_10 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_9, NULL);
		bool L_11;
		L_11 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_8, L_10, NULL);
		if (!L_11)
		{
			goto IL_004e;
		}
	}
	{
		int8_t L_12 = ((int8_t)1);
		RuntimeObject* L_13 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_12);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_13, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_004e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_14 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_15;
		L_15 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_14, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		bool L_18;
		L_18 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_15, L_17, NULL);
		if (!L_18)
		{
			goto IL_0075;
		}
	}
	{
		uint16_t L_19 = ((uint16_t)1);
		RuntimeObject* L_20 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_19);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_20, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0075:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_21 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_22;
		L_22 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_21, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_23 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_24;
		L_24 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_23, NULL);
		bool L_25;
		L_25 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_22, L_24, NULL);
		if (!L_25)
		{
			goto IL_009c;
		}
	}
	{
		int16_t L_26 = ((int16_t)1);
		RuntimeObject* L_27 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_26);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_27, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_009c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_28 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_29;
		L_29 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_28, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_30, NULL);
		bool L_32;
		L_32 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_29, L_31, NULL);
		if (!L_32)
		{
			goto IL_00c3;
		}
	}
	{
		uint32_t L_33 = ((uint32_t)1);
		RuntimeObject* L_34 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_33);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_34, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_00c3:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_37 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_38;
		L_38 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_37, NULL);
		bool L_39;
		L_39 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_36, L_38, NULL);
		if (!L_39)
		{
			goto IL_00ea;
		}
	}
	{
		int32_t L_40 = 1;
		RuntimeObject* L_41 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_40);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_41, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_00ea:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_44, NULL);
		bool L_46;
		L_46 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_43, L_45, NULL);
		if (!L_46)
		{
			goto IL_0112;
		}
	}
	{
		uint64_t L_47 = ((uint64_t)((int64_t)1));
		RuntimeObject* L_48 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_47);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_48, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0112:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_49 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_50;
		L_50 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_49, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_51 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_52;
		L_52 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_51, NULL);
		bool L_53;
		L_53 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_50, L_52, NULL);
		if (!L_53)
		{
			goto IL_013a;
		}
	}
	{
		int64_t L_54 = ((int64_t)1);
		RuntimeObject* L_55 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_54);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_013a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0165;
		}
	}
	{
		float L_61 = (1.0f);
		RuntimeObject* L_62 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_61);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_62, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0165:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_65 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_66;
		L_66 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_65, NULL);
		bool L_67;
		L_67 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_64, L_66, NULL);
		if (!L_67)
		{
			goto IL_0194;
		}
	}
	{
		double L_68 = (1.0);
		RuntimeObject* L_69 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_68);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_69, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0194:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_70 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_70);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_70, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_70, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetOneValue_m5547048AF495EEF927EF7BD8647DAAD6D237CB3A_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1_GetAllBitsSetValue_m5AEB1D20298C13CBD8F8A67B7FBE15ECF8DFCB1E_gshared (Il2CppFullySharedGenericStruct* il2cppRetVal, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_002b;
		}
	}
	{
		uint8_t L_5;
		L_5 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		uint8_t L_6 = L_5;
		RuntimeObject* L_7 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_6);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_7, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_002b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_8 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_9;
		L_9 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_8, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		bool L_12;
		L_12 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_9, L_11, NULL);
		if (!L_12)
		{
			goto IL_0056;
		}
	}
	{
		int8_t L_13;
		L_13 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		int8_t L_14 = L_13;
		RuntimeObject* L_15 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_14);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_15, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0056:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_18 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_19;
		L_19 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_18, NULL);
		bool L_20;
		L_20 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_17, L_19, NULL);
		if (!L_20)
		{
			goto IL_0081;
		}
	}
	{
		uint16_t L_21;
		L_21 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		uint16_t L_22 = L_21;
		RuntimeObject* L_23 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_22);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_23, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0081:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_24 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_25;
		L_25 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_24, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_26 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_27;
		L_27 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_26, NULL);
		bool L_28;
		L_28 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_25, L_27, NULL);
		if (!L_28)
		{
			goto IL_00ac;
		}
	}
	{
		int16_t L_29;
		L_29 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		int16_t L_30 = L_29;
		RuntimeObject* L_31 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_30);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_31, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_00ac:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_32, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_34 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_35;
		L_35 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_34, NULL);
		bool L_36;
		L_36 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_33, L_35, NULL);
		if (!L_36)
		{
			goto IL_00d7;
		}
	}
	{
		uint32_t L_37;
		L_37 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		uint32_t L_38 = L_37;
		RuntimeObject* L_39 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_38);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_39, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_00d7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_40 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_41;
		L_41 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_40, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		bool L_44;
		L_44 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_41, L_43, NULL);
		if (!L_44)
		{
			goto IL_0102;
		}
	}
	{
		int32_t L_45;
		L_45 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		int32_t L_46 = L_45;
		RuntimeObject* L_47 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_46);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_47, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0102:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_48 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_49;
		L_49 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_48, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_50 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_51;
		L_51 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_50, NULL);
		bool L_52;
		L_52 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_49, L_51, NULL);
		if (!L_52)
		{
			goto IL_012d;
		}
	}
	{
		uint64_t L_53;
		L_53 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		uint64_t L_54 = L_53;
		RuntimeObject* L_55 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_54);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_012d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0158;
		}
	}
	{
		int64_t L_61;
		L_61 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		int64_t L_62 = L_61;
		RuntimeObject* L_63 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_62);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_63, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0158:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_64 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_65;
		L_65 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_64, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_66 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_67;
		L_67 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_66, NULL);
		bool L_68;
		L_68 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_65, L_67, NULL);
		if (!L_68)
		{
			goto IL_0183;
		}
	}
	{
		float L_69;
		L_69 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		float L_70 = L_69;
		RuntimeObject* L_71 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_70);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_71, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_0183:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_72 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_73;
		L_73 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_72, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_74 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_75;
		L_75 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_74, NULL);
		bool L_76;
		L_76 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_73, L_75, NULL);
		if (!L_76)
		{
			goto IL_01ae;
		}
	}
	{
		double L_77;
		L_77 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		double L_78 = L_77;
		RuntimeObject* L_79 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_78);
		il2cpp_codegen_memcpy(il2cppRetVal, (((Il2CppFullySharedGenericStruct)((Il2CppFullySharedGenericStruct)(Il2CppFullySharedGenericStruct*)UnBox(L_79, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4))))), SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
		return;
	}

IL_01ae:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_80 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_80);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_80, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_80, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetAllBitsSetValue_m5AEB1D20298C13CBD8F8A67B7FBE15ECF8DFCB1E_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Vector_1__cctor_m5FA2EE007E9D5AEF461B7A4B4FEB7989282753A8_gshared (const RuntimeMethod* method) 
{
	const uint32_t SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	const Il2CppFullySharedGenericStruct L_1 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_2 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_4 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	const Il2CppFullySharedGenericStruct L_5 = alloca(SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE);
	{
		int32_t L_0;
		L_0 = ((  int32_t (*) (const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 14)))(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 14));
		((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_count_1 = L_0;
		il2cpp_codegen_initobj((&((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_zero_2), sizeof(Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2));
		InvokerActionInvoker1< Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15), NULL, (Il2CppFullySharedGenericStruct*)L_1);
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_3;
		memset((&L_3), 0, sizeof(L_3));
		Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2((&L_3), il2cpp_codegen_memcpy(L_2, L_1, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_one_3 = L_3;
		InvokerActionInvoker1< Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17), NULL, (Il2CppFullySharedGenericStruct*)L_4);
		Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector_1__ctor_m7540979061ABB2A0A6D57213359B3E83A1B7B4D2((&L_6), il2cpp_codegen_memcpy(L_5, L_4, SizeOf_T_t7D67093BB2FFD728051D825E6ED6B46C110A9BAE), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_allOnes_4 = L_6;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Double_GetHashCode_m3761FC05AD24D97A68FA1E8412A9454DF3880E32_inline (double* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int64_t V_0 = 0;
	{
		double L_0 = *((double*)__this);
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int64_t L_1;
		L_1 = BitConverter_DoubleToInt64Bits_m45D911F884F3B09BF39C02044EDC9BDA8084C80B_inline(L_0, NULL);
		V_0 = L_1;
		int64_t L_2 = V_0;
		if ((((int64_t)((int64_t)(((int64_t)il2cpp_codegen_subtract(L_2, ((int64_t)1)))&((int64_t)(std::numeric_limits<int64_t>::max)())))) < ((int64_t)((int64_t)9218868437227405312LL))))
		{
			goto IL_002d;
		}
	}
	{
		int64_t L_3 = V_0;
		V_0 = ((int64_t)(L_3&((int64_t)9218868437227405312LL)));
	}

IL_002d:
	{
		int64_t L_4 = V_0;
		int64_t L_5 = V_0;
		return ((int32_t)(((int32_t)L_4)^((int32_t)((int64_t)(L_5>>((int32_t)32))))));
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* NumberFormatInfo_get_NumberGroupSeparator_m0556B092AA471513B1EDC31C047712226D39BEB6_inline (NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___numberGroupSeparator_7;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint8_t ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline (const RuntimeMethod* method) 
{
	uint8_t V_0 = 0x0;
	{
		V_0 = (uint8_t)0;
		*((int8_t*)((uintptr_t)(&V_0))) = (int8_t)((int32_t)255);
		uint8_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int8_t ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline (const RuntimeMethod* method) 
{
	int8_t V_0 = 0x0;
	{
		V_0 = (int8_t)0;
		*((int8_t*)((uintptr_t)(&V_0))) = (int8_t)(-1);
		int8_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint16_t ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline (const RuntimeMethod* method) 
{
	uint16_t V_0 = 0;
	{
		V_0 = (uint16_t)0;
		*((int16_t*)((uintptr_t)(&V_0))) = (int16_t)((int32_t)65535);
		uint16_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int16_t ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline (const RuntimeMethod* method) 
{
	int16_t V_0 = 0;
	{
		V_0 = (int16_t)0;
		*((int16_t*)((uintptr_t)(&V_0))) = (int16_t)(-1);
		int16_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline (const RuntimeMethod* method) 
{
	uint32_t V_0 = 0;
	{
		V_0 = 0;
		*((int32_t*)((uintptr_t)(&V_0))) = (int32_t)(-1);
		uint32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline (const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 0;
		*((int32_t*)((uintptr_t)(&V_0))) = (int32_t)(-1);
		int32_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline (const RuntimeMethod* method) 
{
	uint64_t V_0 = 0;
	{
		V_0 = ((int64_t)0);
		*((int64_t*)((uintptr_t)(&V_0))) = (int64_t)((int64_t)(-1));
		uint64_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline (const RuntimeMethod* method) 
{
	int64_t V_0 = 0;
	{
		V_0 = ((int64_t)0);
		*((int64_t*)((uintptr_t)(&V_0))) = (int64_t)((int64_t)(-1));
		int64_t L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline (const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		V_0 = (0.0f);
		*((int32_t*)((uintptr_t)(&V_0))) = (int32_t)(-1);
		float L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR double ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline (const RuntimeMethod* method) 
{
	double V_0 = 0.0;
	{
		V_0 = (0.0);
		*((int64_t*)((uintptr_t)(&V_0))) = (int64_t)((int64_t)(-1));
		double L_0 = V_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Vector_1_get_Count_m80E6CC2AD986BAE1FDB0AF69E8BDEF6C3769FFF0_gshared_inline (const RuntimeMethod* method) 
{
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_0 = ((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___s_count_1;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_Equals_mE275DCDE4DC3B6FB30AB80ACEAC8363207BA9BEC_gshared_inline (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = ___obj0;
		if (((RuntimeObject*)IsInstSealed((RuntimeObject*)L_0, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		RuntimeObject* L_1 = ___obj0;
		bool L_2;
		L_2 = Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27(__this, ((*(Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*)((Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*)(Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A*)UnBox(L_1, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7));
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_gshared_inline (uint64_t ___left0, uint64_t ___right1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0034;
		}
	}
	{
		uint64_t L_5 = ___left0;
		uint64_t L_6 = L_5;
		RuntimeObject* L_7 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_6);
		uint64_t L_8 = ___right1;
		uint64_t L_9 = L_8;
		RuntimeObject* L_10 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_9);
		return (bool)((((int32_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_7, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint8_t*)((uint8_t*)(uint8_t*)UnBox(L_10, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0034:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_11 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_12;
		L_12 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_11, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_13 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_14;
		L_14 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_13, NULL);
		bool L_15;
		L_15 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_12, L_14, NULL);
		if (!L_15)
		{
			goto IL_0068;
		}
	}
	{
		uint64_t L_16 = ___left0;
		uint64_t L_17 = L_16;
		RuntimeObject* L_18 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_17);
		uint64_t L_19 = ___right1;
		uint64_t L_20 = L_19;
		RuntimeObject* L_21 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_20);
		return (bool)((((int32_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_18, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int8_t*)((int8_t*)(int8_t*)UnBox(L_21, SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0068:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_22 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_23;
		L_23 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_22, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_24 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_25;
		L_25 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_24, NULL);
		bool L_26;
		L_26 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_23, L_25, NULL);
		if (!L_26)
		{
			goto IL_009c;
		}
	}
	{
		uint64_t L_27 = ___left0;
		uint64_t L_28 = L_27;
		RuntimeObject* L_29 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_28);
		uint64_t L_30 = ___right1;
		uint64_t L_31 = L_30;
		RuntimeObject* L_32 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_31);
		return (bool)((((int32_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_29, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint16_t*)((uint16_t*)(uint16_t*)UnBox(L_32, UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_009c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_33 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_34;
		L_34 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_33, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		bool L_37;
		L_37 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_34, L_36, NULL);
		if (!L_37)
		{
			goto IL_00d0;
		}
	}
	{
		uint64_t L_38 = ___left0;
		uint64_t L_39 = L_38;
		RuntimeObject* L_40 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_39);
		uint64_t L_41 = ___right1;
		uint64_t L_42 = L_41;
		RuntimeObject* L_43 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_42);
		return (bool)((((int32_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_40, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_43, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_00d0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_44, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_46 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_47;
		L_47 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_46, NULL);
		bool L_48;
		L_48 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_45, L_47, NULL);
		if (!L_48)
		{
			goto IL_0104;
		}
	}
	{
		uint64_t L_49 = ___left0;
		uint64_t L_50 = L_49;
		RuntimeObject* L_51 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_50);
		uint64_t L_52 = ___right1;
		uint64_t L_53 = L_52;
		RuntimeObject* L_54 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_53);
		return (bool)((((int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_51, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))))) == ((int32_t)((*(uint32_t*)((uint32_t*)(uint32_t*)UnBox(L_54, UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0104:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_55 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_56;
		L_56 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_55, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_57 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_58;
		L_58 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_57, NULL);
		bool L_59;
		L_59 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_56, L_58, NULL);
		if (!L_59)
		{
			goto IL_0138;
		}
	}
	{
		uint64_t L_60 = ___left0;
		uint64_t L_61 = L_60;
		RuntimeObject* L_62 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_61);
		uint64_t L_63 = ___right1;
		uint64_t L_64 = L_63;
		RuntimeObject* L_65 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_64);
		return (bool)((((int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_62, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))))) == ((int32_t)((*(int32_t*)((int32_t*)(int32_t*)UnBox(L_65, Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0138:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_66 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_67;
		L_67 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_66, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_68 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_69;
		L_69 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_68, NULL);
		bool L_70;
		L_70 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_67, L_69, NULL);
		if (!L_70)
		{
			goto IL_016c;
		}
	}
	{
		uint64_t L_71 = ___left0;
		uint64_t L_72 = L_71;
		RuntimeObject* L_73 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_72);
		uint64_t L_74 = ___right1;
		uint64_t L_75 = L_74;
		RuntimeObject* L_76 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_75);
		return (bool)((((int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_73, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))))) == ((int64_t)((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_76, UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_016c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_77 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_78;
		L_78 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_77, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_79 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_80;
		L_80 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_79, NULL);
		bool L_81;
		L_81 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_78, L_80, NULL);
		if (!L_81)
		{
			goto IL_01a0;
		}
	}
	{
		uint64_t L_82 = ___left0;
		uint64_t L_83 = L_82;
		RuntimeObject* L_84 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_83);
		uint64_t L_85 = ___right1;
		uint64_t L_86 = L_85;
		RuntimeObject* L_87 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_86);
		return (bool)((((int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_84, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))))) == ((int64_t)((*(int64_t*)((int64_t*)(int64_t*)UnBox(L_87, Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_01a0:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_88 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_89;
		L_89 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_88, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_90 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_91;
		L_91 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_90, NULL);
		bool L_92;
		L_92 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_89, L_91, NULL);
		if (!L_92)
		{
			goto IL_01d4;
		}
	}
	{
		uint64_t L_93 = ___left0;
		uint64_t L_94 = L_93;
		RuntimeObject* L_95 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_94);
		uint64_t L_96 = ___right1;
		uint64_t L_97 = L_96;
		RuntimeObject* L_98 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_97);
		return (bool)((((float)((*(float*)((float*)(float*)UnBox(L_95, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))))) == ((float)((*(float*)((float*)(float*)UnBox(L_98, Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_01d4:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_99 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_100;
		L_100 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_99, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_101 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_102;
		L_102 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_101, NULL);
		bool L_103;
		L_103 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_100, L_102, NULL);
		if (!L_103)
		{
			goto IL_0208;
		}
	}
	{
		uint64_t L_104 = ___left0;
		uint64_t L_105 = L_104;
		RuntimeObject* L_106 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_105);
		uint64_t L_107 = ___right1;
		uint64_t L_108 = L_107;
		RuntimeObject* L_109 = Box(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 4), &L_108);
		return (bool)((((double)((*(double*)((double*)(double*)UnBox(L_106, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))))) == ((double)((*(double*)((double*)(double*)UnBox(L_109, Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var))))))? 1 : 0);
	}

IL_0208:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_110 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_110);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_110, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_110, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_ScalarEquals_m039256C94AA6A2A4629636A42356AEEBE47E484D_RuntimeMethod_var)));
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_op_Equality_m50B11C67F1AC4D10224413FBF3AC098A8037A021_gshared_inline (Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___left0, Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A ___right1, const RuntimeMethod* method) 
{
	{
		Vector_1_t566D05A9DE75BCD8F12F1E09AC3F8A4BC01BF92A L_0 = ___right1;
		bool L_1;
		L_1 = Vector_1_Equals_mAE01D42B31EB54893DC4DB1BE8A99216AF784C27((&___left0), L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7));
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_gshared_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_0027;
		}
	}
	{
		uint8_t L_5 = ((uint8_t)1);
		RuntimeObject* L_6 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_5);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_6, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0027:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_7 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_8;
		L_8 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_7, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_9 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_10;
		L_10 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_9, NULL);
		bool L_11;
		L_11 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_8, L_10, NULL);
		if (!L_11)
		{
			goto IL_004e;
		}
	}
	{
		int8_t L_12 = ((int8_t)1);
		RuntimeObject* L_13 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_12);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_13, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_004e:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_14 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_15;
		L_15 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_14, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		bool L_18;
		L_18 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_15, L_17, NULL);
		if (!L_18)
		{
			goto IL_0075;
		}
	}
	{
		uint16_t L_19 = ((uint16_t)1);
		RuntimeObject* L_20 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_19);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_20, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0075:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_21 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_22;
		L_22 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_21, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_23 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_24;
		L_24 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_23, NULL);
		bool L_25;
		L_25 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_22, L_24, NULL);
		if (!L_25)
		{
			goto IL_009c;
		}
	}
	{
		int16_t L_26 = ((int16_t)1);
		RuntimeObject* L_27 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_26);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_27, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_009c:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_28 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_29;
		L_29 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_28, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_30, NULL);
		bool L_32;
		L_32 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_29, L_31, NULL);
		if (!L_32)
		{
			goto IL_00c3;
		}
	}
	{
		uint32_t L_33 = ((uint32_t)1);
		RuntimeObject* L_34 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_33);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_34, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00c3:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_35, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_37 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_38;
		L_38 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_37, NULL);
		bool L_39;
		L_39 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_36, L_38, NULL);
		if (!L_39)
		{
			goto IL_00ea;
		}
	}
	{
		int32_t L_40 = 1;
		RuntimeObject* L_41 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_40);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_41, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00ea:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_44, NULL);
		bool L_46;
		L_46 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_43, L_45, NULL);
		if (!L_46)
		{
			goto IL_0112;
		}
	}
	{
		uint64_t L_47 = ((uint64_t)((int64_t)1));
		RuntimeObject* L_48 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_47);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_48, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0112:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_49 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_50;
		L_50 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_49, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_51 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_52;
		L_52 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_51, NULL);
		bool L_53;
		L_53 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_50, L_52, NULL);
		if (!L_53)
		{
			goto IL_013a;
		}
	}
	{
		int64_t L_54 = ((int64_t)1);
		RuntimeObject* L_55 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_54);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_013a:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0165;
		}
	}
	{
		float L_61 = (1.0f);
		RuntimeObject* L_62 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_61);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_62, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0165:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_63 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_64;
		L_64 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_63, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_65 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_66;
		L_66 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_65, NULL);
		bool L_67;
		L_67 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_64, L_66, NULL);
		if (!L_67)
		{
			goto IL_0194;
		}
	}
	{
		double L_68 = (1.0);
		RuntimeObject* L_69 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_68);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_69, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0194:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_70 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_70);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_70, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_70, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetOneValue_m89F688B2AEB127BC73E1DBB2A2AF502A22A999CC_RuntimeMethod_var)));
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_gshared_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_0 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_1;
		L_1 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_0, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_2 = { reinterpret_cast<intptr_t> (Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_0_0_0_var) };
		Type_t* L_3;
		L_3 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_2, NULL);
		bool L_4;
		L_4 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_1, L_3, NULL);
		if (!L_4)
		{
			goto IL_002b;
		}
	}
	{
		uint8_t L_5;
		L_5 = ConstantHelper_GetByteWithAllBitsSet_m70D8ABFDDD72F3AA7A6198F10E73B6E9F4C8DDEF_inline(NULL);
		uint8_t L_6 = L_5;
		RuntimeObject* L_7 = Box(Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, &L_6);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_7, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_002b:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_8 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_9;
		L_9 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_8, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_0_0_0_var) };
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_10, NULL);
		bool L_12;
		L_12 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_9, L_11, NULL);
		if (!L_12)
		{
			goto IL_0056;
		}
	}
	{
		int8_t L_13;
		L_13 = ConstantHelper_GetSByteWithAllBitsSet_mEE5AC59F6A7595601D60D765A24CC16D7CEFFE4F_inline(NULL);
		int8_t L_14 = L_13;
		RuntimeObject* L_15 = Box(SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_il2cpp_TypeInfo_var, &L_14);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_15, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0056:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_16 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_17;
		L_17 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_16, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_18 = { reinterpret_cast<intptr_t> (UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_0_0_0_var) };
		Type_t* L_19;
		L_19 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_18, NULL);
		bool L_20;
		L_20 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_17, L_19, NULL);
		if (!L_20)
		{
			goto IL_0081;
		}
	}
	{
		uint16_t L_21;
		L_21 = ConstantHelper_GetUInt16WithAllBitsSet_mAD6E0218F9138800A07FFE0142ED7C131BB9F93E_inline(NULL);
		uint16_t L_22 = L_21;
		RuntimeObject* L_23 = Box(UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_il2cpp_TypeInfo_var, &L_22);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_23, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0081:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_24 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_25;
		L_25 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_24, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_26 = { reinterpret_cast<intptr_t> (Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_0_0_0_var) };
		Type_t* L_27;
		L_27 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_26, NULL);
		bool L_28;
		L_28 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_25, L_27, NULL);
		if (!L_28)
		{
			goto IL_00ac;
		}
	}
	{
		int16_t L_29;
		L_29 = ConstantHelper_GetInt16WithAllBitsSet_mD5F3B243E4443ABAF26AC69325D87B11AEDFB648_inline(NULL);
		int16_t L_30 = L_29;
		RuntimeObject* L_31 = Box(Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var, &L_30);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_31, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00ac:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_32, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_34 = { reinterpret_cast<intptr_t> (UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_0_0_0_var) };
		Type_t* L_35;
		L_35 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_34, NULL);
		bool L_36;
		L_36 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_33, L_35, NULL);
		if (!L_36)
		{
			goto IL_00d7;
		}
	}
	{
		uint32_t L_37;
		L_37 = ConstantHelper_GetUInt32WithAllBitsSet_m511F3C30BF971F878BE62A540619D00438D5D53A_inline(NULL);
		uint32_t L_38 = L_37;
		RuntimeObject* L_39 = Box(UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var, &L_38);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_39, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_00d7:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_40 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_41;
		L_41 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_40, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_0_0_0_var) };
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_42, NULL);
		bool L_44;
		L_44 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_41, L_43, NULL);
		if (!L_44)
		{
			goto IL_0102;
		}
	}
	{
		int32_t L_45;
		L_45 = ConstantHelper_GetInt32WithAllBitsSet_mEF193B6D48097FE76AC293AC1564C431C17EA75B_inline(NULL);
		int32_t L_46 = L_45;
		RuntimeObject* L_47 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_46);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_47, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0102:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_48 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_49;
		L_49 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_48, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_50 = { reinterpret_cast<intptr_t> (UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_0_0_0_var) };
		Type_t* L_51;
		L_51 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_50, NULL);
		bool L_52;
		L_52 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_49, L_51, NULL);
		if (!L_52)
		{
			goto IL_012d;
		}
	}
	{
		uint64_t L_53;
		L_53 = ConstantHelper_GetUInt64WithAllBitsSet_m19EE22B59FBC1306C17BF918D04127CF8633BA7F_inline(NULL);
		uint64_t L_54 = L_53;
		RuntimeObject* L_55 = Box(UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_il2cpp_TypeInfo_var, &L_54);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_55, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_012d:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_56 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_57;
		L_57 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_56, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_58 = { reinterpret_cast<intptr_t> (Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_0_0_0_var) };
		Type_t* L_59;
		L_59 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_58, NULL);
		bool L_60;
		L_60 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_57, L_59, NULL);
		if (!L_60)
		{
			goto IL_0158;
		}
	}
	{
		int64_t L_61;
		L_61 = ConstantHelper_GetInt64WithAllBitsSet_mB3A93617AB846E5DF8AA793DE7D2A8DABF1274C2_inline(NULL);
		int64_t L_62 = L_61;
		RuntimeObject* L_63 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_62);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_63, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0158:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_64 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_65;
		L_65 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_64, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_66 = { reinterpret_cast<intptr_t> (Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_0_0_0_var) };
		Type_t* L_67;
		L_67 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_66, NULL);
		bool L_68;
		L_68 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_65, L_67, NULL);
		if (!L_68)
		{
			goto IL_0183;
		}
	}
	{
		float L_69;
		L_69 = ConstantHelper_GetSingleWithAllBitsSet_m4659346E590601F8DD80D0EC56224D21FEAE7E92_inline(NULL);
		float L_70 = L_69;
		RuntimeObject* L_71 = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &L_70);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_71, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_0183:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_72 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(InitializedTypeInfo(method->klass)->rgctx_data, 3)) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_73;
		L_73 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_72, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_74 = { reinterpret_cast<intptr_t> (Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_0_0_0_var) };
		Type_t* L_75;
		L_75 = Type_GetTypeFromHandle_m2570A2A5B32A5E9D9F0F38B37459DA18736C823E(L_74, NULL);
		bool L_76;
		L_76 = Type_op_Equality_mE6EDDDC900C50B222CF32BCD2AD027595F2D74B7(L_73, L_75, NULL);
		if (!L_76)
		{
			goto IL_01ae;
		}
	}
	{
		double L_77;
		L_77 = ConstantHelper_GetDoubleWithAllBitsSet_m638AC5F89A02C0A256C2B44808AD43D1842DE072_inline(NULL);
		double L_78 = L_77;
		RuntimeObject* L_79 = Box(Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_il2cpp_TypeInfo_var, &L_78);
		return ((*(uint64_t*)((uint64_t*)(uint64_t*)UnBox(L_79, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 4)))));
	}

IL_01ae:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_80 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_80);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_80, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE310274B02A605A3985345944A620D7D2E019A1A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_80, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Vector_1_GetAllBitsSetValue_mE22D12E231A99D7F612763B01936D5F2C88C7023_RuntimeMethod_var)));
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Vector_1_Equals_m1D6500596F9B825F39D474A32D7A6D5E14E22B8F_gshared_inline (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2* __this, RuntimeObject* ___obj0, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = ___obj0;
		if (((RuntimeObject*)IsInstSealed((RuntimeObject*)L_0, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		RuntimeObject* L_1 = ___obj0;
		bool L_2;
		L_2 = ((  bool (*) (Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*, Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7)))(__this, ((*(Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)((Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)(Vector_1_t4FB40153F5AFF7BFDFB20E1BCB98343E42252AD2*)UnBox(L_1, il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0))))), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 7));
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t BitConverter_DoubleToInt64Bits_m45D911F884F3B09BF39C02044EDC9BDA8084C80B_inline (double ___value0, const RuntimeMethod* method) 
{
	{
		int64_t L_0 = *((int64_t*)((uintptr_t)(&___value0)));
		return L_0;
	}
}
