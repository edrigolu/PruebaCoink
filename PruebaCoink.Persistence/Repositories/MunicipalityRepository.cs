using Dapper;
using PruebaCoink.Application.Dtos.Municipalities.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Domain.Entities;
using PruebaCoink.Persistence.Context;
using System.Data;

namespace PruebaCoink.Persistence.Repositories
{
    public class MunicipalityRepository : GenericRepository<Municipios>, IMunicipioRepository
    {
        private readonly ApplicationDbContext _context;

        public MunicipalityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllMunicipiosResponseDto>> GetAllMunicipios(string storeProcedureName, object parameter)
        {
            using var connection = _context.CreateConnection;
            var dynamicParameters = new DynamicParameters(parameter);
            var municipios = await connection.QueryAsync<GetAllMunicipiosResponseDto>(storeProcedureName,
                                                                                  param: dynamicParameters,
                                                                                  commandType: CommandType.StoredProcedure);
            return municipios;
        }
    }
}
