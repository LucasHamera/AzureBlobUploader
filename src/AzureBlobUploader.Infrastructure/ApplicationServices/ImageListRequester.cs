using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AzureBlobUploader.Application.Services;
using AzureBlobUploader.Application.Services.Azure;
using AzureBlobUploader.Application.Services.Configurations;
using AzureBlobUploader.Domain.Entities;
using AzureBlobUploader.Domain.ValueObjects;

namespace AzureBlobUploader.Infrastructure.ApplicationServices
{
    internal class ImageListRequester : IImageListRequester
    {
        private readonly IAzureBlobConnection _azureBlobConnection;
        private readonly IAzureConfiguration _azureConfiguration;

        public ImageListRequester(
            IAzureBlobConnection azureBlobConnection,
            IAzureConfiguration azureConfiguration
        )
        {
            _azureBlobConnection = azureBlobConnection;
            _azureConfiguration = azureConfiguration;
        }

        public async IAsyncEnumerable<Image> Get()
        {
            await foreach (var file in _azureBlobConnection.GetFiles(_azureConfiguration.ImageBlobName))
            {
                yield return new Image(
                    new ImageName(file.Name),
                    new FileAddress(file.Address)
                );
            }
        }
    }
}
