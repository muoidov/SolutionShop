using SolutionShop.Application.Catalog.Products.Dtos;
using SolutionShop.Application.Dtos;
using SolutionShop.Data.EF;
using SolutionShop.Data.Entities;
using System;
using System.Collections.Generic;
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
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,

            };
            //dung async tan dang thread chuong trinh chay ngon hon
            _context.Products.Add(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>>  GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedViewModel<ProductViewModel>>  GetAllPaging(string keyword, int PageIndex, int PageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
