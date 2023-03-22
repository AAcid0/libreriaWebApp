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

            var sql = $"INSERT INTO libros(AuthorId, Name, Year, Gender, PagesCount) VALUES({libro.AuthorId}, '{libro.Name}', {libro.Year}, '{libro.Gender}', {libro.PagesCount})";

            var result = await db.ExecuteAsync(sql, new { });

            return result > 0;
        }

        /// <summary>
        /// Elimina un libro de la libreria
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLibro(long id)
        {
            var db = dbConnection();

            var sql = $"DELETE FROM libros WHERE Id = {id}";

            var result = await db.ExecuteAsync(sql, new {});

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
        public async Task<IEnumerable<Libro>> GetLibroByKeyword(string _name)
        {
            var db = dbConnection();

            var sql = $"SELECT Id, AuthorId, Name, Year, Gender, PagesCount FROM libros WHERE Name LIKE '%{_name}%'";

            return await db.QueryAsync<Libro>(sql, new { });
        }

        /// <summary>
        /// Obtiene un libro según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Libro> GetLibroById(long id)
        {
            var db = dbConnection();

            var sql = $"SELECT Id, AuthorId, Name, Year, Gender, PagesCount FROM libros WHERE Id = {id}";

            return await db.QueryFirstOrDefaultAsync<Libro>(sql, new { });
        }

        /// <summary>
        /// Actualiza la información de un libro
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public async Task<bool> UpdateLibro(Libro libro)
        {
            var db = dbConnection();

            var sql = $"UPDATE libros SET AuthorId = {libro.AuthorId}, Name = '{libro.Name}', Year = {libro.Year}, " +
                $"Gender = '{libro.Gender}', PagesCount = {libro.PagesCount} WHERE Id = {libro.Id}";
            var result = await db.ExecuteAsync(sql);

            return result > 0;
        }

        /// <summary>
        /// Obtiene los libros relacionados a un autor específico
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Libro>> GetLibrosByAuthorId(long authorId)
        {
            var db = dbConnection();

            var sql = $"SELECT Id, AuthorId, Name, Year, Gender, PagesCount FROM libros WHERE AuthorId = {authorId}";
            
            return await db.QueryAsync<Libro>(sql, new { });
        }

        public async Task<bool> DeleteLibrosByAuthorId(long authorId)
        {
            var db = dbConnection();

            var sql = $"DELETE FROM libros WHERE AuthorId = {authorId}";

            var result = await db.ExecuteAsync(sql, new { });

            return result > 0;
        }
    }
}
