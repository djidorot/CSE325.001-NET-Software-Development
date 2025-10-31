using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieApp.Models;

public class MovieIndexViewModel
{
    public List<Movie> Movies { get; set; } = new();
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
    public int? MinYear { get; set; } // NEW
}
