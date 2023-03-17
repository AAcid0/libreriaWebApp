using Dapper;
using Libreria.Domain;
using MySql.Data.MySqlClient;

namespace Libreria.Persistence.Repositories
{
    public class LibrosRepositorio : ILibrosRepositorio
    {
        private readonly MySQLConfiguration _connectionString;

        //Se inyecta la dependencia al repositorio
        public LibrosRepositorio(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>
        /// Agrega un libro a la libreria
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public async Task<bool> CreateLibro(Libro libro)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO libros(Id, AuthorId, Name, Year) VALUES(@Id, @AuthorId, @Name, @Year)";

            var result = await db.ExecuteAsync(sql, new {libro.Id, libro.AuthorId, libro.Name, libro.Year});

            return result > 0;
        }

        /// <summary>
        /// Elimina un libro de la libreria
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLibro(Libro libro)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM libros WHERE Id = @id";

            var result = await db.ExecuteAsync(sql, new {id = libro.Id});

            return result > 0;
        }

        /// <summary>
        /// Obtiene una colección de libros regitrados
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Libro>> GetAllLibros()
        {
            var db = dbConnection();

            var sql = @"SELECT Id, AuthorId, Name, Year, Gender, PagesCount FROM libros";

            return await db.QueryAsync<Libro>(sql, new { });
        }

        /// <summary>
        /// Obtiene información de un libro según su nombre
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public async Task<Libro> GetLibroByName(string _name)
        {
            var db = dbConnection();

            var sql = @"SELECT Id, AuthorId, Name, Year FROM libros WHERE Name = @name";

            return await db.QueryFirstOrDefaultAsync<Libro>(sql, new { name = _name });
        }
    }
}
