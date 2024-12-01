using PruebaCoink.Application.Dtos.Municipalities.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IMunicipioRepository : IGenericRepository<Municipios>
    {
        Task<IEnumerable<GetAllMunicipiosResponseDto>> GetAllMunicipios(string storeProcedureName, object parameter);
    }
}
