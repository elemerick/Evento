using AutoMapper;
using Entities.Users;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.CommandCreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUsersRepository repo, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                throw new Exception(nameof(result));
            }
            var user = _mapper.Map<User>(command);
            await _repo.SaveEntityAsync(user);
            return true;
        }
    }
}
