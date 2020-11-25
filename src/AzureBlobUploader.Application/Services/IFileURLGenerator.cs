namespace AzureBlobUploader.Application.Services
{
    public interface IFileURLGenerator
    {
        string Generate(
            string blobName,
            string fileName
        );
    }
}
