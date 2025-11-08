using Microsoft.EntityFrameworkCore;
using IdorotMovies.Models;

namespace IdorotMovies.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

    public DbSet<Movie> Movie { get; set; } = default!; // default! to satisfy nullable
}
