using AzureBlobUploader.Application.Services.Configurations;

namespace AzureBlobUploader.BlazorSignalR.Configurations
{
    internal class AzureConfiguration : IAzureConfiguration
    {
        public string AccountName
        {
            get;
            set;
        }

        public string AccountKey 
        { 
            get;
            set;
        }

        public string ImageBlobName
        {
            get;
            set;
        }

        public string ConnectionString 
            => $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={AccountKey};EndpointSuffix=core.windows.net";
    }
}
