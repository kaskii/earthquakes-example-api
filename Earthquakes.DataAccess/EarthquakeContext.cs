using Earthquakes.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace Earthquakes.DataAccess;

public class EarthquakeContext : DbContext
{
    public DbSet<Earthquake> Earthquakes { get; set; } = null!;
    
    // Types
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Land> Lands { get; set; } = null!;
    
    public EarthquakeContext(DbContextOptions<EarthquakeContext> options) : base(options)
    {
        
    }
}