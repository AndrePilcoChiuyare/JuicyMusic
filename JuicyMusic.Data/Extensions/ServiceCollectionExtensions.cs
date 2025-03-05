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
using JuicyMusic.Application.Data.Repository.TrackRepository;
using JuicyMusic.Data.Repository.TrackRepository;
using JuicyMusic.Application.Data.Repository.AlbumRepository;
using JuicyMusic.Data.Repository.AlbumRepository;
using JuicyMusic.Application.Data.Repository.ArtistRepository;
using JuicyMusic.Data.Repository.ArtistRepository;
using JuicyMusic.Application.Data.Repository.GenreRepository;
using JuicyMusic.Data.Repository.GenreRepository;

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
            .AddScoped<ITrackRepository, TrackRepository>()
            .AddScoped<IAlbumRepository, AlbumRepository>()
            .AddScoped<IArtistRepository, ArtistRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddDbContext<JuicyMusicContext>(options =>
            {
                options.UseSqlite("Data Source=C:\\Users\\andre\\OneDrive\\Documentos\\JuicyMusic\\JuicyMusic.Data\\juicymusic.db");
            });
    }
}
