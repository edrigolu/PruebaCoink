using MediatR;
using PruebaCoink.Application.Dtos.Municipalities.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;

namespace PruebaCoink.Application.UseCases.UseCases.Municipality.Queries.GetAllQuery
{
    public class GetAllMunicipiosHandler : IRequestHandler<GetAllMunicipiosQuery, BasePaginationResponse<IEnumerable<GetAllMunicipiosResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMunicipiosHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllMunicipiosResponseDto>>> Handle(GetAllMunicipiosQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllMunicipiosResponseDto>>();
            try
            {
                var count = await _unitOfWork.Municipio.GetCountAsync(Tables.Municipios);
                var municipalityList = await _unitOfWork.Municipio.GetAllMunicipios(SP.SP_ListarMunicipios, request);
                switch (municipalityList.Count())
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
                        response.Data = (IEnumerable<GetAllMunicipiosResponseDto>?)municipalityList;
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
