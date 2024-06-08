using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IMDbee.Pages.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbee.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;
        public int CurrentYear { get; set; }

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public List<Movie> MovieRatings { get; set; } = new List<Movie>();

        [BindProperty]
        public Movie NewMovie { get; set; }

        public void OnGet()
        {
            MovieRatings = _context.MovieRatings
                .OrderByDescending(m => m.Rating)
                .ToList();
            CurrentYear = DateTime.Now.Year;
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var movie = await _context.MovieRatings.FindAsync(id);
            if (movie != null)
            {
                _context.MovieRatings.Remove(movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id, [Bind("Id,Title,Director,Year,Rating")] Movie editedMovie)
        {
            if (ModelState.IsValid)
            {
                var movie = await _context.MovieRatings.FindAsync(id);
                if (movie != null)
                {
                    movie.Title = editedMovie.Title;
                    movie.Director = editedMovie.Director;
                    movie.Year = editedMovie.Year;
                    movie.Rating = editedMovie.Rating;
                    await _context.SaveChangesAsync();
                }
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (ModelState.IsValid)
            {
                _context.MovieRatings.Add(NewMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            return Page();
        }
    }
}
