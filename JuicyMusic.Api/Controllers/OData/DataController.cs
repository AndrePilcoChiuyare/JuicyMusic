using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using JuicyMusic.Application.Data.Queries.ListTracks;
using MediatR;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Application.Commands.Tracks;
using JuicyMusic.Application.Data.Queries.ListGenres;
using JuicyMusic.Application.Data.Queries.ListAlbums;

namespace JuicyMusic.Api.Controllers;

[Route("odata")]
public class DataController(IMediator mediator) : ODataController
{

    [HttpGet("tracks")]
    [EnableQuery]
    public Task<IQueryable<TrackResponseDto>> GetTracks()
        => mediator.Send(new ListTracksQuery());

    [HttpGet("genres")]
    [EnableQuery]
    public Task<IQueryable<GenreResponseDto>> GetGenres()
        => mediator.Send(new ListGenresQuery());

    [HttpGet("albums")]
    [EnableQuery]
    public Task<IQueryable<AlbumResponseDto>> GetAlbums()
        => mediator.Send(new ListAlbumsQuery());
}
