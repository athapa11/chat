// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using DashApi.Dtos.Chat;
// using DashApi.Extensions;
// using DashApi.Interfaces;
// using DashApi.Mappers;
// using DashApi.Models;
// using Humanizer;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Infrastructure;
// using Microsoft.Extensions.Logging;

// namespace DashApi.Controllers
// {
//     [Route("dashapi/[controller]")]
//     [ApiController]
//     public class UserChatsController : ControllerBase
//     {
//         private readonly UserManager<User> _userManager;
//         private readonly IChatRepo _chatRepo;
//         private readonly IUserChatsRepo _userChatsRepo;


//         public UserChatsController(UserManager<User> userManager, IChatRepo chatRepo, IUserChatsRepo userChatsRepo)
//         {
//             _userManager = userManager;
//             _chatRepo = chatRepo;
//             _userChatsRepo = userChatsRepo;
//         }

//         [HttpGet]
//         [Authorize]
//         public async Task<IActionResult> GetUserChats()
//         {
//             var username = User.GetUsername();
//             var user = await _userManager.FindByNameAsync(username);
//             var userChats = await _userChatsRepo.GetUserChats(user);
//             return Ok(userChats);
//         }

//         [HttpPost]
//         [Authorize]
//         public async Task<IActionResult> CreateUserChat([FromBody] CreateChatDto dto)
//         {
//             var username = User.GetUsername();
//             var user = await _userManager.FindByNameAsync(username);
//             var chat = dto.ToChatFromCreate();
//             await _chatRepo.CreateChatAsync(chat);

//             return CreatedAtAction
//             (
//                 nameof(GetChatById),
//                 new {id = chat.Id},
//                 chat
//             );

//         }
//     }
// }