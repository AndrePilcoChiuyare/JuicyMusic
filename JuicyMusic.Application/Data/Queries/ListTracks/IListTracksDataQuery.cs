namespace JuicyMusic.Application.Data.Queries.ListTracks;

public interface IListTracksDataQuery
{
    IQueryable<ListTracksDataQueryResult> Execute();
}
