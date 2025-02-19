namespace JuicyMusic.Application.Data.Queries.ListGenres;

public interface IListGenresDataQuery
{
    IQueryable<ListGenresDataQueryResult> Execute();
}
