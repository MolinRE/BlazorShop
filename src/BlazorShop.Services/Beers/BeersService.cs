using BlazorShop.Models.Beers;

namespace BlazorShop.Services.Beers
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using AutoMapper;
	using Data;
	using BlazorShop.Data.Models;
	using Specifications;
	using Microsoft.EntityFrameworkCore;
	
	class BeersService : BaseService<Beer>, IBeersService
	{
		private const int ProductsPerPage = 6;
		
		public BeersService(BlazorShopDbContext data, IMapper mapper) : base(data, mapper)
		{
		}
		
		public async Task<BeersSearchResponseModel> SearchAsync(BeersSearchRequestModel model)
		{
			var specification = this.GetBeerSpecification(model);

			var beers = await this.Mapper
				.ProjectTo<BeersListingResponseModel>(this
					.AllAsNoTracking()
					.Where(specification)
					.Skip((model.Page - 1) * ProductsPerPage)
					.Take(ProductsPerPage))
				.ToListAsync();

			var totalPages = await this.GetTotalPages(model);

			return new BeersSearchResponseModel
			{
				Beers = beers,
				Page = model.Page,
				TotalPages = totalPages
			};
		}

		public async Task<BeersDetailsResponseModel> DetailsAsync(int id)
		{
			return await this.Mapper
				.ProjectTo<BeersDetailsResponseModel>(this.AllAsNoTracking().Where(p => p.Id == id))
				.FirstOrDefaultAsync();
		}

		private async Task<int> GetTotalPages(BeersSearchRequestModel model)
		{
			var specification = this.GetBeerSpecification(model);

			var total = await this.AllAsNoTracking().Where(specification).CountAsync();

			return (int)Math.Ceiling((double)total / ProductsPerPage);
		}

		private Specification<Beer> GetBeerSpecification(BeersSearchRequestModel model)
		{
			return new BeerByNameSpecification(model.Query)
				.And(new BeerByPriceSpecification(model.MinPrice, model.MaxPrice))
				.And(new BeerByBrewerySpecification(model.Brewery));
		}
	}
}