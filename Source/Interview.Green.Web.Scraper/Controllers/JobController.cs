using System;
using System.Threading.Tasks;
using System.Web.Http;
using Interview.Green.Web.Scrapper.Interfaces;
using Interview.Green.Web.Scrapper.Models;
using Interview.Green.Web.Scrapper.Service;

namespace Interview.Green.Web.Scrapper.Controllers
{
    [RoutePrefix("api/job")]
    public class JobController : ApiController
    {
        private readonly IWebScrapService _webScrapService;
        private readonly IDataRepo _repoService;

        public JobController()
        {
            _webScrapService = new WebScrapService();
            _repoService = new DataRepoService();
        }
        public JobController(IWebScrapService webScrapService, IDataRepo dataRepo)
        {
            _webScrapService = webScrapService;
            _repoService = dataRepo;
        }   
        
        public async Task<IHttpActionResult> Get(Guid requestId)
        {
            try
            {
                //The request ID can be used to check the current status of the job running and return back the results of the job.
                var content = await _repoService.GetContent(requestId);

                var jobResult = new JobResult
                {
                    ResultId = requestId,
                    RequestedAt = DateTime.Now,
                    Content = content
                };

                return Ok(jobResult);
            }
            catch (IdNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        // POST: api/job
        // We need an API endpoint that has the ability to post a new Web site job.
        public async Task<IHttpActionResult> Post(JobRequest jobRequest)
        {
            try
            {
                switch (jobRequest.JobType)
                {
                        case JobType.WebScrape:
                            var url = jobRequest.RequestValue;

                            // Currently they only job type needed is the web site scraping job.
                            var scraped = await _webScrapService.Scrape(url);

                            var id = await _repoService.Save(scraped);

                            // The Api will process this job and return a id for lookup and status purpose.
                            var jobResult = new JobResult
                            {
                                ResultId = id,
                                RequestedAt = DateTime.Now,
                                Content = scraped
                            };

                            return Ok(jobResult);                            
                    default:
                        return Ok("Missing Job Type");
                }
                
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
         
        }
    }
}