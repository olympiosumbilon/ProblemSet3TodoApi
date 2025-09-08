using Microsoft.EntityFrameworkCore;
using TodoListApi.Connection;
using TodoListApi.Models;
using TodoListApi.Repository;

namespace TodoListApi.Services
{
    public class TodoService
    {
        private readonly TodoDbContext _dbContextConn;
        private readonly TaskTodoRepository _taskTodoRepository;
        public TodoService(TaskTodoRepository taskTodoRepository)
        {
            _taskTodoRepository = taskTodoRepository;
        }

        public async Task<TaskTodo> GetAsyncById(int id)
        {
            var todos = await _taskTodoRepository.GetByIdAsync(id);
            return todos;
        }
        //public async Task<IEnumerable<TaskTodo>> InsertAysnc(IEnumerable<TaskTodo> items)
        //{
        //    return await _taskTodoRepository.InsertAysnc(items);
        //}
        public async Task<TaskTodo> InsertAsync(TaskTodo items)
        {
            return await _taskTodoRepository.InsertAsync(items);
        }
        public async Task<TaskTodo> UpdateAsync(int id, TaskTodo items)
        {
            return await _taskTodoRepository.UpdateAsync(id, items);
        }


        public async Task<List<TaskTodo>> GetAllAysnc()
        {
            var todos = await _taskTodoRepository.GetAllAsync();
            return todos;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _taskTodoRepository.DeleteAsync(id);
        }
        public async Task<TaskTodo?> MarkCompleteAsync(int id)
        {
            return await _taskTodoRepository.MarkCompleteAsync(id);
        }



        //public async Task<List<TaskTodo>> GetAllCompleted()
        //{
        //    var todos = await _taskTodoRepository.GetAllAsync();
        //    return todos;
        //}
    }
}

