using Microsoft.AspNetCore.Mvc;
using Tasks.Backend.DTOs;
using Tasks.Backend.Services;

namespace Tasks.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly TaskItemService _taskItemService;

        public TaskItemController(TaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskItemService.GetAllTaskItensAsync();

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskItemDTO task)
        {
            if (!await _taskItemService.CreateTaskItemAsync(task)) return BadRequest();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskItemService.GetTaskItemByIdAsync(id);
            if (task == null) return NotFound();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateTaskItemDTO updatedTask)
        {
            var task = await _taskItemService.UpdateTaskItemAsync(id, updatedTask);
            if (!task) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskItemService.DeleteTaskItemAsync(id);
            if (!task) return NotFound();

            return NoContent();
        }
    }
}
