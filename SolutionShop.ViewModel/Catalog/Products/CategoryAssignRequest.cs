using SolutionShop.ViewModel.Common;
using System.Collections.Generic;


namespace SolutionShop.ViewModel.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}
