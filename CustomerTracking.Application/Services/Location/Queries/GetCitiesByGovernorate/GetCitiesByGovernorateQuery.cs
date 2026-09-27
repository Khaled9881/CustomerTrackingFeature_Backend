using CustomerTracking.Application.Services.Location.DTOs;
using CustomerTracking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Location.Queries.GetCitiesByGovernorate
{
    public record GetCitiesByGovernorateQuery(int GovernorateId) : IRequest<List<CityDto>>;
}
