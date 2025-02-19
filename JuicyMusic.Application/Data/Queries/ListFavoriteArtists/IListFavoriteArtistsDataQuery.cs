namespace JuicyMusic.Application.Data.Queries.ListFavoriteArtists;

public interface IListFavoriteArtistsDataQuery
{
    IQueryable<ListFavoriteArtistsDataQueryResult> Execute();
}
