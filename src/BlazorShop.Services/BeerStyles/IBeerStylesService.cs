namespace BlazorShop.Services.BeerStyles
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.BeerStyles;

    public interface IBeerStylesService : IService
    {
        Task<IEnumerable<BeerStylesListingResponseModel>> AllAsync();
    }
}