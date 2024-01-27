using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Tasks.Queries;
using ToDoProject.Domain.Entity;

namespace ToDoProject.Application.UseCases.Tasks.Handlers
{
    public class GetTaskByIdCommandHandler :
          IRequestHandler<GetTaskByIdCommand, Domain.Entity.ToDoTask>
    {
        private readonly IApplicationDbContext _context;

        public GetTaskByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entity.ToDoTask> Handle(GetTaskByIdCommand request, CancellationToken cancellationToken)
        {
            var rea = _context.ToDoTasks.FirstOrDefault(x => x.Id == request.TaskId && x.UserId == request.UserId);
            return  rea;
            
           
            
        }
    }
}
