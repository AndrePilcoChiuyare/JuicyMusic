using JuicyMusic.Api.Models.Dto;
using JuicyMusic.Application.Commands.Tracks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JuicyMusic.Api.Controllers;

[Route("api/tracks")]
public class TracksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTrack([FromBody] TrackRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateTrackCommand
        {
            Name = request.Name,
            DurationMs = request.DurationMs,
            GenreId = request.GenreId,
            AlbumId = request.AlbumId,
            ArtistId = request.ArtistId,
            ImageUrl = request.ImageUrl
        };

        var result = await mediator.Send(command);
        return Ok(result);
    }
}
