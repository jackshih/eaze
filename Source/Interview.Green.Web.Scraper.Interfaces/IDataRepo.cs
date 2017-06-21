using System;
namespace Interview.Green.Web.Scraper.Interfaces
{
    public interface IDataRepo
    {
        Guid Save(string content);
        string GetContent(Guid id);
    }
}
