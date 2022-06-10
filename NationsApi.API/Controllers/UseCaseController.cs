using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.RoleCase;
using NationsApi.Application.Dto.RoleCase;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.RoleCase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public UseCaseController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET api/<UseCaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleUseCaseDto dto,
            [FromServices] IAddRoleUseCaseCommand command,
            [FromServices] AddRoleUseCaseValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                RoleUseCase roleUseCase = _mapper.Map<RoleUseCase>(dto);
                _useCaseExecutor.ExecuteCommand(command, roleUseCase);
                return Ok("RoleUseCase added successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<UseCaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromBody] RoleUseCaseDto dto,
            [FromServices] IDeleteRoleUseCaseCommand command,
            [FromServices] DeleteRoleUseCaseValidator validator)
        {
            dto.RoleId = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                RoleUseCase roleUseCase = _mapper.Map<RoleUseCase>(dto);
                _useCaseExecutor.ExecuteCommand(command, roleUseCase);
                return Ok("Role Use Case removed successfully.");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));

        }
    }
}
