namespace BlazorShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstants.Common;
    using static ModelConstants.Product;

    internal class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> beer)
        {
            beer
                .HasOne(p => p.Brewery)
                .WithMany(c => c.Beers)
                .HasForeignKey(p => p.BreweryId)
                .OnDelete(DeleteBehavior.Restrict);

            beer
                .HasOne(p => p.Style)
                .WithMany(p => p.Beers)
                .HasForeignKey(p => p.StyleId)
                .OnDelete(DeleteBehavior.Restrict);

            beer
                .HasQueryFilter(c => !c.IsDeleted);
        }
    }
}