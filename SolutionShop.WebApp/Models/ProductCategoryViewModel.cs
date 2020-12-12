using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }
        public PagedResult<ProductViewModel> Products { get; set; }
    }
}
