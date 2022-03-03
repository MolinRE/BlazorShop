namespace BlazorShop.Services.Breweries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common;
    using Models;
    using Models.Breweries;

    public interface IBreweriesService : IService
    {
        Task<IEnumerable<BreweriesListingResponseModel>> AllAsync();
    }
}