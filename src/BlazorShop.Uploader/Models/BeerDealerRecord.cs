using Ganss.Excel;

namespace BlazorShop.Uploader.Models;

public class BeerDealerRecord
{
	[Column(2)]
	public string BreweryName { get; set; }
	
	[Column(3)]
	public string Name { get; set; }
	
	[Column(5)]
	public string Abv { get; set; }
	
	[Column(6)]
	public string Ibu { get; set; }
	
	[Column(7)]
	public string Untappd { get; set; }
	
	[Column(8)]
	public string Style { get; set; }
	
	[Column(9)]
	public string Description { get; set; }
	[Column(10)]
	public string Packaging { get; set; }
	
	[Column(11)]
	public string Price { get; set; }
	
	[Column(12)]
	public string PackAndVol { get; set; }
	
	[Column(14)]
	public string Expiration { get; set; }
}