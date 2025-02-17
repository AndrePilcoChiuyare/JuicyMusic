using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JuicyMusic.Application.Data.Queries.ListTracks;
using JuicyMusic.Data.Queries;

namespace JuicyMusic.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IDatabase, JuicyMusicContext>()
            .AddScoped<IListTracksDataQuery, ListTracksDataQuery>()
            .AddDbContext<JuicyMusicContext>(options =>
            {
                options.UseSqlite("Data source=juicymusic.db");
            });
    }
}
