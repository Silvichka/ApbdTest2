using Apbd_test2.Model;

namespace Apbd_test2.Dto.Response;

public class RacerResponseDto
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<RaceParticipationDto> participations { get; set; }
}

public class RaceParticipationDto
{
    public RaceDto Race { get; set; }
    public TrackDto Track { get; set; }
    public int Laps { get; set; }
    public int FinishedTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
}

public class TrackDto
{
    public string Name { get; set; }
    public double LengthInKm { get; set; }
}