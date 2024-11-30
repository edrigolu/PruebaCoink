using MediatR;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.ChangeUserStatus
{
    public class ChangeUserStatusCommand : IRequest<BaseResponse<bool>>
    {
        public int IdUsuario { get; set; }
        public int Activo { get; set; }
    }
}
