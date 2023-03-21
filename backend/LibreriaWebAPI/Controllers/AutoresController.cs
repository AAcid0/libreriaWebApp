using Libreria.Domain;
using Libreria.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.API.Controllers
{
    [Route("api/autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresRepositorio _autoresRepositorio;

        public AutoresController(IAutoresRepositorio autoresRepositorio)
        {
            _autoresRepositorio = autoresRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAutores()
        {
            return Ok(await _autoresRepositorio.GetAllAutores());  
        }

        [HttpGet("by-id/{Id}")]
        public async Task<IActionResult> GetAutorById(long Id)
        {
            return Ok(await _autoresRepositorio.GetAutorById(Id));
        }

        [HttpGet("by-keyword/{keyword}")]
        public async Task<IActionResult> GetAutorByName(string keyword)
        {
            return Ok(await _autoresRepositorio.GetAutorByKeyword(keyword));
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

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> UpdateAutor(long Id, Autor autor)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _autoresRepositorio.UpdateAutor(autor));
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteAutor(long Id)
        {
            return Ok(await _autoresRepositorio.DeleteAutor(Id));
        }
    }
}
