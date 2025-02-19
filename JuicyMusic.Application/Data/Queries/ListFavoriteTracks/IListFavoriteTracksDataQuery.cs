namespace JuicyMusic.Application.Data.Queries.ListFavoriteTracks;

public interface IListFavoriteTracksDataQuery
{
    IQueryable<ListFavoriteTracksDataQueryResult> Execute();
}
