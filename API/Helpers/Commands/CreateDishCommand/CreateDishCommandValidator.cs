using FluentValidation;

namespace API.Helpers.Commands.CreateDishCommand
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.KiloCalories).GreaterThanOrEqualTo(0).WithMessage("KiloCalories must be greater than or equal to zero.");
        }
    }
}