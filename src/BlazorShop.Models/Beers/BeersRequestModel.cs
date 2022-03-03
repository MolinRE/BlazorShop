namespace BlazorShop.Models.Beers
{
    using System.ComponentModel.DataAnnotations;

    using static ErrorMessages;
    using static Data.ModelConstants.Common;
    using static Data.ModelConstants.Product;

    public class BeersRequestModel
    {
        [Required]
        [StringLength(
            MaxNameLength, 
            ErrorMessage = StringLengthErrorMessage, 
            MinimumLength = MinNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; }

        [Required]
        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        public int BreweryId { get; set; }
    }
}
