using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;   // <-- for SelectList
using Microsoft.EntityFrameworkCore;        // <-- for AsNoTracking, ToListAsync
using MovieApp.Data;                        // <-- your DbContext namespace
using MovieApp.Models;                      // <-- Movie + MovieIndexViewModel
using System.Linq;                          // <-- for IQueryable/Where/OrderBy

namespace MovieApp.Controllers;

public class MoviesController : Controller
{
    private readonly MovieContext _context;

    public MoviesController(MovieContext context)   // <-- DI constructor
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? searchString, string? movieGenre, int? minYear)
    {
        IQueryable<string> genreQuery =
            from m in _context.Movie
            orderby m.Genre
            select m.Genre;

        var movies = from m in _context.Movie select m;

        if (!string.IsNullOrWhiteSpace(searchString))
            movies = movies.Where(s => s.Title.Contains(searchString));

        if (!string.IsNullOrWhiteSpace(movieGenre))
            movies = movies.Where(x => x.Genre == movieGenre);

        // Year-or-newer filter
        if (minYear.HasValue)
            movies = movies.Where(m => m.ReleaseDate.Year >= minYear.Value);

        var vm = new MovieIndexViewModel
        {
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
            Movies = await movies.AsNoTracking().ToListAsync(),
            SearchString = searchString,
            MovieGenre = movieGenre,
            MinYear = minYear
        };

        return View(vm);
    }
}
