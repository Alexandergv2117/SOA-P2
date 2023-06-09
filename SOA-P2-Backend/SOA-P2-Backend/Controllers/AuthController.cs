using Domain.Request;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOA_P2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth, IConfiguration configuration)
        {
            _auth = auth;
        }
        [HttpPost]
        [Route("")]
        public IActionResult Send([FromBody] RequestPostLogin user)
        {
            return Ok(_auth.ValidCredentials(user));
        }
    }
}
