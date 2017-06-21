using System;
using System.Net.Http;
using System.Threading.Tasks;
using Interview.Green.Web.Scrapper.Interfaces;

namespace Interview.Green.Web.Scrapper.Service
{
    public class WebScrapService : IWebScrapService
    {
		static readonly HttpClient Client = new HttpClient();

		// TODO: IMP. WEBSITE Scraper HERE.
		public async Task<string> Scrape(string url)
        {
			var uri = new Uri(url);

			var response = await Client.GetStringAsync(uri);

			return response;
        }

      
    }
}