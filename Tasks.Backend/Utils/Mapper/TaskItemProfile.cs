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
        }
    }
}

