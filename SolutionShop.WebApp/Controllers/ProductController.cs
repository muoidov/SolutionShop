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
            
        public async Task<IActionResult> Detail(int id,string culture)
        {
            var product = await _productApiClient.GetById(id, culture);
            return View(new ProductDetailViewModel()
            {
                Product=product,
                Category=await categoryApiClient.GetById(culture,id)
            });
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
