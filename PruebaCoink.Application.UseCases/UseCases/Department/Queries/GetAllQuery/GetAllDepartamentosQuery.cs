using MediatR;
using PruebaCoink.Application.Dtos.Departaments.Response;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.Department.Queries.GetAllQuery
{
    public class GetAllDepartamentosQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllDepartamentosResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
