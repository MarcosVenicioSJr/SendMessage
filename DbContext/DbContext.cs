using Microsoft.EntityFrameworkCore;
using SendMessage.Models;

namespace SendMessage.Context
{
    public class Context : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=pass; Database=blog";

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
