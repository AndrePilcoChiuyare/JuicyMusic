using MediatR;
using JuicyMusic.Application.Commands.Tracks;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Commands;

public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, TrackDto>
{
    private readonly JuicyMusicContext _context;

    public CreateTrackCommandHandler(JuicyMusicContext context)
    {
        _context = context;
    }

    public async Task<TrackDto> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
    {
        var trackEntity = new TrackEntity
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            DurationMs = request.DurationMs,
            GenreId = request.GenreId,
            AlbumId = request.AlbumId,
            ArtistId = request.ArtistId,
            ImageUrl = request.ImageUrl
        };

        _context.Tracks.Add(trackEntity);
        await _context.SaveChangesAsync(cancellationToken);

        var createdTrack = await _context.Tracks
            .Where(t => t.Id == trackEntity.Id)
            .Select(t => new TrackDto
            {
                Id = t.Id,
                Name = t.Name,
                DurationMs = t.DurationMs,
                GenreName = t.Genre.Name,
                AlbumName = t.Album.Name,
                ArtistName = t.Artist.Name,
                ImageUrl = t.ImageUrl
            })
            .FirstAsync(cancellationToken);

        return createdTrack;
    }
}
