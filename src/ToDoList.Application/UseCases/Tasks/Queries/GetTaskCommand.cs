using MediatR;

namespace ToDoProject.Application.UseCases.Tasks.Queries
{
    public class GetTaskCommand : IRequest<List<Domain.Entity.ToDoTask>>
    {
        public int UserId { get; set; }
    }
}
