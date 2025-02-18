namespace JuicyMusic.Data.Entities;

internal class ArtistEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Followers { get; set; }

    public string Description { get; set; }

    public string Genre { get; set; }

    public string ImageUrl { get; set; }
}
