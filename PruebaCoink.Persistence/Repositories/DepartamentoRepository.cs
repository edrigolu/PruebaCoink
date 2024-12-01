using Dapper;
using PruebaCoink.Application.Dtos.Departaments.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Domain.Entities;
using PruebaCoink.Persistence.Context;
using System.Data;

namespace PruebaCoink.Persistence.Repositories
{
    public class DepartamentoRepository : GenericRepository<Departamentos>,IDepartamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllDepartamentosResponseDto>> GetAllDepartamentos(string storeProcedureName, object parameter)
        {
            using var connection = _context.CreateConnection;
            var dynamicParameters = new DynamicParameters(parameter);
            var departamentos = await connection.QueryAsync<GetAllDepartamentosResponseDto>(storeProcedureName,
                                                                                  param: dynamicParameters,
                                                                                  commandType: CommandType.StoredProcedure);
            return departamentos;
        }
    }
}
