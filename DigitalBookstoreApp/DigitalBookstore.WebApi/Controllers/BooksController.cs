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
    public class BooksController : ControllerBase
    {
        private readonly BookAppDbContext _context;

        public BooksController(BookAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
          if (_context.Book == null)
          {
              return NotFound();
          }
            return await _context.Book.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
          if (_context.Book == null)
          {
              return NotFound();
          }
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            Book putbook = new()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Yearpublication = book.Yearpublication
            };

            _context.Entry(putbook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO book)
        {
          if (_context.Book == null)
          {
              return Problem("Entity set 'BookAppDbContext.Book'  is null.");
          }

            Book postbook = new()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Yearpublication = book.Yearpublication
            };
            _context.Book.Add(postbook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }



        //public Libro(string titulo, string autor)
        //{
        //    Titulo = titulo;
        //    Autor = autor;
        //    Calificacion = 0; // Inicializamos la calificación en 0.
        //}

        //public void Calificar(int calificacion = 0)
        //{
        //    if (calificacion >= 1 && calificacion <= 5)
        //    {
        //        Calificacion = calificacion;
        //        Console.WriteLine($"Has calificado '{Titulo}' de '{Autor}' con {Calificacion} estrellas.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("La calificación debe estar entre 1 y 5 estrellas.");
        //    }
        //}



        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Book == null)
            {
                return NotFound();
            }
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
