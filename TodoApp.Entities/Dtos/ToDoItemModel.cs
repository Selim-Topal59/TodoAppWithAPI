using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities.Entities;

namespace TodoApp.Entities.Dtos
{
    public class ToDoItemModel : TodoItem
    {
        public new string? Title { get; set; }

        public new string? Message { get; set; }

        public new bool IsActive { get; set; }
    }
}
