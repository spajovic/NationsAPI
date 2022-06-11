using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.CountryFlags;
using NationsApi.Application.Dto.CountryFlags;
using NationsApi.Application.FileUpload;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.CountryFlag;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryFlagController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public CountryFlagController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<CountryFlagController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountryFlagController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryFlagController>
        [HttpPost]
        public IActionResult Post([FromForm] AddCountryFlagDto dto,
            [FromServices] IAddCountryFlagCommand command,
            [FromServices] AddCountryFlagValidator validator)
        {
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                CountryFlag countryFlag = _mapper.Map<CountryFlag>(dto);

                countryFlag.FilePath = FlagImage.UploadFlagImage(dto.FilePath);

                _useCaseExecutor.ExecuteCommand(command, countryFlag);
                return Ok("Country Flag succesfully added");

            }
            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));

        }

        // PUT api/<CountryFlagController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdateCountryFlagDto dto,
            [FromServices] IUpdateCountryFlagCommand command,
            [FromServices] UpdateCountryFlagValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                _useCaseExecutor.ExecuteCommand(command, dto);
                return Ok("Country flag removed successfully.");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<CountryFlagController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] DeleteCountryFlagDto dto,
            [FromServices] IDeleteCountryFlagCommand command,
            [FromServices] DeleteCountryFlagValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                CountryFlag countryFlag = _mapper.Map<CountryFlag>(dto);
                _useCaseExecutor.ExecuteCommand(command, countryFlag);
                return Ok("Country Flag removed successfully.");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }
    }
}
