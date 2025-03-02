using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Commands.Genres;

public record CreateGenreCommand : IRequest<GenreResponseDto>
{
    public string Name { get; set; } = default!;
}
