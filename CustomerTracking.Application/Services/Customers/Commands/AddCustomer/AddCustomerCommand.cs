using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CustomerTracking.Application.Services.Customers.Commands.AddCustomer
{
    public record AddCustomerCommand(string Name, int GovernorateId, int CityId, double Latitude, double Longitude, IFormFile image) : IRequest<int>;
}
