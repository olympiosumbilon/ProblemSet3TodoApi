using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListApi.Connection;
using TodoListApi.Models;

namespace TodoListApi.Repository
{
    public class TaskTodoRepository
    {
        private readonly TodoDbContext _dbContextConn;
        public TaskTodoRepository(TodoDbContext dbContextConn)
        {
            _dbContextConn = dbContextConn;
        }

        //public async Task<IEnumerable<TaskTodo>> InsertAysnc(IEnumerable<TaskTodo> items)
        //{
        //    await _dbContextConn.TaskTodos.AddRangeAsync(items);
        //    await _dbContextConn.SaveChangesAsync();
        //    return items;
        //}
        public async Task<TaskTodo> InsertAsync(TaskTodo item)
        {
            item.CreatedAt = DateTime.UtcNow;
            item.UpdateAt = DateTime.UtcNow;

            _dbContextConn.TaskTodos.Add(item);
            await _dbContextConn.SaveChangesAsync();
            return item;
        }
        public async Task<List<TaskTodo>> GetAllAsync()
        {
            return await _dbContextConn.TaskTodos.ToListAsync();
        }
        public async Task<TaskTodo> GetByIdAsync(int id)
        {
            return await _dbContextConn.TaskTodos.FindAsync(id);
        }
        public async Task<TaskTodo?> UpdateAsync(int id, TaskTodo items)
        {
            var todos = await _dbContextConn.TaskTodos.FindAsync(id);
            if (todos == null) return null;

            // update fields
            todos.Title = items.Title;
            todos.Deadline = items.Deadline;
            todos.IsCompleted = items.IsCompleted;
            todos.UpdateAt = DateTime.UtcNow;

            await _dbContextConn.SaveChangesAsync();
            return todos;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _dbContextConn.TaskTodos.FindAsync(id);
            if (product == null) return false;

            _dbContextConn.TaskTodos.Remove(product);
            await _dbContextConn.SaveChangesAsync();
            return true;
        }

        public async Task<TaskTodo?> MarkCompleteAsync(int id)
        {
            var task = await _dbContextConn.TaskTodos.FindAsync(id);
            if (task == null) return null;

            if (!task.IsCompleted)
            {
                task.IsCompleted = true;
                task.CompletedAt = DateTime.UtcNow;
                task.UpdateAt = DateTime.UtcNow;
                _dbContextConn.TaskTodos.Update(task);
                await _dbContextConn.SaveChangesAsync();
            }

            return task;
        }

    }
}
