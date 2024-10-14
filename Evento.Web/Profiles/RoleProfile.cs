using AutoMapper;
using Evento.Web.Models.Role;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Evento.Web.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleViewModel, SelectListItem>()
                .ForMember(dest => dest.Value, t => t.MapFrom(role => $"{role.Id}"))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));
        }
    }
}
