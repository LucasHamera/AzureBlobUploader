using AzureBlobUploader.Application.Services.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobUploader.Application
{
    public static class RegisterExtensions
    {
        public static IServiceCollection RegisterApplication(
            this IServiceCollection serviceCollection,
            IAzureConfiguration azureConfiguration
        )
        {
            serviceCollection
                .AddSingleton(azureConfiguration);

            return serviceCollection;
        }
    }
}
