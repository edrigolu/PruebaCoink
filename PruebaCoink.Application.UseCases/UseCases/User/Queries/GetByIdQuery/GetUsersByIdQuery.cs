using MediatR;
using PruebaCoink.Application.Dtos.User.Response;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.User.Queries.GetByIdQuery
{
    public class GetUsersByIdQuery : IRequest<BaseResponse<GetUserByIdResponseDto>>
    {
        public int? IdUsuario { get; set; }
    }
}
