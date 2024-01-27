using MediatR;

namespace ToDoProject.Application.UseCases.Tasks.Commands
{
    public class PutTaskCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDueDate { get; set; }
        public int TaskPriority { get; set; }
        public TaskStatus TaskState { get; set; }
        public string TaskNote { get; set; }


    }
}
