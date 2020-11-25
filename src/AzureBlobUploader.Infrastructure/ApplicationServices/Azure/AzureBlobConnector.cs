using Azure.Storage.Blobs;
using AzureBlobUploader.Application.Services;
using AzureBlobUploader.Application.Services.Azure;

namespace AzureBlobUploader.Infrastructure.ApplicationServices.Azure
{
    internal class AzureBlobConnector : IAzureBlobConnector
    {
        private readonly IFileURLGenerator _fileUrlGenerator;

        public AzureBlobConnector(IFileURLGenerator fileUrlGenerator)
        {
            _fileUrlGenerator = fileUrlGenerator;
        }

        public IAzureBlobConnection Connect(
            string connectionString, 
            string blobContainerName
        )
        {
            var blobServiceClient = new BlobServiceClient(connectionString);

            var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists();

            return new AzureBlobConnection(containerClient, _fileUrlGenerator);
        }
    }
}
