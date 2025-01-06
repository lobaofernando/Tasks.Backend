using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Tasks.Backend.Data;
using Tasks.Backend.DTOs;
using Tasks.Backend.Models;

namespace Tasks.Backend.Services
{
    public class TaskItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TaskItemService (ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TaskItemDTO>> GetAllTaskItensAsync()
        {
            var taskItens = await _context.Tasks.ToListAsync();

            return _mapper.Map<List<TaskItemDTO>>(taskItens);
        }

        public async Task<TaskItemDTO> GetTaskItemByIdAsync(int id)
        {
            var taskItem = await _context.Tasks.FindAsync(id);

            return _mapper.Map<TaskItemDTO>(taskItem);
        }

        public async Task<List<TaskItemDTO>> GetTaskItensByUserId(int userId)
        {
            var taskItens = await _context.Tasks.Where(task => task.UserId == userId).ToListAsync();

            return _mapper.Map<List<TaskItemDTO>>(taskItens);
        }

        public async Task<bool> CreateTaskItemAsync(CreateTaskItemDTO taskItemDTO)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDTO);
            var user = await _context.Users.FindAsync(taskItem.UserId);

            if (user == null) return false;

            try
            {
                _context.Tasks.Add(taskItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateTaskItemAsync(int id, CreateTaskItemDTO taskItemDTO)
        {
            // verificando se usuário existe
            var user = await _context.Users.FindAsync(taskItemDTO.UserId);
            if (user == null) return false;

            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null) return false;

            taskItem.Title = taskItemDTO.Title;
            taskItem.Description = taskItemDTO.Description;
            taskItem.DueDate = taskItemDTO.DueDate;
            taskItem.IsCompleted = taskItemDTO.IsCompleted;
            taskItem.UserId = taskItemDTO.UserId;


            _context.Entry(taskItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTaskItemAsync(int id)
        {
            var taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem == null) return false;

            try
            {
                _context.Tasks.Remove(taskItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Erro ao excluir o taskItem:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado");
            }
        }
    }
}
