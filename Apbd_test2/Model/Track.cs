using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apbd_test2.Model;

public class Track
{
    [Key] 
    public int TrackId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double LengthKm { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; }
}