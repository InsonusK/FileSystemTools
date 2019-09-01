using System;
using System.IO;
using NUnit.Framework;

namespace FileSystem.Tools.Test
{
    public class DirectoryManager_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SubDirectory()
        {
            string sandboxPath = Path.Combine(Environment.CurrentDirectory, "SandBox");
            DirectoryManager directory = new DirectoryManager(Environment.CurrentDirectory);
            var sandBoxFolder = directory.SubDirectory("SandBox");
            Assert.AreEqual(sandboxPath, sandBoxFolder.Path);
        }
    }
}