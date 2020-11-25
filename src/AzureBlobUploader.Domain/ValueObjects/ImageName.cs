using AzureBlobUploader.Domain.ValueObjects.Exceptions;

namespace AzureBlobUploader.Domain.ValueObjects
{
    public class ImageName
    {
        public ImageName(
            string name
        )
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BlankImageNameException();

            Name = name;
        }

        public ImageName(
            FileName fileName
        )
        {
            Name = fileName.Name;
        }

        public string Name
        {
            get;
        }
    }
}
