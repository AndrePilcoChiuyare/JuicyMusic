using JuicyMusic.Api.Models.Dto;
using JuicyMusic.Application.Commands.Artists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JuicyMusic.Api.Controllers;

[Route("api/artists")]
public class ArtistsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateArtist([FromBody] ArtistRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateArtistCommand
        {
            Name = request.Name,
            Description = request.Description,
            GenreId = Guid.Parse(request.GenreId),
            ImageUrl = request.ImageUrl
        };

        var result = await mediator.Send(command);
        return Ok(result);
    }
}