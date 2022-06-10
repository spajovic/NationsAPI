using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.CountryStats;
using NationsApi.Application.Dto.CountryStats;
using NationsApi.Application.Queries.CountryStat;
using NationsApi.Application.Searches;
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
        public IActionResult Get([FromBody] CountryStatSearch search,
            [FromServices] IGetCountryStatsQuery query)
        {
            IEnumerable<GetCountryStatDto> countries = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(countries);
        }

        // GET api/<CountryStatController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCountryStatQuery query)
        {
            IEnumerable<GetCountryStatDto> countryStats = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(countryStats);
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
        public IActionResult Put(int id, [FromBody] UpdateCountryStatDto dto,
            [FromServices] IUpdateCountryStatCommand command,
            [FromServices] UpdateCountryStatValidator validator)
        {
            dto.CountryId = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                CountryStat countryStat = _mapper.Map<CountryStat>(dto);
                _useCaseExecutor.ExecuteCommand(command, countryStat);
                return Ok("Country changed successfully.");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<CountryStatController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, 
            [FromBody] RemoveCountryStatDto dto, 
            [FromServices] IDeleteCountryStatCommand command,
            [FromServices] RemoveCountryStatValidator validator)
        {
            dto.CountryId = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                CountryStat countryStat = _mapper.Map<CountryStat>(dto);
                _useCaseExecutor.ExecuteCommand(command, countryStat);
                return Ok("Country stat removed successfully.");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));

        }
    }
}
