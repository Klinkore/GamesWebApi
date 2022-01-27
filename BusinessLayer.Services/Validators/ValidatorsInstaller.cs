using BusinessLayer.Contracts.Models;
using DataAccess.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Services.Validators
{
    /// <summary>
    /// Класс использующийся для содания зависимостей валидаторов
    /// </summary>
    public class ValidatorsInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services
                .AddTransient<AbstractValidator<GameDto>, GameDtoValidator>()
                .AddTransient<AbstractValidator<DeveloperStudioDto>, DeveloperStudioDtoValidator>()
                .AddTransient<AbstractValidator<GenreDto>, GenreDtoValidator>();
        }
    }
}
