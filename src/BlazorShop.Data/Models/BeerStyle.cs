namespace BlazorShop.Data.Models
{
	using System.Collections.Generic;

	using Contracts;
	
	public class BeerStyle : BaseDeletableModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<Beer> Beers { get; } = new HashSet<Beer>();
	}
}