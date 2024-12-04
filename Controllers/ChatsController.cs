using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DashApi.Data;
using DashApi.Models;
using DashApi.Interfaces;

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

            return Ok(chats);
        }

        // get chat by id
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetChatById([FromRoute] int id)
        // {
        //     var chat = await _context.Chat.FindAsync(id);

        //     if(chat == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(chat);
        // }


    //     // PUT: api/Chats/5
    //     // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //     [HttpPut("{id}")]
    //     public async Task<IActionResult> PutChat(int id, Chat chat)
    //     {
    //         if (id != chat.Id)
    //         {
    //             return BadRequest();
    //         }

    //         _context.Entry(chat).State = EntityState.Modified;

    //         try
    //         {
    //             await _context.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!ChatExists(id))
    //             {
    //                 return NotFound();
    //             }
    //             else
    //             {
    //                 throw;
    //             }
    //         }

    //         return NoContent();
    //     }

    //     // POST: api/Chats
    //     // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //     [HttpPost]
    //     public async Task<ActionResult<Chat>> PostChat(Chat chat)
    //     {
    //         _context.Chat.Add(chat);
    //         await _context.SaveChangesAsync();

    //         return CreatedAtAction("GetChat", new { id = chat.Id }, chat);
    //     }

    //     // DELETE: api/Chats/5
    //     [HttpDelete("{id}")]
    //     public async Task<IActionResult> DeleteChat(int id)
    //     {
    //         var chat = await _context.Chat.FindAsync(id);
    //         if (chat == null)
    //         {
    //             return NotFound();
    //         }

    //         _context.Chat.Remove(chat);
    //         await _context.SaveChangesAsync();

    //         return NoContent();
    //     }

    //     private bool ChatExists(int id)
    //     {
    //         return _context.Chat.Any(e => e.Id == id);
    //     }
    }
}
