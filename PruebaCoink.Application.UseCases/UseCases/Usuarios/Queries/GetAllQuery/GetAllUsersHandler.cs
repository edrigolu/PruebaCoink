using MediatR;
using PruebaCoink.Application.Dtos.Usuarios.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;

namespace PruebaCoink.Application.UseCases.UseCases.Usuarios.Queries.GetAllQuery
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, BasePaginationResponse<IEnumerable<GetAllUsersResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllUsersResponseDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllUsersResponseDto>>();
            try
            {
                int contar = await _unitOfWork.Usuario.GetCountAsync(Tables.Usuarios);
                IEnumerable<GetAllUsersResponseDto> listarUsuarios = await _unitOfWork.Usuario.GetAllUsers(SP.SP_UserList, request);
                switch (listarUsuarios.Count())
                {
                    case <= 0:
                        response.IsSuccess = false;
                        response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                        break;
                    default:
                        response.IsSuccess = true;
                        response.PageNumber = request.PageNumber;
                        response.TotalPages = (int)Math.Ceiling(contar / (double)request.PageSize);
                        response.TotalCount = contar;
                        response.Data = listarUsuarios;
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
