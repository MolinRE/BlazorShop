using BlazorShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Data.Configurations
{
	public class BeerStyleConfiguration : IEntityTypeConfiguration<BeerStyle>
	{
		public void Configure(EntityTypeBuilder<BeerStyle> category)
		{
			category
				.HasIndex(c => c.IsDeleted);

			category
				.HasQueryFilter(c => !c.IsDeleted);
		}
	}
}