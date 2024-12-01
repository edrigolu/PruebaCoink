using MediatR;
using PruebaCoink.Application.Dtos.Usuarios.Response;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.Usuarios.Queries.GetAllQuery
{
    public class GetAllUsersQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllUsersResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
