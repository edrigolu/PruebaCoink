using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.ChangeUserStatus;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.CreateCommand;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.DeleteCommand;
using PruebaCoink.Application.UseCases.UseCases.User.Commands.UpdateCommand;
using PruebaCoink.Application.UseCases.UseCases.User.Queries.GetAllQuery;
using PruebaCoink.Application.UseCases.UseCases.User.Queries.GetByIdQuery;

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
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{IdUsuario:int}")]
        public async Task<IActionResult> PatientById(int IdUsuario)
        {
            var response = await _mediator.Send(new GetUsersByIdQuery() { IdUsuario = IdUsuario });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPatient([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatient([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{IdUsuario:int}")]
        public async Task<IActionResult> DeletePatient(int IdUsuario)
        {
            var response = await _mediator.Send(new DeleteUserCommand() { IdUsuario = IdUsuario });
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeUserStatusCommand change)
        {
            var response = await _mediator.Send(change);
            return Ok(response);
        }

    }
}
