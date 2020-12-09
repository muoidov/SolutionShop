using ApiIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        private readonly ICategoryApiClient _categoryApiClient;
        public ProductController( IConfiguration configuration, IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
            _configuration = configuration;
            
        }
        public async Task<IActionResult> Index(string kw,int? ct, int pi = 1, int ps = 10)
        {
            var LanguageId=HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var sessions = HttpContext.Session.GetString("Token");
            var request = new MGetProductPagingRequest()
            {
                Keyword = kw,
                PageIndex = pi,
                PageSize = ps,
                LanguageId=LanguageId,
                CategoryId=ct
            };
            var data = await _productApiClient.GetPagings(request);
            var categories = await _categoryApiClient.GetAll(LanguageId);
            ViewBag.Keyword = kw;
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected=ct.HasValue&&ct.Value==x.Id
            });
            
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var roleAssignRequest = await GetCategoryAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetCategoryAssignRequest(request.Id);

            return View(roleAssignRequest);
        }

        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var productObj = await _productApiClient.GetById(id, languageId);
            var categories = await _categoryApiClient.GetAll(languageId);
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var role in categories)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Selected = productObj.Categories.Contains(role.Name)
                });
            }
            return categoryAssignRequest;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
                }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async  Task<IActionResult> Create([FromForm]ProductCreateRequest request)

        {
            if (!ModelState.IsValid)
                return View(request);
            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }

    }
}
