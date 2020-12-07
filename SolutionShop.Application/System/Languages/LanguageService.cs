
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SolutionShop.Data.EF;
using SolutionShop.Data.Entities;
using SolutionShop.Utilities.Exceptions;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Languages;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
       
        private readonly IConfiguration _config;
        private readonly Shopdbcontext _context;
        
        public LanguageService(IConfiguration config,Shopdbcontext context)
        {
           
            _config = config;
            _context = context;
           
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages= await _context.Languages.Select(x=>new LanguageVm()
                {
                Id=x.Id,
                Name=x.Name
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}
