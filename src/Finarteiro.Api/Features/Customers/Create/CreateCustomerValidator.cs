using FluentValidation;

namespace Finarteiro.Api.Features.Customers.Create;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(i => i.Email)
            .EmailAddress()
            .WithMessage("Value must be a valid e-mail.");

        RuleFor(i => i.FirstName)
            .NotEmpty()
            .WithMessage("First name must be informed.")
            .MaximumLength(50)
            .WithMessage("Fist name must have less than 50 characters.");

        RuleFor(i => i.LastName)
            .NotEmpty()
            .WithMessage("Last name must be informed.")
            .MaximumLength(50)
            .WithMessage("Last name must have less than 50 characters.");

        RuleFor(i => i.PhoneNumber)
            .Length(11)
            .WithMessage("Value must be a valid phone number.");
    }
}
