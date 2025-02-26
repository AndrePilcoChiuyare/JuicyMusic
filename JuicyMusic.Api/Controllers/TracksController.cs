using MediatR;
using Microsoft.AspNetCore.Mvc;
using JuicyMusic.Application.Data.Queries.ListTracks;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Api.Controllers;

/// <summary>
/// Provides access to tracks
/// </summary>
[ApiController]
[Route("api/tracks")]
public class TracksController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Get the complete list of tracks
    /// </summary>
    /// <returns>The collection of found <see cref="TrackDto"/> records.</returns>
    [HttpGet]
    public Task<IReadOnlyCollection<TrackDto>> GetTracks()
        => mediator.Send(new ListTracksQuery());
}
