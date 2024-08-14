using System.ComponentModel.DataAnnotations;

namespace task3.model
{
    public class Patron
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //contact with email
        public string ContactInformation { get; set; }
    }
}
