using Microsoft.AspNetCore.Http;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.Catalog.Products
{
    public interface IProductService
    {//quan ly san pham
        //uu diem cua no la co the trien khai DI
        //tao logic them sua xoa
        //tra ve 1 nhiem vu taskk
        Task<int> Create(ProductCreateRequest request);
        Task<int>  Update(ProductUpdateRequest request);
        Task<int>  Delete(int productId);
        Task<ProductViewModel> GetById(int productId,string languageId); 
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(MGetProductPagingRequest request);

        Task<int> AddImage(int productId,ProductImageCreateRequest request);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
        Task<ProductImageViewModel> GetImageById(int imageId);
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, PGetProductPagingRequest request);
    }
}
