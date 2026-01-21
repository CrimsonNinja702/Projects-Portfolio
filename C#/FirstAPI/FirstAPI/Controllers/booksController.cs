using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        //static private List<Book> books = new List<Book>
        //{
        //        new Book
        //        {
        //            Id = 1,
        //            Title = "The Great Gatsby",
        //            Author = "F. Scott Fitzgerald",
        //            YearPublished = 1925
        //        },
        //        new Book
        //        {
        //            Id = 2,
        //            Title = "To Kill a Mockingbird",
        //            Author = "Harper Lee",
        //            YearPublished = 1960
        //        },
        //        new Book
        //        {
        //            Id = 3,
        //            Title = "1984",
        //            Author = "George Orwell",
        //            YearPublished = 1949
        //        },
        //        new Book
        //        {
        //            Id = 4,
        //            Title = "Pride and Prejudice",
        //            Author = "Jane Austen",
        //            YearPublished = 1813
        //        },
        //        new Book
        //        {
        //            Id = 5,
        //            Title = "Moby-Dick",
        //            Author = "Herman Melville",
        //            YearPublished = 1851
        //        }
        //};
        private readonly FirstAPIContext _context;
        public booksController(FirstAPIContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBookByID(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookByID), new { Id = newBook.Id }, newBook);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBook(int Id, Book updatedBook)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book == null)
                return NotFound();

            book.Id = updatedBook.Id;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;
            book.Title = updatedBook.Title;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
