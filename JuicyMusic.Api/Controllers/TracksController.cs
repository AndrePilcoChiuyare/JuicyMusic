using JuicyMusic.Application.Commands.Tracks;
using JuicyMusic.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JuicyMusic.Api.Controllers;

[Route("api/tracks")]
public class TracksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task<TrackResponseDto> CreateTrack([FromBody] CreateTrackCommand command)
        => mediator.Send(command);
}
