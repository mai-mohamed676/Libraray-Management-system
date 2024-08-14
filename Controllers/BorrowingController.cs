using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task3.Dto;
using task3.model;

namespace task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly itientity Context;
        public BorrowingController(itientity context)
        {
            Context = context;
        }
        /*
        //TRANSACTION MANAGMENT
        public void BorrowBook(int bookId, int patronId)
        {
            using var transaction = Context.Database.BeginTransaction();
            try
            {
                // Code for borrowing a book.
                Context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        */
        // POST /api/borrow/{bookId}/patron/{patronId}
        [HttpPost("borrow/{bookId}/patron/{patronId}")]
        public IActionResult BorrowBook(int bookId, int patronId, [FromBody] BorrowBookDto borrowBookDto)
        {
            // Check if the book exists and is available.
            var book = Context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            var existingBorrowingRecord = Context.BorrowingRecords
                .FirstOrDefault(br => br.BookId == bookId && br.ReturnDate == null);
            if (existingBorrowingRecord != null)
            {
                return BadRequest("Book is already borrowed and not yet returned.");
            }

            // Check if the patron exists.
            var patron = Context.Patrons.FirstOrDefault(p => p.Id == patronId);
            if (patron == null)
            {
                return NotFound("Patron not found.");
            }

            // Create a new BorrowingRecord based on the DTO.
            var borrowingRecord = new BorrowingRecord
            {
                BookId = borrowBookDto.BookId,
                PatronId = borrowBookDto.PatronId,
                BorrowDate = borrowBookDto.BorrowDate
            };

            // Save the borrowing record in the database.
            Context.BorrowingRecords.Add(borrowingRecord);
            Context.SaveChanges();

            // Return an appropriate response.
            return Ok("Book borrowed successfully.");
        }

        // PUT /api/return/{bookId}/patron/{patronId}
        [HttpPut("return/{bookId}/patron/{patronId}")]
        public IActionResult ReturnBook(int bookId, int patronId, [FromBody] ReturnBookDto returnBookDto)
        {
            // Check if the borrowing record exists.
            var borrowingRecord = Context.BorrowingRecords
                .FirstOrDefault(br => br.BookId == bookId && br.PatronId == patronId && br.ReturnDate == null);
            if (borrowingRecord == null)
            {
                return NotFound("Borrowing record not found or the book is already returned.");
            }

            // Update the borrowing record to mark the book as returned.
            borrowingRecord.ReturnDate = returnBookDto.ReturnDate;

            // Save changes to the database.
            Context.SaveChanges();

            // Return an appropriate response.
            return Ok("Book returned successfully.");
        }
    }
}
