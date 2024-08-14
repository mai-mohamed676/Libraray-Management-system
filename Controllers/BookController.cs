using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task3.model;

namespace task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //api/Book
    public class BookController : ControllerBase
    {
        private readonly itientity Context;

        public BookController(itientity context)
        {
            Context = context;
        }
       
        // GET /api/book
        [HttpGet]
        public IActionResult GetBook()
        {
          List<Book> books = Context.Books.ToList();
            return Ok(books);
            // Retrieve and return the list of books.
        }
      

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            // Retrieve and return the book by ID.
          Book book = Context.Books.Find(id);
            return Ok(book);
        }
      

      // POST /api/books
      [HttpPost]
        public IActionResult Add([FromBody] Book book)
      {
            // Add a new book to the library.
            if (ModelState.IsValid)
            {
                Context.Books.Add(book);
                Context.SaveChanges();
                return Ok("book added success");
            }
            return BadRequest(ModelState);
      }
       
    // PUT /api/books/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Book book)
    {
            // Update an existing book's information.
            if (ModelState.IsValid)
            {
                Book oldbook = Context.Books.Find(id);
                oldbook.price=oldbook.price*book.price;
                Context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent, "datasaved");
            }
            return BadRequest("data not valid");
        }
      
    // DELETE /api/books/{id}
    [HttpDelete("{id}")]
    public IActionResult RemoveBook(int id)
    {
            // Remove a book from the library.
            Book oldbook = Context.Books.Find(id);
            Context.Books.Remove(oldbook);
            Context.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent, "datasaved");
        }
   
    }
}
