using Microsoft.AspNetCore.Mvc;
using DashApi.Data;
using DashApi.Dtos.Message;
using DashApi.Mappers;

namespace DashApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly DashDbContext _context;

        public MessageController(DashDbContext context){ _context = context; }

        // get all messages
        [HttpGet]
        public IActionResult GetAll()
        {
            var messages = _context.Message.ToList();
            return Ok(messages);
        }

        // get message by id
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var message = _context.Message.Find(id);

            if(message == null){ return NotFound(); }

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

    }
}