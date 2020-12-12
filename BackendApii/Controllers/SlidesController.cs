using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Ultilities.Slides;
using System.Threading.Tasks;

namespace BackendApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class SlidesController : ControllerBase
    {
        private readonly ISlideService _SlideService;
        public SlidesController(ISlideService SlideService)
        {
            _SlideService = SlideService; 
        }
        // GET: api/<SlidesController>
        [HttpGet]
        [AllowAnonymous]    
        public async Task<IActionResult> GetAll()
        {
            var Slides = await _SlideService.GetAll();
            return Ok(Slides);
        }

        
    }
}
