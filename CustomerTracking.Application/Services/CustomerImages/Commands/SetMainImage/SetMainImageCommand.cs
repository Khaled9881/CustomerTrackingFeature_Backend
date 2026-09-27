using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.CustomerImages.Commands.SetMainImage
{
    public record SetMainImageCommand(int CustomerId, int ImageId) : IRequest;
}
