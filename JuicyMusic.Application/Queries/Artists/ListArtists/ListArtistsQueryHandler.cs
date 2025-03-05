using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListArtists;

public class ListArtistsQueryHandler : IRequestHandler<ListArtistsQuery, IQueryable<ArtistResponseDto>>
{
    private readonly IListArtistsDataQuery _query;

    public ListArtistsQueryHandler(IListArtistsDataQuery query)
    {
        _query = query;
    }

    public Task <IQueryable<ArtistResponseDto>> Handle(ListArtistsQuery request, CancellationToken cancellationToken)
    {
        var results = _query.Execute()
            .Select(t => new ArtistResponseDto
            {
                Id = t.Id,
                Name = t.Name,
                Followers = t.Followers,
                Description = t.Description,
                GenreId = t.GenreId,
                GenreName = t.GenreName,
                ImageUrl = t.ImageUrl
            });

        return Task.FromResult(results);
    }
}
