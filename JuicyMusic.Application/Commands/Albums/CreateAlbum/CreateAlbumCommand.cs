using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Commands.Albums;

public record CreateAlbumCommand : IRequest<AlbumResponseDto>
{
    public string Name { get; set; }

    public int TypeId { get; set; }

    public int TotalTracks { get; set; }

    public string ReleaseDate { get; set; }

    public int DurationMs { get; set; }

    public Guid GenreId { get; set; }

    public Guid ArtistId { get; set; }

    public string ImageUrl { get; set; }
}
