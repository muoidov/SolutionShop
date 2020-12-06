using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.Common
{
    
    public class PagedResult<T>:PageResultBase
    {
        public List<T> Items { set; get; }
        
    }
}
