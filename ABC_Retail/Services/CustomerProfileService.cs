using Azure.Data.Tables;
using ABC_Retail.Models;

namespace ABC_Retail.Services
{
    public class CustomerProfileService
    {
        private readonly TableClient _tableClient;

        public CustomerProfileService(IConfiguration config)
        {
            string connectionString = config.GetConnectionString("AzureStorage");
            var serviceClient = new TableServiceClient(connectionString);
            _tableClient = serviceClient.GetTableClient("CustomerProfiles");
            _tableClient.CreateIfNotExists();
        }
       

        public async Task AddCustomerProfileAsync(CustomerProfile profile)
        {
            await _tableClient.AddEntityAsync(profile);
        }

        public async Task<CustomerProfile?> GetCustomerProfileAsync(string email)
        {
            return await _tableClient.GetEntityAsync<CustomerProfile>("Customer", email);
        }
    }
}
