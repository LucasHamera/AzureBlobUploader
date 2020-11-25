using System;

namespace AzureBlobUploader.Domain
{
    public class DomainException : Exception
    {
        protected DomainException(
            string message
        ) : base(message)
        {
        }
    }
}
