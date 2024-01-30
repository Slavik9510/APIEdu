using ASP_WebApi_Edu.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WebApi_Edu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : Controller
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public IActionResult GetSecret()
        {
            return Ok("Secret text");
        }

        [HttpGet("server-error")]
        public IActionResult GetServerError()
        {
            var user = _context.Users.Find(-1);

            return Ok(user.ToString());
        }
    }
}
