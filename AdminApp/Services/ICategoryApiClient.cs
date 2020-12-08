using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public interface ICategoryApiClient
    {
        public Task<List<CategoryVm>> GetAll(string languageId);
    }
}
