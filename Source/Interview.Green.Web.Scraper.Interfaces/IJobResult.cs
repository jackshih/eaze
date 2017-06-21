using System;

namespace Interview.Green.Web.Scrapper.Interfaces
{
    public interface IJobResult : IBasic
    {
        Guid ResultId { get; set; }
        string Content { get; set; }
    }
}
