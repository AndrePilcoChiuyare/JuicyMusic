namespace JuicyMusic.Application.Data.Queries.ListAlbums;

public interface IListAlbumsDataQuery
{
    IQueryable<ListAlbumsDataQueryResult> Execute();
}
