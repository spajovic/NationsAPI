using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.Countries;
using NationsApi.Application.Dto.Countries;
using NationsApi.Application.Queries.Countries;
using NationsApi.Application.Searches;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.Country;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public CountryController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IActionResult Get([FromBody] CountrySearch search,
            [FromServices] IGetCountriesQuery query)
        {
            IEnumerable<GetCountryDto> countries = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(countries);
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCountryQuery query)
        {
            GetCountryDto country = _useCaseExecutor.ExecuteQuery(query, id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // POST api/<CountryController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCountryDto dto,
            [FromServices] IAddCountryCommand command,
            [FromServices] AddCountryValidator validator)
        {
            dto.NationalDay = DateTime.Parse("2018-12-10T13:49:51.141Z");
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Country country = _mapper.Map<Country>(dto);
                _useCaseExecutor.ExecuteCommand(command, country);
                return Ok("Country succesfully added");

            }
            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));

        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCountryDto dto,
            [FromServices] IUpdateCountryCommand command,
            [FromServices] UpdateCountryValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Country country = _mapper.Map<Country>(dto);
                _useCaseExecutor.ExecuteCommand(command, country);
                return Ok("Country changed successfully.");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCountryCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Accepted();
        }
    }
}
