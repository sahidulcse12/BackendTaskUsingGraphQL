using BackendTaskUsingGraphQL.Data;
using Microsoft.EntityFrameworkCore;
using BackendTaskUsingGraphQL.Models;

namespace BackendTaskUsingGraphQL.GraphQL
{
    public class TaskMutation
    {
        public async Task<TaskItem> CreateTask(string title, string description, [Service] AppDbContext context)
        {
            var task = new TaskItem
            {
                Title = title,
                Description = description,
                Status = "Pending"
            };

            context.Tasks.Add(task);
            await context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem?> UpdateTaskStatus(Guid id, string status, [Service] AppDbContext context)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null) return null;

            task.Status = status;
            await context.SaveChangesAsync();
            return task;
        }
    }
}
