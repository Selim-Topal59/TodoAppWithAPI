using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities.Entities;

namespace TodoApp.Repository.Context
{
    public class TodoappContext : DbContext
    {
        public TodoappContext(DbContextOptions<TodoappContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
