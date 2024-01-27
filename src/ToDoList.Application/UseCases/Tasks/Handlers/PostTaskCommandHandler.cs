using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Tasks.Commands;
using ToDoProject.Domain.Entity;

namespace ToDoProject.Application.UseCases.ta.Handlers
{
    public class PostTaskCommandHandler :
        IRequestHandler<PostTaskCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public PostTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(PostTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                var res = new Domain.Entity.ToDoTask()
                {
                    TaskTitle = request.TaskTitle,
                    TaskDescription = request.TaskDescription,
                    TaskDueDate = request.TaskDueDate,
                    TaskNote = request.TaskNote,
                    TaskPriority = request.TaskPriority,
                    TaskState = (ToDoProject.Domain.Enums.TaskStatus)request.TaskState,
                    UserId = request.UserId,
                    CratedAt = DateTime.Now,
                    DeletedAt = null,
                    UpdatedAt = null,

                };
                var result =  await _context.ToDoTasks.AddAsync(res);
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
