using System;
using Interview.Green.Web.Scrapper.Interfaces;

namespace Interview.Green.Web.Scrapper.Models
{
    public class JobResult : IJobResult
    {
        public DateTime RequestedAt { get; set; }
        public Guid ResultId { get; set; }
        public string Content { get; set; }
    }
}