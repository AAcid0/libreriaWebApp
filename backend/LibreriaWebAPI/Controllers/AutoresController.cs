using Libreria.Domain;
using Libreria.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresRepositorio _autoresRepositorio;

        public AutoresController(IAutoresRepositorio autoresRepositorio)
        {
            _autoresRepositorio = autoresRepositorio;
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetAutorByName(string name)
        {
            return Ok(await _autoresRepositorio.GetAutorByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor([FromBody] Autor autor)
        {
            if (autor == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var insert = await _autoresRepositorio.CreateAutor(autor);

            return Created("created", insert);
        }
    }
}
