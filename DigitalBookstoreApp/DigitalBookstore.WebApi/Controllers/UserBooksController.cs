using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalBookstore.WebApi.Models;
using DigitalBookstore.WebApi.DTOs;

namespace DigitalBookstore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {
        private readonly BookAppDbContext _context;

        public UserBooksController(BookAppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBook>>> GetUsersBooks()
        {
          if (_context.UsersBooks == null)
          {
              return NotFound();
          }
            return await _context.UsersBooks.ToListAsync();
        }

        // GET: api/UserBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBook>> GetUserBook(int id)
        {
          if (_context.UsersBooks == null)
          {
              return NotFound();
          }
            var userBook = await _context.UsersBooks.FindAsync(id);

            if (userBook == null)
            {
                return NotFound();
            }

            return userBook;
        }

        // PUT: api/UserBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBook(int id, UserBookDTO userBook)
        {
            if (id != userBook.Id)
            {
                return BadRequest();
            }

            _ = new
            UserBook()
            {
                Id = userBook.Id,
                BookId = userBook.BookId,
                UserId = userBook.UserId,
                Calification = userBook.Calification,
                Review = userBook.Review
            };

            _context.Entry(userBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserBook>> PostUserBook(UserBookDTO userBook)
        {
          if (_context.UsersBooks == null)
          {
              return Problem("Entity set 'BookAppDbContext.UsersBooks'  is null.");
          }
            UserBook postuserbook = new()
            {
                Id = userBook.Id,
                BookId = userBook.BookId,
                UserId = userBook.UserId,
                Calification = userBook.Calification,
                Review = userBook.Review
            };
            _context.UsersBooks.Add(postuserbook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBook", new { id = userBook.Id });
        }

        // DELETE: api/UserBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBook(int id)
        {
            if (_context.UsersBooks == null)
            {
                return NotFound();
            }
            var userBook = await _context.UsersBooks.FindAsync(id);
            if (userBook == null)
            {
                return NotFound();
            }

            _context.UsersBooks.Remove(userBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserBookExists(int id)
        {
            return (_context.UsersBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
