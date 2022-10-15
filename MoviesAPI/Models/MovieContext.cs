using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Models
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {

        }

        public DbSet<Movie> MoviesList { get; set; } = null!;
    }
}
