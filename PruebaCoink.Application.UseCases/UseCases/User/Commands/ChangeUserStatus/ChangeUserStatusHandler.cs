using AutoMapper;
using MediatR;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;
using PruebaCoink.Utilities.HelperExtensions;
using Entity = PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.ChangeUserStatus
{
    public class ChangeUserStatusHandler : IRequestHandler<ChangeUserStatusCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeUserStatusHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var patient = _mapper.Map<Entity.User>(request);
                var parameters = patient.GetPropertiesWithValues();
                response.Data = await _unitOfWork.User.ExecAsync(SP.SP_ChangeUserStatus, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE_STATE;
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
