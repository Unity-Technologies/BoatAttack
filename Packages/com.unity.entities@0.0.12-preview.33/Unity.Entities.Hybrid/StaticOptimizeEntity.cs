using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using MonoBehaviour = UnityEngine.MonoBehaviour;
using GameObject = UnityEngine.GameObject;
using Component = UnityEngine.Component;

namespace Unity.Entities
{
    [DisallowMultipleComponent]
    [RequiresEntityConversion]
    public class StaticOptimizeEntity : MonoBehaviour
    {
    }
}