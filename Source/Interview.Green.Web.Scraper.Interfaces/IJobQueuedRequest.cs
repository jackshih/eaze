using System;

namespace Interview.Green.Web.Scrapper.Interfaces
{
    /// <summary>
    ///     Used for Queued Jobs.
    /// </summary>
    public interface IJobQueuedRequest : IBasic
    {
        Guid RequestId { get; set; }
        JobType JobType { get; set; }
        string RequestValue { get; set; }
    }
}