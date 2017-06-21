using System;
using System.IO;
using Interview.Green.Web.Scraper.Interfaces;
using Interview.Green.Web.Scraper.Models;

namespace Interview.Green.Web.Scraper.Service
{
    public class DataRepoService : IDataRepo
    {
        string dataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

        public Guid Save(string content)
        {
            var id = Guid.NewGuid();

            var path = $"{dataPath}/{id}.txt";

            using (var fs = File.CreateText(path))
			{
                fs.Write(content);
			}
            return id;
        }

        public string GetContent(Guid id)
        {
			var path = $"{dataPath}/{id}.txt";
            if (File.Exists(path))
                return File.ReadAllText(path);
            throw new IdNotFoundException();
        }
    }
}
