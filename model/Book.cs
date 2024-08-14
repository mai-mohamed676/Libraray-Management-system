using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace task3.model
{
    public class Book
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string title { get; set; }
        public int price { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1670,2024)]
        public int publicationyear { get; set; }
        [Required]
        [RegularExpression(@"\d{13}")]
        public long Isbn { get; set; }
    }
    

}
