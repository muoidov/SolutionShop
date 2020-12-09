using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Languages;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}
