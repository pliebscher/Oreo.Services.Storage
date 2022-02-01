using System.IO;
using System.Collections.Generic;

namespace Oreo.Services.Storage.Core
{
    /// <summary>
    /// Defines basic storge service functions.
    /// </summary>
    /// <remarks>
    /// fileName(s) should include a path relative to the root of the Store. e.g. "some\path\filename.ext"
    /// </remarks>
    public interface IStorageService
    {
        /// <summary>
        /// Returns a list of files in the Store.
        /// </summary>
        IEnumerable<string> List();

        /// <summary>
        /// Loads a file from the Store.
        /// </summary>
        /// <param name="fileName"></param>
        MemoryStream Load(string fileName);

        /// <summary>
        /// Saves a file to the Store.
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="fileName"></param>
        void Save(MemoryStream fileData, string fileName);

        /// <summary>
        /// Checks if a file exists in the Store.
        /// </summary>
        /// <param name="fileName"></param>
        bool Exists(string fileName);

        /// <summary>
        /// Deletes a file from the Store.
        /// </summary>
        /// <param name="fileName"></param>
        void Delete(string fileName);
    }
}
