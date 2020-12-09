﻿using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;

using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(MGetProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<ProductViewModel> GetById(int id,string languageId);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
    }
}
