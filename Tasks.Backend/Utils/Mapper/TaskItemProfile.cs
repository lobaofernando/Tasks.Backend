using AutoMapper;
using Tasks.Backend.DTOs;
using Tasks.Backend.Models;

namespace Tasks.Backend.Utils.Mapper
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDTO>();

            CreateMap<TaskItemDTO, TaskItem>();

            CreateMap<CreateTaskItemDTO, TaskItem>();
            
            CreateMap<TaskItem, CreateTaskItemDTO>();

            CreateMap<CreateTaskItemDTO, TaskItemDTO>();

            CreateMap<TaskItemDTO, CreateTaskItemDTO>();
        }
    }
}

