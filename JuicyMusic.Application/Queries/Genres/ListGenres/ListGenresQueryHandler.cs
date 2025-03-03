using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListGenres;

public class ListGenresQueryHandler : IRequestHandler<ListGenresQuery, IQueryable<GenreResponseDto>>
{
    private readonly IListGenresDataQuery _query;

    public ListGenresQueryHandler(IListGenresDataQuery query)
    {
        _query = query;
    }

    public Task<IQueryable<GenreResponseDto>> Handle(ListGenresQuery request, CancellationToken cancellationToken)
    {
        var results = _query.Execute()
            .Select(t => new GenreResponseDto
            {
                Id = t.Id,
                Name = t.GenreName
            });

        return Task.FromResult(results);
    }
}
