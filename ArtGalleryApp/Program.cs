using ArtGalleryApp;
using DataSource.Collection;

class Program
{
    static void Main(string[] args)
    {
        // Chargement des données depuis le fichier JSON
        Utils.LoadArtworksFromFiles();

        Console.WriteLine("Welcome to the Virtual Art Gallery!");
        Console.WriteLine("----------------------------------");

        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    DisplayArtworks();
                    break;
                case "2":
                    Utils.AdvancedSearch();
                    break;
                case "3":
                    SortArtworks();
                    break;
                case "4":
                    Utils.TransformJsonToXml(Utils.pathJsonFile, Utils.pathXmlFile);
                    break;
                case "5":
                    Utils.DisplayTotalArtwork();
                    break;
                case "6":
                    AddNewArtwork();
                    break;
                case "7":
                    DownloadJson();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Thank you for visiting the Virtual Art Gallery!");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Display all artworks");
        Console.WriteLine("2. Advanced search artworks");
        Console.WriteLine("3. Sort artworks");
        Console.WriteLine("4. Transform artworks (JSON to XML)");
        Console.WriteLine("5. Display artwork statistics");
        Console.WriteLine("6. Add new artwork");
        Console.WriteLine("7. Download JSON");
        Console.WriteLine("8. Exit");
        Console.Write("Enter your choice: ");
    }

    static void DisplayArtworks()
    {
        Console.WriteLine("All Artworks:");
        foreach (var artwork in Utils.artworks)
        {
            Console.WriteLine(artwork);
        }
    }

    static void SortArtworks()
    {
        Console.WriteLine("Sort by:");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Artist");
        Console.WriteLine("3. Year");
        Console.WriteLine("4. Style");
        Console.Write("Enter your choice: ");
        string sortChoice = Console.ReadLine();
        Console.WriteLine();

        switch (sortChoice)
        {
            case "1":
                Utils.artworks = Utils.artworks.OrderBy(a => a.Title).ToList();
                break;
            case "2":
                Utils.artworks = Utils.artworks.OrderBy(a => a.Artist).ToList();
                break;
            case "3":
                Utils.artworks = Utils.artworks.OrderBy(a => a.Year).ToList();
                break;
            case "4":
                Utils.artworks = Utils.artworks.OrderBy(a => a.Style).ToList();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine("Artworks sorted successfully.");
        DisplayArtworks();
    }

    static void AddNewArtwork()
    {
        Console.WriteLine("Add a new artwork:");
        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter artist: ");
        string artist = Console.ReadLine();
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Enter style: ");
        string style = Console.ReadLine();

        Artwork newArtwork = new Artwork
        {
            Title = title,
            Artist = artist,
            Year = year,
            Style = style
        };

        Utils.AddArtwork(newArtwork);
        Console.WriteLine("Artwork added successfully.");
    }

    static void DownloadJson()
    {
        try
        {
            // Création du répertoire pour le téléchargement si nécessaire
            string uploadDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "DataSource", "upload");
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            string fileName = "artworks.json";
            string filePath = Path.Combine(uploadDirectory, fileName);

            Utils.DownloadJsonFile(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading JSON file: {ex.Message}");
        }
    }
}
