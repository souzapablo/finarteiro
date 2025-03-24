using FluentValidation;

namespace Finarteiro.Api.Features.Customers.Create;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(i => i.FirstName)
            .NotEmpty()
            .WithMessage(CustomerErrors.CreateUser.MissingFirstName.Message)
            .MaximumLength(50)
            .WithMessage(CustomerErrors.CreateUser.InvalidFirstName.Message);

        RuleFor(i => i.LastName)
            .MaximumLength(50)
            .WithMessage(CustomerErrors.CreateUser.InvalidLastName.Message);

        RuleFor(i => i.Email)
            .EmailAddress()
            .WithMessage(CustomerErrors.CreateUser.InvalidEmail.Message);

        RuleFor(i => i.PhoneNumber)
            .Length(11)
            .WithMessage(CustomerErrors.CreateUser.InvalidPhoneNumber.Message);
    }
}
