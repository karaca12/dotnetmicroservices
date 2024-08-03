using OrderService.Clients.Abstract;
using System.Net.Http;
using System.Text.Json;

namespace OrderService.Clients.Concrete
{
    public class ProductClient:IProductClient
    {
        private readonly HttpClient _httpClient;
        public ProductClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetProductPriceByIdAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5001/api/Product/{productId}/price");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Product service didn't return the price.");
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<decimal>(content);
        }
    }
}
