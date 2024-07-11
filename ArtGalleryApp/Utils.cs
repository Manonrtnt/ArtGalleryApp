using System.Xml.Linq;
using Newtonsoft.Json;
using DataSource.Collection;
using Newtonsoft.Json.Linq;

namespace ArtGalleryApp
{
    public static class Utils
    {
        public static List<Artwork> artworks = new();

        public static string pathJsonFile =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "DataSource", "JSON", "Artwork.json").ToString();
        public static string pathXmlFile =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "DataSource", "XML", "Artwork.xml").ToString();

        public static void LoadArtworksFromFiles()
        {
            try
            {
                string jsonFilePath = pathJsonFile;
                // Load from JSON file
                if (File.Exists(jsonFilePath))
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);
                    var artworksWrapper = JsonConvert.DeserializeObject<ArtworksWrapper>(jsonContent);
                    artworks.AddRange(artworksWrapper.Artworks);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading artworks: {ex.Message}");
            }
        }

        public static void SaveArtworksToXml(string filePath)
        {
            try
            {
                XDocument xmlDoc = new XDocument(
                    new XElement("artworks",
                        artworks.Select(a => XElement.Parse(a.ToXmlString()))
                    )
                );
                xmlDoc.Save(filePath);
                Console.WriteLine($"Artworks saved as XML to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving artworks as XML: {ex.Message}");
            }
        }

        public static void TransformJsonToXml(string sourceFilePathJson, string destinationFilePathXml)
        {
            try
            {
                JObject jsonContent = JObject.Parse(File.ReadAllText(sourceFilePathJson));
        
                JToken artworksToken;
                if (jsonContent.TryGetValue("artworks", out artworksToken))
                {
                    List<Artwork> artworksToTransform = artworksToken.ToObject<List<Artwork>>();
            
                    // Transform JSON data to XML
                    XDocument xmlOutput = new XDocument(
                        new XElement("artworks",
                            artworksToTransform.Select(a => XElement.Parse(a.ToXmlString()))
                        )
                    );
                    xmlOutput.Save(destinationFilePathXml);
                    Console.WriteLine($"JSON data transformed and saved as XML to {destinationFilePathXml}");
                }
                else
                {
                    Console.WriteLine("No 'artworks' array found in JSON.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error transforming JSON data to XML: {ex.Message}");
            }
        }

        public static void AdvancedSearch()
        {
            Console.WriteLine("Advanced Search Menu:");
            Console.WriteLine("1. Artworks created by a specific artist");
            Console.WriteLine("2. Artworks created before a certain year");
            Console.WriteLine("3. Artworks by a specific style");
            Console.Write("Enter your choice: ");
            string searchChoice = Console.ReadLine();
            Console.WriteLine();

            switch (searchChoice)
            {
                case "1":
                    Console.Write("Enter artist name: ");
                    string artistName = Console.ReadLine().Trim().ToLower();

                    var artistResults = artworks.Where(a => a.Artist.ToLower().Contains(artistName));
                    DisplaySearchResults(artistResults);
                    break;
                case "2":
                    Console.Write("Enter maximum year: ");
                    if (int.TryParse(Console.ReadLine().Trim(), out int maxYear))
                    {
                        var yearResults = artworks.Where(a => a.Year <= maxYear);
                        DisplaySearchResults(yearResults);
                    }
                    else
                    {
                        Console.WriteLine("Invalid year input.");
                    }
                    break;
                case "3":
                    Console.Write("Enter style: ");
                    string style = Console.ReadLine().Trim().ToLower();

                    var styleResults = artworks.Where(a => a.Style.ToLower().Contains(style));
                    DisplaySearchResults(styleResults);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void DisplaySearchResults(IEnumerable<Artwork> results)
        {
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        public static void DisplayTotalArtwork()
        {
            int totalArtworks = artworks.Count();
            Console.WriteLine($"Total number of artworks: {totalArtworks}");
        }

        public static void AddArtwork(Artwork artwork)
        {
            artworks.Add(artwork);
            SaveArtworksToXml(pathXmlFile); // Update XML after adding artwork
            SaveArtworksToJson(pathJsonFile); // Update JSON after adding artwork
        }

        public static void SaveArtworksToJson(string filePath)
        {
            try
            {
                string jsonOutput = JsonConvert.SerializeObject(artworks, Formatting.Indented);
                File.WriteAllText(filePath, jsonOutput);
                Console.WriteLine($"Artworks saved as JSON to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving artworks as JSON: {ex.Message}");
            }
        }

        public static void DownloadJsonFile(string filePath)
        {
            try
            {
                string jsonOutput = JsonConvert.SerializeObject(artworks, Formatting.Indented);
                File.WriteAllText(filePath, jsonOutput);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving artworks as JSON: {ex.Message}");
            }
        }
    }
}
