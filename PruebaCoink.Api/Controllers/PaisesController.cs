using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaCoink.Application.UseCases.UseCases.Department.Queries.GetAllQuery;
using PruebaCoink.Application.UseCases.UseCases.Paises.Queries.GetAllQuery;

namespace PruebaCoink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarPaises")]
        public async Task<IActionResult> ListarPaises([FromQuery] GetAllPaisesQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
