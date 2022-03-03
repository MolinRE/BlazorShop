namespace BlazorShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstants.Common;
    using static ModelConstants.Product;

    internal class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> product)
        {
            product
                .HasOne(p => p.Brewery)
                .WithMany(c => c.Beers)
                .HasForeignKey(p => p.BreweryId)
                .OnDelete(DeleteBehavior.Restrict);

            product
                .HasQueryFilter(c => !c.IsDeleted);
        }
    }
}