using CustomerTracking.Application.Services.Location.DTOs;
using CustomerTracking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Location.Queries.GetAllGovernorates
{
    public record GetAllGovernoratesQuery : IRequest<List<GovernorateDto>>;
}
