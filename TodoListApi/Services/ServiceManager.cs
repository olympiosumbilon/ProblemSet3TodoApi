using Microsoft.Identity.Client;
using TodoListApi.Repository;

namespace TodoListApi.Services
{
    public static class ServiceManager
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<TodoService>();
            services.AddScoped<TaskTodoRepository>();
        }
    }
}
