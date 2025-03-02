using JuicyMusic.Domain.Models;

namespace JuicyMusic.Application.Data.Repository.TrackRepository;

public interface ITrackRepository
{
    public Task<Track?> GetTrackById(Guid id);

    public Task Save(Track track);
}
