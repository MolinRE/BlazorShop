using BlazorShop.Models.Beers;
using BlazorShop.Services.Beers;

namespace BlazorShop.Web.Server.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.Constants;

    [Authorize(Roles = AdministratorRole)]
    public class BeersController : ApiController
    {
        private readonly IBeersService beers;

        public BeersController(IBeersService beers) => this.beers = beers;

        [HttpGet]
        [AllowAnonymous]
        public async Task<BeersSearchResponseModel> Search([FromQuery] BeersSearchRequestModel model)
        {
            return await this.beers.SearchAsync(model);
        }

        [HttpGet(Id)]
        [AllowAnonymous]
        public async Task<BeersDetailsResponseModel> Details(int id)
        {
            return await this.beers.DetailsAsync(id);
        }
    }
}
