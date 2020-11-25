using System.Collections.Generic;
using System.Threading.Tasks;
using AzureBlobUploader.Domain.Entities;

namespace AzureBlobUploader.Application.Services.Azure
{
    public interface IAzureBlobConnection
    {
        Task<File> Upload(
            System.IO.Stream stream,
            string fileName
        );

        IAsyncEnumerable<File> GetFiles(
            string blobName
        );
    }
}
