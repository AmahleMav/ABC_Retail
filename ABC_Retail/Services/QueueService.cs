using Azure.Storage.Queues;
using System.Text.Json;

namespace ABC_Retail.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;

        public QueueService(IConfiguration config)
        {
            string connectionString = config.GetConnectionString("AzureStorage");

            _queueClient = new QueueClient(connectionString, "productqueue");
            _queueClient.CreateIfNotExists();
        }

        public async Task SendMessageAsync<T>(T messageObj)
        {
            string messageJson = JsonSerializer.Serialize(messageObj);
            string base64Message = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(messageJson));

            await _queueClient.SendMessageAsync(base64Message);
        }
    }
}
