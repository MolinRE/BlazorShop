namespace BlazorShop.Web.Client.Infrastructure.Services.Beers
{
    using System.Threading.Tasks;
    using Models.Beers;

    public interface IBeersService
    {
        Task<TModel> DetailsAsync<TModel>(int id) where TModel : class;

        Task<BeersSearchResponseModel> SearchAsync(BeersSearchRequestModel model);
    }
}