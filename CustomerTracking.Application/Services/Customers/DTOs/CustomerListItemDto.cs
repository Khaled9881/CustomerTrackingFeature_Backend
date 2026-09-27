using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.DTOs
{
    public record CustomerListItemDto(
    int Id,
    string Name,
    string GovernorateName,
    string CityName,
    double Latitude,
    double Longitude,
    string? MainImagePath
    );
}
