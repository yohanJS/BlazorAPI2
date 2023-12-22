using Microsoft.AspNetCore.Http;

namespace WebApiPoc.Services
{
    public interface IImageService
    {
        Task<List<byte[]>> ConvertFilesToByteArrayAsync(List<IFormFile> files);
        string ConvertByteArrayToFile(byte[] fileData, string extension);

    }
}
