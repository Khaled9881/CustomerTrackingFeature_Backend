using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        private static readonly string[] AllowedImageTypes = { "image/jpeg", "image/png", "image/jpg" };
        private const long MaxImageSizeInBytes = 10 * 1024 * 1024; // 10 MB

        public AddCustomerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(150).WithMessage("Customer name must not exceed 150 characters.");

            RuleFor(x => x.GovernorateId)
                .GreaterThan(0).WithMessage("A valid Governorate must be selected.");

            RuleFor(x => x.CityId)
                .GreaterThan(0).WithMessage("A valid City must be selected.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");

            RuleFor(x => x.image)
                .NotNull().WithMessage("An image is required.")
                .Must(HaveValidSize).WithMessage($"Image size must not exceed {MaxImageSizeInBytes / (1024 * 1024)} MB.")
                .Must(HaveValidExtensionAndType).WithMessage("Only JPG and PNG images are allowed.");
        }

        private bool HaveValidSize(IFormFile? file)
        {
            return file is not null && file.Length > 0 && file.Length <= MaxImageSizeInBytes;
        }

        private bool HaveValidExtensionAndType(IFormFile? file)
        {
            if (file is null) return false;
            return AllowedImageTypes.Contains(file.ContentType?.ToLowerInvariant());
        }
    }
}
