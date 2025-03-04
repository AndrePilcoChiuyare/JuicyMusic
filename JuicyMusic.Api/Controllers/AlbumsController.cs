using JuicyMusic.Api.Models.Dto;
using JuicyMusic.Application.Commands.Albums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JuicyMusic.Api.Controllers;

[Route("api/albums")]
public class AlbumsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTrack([FromBody] AlbumRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateAlbumCommand
        {
            Name = request.Name,
            TypeId = request.TypeId,
            TotalTracks = request.TotalTracks,
            ReleaseDate = request.ReleaseDate,
            DurationMs = request.DurationMs,
            GenreId = Guid.Parse(request.GenreId),
            ArtistId = Guid.Parse(request.ArtistId),
            ImageUrl = request.ImageUrl
        };

        var result = await mediator.Send(command);
        return Ok(result);
    }
}
