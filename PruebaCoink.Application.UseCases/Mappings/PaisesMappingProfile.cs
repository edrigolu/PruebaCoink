using AutoMapper;
using PruebaCoink.Application.Dtos.Paises.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.Mappings
{
    public class PaisesMappingProfile: Profile
    {
        public PaisesMappingProfile()
        {
            CreateMap<Paises, GetAllPaisesResponseDto>().ReverseMap();
        }
    }
}
