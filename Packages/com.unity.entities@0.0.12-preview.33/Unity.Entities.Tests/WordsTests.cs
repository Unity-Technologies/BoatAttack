#if !UNITY_DOTSPLAYER
using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using Unity.Collections;

namespace Unity.Entities.Tests
{
    struct EcsStringData : IComponentData
    {
        public NativeString64 value;
    }
    class NativeStringECSTests : ECSTestsFixture
    {       
        [Test]
        public void NativeString64CanBeComponent()
        {            
            var archetype = m_Manager.CreateArchetype(new ComponentType[]{typeof(EcsStringData)});
            const int entityCount = 1000;
            NativeArray<Entity> entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            m_Manager.CreateEntity(archetype, entities);
            for(var i = 0; i < entityCount; ++i)
            {
                m_Manager.SetComponentData(entities[i], new EcsStringData {value = new NativeString64(i.ToString())});
            }
            for (var i = 0; i < entityCount; ++i)
            {
                var ecsStringData = m_Manager.GetComponentData<EcsStringData>(entities[i]);
                Assert.AreEqual(ecsStringData.value.ToString(), i.ToString());
            }
            entities.Dispose();
        }
    }
    
    [TestFixture("en-US")]
    [TestFixture("da-DK")]
    public class WordsTests
	{
        CultureInfo testCulture;
        CultureInfo backupCulture;
        
        public WordsTests(string culture)
        {
            testCulture = CultureInfo.CreateSpecificCulture(culture);
        }

        [SetUp]
	    public virtual void Setup()
	    {
            backupCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = testCulture;
	        WordStorage.Setup();
	    }

	    [TearDown]
	    public virtual void TearDown()
	    {
            Thread.CurrentThread.CurrentCulture = backupCulture;
        }

        [Test]
        public unsafe void Utf8EncodeDecode([Range(0, 0xD7FF, 997)] int input_ucs)
        {
            var converted = new byte[4];
            fixed (byte* c = converted)
            {
                ConversionError error;
                int write_length = 0;
                error = NativeString.UcsToUtf8(c, ref write_length, converted.Length, input_ucs);
                Assert.AreEqual(ConversionError.None, error);
                int read_length = 0;
                error = NativeString.Utf8ToUcs(out int output_ucs, c, ref read_length, write_length);
                Assert.AreEqual(ConversionError.None, error);
                Assert.AreEqual(write_length, read_length);
                Assert.AreEqual(output_ucs, input_ucs);
            }
        }

        [Test]
        public unsafe void Utf16EncodeDecode([Range(0, 0xD7FF,997)] int input_ucs)
        {
            var converted = new char[2];
            fixed (char* c = converted)
            {
                ConversionError error;
                int write_length = 0;
                error = NativeString.UcsToUtf16(c, ref write_length, converted.Length, input_ucs);
                Assert.AreEqual(ConversionError.None, error);
                int read_length = 0;
                error = NativeString.Utf16ToUcs(out int output_ucs, c, ref read_length, write_length);
                Assert.AreEqual(ConversionError.None, error);
                Assert.AreEqual(write_length, read_length);
                Assert.AreEqual(output_ucs, input_ucs);
            }
        }

        unsafe void Utf16ToUtf8(string source)
        {
            var converted = new byte[source.Length * 4]; // UTF-8 text can be up to 2x as long as UTF-16 text
            var destination = new char[source.Length];
            fixed(byte* c = converted)
            fixed(char* s = source)
            fixed(char* d = destination)
            {
                NativeString.Utf16ToUtf8(s, source.Length, c, out var converted_length, converted.Length);
                NativeString.Utf8ToUtf16(c, converted_length, d, out var destination_length, destination.Length);
                Assert.AreEqual(source, destination);
            }
        }

