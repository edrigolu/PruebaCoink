using MediatR;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.DeleteCommand
{
    public class DeleteUserCommand : IRequest<BaseResponse<bool>>
    {
        public int IdUsuario { get; set; }
    }
}
