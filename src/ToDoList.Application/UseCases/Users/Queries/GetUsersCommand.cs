using MediatR;

namespace ToDoProject.Application.UseCases.Users.Queries
{
    public class GetUsersCommand : IRequest<List<Domain.Entity.User>>
    {
    }
}
