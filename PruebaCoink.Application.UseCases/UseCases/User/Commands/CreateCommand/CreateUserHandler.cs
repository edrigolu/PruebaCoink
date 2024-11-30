using AutoMapper;
using MediatR;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;
using PruebaCoink.Utilities.HelperExtensions;
using Entity = PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.CreateCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            try
            {
                Entity.User user = _mapper.Map<Entity.User>(request);
                Dictionary<string, object> parameters = user.GetPropertiesWithValues();
                response.Data = await _unitOfWork.User.ExecAsync(SP.SP_RegisterUser, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_SAVE;
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
