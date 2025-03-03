using JuicyMusic.Api.Models.Dto;
using JuicyMusic.Application.Commands.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JuicyMusic.Api.Controllers;

[Route("api/genres")]
public class GenresController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateGenreCommand {
            Name = request.Name
        };

        var result = await mediator.Send(command);
        return Ok(result);
    }
}
