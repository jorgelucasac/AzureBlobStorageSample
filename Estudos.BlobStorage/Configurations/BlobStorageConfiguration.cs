using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Estudos.BlobStorage.Services;
using Estudos.BlobStorage.Settings;
using Microsoft.Extensions.Azure;

namespace Estudos.BlobStorage.Configurations;

public static class BlobStorageConfiguration
{
    public static IServiceCollection ConfigureBlobStorage(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<ContainnerSettings>(configuration.GetSection("ContainnerSettings"));

        services.AddAzureClients(builder =>
        {
            builder.AddBlobServiceClient(configuration.GetConnectionString("StorageAccount"));
        });

        services.AddScoped<EstudosContainnerService>();
        return services;
    }
}