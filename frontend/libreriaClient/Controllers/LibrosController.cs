using libreriaClient.Models.Autores;
using libreriaClient.Models.Libros;
using libreriaClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var response = await _service.GetAllLibros();

            return View(response);
        }

        public async Task<IActionResult> LibrosForm(long? libroId)
        {
            List<SelectListItem> _ObjList = new List<SelectListItem>();
            if (libroId == null) {
                var responseAutores = await _service.GetAllAutores();

                if (responseAutores != null)
                {
                    foreach (var item in responseAutores.ToList())
                    {
                        _ObjList.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                    }

                    ViewBag.AuthorId = _ObjList;
                }
                return View();
            }else
            {
                var responseAutores = await _service.GetAllAutores();

                if (responseAutores != null)
                {
                    foreach (var item in responseAutores.ToList())
                    {
                        _ObjList.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                    }

                    ViewBag.AuthorId = _ObjList;
                }

                var response = await _service.GetLibroById(libroId ?? 0);

                return View(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLibrosByKeyword(string keyword)
        {
            var response = await _service.GetLibrosByKeyword(keyword);

            return View("LibrosIndex",response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibro(int AuthorId, string Nombre, int Year, string Gender, int PagesCount)
        {
            if (!ModelState.IsValid)
                return View("LibrosForm");

            var response = _service.CreateLibro(new Libro(AuthorId, Nombre, Year, Gender, PagesCount));

            return RedirectToAction("LibrosIndex", "Libros");
        }

        public async Task<IActionResult> UpdateLibro(int AuthorId, long Id, string Nombre, int Year, string Gender, int PagesCount)
        {
            if(!ModelState.IsValid) return View("LibrosIndex");

            await _service.UpdateLibro(new Libro(Id, AuthorId, Nombre, Year, Gender, PagesCount));

            return RedirectToAction("LibrosIndex", "Libros");
        }

        public async Task<IActionResult> DeleteLibro(long id)
        {
            await _service.DeleteLibro(id);

            return RedirectToAction("LibrosIndex", "Libros");
        }

        public async Task<IActionResult> GetLibrosByAuthor(int AuthorId)
        {
            var response = await _service.GetLibrosByAuthorId(AuthorId);

            return View("LibrosIndex",response);
        }

    }
}
