using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SiteMapConsole.Models
{
    [XmlType(AnonymousType = true, Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    [XmlRoot(ElementName = "sitemapindex", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9", IsNullable = false)]
    public class sitemapsitemapindex : IHaveLocationElements
    {
        [XmlElement("sitemap")]
        public sitemapsitemap[] sitemap { get; set; }

        public IEnumerable<IHaveALocationElement> Locations
        {
            get { return sitemap == null ? new List<sitemapsitemap>() : sitemap.ToList(); }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class sitemapsitemap : IHaveALocationElement
    {
        public string loc { get; set; }
        public System.DateTime lastmod { get; set; }
    }
}