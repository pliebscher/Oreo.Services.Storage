using System;
using System.Collections.Generic;
using System.IO;

using Oreo.Services.Storage.Core;

namespace Oreo.Services.Storage.Azure
{
    /// <summary>
    /// 
    /// </summary>
    public class AzureBlobStorageService : IStorageService
    {
        public void Delete(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> List()
        {
            throw new NotImplementedException();
        }

        public MemoryStream Load(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save(MemoryStream fileData, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
