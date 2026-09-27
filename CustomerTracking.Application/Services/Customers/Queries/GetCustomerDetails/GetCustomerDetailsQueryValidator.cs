using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryValidator : AbstractValidator<GetCustomerDetailsQuery>
    {
        public GetCustomerDetailsQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("A valid CustomerId is required.");
        }
    }
}
