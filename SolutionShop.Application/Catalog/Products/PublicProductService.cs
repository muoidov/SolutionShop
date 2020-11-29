﻿
//using SolutionShop.Application.Catalog.Products.Dtos.Mangage;
using SolutionShop.Application.Catalog.Products.Dtos;
using SolutionShop.Application.Dtos;
using SolutionShop.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolutionShop.Application.Catalog.Products.Dtos.Mangage;

namespace SolutionShop.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly Shopdbcontext _context;
        public PublicProductService(Shopdbcontext context)
        {
            _context = context;
        }


        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt };
            //loc
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            //paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip(request.PageIndex - 1 * request.PageSize).Take(request.PageSize).Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                Name = x.pt.Name,
                DateCreated = x.p.DateCreated,
                Description = x.pt.Description,
                LanguageId = x.pt.LanguageId,
                OriginalPrice = x.p.OriginalPrice,
                Price = x.p.Price,
                SeoAlias = x.pt.SeoAlias,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoDescription,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount
            }).ToListAsync();
            //chon project

            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;

        }
    }
}
