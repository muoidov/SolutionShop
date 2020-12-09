using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}
