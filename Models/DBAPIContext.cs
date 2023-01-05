using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.Models
{
    public class DBAPIContext : DbContext
    {
        public DBAPIContext(DbContextOptions<DBAPIContext> options)
        : base(options)
        {
        }

        //public DbSet<TodoItem> TodoItems { get; set; } = null!;

    }
}
