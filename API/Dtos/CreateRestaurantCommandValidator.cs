using API.Helpers.Commands.CreateRestaurant;
using FluentValidation;

namespace API.Dtos
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().Length(3, 100).WithMessage("Name is required.");
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is Required");
            RuleFor(dto => dto.Category).NotEmpty().WithMessage("Insert a valid Category");
            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Provide a valid email address");
        }
        

    }
}