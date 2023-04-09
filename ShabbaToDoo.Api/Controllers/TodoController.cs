using Microsoft.AspNetCore.Mvc;

namespace ShabbaToDoo.Api.Controllers
{
    [Route("[controller]")]
    public class TodoController : ApiController
    {
        [HttpGet]
        public IActionResult ListTodos()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
