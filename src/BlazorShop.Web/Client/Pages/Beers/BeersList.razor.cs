using System;
using BlazorShop.Models.BeerStyles;

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
        private IEnumerable<BeerStylesListingResponseModel> beerStyles;

        [Parameter]
        public int? BreweryId { get; set; }

        [Parameter]
        public string BreweryName { get; set; }
        
        [Parameter]
        public int? StyleId { get; set; }

        [Parameter]
        public string StyleName { get; set; }

        [Parameter]
        public string SearchQuery { get; set; } = string.Empty;

        [Parameter]
        public int Page { get; set; } = 1;

        [Parameter]
        public bool ListView { get; set; } = false;

        [Parameter]
        public bool GridView { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("OnInitializedAsync");
            await this.LoadData();
        }

        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine("OnParametersSetAsync");
            await this.LoadData(withCategories: false);
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var prms = parameters.ToDictionary();
            await base.SetParametersAsync(parameters);
        }

        private async Task SelectedPage(int page)
        {
            Console.WriteLine("SelectedPage");
            this.Page = page;

            await this.LoadData(withCategories: false);
        }

        private async Task LoadData(bool withCategories = true)
        {
            Console.WriteLine($"LoadData (withCategories = {withCategories}, Brewery = {this.BreweryId}, Query = {this.SearchQuery}, Page = {this.Page}, Style = {this.StyleId})");
            if (this.Page == 0)
            {
                this.Page = 1;
            }

            this.model.Brewery = this.BreweryId;
            this.model.Query = this.SearchQuery;
            this.model.Page = this.Page;
            this.model.Style = this.StyleId;

            this.searchResponse = await this.BeersService.SearchAsync(this.model);
            this.beers = this.searchResponse.Beers;

            if (withCategories)
            {
                this.breweries = await this.BreweriesService.All();
                this.beerStyles = await this.BeerStylesService.All();
            }

            this.Filter();
        }

        private void FilterByBrewery(ChangeEventArgs e)
        {
            Console.WriteLine("FilterByBrewery");
            this.NavigationManager.NavigateTo($"/beers/brewery/{e.Value}");
        }

        private void FilterByStyle(ChangeEventArgs e)
        {
            Console.WriteLine("FilterByStyle");
            this.NavigationManager.NavigateTo($"/beers/style/{e.Value}");
        }
        
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
            bool query = !string.IsNullOrWhiteSpace(this.model.Query);
            bool brewery = this.model.Brewery.HasValue;
            bool style = this.model.Style.HasValue;
            
            
            Console.WriteLine($"Filter (Query = {this.model.Query}, Brewery = {this.model.Brewery} Style = {this.model.Style})");

            if (style)
            {
                this.NavigationManager.NavigateTo($"/beers/style/{this.StyleName}/{this.model.Style}/page/{this.model.Page}");
            }

            if (query && !brewery)
            {
                this.NavigationManager.NavigateTo($"/beers/search/{this.model.Query}/page/{this.model.Page}");
            }
            else if (query && brewery)
            {
                this.NavigationManager.NavigateTo($"/beers/brewery/{this.BreweryName}/{this.model.Brewery}/search/{this.model.Query}/page/{this.model.Page}");
            }
            else if (brewery)
            {
                this.NavigationManager.NavigateTo($"/beers/brewery/{this.BreweryName}/{this.model.Brewery}/page/{this.model.Page}");
            }
            else if (!query && !brewery)
            {
                this.NavigationManager.NavigateTo($"/beers/page/{this.model.Page}");
            }
        }
    }
}
