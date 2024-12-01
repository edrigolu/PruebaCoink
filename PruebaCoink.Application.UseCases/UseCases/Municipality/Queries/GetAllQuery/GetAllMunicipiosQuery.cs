using MediatR;
using PruebaCoink.Application.Dtos.Municipalities.Response;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.Municipality.Queries.GetAllQuery
{
    public class GetAllMunicipiosQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllMunicipiosResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
