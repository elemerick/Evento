using Domain.Models.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.QueryGetUser
{
    internal class GetUserQueryValidators : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidators()
        {
            RuleFor(u => u.UserId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
