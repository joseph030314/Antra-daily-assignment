using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

public class BaseController : Controller
{
    private readonly IGenreService _genreService;

    public BaseController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        ViewBag.Genres = await _genreService.GetAllGenres();
        await next();
    }
}
