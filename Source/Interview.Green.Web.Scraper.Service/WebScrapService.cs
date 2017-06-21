using HtmlAgilityPack;
using System;
using System.Net.Http;
using Interview.Green.Web.Scraper.Interfaces;
using System.Net.Http.Headers;

namespace Interview.Green.Web.Scraper.Service
{
    public class WebScrapService : IWebScrapService
    {
		static HttpClient client = new HttpClient();

		// TODO: IMP. WEBSITE Scraper HERE.
		public string Scrape(string url)
        {
			var uri = new Uri(url);

			var response = client.GetStringAsync(uri).Result;

			return response;
        }

      
    }
}