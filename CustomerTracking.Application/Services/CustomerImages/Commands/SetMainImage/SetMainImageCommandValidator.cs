using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.CustomerImages.Commands.SetMainImage
{
    public class SetMainImageCommandValidator : AbstractValidator<SetMainImageCommand>
    {
        public SetMainImageCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("A valid CustomerId is required.");

            RuleFor(x => x.ImageId)
                .GreaterThan(0).WithMessage("A valid ImageId is required.");
        }
    }
}
