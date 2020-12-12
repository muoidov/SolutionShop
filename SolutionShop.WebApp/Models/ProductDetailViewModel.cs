using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryVm Category { get; set; }
        public ProductViewModel Product { get; set; }
        public List<ProductViewModel> RelatedProducts { get; set; }
        public List<ProductImageViewModel>  ProductImages{ get; set; }
    }
}
