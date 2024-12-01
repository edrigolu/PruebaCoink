using Dapper;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Persistence.Context;
using System.Data;

namespace PruebaCoink.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storeProcedureName)
        {
            using var connection = _context.CreateConnection;
            return await connection.QueryAsync<T>(storeProcedureName,
                                                  commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storeProcedureName, object parameter)
        {
            using var connection = _context.CreateConnection;
            DynamicParameters dynamicParameters = new DynamicParameters(parameter);
            T? record = await connection.QuerySingleOrDefaultAsync<T>(storeProcedureName,
                                                                 param: dynamicParameters,
                                                                 commandType: CommandType.StoredProcedure);
            return record!;
        }

        public async Task<bool> ExecAsync(string storeProcedureName, object parameters)
        {
            using var connection = _context.CreateConnection;
            DynamicParameters dynamicParameters = new DynamicParameters(parameters);
            int recordAffected = await connection.ExecuteAsync(storeProcedureName,
                                                               param: dynamicParameters,
                                                               commandType: CommandType.StoredProcedure);
            return recordAffected > 0;
        }

        public async Task<IEnumerable<T>> GetAllWithPaginationAsync(string storeProcedureName, object parameter)
        {
            using var connection = _context.CreateConnection;
            var dynamicParameters = new DynamicParameters(parameter);
            return await connection.QueryAsync<T>(storeProcedureName,
                                                  param: dynamicParameters,
                                                  commandType: CommandType.StoredProcedure);
        }

        public async Task<int> GetCountAsync(string tableName)
        {
            using var connection = _context.CreateConnection;
            var query = $"SELECT COUNT(1) FROM {tableName}";
            var count = await connection.ExecuteScalarAsync<int>(query,
                                                                 commandType: CommandType.Text);
            return count;
        }
    }
}
