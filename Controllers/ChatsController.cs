using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashApi.Data;
using DashApi.Models;
using DashApi.Interfaces;
using DashApi.Mappers;
using DashApi.Dtos.Chat;

namespace DashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatRepo _repo;

        public ChatsController(IChatRepo repo)
        { 
            _repo = repo; 
        }

        // get all chats
        [HttpGet]
        public async Task<IActionResult> GetAllChats()
        {
            var chats = await _repo.GetAllAsync();
            var chatsDto = chats.Select(chat => chat.ToChatDto());

            return Ok(chatsDto);
        }

        // get chat by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatById([FromRoute] int id)
        {
            var chat = await _repo.GetByIdAsync(id);

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
            var chat = dto.ToChatFromDto();
            await _repo.CreateChatAsync(chat);

            return CreatedAtAction
            (
                nameof(GetChatById),
                new {id = chat.Id},
                chat
            );
        }
    }
}
