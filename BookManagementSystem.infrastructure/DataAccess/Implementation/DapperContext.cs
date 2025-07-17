using BookManagementSystem.Domain.Enum;
using BookManagementSystem.infrastructure.DataAccess.Interface;
using Dapper;
using System.Data;

namespace BookManagementSystem.infrastructure.DataAccess.Implementation
{
    public class DapperContext(IConnectionManager connectionManager) : IDapperContext
    {
        private readonly IConnectionManager _connectionManager = connectionManager;

        public async Task<T?> GetSingleAsync<T, P>(DbConnectionEnum db, string storedProc, P? param)
        {
            using var conn = _connectionManager.DbConnection(db);
            return await conn.QueryFirstOrDefaultAsync<T>(storedProc, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> GetAsync<T, P>(DbConnectionEnum db, string storedProc, P? param)
        {
            using var conn = _connectionManager.DbConnection(db);
            return await conn.QueryAsync<T>(storedProc, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteAsync<P>(DbConnectionEnum db, string storedProc, P? param)
        {
            using var conn = _connectionManager.DbConnection(db);
            return await conn.ExecuteAsync(storedProc, param, commandType: CommandType.StoredProcedure);
        }
    }
}