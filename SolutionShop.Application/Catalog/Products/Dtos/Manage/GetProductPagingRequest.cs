using SolutionShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.Application.Catalog.Manage.Products.Dtos
{
   public class GetProductPagingRequest : PagingRequestBase
    {
        public int Keyword{ get; set; }
        public List<int> CategoryIds { get; set; }

    }
}
