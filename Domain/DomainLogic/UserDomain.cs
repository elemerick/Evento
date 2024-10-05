using Domain.Interfaces;
using Entities.Users;
using Repository;

namespace Domain.DomainLogic
{
    public class UserDomain : DomainBase<User>, IUserDomain
    {
        public UserDomain(IDataRepositoryBase<User> repo) : base(repo)
        {
        }
    }
}
