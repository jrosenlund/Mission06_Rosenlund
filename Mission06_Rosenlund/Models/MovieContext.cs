using Microsoft.EntityFrameworkCore;

namespace Mission06_Rosenlund.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { // Constructor
            
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
