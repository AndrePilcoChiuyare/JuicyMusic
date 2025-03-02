using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using JuicyMusic.Application.Data.Queries.ListTracks;

namespace JuicyMusic.Api.Configuration;

public static class ODataConfiguration
{
    public static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();

        EntitySetConfiguration<ListTracksDataQueryResult> formDetailsSet = builder
            .EntitySet<ListTracksDataQueryResult>("tracks");
        formDetailsSet.EntityType.HasKey(r => r.Id);

        return builder.GetEdmModel();
    }
}
