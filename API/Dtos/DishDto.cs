using API.Models;

namespace API.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? KiloCalories { get; set; }
    }
}