using Microsoft.EntityFrameworkCore;
using TodosBackEnd.models;

namespace TodosBackEnd.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo() { Id = 1, Name = "Nhiệm vụ 1", IsComplete= false},
                new Todo() { Id = 2, Name = "Nhiệm vụ 2", IsComplete = false },
                new Todo() { Id = 3, Name = "Nhiệm vụ 3", IsComplete = false }
                );
        }
    }
}
