namespace BlazorShop.Models.Breweries
{
    using Common.Mapping;
    using Data.Models;

    public class BreweriesListingResponseModel : IMapFrom<Brewery>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}