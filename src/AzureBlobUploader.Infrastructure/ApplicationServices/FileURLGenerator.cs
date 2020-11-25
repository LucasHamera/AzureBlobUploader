using AzureBlobUploader.Application.Services;
using AzureBlobUploader.Application.Services.Configurations;

namespace AzureBlobUploader.Infrastructure.ApplicationServices
{
    internal class FileURLGenerator : IFileURLGenerator
    {
        private readonly IAzureConfiguration _azureConfiguration;

        public FileURLGenerator(
            IAzureConfiguration azureConfiguration
        )
        {
            _azureConfiguration = azureConfiguration;
        }

        public string Generate(
            string blobName, 
            string fileName
        )
        {
            return
                $"https://{_azureConfiguration.AccountName}.blob.core.windows.net/{_azureConfiguration.ImageBlobName}/{fileName}";
        }
    }
}
