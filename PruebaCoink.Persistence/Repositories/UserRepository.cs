﻿using Dapper;
using PruebaCoink.Application.Dtos.Usuarios.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Domain.Entities;
using PruebaCoink.Persistence.Context;
using System.Data;

namespace PruebaCoink.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Usuarios>, IUserRepository
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
            var users = await connection.QueryAsync<GetAllUsersResponseDto>(storeProcedureName,
                                                                                  param: dynamicParameters,
                                                                                  commandType: CommandType.StoredProcedure);
            return users;
        }
    }
}