        [TestCase("The Quick Brown Fox Jumps Over The Lazy Dog")]
        [TestCase("Albert osti fagotin ja töräytti puhkuvan melodian.", TestName = "{m}(Finnish)")]
        [TestCase("Franz jagt im komplett verwahrlosten Taxi quer durch Bayern.", TestName = "{m}(German)")]
        [TestCase("איך בלש תפס גמד רוצח עז קטנה?", TestName = "{m}(Hebrew)")]
        [TestCase("PORTEZ CE VIEUX WHISKY AU JUGE BLOND QUI FUME.", TestName = "{m}(French)")]
        [TestCase("いろはにほへとちりぬるをわかよたれそつねならむうゐのおくやまけふこえてあさきゆめみしゑひもせす", TestName = "{m}(Japanese)")]
        [TestCase("키스의 고유조건은 입술끼리 만나야 하고 특별한 기술은 필요치 않다.", TestName = "{m}(Korean)")]
        public unsafe void Utf16ToUtf8BMP(string source)
        {
            Utf16ToUtf8(source);
        }

        [TestCase("🌕🌖🌗🌘🌑🌒🌓🌔", TestName = "{m}(MoonPhases)")]
        [TestCase("𝒞𝒯𝒮𝒟𝒳𝒩𝒫𝒢", TestName = "{m}(Cursive)")]        
        public unsafe void Utf16ToUtf8TransBMP(string source)
        {
            Utf16ToUtf8(source);
        }
        
        [TestCase("This is supposed to be too long to fit into a fixed-length string.", CopyError.Truncation)]
        [TestCase("This should fit.", CopyError.None)]
        public void NativeStringCopyFrom(String s, CopyError expectedError)
        {
            NativeString64 ns = new NativeString64();
            var error = ns.CopyFrom(s);
            Assert.AreEqual(expectedError, error);
        }
        
        [TestCase("red", 0, 0, ParseError.Syntax)]
        [TestCase("0", 1, 0, ParseError.None)]
        [TestCase("-1", 2, -1, ParseError.None)]
        [TestCase("-0", 2, 0, ParseError.None)]
        [TestCase("100", 3, 100, ParseError.None)]
        [TestCase("-100", 4, -100, ParseError.None)]
        [TestCase("100.50", 3, 100, ParseError.None)]
        [TestCase("-100ab", 4, -100, ParseError.None)]
        [TestCase("2147483647", 10, 2147483647, ParseError.None)]
        [TestCase("-2147483648", 11, -2147483648, ParseError.None)]
        [TestCase("2147483648", 10, 0, ParseError.Overflow)]
        [TestCase("-2147483649", 11, 0, ParseError.Overflow)]
        public void NativeString64ParseIntWorks(String a, int expectedOffset, int expectedOutput, ParseError expectedResult)
        {
            NativeString64 aa = new NativeString64(a);
            int offset = 0;
            int output = 0;
            var result = aa.Parse(ref offset, ref output);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedOffset, offset);
            if (result == ParseError.None)
            {
                Assert.AreEqual(expectedOutput, output);
            }
        }
        
