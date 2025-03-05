using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JuicyMusic.Api.Models.Dto;

public class AlbumRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "TypeId is required.")]
    [JsonPropertyName("typeId")]
    public int TypeId { get; set; }

    [Required(ErrorMessage = "TotalTracks is required.")]
    [JsonPropertyName("totalTracks")]
    public int TotalTracks { get; set; }

    [JsonPropertyName("releaseDate")]
    public string ReleaseDate { get; set; }

    [Required(ErrorMessage = "DurationMs is required.")]
    [JsonPropertyName("durationMs")]
    public int DurationMs { get; set; }

    [Required(ErrorMessage = "GenreId is required.")]
    [JsonPropertyName("genreId")]
    public string GenreId { get; set; }

    [Required(ErrorMessage = "ArtistId is required.")]
    [JsonPropertyName("artistId")]
    public string ArtistId { get; set; }

    [Required(ErrorMessage = "ImageUrl is required")]
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }
}
