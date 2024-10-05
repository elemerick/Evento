using AutoMapper;
using Domain.Models.User;
using Entities.Users;

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
            
            CreateMap<UserCreationDto, User>().ReverseMap();

            CreateMap<UserUpdateDto, User>().ReverseMap(); 
        }
    }
}
