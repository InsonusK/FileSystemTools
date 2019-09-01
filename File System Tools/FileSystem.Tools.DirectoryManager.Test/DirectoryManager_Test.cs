using System;
using System.IO;
using NUnit.Framework;

namespace FileSystem.Tools.Test
{
    public class DirectoryManager_Test
    {
        private DirectoryManager directory;
        private DirectoryManager sandBoxFolder;
        [SetUp]
        public void Setup()
        {
            directory = new DirectoryManager(Environment.CurrentDirectory);
            sandBoxFolder = directory.SubDirectory("SandBox");
        }

        [Test]
        public void SubDirectory()
        {
            string sandboxPath = Path.Combine(Environment.CurrentDirectory, "SandBox");
            Assert.AreEqual(sandboxPath, sandBoxFolder.Path);
        }

        [Test]
        public void SubDirectory_NotExist()
        {
            Assert.Throws<DirectoryNotFoundException>(()=> sandBoxFolder.SubDirectory("123"));
            var NotExist = sandBoxFolder.SubDirectory("123", false);
            Assert.IsFalse(Directory.Exists(NotExist.Path));
        }

        /// <summary>
        /// Create test
        /// </summary>
        [Test]
        public void Create_delete()
        {
            var createDir = sandBoxFolder.SubDirectory("Create", false);
            createDir.Create();
            createDir.Create();
            Assert.IsTrue(Directory.Exists(createDir.Path));

            createDir.Delete();
            Assert.Throws<DirectoryNotFoundException>(()=> createDir.Delete());
            createDir.TryDelete();
        }

        /// <summary>
        /// FilePath
        /// </summary>
        [Test]
        public void FilePath_Test()
        {
            var _answer = Path.Combine(sandBoxFolder.Path, "Test.txt");
            var _path = sandBoxFolder.FilePath("Test.txt");
            Assert.AreEqual(_answer,_path);
            Assert.Throws<FileNotFoundException>(() => sandBoxFolder.FilePath("Test1"));

            _answer = Path.Combine(sandBoxFolder.Path, "Test1.txt");
            _path = sandBoxFolder.FilePath("Test1.txt", false);
            Assert.AreEqual(_answer, _path);
        }
    }
}