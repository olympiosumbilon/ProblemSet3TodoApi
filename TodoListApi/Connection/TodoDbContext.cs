using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Connection
{
    public class TodoDbContext:DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TaskTodo> TaskTodos { get; set; }
    }
}
