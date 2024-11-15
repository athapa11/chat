using Microsoft.AspNetCore.Mvc;
using DashApi.Data;
using DashApi.Models;

namespace DashApi.Controllers
{
    [Route("DashApi/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DashDbContext _context;
        public LoginController(DashDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if(login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password)){
                return BadRequest("Null Client Request");
            }

            // generate token or sesh here
            return Ok("Login successful");
        }
    }
}