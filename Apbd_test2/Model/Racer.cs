using System.ComponentModel.DataAnnotations;

namespace Apbd_test2.Model;

public class Racer
{
    [Key] 
    public int RacerId { get; set; }
    [MaxLength(50)]
    public String FirstName { get; set; }
    [MaxLength(100)]
    public String LastName { get; set; }
    
    public ICollection<RaceParticipation> RaceParticipations { get; set; }
}