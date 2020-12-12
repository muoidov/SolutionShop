using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Catalog.Products;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Catalog.Products;

using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        //[HttpGet("{languageId}")]
        //public async Task<IActionResult> GetAllPaging(string languageId,[FromQuery]PGetProductPagingRequest request)
        //{
        //    var products = await _productService.GetAllByCategoryId(languageId,request);
        //    return Ok(products);
        //}

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]MGetProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }


        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Ko tim thay product");
            return Ok(product);
        }

        [HttpGet("featured/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts( string languageId,int take)
        {
            var products = await _productService.GetFeaturedProducts(languageId,take);
            return Ok(products);
        }
        [HttpGet("lastest/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLastestProducts(string languageId, int take)
        {
            var products = await _productService.GetLastestProducts(languageId, take);
            return Ok(products);
        }


        // POST api/<ProductController>

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }
        // PUT api/<ProductController>/5
        [HttpPut]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute]int productId,[FromForm] ProductUpdateRequest request)
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = productId;
                var affectrs = await _productService.Update(request);
                if (affectrs == 0)
                    return BadRequest();
                return Ok();
            }

            // DELETE api/<ProductController>/5
            [HttpDelete("{productId}")]
            public async Task<IActionResult> Delete(int productId)
            {
                var affectrs = await _productService.Delete(productId);
                if (affectrs == 0)
                    return BadRequest();
                return Ok();
            }

            [HttpPatch("price/{productId}/{newPrice}")]
            public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
            {
                var isSuccess = await _productService.UpdatePrice(productId, newPrice);
                if (isSuccess)
                    return Ok();
                return BadRequest();
            }
            //image create
            [HttpPost("{productId}/images")]
            public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var imageId = await _productService.AddImage(productId, request);
                if (imageId == 0)
                    return BadRequest();
                var image = await _productService.GetImageById(imageId);
                return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
            }
            [HttpPut("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var rs = await _productService.UpdateImage(imageId, request);
                if (rs == 0)
                    return BadRequest();

                return Ok();
            }
            [HttpDelete("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> RemoveImage(int imageId)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var rs = await _productService.RemoveImages(imageId);
                if (rs == 0)
                    return BadRequest();

                return Ok();
            }

            [HttpGet("{productId}/image/{imageId}")]
            public async Task<IActionResult> GetImageById(int productId, int imageId)
            {
                var image = await _productService.GetImageById(imageId);
                if (image == null)
                    return BadRequest("Ko tim thay product");
                return Ok(image);
            }
        }
    }
