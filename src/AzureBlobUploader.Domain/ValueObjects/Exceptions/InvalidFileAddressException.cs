namespace AzureBlobUploader.Domain.ValueObjects.Exceptions
{
    public class InvalidFileAddressException : DomainException
    {      
        // TODO exception message localization - exception code or sth.
        private const string ExceptionMessage = "Invalid file address.";

        public InvalidFileAddressException() 
            : base(ExceptionMessage)
        {
        }
    }
}
