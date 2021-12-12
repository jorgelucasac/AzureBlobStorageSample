using Azure.Storage.Blobs;
using Estudos.BlobStorage.Services;
using Estudos.BlobStorage.Settings;

namespace Estudos.BlobStorage.Configurations;

public static class BlobStorageConfiguration
{
    public static IServiceCollection ConfigureBlobStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BlobConnectionString>(configuration.GetSection("ConnectionStrings"));
        services.Configure<BlobSettings>(configuration.GetSection("BlobSettings"));
        services.AddScoped<BlobStorageService>();
        return services;
    }
}