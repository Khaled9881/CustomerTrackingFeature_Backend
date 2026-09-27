using CustomerTracking.Application.Services.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Queries.GetNearestCustomers
{
    public record GetNearestCustomersQuery(double Latitude, double Longitude)
    : IRequest<List<CustomerNearestDto>>;
}
