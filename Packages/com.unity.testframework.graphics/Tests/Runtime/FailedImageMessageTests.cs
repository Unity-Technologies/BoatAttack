using NUnit.Framework;

namespace UnityEngine.TestTools.Graphics.Tests
{
#if TEST_FRAMEWORK_2_0_0_OR_NEWER
    [RequiresPlayMode]
#endif
    public class ImageMessageTests
    {
        [Test]
        public void SerializationRoundtrip_DefaultInstance()
        {
            var message = new ImageMessage();

            var data = message.Serialize();
            var deserialized = ImageMessage.Deserialize(data);

            AssertAreEqual(deserialized, message);
        }

#if UNITY_MONO // IL2CPP does not support attributes with object arguments that are array types.
        [TestCase(null, null, null, null, null)]
        [TestCase("", "", new byte[0], new byte[0], new byte[0])]
        [TestCase("Foo", "Bar", new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, null, null)]
        [TestCase("Foo", "Bar", new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new byte[] { 42, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, null)]
        [TestCase("Foo", "Bar", new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new byte[] { 42, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new byte[] { 42, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void SerializationRoundtrip_AllFieldsAreSerializedAndDeserialized(string pathName, string imageName, byte[] expectedImage,  byte[] actualImage, byte[] diffImage)
        {
            var message = new ImageMessage
            {
                PathName = pathName,
                ImageName = imageName,
                ExpectedImage = expectedImage,
                ActualImage = actualImage,
                DiffImage = diffImage,
            };

            AssertAreEqual(deserialized, message);
        }
#endif

        private static void AssertAreEqual(ImageMessage deserialized, ImageMessage message)
        {
            Assert.That(deserialized.ImageName, Is.EqualTo(message.ImageName));
            Assert.That(deserialized.PathName, Is.EqualTo(message.PathName));
            Assert.That(deserialized.ExpectedImage, Is.EqualTo(message.ExpectedImage));
            Assert.That(deserialized.ActualImage, Is.EqualTo(message.ActualImage));
            Assert.That(deserialized.DiffImage, Is.EqualTo(message.DiffImage));
        }
    }
}
