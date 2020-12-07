using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.System.Users
{
   public class RoleAsignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
