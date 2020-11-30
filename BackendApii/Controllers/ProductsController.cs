using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Catalog.Products;
using SolutionShop.ViewModel.Catalog.ProductImages;
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
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService1;
        private readonly IManageProductService _publicManageService1;
        public ProductsController(IPublicProductService publicProductService,IManageProductService manageProductService)
        {
            _publicProductService1 = publicProductService;
            _publicManageService1 = manageProductService;
        }
        // GET: api/<ProductController>
        //[HttpGet("{languageId}")] 
        //public async Task<IActionResult> GetAll(string languageId)
        //{
        //    var products = await _publicProductService1.GetAll(languageId);
        //    return Ok(products);
        //}

        // GET api/<ProductController>/5
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId,[FromQuery]PGetProductPagingRequest request)
        {
            var products = await _publicProductService1.GetAllByCategoryId(languageId,request);
            return Ok(products);
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId,string languageId)
        {
            var product = await _publicManageService1.GetById(productId,languageId);
            if (product == null)
                return BadRequest("Ko tim thay product");
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)  
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectrs = await _publicManageService1.Delete(productId);
            if (affectrs == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("price/{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId,decimal newPrice)
        {
            var isSuccess= await _publicManageService1.UpdatePrice(productId,newPrice);
            if (isSuccess)   
            return Ok();
            return BadRequest();
        }
        //image create
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId,[FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _publicManageService1.AddImage(productId,request);
            if (imageId == 0)
                return BadRequest();
            var image = await _publicManageService1.GetImageById(imageId);
            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }
        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rs = await _publicManageService1.UpdateImage(imageId, request);
            if (rs == 0)
                return BadRequest();

            return Ok();
        }
        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rs = await _publicManageService1.RemoveImages(imageId);
            if (rs == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{productId}/image/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _publicManageService1.GetImageById(imageId);
            if (image == null)
                return BadRequest("Ko tim thay product");
            return Ok(image);
        }
    }
}
