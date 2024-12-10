using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashApi.Data;
using DashApi.Models;
using DashApi.Interfaces;
using DashApi.Mappers;
using DashApi.Dtos.Chat;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatRepo _chatRepo;

        public ChatsController(IChatRepo chatRepo)
        { 
            _chatRepo = chatRepo; 
        }

        // get all chats
        [HttpGet]
        public async Task<IActionResult> GetAllChats()
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            var chats = await _chatRepo.GetAllAsync();
            var chatsDto = chats.Select(chat => chat.ToChatDto());

            return Ok(chatsDto);
        }

        // get chat by id
        [HttpGet("{id:int}")]
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


        // create chat
        [HttpPost]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatDto dto)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            var chat = dto.ToChatFromCreate();
            await _chatRepo.CreateChatAsync(chat);

            return CreatedAtAction
            (
                nameof(GetChatById),
                new {id = chat.Id},
                chat
            );
        }


        // edit chat
        [HttpPut]
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


        // delete chat
        [HttpDelete]
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