using Microsoft.AspNetCore.Mvc;
using Mvs.Data.Access.EF.Repositories;
using Mvs.Data.Contexts;
using Mvs.Data.Repositories;
using Mvs.Domain.Entities;

namespace Mvs.Application.Controllers;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
    {
        return await unitOfWork.ActorsRepository.GetAllAsync();
    }
}