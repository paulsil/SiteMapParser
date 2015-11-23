using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SiteMapConsole.Models
{
    [XmlType(AnonymousType=true, Namespace="http://www.google.com/schemas/sitemap/0.9")]
    [XmlRoot(ElementName = "sitemapindex", Namespace="http://www.google.com/schemas/sitemap/0.9", IsNullable=false)]
    public class sitemapindex : IHaveLocationElements
    {
        [XmlElement("sitemap")]
        public sitemap[] sitemap { get; set; }

        public IEnumerable<IHaveALocationElement> Locations
        {
            get { return sitemap == null ? new List<sitemap>() : sitemap.ToList(); }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "http://www.google.com/schemas/sitemap/0.9")]
    public class sitemap : IHaveALocationElement
    {
        public string loc { get; set; }
        public System.DateTime lastmod { get; set; }
    }


   
}