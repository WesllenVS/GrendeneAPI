using MakeupAPI.Data;
using MakeupAPI.Interface;
using System.Net.Http;
using System.Text.Json;

namespace MakeupAPI.Services.ProductsServices
{
    public class ProductsService : IProductsInterface
    {
        private readonly HttpClient _httpClient;

        public ProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<object>> GetProductsAsync()
        {
            var resposta = await _httpClient.GetAsync("https://makeup-api.herokuapp.com/api/v1/products.json");
            resposta.EnsureSuccessStatusCode();


            var jsonString = await resposta.Content.ReadAsStringAsync();
            var produtos = JsonSerializer.Deserialize<IEnumerable<object>>(jsonString);

            return produtos;
        }
    }
}
