using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolutionShop.Data.EF;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Languages;
using System.Collections.Generic;
using System.Linq;
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
