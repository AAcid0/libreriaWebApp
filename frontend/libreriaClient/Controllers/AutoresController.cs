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

        [HttpGet]
        public async Task<IActionResult> AutoresIndex()
        {
            var response = await _service.GetAllAutores();

            return View("AutoresIndex", response);
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
            var autoresResponse = await _service.GetAllAutores();

            return View("AutoresIndex", autoresResponse);
        }

        public async Task<IActionResult> UpdateAutor(long id, string nombre, string city, string email, DateTime fecha)
        {
            await _service.UpdateAutor(new Autor(id, nombre, city, email, fecha));
            var autoresResponse = await _service.GetAllAutores();

            return View("AutoresIndex", autoresResponse);
        }

        public async Task<IActionResult> DeleteAutor(long id)
        {
            //Primero se eliminan los libros relacionados al autor
            //para evitar conflictos
            await _service.DeleteLibrosByAutor(id);

            await _service.DeleteAutor(id);

            var autoresResponse = await _service.GetAllAutores();

            return View("AutoresIndex", autoresResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAutores()
        {
            var response =  await _service.GetAllAutores();

            return View("AutoresIndex", response);
        }
    }
}
