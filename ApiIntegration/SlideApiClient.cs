using ApiIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SolutionShop.ViewModel.Ultilities.Slides;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiIntegration
{
    public class SlideApiClient : BaseApiClient, ISlideApiClient
    {
        
            public SlideApiClient(IHttpClientFactory httpClientFactory,
                       IHttpContextAccessor httpContextAccessor,
                        IConfiguration configuration)
                : base(httpClientFactory, httpContextAccessor, configuration)
            {
            }
            public async Task<List<SlideVm>> GetAll()
            {
                return await GetListAsync<SlideVm>("/api/Slides");
            }
        }
    }


