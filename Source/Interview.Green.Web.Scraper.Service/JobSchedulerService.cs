using Quartz;

namespace Interview.Green.Web.Scrapper.Service
{
    public class JobSchedulerService : IJob
    {
        // TODO: IMP JOB SCHEDULE LOGIC HERE.
        public async void Execute(IJobExecutionContext context)
        {
            // Website scraping job is a simple job that does the following:
            var dataMap = context.JobDetail.JobDataMap;

            // Makes a request to website and gathers its response.
            var url = dataMap.GetString("url");
            var webScraperService = new WebScrapService();
            var scraped = await webScraperService.Scrape(url);

            // If items to scrape were requested the next step should be to process the response and find the items.

            // Store the result of the job so it can be retrieved later by ID.
            var dataRepoService = new DataRepoService();
            await dataRepoService.Save(scraped);
        }
    }
}