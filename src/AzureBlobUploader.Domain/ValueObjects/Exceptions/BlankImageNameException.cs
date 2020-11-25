namespace AzureBlobUploader.Domain.ValueObjects.Exceptions
{
    public class BlankImageNameException : DomainException
    {
        // TODO exception message localization - exception code or sth.
        private const string ExceptionMessage = "Blank image name.";

        public BlankImageNameException()
            : base(ExceptionMessage)
        {
            
        }
    }
}
