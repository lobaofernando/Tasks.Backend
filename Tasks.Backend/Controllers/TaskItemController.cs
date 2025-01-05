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

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var task = _context.Tasks.Find(id);
        //    if (task == null) return NotFound();
        //    return Ok(task);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, TaskItem updatedTask)
        //{
        //    var task = _context.Tasks.Find(id);
        //    if (task == null) return NotFound();

        //    task.Title = updatedTask.Title;
        //    task.Description = updatedTask.Description;
        //    task.DueDate = updatedTask.DueDate;
        //    task.IsCompleted = updatedTask.IsCompleted;

        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var task = _context.Tasks.Find(id);
        //    if (task == null) return NotFound();

        //    _context.Tasks.Remove(task);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
