using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Application.UseCases.Tasks.Commands;
using ToDoProject.Application.UseCases.Tasks.Queries;
using ToDoProject.Application.UseCases.Users.Commands;
using ToDoProject.Application.UseCases.Users.Queries;

namespace ToDoProject.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllUsers()
    {
        var cards = await _mediator.Send(new GetUsersCommand());
        return Ok(cards);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetByEmailUsers(string email)
    {
        var cards = await _mediator.Send(new GetUsersByEmailCommand()
        {
            Email = email
        }) ;
        return Ok(cards);
    }



    [HttpPost]

    public async ValueTask<bool> AddUsers(PostUsersCommand postCard)
    {
        var t = await _mediator.Send(postCard);
        return t;
    }
    [HttpPut]

    public async ValueTask<IActionResult> UpdateUser(PutUsersCommand postUser)
    {
        var t = await _mediator.Send(postUser);
        return Ok(t);
    }

    [HttpDelete]

    public async ValueTask<IActionResult> DeleteUsers(DeleteUsersCommand postUser)
    {
        var t = await _mediator.Send(postUser);
        return Ok(t);
    }


}
