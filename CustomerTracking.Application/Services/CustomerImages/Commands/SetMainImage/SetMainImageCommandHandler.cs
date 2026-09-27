using CustomerTracking.Application.Common.Exceptions;
using CustomerTracking.Application.Interfaces;
using CustomerTracking.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerTracking.Application.Services.CustomerImages.Commands.SetMainImage
{
    public class SetMainImageCommandHandler(IAppDbContext _dbContext) : IRequestHandler<SetMainImageCommand>
    {
        public async Task Handle(SetMainImageCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(x => x.Id == request.CustomerId, cancellationToken);

            if (customer is null)
                throw new NotFoundException(nameof(Customer), request.CustomerId);

            var image = await _dbContext.CustomerImages
                .FirstOrDefaultAsync(x => x.Id == request.ImageId, cancellationToken);

            if (image is null)
                throw new NotFoundException(nameof(CustomerImage), request.ImageId);

            if (image.CustomerId != request.CustomerId)
                throw new NotFoundException(nameof(CustomerImage), request.ImageId);

            var customerImages = await _dbContext.CustomerImages
                .Where(x => x.CustomerId == request.CustomerId)
                .ToListAsync(cancellationToken);

            foreach (var img in customerImages)
            {
                img.IsMain = img.Id == request.ImageId;
            }


            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}