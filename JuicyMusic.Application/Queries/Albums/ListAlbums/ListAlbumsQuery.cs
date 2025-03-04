using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListAlbums;

public class ListAlbumsQuery : IRequest<IQueryable<AlbumResponseDto>>
{

}
