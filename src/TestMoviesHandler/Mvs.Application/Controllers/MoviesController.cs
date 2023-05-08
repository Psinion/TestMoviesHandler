using Microsoft.AspNetCore.Mvc;
using Mvs.Data.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.DTOs;
using Mvs.Domain.Entities;

namespace Mvs.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly UnitOfWork unitOfWork;
    private MoviesDbContext context;

    public MoviesController(MoviesDbContext context)
    {
        unitOfWork = new UnitOfWork(context);
        this.context = context;
    }

    [HttpGet("TestMethod")]
    public async Task<ActionResult<IEnumerable<Movie>>> GetTestMethod()
    {
        throw new Exception("Kekes");
    }

    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await unitOfWork.MoviesRepository.GetAllWithActorsAsync();
    }

    // GET: Movies/Details/5
    [HttpGet("{Id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        Movie? movie = await unitOfWork.MoviesRepository.GetByIdWithActorsAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }

    [HttpGet("get_slim_movie/{Id}")]
    public async Task<ActionResult<MovieSlimDto>> GetSlimMovie(int id)
    {
        Movie? movie = await unitOfWork.MoviesRepository.GetByIdWithActorsAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        List<ActorSlimDto> actorsDto = new List<ActorSlimDto>(movie.Actors.Count);

        foreach (var actor in movie.Actors)
        {
            actorsDto.Add(new ActorSlimDto()
            {
                Id = actor.Id,
                Name = actor.Name,
                Surname = actor.Surname
            });
        }

        MovieSlimDto movieDto = new MovieSlimDto()
        {
            Id = movie.Id,
            Description = movie.Description,
            Genre = movie.Genre,
            Title = movie.Title,
            Actors = actorsDto
        };

        return movieDto;
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
    public async Task<ActionResult<MovieCreateDto>> PostMovie(MovieCreateDto movieDto)
    {
        if (movieDto.Id == 0)
        {
            Movie movie = new Movie()
            {
                Id = movieDto.Id,
                Title = movieDto.Title,
                Description = movieDto.Description,
                Genre = movieDto.Genre
            };

            List<Actor> actors = new List<Actor>();
            foreach (var actorId in movieDto.ActorsId)
            {
                Actor actor = await unitOfWork.ActorsRepository.GetByIdAsync(actorId);
                if (actor != null)
                {
                    actors.Add(actor);
                }
            }

            movie.Actors = actors;
            await unitOfWork.MoviesRepository.CreateAsync(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }
        else
        {
            Movie movie = await unitOfWork.MoviesRepository.GetByIdWithActorsAsync(movieDto.Id);

            movie.Title = movieDto.Title;
            movie.Description = movieDto.Description;
            movie.Genre = movieDto.Genre;

            for (int i = movie.Actors.Count - 1; i >= 0; i--)
            {
                movie.Actors.RemoveAt(i);
            }

            foreach (var actorId in movieDto.ActorsId)
            {
                Actor actor = await unitOfWork.ActorsRepository.GetByIdAsync(actorId);
                if (actor != null)
                {
                    movie.Actors.Add(actor);
                }
            }

            await unitOfWork.MoviesRepository.UpdateAsync(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }
    }

    // GET: Movies/Delete/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        await unitOfWork.MoviesRepository.DeleteAsync(id);

        return NoContent();
    }
}