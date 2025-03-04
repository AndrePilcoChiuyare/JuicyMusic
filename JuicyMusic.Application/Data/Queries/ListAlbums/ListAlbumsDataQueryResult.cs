namespace JuicyMusic.Application.Data.Queries.ListAlbums;

public class ListAlbumsDataQueryResult
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int TypeId { get; set; }

    public string TypeName { get; set; }

    public int TotalTracks { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int DurationMs { get; set; }

    public Guid GenreId { get; set; }

    public string GenreName { get; set; }

    public Guid ArtistId { get; set; }

    public string ArtistName { get; set; }

    public string ImageUrl { get; set; }
}
