

using Azure.Storage.Blobs;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace LibraryManagementSystem.Infrastructure.Storage;

public class BlobStorageService(IOptions<BlobStorageSettings> blobStorageSettingsOptions) : IBlobStorageService
{
    private readonly BlobStorageSettings _blobStorageSettings = blobStorageSettingsOptions.Value;
    public async Task<string> UploadBlobAsync(Stream data, string fileName)
    {
        try
        {

            var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.CoverImageContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(data, overwrite: true);
            var blobUrl = blobClient.Uri.ToString();
            return blobUrl;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Blob upload failed: {ex.Message}");
            throw;
        }
    }
}
