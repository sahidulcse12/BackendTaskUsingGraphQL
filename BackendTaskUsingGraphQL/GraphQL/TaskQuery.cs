using BackendTaskUsingGraphQL.Data;
using BackendTaskUsingGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackendTaskUsingGraphQL.GraphQL
{
    public class TaskQuery
    {
        public string Hello() => "world";
        [GraphQLName("getAllTasks")]
        public async Task<List<TaskItem>> GetAllTasks([Service] AppDbContext context)
        {
            return await context.Tasks.ToListAsync();
        }
    }
}
