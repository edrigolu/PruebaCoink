using MediatR;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.DeleteCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response.Data = await _unitOfWork.User.ExecAsync(SP.SPDeleteUser, request);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_DELETE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
