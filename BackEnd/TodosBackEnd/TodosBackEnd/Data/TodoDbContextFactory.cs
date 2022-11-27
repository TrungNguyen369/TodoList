using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodosBackEnd.Data
{
    public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodosDbContext>
    {
        public TodosDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TodosDatabase");

            var optionBuilder = new DbContextOptionsBuilder<TodosDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new TodosDbContext(optionBuilder.Options);
        }
    }
}
