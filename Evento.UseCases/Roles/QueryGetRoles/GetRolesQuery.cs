using Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Roles.QueryGetRoles
{
    public class GetRolesQuery : IRequest<ICollection<RoleDto>>
    {
    }
}
