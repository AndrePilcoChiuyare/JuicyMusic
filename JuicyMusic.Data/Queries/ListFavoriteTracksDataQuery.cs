using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListFavoriteTracks;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Queries;

internal class ListFavoriteTracksDataQuery(JuicyMusicContext db) : IListFavoriteTracksDataQuery
{
    public IQueryable<ListFavoriteTracksDataQueryResult> Execute()
        => db.Set<FavoriteTrackEntity>().AsNoTracking().Select(i => new ListFavoriteTracksDataQueryResult
        {
            Id = i.Id,
            Username = i.User.Username,
            TrackName = i.Track.Name,
        });
}
