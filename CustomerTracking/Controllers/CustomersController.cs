using CustomerTracking.Application.Services.Customers.Commands.AddCustomer;
using CustomerTracking.Application.Services.Customers.Queries.GetAllCustomers;
using CustomerTracking.Application.Services.Customers.Queries.GetCustomerDetails;
using CustomerTracking.Application.Services.Customers.Queries.GetNearestCustomers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("AddCustomer")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }


        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersQuery query)
        {
            var result = await _mediator.Send(query);

            var itemsWithFullUrls = result.Items.Select(c => c with
            {
                MainImagePath = c.MainImagePath is not null ? BuildImageUrl(c.MainImagePath) : null
            });

            var response = result with { Items = itemsWithFullUrls };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var query = new GetCustomerDetailsQuery(id);
            var result = await _mediator.Send(query);

            var imagesWithFullUrls = result.Images
            .Select(img => img with { ImagePath = BuildImageUrl(img.ImagePath) })
            .ToList();

            var response = result with { Images = imagesWithFullUrls };

            return Ok(response);
        }

        [HttpGet("nearest")]
        public async Task<IActionResult> GetNearestCustomers([FromQuery] GetNearestCustomersQuery query)
        {
            var result = await _mediator.Send(query);

            var withFullUrls = result.Select(c => c with
            {
                MainImagePath = c.MainImagePath is not null ? BuildImageUrl(c.MainImagePath) : null
            }).ToList();

            return Ok(withFullUrls);
        }



        // Helper method to build the full image URL
        private string BuildImageUrl(string relativePath) =>
            $"{Request.Scheme}://{Request.Host}/{relativePath}";

    }
}