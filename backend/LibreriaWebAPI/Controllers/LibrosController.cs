using Libreria.Domain;
using Libreria.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.API.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosRepositorio _librosRepositorio;

        public LibrosController(ILibrosRepositorio librosRepositorio)
        {
            _librosRepositorio = librosRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibros()
        {
            return Ok(await _librosRepositorio.GetAllLibros());
        }

        [HttpGet("by-keyword/{name}")]
        public async Task<IActionResult> GetLibroByName(string name)
        {
            return Ok(await _librosRepositorio.GetLibroByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibro([FromBody] Libro libro)
        {
            if (libro == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var insert = await _librosRepositorio.CreateLibro(libro);

            return Created("created", insert);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            await _librosRepositorio.DeleteLibro(new Libro { Id = id });

            return NoContent();
        }
    }
}
