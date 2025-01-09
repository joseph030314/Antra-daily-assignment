using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class CastController : BaseController
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService, IGenreService genreService) : base(genreService)
        {
            _castService = castService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var cast = await _castService.GetCastDetails(id);
            if (cast == null)
            {
                return NotFound();
            }
            return View(cast);
        }
    }
}
