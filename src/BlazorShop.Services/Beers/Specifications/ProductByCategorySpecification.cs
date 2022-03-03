namespace BlazorShop.Services.Beers.Specifications
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    internal class BeerByBrewerySpecification : Specification<Beer>
    {
        private readonly int? breweryId;

        internal BeerByBrewerySpecification(int? breweryId) => this.breweryId = breweryId;

        protected override bool Include => this.breweryId != null;

        public override Expression<Func<Beer, bool>> ToExpression()
        {
            return product => product.Brewery.Id == this.breweryId;
        }
    }
}