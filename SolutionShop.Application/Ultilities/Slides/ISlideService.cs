
using SolutionShop.ViewModel.Ultilities.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolutionShop.Application.Ultilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVm>> GetAll();
    }
}
