using NUnit.Framework;

namespace Unity.Entities.Tests
{
    public class BufferElementDataSystemStateInstantiateTests : ECSTestsFixture
    {
        [Test]
        public unsafe void InstantiateDoesNotCreatesCopy()
        {
            var original = m_Manager.CreateEntity(typeof(EcsIntStateElement));
            var buffer = m_Manager.GetBuffer<EcsIntStateElement>(original);
            buffer.CopyFrom(new EcsIntStateElement[] { 1, 2, 3 }); // smaller than 8
            var clone = m_Manager.Instantiate(original);

            buffer = m_Manager.GetBuffer<EcsIntStateElement>(original);
            Assert.IsFalse(m_Manager.HasComponent<EcsIntStateElement>(clone));
        }
    }
}
