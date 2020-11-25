using AzureBlobUploader.Application.Services;
using AzureBlobUploader.Application.Services.Azure;
using AzureBlobUploader.Application.Services.Configurations;
using AzureBlobUploader.Infrastructure.ApplicationServices;
using AzureBlobUploader.Infrastructure.ApplicationServices.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobUploader.Infrastructure
{
    public static class RegisterExtensions
    {
        public static IServiceCollection RegisterInfrastructure(
            this IServiceCollection serviceCollection
        )
        {
            // Azure services
            serviceCollection.AddScoped<IAzureBlobConnector, AzureBlobConnector>();
            serviceCollection.AddScoped<IAzureBlobConnection>( x =>
            {
                var connector = x.GetRequiredService<IAzureBlobConnector>();
                var configuration = x.GetRequiredService<IAzureConfiguration>();

                return connector.Connect(configuration.ConnectionString, configuration.ImageBlobName);
            });

            serviceCollection.AddScoped<IFileURLGenerator, FileURLGenerator>();

            // Image services
            serviceCollection.AddScoped<IImageUploader, ImageUploader>();
            serviceCollection.AddScoped<IImageListRequester, ImageListRequester>();

            return serviceCollection;
        }
    }
}
