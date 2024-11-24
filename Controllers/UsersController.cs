using DashApi.Data;
using Microsoft.AspNetCore.Mvc;
using DashApi.Mappers;
using DashApi.Dtos.User;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.User
                .Select(u => u.ToUserDto())
                .ToListAsync();
            
            return Ok(users);
        }

        // get specific user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _context.User.FindAsync(id);

            if(user == null){
                return NotFound();
            }
            
            return Ok(user.ToUserDto());
        }

        // register user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromDto();
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();

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