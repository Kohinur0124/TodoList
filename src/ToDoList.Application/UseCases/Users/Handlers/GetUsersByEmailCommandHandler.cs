using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Users.Queries;

namespace ToDoProject.Application.UseCases.Users.Handlers
{
    public class GetUsersByEmailCommandHandler :
          IRequestHandler<GetUsersByEmailCommand, Domain.Entity.User>    {
        private readonly IApplicationDbContext _context;

        public GetUsersByEmailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entity.User> Handle(GetUsersByEmailCommand request, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email); ;
        }
    }
}
