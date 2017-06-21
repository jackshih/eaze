using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Green.Web.Scrapper.Interfaces
{
    public interface IFileSystem
    {      
        Task<string> ReadToEndAsync(string path);
        Task<bool> WriteLineAsync(string path, string content);        
    }
}
