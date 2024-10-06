using AutoMapper;
using Domain.Models.User;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.QueryGetUser
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUsersRepository repo, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetByIdAsync(request.UserId);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
