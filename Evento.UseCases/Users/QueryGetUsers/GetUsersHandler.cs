using AutoMapper;
using Domain.Models.User;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.QueryGetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, ICollection<UserDto>>
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;
        public GetUsersHandler(IUsersRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ICollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repo.GetAllAsync();
            ICollection<UserDto> usersDto = _mapper.Map<ICollection<UserDto>>(users);
            return usersDto;
        }
    }
}
