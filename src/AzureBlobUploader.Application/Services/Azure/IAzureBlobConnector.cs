using System.Threading.Tasks;

namespace AzureBlobUploader.Application.Services.Azure
{
    public interface IAzureBlobConnector
    {
        IAzureBlobConnection Connect(
            string connectionString,
            string blobContainerName
        );
    }
}
