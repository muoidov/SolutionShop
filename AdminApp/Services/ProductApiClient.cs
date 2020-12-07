using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public class ProductApiClient: BaseApiClient,IProductApiClient
    {
       
        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor):
            base(httpClientFactory,configuration,httpContextAccessor)
        {
            
        }
        public async Task<PagedResult<ProductViewModel>> GetPagings(MGetProductPagingRequest request)
        {
 var data = await GetAsync<PagedResult<ProductViewModel>>
 ($"/api/Products/paging?PageIndex={request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}&LanguageId={request.LanguageId}");
          
            return data;
        }
    }
}
