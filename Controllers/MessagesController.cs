using Microsoft.AspNetCore.Mvc;
using DashApi.Data;
using DashApi.Dtos.Message;
using DashApi.Mappers;

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
        public IActionResult GetAllMessages()
        {
            var messages = _context.Message.ToList();
            return Ok(messages);
        }

        // get message by id
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var message = _context.Message.Find(id);
            if(message == null)
            { 
                return NotFound(); 
            }
            return Ok(message);
        }

        // create message
        [HttpPost]
        public IActionResult CreateMessage([FromBody] CreateMessageDto messageDto)
        {
            var messageModel = messageDto.ToMessageFromDto();
            _context.Message.Add(messageModel);
            _context.SaveChanges();

            return CreatedAtAction
            (
                nameof(GetById),
                new {id = messageModel.Id},
                messageModel
            );
        }

        // Edit message body
        [HttpPut]
        [Route("{id}")]
        public IActionResult EditMessage([FromRoute] int id, [FromBody] EditMessageDto editDto)
        {
            var message = _context.Message.FirstOrDefault(
                x => x.Id == id);

            if(message == null)
            { 
                return NotFound(); 
            }
            message.Content = editDto.Content;
            message.Edited = true;
            _context.SaveChanges();

            return Ok(message);
        }

        // Delete message
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMessage([FromRoute] int id)
        { 
            var message = _context.Message.FirstOrDefault(
                x => x.Id == id
            );

            if(message == null){
                return NotFound();
            }

            _context.Message.Remove(message);
            _context.SaveChanges();

            return NoContent();
        }
    }
}