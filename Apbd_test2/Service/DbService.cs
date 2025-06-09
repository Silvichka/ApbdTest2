using Apbd_test2.Data;
using Apbd_test2.Dto.Request;
using Apbd_test2.Dto.Response;
using Apbd_test2.Model;
using Microsoft.EntityFrameworkCore;

namespace Apbd_test2.Service;

public class DbService : IDbService
{

    private readonly MyDbContext _context;

    public DbService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<RacerResponseDto> getRacerParticipation(int id)
    {
        var racer = await _context.Racers
            .Include(p => p.RaceParticipations)
            .Include(t => t.RaceParticipations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(p => p.Track)
            .Include(p => p.RaceParticipations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(p => p.Race)
            .FirstOrDefaultAsync(r => r.RacerId == id);

        if (racer == null)
            throw new Exception("No such racer");

        var res = new RacerResponseDto()
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            participations = racer.RaceParticipations.Select(p => new RaceParticipationDto()
            {
                FinishedTimeInSeconds = p.FinishTimeInSeconds,
                Laps = p.TrackRace.Laps,
                Position = p.Position,
                Race = new RaceDto()
                {
                    Name = p.TrackRace.Race.Name,
                    Location = p.TrackRace.Race.Location,
                    Date = p.TrackRace.Race.Date
                },
                Track = new TrackDto()
                {
                    Name = p.TrackRace.Track.Name,
                    LengthInKm = p.TrackRace.Track.LengthKm
                }
            }).ToList()
        };
        return res;
    }

    public async Task<string> addNewParticipation(RequestDto request)
    {

        var raceName = await _context.Races.FirstOrDefaultAsync(p => p.Name == request.raceName);
        if (raceName == null)
            throw new Exception("Race with this name does not exist");

        var trackName = await _context.Tracks.FirstOrDefaultAsync(p => p.Name == request.trackName);
        if (trackName == null)
            throw new Exception("Track with this name does not exist");
        

        foreach (var part in request.participations)
        {
            var racerExist = await _context.Racers.FirstOrDefaultAsync(p => p.RacerId == part.racerId);
            if (racerExist == null)
                throw new Exception($"Racer with id {part.racerId} does not exist");

            var bestTime = await _context.TrackRaces.FirstOrDefaultAsync(p => p.RaceId == raceName.RaceId);
            var newValueForBestTime = bestTime.BestTimeInSeconds;
            if (newValueForBestTime < part.finishTimeInSeconds)
                newValueForBestTime = part.finishTimeInSeconds;

            var newTrackRace = new TrackRace()
            {
                TrackId = trackName.TrackId,
                RaceId = raceName.RaceId,
                BestTimeInSeconds = newValueForBestTime
            };

            var newParticipation = new RaceParticipation()
            {
                TrackRace = newTrackRace,
                Racer = racerExist,
                FinishTimeInSeconds = part.finishTimeInSeconds,
                Position = part.position
            };

            _context.RaceParticipations.Add(newParticipation);

        }
        
        await _context.SaveChangesAsync();
        return "New race participation successfully added.";

    }
}