using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoProject.Domain.Entity
{
	[Table("User", Schema = "dbo")]
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("Email")]
		public string Email { get; set; }
		[Column("Password")]
		public string Password { get; set; }


		public ICollection<ToDoTask> ToDoTasks { get; set; }
	}
}
