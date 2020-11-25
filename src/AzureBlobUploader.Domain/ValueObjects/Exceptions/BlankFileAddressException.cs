namespace AzureBlobUploader.Domain.ValueObjects.Exceptions
{
    public class BlankFileAddressException : DomainException
    {
        // TODO exception message localization - exception code or sth.
        private const string ExceptionMessage = "Blank file address.";

        public BlankFileAddressException()
            : base(ExceptionMessage)
        {

        }
    }
}
