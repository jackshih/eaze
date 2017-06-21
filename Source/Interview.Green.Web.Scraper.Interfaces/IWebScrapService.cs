using System.Threading.Tasks;

namespace Interview.Green.Web.Scrapper.Interfaces
{
    public interface IWebScrapService
    {
        // TODO: IMP INTERFACE NEEDED FOR SERVICE.
        Task<string> Scrape(string url);
    }
}