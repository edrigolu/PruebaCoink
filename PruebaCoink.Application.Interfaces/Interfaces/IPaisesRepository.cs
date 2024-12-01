using PruebaCoink.Application.Dtos.Paises.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IPaisesRepository : IGenericRepository<Paises>
    {
        Task<IEnumerable<GetAllPaisesResponseDto>> GetAllPaises(string storeProcedureName, object parameter);
    }
}
