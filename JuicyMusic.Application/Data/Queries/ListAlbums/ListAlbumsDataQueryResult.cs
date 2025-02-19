namespace JuicyMusic.Application.Data.Queries.ListAlbums;

public class ListAlbumsDataQueryResult
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public int TotalTracks { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int DurationMs { get; set; }

    public string GenreName { get; set; }

    public string ArtistName { get; set; }

    public string ImageUrl { get; set; }
}
