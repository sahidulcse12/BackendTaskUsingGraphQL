using BackendTaskUsingGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTaskUsingGraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
