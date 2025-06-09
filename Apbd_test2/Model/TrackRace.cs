using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apbd_test2.Model;

public class TrackRace
{
    [Key]
    public int TrackRaceId { get; set; }
    [ForeignKey(nameof(Track))] 
    public int TrackId { get; set; }
    [ForeignKey(nameof(Race))] 
    public int RaceId { get; set; }
    public int Laps { get; set; }
    public int? BestTimeInSeconds { get; set; }

    public Track Track { get; set; }
    public Race Race { get; set; }
}