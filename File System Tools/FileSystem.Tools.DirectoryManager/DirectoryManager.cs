using System;
using System.IO;

namespace FileSystem.Tools
{
    public class DirectoryManager
    {
        public readonly string Path;

        public DirectoryManager(string path, bool exist = true)
        {
            if (exist && !Directory.Exists(path))
            {
                throw new DirectoryNotFoundException("Не найдена папка:" + path);
            }
            Path = path;
        }

        public string FilePath(string fileName, bool exist = true)
        {
            string _path = System.IO.Path.Combine(Path, fileName);
            if (exist && !System.IO.File.Exists(_path))
            {
                throw new DirectoryNotFoundException("Файл не найден: " + _path);
            }

            return _path;
        }

        public DirectoryManager SubDirectory(string name, bool exist = true)
        {
            string _path = System.IO.Path.Combine(Path, name);
            if (exist && !System.IO.Directory.Exists(_path))
            {
                throw new DirectoryNotFoundException("Под папка не найдена: " + _path);
            }
            return new DirectoryManager(_path, exist);
        }

        public DirectoryManager Delete(bool recursive = false)
        {
            Directory.Delete(Path, recursive);
            return this;
        }

        public DirectoryManager TryDelete(bool recursive = false)
        {
            return Directory.Exists(Path) ? Delete(recursive) : this;
        }

        public DirectoryManager Create()
        {
            Directory.CreateDirectory(Path);
            return this;
        }

        public DirectoryManager TryCreate()
        {
            return Directory.Exists(Path) ? Create() : this;
        }
    }
}
