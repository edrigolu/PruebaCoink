using Dapper;
using PruebaCoink.Application.Dtos.Paises.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Domain.Entities;
using PruebaCoink.Persistence.Context;
using System.Data;

namespace PruebaCoink.Persistence.Repositories
{
    public class PaisesRepository : GenericRepository<Paises>, IPaisesRepository
    {
        private readonly ApplicationDbContext _context;

        public PaisesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPaisesResponseDto>> GetAllPaises(string storeProcedureName, object parameter)
        {
            using var connection = _context.CreateConnection;
            var dynamicParameters = new DynamicParameters(parameter);
            var paises = await connection.QueryAsync<GetAllPaisesResponseDto>(storeProcedureName,
                                                                                  param: dynamicParameters,
                                                                                  commandType: CommandType.StoredProcedure);
            return paises;
        }
    }
}
