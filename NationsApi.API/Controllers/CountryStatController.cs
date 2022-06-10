using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.CountryStats;
using NationsApi.Application.Dto.CountryStats;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.CountryStat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryStatController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public CountryStatController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<CountryStatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountryStatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryStatController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCountryStatDto dto,
            [FromServices] IAddCountryStatCommand command,
            [FromServices] AddCountryStatValidator validator)
        {
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                CountryStat countryStat = _mapper.Map<CountryStat>(dto);
                _useCaseExecutor.ExecuteCommand(command, countryStat);
                return Ok("Country stat added successfully.");

            }
            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // PUT api/<CountryStatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryStatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
