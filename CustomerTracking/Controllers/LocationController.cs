using CustomerTracking.Application.Services.Location.Queries.GetAllGovernorates;
using CustomerTracking.Application.Services.Location.Queries.GetCitiesByGovernorate;
using CustomerTracking.Application.Services.Location.Queries.GetGovernorateById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(IMediator _mediator) : ControllerBase
    {

        [HttpGet()]
        public async Task<IActionResult> GetAllGovernates()
        {
            var Governates = await _mediator.Send(new GetAllGovernoratesQuery());
            return Ok(Governates);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGovernateById(int id)
        {
            var Governates = await _mediator.Send(new GetGovernorateByIdQuery(id));
            return Ok(Governates);
        }

        [HttpGet("{id}/cities")]
        public async Task<IActionResult> GetCitiesByGovernorate(int id)
        {
            var result = await _mediator.Send(new GetCitiesByGovernorateQuery(id));
            return Ok(result);
        }

    }
}
