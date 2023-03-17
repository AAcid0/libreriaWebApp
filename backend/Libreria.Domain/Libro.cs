namespace Libreria.Domain
{
    public class Libro
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public long Year { get; set; }
        public string Gender { get; set; }
        public long PagesCount { get; set; }
    }
}
