using Microsoft.EntityFrameworkCore;

namespace IMDbee.Pages.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Movie> MovieRatings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MovieDb");
        }
    }

}
