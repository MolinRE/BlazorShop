namespace BlazorShop.Services.BeerStyles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using Models.BeerStyles;

    public class BeerStylesService : BaseService<BeerStyle>, IBeerStylesService
    {
        public BeerStylesService(BlazorShopDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }
        
        public async Task<IEnumerable<BeerStylesListingResponseModel>> AllAsync()
            => await this.Mapper
                .ProjectTo<BeerStylesListingResponseModel>(this
                    .AllAsNoTracking())
                .ToListAsync();

        private async Task<BeerStyle> FindByIdAsync(
            int id)
            => await this
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}
