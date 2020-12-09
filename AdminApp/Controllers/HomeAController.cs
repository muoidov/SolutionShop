using AdminApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolutionShop.Utilities.Constants;
using System.Diagnostics;

namespace AdminApp.Controllers
{
    //[Authorize]
    public class HomeAController : BaseController 
    {
        private readonly ILogger<HomeAController> _logger;

        public HomeAController(ILogger<HomeAController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            return View(); 
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
        [HttpPost]
        public IActionResult Language(NavigationViewModel viewModel)
        {
            HttpContext.Session.SetString(SystemConstants.AppSettings.DefaultLanguageId, viewModel.CurrentLanguageId);
            return RedirectToAction("Index");
        }
    }
}
