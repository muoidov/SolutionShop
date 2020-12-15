﻿using SolutionShop.Data.EF;
using SolutionShop.ViewModel.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SolutionShop.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly Shopdbcontext _context;
        public CategoryService(Shopdbcontext context)
        {
            _context=context;
        }
        public async Task<List<CategoryVm>> GetAll(string languageId)
        {

            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParenId
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParenId
            }).FirstOrDefaultAsync();
        }
    
}
}