        [TestCase("red", 0, ParseError.Syntax)]
        [TestCase("0", 1,  ParseError.None)]
        [TestCase("-1", 2, ParseError.None)]
        [TestCase("-0", 2, ParseError.None)]
        [TestCase("100", 3, ParseError.None)]
        [TestCase("-100", 4, ParseError.None)]
        [TestCase("100.50", 6, ParseError.None)]
        [TestCase("2147483648", 10, ParseError.None)]
        [TestCase("-2147483649", 11, ParseError.None)]
        [TestCase("-10E10", 6, ParseError.None)]
        [TestCase("-10E-10", 7, ParseError.None)]
        [TestCase("-10E+10", 7, ParseError.None)]
        [TestCase("10E-40", 5, ParseError.Underflow)]
        [TestCase("10E+40", 5, ParseError.Overflow)]
        [TestCase("-Infinity", 9, ParseError.None)]
        [TestCase("Infinity", 8, ParseError.None)]
        [TestCase("1000001",       7, ParseError.None)]
        [TestCase("10000001",      8, ParseError.None)]
        [TestCase("100000001",     9, ParseError.None)]
        [TestCase("1000000001",   10, ParseError.None)]
        [TestCase("10000000001",  11, ParseError.None)]
        [TestCase("100000000001", 12, ParseError.None)]
        public void NativeString64ParseFloat(String unlocalizedString, int expectedOffset, ParseError expectedResult)
        {
            var localizedDecimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);            
            var localizedString = unlocalizedString.Replace('.', localizedDecimalSeparator);
            float expectedOutput = 0;
            try { expectedOutput = Single.Parse(localizedString); } catch {}
            NativeString64 nativeLocalizedString = new NativeString64(localizedString);
            int offset = 0;
            float output = 0;
            var result = nativeLocalizedString.Parse(ref offset, ref output, localizedDecimalSeparator);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedOffset, offset);
            if (result == ParseError.None)
            {
                Assert.AreEqual(expectedOutput, output);
            }
        }

        [TestCase(Single.NaN, FormatError.None)]
        [TestCase(Single.PositiveInfinity, FormatError.None)]
        [TestCase(Single.NegativeInfinity, FormatError.None)]
        [TestCase(0.0f, FormatError.None)]
        [TestCase(-1.0f, FormatError.None)]
        [TestCase(100.0f, FormatError.None)]
        [TestCase(-100.0f, FormatError.None)]
        [TestCase(100.5f, FormatError.None)]
        [TestCase(0.001005f, FormatError.None)]
        [TestCase(0.0001f, FormatError.None)]
        [TestCase(0.00001f, FormatError.None)]
        [TestCase(0.000001f, FormatError.None)]
        [TestCase(-1E10f, FormatError.None)]
        [TestCase(-1E-10f, FormatError.None)]
        public void NativeString64FormatFloat(float input, FormatError expectedResult)
        {         
            var localizedDecimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            var expectedOutput = input.ToString();
            NativeString64 aa = new NativeString64();
            var result = aa.Format(input, localizedDecimalSeparator);
            Assert.AreEqual(expectedResult, result);
            if (result == FormatError.None)
            {
                var actualOutput = aa.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [Test]
        public void NativeString64FormatNegativeZero()
        {
            float input = -0.0f;
            var expectedOutput = input.ToString();
            NativeString64 aa = new NativeString64();
            var result = aa.Format(input);
            Assert.AreEqual(FormatError.None, result);
            var actualOutput = aa.ToString();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        
        [TestCase("en-US")]
        [TestCase("da-DK")]
        public void NativeString64ParseFloatLocale(String locale)
        {         
            var original = CultureInfo.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
                var localizedDecimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);                    
                float value = 1.5f;
                NativeString64 native = new NativeString64();
                native.Format(value, localizedDecimalSeparator);
                var nativeResult = native.ToString();
                var managedResult = value.ToString();
                Assert.AreEqual(managedResult, nativeResult);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = original;
            }
        }
        
        [Test]
        public void NativeString64ParseFloatNan()
        {         
            NativeString64 aa = new NativeString64("NaN");
            int offset = 0;
            float output = 0;
            var result = aa.Parse(ref offset, ref output);
            Assert.AreEqual(ParseError.None, result);
            Assert.IsTrue(Single.IsNaN(output));
        }
        
        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("green")]
        [TestCase("blue")]
        [TestCase("indigo")]
        [TestCase("violet")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("绿色", TestName="{m}(Chinese-Green)")]
        [TestCase("蓝色", TestName="{m}(Chinese-Blue")]
        [TestCase("靛蓝色", TestName="{m}(Chinese-Blue")]
        [TestCase("紫罗兰色", TestName="{m}(Chinese-Violet")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("James Madison")]
        [TestCase("James Monroe")]
        [TestCase("John Quincy Adams")]
        [TestCase("Andrew Jackson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        [TestCase("大江健三郎", TestName="{m}(OeKenzaburo)")]
        [TestCase("川端 康成", TestName="{m}(KawabataYasunari)")]
        [TestCase("桐野夏生", TestName="{m}(TongyeXiasheng)")]
        [TestCase("芥川龍之介", TestName="{m}(RyunosukeAkutagawa)")]
        public void NativeString64ToStringWorks(String a)
        {
            NativeString64 aa = new NativeString64(a);
            Assert.AreEqual(aa.ToString(), a);
        }
        
        [TestCase("monkey", "monkey")]
        [TestCase("red","orange")]
        [TestCase("yellow","green")]
        [TestCase("blue", "indigo")]
        [TestCase("violet","紅色", TestName="{m}(Violet-Chinese-Red")]
        [TestCase("橙色","黄色", TestName="{m}(Chinese-Orange-Yellow")]
        [TestCase("绿色","蓝色", TestName="{m}(Chinese-Green-Blue")]
        [TestCase("靛蓝色","紫罗兰色", TestName="{m}(Chinese-Indigo-Violet")]
        [TestCase("George Washington","John Adams")]
        [TestCase("Thomas Jefferson","James Madison")]
        [TestCase("James Monroe","John Quincy Adams")]
        [TestCase("Andrew Jackson","村上春樹", TestName="{m}(AndrewJackson-HarukiMurakami")]
        [TestCase("三島 由紀夫","吉本ばなな", TestName="{m}(MishimaYukio-YoshimotoBanana")]
        [TestCase("大江健三郎","川端 康成", TestName="{m}(OeKenzaburo-KawabataYasunari")]
        [TestCase("桐野夏生","芥川龍之介", TestName="{m}(TongyeXiasheng-RyunosukeAkutagawa")]
        public void NativeString64EqualsWorks(String a, String b)
        {
            NativeString64 aa = new NativeString64(a);
            NativeString64 bb = new NativeString64(b);
            Assert.AreEqual(aa.Equals(bb), a.Equals(b));
        }
        
        [TestCase("monkey", "monkey")]
        [TestCase("red","orange")]
        [TestCase("yellow","green")]
        [TestCase("blue", "indigo")]
        [TestCase("violet","紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色","黄色", TestName="{m}(Chinese-Orange-Yellow")]
        [TestCase("绿色","蓝色", TestName="{m}(Chinese-Green-Blue")]
        [TestCase("靛蓝色","紫罗兰色", TestName="{m}(Chinese-Indigo-Violet")]
        [TestCase("George Washington","John Adams")]
        [TestCase("Thomas Jefferson","James Madison")]
        [TestCase("James Monroe","John Quincy Adams")]
        [TestCase("Andrew Jackson","村上春樹", TestName="{m}(AndrewJackson-HarukiMurakami")]
        [TestCase("三島 由紀夫","吉本ばなな", TestName="{m}(MishimaYukio-YoshimotoBanana")]
        [TestCase("大江健三郎","川端 康成", TestName="{m}(OeKenzaburo-KawabataYasunari")]
        [TestCase("桐野夏生","芥川龍之介", TestName="{m}(TongyeXiasheng-RyunosukeAkutagawa")]
        public void NativeString64CompareToWorks(String a, String b)
        {
            NativeString64 aa = new NativeString64(a);
            NativeString64 bb = new NativeString64(b);
            var c0 = aa.CompareTo(bb);
            var c1 = a.CompareTo(b);
            Assert.AreEqual(c0, c1);
        }

        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("green")]
        [TestCase("blue")]
        [TestCase("indigo")]
        [TestCase("violet")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("绿色", TestName="{m}(Chinese-Green)")]
        [TestCase("蓝色", TestName="{m}(Chinese-Blue")]
        [TestCase("靛蓝色", TestName="{m}(Chinese-Indigo")]
        [TestCase("紫罗兰色", TestName="{m}(Chinese-Violet")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("James Madison")]
        [TestCase("James Monroe")]
        [TestCase("John Quincy Adams")]
        [TestCase("Andrew Jackson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        [TestCase("大江健三郎", TestName="{m}(OeKenzaburo)")]
        [TestCase("川端 康成", TestName="{m}(KawabataYasunari)")]
        [TestCase("桐野夏生", TestName="{m}(TongyeXiasheng)")]
        [TestCase("芥川龍之介", TestName="{m}(RyunosukeAkutagawa)")]
        public void NativeString512ToStringWorks(String a)
        {
            NativeString512 aa = new NativeString512(a);
            Assert.AreEqual(aa.ToString(), a);
        }
        
        [TestCase("monkey", "monkey")]
        [TestCase("red","orange")]
        [TestCase("yellow","green")]
        [TestCase("blue", "indigo")]
        [TestCase("violet","紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色","黄色", TestName="{m}(Chinese-Orange-Yellow)")]
        [TestCase("绿色","蓝色", TestName="{m}(Chinese-Green-Blue")]
        [TestCase("靛蓝色","紫罗兰色", TestName="{m}(Chinese-Indigo-Violet")]
        [TestCase("George Washington","John Adams")]
        [TestCase("Thomas Jefferson","James Madison")]
        [TestCase("James Monroe","John Quincy Adams")]
        [TestCase("Andrew Jackson","村上春樹", TestName="{m}(AndrewJackson-HarukiMurakami")]
        [TestCase("三島 由紀夫","吉本ばなな", TestName="{m}(MishimaYukio-YoshimotoBanana")]
        [TestCase("大江健三郎","川端 康成", TestName="{m}(OeKenzaburo-KawabataYasunari")]
        [TestCase("桐野夏生","芥川龍之介", TestName="{m}(TongyeXiasheng-RyunosukeAkutagawa")]
        public void NativeString512EqualsWorks(String a, String b)
        {
            NativeString512 aa = new NativeString512(a);
            NativeString512 bb = new NativeString512(b);
            Assert.AreEqual(aa.Equals(bb), a.Equals(b));
        }
        
        [TestCase("monkey", "monkey")]
        [TestCase("red","orange")]
        [TestCase("yellow","green")]
        [TestCase("blue", "indigo")]
        [TestCase("violet","紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色","黄色", TestName="{m}(Chinese-Orange-Yellow)")]
        [TestCase("绿色","蓝色", TestName="{m}(Chinese-Green-Blue")]
        [TestCase("靛蓝色","紫罗兰色", TestName="{m}(Chinese-Indigo-Violet")]
        [TestCase("George Washington","John Adams")]
        [TestCase("Thomas Jefferson","James Madison")]
        [TestCase("James Monroe","John Quincy Adams")]
        [TestCase("Andrew Jackson","村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫","吉本ばなな", TestName="{m}(MishimaYukio-YoshimotoBanana")]
        [TestCase("大江健三郎","川端 康成", TestName="{m}(OeKenzaburo-KawabataYasunari")]
        [TestCase("桐野夏生","芥川龍之介", TestName="{m}(TongyeXiasheng-RyunosukeAkutagawa")]
        public void NativeString512CompareToWorks(String a, String b)
        {
            NativeString512 aa = new NativeString512(a);
            NativeString512 bb = new NativeString512(b);
            Assert.AreEqual(aa.CompareTo(bb), a.CompareTo(b));
        }

        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("green")]
        [TestCase("blue")]
        [TestCase("indigo")]
        [TestCase("violet")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("绿色", TestName="{m}(Chinese-Green)")]
        [TestCase("蓝色", TestName="{m}(Chinese-Blue")]
        [TestCase("靛蓝色", TestName="{m}(Chinese-Blue")]
        [TestCase("紫罗兰色", TestName="{m}(Chinese-Violet")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("James Madison")]
        [TestCase("James Monroe")]
        [TestCase("John Quincy Adams")]
        [TestCase("Andrew Jackson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        [TestCase("大江健三郎", TestName="{m}(OeKenzaburo)")]
        [TestCase("川端 康成", TestName="{m}(KawabataYasunari)")]
        [TestCase("桐野夏生", TestName="{m}(TongyeXiasheng)")]
        [TestCase("芥川龍之介", TestName="{m}(RyunosukeAkutagawa)")]
        public void NativeString4096ToStringWorks(String a)
        {
            NativeString4096 aa = new NativeString4096(a);
            Assert.AreEqual(aa.ToString(), a);
        }
        
        [TestCase("monkey", "monkey")]
        [TestCase("red","orange")]
        [TestCase("yellow","green")]
        [TestCase("blue", "indigo")]
        [TestCase("violet","紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色","黄色", TestName="{m}(Chinese-Orange-Yellow)")]
        [TestCase("绿色","蓝色", TestName="{m}(Chinese-Green-Blue")]
        [TestCase("靛蓝色","紫罗兰色", TestName="{m}(Chinese-Indigo-Violet")]
        [TestCase("George Washington","John Adams")]
        [TestCase("Thomas Jefferson","James Madison")]
        [TestCase("James Monroe","John Quincy Adams")]
        [TestCase("Andrew Jackson","村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫","吉本ばなな", TestName="{m}(MishimaYukio-YoshimotoBanana")]
        [TestCase("大江健三郎","川端 康成", TestName="{m}(OeKenzaburo-KawabataYasunari")]
        [TestCase("桐野夏生","芥川龍之介", TestName="{m}(TongyeXiasheng-RyunosukeAkutagawa")]
        public void NativeString4096EqualsWorks(String a, String b)
        {
            NativeString4096 aa = new NativeString4096(a);
            NativeString4096 bb = new NativeString4096(b);
            Assert.AreEqual(aa.Equals(bb), a.Equals(b));
        }
        
        [TestCase("monkey", "monkey")]
        [TestCase("red","orange")]
        [TestCase("yellow","green")]
        [TestCase("blue", "indigo")]
        [TestCase("violet","紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色","黄色", TestName="{m}(Chinese-Orange-Yellow)")]
        [TestCase("绿色","蓝色", TestName="{m}(Chinese-Green-Blue")]
        [TestCase("靛蓝色","紫罗兰色", TestName="{m}(Chinese-Indigo-Violet")]
        [TestCase("George Washington","John Adams")]
        [TestCase("Thomas Jefferson","James Madison")]
        [TestCase("James Monroe","John Quincy Adams")]
        [TestCase("Andrew Jackson","村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫","吉本ばなな", TestName="{m}(MishimaYukio-YoshimotoBanana")]
        [TestCase("大江健三郎","川端 康成", TestName="{m}(OeKenzaburo-KawabataYasunari")]
        [TestCase("桐野夏生","芥川龍之介", TestName="{m}(TongyeXiasheng-RyunosukeAkutagawa")]
        public void NativeString4096CompareToWorks(String a, String b)
        {
            NativeString4096 aa = new NativeString4096(a);
            NativeString4096 bb = new NativeString4096(b);
            Assert.AreEqual(aa.CompareTo(bb), a.CompareTo(b));
        }

        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        public void NativeString512ToNativeString64Works(String a)
        {
            var b = new NativeString512(a);
            var c = new NativeString64(ref b);
            String d = c.ToString();
            Assert.AreEqual(a, d);
        }
        
        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        public void NativeString4096ToNativeString64Works(String a)
        {
            var b = new NativeString4096(a);
            var c = new NativeString64(ref b);
            String d = c.ToString();
            Assert.AreEqual(a, d);
        }
        
        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        public void NativeString64ToNativeString512Works(String a)
        {
            var b = new NativeString64(a);
            var c = new NativeString512(ref b);
            String d = c.ToString();
            Assert.AreEqual(a, d);
        }
        
        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        public void NativeString4096ToNativeString512Works(String a)
        {
            var b = new NativeString4096(a);
            var c = new NativeString512(ref b);
            String d = c.ToString();
            Assert.AreEqual(a, d);
        }

        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        public void NativeString64ToNativeString4096Works(String a)
        {
            var b = new NativeString64(a);
            var c = new NativeString4096(ref b);
            String d = c.ToString();
            Assert.AreEqual(a, d);
        }
        
        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        public void NativeString512ToNativeString4096Works(String a)
        {
            var b = new NativeString512(a);
            var c = new NativeString4096(ref b);
            String d = c.ToString();
            Assert.AreEqual(a, d);
        }
        
        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("green")]
        [TestCase("blue")]
        [TestCase("indigo")]
        [TestCase("violet")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("绿色", TestName="{m}(Chinese-Green)")]
        [TestCase("蓝色", TestName="{m}(Chinese-Blue")]
        [TestCase("靛蓝色", TestName="{m}(Chinese-Indigo")]
        [TestCase("紫罗兰色", TestName="{m}(Chinese-Violet")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("James Madison")]
        [TestCase("James Monroe")]
        [TestCase("John Quincy Adams")]
        [TestCase("Andrew Jackson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        [TestCase("大江健三郎", TestName="{m}(OeKenzaburo)")]
        [TestCase("川端 康成", TestName="{m}(KawabataYasunari)")]
        [TestCase("桐野夏生", TestName="{m}(TongyeXiasheng)")]
        [TestCase("芥川龍之介", TestName="{m}(RyunosukeAkutagawa)")]
        [TestCase("로마는 하루아침에 이루어진 것이 아니다", TestName="{m}(Korean - Rome was not made overnight)")]
        [TestCase("낮말은 새가 듣고 밤말은 쥐가 듣는다", TestName="{m}(Korean-Proverb2)")]
        [TestCase("말을 냇가에 끌고 갈 수는 있어도 억지로 물을 먹일 수는 없다", TestName="{m}(Korean-Proverb3)")]
        [TestCase("호랑이에게 물려가도 정신만 차리면 산다", TestName="{m}(Korean-Proverb4)")]
        [TestCase("Үнэн үг хэлсэн хүнд ноёд өстэй, үхэр унасан хүнд ноход өстэй.", TestName="{m}(Mongolian-Proverb1)")]
        [TestCase("Өнгөрсөн борооны хойноос эсгий нөмрөх.", TestName="{m}(Mongolian-Proverb2)")]
        [TestCase("Барын сүүл байснаас батганы толгой байсан нь дээр.", TestName="{m}(Mongolian-Proverb3)")]
        [TestCase("Гараар ганц хүнийг дийлэх. Tолгойгоор мянган хүнийг дийлэх.", TestName="{m}(Mongolian-Proverb4)")]
        [TestCase("Աղւէսը բերանը խաղողին չի հասնում, ասում է՝ խակ է", TestName="{m}(Armenian-Proverb1)")]
        [TestCase("Ամեն փայտ շերեփ չի դառնա, ամեն սար՝ Մասիս", TestName="{m}(Armenian-Proverb2)")]
        [TestCase("Արևին ասում է դուրս մի արի՝ ես դուրս եմ եկել", TestName="{m}(Armenian-Proverb3)")]
        [TestCase("Գայլի գլխին Աւետարան են կարդում, ասում է՝ շուտ արէ՛ք, գալլէս գնաց", TestName="{m}(Armenian-Proverb4)")]
        [TestCase("पृथिव्यां त्रीणी रत्नानि जलमन्नं सुभाषितम्।", TestName="{m}(Hindi-Proverb1)")]
        [TestCase("जननी जन्मभुमिस्छ स्वर्गादपि गरीयसि", TestName="{m}(Hindi-Proverb2)")]
        [TestCase("न अभिशेको न संस्कारः सिम्हस्य कृयते वनेविक्रमार्जितसत्वस्य स्वयमेव मृगेन्द्रता", TestName="{m}(Hindi-Proverb3)")]
        public void WordsWorks(String value)
        {
            Words s = new Words();
            s.SetString(value);
            Assert.AreEqual(s.ToString(), value);
        }

        [TestCase("red")]
        [TestCase("orange")]
        [TestCase("yellow")]
        [TestCase("green")]
        [TestCase("blue")]
        [TestCase("indigo")]
        [TestCase("violet")]
        [TestCase("紅色", TestName="{m}(Chinese-Red)")]
        [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
        [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
        [TestCase("绿色", TestName="{m}(Chinese-Green)")]
        [TestCase("蓝色", TestName="{m}(Chinese-Blue")]
        [TestCase("靛蓝色", TestName="{m}(Chinese-Indigo")]
        [TestCase("紫罗兰色", TestName="{m}(Chinese-Violet")]
        [TestCase("George Washington")]
        [TestCase("John Adams")]
        [TestCase("Thomas Jefferson")]
        [TestCase("James Madison")]
        [TestCase("James Monroe")]
        [TestCase("John Quincy Adams")]
        [TestCase("Andrew Jackson")]
        [TestCase("村上春樹", TestName="{m}(HarukiMurakami)")]
        [TestCase("三島 由紀夫", TestName="{m}(MishimaYukio)")]
        [TestCase("吉本ばなな", TestName="{m}(YoshimotoBanana)")]
        [TestCase("大江健三郎", TestName="{m}(OeKenzaburo)")]
        [TestCase("川端 康成", TestName="{m}(KawabataYasunari)")]
        [TestCase("桐野夏生", TestName="{m}(TongyeXiasheng)")]
        [TestCase("芥川龍之介", TestName="{m}(RyunosukeAkutagawa)")]
        [TestCase("로마는 하루아침에 이루어진 것이 아니다", TestName="{m}(Korean-Proverb1)")]
        [TestCase("낮말은 새가 듣고 밤말은 쥐가 듣는다", TestName="{m}(Korean-Proverb2)")]
        [TestCase("말을 냇가에 끌고 갈 수는 있어도 억지로 물을 먹일 수는 없다", TestName="{m}(Korean-Proverb3)")]
        [TestCase("호랑이에게 물려가도 정신만 차리면 산다", TestName="{m}(Korean-Proverb4)")]
        [TestCase("Үнэн үг хэлсэн хүнд ноёд өстэй, үхэр унасан хүнд ноход өстэй.", TestName="{m}(Mongolian-Proverb1)")]
        [TestCase("Өнгөрсөн борооны хойноос эсгий нөмрөх.", TestName="{m}(Mongolian-Proverb2)")]
        [TestCase("Барын сүүл байснаас батганы толгой байсан нь дээр.", TestName="{m}(Mongolian-Proverb3)")]
        [TestCase("Гараар ганц хүнийг дийлэх. Tолгойгоор мянган хүнийг дийлэх.", TestName="{m}(Mongolian-Proverb4)")]
        [TestCase("Աղւէսը բերանը խաղողին չի հասնում, ասում է՝ խակ է", TestName="{m}(Armenian-Proverb1)")]
        [TestCase("Ամեն փայտ շերեփ չի դառնա, ամեն սար՝ Մասիս", TestName="{m}(Armenian-Proverb2)")]
        [TestCase("Արևին ասում է դուրս մի արի՝ ես դուրս եմ եկել", TestName="{m}(Armenian-Proverb3)")]
        [TestCase("Գայլի գլխին Աւետարան են կարդում, ասում է՝ շուտ արէ՛ք, գալլէս գնաց", TestName="{m}(Armenian-Proverb4)")]
        [TestCase("पृथिव्यां त्रीणी रत्नानि जलमन्नं सुभाषितम्।", TestName="{m}(Hindi-Proverb1)")]
        [TestCase("जननी जन्मभुमिस्छ स्वर्गादपि गरीयसि", TestName="{m}(Hindi-Proverb2)")]
        [TestCase("न अभिशेको न संस्कारः सिम्हस्य कृयते वनेविक्रमार्जितसत्वस्य स्वयमेव मृगेन्द्रता", TestName="{m}(Hindi-Proverb3)")]
	    public void AddWorks(String value)
	    {
	        Words w = new Words();
            Assert.IsFalse(WordStorage.Instance.Contains(value));
	        Assert.IsTrue(WordStorage.Instance.Entries == 1);
	        w.SetString(value);	        
	        Assert.IsTrue(WordStorage.Instance.Contains(value));
	        Assert.IsTrue(WordStorage.Instance.Entries == 2);
	    }

	    [TestCase("red")]
	    [TestCase("orange")]
	    [TestCase("yellow")]
	    [TestCase("green")]
	    [TestCase("blue")]
	    [TestCase("indigo")]
	    [TestCase("violet")]
	    [TestCase("紅色", TestName="{m}(Chinese-Red)")]
	    [TestCase("橙色", TestName="{m}(Chinese-Orange)")]
	    [TestCase("黄色", TestName="{m}(Chinese-Yellow)")]
	    [TestCase("绿色", TestName="{m}(Chinese-Green)")]
	    [TestCase("蓝色", TestName="{m}(Chinese-Blue")]
	    [TestCase("靛蓝色", TestName="{m}(Chinese-Indigo")]
	    [TestCase("紫罗兰色", TestName="{m}(Chinese-Violet")]
	    [TestCase("로마는 하루아침에 이루어진 것이 아니다", TestName="{m}(Korean - Rome was not made overnight)")]
	    [TestCase("낮말은 새가 듣고 밤말은 쥐가 듣는다", TestName="{m}(Korean-Proverb2)")]
	    [TestCase("말을 냇가에 끌고 갈 수는 있어도 억지로 물을 먹일 수는 없다", TestName="{m}(Korean-Proverb3)")]
	    [TestCase("호랑이에게 물려가도 정신만 차리면 산다", TestName="{m}(Korean-Proverb4)")]
	    public void NumberedWordsWorks(String value)
	    {
	        NumberedWords w = new NumberedWords();
	        Assert.IsTrue(WordStorage.Instance.Entries == 1);
	        for (var i = 0; i < 100; ++i)
	        {
	            w.SetString( value + i);
	            Assert.IsTrue(WordStorage.Instance.Entries == 2);
	        }	        
	    }
	}
}
#endif
