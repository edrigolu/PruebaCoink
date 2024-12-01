using MediatR;
using PruebaCoink.Application.Dtos.User.Response;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Application.UseCases.Common.Bases;
using PruebaCoink.Utilities.Constants;

namespace PruebaCoink.Application.UseCases.UseCases.User.Queries.GetAllQuery
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
                var count = await _unitOfWork.User.GetCountAsync(Tables.Users);
                var usersList = await _unitOfWork.User.GetAllUsers(SP.SP_UserList, request);
                switch (usersList.Count())
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
                        response.Data = usersList;
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
