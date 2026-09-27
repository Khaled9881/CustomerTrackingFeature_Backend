using CustomerTracking.Application.Common.Exceptions;
using CustomerTracking.Application.Interfaces;
using CustomerTracking.Application.Services.Customers.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler(IAppDbContext _dbContext) : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailDto>
    {
        public async Task<CustomerDetailDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers
                .Where(c => c.Id == request.Id)
                .Select(c => new CustomerDetailDto(
                    c.Id,
                    c.Name,
                    c.GovernorateId,
                    c.Governorate.Name,
                    c.CityId,
                    c.City.Name,
                    c.Latitude,
                    c.Longitude,
                    c.Images.Select(i => new CustomerImageDto(
                        i.Id,
                        i.ImagePath,
                        i.IsMain
                    )).ToList()
                ))
                .FirstOrDefaultAsync(cancellationToken);

            if (customer == null)
                throw new NotFoundException("Customer", request.Id);

            return customer;
        }
    }
}
