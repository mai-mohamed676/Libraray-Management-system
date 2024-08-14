using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace task3.model
{
    public class itientity:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }
        public itientity()
        {

        }
        public itientity(DbContextOptions options) : base(options)
        {

        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PFKAJN7/SQLEXPRESS;Initial Catalog=library;Integrated Security=TrueData Source=DESKTOP-PFKAJN7/SQLEXPRESS;Initial Catalog=library;Integrated Security=True");
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=DESKTOP-PFKAJN7\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True");
        }
    }

    }

