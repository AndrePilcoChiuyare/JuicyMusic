using JuicyMusic.Domain.Models;

namespace JuicyMusic.Data.Repository;

public interface ITrackRepository
{
    public Task<Track?> Get(Guid id);

    public Task Save(Track track);
}
