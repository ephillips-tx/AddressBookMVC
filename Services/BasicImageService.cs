using AddressBookMVC.Services.Interfaces;

namespace AddressBookMVC.Services
{
    public class BasicImageService : IImageService
    {
        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null) return string.Empty;

            string imageBase64Data = Convert.ToBase64String(fileData);
            return $"data:{extension};base64,{imageBase64Data}";
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            //turns image into a byte array, controls memory use and returns the byte array. 
            using MemoryStream memoryStream = new();
            await file.CopyToAsync(memoryStream);
            byte[] byteFile = memoryStream.ToArray();

            return byteFile;
        }
    }
}
