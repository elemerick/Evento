using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.CommandUpdateUser
{
    internal class UpdateUserCommandValidator : AbstractValidator<UserUpdateDto>
    {
        public UpdateUserCommandValidator()
        {
            // Rule for FirstName: not empty, minimum 2 characters, maximum 50 characters
            RuleFor(user => user.FirstName)
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

            // Rule for LastName: not empty, minimum 2 characters, maximum 50 characters
            RuleFor(user => user.LastName)
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

            // Rule for Email: must not be empty and must be a valid email format
            RuleFor(user => user.Email)
                .EmailAddress().WithMessage("A valid email is required.");
        }
    }
}
