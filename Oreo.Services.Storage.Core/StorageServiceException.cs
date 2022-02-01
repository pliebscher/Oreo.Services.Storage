using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Oreo.Services.Storage.Core
{
    [Serializable()]
    public class StorageServiceException : Exception
    {
        public StorageServiceException()
        {
        }

        public StorageServiceException(string message) : base(message)
        {
        }

        public StorageServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StorageServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
