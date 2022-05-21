using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using RealtimeGraphWithHostedService.Models;

namespace RealtimeGraphWithHostedService.Services
{
    public class StockData : IStockData
    {
        public IHttpClientFactory _httpClientFactory { get; }
        public StockData(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductModel> GetStockData(int productid)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var url = $"https://dummyjson.com/products/{productid}"; // dummy api call for demo
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<ProductModel>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                //log error
                throw;
              
            }
        }
    }
}
