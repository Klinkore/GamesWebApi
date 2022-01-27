using FluentValidation;
using BusinessLayer.Contracts.Models;
using Games.Common;

namespace BusinessLayer.Services.Validators
{
    /// <summary>
    /// Валидатор DeveloperStudioDto
    /// </summary>
    public class DeveloperStudioDtoValidator : AbstractValidator<Contracts.Models.DeveloperStudioDto>
    {
        public DeveloperStudioDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(DeveloperStudioConst.Name.MinLength, DeveloperStudioConst.Name.MaxLength)
                .WithMessage(DeveloperStudioConst.Name.LengthErrorMessage);
        }
    }
}
