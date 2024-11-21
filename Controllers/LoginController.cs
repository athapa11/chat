using Microsoft.AspNetCore.Mvc;
using DashApi.Data;
using DashApi.Models;
using DashApi.Mappers;

namespace DashApi.Controllers
{
    [Route("DashApi")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DashDbContext _context;
        public LoginController(DashDbContext context)
        {
            _context = context;
        }

        // get all users
        [HttpGet("User")]
        public IActionResult GetAll()
        {
            var users = _context.User.Select(u => u.ToUserDto())
                .ToList();
            
            return Ok(users);
        }

        // get specific user
        [HttpGet("User/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.User.Find(id);

            if(user == null){
                return NotFound();
            }
            
            return Ok(user.ToUserDto());
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