
using Finarteiro.Api.Common.Base;

namespace Finarteiro.Api.Features.Customers;

public static class CustomerErrors
{
    public static class CreateUser
    {
        public static Error InvalidEmail => new("Email", "Value must be a valid e-mail.");
        public static Error MissingFirstName => new("FirstName", "First name must be informed.");
        public static Error InvalidFirstName => new("FirstName", "Fist name must have less than 50 characters.");
        public static Error InvalidLastName => new("LastName", "Last name must have less than 50 characters.");
        public static Error InvalidPhoneNumber => new("PhoneNumber", "Value must be a valid phone number.");
    }
}
