using FluentValidation;
using BusinessLayer.Contracts.Models;
using Games.Common;

namespace BusinessLayer.Services.Validators
{
    /// <summary>
    /// Валидатор GenreDto
    /// </summary>
    public class GenreDtoValidator : AbstractValidator<GenreDto>
    {
        public GenreDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(GenreConst.Name.MinLength, GenreConst.Name.MaxLength)
                .WithMessage(GenreConst.Name.LengthErrorMessage);
        }
    }
}
