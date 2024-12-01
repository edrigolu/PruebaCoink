using AutoMapper;
using PruebaCoink.Application.Dtos.Usuarios.Response;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.CreateCommand;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.DeleteCommand;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.UpdateCommand;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Usuarios, GetAllUsersResponseDto>().ReverseMap();
            CreateMap<Usuarios, GetUserByIdResponseDto>().ReverseMap();
            CreateMap<CreateUserCommand, Usuarios>();
            CreateMap<UpdateUserCommand, Usuarios>();
            CreateMap<DeleteUserCommand, Usuarios>();            
        }
    }
}
