using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Users.Queries;

namespace ToDoProject.Application.UseCases.Users.Handlers
{
    public class GetUsersCommandHandler :
          IRequestHandler<GetUsersCommand, List<Domain.Entity.User>>
    {
        private readonly IApplicationDbContext _context;

        public GetUsersCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entity.User>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            return await _context.Users.Include(x=>x.ToDoTasks).ToListAsync();
        }
    }
}
