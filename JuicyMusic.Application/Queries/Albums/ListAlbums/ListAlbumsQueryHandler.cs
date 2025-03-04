using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListAlbums;

public class ListAlbumsQueryHandler : IRequestHandler<ListAlbumsQuery, IQueryable<AlbumResponseDto>>
{
    private readonly IListAlbumsDataQuery _query;

    public ListAlbumsQueryHandler(IListAlbumsDataQuery query)
    {
        _query = query;
    }

    public Task<IQueryable<AlbumResponseDto>> Handle(ListAlbumsQuery request, CancellationToken cancellationToken)
    {
        var results = _query.Execute()
            .Select(t => new AlbumResponseDto
            {
                Id = t.Id,
                Name = t.Name,
                TypeId = t.TypeId,
                TypeName = t.TypeName,
                TotalTracks = t.TotalTracks,
                ReleaseDate = t.ReleaseDate,
                DurationMs = t.DurationMs,
                GenreId = t.GenreId,
                GenreName = t.GenreName,
                ArtistId = t.ArtistId,
                ArtistName = t.ArtistName,
                ImageUrl = t.ImageUrl
            });

        return Task.FromResult(results);
    }
}
