using CustomerTracking.Application.Common.Exceptions;
using CustomerTracking.Application.Interfaces;
using CustomerTracking.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.CustomerImages.Commands.AddImage
{
    public class AddImageCommandHandler(IAppDbContext _dbContext, IFileStorageService _fileStorage) : IRequestHandler<AddImageCommand, int>
    {
        public async Task<int> Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers
                .Include(c => c.Images)
                .FirstOrDefaultAsync(c => c.Id == request.CustomerId, cancellationToken);

            if (customer is null)
                throw new NotFoundException(nameof(Customer), request.CustomerId);

            var relativePath = await _fileStorage.SaveImageAsync(request.Image, "customers", cancellationToken);

            try
            {
                // Edge case: if this customer somehow has zero images, force this one to be Main
                var isFirstImage = !customer.Images.Any();

                var newImage = new CustomerImage
                {
                    CustomerId = customer.Id,
                    ImagePath = relativePath,
                    IsMain = isFirstImage
                };

                _dbContext.CustomerImages.Add(newImage);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return newImage.Id;
            }
            catch
            {
                _fileStorage.DeleteImage(relativePath);
                throw;
            }
        }
    }
}
