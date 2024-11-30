using AutoMapper;
using PruebaCoink.Domain.Entities;
using PruebaCoinl.Application.Dtos.User.Response;

namespace PruebaCoink.Application.UseCases.Mappings
{
    public class UserMappingProfile : Profile
    {
        protected UserMappingProfile()
        {
            CreateMap<User, GetAllUsersResponseDto>()
                .ForMember(x => x.EstaActivo, x => x.MapFrom(y => y.Activo == 1 ? "Activo" : "Inactivo"))
                .ReverseMap();
            CreateMap<User, GetUserByIdResponseDto>().ReverseMap();
        }
    }
}
