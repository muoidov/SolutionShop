using AdminApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.Catalog.Products;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;
        

        public ProductController( IConfiguration configuration, IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
            
        }
        public async Task<IActionResult> Index(string kw, int pi = 1, int ps = 10)
        {
            var LanguageId=HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var sessions = HttpContext.Session.GetString("Token");
            var request = new MGetProductPagingRequest()
            {

                Keyword = kw,
                PageIndex = pi,
                PageSize = ps,
                LanguageId=LanguageId
            };
            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = kw;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
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
