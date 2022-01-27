using DataAccess.Abstactions;
using DataAccess.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.EntityFramework
{
    public class RepositoriesInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IGameRepository, GameRepository>()
                .AddTransient<IDeveloperStuidoRepository, DeveloperStudioRepository>()
                .AddTransient<IGenreRepository, GenreRepository>();
        }
    }
}
