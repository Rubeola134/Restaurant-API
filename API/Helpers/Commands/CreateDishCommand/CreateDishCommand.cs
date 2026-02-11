using MediatR;

namespace API.Helpers.Commands.CreateDishCommand
{
    public class CreateDishCommand : IRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? KiloCalories { get; set; }
        public int RestaurantId { get; set; }
    }
}