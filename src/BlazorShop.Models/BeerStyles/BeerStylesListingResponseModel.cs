namespace BlazorShop.Models.BeerStyles
{
    using Common.Mapping;
    using Data.Models;

    public class BeerStylesListingResponseModel : IMapFrom<BeerStyle>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value => $"{Name}/{Id}";
    }
}