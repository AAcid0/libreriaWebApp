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
        public async Task<bool> DeleteAutor(long id)
        {
            var db = dbConnection();

            var sql = $"DELETE FROM autores WHERE Id = {id}";

            var result = await db.ExecuteAsync(sql, new { });

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
        public async Task<IEnumerable<Autor>> GetAutorByKeyword(string keyword)
        {
            var db = dbConnection();

            var sql = $"SELECT Id, Name, DATEBORN, City, Email FROM autores WHERE Name LIKE '%{keyword}%'";

            return await db.QueryAsync<Autor>(sql, new { });
        }

        /// <summary>
        /// Obtiene información de un autor según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Autor> GetAutorById(long id)
        {
            var db = dbConnection();

            var sql = $"SELECT Id, Name, DATEBORN, City, Email FROM autores WHERE Id = {id}";

            return await db.QueryFirstOrDefaultAsync<Autor>(sql, new { });
        }

        /// <summary>
        /// Actualiza la información de un autor que llega por modelo
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAutor(Autor autor)
        {
            var db = dbConnection();

            var sql = $"UPDATE autores SET Name = '{autor.Name}', DATEBORN = '{autor.DateBorn.ToUniversalTime().ToString("yyyy'-'MM'-'dd")}', City = '{autor.City}', " +
                $"Email = '{autor.Email}' WHERE Id = '{autor.Id}'";
            var result = await db.ExecuteAsync(sql);

            return result > 0;
        }
    }
}
