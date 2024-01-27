using MediatR;

namespace ToDoProject.Application.UseCases.Users.Commands
{
    public class PutUsersCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
