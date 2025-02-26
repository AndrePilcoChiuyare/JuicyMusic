using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Commands.Tracks;

public class CreateTrackCommand : IRequest<TrackDto>
{
    public string Name { get; set; } = default!;
    public int DurationMs { get; set; }
    public Guid GenreId { get; set; }
    public Guid AlbumId { get; set; }
    public Guid ArtistId { get; set; }
    public string ImageUrl { get; set; } = default!;
}
