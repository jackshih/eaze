using System;
using System.IO;
using System.Threading.Tasks;
using Interview.Green.Web.Scrapper.Interfaces;
using Interview.Green.Web.Scrapper.Models;

namespace Interview.Green.Web.Scrapper.Service
{
    public class DataRepoService : IDataRepo
    {
        //static readonly string DataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        //static readonly string LogPath = $"{DataPath}\\Log.txt";
        private readonly string _dataPath;
        private readonly string _logPath;
        private readonly IFileSystem _fileSystem;

        public DataRepoService(IFileSystem fileSystem, string dataPath, string logPath)
        {
            _dataPath = dataPath;
            _logPath = logPath;
            _fileSystem = fileSystem;
        }

        public DataRepoService()
        {
            _fileSystem = new FileSystemService();
            _dataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            _logPath = $"{_dataPath}\\Log.txt";
        }

        /// <summary>
        /// Save content to a data repo.
        /// All new requests are logged and an ID is given back as a response.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<Guid> Save(string content)
        {
            var id = Guid.NewGuid();

            // All new requests are logged and an ID is given back as a response.
            var path = $"{_dataPath}\\{id}.txt";  
            
            await _fileSystem.WriteLineAsync(path, content);

            var logEntry = $"{id} processed at {DateTime.Now}";

            await _fileSystem.WriteLineAsync(_logPath, logEntry);
            
            return id;
        }

        /// <summary>
        /// Get content based on request Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> GetContent(Guid id)
        {
            var path = $"{_dataPath}/{id}.txt";

            var content = await _fileSystem.ReadToEndAsync(path);
            return content;
        }
    }
}
