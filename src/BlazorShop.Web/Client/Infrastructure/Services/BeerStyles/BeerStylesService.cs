namespace BlazorShop.Web.Client.Infrastructure.Services.BeerStyles
{
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Threading.Tasks;
	
	using Models.BeerStyles;
	
	public class BeerStylesService : IBeerStylesService
	{
		private readonly HttpClient http;

		private const string StylesPath = "api/styles";

		public BeerStylesService(HttpClient http) => this.http = http;

		public async Task<IEnumerable<BeerStylesListingResponseModel>> All()
			=> await this.http.GetFromJsonAsync<IEnumerable<BeerStylesListingResponseModel>>(StylesPath);
	}
}