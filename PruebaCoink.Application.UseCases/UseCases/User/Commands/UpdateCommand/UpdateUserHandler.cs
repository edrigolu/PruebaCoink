using AutoMapper;
using MediatR;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;
using PruebaCoink.Utilities.HelperExtensions;
using Entity = PruebaCoink.Domain.Entities;


namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.UpdateCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            try
            {
                Entity.User user = _mapper.Map<Entity.User>(request);
                var parameters = user.GetPropertiesWithValues();
                response.Data = await _unitOfWork.User.ExecAsync(SP.SP_EditUser, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE;
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
