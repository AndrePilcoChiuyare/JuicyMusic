using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Commands.Albums;

public record CreateAlbumCommand : IRequest<AlbumResponseDto>
{

}
