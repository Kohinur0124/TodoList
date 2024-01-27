using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Tasks.Commands;


namespace ToDoProject.Application.UseCases.Tasks.Handlers
{
    public class DeleteTaskCommandHandler :
        IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (res == null)
                {
                    return false;
                }

              
                res.DeletedAt = DateTime.Now;
                _context.ToDoTasks.Update(res);
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
