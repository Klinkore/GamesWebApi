using System.IO;
using DataAccess.Abstactions;
using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.EntityFramework
{
    /// <summary>
    /// Класс используемый для внедрения зависимостей
    /// </summary>
    public static class DbContextInstaller
    {
        public static void ConfigureDbContext(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services
                .AddDbContext<BoardDbContext>(o => o
                    .UseSqlServer(config.GetConnectionString("BoardDb")))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IGameRepository, GameRepository>()
                .AddTransient<IGenreRepository, GenreRepository>()
                .AddTransient<IDeveloperStuidoRepository, DeveloperStudioRepository>();
        }
    }
}
