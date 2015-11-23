using System.IO;
using System.Linq;
using System.Net;
using SiteMapConsole.Models;
using SiteMapConsole.SiteMapFileHandlers;

namespace SiteMapConsole
{
    public class SiteMapUrlHandler
    {
        public ISiteMapFileHandler GetFileHandler(string fileUrl)
        {
            var filename = FileDownloader.DownloadedFile(fileUrl);
            var contents = File.ReadAllText(filename);

            if (contents.Contains("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\""))
            {
                return new UrlSetHandler<sitemapurlset>(filename);
            }
            if (contents.Contains("<urlset"))
            {
                return new UrlSetHandler<urlset>(filename);
            }
            if (contents.Contains("sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\""))
            {
                return new SiteMapIndexHandler<sitemapsitemapindex>(filename);
            }
            return new SiteMapIndexHandler<sitemapindex>(filename);
        }
    }
}