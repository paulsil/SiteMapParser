using System;
using System.Collections.Generic;
using System.IO;

namespace SiteMapConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter domain to parse robots.txt file:");
            var domain = Console.ReadLine();
            var sitemaps = new RobotsFileParser(domain).SiteMapUrls();

            var siteUrls = new List<string>();
            var productUrls = new List<string>();

            foreach (var fileUrl in sitemaps)
            {
                new SiteMapUrlHandler().GetFileHandler(fileUrl).Process(
                    (url) =>
                    {
                        siteUrls.Add(url.loc);

                        if(url.loc.Contains("/product/"))
                            productUrls.Add(url.loc);
                    });
            }
            
            WriteLinkToFile(siteUrls, "siteurls.csv");
            WriteLinkToFile(productUrls, "products.csv");

            Console.WriteLine("fetched {0} urls",siteUrls.Count);
            Console.WriteLine("Press any key to close..");
            Console.ReadKey();
        }

        private static void WriteLinkToFile(IEnumerable<string> siteUrls, string fileName)
        {
            using (var file = File.CreateText(fileName))
            {
                foreach (var arr in siteUrls)
                {
                    file.WriteLine(string.Join(",", arr));
                }
            }
        }
    }
}
