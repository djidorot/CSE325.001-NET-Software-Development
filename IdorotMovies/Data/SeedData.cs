using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Models;

namespace MovieApp.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>());

        if (context.Movie.Any()) return;

        context.Movie.AddRange(
            new Movie { Title = "Inception", Genre = "Sci-Fi", Price = 9.99m, ReleaseDate = new DateTime(2010, 7, 16) },
            new Movie { Title = "Interstellar", Genre = "Sci-Fi", Price = 10.99m, ReleaseDate = new DateTime(2014, 11, 7) },
            new Movie { Title = "The Dark Knight", Genre = "Action", Price = 8.99m, ReleaseDate = new DateTime(2008, 7, 18) }
        );
        context.SaveChanges();
    }
}
