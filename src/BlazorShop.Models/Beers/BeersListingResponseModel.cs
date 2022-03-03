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
    }
}
