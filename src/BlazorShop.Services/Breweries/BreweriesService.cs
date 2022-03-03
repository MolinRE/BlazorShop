namespace BlazorShop.Services.Breweries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using Models.Breweries;

    public class BreweriesService : BaseService<Brewery>, IBreweriesService
    {
        public BreweriesService(BlazorShopDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }
        
        public async Task<IEnumerable<BreweriesListingResponseModel>> AllAsync()
            => await this.Mapper
                .ProjectTo<BreweriesListingResponseModel>(this
                    .AllAsNoTracking())
                .ToListAsync();

        private async Task<Brewery> FindByIdAsync(
            int id)
            => await this
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}
