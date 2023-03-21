using libreriaClient.Models.Autores;
using libreriaClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace libreriaClient.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IAutoresService _service;

        public AutoresController(IAutoresService service)
        {
            _service = service;
        }

        public async Task<IActionResult> AutoresIndex()
        {
            return View();
        }

        public async Task<IActionResult> AutoresForm(long? autorId)
        {
            if(autorId == null)
                return View();
            else
            {
                var response = await _service.GetAutorById(autorId ?? 0);
                return View(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAutoresByKeyword(string keyword)
        {
            var response = await _service.GetAutoresByKeyword(keyword);

            return View("AutoresIndex", response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(string nombre, string city, string email, DateTime fecha)
        {
            await _service.CreateAutor(new Autor(0,nombre, city, email, fecha));

            return View("AutoresIndex");
        }

        public async Task<IActionResult> UpdateAutor(long id, string nombre, string city, string email, DateTime fecha)
        {
            await _service.UpdateAutor(new Autor(id, nombre, city, email, fecha));

            return View("AutoresIndex");
        }

        public async Task<IActionResult> DeleteAutor(long id)
        {
            await _service.DeleteAutor(id);

            return View("AutoresIndex");
        }
    }
}
