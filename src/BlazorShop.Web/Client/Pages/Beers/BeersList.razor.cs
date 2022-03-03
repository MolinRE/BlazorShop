namespace BlazorShop.Web.Client.Pages.Beers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    using Models.Breweries;
    using Models.Beers;

    public partial class BeersList
    {
        private readonly BeersSearchRequestModel model = new BeersSearchRequestModel();

        private BeersSearchResponseModel searchResponse;
        private IEnumerable<BeersListingResponseModel> beers;
        private IEnumerable<BreweriesListingResponseModel> breweries;

        [Parameter]
        public int? BreweryId { get; set; }

        [Parameter]
        public string BreweryName { get; set; }

        [Parameter]
        public string SearchQuery { get; set; } = string.Empty;

        [Parameter]
        public int Page { get; set; } = 1;

        [Parameter]
        public bool ListView { get; set; } = false;

        [Parameter]
        public bool GridView { get; set; } = true;

        protected override async Task OnInitializedAsync() => await this.LoadData();

        protected override async Task OnParametersSetAsync() => await this.LoadData(withCategories: false);

        private async Task SelectedPage(int page)
        {
            this.Page = page;

            await this.LoadData(withCategories: false);
        }

        private async Task LoadData(bool withCategories = true)
        {
            if (this.Page == 0)
            {
                this.Page = 1;
            }

            this.model.Brewery = this.BreweryId;
            this.model.Query = this.SearchQuery;
            this.model.Page = this.Page;

            this.searchResponse = await this.BeersService.SearchAsync(this.model);
            this.beers = this.searchResponse.Beers;

            if (withCategories)
            {
                this.breweries = await this.BreweriesService.All();
            }

            this.Filter();
        }

        // private async Task AddToWishlist(int id)
        // {
        //     await this.WishlistsService.AddProduct(id);
        //     this.NavigationManager.NavigateTo("/wishlist");
        // }

        // private async Task AddToCart(int id)
        // {
        //     var cartRequest = new ShoppingCartRequestModel
        //     {
        //         ProductId = id,
        //         Quantity = 1
        //     };
        //
        //     var result = await this.ShoppingCartsService.AddProduct(cartRequest);
        //
        //     if (!result.Succeeded)
        //     {
        //         this.ToastService.ShowError(result.Errors.First());
        //     }
        //     else
        //     {
        //         this.NavigationManager.NavigateTo("/cart", forceLoad: true);
        //     }
        // }

        private void ChangeView()
        {
            this.ListView = !this.ListView;
            this.GridView = !this.GridView;
        }

        private void Reset()
        {
            this.model.MinPrice = null;
            this.model.MaxPrice = null;
            this.NavigationManager.NavigateTo("/beers/page/1");
        }

        private void Filter()
        {
            if (!string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.BreweryName) && !this.model.Brewery.HasValue)
            {
                this.NavigationManager.NavigateTo($"/beers/search/{this.model.Query}/page/{this.model.Page}");
            }
            else if (!string.IsNullOrWhiteSpace(this.model.Query) && !string.IsNullOrWhiteSpace(this.BreweryName) && this.model.Brewery.HasValue)
            {
                this.NavigationManager.NavigateTo($"/beers/brewery/{this.BreweryName}/{this.model.Brewery}/search/{this.model.Query}/page/{this.model.Page}");
            }
            else if (!string.IsNullOrWhiteSpace(this.BreweryName) && this.model.Brewery.HasValue)
            {
                this.NavigationManager.NavigateTo($"/beers/brewery/{this.BreweryName}/{this.model.Brewery}/page/{this.model.Page}");
            }
            else if (string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.BreweryName) && !this.model.Brewery.HasValue)
            {
                this.NavigationManager.NavigateTo($"/beers/page/{this.model.Page}");
            }
        }
    }
}
