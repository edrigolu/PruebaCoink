using PruebaCoink.Application.Dtos.Usuarios.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IUserRepository : IGenericRepository<Usuarios>
    {
        Task<IEnumerable<GetAllUsersResponseDto>> GetAllUsers(string storeProcedureName, object parameter);
    }
}
