using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.Catalog.Products
{//pt danh cho phan ben ngoai khach hang
    public interface IPublicProductService
    {
         public Task<PagedResult<ProductViewModel>> GetAllByCategoryId(PGetProductPagingRequest request);
    }
}
