using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.Catalog.Products
{
   public class MGetProductPagingRequest : PagingRequestBase
    {
        public string Keyword{ get; set; }
        public List<int> CategoryIds { get; set; }

    }
}
