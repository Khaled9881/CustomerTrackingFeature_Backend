using CustomerTracking.Application.Interfaces;
using CustomerTracking.Application.Services.Customers.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerTracking.Application.Services.Customers.Queries.GetNearestCustomers
{
    public class GetNearestCustomersQueryHandler(IAppDbContext _dbContext)
        : IRequestHandler<GetNearestCustomersQuery, List<CustomerNearestDto>>
    {
        private const double EarthRadiusKm = 6371.0;

        public async Task<List<CustomerNearestDto>> Handle(GetNearestCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _dbContext.Customers
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    GovernorateName = c.Governorate.Name,
                    CityName = c.City.Name,
                    c.Latitude,
                    c.Longitude,
                    MainImagePath = c.Images
                        .Where(i => i.IsMain)
                        .Select(i => i.ImagePath)
                        .FirstOrDefault()
                })
                .ToListAsync(cancellationToken);

            var result = customers
                .Select(c => new CustomerNearestDto(
                    c.Id,
                    c.Name,
                    c.GovernorateName,
                    c.CityName,
                    c.Latitude,
                    c.Longitude,
                    c.MainImagePath,
                    CalculateDistanceKm(request.Latitude, request.Longitude, c.Latitude, c.Longitude)
                ))
                .OrderBy(c => c.DistanceKm)
                .ToList();

            return result;
        }

        private static double CalculateDistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }

        private static double DegreesToRadians(double degrees) => degrees * (Math.PI / 180);
    }
}