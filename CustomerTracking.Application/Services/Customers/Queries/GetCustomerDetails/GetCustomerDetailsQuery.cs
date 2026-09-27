using CustomerTracking.Application.Services.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Queries.GetCustomerDetails
{
    public record GetCustomerDetailsQuery(int Id) : IRequest<CustomerDetailDto>;
}
