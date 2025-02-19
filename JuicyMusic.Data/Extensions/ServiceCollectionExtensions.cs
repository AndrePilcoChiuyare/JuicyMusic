using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JuicyMusic.Application.Data.Queries.ListTracks;
using JuicyMusic.Application.Data.Queries.ListAlbums;
using JuicyMusic.Application.Data.Queries.ListArtists;
using JuicyMusic.Application.Data.Queries.ListGenres;
using JuicyMusic.Application.Data.Queries.ListFavoriteAlbums;
using JuicyMusic.Application.Data.Queries.ListFavoriteArtists;
using JuicyMusic.Application.Data.Queries.ListFavoriteTracks;
using JuicyMusic.Application.Data.Queries.ListUsers;
using JuicyMusic.Data.Queries;

namespace JuicyMusic.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IDatabase, JuicyMusicContext>()
            .AddScoped<IListAlbumsDataQuery, ListAlbumsDataQuery>()
            .AddScoped<IListArtistsDataQuery, ListArtistsDataQuery>()
            .AddScoped<IListFavoriteAlbumsDataQuery, ListFavoriteAlbumsDataQuery>()
            .AddScoped<IListFavoriteArtistsDataQuery, ListFavoriteArtistsDataQuery>()
            .AddScoped<IListFavoriteTracksDataQuery, ListFavoriteTracksDataQuery>()
            .AddScoped<IListGenresDataQuery, ListGenresDataQuery>()
            .AddScoped<IListTracksDataQuery, ListTracksDataQuery>()
            .AddScoped<IListUsersDataQuery, ListUsersDataQuery>()
            .AddDbContext<JuicyMusicContext>(options =>
            {
                options.UseSqlite("Data source=juicymusic.db");
            });
    }
}
