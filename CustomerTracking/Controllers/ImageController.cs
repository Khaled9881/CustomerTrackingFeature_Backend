using CustomerTracking.Application.Services.CustomerImages.Commands.AddImage;
using CustomerTracking.Application.Services.CustomerImages.Commands.SetMainImage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController(IMediator _mediator) : ControllerBase
    {
        [HttpPost()]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddImageToCustomer([FromForm] AddImageCommand command)
        {
            var imagnId = await _mediator.Send(command);
            return Ok(imagnId);
        }

        [HttpPost("SetMainImage")]
        public async Task<IActionResult> SetMainImage([FromBody] SetMainImageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
