using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace libreriaClient.Models.Autores
{
    public class Autor
    {
        public Autor() { }
        public Autor(long id, string name, string city, string email, DateTime dateBorn)
        {
            Id = id;
            Name = name;
            DateBorn = dateBorn;
            City = city;
            Email = email;
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una fecha de nacimiento")]
        public DateTime DateBorn { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una ciudad de origen")]
        public string City { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un email")]
        public string Email { get; set; }
    }
}
