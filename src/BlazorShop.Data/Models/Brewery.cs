using System.Collections.Generic;
using BlazorShop.Data.Contracts;

namespace BlazorShop.Data.Models
{
	public class Brewery : BaseDeletableModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<Beer> Beers { get; } = new HashSet<Beer>();
	}
}