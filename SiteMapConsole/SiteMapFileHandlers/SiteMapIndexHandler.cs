using System;
using SiteMapConsole.Models;

namespace SiteMapConsole.SiteMapFileHandlers
{
    public class SiteMapIndexHandler<T> : ISiteMapFileHandler where T : IHaveLocationElements
    {
        private readonly string _filename;

        public SiteMapIndexHandler(string filename)
        {
            _filename = filename;
        }

        public void Process(Action<IHaveALocationElement> urlHandler) 
        {
            var sitemapindex = Deserializer.Deserialize<T>(_filename);

            foreach (var siteMapLink in sitemapindex.Locations)
            {
                new SiteMapUrlHandler().GetFileHandler(siteMapLink.loc).Process(urlHandler);
            }
        }
    }
}