namespace BlazorShop.Models.Beers
{
    using Common.Mapping;
    using Data.Models;

    public class BeersListingResponseModel : IMapFrom<Beer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public short? Ibu { get; set; }

        public float? Abv { get; set; }

        public string UntappdUrl { get; set; }

        public string Packaging { get; set; }
        
        public float Volume { get; set; }

        public int BreweryId { get; set; }

        public string BreweryName { get; set; }

        public int StyleId { get; set; }

        public string StyleName { get; set; }
    }
}
