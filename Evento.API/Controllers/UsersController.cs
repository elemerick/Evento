using Domain.Models.User;
using Entities.Users;
using Evento.UseCases.Users.CommandCreateUser;
using Evento.UseCases.Users.CommandDeleteUser;
using Evento.UseCases.Users.CommandUpdateUser;
using Evento.UseCases.Users.QueryGetUser;
using Evento.UseCases.Users.QueryGetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evento.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetUsersQuery());
            return Ok(response);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetUserQuery() { UserId = id });
            return Ok(response);
        }
        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreationDto userDto)
        {
            var response = await _mediator.Send(new CreateUserCommand() { User = userDto });
            return Ok(response);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserCommand() { UserId = id });
            return Ok();
        }
    }
}
