using MediatR;

namespace ToDoProject.Application.UseCases.Tasks.Queries
{
    public class GetTaskByIdCommand : IRequest<Domain.Entity.ToDoTask>
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
