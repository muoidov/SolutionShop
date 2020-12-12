using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SolutionShop.ViewModel.Catalog.Categories;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public class CategoryApiClient  :BaseApiClient , ICategoryApiClient
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IConfiguration _configuration;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration )
        {

        }
        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            return await GetAsync<List<CategoryVm>>("/api/Categories?languageId="+languageId);
        
    }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            return await GetAsync<CategoryVm>($"/api/Categories/{id}/{languageId}");
        }
    }
}
