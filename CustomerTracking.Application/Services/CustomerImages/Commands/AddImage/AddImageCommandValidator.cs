using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.CustomerImages.Commands.AddImage
{
    public class AddImageCommandValidator : AbstractValidator<AddImageCommand>
    {
        private static readonly string[] AllowedImageTypes = { "image/jpeg", "image/png", "image/jpg" };
        private const long MaxImageSizeInBytes = 5 * 1024 * 1024; // 5 MB

        public AddImageCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("A valid CustomerId is required.");

            RuleFor(x => x.Image)
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
