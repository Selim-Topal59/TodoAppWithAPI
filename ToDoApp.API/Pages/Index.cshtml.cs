using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Entities.Entities;
using TodoApp.Repository.Context;

namespace ToDoApp.API.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoappContext _context;


        public List<TodoItem> ToDoItems { get; set; } = new List<TodoItem>();

        [BindProperty]
        public TodoItem NewTodoItem { get; set; }

        public IndexModel(TodoappContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            ToDoItems = _context.TodoItems.Where(x => x.IsActive == true).ToList();
        }
        public IActionResult OnPost() 
        {
            if (NewTodoItem != null) 
            {
                _context.TodoItems.Add(NewTodoItem);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                _context.TodoItems.Remove(data);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToPage();
        }
        public IActionResult OnPostFinished(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                data.IsActive = false;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToPage();
        }
        public IActionResult OnPostUpdate(int id, string title, string message)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            // Güncelleme iþlemleri
            todoItem.Title = title;
            todoItem.Message = message;
            _context.SaveChanges();

            return RedirectToPage();
        }

    }
}
