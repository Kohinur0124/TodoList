using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskStatus = ToDoProject.Domain.Enums.TaskStatus;

namespace ToDoProject.Domain.Entity
{


	[Table("ToDoTask", Schema = "dbo")]
	public class ToDoTask
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }

		[Column("UserId")]
		[ForeignKey("UserId")]
		public int UserId { get; set; }
		[Column("TaskTitle")]
		public string TaskTitle { get; set; }
		[Column("TaskDescription")]
		public string TaskDescription { get; set; }
		[Column("TaskDueDate")]
		public DateTime TaskDueDate { get; set; }
		[Column("TaskPriority")]
		public int TaskPriority { get; set; }
		[Column("TaskState")]
		public TaskStatus TaskState { get; set; }
		[Column("TaskNote")]
		public string TaskNote { get; set; }

		[Column("CratedAt")]
		public DateTime CratedAt { get; set; }
		[Column("UpdatedAt")]
		public DateTime? UpdatedAt { get; set; }
		[Column("DeletedAt")]
		public DateTime? DeletedAt { get; set; }


		public User User { get; set; }

	}
}
