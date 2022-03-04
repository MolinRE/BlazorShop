namespace BlazorShop.Models.BeerStyles
{
    using System.ComponentModel.DataAnnotations;

    using static ErrorMessages;
    using static Data.ModelConstants.Common;

    public class BeerStylesRequestModel
    {
        [Required]
        [StringLength(
            MaxNameLength, 
            ErrorMessage = StringLengthErrorMessage, 
            MinimumLength = MinNameLength)]
        public string Name { get; set; }
    }
}
