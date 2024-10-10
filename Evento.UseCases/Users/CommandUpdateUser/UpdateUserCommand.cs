using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.UseCases.Users.CommandUpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public UserUpdateDto User { get; set; }
        public int UserId { get; set; }
    }
}
