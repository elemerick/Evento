using Domain.DataValidation;
using Domain.Interfaces;
using Entities.Users;
using Repository;
using Repository.Interfaces;

namespace Domain.DomainLogic
{
    public class UserDomain : DomainBase<User>, IUserDomain
    {
        private readonly IUsersRepository _repo;
        public UserDomain(IUsersRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public override async Task SaveEntityAsync(User user)
        {
            // Create an instance of the validator
            var validator = new UserValidator();

            // Validate the user
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                throw new Exception(nameof(result));
            }
            await base.SaveEntityAsync(user);
        }
    }
}
