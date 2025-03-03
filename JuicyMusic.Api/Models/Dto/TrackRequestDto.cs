using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JuicyMusic.Api.Models.Dto;

public class TrackRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "DurationMs is required.")]
    [JsonPropertyName("durationMs")]
    public int DurationMs { get; set; }

    [Required(ErrorMessage = "GenreId is required.")]
    [JsonPropertyName("genreId")]
    public Guid GenreId { get; set; }

    [Required(ErrorMessage = "AlbumId is required.")]
    [JsonPropertyName("albumId")]
    public Guid AlbumId { get; set; }

    [Required(ErrorMessage = "ArtistId is required.")]
    [JsonPropertyName("artistId")]
    public Guid ArtistId { get; set; }

    [Required(ErrorMessage = "ImageUrl is required")]
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;
}
