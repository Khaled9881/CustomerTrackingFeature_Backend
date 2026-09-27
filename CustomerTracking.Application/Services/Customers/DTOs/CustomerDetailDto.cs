using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.DTOs
{
    public record CustomerDetailDto(
    int Id,
    string Name,
    int GovernorateId,
    string GovernorateName,
    int CityId,
    string CityName,
    double Latitude,
    double Longitude,
    List<CustomerImageDto> Images
);
}
