using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Interview.Green.Web.Scraper.Interfaces;

namespace Interview.Green.Web.Scraper.Controllers
{
    public class JobController : ApiController
    {
        private IWebScrapService _webScrapService;
        private IDataRepo _repoService;

        public JobController(IWebScrapService webScrapService, IDataRepo dataRepo)
        {
            _webScrapService = webScrapService;
            _repoService = dataRepo;
        }
        // GET: api/job
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET: api/job/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/job
        public async Task<IHttpActionResult> Post([FromBody] string url)
        {
            try
            {
                var scraped = _webScrapService.Scrape(url);

                var id = _repoService.Save(scraped);

                return Ok(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
         
        }
    }
}