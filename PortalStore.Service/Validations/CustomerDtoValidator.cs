using FluentValidation;
using PortalStore.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Service.Validations
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Birthdate)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.TCID)
                .InclusiveBetween(1,long.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
    }
}
