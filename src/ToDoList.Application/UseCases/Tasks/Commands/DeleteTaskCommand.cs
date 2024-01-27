using MediatR;

namespace ToDoProject.Application.UseCases.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
