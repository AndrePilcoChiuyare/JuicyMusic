using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListFavoriteAlbums;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Queries;

internal class ListFavoriteAlbumsDataQuery(JuicyMusicContext db) : IListFavoriteAlbumsDataQuery
{
    public IQueryable<ListFavoriteAlbumsDataQueryResult> Execute()
        => db.Set<FavoriteAlbumEntity>().AsNoTracking().Select(i => new ListFavoriteAlbumsDataQueryResult
        {
            Id = i.Id,
            Username = i.User.Username,
            AlbumName = i.Album.Name,
        });
}
