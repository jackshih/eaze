using System;
using System.Threading.Tasks;

namespace Interview.Green.Web.Scrapper.Interfaces
{
    public interface IDataRepo
    {
        Task<Guid> Save(string content);
        Task<string> GetContent(Guid requestId);
    }
}
