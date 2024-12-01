using AutoMapper;
using MediatR;
using PruebaCoink.Application.Dtos.Usuarios.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;
using Entity = PruebaCoink.Domain.Entities;

namespace PruebaCoink.Application.UseCases.UseCases.Usuarios.Queries.GetByIdQuery
{
    public class GetUsersByIdHandler : IRequestHandler<GetUsersByIdQuery, BaseResponse<GetUserByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetUserByIdResponseDto>> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetUserByIdResponseDto>();
            try
            {
                var patient = await _unitOfWork.Usuario.GetByIdAsync(SP.SP_UserById, request);
                switch (patient)
                {
                    case null:
                        response.IsSuccess = false;
                        response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                        break;
                    default:
                        response.IsSuccess = true;
                        response.Data = _mapper.Map<GetUserByIdResponseDto>((Entity.Usuarios?)await _unitOfWork.Usuario.GetByIdAsync(SP.SP_UserById, request));
                        response.Message = GlobalMessage.MESSAGE_QUERY;
                        break;
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
