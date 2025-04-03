using Microsoft.EntityFrameworkCore;
using Movie_Night_website.Models;

namespace Movie_Night_website
{
    public class MovieNightDatabase(DbContextOptions<MovieNightDatabase> options) : DbContext(options) //special constructor takes dboptions and puts it in dbcontext
    {
        public DbSet<Movie> Movies { get; set; }
        
    }
}
