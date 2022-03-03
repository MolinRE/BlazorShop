using BlazorShop.Data.Contracts;

namespace BlazorShop.Data.Models
{
	public class Beer : BaseDeletableModel
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		public float? Abv { get; set; }
		public short? Ibu { get; set; }
		public string Description { get; set; }
		public decimal? Price { get; set; }
		public string UntappdUrl { get; set; }
		public string Packaging { get; set; }
		public float? Volume { get; set; }
		public string ExpirationDays { get; set; }
        
		public int BreweryId { get; set; }
		public Brewery Brewery { get; set; }
		public int? UntappdId { get; set; }
	}
}