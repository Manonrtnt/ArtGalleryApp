using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataSource.Collection;

namespace ArtGalleryApp;

public static class Utils
{
    public static List<Artwork> artworks = new();

    // Chemins des fichiers JSON et XML
    public static string pathJsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "DataSource", "JSON", "Artwork.json");
    public static string pathXmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "DataSource", "XML", "Artwork.xml");

    // Chargement des œuvres depuis le fichier JSON
    public static void LoadArtworksFromFiles()
    {
        try
        {
            string jsonFilePath = pathJsonFile;
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                artworks = JsonConvert.DeserializeObject<List<Artwork>>(jsonContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading artworks: {ex.Message}");
        }
    }

    // Sauvegarde des œuvres au format XML
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

    // Transformation des données JSON en XML
    public static void TransformJsonToXml(string sourceFilePathJson, string destinationFilePathXml)
    {
        try
        {
            JArray jsonContent = JArray.Parse(File.ReadAllText(sourceFilePathJson));

            List<Artwork> artworksToTransform = jsonContent.ToObject<List<Artwork>>();

            // Transformation des données JSON en XML
            XDocument xmlOutput = new XDocument(
                new XElement("artworks",
                    artworksToTransform.Select(a => XElement.Parse(a.ToXmlString()))
                )
            );
            xmlOutput.Save(destinationFilePathXml);
            Console.WriteLine($"JSON data transformed and saved as XML to {destinationFilePathXml}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error transforming JSON data to XML: {ex.Message}");
        }
    }

    // Recherche avancée d'œuvres
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
        Console.WriteLine("Search Results:");
        foreach (var artwork in results)
        {
            Console.WriteLine(artwork);
        }
    }

    // Ajout d'une nouvelle œuvre
    public static void AddArtwork(Artwork newArtwork)
    {
        artworks.Add(newArtwork);
        SaveArtworksToJson(pathJsonFile);
    }

    // Sauvegarde des œuvres au format JSON
    public static void SaveArtworksToJson(string filePath)
    {
        try
        {
            string jsonContent = JsonConvert.SerializeObject(artworks, Formatting.Indented);
            File.WriteAllText(filePath, jsonContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving artworks as JSON: {ex.Message}");
        }
    }

    // Téléchargement du fichier JSON
    public static void DownloadJsonFile(string destinationFilePath)
    {
        try
        {
            SaveArtworksToJson(destinationFilePath);
            Console.WriteLine($"JSON file downloaded to: {destinationFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading JSON file: {ex.Message}");
        }
    }

    // Affichage du nombre total d'œuvres d'art
    public static void DisplayTotalArtwork()
    {
        int totalArtworks = artworks.Count();
        Console.WriteLine($"Total number of artworks: {totalArtworks}");
    }
}
