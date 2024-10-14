using AutoMapper;
using Entities.Users;
using Evento.UseCases.Roles;

namespace Evento.API.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>(); 
        }
    }
}
