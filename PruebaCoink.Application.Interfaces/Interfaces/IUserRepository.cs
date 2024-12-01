using PruebaCoink.Application.Dtos.User.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<GetAllUsersResponseDto>> GetAllUsers(string storeProcedureName, object parameter);
    }
}
