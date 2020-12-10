using SolutionShop.ViewModel.System.Languages;
using System.Collections.Generic;

namespace AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVm> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
        public string ReturnUrl { get; set; }
    }
}
