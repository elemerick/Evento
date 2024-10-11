using AutoMapper;
using Entities.Users;
using MediatR;
using Repository.Interfaces;

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
            var result = validator.Validate(command.User);
            if (result.IsValid)
            {
                await _repo.UpdateUserAsync(command.UserId, _mapper.Map<User>(command.User));
            }
            
        }
    }
}
