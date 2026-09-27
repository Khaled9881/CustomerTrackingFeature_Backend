using CustomerTracking.Application.Common.Exceptions;
using CustomerTracking.Application.Interfaces;
using CustomerTracking.Application.Services.Location.DTOs;
using CustomerTracking.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Location.Queries.GetGovernorateById
{
    public class GetGovernorateByIdQueryHandler(IAppDbContext _dbContext) : IRequestHandler<GetGovernorateByIdQuery, GovernorateDto>
    {
        public async Task<GovernorateDto> Handle(GetGovernorateByIdQuery request, CancellationToken cancellationToken)
        {
            var governate = _dbContext.Governorates.FirstOrDefault(x => x.Id == request.id);
            if (governate is null)
                throw new NotFoundException(nameof(Governorate), request.id);

            GovernorateDto governorateDto = new GovernorateDto()
            {
                Id = governate.Id,
                Name = governate.Name,
            };

            return governorateDto;
        }
    }
}
