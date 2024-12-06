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
        private readonly IMessageRepo _repo;

        public MessagesController(IMessageRepo repo)
        { 
            _repo = repo;
        }


        // get all messages
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _repo.GetAllAsync();
            var messagesDto = messages.Select(s => s.ToMessageDto());

            return Ok(messagesDto);
        }


        // get message by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var message = await _repo.GetByIdAsync(id);

            if(message == null){
                return NotFound();
            }

            return Ok(message.ToMessageDto());
        }


        // create message
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageDto messageDto)
        {
            var message = messageDto.ToMessageFromDto();
            await _repo.CreateMessageAsync(message);

            return CreatedAtAction
            (
                nameof(GetById),
                new {id = message.Id},
                message
            );
        }


        // Edit message body
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditMessageDto dto)
        {
            var message = await _repo.EditMessageAsync(id, dto);

            if(message == null)
            { 
                return NotFound(); 
            }

            return Ok(message);
        }


        // Delete message
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        { 
            var message = await _repo.DeleteMessageAsync(id);

            if(message == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}