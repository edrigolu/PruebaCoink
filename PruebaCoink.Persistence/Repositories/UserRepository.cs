using Dapper;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Domain.Entities;
using PruebaCoink.Persistence.Context;
using PruebaCoinl.Application.Dtos.User.Response;
using System.Data;

namespace PruebaCoink.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllUsersResponseDto>> GetAllUsers(string storeProcedureName, object parameter)
        {
            using var connection = _context.CreateConnection;
            var dynamicParameters = new DynamicParameters(parameter);
            var patients = await connection.QueryAsync<GetAllUsersResponseDto>(storeProcedureName,
                                                                                  param: dynamicParameters,
                                                                                  commandType: CommandType.StoredProcedure);
            return patients;
        }
    }
}
