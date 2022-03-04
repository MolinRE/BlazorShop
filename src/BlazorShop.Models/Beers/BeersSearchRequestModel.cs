namespace BlazorShop.Models.Beers
{
	public class BeersSearchRequestModel
	{
		public string Query { get; set; }

		public int? Brewery { get; set; }

		public int? Style { get; set; }

		public decimal? MinPrice { get; set; }

		public decimal? MaxPrice { get; set; }

		public int Page { get; set; } = 1;
	}
}