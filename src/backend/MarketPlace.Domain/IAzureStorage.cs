using Microsoft.AspNetCore.Http;

namespace MarketPlace.Domain;

public interface IAzureStorage
{
    /// <summary>
    /// This method uploads a file submitted with the request
    /// </summary>
    /// <param name="file">File for upload</param>
    /// <param name="pathName"></param>
    /// <returns>Blob with status</returns>
    Task<string> UploadAsync(IFormFile file, string pathName);
}