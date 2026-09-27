using CustomerTracking.Application.Interfaces;
using CustomerTracking.Application.Services.Location.DTOs;
using CustomerTracking.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Location.Queries.GetAllGovernorates
{
    public class GetAllGovernoratesQueryHandler(IAppDbContext _dbContext) : IRequestHandler<GetAllGovernoratesQuery, List<GovernorateDto>>
    {
        public async Task<List<GovernorateDto>> Handle(GetAllGovernoratesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Governorates
                                    .Select(x => new GovernorateDto
                                    {
                                        Id = x.Id,
                                        Name = x.Name
                                    })
                                    .ToListAsync(cancellationToken);
        }
    }
}
