using Microsoft.AspNetCore.Mvc;
using RestWithASP.Net5.Business.InterfacesBusiness;
using RestWithASP.Net5.Model;


namespace RestWithASP.Net5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksBusiness _booksBusiness;

        public BooksController(IBooksBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            var books = _booksBusiness.FindById(Id);
            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Books books)
        {
            if (books == null)
                return BadRequest();

            return Ok(_booksBusiness.Create(books));
        }


        [HttpPut()]
        public IActionResult Put([FromBody] Books books)
        {
            if (books == null)
                return BadRequest();

            return Ok(_booksBusiness.Update(books));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            _booksBusiness.Delete(Id);
            return NoContent();

        }
    }
}
