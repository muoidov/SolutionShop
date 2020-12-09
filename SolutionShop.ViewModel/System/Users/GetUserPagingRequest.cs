using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.System.Users
{
    public class GetUserPagingRequest :PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
