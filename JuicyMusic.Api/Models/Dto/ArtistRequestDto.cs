using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JuicyMusic.Api.Models.Dto;

public class ArtistRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "GenreId is required.")]
    [JsonPropertyName("genreId")]
    public string GenreId { get; set; }

    [Required(ErrorMessage = "ImageUrl is required")]
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }
}