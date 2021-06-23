using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP.Net5.Business.InterfacesBusiness;
using RestWithASP.Net5.Data.VO;
using RestWithASP.Net5.Model;

namespace RestWithASP.Net5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBusiness _personBusiness;


        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            var person = _personBusiness.FindById(Id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personBusiness.Create(person));
        }


        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            _personBusiness.Delete(Id);
            return NoContent();
        }

    }
}
