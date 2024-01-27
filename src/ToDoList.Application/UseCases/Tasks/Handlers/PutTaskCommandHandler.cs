using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Tasks.Commands;
using ToDoProject.Domain.Entity;

namespace ToDoProject.Application.UseCases.Tasks.Handlers
{
    public class PutTaskCommandHandler :
         IRequestHandler<PutTaskCommand, bool>
    {

        private readonly IApplicationDbContext _context;

        public PutTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(PutTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var res = await _context.ToDoTasks.
                    FirstOrDefaultAsync(x => x.Id == request.Id);

                res.TaskTitle = request.TaskTitle;
                res.TaskDescription = request.TaskDescription;
                res.TaskDueDate = request.TaskDueDate;
                res.TaskNote = request.TaskNote;
                res.TaskPriority = request.TaskPriority;
                res.TaskState = (ToDoProject.Domain.Enums.TaskStatus)request.TaskState;
                
                res.UpdatedAt = DateTime.UtcNow;
                



                var result = _context.ToDoTasks.Update(res);

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
