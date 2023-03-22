using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreriaClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] buscadorData formData)
        {
            // Aquí es donde procesarías la información enviada desde el formulario
            // Puedes guardar los datos en una base de datos o hacer lo que necesites
            return Ok();
        }

        public class buscadorData
        {
            public string keyword { get; set; }
        }
    }
}
