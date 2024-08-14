using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using task3.model;

namespace task3.Service
{
    //springs cashing
    public class BookService
    {
        private readonly IMemoryCache _cache;
        private readonly itientity _context;
        public BookService(IMemoryCache cache, itientity context)
        {
            _cache = cache;
            _context = context;
        }
        public Book GetBook(int id)
        {
            // Use the cache to get the book or create it if it doesn't exist
            return _cache.GetOrCreate($"book_{id}", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);

                // Fetch the book from the database
                var book = _context.Books.Find(id);

                // If the book is not found, you might want to handle this scenario
                if (book == null)
                {
                    // Handle book not found case (e.g., return null, throw an exception, etc.)
                    throw new Exception("Book not found");
                }

                return book;
            });
        }
    }
}
