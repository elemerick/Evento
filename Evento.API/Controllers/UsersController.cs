using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.User;
using Entities.Users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evento.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserDomain _domain;
        private readonly IMapper _mapper;

        public UsersController(IUserDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _domain.GetEntitiesAsync();
            ICollection<UserDto> usersDto = _mapper.Map<ICollection<UserDto>>(users);
            return Ok(usersDto);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _domain.GetEntityAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserCreationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _domain.SaveEntityAsync(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            await _domain.UpdateEntityAsync(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _domain.GetEntityAsync(id);
            await _domain.DeleteEntityAsync(user);
            return Ok();
        }
    }
}
