using Microsoft.EntityFrameworkCore;
using Mission6_MBrown.Models;

namespace Mission6_MBrown.Models;
public class MovieInformationContext : DbContext
{
        public MovieInformationContext(DbContextOptions<MovieInformationContext> options) : base(options) //Constructor
        {
        }
        
        //set up for movies table containing instances of Movie
        public DbSet<Movie> Movies { get; set; }
        
        //set up for categories table containing instances of Category
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                //doesn't manually create the Categories table again
                modelBuilder.Entity<Category>().ToTable("Categories");
        }
}
