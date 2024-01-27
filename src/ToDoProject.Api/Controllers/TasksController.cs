using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ToDoProject.Application.UseCases.Tasks.Commands;
using ToDoProject.Application.UseCases.Tasks.Queries;
using ToDoProject.Domain.Entity;
using Task = System.Threading.Tasks.Task;

namespace DomikTut.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

 



    [HttpPost]

    public async ValueTask<IActionResult> AddTask(PostTaskCommand postCard)
    {
        var t = await _mediator.Send(postCard);
        return Ok(t);
    }
    [HttpPut]

    public async ValueTask<IActionResult> UpdateTask(PutTaskCommand postUser)
    {
        var t = await _mediator.Send(postUser);
        return Ok(t);
    }

    [HttpDelete]

    public async ValueTask<IActionResult> DeleteTask(DeleteTaskCommand postUser)
    {
        var t = await _mediator.Send(postUser);
        return Ok(t);
    }


    [HttpGet]
    public async ValueTask<IActionResult> GetAllTasks(int userId)
    {
        var command = new GetTaskCommand()
        {
            UserId = userId
        };

        var tasks = await _mediator.Send(command);
        return Ok(tasks);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetTasksById(int userId , int taskId)
    {
        var command = new GetTaskByIdCommand()
        {
            UserId = userId,
            TaskId = taskId,
        };

        var tasks = await _mediator.Send(command);
        return Ok(tasks);
    }

}
