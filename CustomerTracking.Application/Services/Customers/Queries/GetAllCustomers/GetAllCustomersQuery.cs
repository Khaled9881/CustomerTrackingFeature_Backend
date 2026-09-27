using CustomerTracking.Application.Services.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Queries.GetAllCustomers
{
    public record GetAllCustomersQuery(int Page = 1, int PageSize = 10)
    : IRequest<PagedResult<CustomerListItemDto>>;


}
