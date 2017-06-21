using System;
using Interview.Green.Web.Scrapper.Interfaces;

namespace Interview.Green.Web.Scrapper.Models
{
    public class JobRequest : IJobQueuedRequest
    {
        //public int Id { get; set; }
        public DateTime RequestedAt { get; set; }
        public Guid RequestId { get; set; }
        public JobType JobType { get; set; }
        public string RequestValue { get; set; }
    }
}