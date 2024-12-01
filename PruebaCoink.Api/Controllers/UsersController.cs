using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.CreateCommand;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.DeleteCommand;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.UpdateCommand;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Queries.GetAllQuery;
using PruebaCoink.Application.UseCases.UseCases.Usuarios.Queries.GetByIdQuery;

namespace PruebaCoink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("UsersList")]
        public async Task<IActionResult> UsersList([FromQuery] GetAllUsersQuery query)
        {
            Application.UseCases.Common.Bases.BasePaginationResponse<IEnumerable<Application.Dtos.Usuarios.Response.GetAllUsersResponseDto>> response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{IdUsuario:int}")]
        public async Task<IActionResult> UserById(int IdUsuario)
        {
            Application.UseCases.Common.Bases.BaseResponse<Application.Dtos.Usuarios.Response.GetUserByIdResponseDto> response = await _mediator.Send(new GetUsersByIdQuery() { IdUsuario = IdUsuario });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]  CreateUserCommand command)
        {
            Application.UseCases.Common.Bases.BaseResponse<bool> response = await _mediator.Send(command);
            return Ok(response);
        }        

        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatient([FromBody] UpdateUserCommand command)
        {
            Application.UseCases.Common.Bases.BaseResponse<bool> response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{IdUsuario:int}")]
        public async Task<IActionResult> DeletePatient(int IdUsuario)
        {
            Application.UseCases.Common.Bases.BaseResponse<bool> response = await _mediator.Send(new DeleteUserCommand() { IdUsuario = IdUsuario });
            return Ok(response);
        }
    }
}
