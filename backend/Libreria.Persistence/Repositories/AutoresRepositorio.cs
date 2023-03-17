using Dapper;
using Libreria.Domain;
using Libreria.Persistence.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Libreria.Persistence.Repositories
{
    public class AutoresRepositorio : IAutoresRepositorio
    {
        private readonly MySQLConfiguration _connectionString;

        //Se inyecta la dependencia al repositorio
        public AutoresRepositorio(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>
        /// Crea un autor para la libreria
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public async Task<bool> CreateAutor(Autor autor)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO autores(Name, DATEBORN, City, Email) VALUES(@Name, @DateBorn, @City, @Email)";

            var result = await db.ExecuteAsync(sql, new { autor.Name,  autor.DateBorn, autor.City, autor.Email});

            return result > 0;
        }

        /// <summary>
        /// Elimina a un autor
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAutor(Autor autor)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM autores WHERE Id = @id";

            var result = await db.ExecuteAsync(sql, new { id = autor.Id });

            return result > 0;
        }

        /// <summary>
        /// Obtiene un listado de los autores registrados
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            var db = dbConnection();

            var sql = @"SELECT Id, Name, DATEBORN, City, Email FROM autores";

            return await db.QueryAsync<Autor>(sql, new { });
        }

        /// <summary>
        /// Obtiene información de un autor según su nombre
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public async Task<Autor> GetAutorByName(string _name)
        {
            var db = dbConnection();

            var sql = @"SELECT Id, Name, DATEBORN, City, Email FROM autores WHERE Name = @name";

            return await db.QueryFirstOrDefaultAsync<Autor>(sql, new { name = _name });
        }
    }
}
