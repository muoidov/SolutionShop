using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languagesService;
        
        public LanguagesController(ILanguageService languageService)
        {
            _languagesService = languageService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllPaging()
        {
            var products = await _languagesService.GetAll();
            return Ok(products);
        }

    }
}
