using System;
using System.Linq.Expressions;
using UnityEditor;

namespace Cinemachine.Editor
{
    public static class SerializedPropertyHelper
    {
        /// This is a way to get a field name string in such a manner that the compiler will
        /// generate errors for invalid fields.  Much better than directly using strings.
        /// Usage: instead of
        /// <example>
        /// "m_MyField";
        /// </example>
        /// do this:
        /// <example>
        /// MyClass myclass = null;
        /// SerializedPropertyHelper.PropertyName( () => myClass.m_MyField);
        /// </example>
        public static string PropertyName(Expression<Func<object>> exp)
        {
            var body = exp.Body as MemberExpression;
            if (body == null)
            {
                var ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }
            return body.Member.Name;
        }

        /// Usage: instead of
        /// <example>
        /// mySerializedObject.FindProperty("m_MyField");
        /// </example>
        /// do this:
        /// <example>
        /// MyClass myclass = null;
        /// mySerializedObject.FindProperty( () => myClass.m_MyField);
        /// </example>
        public static SerializedProperty FindProperty(this SerializedObject obj, Expression<Func<object>> exp)
        {
            return obj.FindProperty(PropertyName(exp));
        }

        /// Usage: instead of
        /// <example>
        /// mySerializedProperty.FindPropertyRelative("m_MyField");
        /// </example>
        /// do this:
        /// <example>
        /// MyClass myclass = null;
        /// mySerializedProperty.FindPropertyRelative( () => myClass.m_MyField);
        /// </example>
        public static SerializedProperty FindPropertyRelative(this SerializedProperty obj, Expression<Func<object>> exp)
        {
            return obj.FindPropertyRelative(PropertyName(exp));
        }
    }
}
