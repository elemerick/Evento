using AutoMapper;
using Evento.Web.Models.User;

namespace Evento.Web.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, UserUpdateViewModel>();
        }
    }
}
