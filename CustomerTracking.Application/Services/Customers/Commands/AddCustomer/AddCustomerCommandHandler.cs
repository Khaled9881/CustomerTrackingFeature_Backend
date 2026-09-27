using CustomerTracking.Application.Common.Exceptions;
using CustomerTracking.Application.Interfaces;
using CustomerTracking.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerTracking.Application.Services.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandHandler(
     IAppDbContext _dbContext,
     IFileStorageService _fileStorage) : IRequestHandler<AddCustomerCommand, int>
    {
        public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var governorate = await _dbContext.Governorates
                .FirstOrDefaultAsync(x => x.Id == request.GovernorateId, cancellationToken);

            if (governorate == null)
                throw new NotFoundException(nameof(Governorate), request.GovernorateId);


            var city = await _dbContext.Cities
                .FirstOrDefaultAsync(x => x.Id == request.CityId, cancellationToken);

            if (city == null)
                throw new NotFoundException(nameof(City), request.CityId);

            var relativePath = await _fileStorage.SaveImageAsync(request.image, "customers", cancellationToken);

            try
            {
                var newCustomer = new Customer
                {
                    Name = request.Name,
                    GovernorateId = request.GovernorateId,
                    CityId = request.CityId,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Images = new List<CustomerImage>
                {
                    new CustomerImage
                    {
                        ImagePath = relativePath,
                        IsMain = true
                    }
                }
                };

                _dbContext.Customers.Add(newCustomer);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return newCustomer.Id;
            }
            catch
            {
                _fileStorage.DeleteImage(relativePath);
                throw;
            }
        }
    }
}