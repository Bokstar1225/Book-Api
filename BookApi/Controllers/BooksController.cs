using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookApi.Models;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Introduction to Information Systems, International Adaptation", Author = "R. K. Rainer, B. Prince", Price = 1100 },
            new Book {Id = 2, Title = "Head First Android Development: a Learner's Guide to Building Android Apps with Kotlin", Author = "D. Griffiths, D. Griffiths", Price = 2040},
            new Book {Id = 3, Title = "Java Programming", Author = "J. Farrel", Price = 1380},
            new Book {Id = 4, Title = "HTML and CSS: Visual QuickStart Guide", Author = "J. Casabona", Price = 920}
        };

        //Get api books(get and return all books)
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return books;
        }

        //Get api books{id}(get and return a specific book)
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //Post api book(Adds a new book)
        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book newBook)
        {
            //Adding a new book to books list
            books.Add(newBook);
            return CreatedAtAction(nameof(GetBook), new {id = newBook.Id}, newBook);
        }

        //Put api book(Updates an existing book)
        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if(book == null)
            {
                return NotFound();
            }

            //Updating the book resource with updatedBook parameter
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Price = updatedBook.Price;

            return NoContent();
        }

        //Delete api book(Deletes an existing book)
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if(book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return NoContent();
        }
    }
}
