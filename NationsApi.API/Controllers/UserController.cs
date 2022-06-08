using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.Users;
using NationsApi.Application.Dto.Users;
using NationsApi.Application.Queries.User;
using NationsApi.Application.Searches;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public UserController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromBody] UserSearch search,
              [FromServices] IGetUsersQuery query)
        {
            IEnumerable<GetUserDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            GetUserDto result = _useCaseExecutor.ExecuteQuery(query, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] AddUserDto dto, 
            [FromServices] IAddUserCommand command, 
            [FromServices] AddUserValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                User user = _mapper.Map<User>(dto);
                _useCaseExecutor.ExecuteCommand(command, user);
                return Ok("User added successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto, 
            [FromServices] IUpdateUserCommand command, 
            [FromServices] UpdateUserValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                User user = _mapper.Map<User>(dto);
                _useCaseExecutor.ExecuteCommand(command, user);
                return Ok("User changed successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteUserCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("User removed successfully.");
        }
    }
}
