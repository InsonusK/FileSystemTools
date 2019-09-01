using System.Collections;
using NUnit.Framework;

namespace FileSystem.Tools.Test
{
    public class FileName_Test
    {
        [Test]
        public void ToString_Test()
        {
            Assert.AreEqual("abc.zsc", new FileName("abc", "zsc").ToString());
            Assert.AreEqual("abc.", new FileName("abc.").ToString());
            Assert.AreEqual("abc.123.zsc", new FileName("abc.123", "zsc").ToString());
            Assert.AreEqual("abc", new FileName("abc").ToString());
        }

        [Test]
        public void Equals_Test()
        {
            var _example = new FileName("abc", "zsc");

            Assert.AreEqual(_example, new FileName("abc", "zsc"));
            Assert.AreNotEqual(_example, new FileName("abc", "zs"));
            Assert.AreNotEqual(_example, new FileName("abc"));

            _example = new FileName("abc");
            Assert.AreNotEqual(_example, new FileName("abc", "zs"));
            Assert.AreEqual(_example, new FileName("abc"));
        }

        [Test]
        public void GetHashCode_Test()
        {
            var _example = new FileName("abc", "zsc").GetHashCode();

            Assert.AreEqual(_example, new FileName("abc", "zsc").GetHashCode());
            Assert.AreNotEqual(_example, new FileName("abc", "zs").GetHashCode());
            Assert.AreNotEqual(_example, new FileName("abc").GetHashCode());

            _example = new FileName("abc").GetHashCode();
            Assert.AreNotEqual(_example, new FileName("abc", "zs").GetHashCode());
            Assert.AreEqual(_example, new FileName("abc").GetHashCode());

            Assert.AreNotEqual(
                new FileName("abc.").GetHashCode(), 
                new FileName("abc").GetHashCode());
        }

        [TestCaseSource(nameof(Constructor_Simple_TestCase))]
        public FileName Constructor_Simple(string fileName, string extension)
        {
           var _return = new FileName(fileName, extension);
           Assert.AreEqual(_return.Name,fileName );
           Assert.AreEqual(_return.Extension, extension);
           return _return;
        }

        public static IEnumerable Constructor_Simple_TestCase
        {
            get
            {
                yield return new TestCaseData("abc", "zxc").Returns(new FileName("abc", "zxc"));
                yield return new TestCaseData("abc.zxc", "123").Returns(new FileName("abc.zxc", "123"));
                yield return new TestCaseData("abc.zxc_wsx", "123").Returns(new FileName("abc.zxc_wsx", "123"));
            }
        }

        [TestCaseSource(nameof(Constructor_FromFileName_TestCase))]
        public FileName Constructor_FromFileName(string fileName)
        {
            return new FileName(fileName);
        }

        public static IEnumerable Constructor_FromFileName_TestCase
        {
            get
            {
                yield return new TestCaseData("abc.zxc").Returns(new FileName("abc","zxc"));
                yield return new TestCaseData("abc.zxc.123").Returns(new FileName("abc.zxc", "123"));
                yield return new TestCaseData("abc.zxc_wsx.123").Returns(new FileName("abc.zxc_wsx", "123"));
            }
        }

        [Test]
        public void Constructor()
        {
            Assert.AreNotEqual(new FileName("abc."), new FileName("abc"));
        }
    }
}