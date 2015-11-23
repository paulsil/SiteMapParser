using System;
using SiteMapConsole.Models;

namespace SiteMapConsole.SiteMapFileHandlers
{
    public class UrlSetHandler<T> : ISiteMapFileHandler where T : IHaveLocationElements 
    {
        private readonly string _filename;

        public UrlSetHandler(string filename)
        {
            _filename = filename;
        }

        public void Process(Action<IHaveALocationElement> urlHandler) 
        {
            var urlSet = Deserializer.Deserialize<T>(_filename);
            
            foreach (var url in urlSet.Locations)
            {
                urlHandler(url);
            }
        }
    }
}