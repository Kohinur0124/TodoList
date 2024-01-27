using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Tasks.Commands;
using ToDoProject.Application.UseCases.Users.Commands;

namespace ToDoProject.Application.UseCases.Users.Handlers
{
    public class PutUsersCommandHandler :
         IRequestHandler<PutUsersCommand, bool>
    {

        private readonly IApplicationDbContext _context;

        public PutUsersCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(PutUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var res = await _context.Users.
                    FirstOrDefaultAsync(x => x.Id == request.Id);

                res.Name = request.Name;
                res.Email = request.Email;
                res.Password = request.Password;




                var result = _context.Users
                    .Update(res);

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
