namespace AzureBlobUploader.Domain.ValueObjects.Exceptions
{
    public class BlankFileNameException : DomainException
    {
        // TODO exception message localization - exception code or sth.
        private const string ExceptionMessage = "Blank file name.";

        public BlankFileNameException()
            : base(ExceptionMessage)
        {

        }
    }
}
