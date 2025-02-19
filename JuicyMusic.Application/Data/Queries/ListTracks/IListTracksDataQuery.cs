// using JuicyMusic.Application.Data.Queries.ListTracks;

namespace JuicyMusic.Application.Data.Queries.ListTracks;

public interface IListTracksDataQuery
{
    IQueryable<ListTracksDataQueryResult> Execute();
}
