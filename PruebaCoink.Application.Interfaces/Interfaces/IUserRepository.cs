using PruebaCoink.Domain.Entities;
using PruebaCoinl.Application.Dtos.User.Response;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<GetAllUsersResponseDto>> GetAllUsers(string storeProcedureName, object parameter);
    }
}
