using MediatR;

namespace ToDoProject.Application.UseCases.Users.Commands
{
    public class PostUsersCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
