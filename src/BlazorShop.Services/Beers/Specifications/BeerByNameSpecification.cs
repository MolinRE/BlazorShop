using System;
using System.Linq.Expressions;
using BlazorShop.Data.Models;

namespace BlazorShop.Services.Beers.Specifications
{
	internal class BeerByNameSpecification : Specification<Beer>
	{
		private readonly string name;

		internal BeerByNameSpecification(string name) => this.name = name;

		protected override bool Include => this.name != null;

		public override Expression<Func<Beer, bool>> ToExpression()
			=> product => product.Name.ToLower().Contains(this.name.ToLower());
	}
}