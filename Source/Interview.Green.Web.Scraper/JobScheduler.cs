using Interview.Green.Web.Scrapper.Service;
using Quartz;
using Quartz.Impl;

namespace Interview.Green.Web.Scrapper
{
    public class JobScheduler
    {
        public static void Start()
        {
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            var job = JobBuilder.Create<JobSchedulerService>().Build();
            job.JobDataMap["url"] = "https://www.eaze.com/";
            var trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInMinutes(1)
                    //.OnEveryDay()
                    //.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                  )
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}