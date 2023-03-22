using System.ComponentModel.DataAnnotations;

namespace libreriaClient.Models.Libros
{
    public class Libro
    {
        public Libro() { }
        public Libro(long authorId, string name, long year, string gender, long pagesCount)
        {
            AuthorId = authorId;
            Name = name;
            Year = year;
            Gender = gender;
            PagesCount = pagesCount;
        }

        public Libro(long id, long authorId, string name, long year, string gender, long pagesCount)
        {
            Id = id;
            AuthorId = authorId;
            Name = name;
            Year = year;
            Gender = gender;
            PagesCount = pagesCount;
        }


        public long Id { get; set; }
        public long AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un año de lanzamiento")]
        public long Year { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un género")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un conteo de páginas")]
        public long PagesCount { get; set; }
    }
}
