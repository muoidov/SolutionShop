using SolutionShop.Application.Catalog.Products.Dtos;
using SolutionShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.Catalog.Products
{
    public interface IManageProductService
    {
        //tao logic them sua xoa
        //tra ve 1 nhiem vu taskk
        Task<int> Create(ProductCreateRequest request);
        Task<int>  Update(ProductEditRequest request);
        Task<int>  Delete(int productId);
        Task<List<ProductViewModel>>  GetAll(); 
        Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword,int PageIndex,int PageSize); 

    }
}
