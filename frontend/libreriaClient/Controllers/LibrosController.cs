using libreriaClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace libreriaClient.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibrosService _service;

        public LibrosController(ILibrosService service)
        {
            _service = service;
        }

        public async Task<IActionResult> LibrosIndex()
        {

            return View();
        }

        public async Task<IActionResult> LibrosForm()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLibrosByName(string keyword)
        {
            var response = await _service.GetLibrosByKeyboard(keyword);

            return View("LibrosIndex",response);
        }
    }
}
