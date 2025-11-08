using System.ComponentModel.DataAnnotations;

namespace IdorotMovies.Models;

public class Movie
{
    public int Id { get; set; }

    [Required, StringLength(60)]
    public string Title { get; set; } = "";

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [StringLength(30)]
    public string Genre { get; set; } = "";

    [Range(0, 999.99)]
    public decimal Price { get; set; }
}
