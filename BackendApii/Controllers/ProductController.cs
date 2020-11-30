using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Catalog.Products;
using SolutionShop.ViewModel.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService1;
        private readonly IManageProductService _publicManageService1;
        public ProductController(IPublicProductService publicProductService,IManageProductService manageProductService)
        {
            _publicProductService1 = publicProductService;
            _publicManageService1 = manageProductService;
        }
        // GET: api/<ProductController>
        [HttpGet("{languageId}")] 
        public async Task<IActionResult> Get(string languageId)
        {
            var products = await _publicProductService1.GetAll(languageId);
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("public-paging/{languageId}")]
        public async Task<IActionResult> Get([FromQuery]PGetProductPagingRequest request)
        {
            var products = await _publicProductService1.GetAllByCategoryId(request);
            return Ok(products);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id,string languageId)
        {
            var product = await _publicManageService1.GetById(id,languageId);
            if (product == null)
                return BadRequest("Ko tim thay product");
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)  
        {
            var products = await _publicManageService1.Create(request);
            if (products == 0)
                return BadRequest();
            var product = await _publicManageService1.GetById(products,request.LanguageId);
            return CreatedAtAction(nameof(GetById),new { id=products},product);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]ProductUpdateRequest request)
        {
            var affectrs = await _publicManageService1.Update(request);
            if (affectrs == 0)
                return BadRequest();
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectrs = await _publicManageService1.Delete(id);
            if (affectrs == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id,decimal newPrice)
        {
            var isSuccess= await _publicManageService1.UpdatePrice(id,newPrice);
            if (isSuccess)   
            return Ok();
            return BadRequest();
        }
    }
}
