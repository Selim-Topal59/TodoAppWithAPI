using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Entities.Entities;
using TodoApp.Repository.Context;

namespace ToDoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly TodoappContext _context;

        public ToDoController(TodoappContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Getbyid(int id)
        {
            if (id <= 0)
            {
                return NotFound("not found");
            }


            var data =  _context.TodoItems.FirstOrDefault(e => e.Id == id);

            if (data == null)
            {
                return NotFound("notfound");
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItems([FromBody] TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItems), new { id = todoItem.Id }, todoItem);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItems([FromBody] int id)
        {
            var data = await _context.TodoItems.FindAsync(id);
            if (data != null)
            {
                _context.TodoItems.Remove(data);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound(new
                {
                    Message = "Veri bulunamadı",
                    StatusCode = 404
                });
            }
        }
        [HttpPut]
        public async Task<ActionResult<TodoItem>> UpdateTodoItems([FromBody] TodoItem todoItem)
        {
            var data = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == todoItem.Id);
            if (data != null)
            {
                data.Title = todoItem.Title;
                data.Message = todoItem.Message;
                data.IsActive = todoItem.IsActive;
                return Ok();
            }
            else
            {
                return NotFound(new
                {
                    Message = "Veri Bulunamadı",
                    StatusCode = 404
                });
            }

        }
    }
}
//https://localhost:7106/swagger/index.html
//https://localhost:7106/swagger/v1/swagger.json