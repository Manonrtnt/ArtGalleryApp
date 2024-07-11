using System.Xml.Linq;

namespace DataSource.Collection
{
    public class Artwork
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Style { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Artist}, {Year} - {Style}";
        }
        
        public string ToXmlString()
        {
            return new XElement("artwork",
                new XElement("title", Title),
                new XElement("artist", Artist),
                new XElement("year", Year),
                new XElement("style", Style)
            ).ToString();
        }
    }
}


