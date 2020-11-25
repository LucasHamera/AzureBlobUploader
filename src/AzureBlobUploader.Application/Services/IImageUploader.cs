using System.IO;
using System.Threading.Tasks;
using AzureBlobUploader.Domain.Entities;

namespace AzureBlobUploader.Application.Services
{
    public interface IImageUploader
    {
        Task<Image> UploadAsync(
            Stream imageStream,
            string imageName
        );
    }
}
