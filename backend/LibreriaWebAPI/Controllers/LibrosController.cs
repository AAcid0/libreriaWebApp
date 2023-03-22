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


        [HttpGet("by-id/{Id}")]
        public async Task<IActionResult> GetLibroById(long id)
        {
            return Ok(await _librosRepositorio.GetLibroById(id));
        }

        [HttpGet("by-keyword/{name}")]
        public async Task<IActionResult> GetLibroByKeyword(string name)
        {
            return Ok(await _librosRepositorio.GetLibroByKeyword(name));
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

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteLibro(int Id)
        {
            return Ok(await _librosRepositorio.DeleteLibro(Id));

        }

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> UpdateLibro(long Id, Libro libro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _librosRepositorio.UpdateLibro(libro));
        }

        [HttpGet("by-autor/{authorId}")]
        public async Task<IActionResult> GetLibrosByAuthorId(long authorId)
        {
            return Ok(await _librosRepositorio.GetLibrosByAuthorId(authorId));
        }

        [HttpDelete("delete-by-autor/{authorId}")]
        public async Task<IActionResult> DeleteLibrosByAuthor(long authorId)
        {
            return Ok(await _librosRepositorio.DeleteLibrosByAuthorId(authorId));
        }
    }
}
