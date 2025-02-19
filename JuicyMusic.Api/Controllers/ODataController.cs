using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using JuicyMusic.Application.Data.Queries.ListTracks;

namespace JuicyMusic.Api.Controllers;

[Route("odata")]
public class ODataController(IListTracksDataQuery query) : Controller
{
    [HttpGet("tracks")]
    [EnableQuery]
    public IQueryable<ListTracksDataQueryResult> GetTracks()
        => query.Execute();
}
