using AutoMapper;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.CommandDeleteUser
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUsersRepository _repo;

        public DeleteUserCommandHandler(IUsersRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteUserCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                throw new Exception(nameof(result));
            }
            await _repo.DeleteEntityAsync(command.UserId);
        }
    }
}
