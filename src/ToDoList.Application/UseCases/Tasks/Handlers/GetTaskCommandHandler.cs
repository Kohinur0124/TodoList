using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ToDoProject.Application.Abstraction;
using ToDoProject.Application.UseCases.Tasks.Queries;
using ToDoProject.Domain.Entity;

namespace ToDoProject.Application.UseCases.Tasks.Handlers
{
    public class GetTaskCommandHandler :
          IRequestHandler<GetTaskCommand, List<Domain.Entity.ToDoTask>>
    {
        private readonly IApplicationDbContext _context;

        public GetTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entity.ToDoTask>> Handle(GetTaskCommand request, CancellationToken cancellationToken)
        { 
               List<Domain.Entity.ToDoTask> rea = _context.ToDoTasks.Where(x=>x.UserId==request.UserId).ToList();
            return  rea;
            
           
            
        }
    }
}
