using AutoMapper;
using PruebaCoink.Application.Dtos.Municipalities.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.Mappings
{
    public class MunicipioMappingProfile : Profile
    {
        public MunicipioMappingProfile()
        {
            CreateMap<Municipios, GetAllMunicipiosResponseDto>().ReverseMap();
        }
    }
}
