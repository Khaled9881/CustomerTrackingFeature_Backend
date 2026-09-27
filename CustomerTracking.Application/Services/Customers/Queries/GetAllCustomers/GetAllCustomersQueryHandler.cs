using CustomerTracking.Application.Interfaces;
using CustomerTracking.Application.Services.Customers.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler(IAppDbContext _dbContext) : IRequestHandler<GetAllCustomersQuery, PagedResult<CustomerListItemDto>>
    {
        async Task<PagedResult<CustomerListItemDto>> IRequestHandler<GetAllCustomersQuery, PagedResult<CustomerListItemDto>>.Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _dbContext.Customers
                .OrderBy(c => c.Id)
                .Select(c => new CustomerListItemDto(
                    c.Id,
                    c.Name,
                    c.Governorate.Name,
                    c.City.Name,
                    c.Latitude,
                    c.Longitude,
                    c.Images.Where(i => i.IsMain).Select(i => i.ImagePath).FirstOrDefault()
                //c.Images.FirstOrDefault(i => i.IsMain)!.ImagePath
                ))
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var totalCount = await _dbContext.Customers.CountAsync(cancellationToken);

            return new PagedResult<CustomerListItemDto>(customers, totalCount, request.Page, request.PageSize);
        }
    }
}
