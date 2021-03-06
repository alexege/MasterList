using Microsoft.EntityFrameworkCore;

namespace masterList.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<Word> Words {get; set;}
        public DbSet<Note> Notes { get; set; }
    }
}