using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.Continents;
using NationsApi.Application.Dto.Continets;
using NationsApi.Application.Queries.Continent;
using NationsApi.Application.Searches;
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
        public IActionResult Get([FromBody] ContinentSearch search, 
            [FromServices] IGetContinentsQuery query)
        {
            IEnumerable<GetContinentDto> continents = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(continents);
        }

        // GET api/<ContinentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneContinentQuery query)
        {
            GetContinentDto continent = _useCaseExecutor.ExecuteQuery(query, id);

            if(continent == null)
            {
                return NotFound();
            }

            return Ok(continent);
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
        public IActionResult Put(int id, [FromBody] UpdateContinentDto dto, 
            [FromServices] IUpdateContinentCommand command, 
            [FromServices] UpdateContinentValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Continent continent = _mapper.Map<Continent>(dto);
                _useCaseExecutor.ExecuteCommand(command, continent);
                return Ok("Continent changed successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<ContinentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteContinentCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Accepted();
        }
    }
}
