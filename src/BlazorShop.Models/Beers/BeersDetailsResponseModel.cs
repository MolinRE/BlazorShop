namespace BlazorShop.Models.Beers
{
    public class BeersDetailsResponseModel : BeersListingResponseModel
    {
        public int Quantity { get; set; }

        public int BreweryId { get; set; }

        public string BreweryName { get; set; }
    }
}
