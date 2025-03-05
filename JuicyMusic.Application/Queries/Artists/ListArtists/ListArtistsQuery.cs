using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListArtists;

public class ListArtistsQuery : IRequest<IQueryable<ArtistResponseDto>>
{

}
