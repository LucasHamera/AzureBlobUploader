using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobUploader.Application.Services;
using AzureBlobUploader.Application.Services.Azure;
using AzureBlobUploader.Application.Services.Configurations;
using AzureBlobUploader.Domain.ValueObjects;
using File = AzureBlobUploader.Domain.Entities.File;

namespace AzureBlobUploader.Infrastructure.ApplicationServices.Azure
{
    internal class AzureBlobConnection : IAzureBlobConnection
    {
        private readonly BlobContainerClient _blobContainerClient;
        private readonly IFileURLGenerator _fileUrlGenerator;

        public AzureBlobConnection(
            BlobContainerClient blobContainerClient,
            IFileURLGenerator fileUrlGenerator
        )
        {
            _blobContainerClient = blobContainerClient;
            _fileUrlGenerator = fileUrlGenerator;
        }

        public async Task<File> Upload(
            Stream stream,
            string fileName
        )
        {
            var blobHttpHeaders = new BlobHttpHeaders
            {
                ContentType = "image/jpg"
            };

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var fileExtension = Path.GetExtension(fileName);

            var fileGuid = Guid.NewGuid().ToString("N");
            var fileNameWithGuid = $"{fileNameWithoutExtension}_{fileGuid}{fileExtension}";

            var blobClient = _blobContainerClient.GetBlobClient(fileNameWithGuid);
            await blobClient.UploadAsync(stream);
            await blobClient.SetHttpHeadersAsync(blobHttpHeaders);

            var fileAddress = _fileUrlGenerator.Generate(
                _blobContainerClient.Name,
                fileNameWithGuid
            );

            return new File(
                new FileName(fileNameWithGuid),
                new FileAddress(fileAddress)
            );
        }

        public async IAsyncEnumerable<File> GetFiles(
            string blobName
        )
        {
            var blobPages = _blobContainerClient.GetBlobsAsync().AsPages();

            await foreach (var blobPage in blobPages)
            {
                foreach (var blobFile in blobPage.Values)
                {
                    var fileAddress = _fileUrlGenerator
                        .Generate(
                            _blobContainerClient.Name,
                            blobFile.Name
                        );

                    yield return new File(
                        new FileName(blobFile.Name),
                        new FileAddress(fileAddress)
                    );
                }
            }
        }
    }
}
