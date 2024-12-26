using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashApi.Data;
using DashApi.Models;
using DashApi.Interfaces;
using DashApi.Mappers;
using DashApi.Dtos.Chat;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DashApi.Extensions;

namespace DashApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatRepo _chatRepo;
        private readonly UserManager<User> _userManager;

        public ChatsController(IChatRepo chatRepo, UserManager<User> userManager)
        { 
            _userManager = userManager;
            _chatRepo = chatRepo;
        }


        // get user specific chats
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUserChats()
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var chats = await _chatRepo.GetUserChatsAsync(user);

            return Ok(chats);
        }


        // get chat by id (all)
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetChatById([FromRoute] int id)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            var chat = await _chatRepo.GetByIdAsync(id);

            if(chat == null)
            {
                return NotFound();
            }

            return Ok(chat.ToChatDto());
        }


        // create chat (creator only)
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatDto dto)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) 
            { 
                return BadRequest("User not found"); 
            }

            var chat = dto.ToChatFromCreate();
            await _chatRepo.CreateChatAsync(chat);

            var association = new UserChat
            {
                ChatId = chat.Id,
                UserId = user.Id,
            };

            var res = await _chatRepo.CreateAssociationAsync(association);
            if (res == null)
            {
                return StatusCode(500, "Could not create user chat association");
            }

            return CreatedAtAction
            (
                nameof(GetChatById), 
                new {id = chat.Id}, 
                chat.ToChatDto()
            );
        }


        // edit chat (all)
        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> EditChat([FromRoute] int id, [FromBody] EditChatDto dto)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            var chat = await _chatRepo.EditChatAsync(id, dto.ToChatFromUpdate());

            if(chat == null){
                return NotFound("Chat not found");
            }

            return Ok(chat.ToChatDto());
        }


        // delete chat (creator only)
        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteChat([FromRoute] int id)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }
            
            var chat = await _chatRepo.DeleteChatAsync(id);

            if(chat == null){
                return NotFound("Chat not found");
            }

            return NoContent();
        }
    }
}