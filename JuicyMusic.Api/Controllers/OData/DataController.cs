using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using JuicyMusic.Application.Data.Queries.ListTracks;
using MediatR;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Application.Commands.Tracks;

namespace JuicyMusic.Api.Controllers;

[Route("odata")]
public class DataController(IMediator mediator) : ODataController
{

    [HttpGet("tracks")]
    [EnableQuery]
    public Task<IQueryable<TrackResponseDto>> GetTracks()
        => mediator.Send(new ListTracksQuery());
}
