using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public class ProductApiClient: BaseApiClient,IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
       private readonly IConfiguration _configuration;
        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor):
            base(httpClientFactory, httpContextAccessor,configuration)
        {
            _httpContextAccessor= httpContextAccessor;
            _httpClientFactory= httpClientFactory;
            _configuration = configuration;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            
            
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration["BaseAddress"]);
                var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
                var json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/api/Products/{id}/Categories", httpContent);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

                return JsonConvert.DeserializeObject<ApiError<bool>>(result);
            
        }

      

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);
            var LanguageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnailImage", request.ThumbnailImage.FileName);
            }
            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.Description.ToString()), "description");
            requestContent.Add(new StringContent(request.Details.ToString()), "details");
            requestContent.Add(new StringContent(request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(LanguageId), "languageId");
            //requestContent.Add(new StringContent(request.LanguageId.ToString()), "languageid");
            var response = await client.PostAsync($"/api/Products/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public  async Task<ProductViewModel> GetById(int id,string languageId)
        {
            var data = await GetAsync<ProductViewModel>($"/api/products/{id}/{languageId}");
            return data;
        }

        public async Task<List<ProductViewModel>> GetFeaturedProducts( string languageId,int take)
        {
            var data = await GetListAsync<ProductViewModel>($"/api/products/featured/{languageId}/{take}");
            return data;
        }

        public async Task<List<ProductViewModel>> GetLastestProducts(string languageId, int take)
        {
            var data = await GetListAsync<ProductViewModel>($"/api/products/lastest/{languageId}/{take}");
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetPagings(MGetProductPagingRequest request)
        {
 var data = await GetAsync<PagedResult<ProductViewModel>>
 ($"/api/Products/paging?PageIndex={request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}&LanguageId={request.LanguageId}&categoryId={request.CategoryId}");
          
            return data;
        }
    }
}
