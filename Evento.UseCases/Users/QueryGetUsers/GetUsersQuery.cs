using Domain.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.QueryGetUsers
{
    public class GetUsersQuery : IRequest<ICollection<UserDto>>
    {
    }
}
