using AutoMapper;
using Entities.Users;
using MediatR;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Roles.QueryGetRoles
{
    internal class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, ICollection<RoleDto>>
    {
        private readonly IRolesRepository _repo;
        private readonly IMapper _mapper;
        public GetRolesQueryHandler(IRolesRepository rolesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = rolesRepository;
        }

        public async Task<ICollection<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {

            var roles = await _repo.GetEntitiesAsync();
            ICollection<RoleDto> rolesDto = _mapper.Map<ICollection<RoleDto>>(roles);
            return rolesDto;
        }
    }
}
