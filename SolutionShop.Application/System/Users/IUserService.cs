using SolutionShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Auhthencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
