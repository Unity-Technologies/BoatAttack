using System;
using NUnit.Framework;
using UnityEngine;

namespace Unity.Entities.Tests
{
    public class SharedComponentDataWithUnityEngineObject : ECSTestsFixture
    {
        struct CorrectHashCode : ISharedComponentData , IEquatable<CorrectHashCode>
        {
            public UnityEngine.Object Target;

            public bool Equals(CorrectHashCode other)
            {
                return Target == other.Target;
            }
            public override int GetHashCode()
            {
                return ReferenceEquals(Target, null) ? 0 : Target.GetHashCode();
            }
        }

        struct IncorrectHashCode : ISharedComponentData, IEquatable<IncorrectHashCode>
        {
            public UnityEngine.Object Target;

            public bool Equals(IncorrectHashCode other)
            {
                return Target == other.Target;
            }

            // Target == null can not be used because destroying the object will result in a different hashcode
            public override int GetHashCode()
            {
                return Target == null ? 0 : Target.GetHashCode();
            }
        }


        // https://github.com/Unity-Technologies/dots/issues/1813
        [Test]
        public void CorrectlyImplementedHashCodeDoesNotThrow()
        {
            var e = m_Manager.CreateEntity();
            var obj = new TextAsset();
            m_Manager.AddSharedComponentData(e, new CorrectHashCode { Target = obj });
            UnityEngine.Object.DestroyImmediate(obj);
            m_Manager.DestroyEntity(e);
        }

        [Test]
        public void IncorrectlyImplementedHashCodeThrows()
        {
            var e = m_Manager.CreateEntity();
            var obj = new TextAsset();
            m_Manager.AddSharedComponentData(e, new IncorrectHashCode { Target = obj });
            UnityEngine.Object.DestroyImmediate(obj);

            Assert.Throws<ArgumentException>(() => m_Manager.DestroyEntity(e));
            Assert.Throws<ArgumentException>(() => m_Manager.Debug.CheckInternalConsistency());
            m_Manager.World.Dispose();
        }
    }
}
