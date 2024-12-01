using MediatR;
using PruebaCoink.Application.Dtos.Paises.Response;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.Paises.Queries.GetAllQuery
{
    public class GetAllPaisesQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllPaisesResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
