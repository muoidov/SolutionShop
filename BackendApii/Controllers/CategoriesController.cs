﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Catalog.Categories;
using System.Threading.Tasks;

namespace BackendApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        
        
            private readonly ICategoryService _categoryService;

            public CategoriesController(ICategoryService categoryService)
            {
                _categoryService = categoryService;

            }
            [HttpGet]
            public async Task<IActionResult> GetAll(string languageId)
            {
                var products = await _categoryService.GetAll(languageId);
                return Ok(products);
            }
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId,int id)
        {
            var products = await _categoryService.GetAll(languageId);
            return Ok(products);
        }
    }
}
