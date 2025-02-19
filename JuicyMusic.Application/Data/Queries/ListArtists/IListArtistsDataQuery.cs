namespace JuicyMusic.Application.Data.Queries.ListArtists;

public interface IListArtistsDataQuery
{
    IQueryable<ListArtistsDataQuery> Execute();
}
