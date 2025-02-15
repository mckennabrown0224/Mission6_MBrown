using Microsoft.EntityFrameworkCore;

namespace Mission6_MBrown.Models
{
    public class MovieInformationContext : DbContext
    {
        public MovieInformationContext(DbContextOptions<MovieInformationContext> options) : base(options) //Constructor
        {
        }
        
        public DbSet<NewMovie> NewMovies { get; set; }
    }
}

