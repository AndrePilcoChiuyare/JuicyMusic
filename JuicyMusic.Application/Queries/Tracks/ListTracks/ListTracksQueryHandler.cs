using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListTracks;

public class ListTracksQueryHandler : IRequestHandler<ListTracksQuery, IQueryable<TrackDto>>
{
    private readonly IListTracksDataQuery _query;

    public ListTracksQueryHandler(IListTracksDataQuery query)
    {
        _query = query;
    }

    public Task<IQueryable<TrackDto>> Handle(ListTracksQuery request, CancellationToken cancellationToken)
    {
        var results = _query.Execute()
            .Select(t => new TrackDto
            {
                Id = t.Id,
                Name = t.Name,
                DurationMs = t.DurationMs,
                GenreName = t.GenreName,
                AlbumName = t.AlbumName,
                ArtistName = t.ArtistName,
                ImageUrl = t.ImageUrl
            });

        return Task.FromResult(results);
    }
}
