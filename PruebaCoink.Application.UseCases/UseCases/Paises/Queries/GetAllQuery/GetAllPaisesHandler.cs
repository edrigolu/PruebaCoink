using MediatR;
using PruebaCoink.Application.Dtos.Paises.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;

namespace PruebaCoink.Application.UseCases.UseCases.Paises.Queries.GetAllQuery
{
    public class GetAllPaisesHandler : IRequestHandler<GetAllPaisesQuery, BasePaginationResponse<IEnumerable<GetAllPaisesResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPaisesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllPaisesResponseDto>>> Handle(GetAllPaisesQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllPaisesResponseDto>>();
            try
            {
                var contar = await _unitOfWork.Paises.GetCountAsync(Tables.Paises);
                var listarPaises = await _unitOfWork.Paises.GetAllPaises(SP.SP_ListarPaises, request);
                switch (listarPaises.Count())
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
                        response.Data = (IEnumerable<GetAllPaisesResponseDto>?)listarPaises;
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
