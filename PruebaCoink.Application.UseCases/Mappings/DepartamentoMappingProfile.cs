using AutoMapper;
using PruebaCoink.Application.Dtos.Departaments.Response;
using PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.Mappings
{
    public class DepartamentoMappingProfile : Profile
    {
        public DepartamentoMappingProfile()
        {
            CreateMap<Departamentos, GetAllDepartamentosResponseDto>().ReverseMap();
        }
    }
}
