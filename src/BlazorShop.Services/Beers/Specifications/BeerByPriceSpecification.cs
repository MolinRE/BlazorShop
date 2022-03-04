namespace BlazorShop.Services.Beers.Specifications
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    internal class BeerByPriceSpecification : Specification<Beer>
    {
        private readonly decimal minPrice;
        private readonly decimal maxPrice;

        internal BeerByPriceSpecification(decimal? minPrice = default, decimal? maxPrice = decimal.MaxValue)
        {
            this.minPrice = minPrice ?? default;
            this.maxPrice = maxPrice ?? decimal.MaxValue;
        }

        public override Expression<Func<Beer, bool>> ToExpression()
        {
            return product => (this.minPrice < product.Price && this.maxPrice > product.Price);
        }
    }
}
