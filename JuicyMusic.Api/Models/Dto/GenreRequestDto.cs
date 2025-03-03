using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JuicyMusic.Api.Models.Dto;
public class CreateGenreRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
