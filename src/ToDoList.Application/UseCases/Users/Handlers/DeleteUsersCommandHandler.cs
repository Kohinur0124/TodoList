using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Users.Commands;


namespace ToDoProject.Application.UseCases.Users.Handlers
{
    public class DeleteUsersCommandHandler :
        IRequestHandler<DeleteUsersCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUsersCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (res == null)
                {
                    return false;
                }

                _context.Users.Remove(res);
                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
