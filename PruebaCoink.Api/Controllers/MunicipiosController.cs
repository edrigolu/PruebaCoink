using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaCoink.Application.UseCases.UseCases.Department.Queries.GetAllQuery;
using PruebaCoink.Application.UseCases.UseCases.Municipality.Queries.GetAllQuery;

namespace PruebaCoink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MunicipiosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("MunicipiosList")]
        public async Task<IActionResult> MunicipiosList([FromQuery] GetAllMunicipiosQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
