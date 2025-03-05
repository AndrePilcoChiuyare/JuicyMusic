using MediatR;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Application.Data.Repository.TrackRepository;
using JuicyMusic.Domain.Models;
using JuicyMusic.Application.Data.Repository.AlbumRepository;
using JuicyMusic.Application.Data.Repository.ArtistRepository;
using JuicyMusic.Application.Data.Repository.GenreRepository;

namespace JuicyMusic.Application.Commands.Tracks;

internal class CreateTrackCommandHandler(
    ITrackRepository trackRepository,
    IAlbumRepository albumRepository,
    IArtistRepository artistRepository,
    IGenreRepository genreRepository) : IRequestHandler<CreateTrackCommand, TrackResponseDto>
{
    public async Task<TrackResponseDto> Handle(CreateTrackCommand command, CancellationToken cancellationToken)
    {
        // query the genre, album and artist based on the ids
        var genre = await genreRepository.GetGenreById(command.GenreId) ?? throw new InvalidOperationException("Invalid genre ID");
        var album = await albumRepository.GetAlbumById(command.AlbumId) ?? throw new InvalidOperationException("Invalid album ID");
        var artist = await artistRepository.GetArtistById(album.Artist.Id) ?? throw new InvalidOperationException("Invalid artist ID");

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
        return new TrackResponseDto
        {
            Id = track.Id,
            Name = track.Name,
            DurationMs = track.DurationMs,
            ArtistId = artist.Id,
            ArtistName = artist.Name,
            AlbumId = album.Id,
            AlbumName = album.Name,
            GenreId = genre.Id,
            GenreName = genre.Name,
            ImageUrl = track.ImageUrl
        };
    }
}
