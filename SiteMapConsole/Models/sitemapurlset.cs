using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SiteMapConsole.Models
{
    [XmlType(AnonymousType = true, Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    [XmlRoot(ElementName = "urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9", IsNullable = false)]
    public class sitemapurlset : IHaveLocationElements
    {
        [XmlElement("url")]
        public sitemapurlsetUrl[] url { get; set; }

        public IEnumerable<IHaveALocationElement> Locations
        {
            get { return url == null ? new List<sitemapurlsetUrl>() : url.ToList(); }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class sitemapurlsetUrl : IHaveALocationElement
    {
        public string loc { get; set; }

        [XmlElement(DataType = "date")]
        public DateTime lastmod { get; set; }
    }   
}