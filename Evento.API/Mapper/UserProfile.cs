using AutoMapper;
using Entities.Users;
using Evento.UseCases.Users;
using Evento.UseCases.Users.CommandCreateUser;
using Evento.UseCases.Users.CommandUpdateUser;

namespace Evento.API.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Define a map between User and UserDto
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            // If you need two-way mapping (DTO back to Entity)
            
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UpdateUserCommand, User>().ReverseMap(); 
        }
    }
}
