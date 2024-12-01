using MediatR;
using PruebaCoink.Application.Dtos.Usuarios.Response;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.Usuarios.Queries.GetByIdQuery
{
    public class GetUsersByIdQuery : IRequest<BaseResponse<GetUserByIdResponseDto>>
    {
        public int IdUsuario {  get; set; }
    }
}
