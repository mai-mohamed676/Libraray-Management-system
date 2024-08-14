using task3.model;

namespace task3.Service
{
    //transactin  managment
    public class BorrowingServices
    {
        private readonly itientity _context;

        public BorrowingServices(itientity context)
        {
            _context = context;
        }

        public void BorrowBook(int bookId, int patronId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Code for borrowing a book.
                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}

