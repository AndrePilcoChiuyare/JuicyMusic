namespace JuicyMusic.Application.Data.Queries.ListTracks;

public class ListTracksDataQueryResult
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int DurationMs { get; set; }

    public Guid GenreId { get; set; }

    public Guid AlbumId { get; set; }

    public Guid ArtistId { get; set; }

    public string ImageUrl { get; set; }
}
