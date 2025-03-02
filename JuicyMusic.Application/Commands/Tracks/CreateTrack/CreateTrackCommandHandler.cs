using MediatR;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Application.Data.Repository.TrackRepository;
using JuicyMusic.Domain.Models;
using JuicyMusic.Application.Data.Repository.AlbumRepository;
using JuicyMusic.Application.Data.Repository.ArtistRepository;
using JuicyMusic.Application.Data.Repository.GenreRepository;

namespace JuicyMusic.Application.Commands.Tracks.CreateTrack;

internal class CreateTrackCommandHandler(
    ITrackRepository trackRepository,
    IAlbumRepository albumRepository,
    IArtistRepository artistRepository,
    IGenreRepository genreRepository) : IRequestHandler<CreateTrackCommand, TrackDto>
{
    public async Task<TrackDto> Handle(CreateTrackCommand command, CancellationToken cancellationToken)
    {
        // query the genre, album and artist based on the ids
        var genre = await genreRepository.GetGenreById(command.GenreId);
        var album = await albumRepository.GetAlbumById(command.AlbumId);
        var artist = await artistRepository.GetArtistById(command.ArtistId);

        if (genre is null || album is null || artist is null)
            throw new InvalidOperationException("Invalid genre, album or artist ID");

        // construct the track object
        Track track = Track.Create(
            Guid.NewGuid(),
            command.Name,
            command.DurationMs,
            album,
            genre,
            artist,
            command.ImageUrl
        );

        // call repo save method
        await trackRepository.Save(track);

        // return the track dto
        return new TrackDto
        {
            Id = track.Id,
            Name = track.Name,
            ArtistName = artist.Name,
            AlbumName = album.Name,
            GenreName = genre.Name,
            ImageUrl = track.ImageUrl
        };
    }
}
