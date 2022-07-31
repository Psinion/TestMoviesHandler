using Microsoft.AspNetCore.Mvc;
using TestMoviesHandler.Data;
using TestMoviesHandler.Data.Models;
using TestMoviesHandler.Data.Repositories;

namespace TestMoviesHandler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController : Controller
{
    private readonly UnitOfWork unitOfWork;
    private MoviesDbContext context;

    public ActorsController(MoviesDbContext context)
    {
        unitOfWork = new UnitOfWork(context);
        this.context = context;
    }

    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> GetMovies()
    {
        return await unitOfWork.ActorsRepository.GetAllAsync();
    }
}