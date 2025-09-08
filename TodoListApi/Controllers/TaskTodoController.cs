using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Models;
using TodoListApi.Repository;
using TodoListApi.Services;


namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTodoController : ControllerBase
    {
        private TodoService _todoService;
        public TaskTodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<TaskTodo>>> Create([FromBody] List<TaskTodo> items)
        //{
        //    var todos = await _todoService.InsertAysnc(items);
        //    return Ok(todos);
        //}

        [HttpPost]
        public async Task<ActionResult<TaskTodo>> Create([FromBody] TaskTodo item)
        {
            var todo = await _todoService.InsertAsync(item);
            return Ok(todo);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskTodo>>> GetAllAsyncs()
        {
            var todos = await _todoService.GetAllAysnc();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskTodo>> GetAsyncById(int id)
        {
            var todos = await _todoService.GetAsyncById(id);
            if (todos == null)
            {
                return NotFound();
            }
            return Ok(todos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskTodo>> UpdateAsync(int id, [FromBody] TaskTodo items)
        {
            var updatedProduct = await _todoService.UpdateAsync(id, items);

            if (updatedProduct == null)
            {
                return NotFound($"Todo with Id = {id} not found.");
            }

            return Ok(updatedProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _todoService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<ActionResult<TaskTodo>> MarkComplete(int id)
        {
            var updatedTask = await _todoService.MarkCompleteAsync(id);

            if (updatedTask == null)
            {
                return NotFound($"Todo with Id = {id} not found.");
            }

            return Ok(updatedTask);
        }

    }
}
