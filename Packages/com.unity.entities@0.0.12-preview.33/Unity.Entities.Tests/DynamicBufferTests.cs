using System;
using NUnit.Framework;

namespace Unity.Entities.Tests
{
    public class DynamicBufferTests : ECSTestsFixture
    {
        struct DynamicBufferElement : IBufferElementData
        {
            public int Value;
        }

        [Test]
        public void CopyFromDynamicBuffer([Values(0,1,2,3,64)]int srcBufferLength)
        {
            var srcEntity = m_Manager.CreateEntity(typeof(DynamicBufferElement));
            var dstEntity = m_Manager.CreateEntity(typeof(DynamicBufferElement));
            var src = m_Manager.GetBuffer<DynamicBufferElement>(srcEntity);
            var dst = m_Manager.GetBuffer<DynamicBufferElement>(dstEntity);

            src.Reserve(srcBufferLength);
            for (var i = 0; i < srcBufferLength; ++i)
            {
                src.Add(new DynamicBufferElement() {Value = i});
            }

            dst.Reserve(2);

            for (var i = 0; i < 2; ++i)
            {
                dst.Add(new DynamicBufferElement() {Value = 0});
            }

            Assert.DoesNotThrow(() => dst.CopyFrom(src));

            Assert.AreEqual(src.Length, dst.Length);

            for (var i = 0; i < src.Length; ++i)
            {
                Assert.AreEqual(i, src[i].Value);
                Assert.AreEqual(src[i].Value, dst[i].Value);
            }
        }

        [Test]
        public void CopyFromArray([Values(0,1,2,3,64)]int srcBufferLength)
        {
            var dstEntity = m_Manager.CreateEntity(typeof(DynamicBufferElement));
            var src = new DynamicBufferElement[srcBufferLength];
            var dst = m_Manager.GetBuffer<DynamicBufferElement>(dstEntity);

            for (var i = 0; i < srcBufferLength; ++i)
            {
                src[i] = new DynamicBufferElement() {Value = i};
            }

            dst.Reserve(2);

            for (var i = 0; i < 2; ++i)
            {
                dst.Add(new DynamicBufferElement() {Value = 0});
            }

            Assert.DoesNotThrow(() => dst.CopyFrom(src));

            Assert.AreEqual(src.Length, dst.Length);

            for (var i = 0; i < src.Length; ++i)
            {
                Assert.AreEqual(i, src[i].Value);
                Assert.AreEqual(src[i].Value, dst[i].Value);
            }
        }

        [Test]
        public void CopyFromDynamicBufferToEmptyDestination()
        {
            var srcEntity = m_Manager.CreateEntity(typeof(DynamicBufferElement));
            var dstEntity = m_Manager.CreateEntity(typeof(DynamicBufferElement));
            var src = m_Manager.GetBuffer<DynamicBufferElement>(srcEntity);
            var dst = m_Manager.GetBuffer<DynamicBufferElement>(dstEntity);

            src.Reserve(64);
            for (var i = 0; i < 64; ++i)
            {
                src.Add(new DynamicBufferElement() {Value = i});
            }

            Assert.DoesNotThrow(() => dst.CopyFrom(src));

            Assert.AreEqual(src.Length, dst.Length);

            for (var i = 0; i < src.Length; ++i)
            {
                Assert.AreEqual(i, src[i].Value);
                Assert.AreEqual(src[i].Value, dst[i].Value);
            }
        }

        [Test]
        public void CopyFromNullSource()
        {
            var dstEntity = m_Manager.CreateEntity(typeof(DynamicBufferElement));
            var dst = m_Manager.GetBuffer<DynamicBufferElement>(dstEntity);

            Assert.Throws<ArgumentNullException>(() => dst.CopyFrom(null));
        }
    }
}
