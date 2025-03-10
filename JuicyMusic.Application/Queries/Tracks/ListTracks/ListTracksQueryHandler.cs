using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListTracks;

public class ListTracksQueryHandler : IRequestHandler<ListTracksQuery, IQueryable<TrackResponseDto>>
{
    private readonly IListTracksDataQuery _query;

    public ListTracksQueryHandler(IListTracksDataQuery query)
    {
        _query = query;
    }

    public Task<IQueryable<TrackResponseDto>> Handle(ListTracksQuery request, CancellationToken cancellationToken)
    {
        var results = _query.Execute()
            .Select(t => new TrackResponseDto
            {
                Id = t.Id,
                Name = t.Name,
                DurationMs = t.DurationMs,
                GenreId = t.GenreId,
                GenreName = t.GenreName,
                AlbumId = t.AlbumId,
                AlbumName = t.AlbumName,
                ArtistId = t.ArtistId,
                ArtistName = t.ArtistName,
                ImageUrl = t.ImageUrl
            });

        return Task.FromResult(results);
    }
}
