using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(MGetProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
    }
}
