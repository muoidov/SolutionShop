using Microsoft.EntityFrameworkCore;
using SolutionShop.Application.Catalog.Manage.Products.Dtos;
using SolutionShop.Application.Catalog.Products.Dtos;
using SolutionShop.Application.Dtos;
using SolutionShop.Data.EF;
using SolutionShop.Data.Entities;
using SolutionShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        //chi doc
        private readonly Shopdbcontext _context;
        public ManageProductService(Shopdbcontext context)
        {
            _context = context;
        }

        public async Task AddViewCount(int productId)
        {
            var product =await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
           await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice=request.OriginalPrice,
                Stock=request.Stock,
                ViewCount=0,
                DateCreated=DateTime.Now,
                ProductTranslations=new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name=request.Name,
                        Description=request.Description,
                        Details=request.Details,
                        SeoDescription=request.SeoDescription,
                        SeoAlias=request.SeoAlias,
                        SeoTitle=request.SeoTitle,
                        LanguageId=request.LanguageId
                    }
                }


            };
            //dung async tan dang thread chuong trinh chay ngon hon
            _context.Products.Add(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new Shopexception($"Không thể tìm thấy:{productId}");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //tim kiem
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new {p,pt };
            //loc
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => p.pic.CategoryIds.Contains(p.pic.CategoryId));
            }
            //paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip(request.PageIndex - 1*request.PageSize).Take(request.PageSize).Select(x=>new ProductViewModel() {Id=x.p.Id,
            Name=x.pt.Name,DateCreated=x.p.DateCreated,Description=x.pt.Description,
            LanguageId=x.pt.LanguageId,
            OriginalPrice=x.p.OriginalPrice,
            Price=x.p.Price,
            SeoAlias=x.pt.SeoAlias,
            SeoDescription=x.pt.SeoDescription,
            SeoTitle=x.pt.SeoDescription,
            Stock=x.p.Stock,
            ViewCount=x.p.ViewCount}).ToListAsync();
            //chon project

            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;

        }
        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.Find(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id&&
            x.LanguageId==request.LanguageId);
            if(product==null || productTranslations==null) throw new Shopexception($"Không thể tìm thấy:{request.Id}");
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Desctiption = request.Description;
            productTranslations.Details = request.Details;
            return await _context.SaveChangesAsync();

        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new Shopexception($"khon tim thay id:{productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new Shopexception($"khon tim thay id:{productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
