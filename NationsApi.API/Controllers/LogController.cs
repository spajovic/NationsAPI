using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationsApi.Application;
using NationsApi.Application.Dto.UseCaseLog;
using NationsApi.Application.Queries.UseCaseLog;
using NationsApi.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NationsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public LogController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromBody] UseCaseLogSearch search,
            [FromServices] IGetUseCaseLogsQuery query)
        {
            IEnumerable<GetUseCaseLogDto> useCaseLogs = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(useCaseLogs);
        }
    }
}
