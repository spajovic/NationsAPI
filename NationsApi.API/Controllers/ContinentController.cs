using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.Continents;
using NationsApi.Application.Dto.Continets;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.Continent;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public ContinentController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<ContinentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContinentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContinentController>
        [HttpPost]
        public IActionResult Post([FromBody] AddContinentDto dto, 
            [FromServices] IAddContinentCommand command, 
            [FromServices] AddContinentValidator validator)
        {
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Continent continent = _mapper.Map<Continent>(dto);
                _useCaseExecutor.ExecuteCommand(command, continent);
                return Ok("Continent succesfully added");

            }
            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
             
        }

        // PUT api/<ContinentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContinentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
