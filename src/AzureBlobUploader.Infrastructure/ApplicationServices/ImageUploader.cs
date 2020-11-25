using System.IO;
using System.Threading.Tasks;
using AzureBlobUploader.Application.Services;
using AzureBlobUploader.Application.Services.Azure;
using AzureBlobUploader.Domain.Entities;
using AzureBlobUploader.Domain.ValueObjects;

namespace AzureBlobUploader.Infrastructure.ApplicationServices
{
    internal class ImageUploader : IImageUploader
    {
        private readonly IAzureBlobConnection _azureBlobConnection;

        public ImageUploader(
            IAzureBlobConnection azureBlobConnection
        )
        {
            _azureBlobConnection = azureBlobConnection;
        }

        public async Task<Image> UploadAsync(
            Stream imageStream, 
            string imageName
        )
        {
            var file = await _azureBlobConnection.Upload(
                imageStream,
                imageName
            );

            return new Image(
                new ImageName(file.Name),
                new FileAddress(file.Address)
            );
        }
    }
}
