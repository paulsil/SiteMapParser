using System.IO;
using System.Xml.Serialization;

namespace SiteMapConsole
{
    public static class Deserializer
    {
        public static T Deserialize<T>(string file)
        {
            var serializer = new XmlSerializer(typeof(T),"");
            using (var reader = new StreamReader(file))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}