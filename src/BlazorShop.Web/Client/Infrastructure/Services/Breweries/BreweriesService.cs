namespace BlazorShop.Web.Client.Infrastructure.Services.Breweries
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Models.Breweries;

    public class BreweriesService : IBreweriesService
    {
        private readonly HttpClient http;

        private const string BreweriesPath = "api/breweries";

        public BreweriesService(HttpClient http) => this.http = http;

        public async Task<IEnumerable<BreweriesListingResponseModel>> All()
            => await this.http.GetFromJsonAsync<IEnumerable<BreweriesListingResponseModel>>(BreweriesPath);
    }
}
