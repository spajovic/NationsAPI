using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.Regions;
using NationsApi.Application.Dto.Regions;
using NationsApi.Application.Queries.Region;
using NationsApi.Application.Searches;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.Region;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public RegionController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<RegionController>
        [HttpGet]
        public IActionResult Get([FromBody] RegionSearch search,
            [FromServices] IGetRegionsQuery query)
        {
            IEnumerable<GetRegionDto> continents = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(continents);
        }

        // GET api/<RegionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneRegionQuery query)
        {
            GetRegionDto region = _useCaseExecutor.ExecuteQuery(query, id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // POST api/<RegionController>
        [HttpPost]
        public IActionResult Post([FromBody] AddRegionDto dto, 
            [FromServices] IAddRegionCommand command, 
            [FromServices] AddRegionValidator validator)
        {
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Region region = _mapper.Map<Region>(dto);
                _useCaseExecutor.ExecuteCommand(command, region);
                return Ok("Region succesfully added");

            }
            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));

        }

        // PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRegionDto dto, 
            [FromServices] IUpdateRegionCommand command, 
            [FromServices] UpdateRegionValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Region continent = _mapper.Map<Region>(dto);
                _useCaseExecutor.ExecuteCommand(command, continent);
                return Ok("Region changed successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRegionCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Accepted();
        }
    }
}
