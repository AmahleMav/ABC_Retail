using Azure.Storage.Blobs;

namespace ABC_Retail.Services
{
    public class ProductImageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "productimage"; 

        public ProductImageService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorage");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadImageAsync(Stream fileStream, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStream, overwrite: true);

            return blobClient.Uri.ToString();
        }

        public async Task DeleteImageAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<List<string>> ListImagesAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var images = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                var blobClient = containerClient.GetBlobClient(blobItem.Name);
                images.Add(blobClient.Uri.ToString());
            }

            return images;
        }
    }
}
