namespace JuicyMusic.Application.Models.Dto;

public class ArtistResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Followers { get; set; }

    public string Description { get; set; }

    public Guid GenreId { get; set; }

    public string GenreName { get; set; }

    public string ImageUrl { get; set; }
}