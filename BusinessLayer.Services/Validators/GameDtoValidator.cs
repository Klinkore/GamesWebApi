using FluentValidation;
using BusinessLayer.Contracts.Models;
using Games.Common;

namespace BusinessLayer.Services.Validators
{
    /// <summary>
    /// Валидатор GameDto
    /// </summary>
    public class GameDtoValidator : AbstractValidator<GameDto>
    {
        public GameDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(GameConst.Name.MinLength, GameConst.Name.MaxLength)
                .WithMessage(GameConst.Name.LengthErrorMessage);
        }
    }
}
