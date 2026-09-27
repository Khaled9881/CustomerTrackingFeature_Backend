using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Queries.GetNearestCustomers
{
    internal class GetNearestCustomersQueryValidator : AbstractValidator<GetNearestCustomersQuery>
    {
        public GetNearestCustomersQueryValidator()
        {
            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");
        }
    }
}
