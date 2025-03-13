using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Entities.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Message { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
