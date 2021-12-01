using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BoatAttack
{
    public class Console : MonoBehaviour
    {
        public GameObject consoleObject;
        public TMP_InputField inputField;

        public InputAction consoleOpen;

        private Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();
        private Dictionary<string, ParameterInfo[]> methodParams = new Dictionary<string, ParameterInfo[]>();

        private void Awake()
        {
            consoleOpen.performed += ConsoleOnPerformed;
            var meths = GetMethodsWith<ConsoleCmd>();
            foreach (var meth in meths)
            {
                methods.Add(meth.Name, meth);
                methodParams.Add(meth.Name, meth.GetParameters());
            }
        }

        private void OnEnable()
        {
            consoleOpen.Enable();
            inputField.onEndEdit.AddListener(Call);
        }

        private void Call(string arg0)
        {
            var vars = arg0.Split(' ');
            var methodName = vars[0];

            if (!methods.ContainsKey(methodName)) return;
            var method = methods[methodName];
            if (!method.IsStatic) return;

            var paramInfos = methodParams[methodName];
            var m_params = new object[paramInfos.Length];
            for (var i = 0; i < paramInfos.Length; i++)
            {
                var paramInfo = paramInfos[i];
                if(paramInfo.HasDefaultValue && vars.Length - 1 <= i) continue; //skip optional vars if not present
                var paramStr = vars[i + 1];

                if (paramInfo.ParameterType == typeof(int))
                {
                    m_params[i] = int.Parse(paramStr);
                }
                else if (paramInfo.ParameterType == typeof(float))
                {
                    m_params[i] = float.Parse(paramStr);
                }
                else if (paramInfo.ParameterType == typeof(string))
                {
                    m_params[i] = paramStr;
                }
            }

            try
            {
                method.Invoke(this, m_params);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }

            inputField.SetTextWithoutNotify("");
            inputField.ActivateInputField();
        }

        public void OnDisable()
        {
            consoleOpen.Disable();
            inputField.DeactivateInputField();
            inputField.onEndEdit.RemoveAllListeners();
        }

        private void ConsoleOnPerformed(InputAction.CallbackContext obj)
        {
            Debug.Log("Open Console");
            consoleObject.SetActive(!consoleObject.activeSelf);
            if (consoleObject.activeSelf)
                inputField.ActivateInputField();
        }

        [ConsoleCmd]
        public static void print(string str)
        {
            Debug.Log(str);
        }

        [AttributeUsage(AttributeTargets.Method)]
        public class ConsoleCmd : Attribute
        {
        }

        public static IEnumerable<MethodInfo> GetMethodsWith<TAttribute>(bool inherit = true)
            where TAttribute : Attribute
        {
            return from assemblies in AppDomain.CurrentDomain.GetAssemblies()
                from types in assemblies.GetTypes()
                from methods in types.GetMethods()
                where methods.IsDefined(typeof(TAttribute), inherit)
                select methods;
        }
    }
}