using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Dtos.Account;
using DashApi.Models;
using DashApi.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;

namespace DashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
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
                    return Ok(_tokenService.CreateToken(user));
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