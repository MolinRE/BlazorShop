namespace BlazorShop.Models.Breweries
{
    using System.ComponentModel.DataAnnotations;

    using static ErrorMessages;
    using static Data.ModelConstants.Common;

    public class BreweriesRequestModel
    {
        [Required]
        [StringLength(
            MaxNameLength, 
            ErrorMessage = StringLengthErrorMessage, 
            MinimumLength = MinNameLength)]
        public string Name { get; set; }
    }
}
