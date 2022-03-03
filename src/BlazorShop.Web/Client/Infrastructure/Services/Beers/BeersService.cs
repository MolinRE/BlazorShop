namespace BlazorShop.Web.Client.Infrastructure.Services.Beers
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Models.Beers;

    public class BeersService : IBeersService
    {
        private readonly HttpClient http;

        private const string BeersPath = "api/beers";
        private const string BeersPathWithSlash = BeersPath + "/";
        private const string BeersSearchPath = BeersPath + "?brewery={0}&minPrice={1}&maxPrice={2}&query={3}&page={4}";

        public BeersService(HttpClient http) => this.http = http;

        public async Task<TModel> DetailsAsync<TModel>(int id) 
            where TModel : class
        {
            return await this.http.GetFromJsonAsync<TModel>(BeersPathWithSlash + id);
        }

        public async Task<BeersSearchResponseModel> SearchAsync(BeersSearchRequestModel model)
        {
            return await this.http.GetFromJsonAsync<BeersSearchResponseModel>(
                string.Format(
                    BeersSearchPath,
                    model.Brewery,
                    model.MinPrice,
                    model.MaxPrice,
                    model.Query,
                    model.Page));
        }
    }
}