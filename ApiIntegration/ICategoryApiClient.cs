using SolutionShop.ViewModel.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public interface ICategoryApiClient
    {
        public Task<List<CategoryVm>> GetAll(string languageId);
    }
}
