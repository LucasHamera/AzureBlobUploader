using AzureBlobUploader.Domain.Entities;
using System.Collections.Generic;

namespace AzureBlobUploader.Application.Services
{
    public interface IImageListRequester
    {
        IAsyncEnumerable<Image> Get();
    }
}
