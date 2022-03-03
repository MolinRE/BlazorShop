namespace BlazorShop.Models.Beers
{
    using System.Collections.Generic;

    public class BeersSearchResponseModel
    {
        public IEnumerable<BeersListingResponseModel> Beers { get; set; }

        public int Page { get; set; }

        public int TotalPages { get; set; }
    }
}
