using Microsoft.EntityFrameworkCore;
using SolutionShop.Data.EF;
using SolutionShop.ViewModel.Ultilities.Slides;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.Application.Ultilities.Slides
{
    public class SlideService : ISlideService
    {


        private readonly Shopdbcontext _context;

        public SlideService(Shopdbcontext context)
        {
            _context = context;

        }
        public async Task<List<SlideVm>> GetAll()
        {
            var Slides = await _context.Slides.OrderBy(x=>x.SortOrder).Select(x => new SlideVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Url=x.Url,
                Image=x.Image
            }).ToListAsync();
            return Slides;
        }


    }
}
