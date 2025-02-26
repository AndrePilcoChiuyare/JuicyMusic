using MediatR;
using JuicyMusic.Application.Models.Dto;

namespace JuicyMusic.Application.Data.Queries.ListTracks;

public class ListTracksQuery : IRequest<IReadOnlyCollection<TrackDto>>
{
    // Add filtering or paging properties if needed
}
