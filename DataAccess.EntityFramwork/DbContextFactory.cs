using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess.EntityFramework
{
    /// <summary>
    /// Фабрика для создания контекста базы данных
    /// </summary>
    public class DbContextFactory : IDesignTimeDbContextFactory<BoardDbContext>
    {
        public BoardDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var optionBuilder = new DbContextOptionsBuilder<BoardDbContext>();
            optionBuilder.UseSqlServer(config.GetConnectionString("BoardDb"));
            return new BoardDbContext(optionBuilder.Options);
        }
    }
}
