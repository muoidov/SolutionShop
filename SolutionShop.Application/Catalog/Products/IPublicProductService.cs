using SolutionShop.Application.Catalog.Products.Dtos;
using SolutionShop.Application.Catalog.Products.Dtos.Public;
using SolutionShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Application.Catalog.Products
{//pt danh cho phan ben ngoai khach hang
    public interface IPublicProductService
    {
        public PagedResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
