using AutoMapper;
using Entities.Users;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.CommandUpdateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUsersRepository repo, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidator();
            var result = validator.Validate(command);
            if (result.IsValid)
            {
                await _repo.UpdateEntityAsync(command.UserId, _mapper.Map<User>(command));
            }
            
        }
    }
}
