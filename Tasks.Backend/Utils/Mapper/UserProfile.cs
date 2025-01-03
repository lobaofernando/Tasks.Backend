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
            
            CreateMap<CreateUserDTO, User>();

            CreateMap<User, CreateUserDTO>();

            CreateMap<CreateUserDTO, UserDTO>();

            CreateMap<UserDTO, CreateUserDTO>();

            CreateMap<UpdateUserDTO, User>();

            CreateMap<User, UpdateUserDTO>();
        }
    }
}
