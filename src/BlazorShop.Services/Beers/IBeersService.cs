using BlazorShop.Models.Beers;

namespace BlazorShop.Services.Beers
{
	using System.Threading.Tasks;

	using Common;
	
	public interface IBeersService : IService
	{
		Task<BeersSearchResponseModel> SearchAsync(BeersSearchRequestModel model);
		Task<BeersDetailsResponseModel> DetailsAsync(int id);
	}
}