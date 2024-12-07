using Microsoft.AspNetCore.Mvc;
using DashApi.Dtos.Message;
using DashApi.Mappers;
using DashApi.Interfaces;

namespace DashApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepo _messageRepo;
        private readonly IChatRepo _chatRepo;


        public MessagesController(IMessageRepo messageRepo, IChatRepo chatRepo)
        {
            _messageRepo = messageRepo;
            _chatRepo = chatRepo;
        }


        // get all messages
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messageRepo.GetAllAsync();
            var messagesDto = messages.Select(message => message.ToMessageDto());
            return Ok(messagesDto);
        }


        // get message by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var message = await _messageRepo.GetByIdAsync(id);

            if(message == null)
            {
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }


        // create message
        [HttpPost("{chatId}")]
        public async Task<IActionResult> Create([FromRoute] int chatId, [FromBody] CreateMessageDto messageDto)
        {
            if(!await _chatRepo.ChatExists(chatId))
            {
                BadRequest("CHAT DOESN'T EXIST");
            }

            var message = messageDto.ToMessageFromDto(chatId);
            await _messageRepo.CreateMessageAsync(message);

            return CreatedAtAction
            (
                nameof(GetById),
                new {id = message},
                message.ToMessageDto()
            );
        }


        // Edit message body
        // [HttpPut]
        // [Route("{id}")]
        // public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditMessageDto dto)
        // {
        //     var message = await _messageRepo.EditMessageAsync(id, dto);

        //     if(message == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(message);
        // }


        // Delete message
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        { 
            var message = await _messageRepo.DeleteMessageAsync(id);

            if(message == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}