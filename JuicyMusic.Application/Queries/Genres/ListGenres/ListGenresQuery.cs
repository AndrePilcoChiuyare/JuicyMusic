using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListGenres;

public class ListGenresQuery : IRequest<IQueryable<GenreResponseDto>>
{
    // Add filtering or paging properties if needed
}
