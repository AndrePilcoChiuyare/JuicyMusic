namespace JuicyMusic.Application.Models.Dto;

public class TrackResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int DurationMs { get; set; }

    public Guid GenreId { get; set; }

    public string GenreName { get; set; }

    public Guid AlbumId { get; set; }

    public string AlbumName { get; set; }

    public Guid ArtistId { get; set; }

    public string ArtistName { get; set; }

    public string ImageUrl { get; set; }
}
