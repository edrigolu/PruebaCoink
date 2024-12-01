using MediatR;
using PruebaCoink.Application.Dtos.Departaments.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;

namespace PruebaCoink.Application.UseCases.UseCases.Department.Queries.GetAllQuery
{
    public class GetAllDepartamentosHandler : IRequestHandler<GetAllDepartamentosQuery, BasePaginationResponse<IEnumerable<GetAllDepartamentosResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDepartamentosHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllDepartamentosResponseDto>>> Handle(GetAllDepartamentosQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllDepartamentosResponseDto>>();
            try
            {
                var count = await _unitOfWork.Departamento.GetCountAsync(Tables.Departamentos);
                var departamentsList = await _unitOfWork.Departamento.GetAllDepartamentos(SP.SP_ListarDepartamentos, request);
                switch (departamentsList.Count())
                {
                    case <= 0:
                        response.IsSuccess = false;
                        response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                        break;
                    default:
                        response.IsSuccess = true;
                        response.PageNumber = request.PageNumber;
                        response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                        response.TotalCount = count;
                        response.Data = (IEnumerable<GetAllDepartamentosResponseDto>?)departamentsList;
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
