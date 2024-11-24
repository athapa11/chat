using Microsoft.AspNetCore.Mvc;
using DashApi.Data;
using DashApi.Dtos.Message;
using DashApi.Mappers;
using DashApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DashApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly DashDbContext _context;

        public MessagesController(DashDbContext context)
        { 
            _context = context; 
        }

        // get all messages from a chat
        // [HttpGet]
        // public IActionResult GetMessagesByChatId([FromQuery] int chatId)
        // {
        //     var messages = _context.Message
        //         .Where(m => m.ChatId == chatId)
        //         .ToList();
        //     return Ok(messages);
        // }


        // get all messages
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var messages = await _context.Message.ToListAsync();

            return Ok(messages);
        }


        // get message by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var message = await _context.Message.FindAsync(id);

            if(message == null){ 
                return NotFound(); 
            }

            return Ok(message);
        }


        // create message
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageDto messageDto)
        {
            var messageModel = messageDto.ToMessageFromDto();
            await _context.Message.AddAsync(messageModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new {id = messageModel.Id},
                messageModel
            );
        }


        // Edit message body
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditMessage([FromRoute] int id, [FromBody] EditMessageDto editDto)
        {
            var message = await _context.Message.FirstOrDefaultAsync(
                x => x.Id == id);

            if(message == null)
            { 
                return NotFound(); 
            }
            message.Content = editDto.Content;
            message.Edited = true;
            await _context.SaveChangesAsync();

            return Ok(message);
        }


        // Delete message
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] int id)
        { 
            var message = await _context.Message.FirstOrDefaultAsync(
                x => x.Id == id
            );

            if(message == null){
                return NotFound();
            }

            _context.Message.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}