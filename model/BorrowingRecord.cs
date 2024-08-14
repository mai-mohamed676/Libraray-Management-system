using System.ComponentModel.DataAnnotations;

namespace task3.model
{
    public class BorrowingRecord
    {
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        public int PatronId { get; set; }
        public Patron Patron { get; set; }
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
    }
}

