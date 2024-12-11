using Microsoft.AspNetCore.Mvc;
using DashApi.Dtos.Message;
using DashApi.Mappers;
using DashApi.Interfaces;
using DashApi.Queryables;

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
        public async Task<IActionResult> GetAll([FromQuery] MessageQuery query)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            var messages = await _messageRepo.GetAllAsync(query);
            var messagesDto = messages.Select(message => message.ToMessageDto());
            return Ok(messagesDto);
        }


        // get message by id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            var message = await _messageRepo.GetByIdAsync(id);

            if(message == null)
            {
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }


        // create message
        [HttpPost("{chatId:int}")]
        public async Task<IActionResult> Create([FromRoute] int chatId, [FromBody] CreateMessageDto messageDto)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            if(!await _chatRepo.ChatExists(chatId))
            {
                BadRequest("Chat not found");
            }

            var message = messageDto.ToMessageFromCreate(chatId);
            await _messageRepo.CreateMessageAsync(message);

            return CreatedAtAction
            (
                nameof(GetById),
                new {id = message.Id},
                message.ToMessageDto()
            );
        }


        // Edit message body
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditMessageDto dto)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }

            var message = await _messageRepo.EditMessageAsync(id, dto.ToMessageFromUpdate());

            if(message == null)
            {
                return NotFound("Message not found");
            }

            return Ok(message.ToMessageDto());
        }


        // Delete message
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid){ return BadRequest(ModelState); }
            
            var message = await _messageRepo.DeleteMessageAsync(id);

            if(message == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}