using PruebaCoink.Application.Dtos.Departaments.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IDepartamentoRepository : IGenericRepository<Departamentos>
    {
        Task<IEnumerable<GetAllDepartamentosResponseDto>> GetAllDepartamentos(string storeProcedureName, object parameter);
    }
}
