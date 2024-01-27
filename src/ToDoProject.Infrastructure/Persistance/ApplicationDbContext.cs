using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ToDoProject.Application.Abstraction;
using ToDoProject.Domain.Entity;

namespace ToDoProject.Infrastructure.Persistance
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
			if (databaseCreator != null)
			{
				if (!databaseCreator.CanConnect()) databaseCreator.Create();
				if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
			}


		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ToDoTask>().HasOne(x => x.User).WithMany(x => x.ToDoTasks).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<ToDoProject.Domain.Entity.ToDoTask> ToDoTasks { get; set; }

	}
}
