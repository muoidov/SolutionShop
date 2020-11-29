using SolutionShop.Application.Catalog.Products.Dtos.Manage;
using SolutionShop.Application.Catalog.Products.Dtos;
using SolutionShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.Catalog.Products
{
    public interface IManageProductService
    {//quan ly san pham
        //uu diem cua no la co the trien khai DI
        //tao logic them sua xoa
        //tra ve 1 nhiem vu taskk
        Task<int> Create(ProductCreateRequest request);
        Task<int>  Update(ProductUpdateRequest request);
        Task<int>  Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request); 

    }
}
