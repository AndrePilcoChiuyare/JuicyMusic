using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using JuicyMusic.Application.Data.Queries.ListTracks;
using JuicyMusic.Application.Data.Queries.ListGenres;
using JuicyMusic.Application.Data.Queries.ListAlbums;

namespace JuicyMusic.Api.Configuration;

public static class ODataConfiguration
{
    public static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();

        // Configure tracks entity set
        EntitySetConfiguration<ListTracksDataQueryResult> tracksSet = builder
            .EntitySet<ListTracksDataQueryResult>("tracks");
        tracksSet.EntityType.HasKey(t => t.Id);

        // Configure genres entity set
        EntitySetConfiguration<ListGenresDataQueryResult> genresSet = builder
            .EntitySet<ListGenresDataQueryResult>("genres");
        genresSet.EntityType.HasKey(g => g.Id);

        // Configure albums entity set
        EntitySetConfiguration<ListAlbumsDataQueryResult> albumsSet = builder
            .EntitySet<ListAlbumsDataQueryResult>("albums");
        albumsSet.EntityType.HasKey(a => a.Id);

        return builder.GetEdmModel();
    }
}
