using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CreditApp.Domain;
using Microsoft.AspNetCore.Http;


namespace CreditApp.Infrastructure.Repositories;

public class BlobRepository : IAzureStorage
{
    private BlobServiceClient BlobStorage { get; set; }

    public BlobRepository(BlobServiceClient blobStorage)
    {
        this.BlobStorage = blobStorage;
    }

    public async Task<string> UploadAsync(IFormFile file, string pathName)
    {
        var blobContainer = BlobStorage.GetBlobContainerClient("corpentunida");
 
        var blobClient = blobContainer.GetBlobClient(pathName);
 
        var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };
        
        var blobInfo = await blobClient.UploadAsync(file.OpenReadStream(),new BlobUploadOptions{HttpHeaders = blobHttpHeader});

        return blobClient.Uri.AbsoluteUri;
    }
    
}