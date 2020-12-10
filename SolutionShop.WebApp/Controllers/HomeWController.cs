using ApiIntegration;
using ApiIntegration.Services;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolutionShop.Utilities.Constants;
using SolutionShop.WebApp.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers
{
    public class HomeWController : Controller
    {

        private readonly ILogger<HomeWController> _logger;
        private readonly ISharedCultureLocalizer _loc;
        private readonly ISlideApiClient _slideApiClient;
        private readonly IProductApiClient _produtApiClient;
        
        
        public HomeWController(ISharedCultureLocalizer loc, ILogger<HomeWController> logger, ISlideApiClient slideApiClient, IProductApiClient produtApiClient)
        {
            _logger = logger;
            _loc = loc;
            _slideApiClient = slideApiClient;
            _produtApiClient=produtApiClient  ;
        }

        public async Task<IActionResult> Index()
        {
            var culture = CultureInfo.CurrentCulture.Name;

            var viewModel = new HomeViewModel() 
            {
                Slides = await _slideApiClient.GetAll()
                ,
                FeaturedProducts = await _produtApiClient.GetFeaturedProducts(culture,SystemConstants.ProductSettings.NumberOfFeaturedProduct),
                LastestProducts = await _produtApiClient.GetLastestProducts(culture,SystemConstants.ProductSettings.NumberOfLastestProduct)

            };

            return View(viewModel); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}
