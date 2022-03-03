using System;
using System.Text.RegularExpressions;
using BlazorShop.Data;
using BlazorShop.Data.Models;
using BlazorShop.Uploader.Models;
using Ganss.Excel;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Uploader
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var products = new ExcelMapper(@"C:\Users\k.komarov\dev\Прайс Бирдилер.xlsx")
				{
					HeaderRow = false
				}
				.Fetch<BeerDealerRecord>()
				.Skip(3)
				.Where(p => !string.IsNullOrEmpty(p.Name))
				.ToArray();


			var builder = new DbContextOptionsBuilder<BlazorShopDbContext>();
			builder.UseSqlServer(
				"Server=(LocalDb)\\MSSQLLocalDB;Database=BlazorShopDb;Trusted_Connection=True;MultipleActiveResultSets=true");
			using var context = new BlazorShopDbContext(builder.Options);

			foreach (var breweryBeers in products.GroupBy(p => p.BreweryName))
			{
				string breweryName = breweryBeers.Key;
				var brewery = context.Breweries.FirstOrDefault(p => p.Name == breweryName);
				if (brewery == null)
				{
					brewery = new Brewery()
					{
						Name = breweryName
					};
					context.Breweries.Add(brewery);
					context.SaveChanges();
				}

				foreach (var beer in breweryBeers)
				{
					beer.Name = beer.Name.Replace(" (Новинка!)", "");
					Console.WriteLine($"{beer.BreweryName} - {beer.Name}");
					var dbBeer = new Beer()
					{
						Name = beer.Name,
						Description = beer.Description,
						Packaging = beer.Packaging,
						ExpirationDays = beer.Expiration,
						Brewery = brewery
					};

					if (!string.IsNullOrEmpty(beer.Abv))
					{
						dbBeer.Abv = float.Parse(beer.Abv);
					}
					if (!string.IsNullOrEmpty(beer.Ibu))
					{
						dbBeer.Ibu = short.Parse(beer.Ibu);
					}

					if (!string.IsNullOrEmpty(beer.Untappd))
					{
						var untappdIdMatch = Regex.Match(beer.Untappd, @"""(\d+?)""");
						if (untappdIdMatch.Success)
						{
							dbBeer.UntappdId = int.Parse(untappdIdMatch.Groups[1].Value);
						}
						// Не все строки содержат ссылку
						if (beer.Untappd.Contains("untappd.com"))
						{
							dbBeer.UntappdUrl = beer.Untappd.Substring(12, beer.Untappd.IndexOf('"', 13) - 12);
						}
					}
					dbBeer.Price = decimal.Parse(beer.Price) + 50;
					// кор. 12х0,5л ст. бут.
					var beerVolMatch = Regex.Match(beer.PackAndVol, @"\d{1,2}х(\d,\d{1,3})\s?л");
					if (beerVolMatch.Success)
					{
						dbBeer.Volume = float.Parse(beerVolMatch.Groups[1].Value);
					}

					context.Beers.Add(dbBeer);
				}

				context.SaveChanges();
			}
		}
	}
}