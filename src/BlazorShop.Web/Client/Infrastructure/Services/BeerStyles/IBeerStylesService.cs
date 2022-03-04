namespace BlazorShop.Web.Client.Infrastructure.Services.BeerStyles
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	
	using Models.BeerStyles;
	
	public interface IBeerStylesService
	{
		Task<IEnumerable<BeerStylesListingResponseModel>> All();
	}
}