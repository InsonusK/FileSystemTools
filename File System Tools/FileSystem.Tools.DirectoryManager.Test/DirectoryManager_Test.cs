using System;
using System.IO;
using NUnit.Framework;

namespace FileSystem.Tools.Test
{
    public class DirectoryManager_Test
    {
        private DirectoryManager directory;
        private string sandboxPath;
        [SetUp]
        public void Setup()
        {
            directory = new DirectoryManager(Environment.CurrentDirectory);
            string sandboxPath = Path.Combine(Environment.CurrentDirectory, "SandBox");
        }

        [Test]
        public void SubDirectory()
        {
            var sandBoxFolder = directory.SubDirectory("SandBox");
            Assert.AreEqual(sandboxPath, sandBoxFolder.Path);
        }

        [Test]
        public void SubDirectory_NotExist()
        {
            var sandBoxFolder = directory.SubDirectory("SandBox");
            Assert.Throws<DirectoryNotFoundException>(()=> sandBoxFolder.SubDirectory("123"));
            var NotExist = sandBoxFolder.SubDirectory("123", false);
            Assert.IsFalse(Directory.Exists(NotExist.Path));
        }
    }
}