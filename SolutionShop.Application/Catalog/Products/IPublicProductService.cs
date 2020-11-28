using SolutionShop.Application.Catalog.Products.Dtos;
using SolutionShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Application.Catalog.Products
{//pt danh cho phan ben ngoai khach hang
    public interface IPublicProductService
    {
        public PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId,int pageIndex,int pageSize);
    }
}
