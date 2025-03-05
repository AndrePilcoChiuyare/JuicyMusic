using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Commands.Artists;

public record CreateArtistCommand : IRequest<ArtistResponseDto>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public Guid GenreId { get; set; }

    public string ImageUrl { get; set; }
}
