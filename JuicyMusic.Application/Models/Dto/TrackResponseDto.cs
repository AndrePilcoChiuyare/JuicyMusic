namespace JuicyMusic.Application.Models.Dto;

public class TrackResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int DurationMs { get; set; }

    public string GenreName { get; set; }

    public string AlbumName { get; set; }

    public string ArtistName { get; set; }

    public string ImageUrl { get; set; }
}
