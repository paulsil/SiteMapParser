using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SiteMapConsole.Models
{
    [XmlType(AnonymousType = true, Namespace = "http://www.google.com/schemas/sitemap/0.9")]
    [XmlRoot(Namespace = "http://www.google.com/schemas/sitemap/0.9", IsNullable = false)]
    public class urlset : IHaveLocationElements
    {
        [XmlElement("url")]
        public urlsetUrl[] url { get; set; }

        public IEnumerable<IHaveALocationElement> Locations
        {
            get { return url == null ? new List<urlsetUrl>() : url.ToList(); }
        }
    }

    [XmlType(AnonymousType = true, Namespace = "http://www.google.com/schemas/sitemap/0.9")]
    public class urlsetUrl : IHaveALocationElement
    {
        public string loc { get; set; }
        public DateTime lastmod { get; set; }
        public string changefreq { get; set; }
        public decimal priority { get; set; }
        [XmlElement(Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
        public image image { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
    [XmlRoot(Namespace = "http://www.google.com/schemas/sitemap-image/1.1", IsNullable = false)]
    public class image
    {
        public string loc { get; set; }
    }
}