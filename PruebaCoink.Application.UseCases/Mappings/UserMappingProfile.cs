using AutoMapper;
using PruebaCoink.Application.Dtos.User.Response;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.ChangeUserStatus;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.CreateCommand;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.DeleteCommand;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.UpdateCommand;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.Mappings
{
    public class UserMappingProfile : Profile
    {
        protected UserMappingProfile()
        {
            CreateMap<User, GetAllUsersResponseDto>()
                .ForMember(x => x.EsActivo, x => x.MapFrom(y => y.Activo == 1 ? "Activo" : "Inactivo"))
                .ReverseMap();
            CreateMap<User, GetUserByIdResponseDto>().ReverseMap();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<DeleteUserCommand, User>();
            CreateMap<ChangeUserStatusCommand, User>();
        }
    }
}
