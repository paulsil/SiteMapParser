using System.Collections.Generic;
using System.IO;

namespace SiteMapConsole
{
    public class RobotsFileParser
    {
        private readonly string _hostname;

        public RobotsFileParser(string hostname)
        {
            _hostname = hostname;
        }

        public List<string> SiteMapUrls()
        {
            var filename = FileDownloader.DownloadedFile(string.Format("http://{0}/robots.txt", _hostname));
            var contents = File.ReadAllLines(filename);

            return ExtractSitemapsFrom(contents);
        }

        private static List<string> ExtractSitemapsFrom(string[] contents)
        {
            var sitemaps = new List<string>();

            foreach (var line in contents)
            {
                if (line.Trim().StartsWith("Sitemap:"))
                    sitemaps.Add(line.Trim().Substring(8).Trim());
            }

            return sitemaps;
        }
    }
}