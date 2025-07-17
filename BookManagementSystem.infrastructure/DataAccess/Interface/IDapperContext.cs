using BookManagementSystem.Domain.Enum;

namespace BookManagementSystem.infrastructure.DataAccess.Interface
{
    public interface IDapperContext
    {
        Task<T?> GetSingleAsync<T, P>(DbConnectionEnum db, string storedProc, P? param);
        Task<IEnumerable<T>> GetAsync<T, P>(DbConnectionEnum db, string storedProc, P? param);
        Task<int> ExecuteAsync<P>(DbConnectionEnum db, string storedProc, P? param);
    }
}
