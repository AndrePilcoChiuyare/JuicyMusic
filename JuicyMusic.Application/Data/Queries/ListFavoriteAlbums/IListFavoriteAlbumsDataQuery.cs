namespace JuicyMusic.Application.Data.Queries.ListFavoriteAlbums;

public interface IListFavoriteAlbumsDataQuery
{
    IQueryable<ListFavoriteAlbumsDataQueryResult> Execute();
}
