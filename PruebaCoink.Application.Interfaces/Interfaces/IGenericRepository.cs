namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string storeProcedureName);
        Task<T> GetByIdAsync(string storeProcedureName, object parameter);
        Task<bool> ExecAsync(string storeProcedureName, object parameters);
        Task<IEnumerable<T>> GetAllWithPaginationAsync(string storeProcedureName, object parameter);
        Task<int> GetCountAsync(string tableName);
    }
}
