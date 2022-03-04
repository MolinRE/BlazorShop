namespace BlazorShop.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Models.BeerStyles;
    using Services.BeerStyles;

    using static Common.Constants;

    [Authorize(Roles = AdministratorRole)]
    public class StylesController : ApiController
    {
        private readonly IBeerStylesService beerStyles;

        public StylesController(IBeerStylesService beerStyles)
            => this.beerStyles = beerStyles;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<BeerStylesListingResponseModel>> All()
            => await this.beerStyles.AllAsync();
    }
}
