using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaCoink.Application.UseCases.UseCases.Department.Queries.GetAllQuery;

namespace PruebaCoink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("DepartmentsList")]
        public async Task<IActionResult> DepartmentsList([FromQuery] GetAllDepartamentosQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
