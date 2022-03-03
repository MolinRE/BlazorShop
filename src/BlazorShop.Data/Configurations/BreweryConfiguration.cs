using BlazorShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Data.Configurations
{
	internal class BreweryConfiguration : IEntityTypeConfiguration<Brewery>
	{
		public void Configure(EntityTypeBuilder<Brewery> product)
		{
			product
				.HasQueryFilter(c => !c.IsDeleted);
		}
	}
}