using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Models
{
    public class BookHeavenContext : IdentityDbContext<User>
    {
        public BookHeavenContext(DbContextOptions<BookHeavenContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            
        }


    }
}
