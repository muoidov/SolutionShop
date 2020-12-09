using SolutionShop.ViewModel.Ultilities.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegration
{
    public interface ISlideApiClient
    {
        public Task<List<SlideVm>> GetAll();
    }
}
