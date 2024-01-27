using MediatR;

namespace ToDoProject.Application.UseCases.Users.Queries
{
    public class GetUsersByEmailCommand : IRequest<Domain.Entity.User>
    {
        public string Email { get; set; }
    }

}
