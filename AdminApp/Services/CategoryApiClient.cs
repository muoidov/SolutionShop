using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public class CategoryApiClient  :BaseApiClient , ICategoryApiClient
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IConfiguration _configuration;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {

        }
        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            return await GetAsync<List<CategoryVm>>("/api/Categories?languageId="+languageId);
        
    }
}}
