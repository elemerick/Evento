using FluentValidation;

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
