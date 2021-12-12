using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Estudos.BlobStorage.Settings;
using Microsoft.Extensions.Options;

namespace Estudos.BlobStorage.Services;

public class BlobStorageService
{
    private readonly BlobContainerClient _container;
    public BlobStorageService(IOptions<BlobConnectionString> blobConnectionString,IOptions<BlobSettings> blobSettings)
    {
        _container = new BlobContainerClient(blobConnectionString.Value.StorageAccount, blobSettings.Value.ContainnerName);
        _container.CreateIfNotExists();
    }

    public List<Page<BlobItem>> GetAll()
    {
        var blobs = _container.GetBlobs().AsPages();
        return blobs.ToList();
    }
}
