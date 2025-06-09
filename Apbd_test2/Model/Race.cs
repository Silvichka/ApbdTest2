using System.ComponentModel.DataAnnotations;

namespace Apbd_test2.Model;

public class Race
{
    [Key]
    public int RaceId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Location { get; set; }
    public DateTime Date { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; }
}