using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Ultilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVm> Slides { get; set; }
        public List<ProductViewModel> FeaturedProducts { get; set; }
    }
}
