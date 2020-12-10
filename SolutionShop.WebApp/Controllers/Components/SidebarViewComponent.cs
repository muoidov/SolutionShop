using ApiIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers.Components
{

    public class SidebarViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;
        public SidebarViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync() {
            var items=await _categoryApiClient.GetAll(CultureInfo.CurrentCulture.Name);
            return View(items);
    } 
}
}
