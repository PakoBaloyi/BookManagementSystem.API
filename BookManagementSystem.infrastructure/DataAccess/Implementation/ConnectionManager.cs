using BookManagementSystem.Domain.Enum;
using BookManagementSystem.Domain.Models;
using BookManagementSystem.infrastructure.DataAccess.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;


namespace BookManagementSystem.infrastructure.DataAccess.Implementation
{
    public class ConnectionManager(IOptions<ConnectionStrings> config) : IConnectionManager
    {
        private readonly ConnectionStrings _config = config.Value;

        public SqlConnection DbConnection(DbConnectionEnum dbConnectionEnum)
        {
            return new SqlConnection(_config.Default);
        }
    }
}