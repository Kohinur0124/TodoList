using MediatR;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Tasks.Commands;
using ToDoProject.Application.UseCases.Users.Commands;

namespace ToDoProject.Application.UseCases.Users.Handlers
{
    public class PostUsersCommandHandler :
        IRequestHandler<PostUsersCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public PostUsersCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(PostUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = new ToDoProject.Domain.Entity.User()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                };
                var users = _context.Users.Any(x=>x.Email == request.Email);
                if (!users) {
                await _context.Users.AddAsync(res);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
