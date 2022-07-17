using Microsoft.AspNetCore.Mvc;
using TestMoviesHandler.Data;
using TestMoviesHandler.Data.Models;
using TestMoviesHandler.Data.Repositories;

namespace TestMoviesHandler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : Controller
{
    private readonly MoviesDbContext context;
    private readonly UnitOfWork unitOfWork;

    public MoviesController(MoviesDbContext context)
    {
        unitOfWork = new UnitOfWork(context);
        this.context = context;
    }

    // GET: Movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await unitOfWork.MoviesRepository.GetAllAsync();
    }

    // GET: Movies/Details/5
    [HttpGet("{Id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        Movie? movie = await unitOfWork.MoviesRepository.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> PutMovie(int id, Movie movie)
    {
        await unitOfWork.MoviesRepository.UpdateAsync(movie);

        return NoContent();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<ActionResult<Movie>> PostMovie(Movie movie)
    {
        await unitOfWork.MoviesRepository.AddAsync(movie);

        return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
    }

    // GET: Movies/Delete/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        await unitOfWork.MoviesRepository.RemoveAsync(id);

        return NoContent();
    }
}