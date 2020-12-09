using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Languages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public class LanguageApiClient : BaseApiClient,ILanguageApiClient
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IConfiguration _configuration;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public LanguageApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory,httpContextAccessor, configuration)
        {
            
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageVm>>>("/api/languages");
        }
    }
}
