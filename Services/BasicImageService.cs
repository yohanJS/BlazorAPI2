using Microsoft.AspNetCore.Http;

namespace WebApiPoc.Services
{
    public class BasicImageService : IImageService
    {
        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null) return string.Empty;

            string imageBase64Data = Convert.ToBase64String(fileData);
            return $"data:{extension};base64,{imageBase64Data}";
        }

        public async Task<List<byte[]>> ConvertFilesToByteArrayAsync(List<IFormFile> files)
        {
            List<byte[]> byteFiles = new List<byte[]>();

            foreach (var file in files)
            {
                using MemoryStream memoryStream = new();
                await file.CopyToAsync(memoryStream);
                byte[] byteFile = memoryStream.ToArray();
                byteFiles.Add(byteFile);
            }

            return byteFiles;
        }
    }
}
