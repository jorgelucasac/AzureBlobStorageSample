using Azure.Storage.Blobs;
using Estudos.BlobStorage.Helper;
using Estudos.BlobStorage.Models;
using Estudos.BlobStorage.Settings;
using Microsoft.Extensions.Options;

namespace Estudos.BlobStorage.Services;

public class BlobContainnerService
{
    private readonly BlobContainerClient _container;

    public BlobContainnerService(BlobServiceClient blobServiceClient, IOptions<ContainnerSettings> blobSettings)
    {
        _container = blobServiceClient.GetBlobContainerClient(blobSettings.Value.Name);
    }

    public async Task<List<BlobItemResponse>> GetAllAsync()
    {
        var blobs = _container.GetBlobsAsync();
        var results = new List<BlobItemResponse>();
        await foreach (var blob in blobs)
            results.Add(new BlobItemResponse
            {
                Name = blob.Name,
                LastModified = blob.Properties.LastModified,
                ContentType = blob.Properties.ContentType,
                Length = blob.Properties.ContentLength
            });

        return results;
    }

    public async Task<BlobItemResponse> UploadAsync(BlobItemUpload upload)
    {
        var unicName = FileHelper.GetUnicName(upload.File.FileName);
        var response = await _container.UploadBlobAsync(unicName, upload.File.OpenReadStream());
        return new BlobItemResponse
        {
            Name = unicName,
            ContentType = upload.File.ContentType,
            Length = upload.File.Length,
            LastModified = response.Value.LastModified
        };
    }

    public async Task<int> DeleteAsync(string name)
    {
        var response = await _container.DeleteBlobAsync(name);
        return response.Status;
    }
}