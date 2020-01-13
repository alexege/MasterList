using Microsoft.EntityFrameworkCore;

namespace masterList.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get; set;}
    }
}