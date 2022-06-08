using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.Roles;
using NationsApi.Application.Dto.Roles;
using NationsApi.Application.Queries.Roles;
using NationsApi.Application.Searches;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.Role;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public RoleController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get([FromBody] RoleSearch search,
              [FromServices] IGetRolesQuery query)
        {
            IEnumerable<GetRoleDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneRoleQuery query)
        {
            GetRoleDto result = _useCaseExecutor.ExecuteQuery(query, id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] AddRoleDto dto
            , [FromServices] IAddRoleCommand command
            , [FromServices] AddRoleValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Role role = _mapper.Map<Role>(dto);
                _useCaseExecutor.ExecuteCommand(command, role);
                return Ok("Role added successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRoleDto dto
            , [FromServices] IUpdateRoleCommand command
            , [FromServices] UpdateRoleValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Role role = _mapper.Map<Role>(dto);
                _useCaseExecutor.ExecuteCommand(command, role);
                return Ok("Role changed successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, 
            [FromServices] IDeleteRoleCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Role removed successfully.");
        }
    }
}
