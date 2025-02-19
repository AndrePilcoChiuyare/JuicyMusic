using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListFavoriteArtists;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Queries;

internal class ListFavoriteArtistsDataQuery(JuicyMusicContext db) : IListFavoriteArtistsDataQuery
{
    public IQueryable<ListFavoriteArtistsDataQueryResult> Execute()
        => db.Set<FavoriteArtistEntity>().AsNoTracking().Select(i => new ListFavoriteArtistsDataQueryResult
        {
            Id = i.Id,
            Username = i.User.Username,
            ArtistName = i.Artist.Name,
        });
}
