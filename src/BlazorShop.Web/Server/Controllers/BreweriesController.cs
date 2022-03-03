namespace BlazorShop.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Models.Breweries;
    using Services.Breweries;

    using static Common.Constants;

    [Authorize(Roles = AdministratorRole)]
    public class BreweriesController : ApiController
    {
        private readonly IBreweriesService breweries;

        public BreweriesController(IBreweriesService breweries)
            => this.breweries = breweries;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<BreweriesListingResponseModel>> All()
            => await this.breweries.AllAsync();
    }
}
