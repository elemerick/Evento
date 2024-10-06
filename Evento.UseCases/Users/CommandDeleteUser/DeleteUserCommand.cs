using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.CommandDeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int? UserId { get; set; }
    }
}
