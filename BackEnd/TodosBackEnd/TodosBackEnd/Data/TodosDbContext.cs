using Microsoft.EntityFrameworkCore;
using TodosBackEnd.Configuration;
using TodosBackEnd.models;
using TodosBackEnd.Seeders;

namespace TodosBackEnd.Data
{
    public class TodosDbContext : DbContext
    {
        public TodosDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodosConfiguration());

            modelBuilder.Seed();
        }

        public DbSet<Todo> todos { get; set; }
    }
}
