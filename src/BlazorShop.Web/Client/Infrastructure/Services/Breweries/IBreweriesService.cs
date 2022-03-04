namespace BlazorShop.Web.Client.Infrastructure.Services.Breweries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Breweries;

    public interface IBreweriesService
    {
        Task<IEnumerable<BreweriesListingResponseModel>> All();
    }
}
