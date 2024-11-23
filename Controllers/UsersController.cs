using DashApi.Data;
using Microsoft.AspNetCore.Mvc;
using DashApi.Mappers;
using DashApi.Dtos.User;

namespace DashApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DashDbContext _context;

        public UsersController(DashDbContext context){ _context = context; }

        // get all users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.User
                .Select(u => u.ToUserDto())
                .ToList();
            
            return Ok(users);
        }

        // get specific user
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _context.User.Find(id);

            if(user == null){
                return NotFound();
            }
            
            return Ok(user.ToUserDto());
        }

        // register user
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromDto();
            _context.User.Add(userModel);
            _context.SaveChanges();

            return CreatedAtAction
            (
                nameof(GetUserById),
                new {id = userModel.Id},
                userModel.ToUserDto()
            );
        }

        // edit user
        // [HttpPut]
        // [Route("{id}")]
        // public IActionResult EditUser([FromRoute] int id, [FromBody] )
        // {

        // }
    }
}