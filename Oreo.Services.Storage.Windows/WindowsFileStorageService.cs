using System;
using System.Collections.Generic;
using System.IO;

using Oreo.Services.Storage.Core;

namespace Oreo.Services.Storage.Windows
{
    /// <summary>
    /// A service for reading and writing file on a Windows filesystem (FAT32, NTFS, etc.) host.
    /// </summary>
    public class WindowsFileStorageService : IStorageService
    {
        private string _basePath = string.Empty;

        /// <summary>
        /// Constructs an instance of the WindowsFileStorageService.
        /// </summary>
        /// <param name="basePath">Path where files are written and read from.</param>
        public WindowsFileStorageService(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath)) throw new ArgumentNullException("basePath");
            _basePath = basePath;
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="fileName"></param>
        public void Delete(string fileName)
        {
            string fullPath = Path.Combine(_basePath, fileName);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fileName);
            File.Delete(fullPath);
        }

        /// <summary>
        /// Checks if a file exists.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>True is file exists, otherwise False.</returns>
        public bool Exists(string fileName)
        {
            string fullPath = Path.Combine(_basePath, fileName);
            return File.Exists(fullPath);
        }

        /// <summary>
        /// Returns a list of files in the storage location.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> List()
        {
            List<string> files = new List<string>();
            foreach (string file in Directory.GetFiles(_basePath))
            {
                files.Add(Path.GetFileName(file));
            }
            return files;
        }

        /// <summary>
        /// Loads a file from the underlying store.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public MemoryStream Load(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException("fileName");

            string fullPath = Path.Combine(_basePath, fileName);

            if (!File.Exists(fullPath)) throw new FileNotFoundException(fileName);

            MemoryStream ms = new MemoryStream();
            using (FileStream fs = new FileStream(fullPath, FileMode.Open))
            {
                fs.CopyTo(ms);
            }
            return ms;
        }

        /// <summary>
        /// Writes a file to the underlying store.
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="fileName"></param>
        public void Save(MemoryStream fileData, string fileName)
        {
            if (fileData == null) throw new ArgumentNullException("fileData");
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException("fileName");

            string fullPath = Path.Combine(_basePath, Path.GetFileName(fileName));

            if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            using (FileStream fs = new FileStream(fullPath, FileMode.CreateNew))
            {
                fileData.CopyTo(fs);
            }
        }
    }
}
