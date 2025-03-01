using MediatR;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Application.Data.Repository;
using JuicyMusic.Domain.Models;

namespace JuicyMusic.Application.Commands.Tracks.CreateTrack;

internal class CreateTrackCommandHandler(
    ITrackRepository trackRepository) : IRequestHandler<CreateTrackCommand, TrackDto>
{
    public async Task<TrackDto> Handle(CreateTrackCommand command, CancellationToken cancellationToken)
    {
        // query the genre, album and artist based on the ids

        // construct the track object
        Track track = Track.Create(
            Guid.NewGuid(),
            command.Name,
            command.DurationMs,
            command.Album,
            command.Genre,
            command.Artist,
            command.ImageUrl
        );

        // call repo save method
        await trackRepository.Save(track);

        // return the track dto

        return new TrackDto
        {
            Id = track.Id,
            Title = track.Title,
            Artist = track.Artist,
            Album = track.Album,
            Genre = track.Genre,
            ReleaseDate = track.ReleaseDate
        };
    }
}