using BookManagementSystem.Domain.Enum;
using Microsoft.Data.SqlClient;


namespace BookManagementSystem.infrastructure.DataAccess.Interface
{
    public interface IConnectionManager
    {
        SqlConnection DbConnection(DbConnectionEnum dbConnectionEnum);
    }
}
