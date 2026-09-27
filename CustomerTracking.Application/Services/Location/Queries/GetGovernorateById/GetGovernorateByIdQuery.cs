using CustomerTracking.Application.Services.Location.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Location.Queries.GetGovernorateById
{
    public record GetGovernorateByIdQuery(int id) : IRequest<GovernorateDto>;
}
