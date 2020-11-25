namespace AzureBlobUploader.Application.Services.Configurations
{
    public interface IAzureConfiguration
    {
        public string AccountName
        {
            get;
        }

        public string AccountKey
        {
            get;
        }

        public string ImageBlobName
        {
            get;
        }

        public string ConnectionString
        {
            get;
        }
    }
}
