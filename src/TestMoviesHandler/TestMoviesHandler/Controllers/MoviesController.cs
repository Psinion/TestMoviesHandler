using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMoviesHandler.Models;

namespace TestMoviesHandler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : Controller
{
    private readonly MoviesDbContext context;

    public MoviesController(MoviesDbContext context)
    {
        this.context = context;
    }

    // GET: Movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await context.Movies.ToListAsync();
    }

    // GET: Movies/Details/5
    [HttpGet("{Id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        Movie? movie = await context.Movies
            .FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> PutMovie(int id, Movie movie)
    {
        movie.Id = id;

        context.Entry(movie).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<ActionResult<Movie>> PostMovie(Movie movie)
    {
        context.Movies.Add(movie);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
    }

    // GET: Movies/Delete/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Movie>> DeleteMovie(int id)
    {
        var movie = await context.Movies.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        context.Movies.Remove(movie);
        await context.SaveChangesAsync();

        return movie;
    }

    private bool MovieExists(int id)
    {
        return (context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}