namespace BlazorShop.Services.Beers.Specifications
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    internal class BeerByStyleSpecification : Specification<Beer>
    {
        private readonly int? styleId;

        internal BeerByStyleSpecification(int? styleId) => this.styleId = styleId;

        protected override bool Include => this.styleId != null;

        public override Expression<Func<Beer, bool>> ToExpression()
        {
            return product => product.Style.Id == this.styleId;
        }
    }
}
