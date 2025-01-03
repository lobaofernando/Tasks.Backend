using AutoMapper;
using Tasks.Backend.Models;
using Tasks.Backend.DTOs;

namespace Tasks.Backend.Utils.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>();
        }
    }
}
