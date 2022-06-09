using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Commands.Languages;
using NationsApi.Application.Dto.Language;
using NationsApi.Application.Queries.Language;
using NationsApi.Application.Searches;
using NationsApi.Domain;
using NationsApi.Implementation.Validators.Language;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public LanguageController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<LanguageController>
        [HttpGet]
        public IActionResult Get([FromBody] LanguageSearch search,
            [FromServices] IGetLanguagesQuery query)
        {
            IEnumerable<GetLanguageDto> continents = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(continents);
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneLanguageQuery query)
        {
            GetLanguageDto language = _useCaseExecutor.ExecuteQuery(query, id);

            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        // POST api/<LanguageController>
        [HttpPost]
        public IActionResult Post([FromBody] AddLanguageDto dto,
            [FromServices] IAddLanguageCommand command,
            [FromServices] LanguageValidator validator)
        {
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Language language = _mapper.Map<Language>(dto);
                _useCaseExecutor.ExecuteCommand(command, language);
                return Ok("Language succesfully added");

            }
            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));

        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLanguageDto dto,
            [FromServices] IUpdateLanguageCommand command,
            [FromServices] UpdateLanguageValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Language language = _mapper.Map<Language>(dto);
                _useCaseExecutor.ExecuteCommand(command, language);
                return Ok("Language changed successfully");
            }

            return UnprocessableEntity(result.Errors.Select(x => new
            {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            }));
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLanguageCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Accepted();
        }
    }
}
