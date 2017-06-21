using System.IO;
using System.Threading.Tasks;
using Interview.Green.Web.Scrapper.Interfaces;
using Interview.Green.Web.Scrapper.Models;

namespace Interview.Green.Web.Scrapper.Service
{
    public class FileSystemService : IFileSystem
    {       
        /// <summary>
        /// File system that will read input path and return content
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
       
        /// <summary>
        /// File system that will write content to path specified in parameter
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<bool> WriteLineAsync(string path, string content)
        {            
            using (var fs = File.CreateText(path))
            {
                await fs.WriteAsync(content);                
            }
            return true;
        }
    }
}
