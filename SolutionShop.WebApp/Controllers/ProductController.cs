using ApiIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.WebApp.Models;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient categoryApiClient;

        public ProductController  (IProductApiClient productApiClient,ICategoryApiClient categoryApiClient) {
            _productApiClient = productApiClient;
            this.categoryApiClient = categoryApiClient;
        }
            
        public IActionResult Detail(int id)
        {
            
            return View();
        }

        public async Task<IActionResult> Category(int id, string culture, int page = 1)
        {
            var products = await _productApiClient.GetPagings(new MGetProductPagingRequest
            {
                CategoryId = id,
                PageIndex = page,
                LanguageId = culture,
                PageSize=10

            });
            return View(new ProductCategoryViewModel() {
            Category=await categoryApiClient.GetById(culture,id),
            Products=products

            });
        }
    }
}
