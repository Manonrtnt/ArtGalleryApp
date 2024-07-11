namespace DataSource.Collection;

public class ArtworksWrapper
{
    public ArtworksWrapper(List<Artwork> artworks)
    {
        Artworks = artworks;
    }

    public List<Artwork> Artworks { get; set; }
}