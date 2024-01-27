using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDoProject.Domain.Enums;
using TaskStatus = ToDoProject.Domain.Enums.TaskStatus;

namespace ToDoProject.Domain.Entity
{
    
    public class ToDoTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDueDate { get; set; }
        public int TaskPriority { get; set; }
        public TaskStatus TaskState {  get; set; }
        public  string  TaskNote { get; set; }

        public DateTime CratedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    
        public User User { get; set; }

    }
}
