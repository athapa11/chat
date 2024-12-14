using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Dtos.Account;
using DashApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid){ return BadRequest(ModelState); }

                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };
                
                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

                if(createdUser.Succeeded)
                {
                    return Ok("User created");
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            } catch (Exception e) // any random errors
            {   
                Console.Error.Write(e);
                return StatusCode(500, "rip");
            }
        }
    }
}