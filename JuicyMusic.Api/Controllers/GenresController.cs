using JuicyMusic.Application.Commands.Genres;
using JuicyMusic.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JuicyMusic.Api.Controllers;

[Route("api/genres")]
public class GenresController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task<GenreResponseDto> CreateGenre([FromBody] CreateGenreCommand command)
        => mediator.Send(command);
}
