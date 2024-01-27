

using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ToDoProject.Domain.Entity;
using ToDoTask = ToDoProject.Domain.Entity.ToDoTask;

namespace ToDoProject.Application.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
     

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
