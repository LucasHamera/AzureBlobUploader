using AzureBlobUploader.Domain.ValueObjects.Exceptions;

namespace AzureBlobUploader.Domain.ValueObjects
{
    public class FileName
    {
        public FileName(
            string name
        )
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BlankFileNameException();

            Name = name;
        }

        public string Name
        {
            get;
        }
    }
}
