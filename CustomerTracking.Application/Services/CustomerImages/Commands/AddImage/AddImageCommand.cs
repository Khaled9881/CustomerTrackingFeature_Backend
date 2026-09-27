using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.CustomerImages.Commands.AddImage
{
    public record AddImageCommand(int CustomerId, IFormFile Image) : IRequest<int>;
}
