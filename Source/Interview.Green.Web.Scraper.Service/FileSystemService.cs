using System.IO;
using System.Threading.Tasks;
using Interview.Green.Web.Scrapper.Interfaces;
using Interview.Green.Web.Scrapper.Models;

namespace Interview.Green.Web.Scrapper.Service
{
    public class FileSystemService : IFileSystem
    {       
        public async Task<string> ReadToEndAsync(string path)
        {
            if (!File.Exists(path))
                throw new IdNotFoundException();

            using (var fs = File.OpenText(path))
            {
                var content = await fs.ReadToEndAsync();
                return content;
            }
        }
       
        public async Task<bool> WriteLineAsync(string path, string content)
        {
            if (!File.Exists(path))
                return false;

            using (var fs = File.CreateText(path))
            {
                await fs.WriteAsync(content);                
            }
            return true;
        }
    }
}
