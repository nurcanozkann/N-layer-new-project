using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class CategoryApiService:HttpClient
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomReponseDto<List<CategoryDto>>>("categories");

            return response.Data;
        }

    }
}
