using Apbd_test2.Model;
using Microsoft.EntityFrameworkCore;

namespace Apbd_test2.Data;

public class MyDbContext :DbContext
{
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    
    protected MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Racer>().HasData(new List<Racer>()
        {
            new Racer(){RacerId = 1, FirstName = "Michael", LastName = "Schumaher"}
        });
        
        modelBuilder.Entity<Track>().HasData(new List<Track>()
        {
            new Track(){TrackId = 1, LengthKm = 4.5, Name = "Monaco GP"}
        });
        
        modelBuilder.Entity<Race>().HasData(new List<Race>()
        {
            new Race(){RaceId = 1, Name = "MonacoGP", Location = "Monaco", Date = DateTime.Today}
        });
        
        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
        {
            new TrackRace(){TrackRaceId = 1, RaceId = 1, TrackId = 1, Laps = 78, BestTimeInSeconds = 69}
        });
        
        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
        {
            new RaceParticipation(){RacerId = 1, TrackRaceId = 1, Position = 1, FinishTimeInSeconds = 400}
        });
        
    }
}